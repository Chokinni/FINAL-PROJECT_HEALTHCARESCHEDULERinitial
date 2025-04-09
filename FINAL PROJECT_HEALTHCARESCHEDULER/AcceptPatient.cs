using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class AcceptPatient : UserControl
    {
        private string loggedInFirstName;
        private string loggedInLastName;
        public AcceptPatient(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;
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
            using (OleDbConnection con = DatabaseHelper.GetConnection())
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

                            // Step 3: Bind the DataTable to your table control (e.g., DataGridView)
                            table_AcceptAppointment.DataSource = dt;
                            if (table_AcceptAppointment.Columns.Contains("Doctor"))
                            {
                                table_AcceptAppointment.Columns["Doctor"].Visible = false;
                            }

                            // Optional: Display a success message
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
            using (OleDbConnection con = DatabaseHelper.GetConnection())
            {
                try
                {
                    con.Open();
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
                    MessageBox.Show("Error confirming appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }

            using (OleDbConnection con = DatabaseHelper.GetConnection())
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
                        string meetLink = "Walaaaa";
                        string doctorName = loggedInFirstName + " " + loggedInLastName;

                        // Step 2: Insert Appointment into the Appointments table
                        string insertQuery = @"INSERT INTO Meeting ([MeetingLink],[MeetingStatus],[UserID], [DoctorName])
                                      VALUES (@MeetingLink, @MeetingStatus, @UserID, @DoctorName);";

                        using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, con))
                        {
                            insertCmd.Parameters.AddWithValue("@MeetingLink", meetLink);
                            insertCmd.Parameters.AddWithValue("@MeetingStatus", meetStatus);
                            insertCmd.Parameters.AddWithValue("@UserID", userID);
                            insertCmd.Parameters.AddWithValue("@DoctorName", doctorName);


                            int rowsAffected = insertCmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Appointment successfully booked!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Booking failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
