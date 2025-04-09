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
    public partial class CancelPatientAppointment : UserControl
    {
        private string loggedInFirstName;
        private string loggedInLastName;
        public CancelPatientAppointment(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;
        }

        private void datetime_cancelPatientAppointment_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_loadschedforcancel_Click(object sender, EventArgs e)
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
                        WHERE (Status = @StatusPending OR Status = @StatusCancelled)
                          AND Doctor = @Doctor";
                    using (OleDbCommand pendingCmd = new OleDbCommand(pendingQuery, con))
                    {
                        pendingCmd.Parameters.AddWithValue("@Status", "Pending");
                        pendingCmd.Parameters.AddWithValue("@StatusCancelled", "Cancelled");
                        pendingCmd.Parameters.AddWithValue("@Doctor", loggedInFirstName + " " + loggedInLastName); // Logged-in doctor's name

                        // Step 2: Execute the query and load the data into a DataTable
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(pendingCmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Step 3: Bind the DataTable to your table control (e.g., DataGridView)
                            table_CancelpatientAppointment.DataSource = dt;

                            // Optional: Display a success message
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Appointments loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No appointments found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_cancelpatientAppointment_Click(object sender, EventArgs e)
        {
            if (table_CancelpatientAppointment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to cancel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 2: Get the selected row
            DataGridViewRow selectedRow = table_CancelpatientAppointment.SelectedRows[0];

            // Step 3: Retrieve the AppointmentID and current Status from the selected row
            int appointmentID = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
            string currentStatus = selectedRow.Cells["Status"].Value.ToString();

            // Step 4: Check if the current status is "Pending"
            if (currentStatus != "Pending")
            {
                MessageBox.Show("Only appointments with 'Pending' status can be cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 5: Update the status to "Cancelled" in the database
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
                        cmd.Parameters.AddWithValue("@Status", "Cancelled");
                        cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn_loadschedforcancel_Click(sender, e); // Refresh the DataGridView
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

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // Step 1: Check if a row is selected in the DataGridView
            if (table_CancelpatientAppointment.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            // Step 2: Retrieve AppointmentID, UserID, and Status from the selected row
            int appointmentID;
            int userID;
            string status;

            // Ensure AppointmentID, UserID, and Status are valid
            if (!int.TryParse(table_CancelpatientAppointment.CurrentRow.Cells["AppointmentID"].Value.ToString(), out appointmentID))
            {
                MessageBox.Show("Invalid AppointmentID. Cannot delete.");
                return;
            }

            if (!int.TryParse(table_CancelpatientAppointment.CurrentRow.Cells["UserID"].Value.ToString(), out userID))
            {
                MessageBox.Show("Invalid UserID. Cannot delete.");
                return;
            }

            status = table_CancelpatientAppointment.CurrentRow.Cells["Status"].Value.ToString();

            // Step 3: Check if the status is "Cancelled"
            if (status != "Cancelled")
            {
                MessageBox.Show("Only appointments with 'Cancelled' status can be deleted.");
                return;
            }

            // Step 4: Use DatabaseHelper to get a connection
            using (OleDbConnection con = DatabaseHelper.GetConnection())
            {
                try
                {
                    con.Open();

                    // Step 5: Check if the UserID exists in the Users table
                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE ID = @UserID";
                    using (OleDbCommand checkUserCmd = new OleDbCommand(checkUserQuery, con))
                    {
                        checkUserCmd.Parameters.AddWithValue("@UserID", userID);
                        int userCount = (int)checkUserCmd.ExecuteScalar();

                        if (userCount == 0)
                        {
                            MessageBox.Show("UserID does not exist in the Users table. Cannot delete appointment.");
                            return;
                        }
                    }

                    // Step 6: Delete the appointment from the Appointments table (only if status is "Cancelled")
                    string deleteAppointmentQuery = @"
                DELETE FROM Appointments 
                WHERE AppointmentID = @AppointmentID 
                  AND UserID = @UserID 
                  AND Status = @Status";
                    using (OleDbCommand cmd = new OleDbCommand(deleteAppointmentQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@Status", "Cancelled");

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cancelled appointment deleted successfully.");
                            table_CancelpatientAppointment.Rows.RemoveAt(table_CancelpatientAppointment.CurrentRow.Index); // Remove the row from the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Deletion failed. Appointment may not have 'Cancelled' status or does not exist.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
