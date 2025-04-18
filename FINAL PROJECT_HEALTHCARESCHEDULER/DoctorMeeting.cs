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
                // Load Google credentials - UPDATED PATH HERE
                using (var stream = new FileStream(@"C:\Ccode\credentials.json", FileMode.Open, FileAccess.Read))
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
                            btn_loadschedmeet_Click(null, null); // Refresh the table
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
    }
}
