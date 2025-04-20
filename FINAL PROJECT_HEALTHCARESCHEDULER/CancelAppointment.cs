using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

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

        private DataTable originalData;
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
            string doctorName = selectedRow.Cells["Doctor"].Value?.ToString();
            string patientName = selectedRow.Cells["Patient"].Value?.ToString();
            int appointmentID = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
            // Step 4: Update the status to "Cancelled" in the database
            using (OleDbConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    string doctorEmail = GetDoctorEmail(doctorName, con);
                    string updateQuery = @"
                        UPDATE Patientsschedule 
                        SET Status = @Status, DoctorNotification = False
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
                            // Send email notification to doctor
                            if (!string.IsNullOrEmpty(doctorEmail))
                            {
                                SendCancellationEmail(doctorEmail, doctorName, patientName, selectedAppointmentDate);
                            }
                            PopupNotifier popup = new PopupNotifier();
                            popup.TitleText = "Appointment Cancelled";
                            popup.ContentText = $"{patientName} has cancelled their appointment on {selectedAppointmentDate:MM/dd/yyyy hh:mm tt}.";
                            popup.Popup();

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

        // Add these helper methods to your class
        private string GetDoctorEmail(string doctorName, OleDbConnection con)
        {
            try
            {
                string[] names = doctorName.Split(' ');
                if (names.Length < 2) return null;

                string query = "SELECT EmailAddress FROM USERS WHERE [FirstName] = @FirstName AND [LastName] = @LastName AND [Role] = 'Doctor'";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FirstName", names[0]);
                    cmd.Parameters.AddWithValue("@LastName", names[1]);

                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
            catch
            {
                return null;
            }
        }
        private void SendCancellationEmail(string doctorEmail, string doctorName, string patientName, DateTime appointmentDate)
        {
            try
            {
                string senderEmail = "migel24asid@gmail.com";
                string senderAppPassword = "lcvl rhgt pqki kxbk";

                string subject = $"Appointment Cancellation: {patientName} - {appointmentDate.ToString("MMMM d, yyyy")}";

                string body = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            line-height: 1.6;
            color: #333;
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
        }}
        .header {{
            background-color: #d9534f;
            color: white;
            padding: 20px;
            text-align: center;
            border-radius: 5px 5px 0 0;
        }}
        .content {{
            padding: 20px;
            background-color: #f9f9f9;
            border: 1px solid #ddd;
            border-top: none;
        }}
        .footer {{
            margin-top: 20px;
            font-size: 0.9em;
            color: #777;
            text-align: center;
        }}
        .appointment-details {{
            background-color: white;
            padding: 15px;
            border: 1px solid #eee;
            border-radius: 4px;
            margin: 15px 0;
        }}
    </style>
</head>
<body>
    <div class='header'>
        <h2>Appointment Cancellation Notice</h2>
    </div>
    
    <div class='content'>
        <p>Dear Dr. {doctorName},</p>
        
        <p>We regret to inform you that your patient <strong>{patientName}</strong> has cancelled their upcoming appointment.</p>
        
        <div class='appointment-details'>
            <h3>Cancelled Appointment Details</h3>
            <p><strong>Original Date:</strong> {appointmentDate.ToString("dddd, MMMM d, yyyy")}</p>
            <p><strong>Original Time:</strong> {appointmentDate.ToString("h:mm tt")}</p>
        </div>
        
        <p>This time slot is now available for other patients. Please log in to your dashboard to view your updated schedule.</p>
        
        <p>Best regards,</p>
        <p>The Hospital Scheduler Team</p>
    </div>
    
    <div class='footer'>
        <p>This is an automated notification. Please do not reply to this email.</p>
        <p>&copy; {DateTime.Now.Year} Hospital Scheduler System</p>
    </div>
</body>
</html>";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail, "Hospital Scheduler");
                mail.To.Add(doctorEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderAppPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending cancellation email: " + ex.Message);
                // Consider logging this error for administrative review
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
                                if (table_CancelAppointment.Columns.Contains("DoctorNotification"))
                                    table_CancelAppointment.Columns["DoctorNotification"].Visible = false;

                                if (table_CancelAppointment.Columns.Contains("IsUpdated"))
                                    table_CancelAppointment.Columns["IsUpdated"].Visible = false;
                                var dgv = table_CancelAppointment;

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
                                originalData = dt;

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
            int appointmentID = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
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
                            // Mark that patient needs notification
                            string updateNotifQuery = @"UPDATE Doctorschedule 
                                  SET PatientNotification = '1' 
                                  WHERE AppointmentID = @AppointmentID";

                            using (OleDbCommand notifCmd = new OleDbCommand(updateNotifQuery, con))
                            {
                                notifCmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
                                notifCmd.ExecuteNonQuery();
                            }


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

        private void txt_searchDoctor_TextChanged(object sender, EventArgs e)
        {
            SearchByDoctorName();
        }

        private void SearchByDoctorName()
        {
            if (originalData == null)
            {
                MessageBox.Show("Please load appointments first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string searchText = txt_searchDoctor.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                // If search text is empty, show all records
                table_CancelAppointment.DataSource = originalData;
                return;
            }

            // Create a new DataTable with the same schema
            DataTable filteredData = originalData.Clone();

            // Filter rows based on doctor name
            foreach (DataRow row in originalData.Rows)
            {
                // Adjust "DoctorName" to the actual column name in your table
                if (row["Doctor"].ToString().ToLower().Contains(searchText))
                {
                    filteredData.ImportRow(row);
                }
            }

            // Update the DataGridView with filtered results
            table_CancelAppointment.DataSource = filteredData;

            if (filteredData.Rows.Count == 0)
            {
                MessageBox.Show("No appointments found with this doctor.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
