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
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Net.Mail;
using System.Net;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class DoctorMeeting : BaseClass
    {

        public DoctorMeeting(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;
        }
        private DataTable originalData;

        private void btn_loadschedmeet_Click(object sender, EventArgs e)
        {
            // Clear existing data from the table to avoid duplicates
            table_CreateMeeting.DataSource = null;

            // SQL query to get only the "Online" appointments that are accepted by the doctor
            string query = "SELECT Doctor, Patient, AppointmentType, Status, MeetingLink, AppointmentDate, MeetingStatus " +
               "FROM Meetingtwo " +
               "WHERE AppointmentType = 'Online' AND Status = 'Accepted' AND Doctor = @DoctorName";

            using (OleDbConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        // Add parameters to avoid SQL injection
                        cmd.Parameters.AddWithValue("?", loggedInFirstName + " " + loggedInLastName);

                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the new data to the table
                        table_CreateMeeting.DataSource = dt;
                        var dgv = table_CreateMeeting;

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
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading schedule: " + ex.Message);
                }
            }

        }

        private async void btn_SCHEDULE_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (table_CreateMeeting.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to schedule the meeting.");
                return;
            }

            // Get selected row values
            DataGridViewRow row = table_CreateMeeting.SelectedRows[0];
            string doctor = row.Cells["Doctor"].Value.ToString();
            string patient = row.Cells["Patient"].Value.ToString();
            DateTime appointmentDate = Convert.ToDateTime(row.Cells["AppointmentDate"].Value);
           

            try
            {
                
                (string doctorEmail, string doctorAppPassword) = GetDoctorEmailAndPassword(doctor);

                if (string.IsNullOrEmpty(doctorEmail) || string.IsNullOrEmpty(doctorAppPassword))
                {
                    MessageBox.Show("Could not retrieve doctor's email credentials from database.");
                    return;
                }
                
                using (var stream = new FileStream(@"C:\Ccode\credentials1.json", FileMode.Open, FileAccess.Read))
                {
                    var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        new[] { CalendarService.Scope.Calendar },
                        "user", // Can be any string, it identifies the user
                        CancellationToken.None,
                        new FileDataStore("DriveServiceCredentials")
                    );

                    // Create calendar service
                    var service = new CalendarService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "HealthcareScheduler"
                    });

                    // Set start and end time (example: 30-minute meeting)
                    var startTime = appointmentDate;
                    var endTime = appointmentDate.AddMinutes(30);

                    // Create calendar event with Meet link
                    var calendarEvent = new Event()
                    {
                        Summary = $"Consultation: Dr. {doctor} & {patient}",
                        Description = "Online consultation using Google Meet.",
                        Start = new EventDateTime() { DateTime = startTime, TimeZone = "Asia/Manila" },
                        End = new EventDateTime() { DateTime = endTime, TimeZone = "Asia/Manila" },
                        ConferenceData = new ConferenceData()
                        {
                            CreateRequest = new CreateConferenceRequest()
                            {
                                RequestId = Guid.NewGuid().ToString(),
                                ConferenceSolutionKey = new ConferenceSolutionKey() { Type = "hangoutsMeet" }
                            }
                        },
                        Attendees = new List<EventAttendee> { new EventAttendee() { Email = "example@gmail.com" } }
                    };

                    // Insert event
                    var request = service.Events.Insert(calendarEvent, "primary");
                    request.ConferenceDataVersion = 1;
                    var createdEvent = await request.ExecuteAsync();

                    // Get Google Meet link
                    string meetLink = createdEvent.ConferenceData?.EntryPoints?.FirstOrDefault()?.Uri;

                    if (string.IsNullOrEmpty(meetLink))
                    {
                        MessageBox.Show("Failed to generate Meet link.");
                        return;
                    }

                    // Update database with the new Meet link
                    string updateQuery = "UPDATE Meetingtwo SET MeetingLink = ? WHERE Doctor = ? AND Patient = ? AND AppointmentDate = ?";

                    using (OleDbConnection conn = GetConnection())
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("?", meetLink);
                            cmd.Parameters.AddWithValue("?", doctor);
                            cmd.Parameters.AddWithValue("?", patient);
                            cmd.Parameters.AddWithValue("?", appointmentDate);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                string patientEmail = GetPatientEmail(patient, conn);

                                if (!string.IsNullOrEmpty(patientEmail))
                                {
                                    // Send email notification to patient using doctor's credentials
                                    SendMeetingScheduledEmail(doctorEmail, doctorAppPassword, patientEmail,
                                                           patient, doctor, meetLink, appointmentDate);
                                }
                                MessageBox.Show("Meeting successfully scheduled and saved with Meet link!");
                                WebViewcreateMeet webViewForm = new WebViewcreateMeet(loggedInFirstName, loggedInLastName, meetLink);
                                webViewForm.Show();
                                await webViewForm.InitializeWebView();

                                btn_loadschedmeet_Click(null, null); // Reload the table
                            }
                            else
                            {
                                MessageBox.Show("Database update failed.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // New method to get doctor's email and app password
        private (string email, string appPassword) GetDoctorEmailAndPassword(string doctorName)
        {
            using (OleDbConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    string[] names = doctorName.Split(' ');
                    if (names.Length < 2) return (null, null);

                    string query = "SELECT EmailAddress, AppPassword FROM USERS WHERE [FirstName] = @FirstName AND [LastName] = @LastName AND [Role] = 'Doctor'";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", names[0]);
                        cmd.Parameters.AddWithValue("@LastName", names[1]);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string email = reader["EmailAddress"].ToString();
                                string appPassword = reader["AppPassword"].ToString();
                                return (email, appPassword);
                            }
                        }
                    }
                }
                catch
                {
                    return (null, null);
                }
            }
            return (null, null);
        }

        private void SendMeetingScheduledEmail(string senderEmail, string senderAppPassword,
                                 string patientEmail, string patientName,
                                 string doctorName, string meetLink,
                                 DateTime appointmentDate)
        {
            try
            {
                string subject = $"Your Online Consultation with Dr. {doctorName.Split(' ')[0]} - {appointmentDate.ToString("MMMM d, yyyy")}";

                string body = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        body {{
            font-family: 'Segoe UI', Arial, sans-serif;
            line-height: 1.6;
            color: #333333;
            max-width: 600px;
            margin: 0 auto;
            padding: 0;
            background-color: #f7f7f7;
        }}
        .email-container {{
            background-color: #ffffff;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.05);
            overflow: hidden;
            margin: 20px auto;
        }}
        .header {{
            background-color: #1976D2; /* Rich blue color */
            color: white;
            padding: 25px;
            text-align: center;
        }}
        .header h1 {{
            margin: 0;
            font-size: 22px;
            font-weight: 500;
        }}
        .content {{
            padding: 25px;
        }}
        .greeting {{
            font-size: 16px;
            margin-bottom: 20px;
        }}
        .appointment-card {{
            background-color: #f8f9fa;
            border-left: 4px solid #1976D2; /* Matching blue accent */
            padding: 15px;
            margin: 20px 0;
            border-radius: 0 4px 4px 0;
        }}
        .appointment-card h3 {{
            margin-top: 0;
            color: #1976D2; /* Matching blue text */
            font-size: 18px;
        }}
        .detail-row {{
            margin-bottom: 8px;
            display: flex;
        }}
        .detail-label {{
            font-weight: 600;
            width: 100px;
            color: #555;
        }}
        .meeting-button {{
            display: inline-block;
            background-color: #1976D2; /* Matching blue background */
            color: white !important;
            text-decoration: none;
            padding: 12px 24px;
            border-radius: 4px;
            font-weight: 500;
            margin: 20px 0;
            text-align: center;
            transition: background-color 0.3s ease;
        }}
        .meeting-button:hover {{
            background-color: #1565C0; /* Slightly darker blue on hover */
        }}
        .instructions {{
            background-color: #f8f9fa;
            padding: 15px;
            border-radius: 4px;
            margin: 20px 0;
            font-size: 14px;
        }}
        .important-note {{
            background-color: #E3F2FD; /* Light blue background */
            border-left: 4px solid #1976D2;
            padding: 15px;
            margin: 20px 0;
            border-radius: 0 4px 4px 0;
            font-size: 14px;
        }}
        .footer {{
            color: #777777;
            font-size: 12px;
            text-align: center;
            padding: 20px;
            border-top: 1px solid #eeeeee;
            margin-top: 20px;
        }}
        .signature {{
            margin-top: 25px;
        }}
    </style>
</head>
<body>
    <div class='email-container'>
        <div class='header'>
            <h1>Your Appointment Confirmation</h1>
        </div>
        
        <div class='content'>
            <div class='greeting'>
                <p>Dear {patientName},</p>
                <p>Your online consultation with Dr. {doctorName} has been scheduled.</p>
            </div>
            
            <div class='appointment-card'>
                <h3>Appointment Details</h3>
                <div class='detail-row'>
                    <span class='detail-label'>Date:</span>
                    <span>{appointmentDate.ToString("dddd, MMMM d, yyyy")}</span>
                </div>
                <div class='detail-row'>
                    <span class='detail-label'>Time:</span>
                    <span>{appointmentDate.ToString("h:mm tt")} (GMT+8)</span>
                </div>
                <div class='detail-row'>
                    <span class='detail-label'>Doctor:</span>
                    <span>Dr. {doctorName}</span>
                </div>
            </div>

            <div class='important-note'>
                <p><strong>Important:</strong> Please join the meeting <u>only at your scheduled time</u> ({appointmentDate.ToString("h:mm tt")}). 
                The meeting link will not be active before your appointment time.</p>
            </div>
            
            <div style='text-align: center;'>
                <a href='{meetLink}' class='meeting-button'>Join Online Consultation</a>
            </div>
            
            <div class='instructions'>
                <p><strong>How to prepare for your consultation:</strong></p>
                <ul>
                    <li>Test your microphone and camera before the meeting</li>
                    <li>Find a quiet, well-lit space</li>
                    <li>Have any relevant medical records ready</li>
                    <li>Join 5 minutes early to ensure proper connection</li>
                </ul>
            </div>
            
            <div class='signature'>
                <p>Best regards,</p>
                <p><strong>Dr. {doctorName}</strong></p>
                <p>Healthcare Provider</p>
            </div>
        </div>
        
        <div class='footer'>
            <p>This is an automated message. Please do not reply directly to this email.</p>
            <p>© {DateTime.Now.Year} Hospital Scheduler. All rights reserved.</p>
        </div>
    </div>
</body>
</html>";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail, $"Dr. {doctorName}");
                mail.To.Add(patientEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderAppPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
        private string GetPatientEmail(string patientName, OleDbConnection con)
        {
            try
            {
                string[] names = patientName.Split(' ');
                if (names.Length < 2)
                {
                    Console.WriteLine("Patient name format invalid");
                    return null;
                }

                string query = "SELECT EmailAddress FROM USERS WHERE [FirstName] = @FirstName AND [LastName] = @LastName AND [Role] = 'Patient'";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FirstName", names[0]);
                    cmd.Parameters.AddWithValue("@LastName", names[1]);

                    object result = cmd.ExecuteScalar();
                    string email = result?.ToString();
                    Console.WriteLine($"Found patient email: {email ?? "NULL"}");
                    return email;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting patient email: {ex.Message}");
                return null;
            }
        }

        private void btn_startmeeting_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (table_CreateMeeting.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a meeting to join.");
                return;
            }

            try
            {
                // Get the meeting link from the selected row
                DataGridViewRow row = table_CreateMeeting.SelectedRows[0];
                string meetLink = row.Cells["MeetingLink"].Value?.ToString();

                string meetingStatus = row.Cells["MeetingStatus"].Value?.ToString();

                // Check if meeting is already finished
                if (meetingStatus == "Finished")
                {
                    MessageBox.Show("This meeting has already been marked as finished and cannot be joined.");
                    return;
                }






                // Validate that the meeting link exists
                if (string.IsNullOrEmpty(meetLink))
                {
                    MessageBox.Show("No meeting link available for this appointment. Please schedule the meeting first.");
                    return;
                }

                // Open the WebView_joinmeet form with the meeting link
                WebView_joinmeet joinMeetForm = new WebView_joinmeet(loggedInFirstName, loggedInLastName, meetLink);
                joinMeetForm.Show();

                // Initialize the WebView and navigate to the meeting link
                joinMeetForm.InitializeWebViewAndJoin();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error joining meeting: " + ex.Message);
            }
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (table_CreateMeeting.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a meeting to mark as finished.");
                return;
            }

            // Get selected row data
            DataGridViewRow row = table_CreateMeeting.SelectedRows[0];
            string doctor = row.Cells["Doctor"].Value.ToString();
            string patient = row.Cells["Patient"].Value.ToString();
            string meetingLink = row.Cells["MeetingLink"].Value?.ToString();
            DateTime appointmentDate = Convert.ToDateTime(row.Cells["AppointmentDate"].Value);
            string currentStatus = row.Cells["MeetingStatus"].Value?.ToString();

            // Check if meeting link is "On the Making"
            if (meetingLink == "On the Making")
            {
                MessageBox.Show("Cannot mark meeting as finished - the meeting link is still being generated.");
                return;
            }

            // Check if meeting is already finished
            if (currentStatus == "Finished")
            {
                MessageBox.Show("This meeting is already marked as finished.");
                return;
            }

            // Update the MeetingStatus in the database
            string updateQuery = "UPDATE Meetingtwo SET MeetingStatus = 'Finished' " +
                                "WHERE Doctor = @Doctor AND Patient = @Patient AND AppointmentDate = @AppointmentDate";

            using (OleDbConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, connection))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Doctor", doctor);
                        cmd.Parameters.AddWithValue("@Patient", patient);
                        cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Meeting status updated to 'Finished' successfully!");

                            // Fetch the doctor's email and app password
                            (string doctorEmail, string doctorAppPassword) = GetDoctorEmailAndPassword(doctor);

                            if (!string.IsNullOrEmpty(doctorEmail) && !string.IsNullOrEmpty(doctorAppPassword))
                            {
                                // Get patient email
                                string patientEmail = GetPatientEmail(patient, connection);

                                if (!string.IsNullOrEmpty(patientEmail))
                                {
                                    // Send completion email to patient
                                    SendCompletionEmail(doctorEmail, doctorAppPassword, patientEmail, patient, doctor, appointmentDate);
                                    MessageBox.Show("Completion notification email sent to patient.");
                                }
                                else
                                {
                                    MessageBox.Show("Could not find patient email address.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Could not retrieve doctor email credentials.");
                            }
                            btn_loadschedmeet_Click(null, null); // Refresh the table

                            // Fetch the doctor's email and app password (sender credentials)
                            
                        }
                        else
                        {
                            MessageBox.Show("No meeting was updated. Please check your selection.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating meeting status: " + ex.Message);
                }
            }

        }
        // Add this new method to send the completion email
        private void SendCompletionEmail(string senderEmail, string senderAppPassword,
                                   string patientEmail, string patientName,
                                   string doctorName, DateTime appointmentDate)
        {
            try
            {
                string subject = $"Your Online Consultation with Dr. {doctorName.Split(' ')[0]} - Completed";

                string body = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        body {{
            font-family: 'Segoe UI', Arial, sans-serif;
            line-height: 1.6;
            color: #333333;
            max-width: 600px;
            margin: 0 auto;
            padding: 0;
            background-color: #f7f7f7;
        }}
        .email-container {{
            background-color: #ffffff;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.05);
            overflow: hidden;
            margin: 20px auto;
        }}
        .header {{
            background-color: #4CAF50; /* Green color for completion */
            color: white;
            padding: 25px;
            text-align: center;
        }}
        .header h1 {{
            margin: 0;
            font-size: 22px;
            font-weight: 500;
        }}
        .content {{
            padding: 25px;
        }}
        .greeting {{
            font-size: 16px;
            margin-bottom: 20px;
        }}
        .summary-card {{
            background-color: #f8f9fa;
            border-left: 4px solid #4CAF50; /* Green accent */
            padding: 15px;
            margin: 20px 0;
            border-radius: 0 4px 4px 0;
        }}
        .summary-card h3 {{
            margin-top: 0;
            color: #4CAF50; /* Green text */
            font-size: 18px;
        }}
        .detail-row {{
            margin-bottom: 8px;
            display: flex;
        }}
        .detail-label {{
            font-weight: 600;
            width: 100px;
            color: #555;
        }}
        .important-note {{
            background-color: #E8F5E9; /* Light green background */
            border-left: 4px solid #4CAF50;
            padding: 15px;
            margin: 20px 0;
            border-radius: 0 4px 4px 0;
            font-size: 14px;
        }}
        .footer {{
            color: #777777;
            font-size: 12px;
            text-align: center;
            padding: 20px;
            border-top: 1px solid #eeeeee;
            margin-top: 20px;
        }}
        .signature {{
            margin-top: 25px;
        }}
    </style>
</head>
<body>
    <div class='email-container'>
        <div class='header'>
            <h1>Consultation Completed</h1>
        </div>
        
        <div class='content'>
            <div class='greeting'>
                <p>Dear {patientName},</p>
                <p>Thank you for attending your online consultation today. I hope you found our session helpful and informative.</p>
            </div>
            
            <div class='summary-card'>
                <h3>Consultation Summary</h3>
                <div class='detail-row'>
                    <span class='detail-label'>Date:</span>
                    <span>{appointmentDate.ToString("dddd, MMMM d, yyyy")}</span>
                </div>
                <div class='detail-row'>
                    <span class='detail-label'>Time:</span>
                    <span>{appointmentDate.ToString("h:mm tt")} (GMT+8)</span>
                </div>
                <div class='detail-row'>
                    <span class='detail-label'>Doctor:</span>
                    <span>Dr. {doctorName}</span>
                </div>
                <div class='detail-row'>
                    <span class='detail-label'>Status:</span>
                    <span style='color: #4CAF50; font-weight: bold;'>Completed</span>
                </div>
            </div>

            <div class='important-note'>
                <p><strong>Next Steps:</strong> Payment details will be emailed to you separately as soon as possible. 
                If you have any questions about the consultation or payment process, please don't hesitate to contact us.</p>
            </div>
            
            <p>If you have any follow-up questions related to our consultation today, please feel free to reach out. 
            I'm here to support your health journey every step of the way.</p>
            
            <div class='signature'>
                <p>Best regards,</p>
                <p><strong>Dr. {doctorName}</strong></p>
                <p>Healthcare Provider</p>
            </div>
        </div>
        
        <div class='footer'>
            <p>This is an automated message. Please do not reply directly to this email.</p>
            <p>© {DateTime.Now.Year} Healthcare Scheduler. All rights reserved.</p>
        </div>
    </div>
</body>
</html>";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail, $"Dr. {doctorName}");
                mail.To.Add(patientEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderAppPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending completion email: " + ex.Message);
            }
        }




        private void txt_searchPatient_TextChanged(object sender, EventArgs e)
        {
            SearchByPatientName();
        }
        private void SearchByPatientName()
        {
            if (originalData == null)
            {
                MessageBox.Show("Please load appointments first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string searchText = txt_searchPatient.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                // If search text is empty, show all records
                table_CreateMeeting.DataSource = originalData;
                return;
            }

            // Create a new DataTable with the same schema
            DataTable filteredData = originalData.Clone();

            // Filter rows based on doctor name
            foreach (DataRow row in originalData.Rows)
            {
                // Adjust "DoctorName" to the actual column name in your table
                if (row["Patient"].ToString().ToLower().Contains(searchText))
                {
                    filteredData.ImportRow(row);
                }
            }

            // Update the DataGridView with filtered results
            table_CreateMeeting.DataSource = filteredData;

            if (filteredData.Rows.Count == 0)
            {
                MessageBox.Show("No appointments found with this doctor.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
