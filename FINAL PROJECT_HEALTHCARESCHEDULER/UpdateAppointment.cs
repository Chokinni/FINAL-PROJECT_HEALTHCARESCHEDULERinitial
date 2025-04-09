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
    public partial class UpdateAppointment : UserControl
    {
        private string loggedInFirstName;
        private string loggedInLastName;
        public UpdateAppointment(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;
        }

        private void UpdateAppointment_Load(object sender, EventArgs e)
        {

        }

        private void btn_LoadSchedule_Click(object sender, EventArgs e)
        {
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

                        // Step 2: Retrieve appointments for the logged-in user
                        string scheduleQuery = "SELECT * FROM Patientsschedule WHERE UserID = @UserID";
                        using (OleDbCommand scheduleCmd = new OleDbCommand(scheduleQuery, con))
                        {
                            scheduleCmd.Parameters.AddWithValue("@UserID", userID);

                            // Step 3: Execute the query and load the data into a DataTable
                            using (OleDbDataAdapter adapter = new OleDbDataAdapter(scheduleCmd))
                            {
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);

                                // Step 4: Bind the DataTable to your table control (e.g., DataGridView)
                                table_UpdateAppointment.DataSource = dt;

                                // Optional: Display a success message
                                if (dt.Rows.Count > 0)
                                {
                                    MessageBox.Show("Schedule loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No appointments found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            // Step 1: Check if a row is selected in the DataGridView
            if (table_UpdateAppointment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 2: Get the selected row
            DataGridViewRow selectedRow = table_UpdateAppointment.SelectedRows[0];

            // Step 3: Retrieve the UserID and original AppointmentDate from the selected row
            int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
            DateTime originalAppointmentDate = Convert.ToDateTime(selectedRow.Cells["AppointmentDate"].Value);
            string currentStatus = selectedRow.Cells["Status"].Value.ToString();

            // Step 4: Get the new appointment date from the DateTimePicker (datetime_sched)
            DateTime newAppointmentDate = datetime_sched.Value;

            // Step 5: Check if the status is "Accepted" and reset it to "Pending" if necessary
            string newStatus = currentStatus == "Accepted" ? "Pending" : currentStatus;

            // Step 6: Update the appointment in the database
            using (OleDbConnection con = DatabaseHelper.GetConnection())
            {
                try
                {
                    con.Open();
                    string updateQuery = @"
                UPDATE Patientsschedule 
                SET AppointmentDate = @NewAppointmentDate, 
                    Status = @NewStatus 
                WHERE UserID = @UserID 
                  AND AppointmentDate = @OriginalAppointmentDate";
                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@NewAppointmentDate", newAppointmentDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@NewStatus", newStatus);
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@OriginalAppointmentDate", originalAppointmentDate.ToString("yyyy-MM-dd HH:mm:ss"));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn_LoadSchedule_Click(sender, e); // Refresh the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Failed to update appointment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void datetime_sched_ValueChanged(object sender, EventArgs e)
        {
            string selectedDateTime = datetime_sched.Value.ToString("MM/dd/yyyy hh:mm tt");

            datetime_sched.Format = DateTimePickerFormat.Custom;
            datetime_sched.CustomFormat = "MM/dd/yyyy hh:mm tt"; // Date + Time (12-hour format)
            datetime_sched.ShowUpDown = true; // Removes dropdown calendar
        }
    }
}
