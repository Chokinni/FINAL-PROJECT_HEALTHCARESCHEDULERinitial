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
    public partial class CancelAppointment : BaseClass
    {
        
        private int selectedUserID; // Store the selected appointment's UserID
        private DateTime selectedAppointmentDate; // Store the selected appointment's date
        public CancelAppointment(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            // Step 1: Check if a row is selected in the DataGridView
            if (table_CancelAppointment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to cancel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 2: Get the selected row
            DataGridViewRow selectedRow = table_CancelAppointment.SelectedRows[0];

            // Step 3: Retrieve the UserID and AppointmentDate from the selected row
            selectedUserID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
            selectedAppointmentDate = Convert.ToDateTime(selectedRow.Cells["AppointmentDate"].Value);

            // Step 4: Update the status to "Cancelled" in the database
            using (OleDbConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    string updateQuery = @"
                        UPDATE Patientsschedule 
                        SET Status = @Status 
                        WHERE UserID = @UserID 
                          AND AppointmentDate = @AppointmentDate";
                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Status", "Cancelled");
                        cmd.Parameters.AddWithValue("@UserID", selectedUserID);
                        cmd.Parameters.AddWithValue("@AppointmentDate", selectedAppointmentDate.ToString("yyyy-MM-dd HH:mm:ss"));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn_LoadAppCancel_Click(sender, e); // Refresh the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Failed to cancel appointment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error cancelling appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }

        }

        private void datetime_sched_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_LoadAppCancel_Click(object sender, EventArgs e)
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
                                table_CancelAppointment.DataSource = dt;

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

        private void CancelAppointment_Load(object sender, EventArgs e)
        {

        }

        private void btn_deleteapp_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (table_CancelAppointment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to delete.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = table_CancelAppointment.SelectedRows[0];
            string status = selectedRow.Cells["Status"].Value?.ToString();

            // Only allow deletion of cancelled appointments
            if (status != "Cancelled")
            {
                MessageBox.Show("Only cancelled appointments can be deleted.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get appointment details
            int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
            DateTime appointmentDate = Convert.ToDateTime(selectedRow.Cells["AppointmentDate"].Value);

            // Confirm deletion
            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to permanently delete this cancelled appointment?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            using (OleDbConnection con = BaseClass.GetConnection())
            {
                try
                {
                    con.Open();
                    string deleteQuery = @"
                DELETE FROM Appointments 
                WHERE UserID = @UserID 
                  AND AppointmentDate = @AppointmentDate
                  AND Status = 'Cancelled'";

                    using (OleDbCommand cmd = new OleDbCommand(deleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment deleted successfully!", "Success",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn_LoadAppCancel_Click(sender, e); // Refresh the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete appointment.", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting appointment: " + ex.Message, "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
