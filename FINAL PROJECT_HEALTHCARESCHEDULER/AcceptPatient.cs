using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class AcceptPatient : BaseClass
    {



        public AcceptPatient(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;

            CustomizeButton(btn_confirm);  // Custom styling for btn_confirm
            CustomizeButton(btn_loadscheddoc); // Custom styling for btn_loadscheddoc
                                               // Add other button customizations if necessary

        }

        private void CustomizeButton(Button btn)
        {
            btn.BackColor = Color.SkyBlue; // Background color
            btn.ForeColor = Color.White; // Text color
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Font style and size
            btn.Size = new Size(150, 40); // Set button size
            btn.FlatStyle = FlatStyle.Flat; // Removes default 3D look
            btn.FlatAppearance.BorderSize = 0; // Remove border
            btn.UseVisualStyleBackColor = false; // Ensures no default visual style

            // Add hover effect for better user interaction
            btn.MouseEnter += (sender, e) =>
            {
                btn.BackColor = Color.LightSkyBlue; // Lighter color on hover
            };

            btn.MouseLeave += (sender, e) =>
            {
                btn.BackColor = Color.SkyBlue; // Original color when mouse leaves
            };
        }
        private void MakeRoundedButton(Button btn, int radius)
        {
            var bounds = new Rectangle(0, 0, btn.Width, btn.Height);
            int diameter = radius * 2;
            var path = new System.Drawing.Drawing2D.GraphicsPath();

            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90); // Top left
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90); // Top right
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90); // Bottom right
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90); // Bottom left
            path.CloseFigure();

            btn.Region = new Region(path);
        }




        private void datetime_Doctor_ValueChanged(object sender, EventArgs e)
        {
            //string selectedDateTime = datetime_Doctor.Value.ToString("MM/dd/yyyy hh:mm tt");

            //datetime_Doctor.Format = DateTimePickerFormat.Custom;
            // datetime_Doctor.CustomFormat = "MM/dd/yyyy hh:mm tt"; // Date + Time (12-hour format)
            // datetime_Doctor.ShowUpDown = true; // Removes dropdown calendar
        }

        private void btn_loadscheddoc_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    // Step 1: Retrieve pending appointments for the logged-in doctor
                    string pendingQuery = @"
            SELECT * 
            FROM Doctorschedule 
            WHERE Status = @Status 
              AND Doctor = @Doctor";
                    using (OleDbCommand pendingCmd = new OleDbCommand(pendingQuery, con))
                    {
                        pendingCmd.Parameters.AddWithValue("@Status", "Pending");
                        pendingCmd.Parameters.AddWithValue("@Doctor", loggedInFirstName + " " + loggedInLastName);

                        // Step 2: Execute the query and load the data into a DataTable
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(pendingCmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Step 3: Bind the DataTable to your DataGridView
                            table_AcceptAppointment.DataSource = dt;

                            // Hide "Doctor" column if it exists
                            if (table_AcceptAppointment.Columns.Contains("Doctor"))
                            {
                                table_AcceptAppointment.Columns["Doctor"].Visible = false;
                            }

                            // ✅ DESIGN: Apply healthcare-style DataGridView formatting
                            var dgv = table_AcceptAppointment;

                            dgv.EnableHeadersVisualStyles = false;
                            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
                            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                            dgv.ColumnHeadersHeight = 35;

                            dgv.DefaultCellStyle.BackColor = Color.White;
                            dgv.DefaultCellStyle.ForeColor = Color.Black;
                            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

                            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

                            dgv.RowTemplate.Height = 30;
                            dgv.GridColor = Color.LightGray;

                            dgv.BorderStyle = BorderStyle.Fixed3D;
                            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            dgv.AutoResizeColumns();

                            // Optional: Display a message
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Pending appointments loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No pending appointments found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading pending appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void ConfirmMeeting()
        {
            using (OleDbConnection con = BaseClass.GetConnection())
            {
                try
                {
                    con.Open();

                    // Step 1: Retrieve the UserID of the logged-in user
                    string userQuery = "SELECT ID FROM USERS WHERE [FirstName] = @FirstName AND [LastName] = @LastName";
                    using (OleDbCommand userCmd = new OleDbCommand(userQuery, con))
                    {
                        userCmd.Parameters.AddWithValue("@FirstName", loggedInFirstName);
                        userCmd.Parameters.AddWithValue("@LastName", loggedInLastName);

                        object result = userCmd.ExecuteScalar();
                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Stop execution if user doesn't exist
                        }

                        int userID = Convert.ToInt32(result); // Get the user ID
                        string meetStatus = "Pending";
                        string meetLink = "On the Making";
                        string doctorName = loggedInFirstName + " " + loggedInLastName;

                        string appointmentQuery = @"
                                            SELECT AppointmentID 
                                            FROM Appointments 
                                            WHERE Doctor = @DoctorName AND Status = 'Pending'
                                            ORDER BY AppointmentDate DESC";

                        int appointmentID;
                        using (OleDbCommand appointmentCmd = new OleDbCommand(appointmentQuery, con))
                        {
                            appointmentCmd.Parameters.AddWithValue("@DoctorName", doctorName);

                            object appResult = appointmentCmd.ExecuteScalar();
                            if (appResult == null || appResult == DBNull.Value)
                            {
                                MessageBox.Show("No pending appointment found for this doctor!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            appointmentID = Convert.ToInt32(appResult);
                        }
                        // Step 2: Insert Appointment into the Appointments table
                        string insertQuery = @"INSERT INTO Meeting ([MeetingLink], [MeetingStatus], [UserID], [DoctorName], [AppointmentID])
                                                VALUES (@MeetingLink, @MeetingStatus, @UserID, @DoctorName, @AppointmentID)";

                        using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, con))
                        {
                            insertCmd.Parameters.AddWithValue("@MeetingLink", meetLink);
                            insertCmd.Parameters.AddWithValue("@MeetingStatus", meetStatus);
                            insertCmd.Parameters.AddWithValue("@UserID", userID);
                            insertCmd.Parameters.AddWithValue("@DoctorName", doctorName);
                            insertCmd.Parameters.AddWithValue("@AppointmentID", appointmentID);

                            int rowsAffected = insertCmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Meeting successfully confirmed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Meeting confirmation failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btn_confirm_Click(object sender, EventArgs e)
        {
            // Step 1: Check if a row is selected in the DataGridView
            if (table_AcceptAppointment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to confirm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 2: Get the selected row
            DataGridViewRow selectedRow = table_AcceptAppointment.SelectedRows[0];

            // Step 3: Retrieve the AppointmentID and current Status from the selected row
            int appointmentID = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
            string currentStatus = selectedRow.Cells["Status"].Value.ToString();

            // Step 4: Check if the current status is "Pending"
            if (currentStatus != "Pending")
            {
                MessageBox.Show("Only appointments with 'Pending' status can be confirmed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 5: Update the status to "Accepted" in the database
            using (OleDbConnection con = BaseClass.GetConnection())
            {
                try
                {
                    con.Open();
                    /*string updateQuery = @"
                                        UPDATE Doctorschedule 
                                        SET Status = @Status 
                                        WHERE AppointmentID = @AppointmentID";*/

                    string updateQuery = @"
                                        UPDATE Doctorschedule 
                                        SET Status = @Status 
                                        WHERE AppointmentID = @AppointmentID";
                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Status", "Accepted");
                        cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            ConfirmMeeting();
                            MessageBox.Show("Appointment confirmed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn_loadscheddoc_Click(sender, e); // Refresh the DataGridView

                        }
                        else
                        {
                            MessageBox.Show("Failed to confirm appointment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error confirming appointment:  {ex.StackTrace} " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }


        }

        private void Patient_profilestrip_Opening(object sender, CancelEventArgs e)
        {
            if (table_AcceptAppointment.SelectedRows.Count > 0)
            {
                string fullName = table_AcceptAppointment.SelectedRows[0].Cells["Patient"].Value.ToString();

                // Split full name into parts
                string[] nameParts = fullName.Trim().Split(' ');

                // Assign first and last name
                string firstName = nameParts.Length > 0 ? nameParts[0] : "";
                string lastName = nameParts.Length > 1 ? string.Join(" ", nameParts.Skip(1)) : "";

                // Open the patient profile form with first and last name
                PatientProfile profileForm = new PatientProfile(firstName, lastName);
                profileForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }
    }
}
