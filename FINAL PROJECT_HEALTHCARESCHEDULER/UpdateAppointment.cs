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
using Tulpep.NotificationWindow;
using System.Net;
using System.Net.Mail;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class UpdateAppointment : BaseClass
    {

        public UpdateAppointment(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;
            
        }

        private void UpdateAppointment_Load(object sender, EventArgs e)
        {

        }
        private DataTable originalData;
        private void btn_LoadSchedule_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = GetConnection())
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
                                if (table_UpdateAppointment.Columns.Contains("DoctorNotification"))
                                    table_UpdateAppointment.Columns["DoctorNotification"].Visible = false;

                                if (table_UpdateAppointment.Columns.Contains("IsUpdated"))
                                    table_UpdateAppointment.Columns["IsUpdated"].Visible = false;
                                var dgv = table_UpdateAppointment;

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
            string doctorName = selectedRow.Cells["Doctor"].Value.ToString();
            if (currentStatus == "Cancelled")
            {
                MessageBox.Show("This appointment has already been cancelled and cannot be updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without updating
            }

            // Step 4: Get the new appointment date from the DateTimePicker (datetime_sched)
            DateTime newAppointmentDate = datetime_sched.Value;

            // Step 5: Check if the status is "Accepted" and reset it to "Pending" if necessary
            string newStatus = currentStatus == "Accepted" ? "Pending" : currentStatus;

            // Step 6: Update the appointment in the database
            using (OleDbConnection con = BaseClass.GetConnection())
            {
                try
                {
                    con.Open();
                    string updateQuery = @"
                UPDATE Patientsschedule 
                SET AppointmentDate = @NewAppointmentDate, 
                    Status = @NewStatus,
                    DoctorNotification = False,
                    IsUpdated= -1
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

                            // Get doctor's email from database
                            string doctorEmail = GetDoctorEmail(doctorName, con);

                            if (!string.IsNullOrEmpty(doctorEmail))
                            {
                                SendEmailToDoctor(doctorEmail, doctorName, newAppointmentDate);
                            }
                            MessageBox.Show("Appointment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Optional: Show confirmation to patient

                            PopupNotifier popup = new PopupNotifier();
                            popup.TitleText = "Update Successful";
                            popup.ContentText = $"Your appointment with Dr. {doctorName} has been updated to {newAppointmentDate:MM/dd/yyyy hh:mm tt}";
                            popup.Popup();
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
        private void SendEmailToDoctor(string doctorEmail, string doctorName, DateTime newAppointmentDate)
        {
            try
            {
                string senderEmail = "migel24asid@gmail.com";
                string senderAppPassword = "lcvl rhgt pqki kxbk";

                string subject = $"Appointment Rescheduled: {loggedInFirstName} {loggedInLastName} - {newAppointmentDate.ToString("MMMM d, yyyy")}";

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
            background-color: #005b96;
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
        .button {{
            display: inline-block;
            background-color: #005b96;
            color: white;
            padding: 10px 20px;
            text-decoration: none;
            border-radius: 4px;
            margin: 10px 0;
        }}
    </style>
</head>
<body>
    <div class='header'>
        <h2>Cebu South General Hopsital</h2>
    </div>
    
    <div class='content'>
        <p>Dear Dr. {doctorName},</p>
        
        <p>Your patient <strong>{loggedInFirstName} {loggedInLastName}</strong> has rescheduled their appointment.</p>
        
        <div class='appointment-details'>
            <h3>Updated Appointment Details</h3>
            <p><strong>Date:</strong> {newAppointmentDate.ToString("dddd, MMMM d, yyyy")}</p>
            <p><strong>Time:</strong> {newAppointmentDate.ToString("h:mm tt")}</p>
        </div>
        
        <p>Please review this change in your schedule and confirm your availability.</p>
        
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
                Console.WriteLine("Error sending email: " + ex.Message);
                // Consider logging this error for administrative review
            }
        }

        private void datetime_sched_ValueChanged(object sender, EventArgs e)
        {
            string selectedDateTime = datetime_sched.Value.ToString("MM/dd/yyyy hh:mm tt");

            datetime_sched.Format = DateTimePickerFormat.Custom;
            datetime_sched.CustomFormat = "MM/dd/yyyy hh:mm tt"; // Date + Time (12-hour format)
            datetime_sched.ShowUpDown = true; // Removes dropdown calendar
        }

        private void rxt_searchDoctor_TextChanged(object sender, EventArgs e)
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

            string searchText = rxt_searchDoctor.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                // If search text is empty, show all records
                table_UpdateAppointment.DataSource = originalData;
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
            table_UpdateAppointment.DataSource = filteredData;

            if (filteredData.Rows.Count == 0)
            {
                MessageBox.Show("No appointments found with this doctor.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void strip_viewdocprof_Opening(object sender, CancelEventArgs e)
        {
            if (table_UpdateAppointment.SelectedRows.Count > 0)
            {
                string fullName = table_UpdateAppointment.SelectedRows[0].Cells["Doctor"].Value.ToString();

                // NEW: Better name handling
                string[] nameParts = fullName.Trim().Split(new[] { ' ' }, 2); // Split into max 2 parts

                string firstName = nameParts[0];
                string lastName = nameParts.Length > 1 ? nameParts[1] : ""; // Handle single-word names

                // DEBUG: Show what we're searching for
                MessageBox.Show($"Searching for:\nFirst Name: '{firstName}'\nLast Name: '{lastName}'",
                              "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DoctorProfile profileFormdoc = new DoctorProfile(firstName, lastName);
                profileFormdoc.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }
    }
}
