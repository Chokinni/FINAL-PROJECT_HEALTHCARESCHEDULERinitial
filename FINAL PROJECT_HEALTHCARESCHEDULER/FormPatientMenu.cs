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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class FormPatientMenu : Form
    {
        string loggedInUsername;
        private string loggedInLastName;
        private UpcomingSchedule activeUpcomingSchedule;


        public FormPatientMenu(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInUsername = firstName;// Store username in a variable
            loggedInLastName = lastName;// Store username in a variable
            lblWelcome.Text = "Welcome, Patient " + loggedInUsername;
            lblWelcome.AutoSize = false;
            lblWelcome.MaximumSize = new Size(300, 0); // limit width, height can grow
            lblWelcome.AutoEllipsis = false;
            lblWelcome.UseCompatibleTextRendering = true; // Fix for rendering inconsistencies
            this.redDot = new System.Windows.Forms.PictureBox();
            this.redDot.Size = new System.Drawing.Size(10, 10); // Small red dot
            this.redDot.BackColor = System.Drawing.Color.Red; // Color red
            this.redDot.Location = new System.Drawing.Point(30, 10); // Adjust position over the bell
            this.redDot.Visible = false; // Initially hidden

            // Add to the form
            this.Controls.Add(this.redDot);


            // Add it to controls


            // Measure and resize label height properly
            Size textSize = TextRenderer.MeasureText(
                lblWelcome.Text,
                lblWelcome.Font,
                new Size(lblWelcome.MaximumSize.Width, 0),
                TextFormatFlags.WordBreak
            );

            lblWelcome.Size = new Size(lblWelcome.MaximumSize.Width, textSize.Height);

            lblWelcome.AutoEllipsis = false; // Optional
            lblWelcome.UseCompatibleTextRendering = false; // Optional but sometimes helps with text measuring where to put this
        }
        private void FormPatientMenu_Load(object sender, EventArgs e)
        {
            //var timer = new System.Windows.Forms.Timer();
            //timer.Interval = 30000;
            // timer.Tick += (s, e) => CheckForNotifications();
            //timer.Start();
            //lblNotificationCount.Visible = true;
            //lblNotificationCount.AutoSize = true;

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 30000; // 30 seconds
            timer.Tick += (s, e) =>
            {
                CheckForNotifications();
            };
            timer.Start();
        }
        private void CheckAppointmentStatus()
        {
            using (var con = BaseClass.GetConnection())
            {
                con.Open();
                string query = @"SELECT COUNT(*) FROM Doctorschedule 
                        WHERE Patient = @Name AND Status = 'Accepted'";
                using (var cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", $"{loggedInUsername} {loggedInLastName}");
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    //lblNotificationCount.Text = count.ToString();
                    //lblNotificationCount.Visible = count > 0;
                }
            }
        }
        private void CheckForNotifications()
        {
            using (OleDbConnection con = BaseClass.GetConnection())
            {
                con.Open();
                // Modified query to check for both accepted and cancelled appointments
                string query = @"SELECT Doctor, AppointmentDate, AppointmentTime, AppointmentID, Status, PatientNotification
                 FROM Doctorschedule 
                 WHERE Patient = @PatientName
                 AND PatientNotification = '1'";

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PatientName", $"{loggedInUsername} {loggedInLastName}");

                    bool hasNotification = false;
                    StringBuilder notificationMessages = new StringBuilder();
                    string notificationTitle = "";
                    int notificationCount = 0;

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hasNotification = true;
                            notificationCount++;

                            DateTime apptDate = Convert.ToDateTime(reader["AppointmentDate"]);
                            string status = reader["Status"].ToString();

                            if (status == "Accepted")
                            {
                                notificationTitle = "APPOINTMENT CONFIRMED";
                                notificationMessages.AppendLine($"Dr. {reader["Doctor"]} accepted your");
                                notificationMessages.AppendLine($"{apptDate:MMMM d} at {reader["AppointmentTime"]}");
                            }
                            else if (status == "Cancelled")
                            {
                                notificationTitle = "APPOINTMENT CANCELLED";
                                notificationMessages.AppendLine($"Dr. {reader["Doctor"]} cancelled your");
                                notificationMessages.AppendLine($"{apptDate:MMMM d} appointment");
                            }

                            // Mark as read after displaying
                            MarkAsNotified(reader["AppointmentID"].ToString());
                        }
                    }

                    if (hasNotification)
                    {
                        redDot.Visible = true;
                        PopupNotifier popup = new PopupNotifier();
                        popup.TitleText = notificationCount + " NEW NOTIFICATION" + (notificationCount > 1 ? "S" : "");
                        popup.ContentText = notificationMessages.ToString();
                        popup.Popup();
                    }
                    else
                    {
                        redDot.Visible = false;
                    }
                }
            }
        }

        private void MarkAsNotified(string appointmentId)
        {
            using (OleDbConnection con = BaseClass.GetConnection())
            {
                con.Open();
                string query = @"UPDATE Doctorschedule 
                        SET PatientNotification = '0'
                        WHERE AppointmentID = @AppointmentID";
                new OleDbCommand(query, con) { Parameters = { new OleDbParameter("@AppointmentID", appointmentId) } }
                   .ExecuteNonQuery();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_schedule_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            ScheduleApointment schedule = new ScheduleApointment(loggedInUsername, loggedInLastName);
            schedule.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(schedule);

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UpdateAppointment updschedule = new UpdateAppointment(loggedInUsername, loggedInLastName);
            updschedule.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(updschedule);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            CancelAppointment cancelschedule = new CancelAppointment(loggedInUsername, loggedInLastName);
            cancelschedule.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(cancelschedule);
        }

        private void btn_upschedpatient_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UpcomingSchedule upcschedule = new UpcomingSchedule(loggedInUsername, loggedInLastName);
            upcschedule.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(upcschedule);
        }

        private void btn_appointments_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            ViewAppointment viewschedule = new ViewAppointment(loggedInUsername, loggedInLastName);
            viewschedule.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(viewschedule);
        }

        private void btn_meeting_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            OnlineMeeting onlinemeet = new OnlineMeeting(loggedInUsername, loggedInLastName);
            onlinemeet.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(onlinemeet);
        }

        private void btn_logoutpatient_Click(object sender, EventArgs e)
        {
            if (panelContainer.Controls.OfType<UpcomingSchedule>().FirstOrDefault() is UpcomingSchedule upcomingSchedule)
            {
                upcomingSchedule.StopAlertSound();
                upcomingSchedule.Dispose();  // Force cleanup
            }



            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
        private void FormPatientMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop sound if window closes
            activeUpcomingSchedule?.StopAlertSound();
            activeUpcomingSchedule?.Dispose();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
        private void MarkNotificationAsRead(string appointmentID)
        {
            using (OleDbConnection con = BaseClass.GetConnection())
            {
                con.Open();
                string updateQuery = @"UPDATE Doctorschedule 
                               SET PatientNotification = '0' 
                               WHERE AppointmentID = @AppointmentID";

                using (OleDbCommand cmd = new OleDbCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private List<PopupNotifier> activePopups = new List<PopupNotifier>();
        private void picNotificationBell_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = BaseClass.GetConnection())
            {
                con.Open();
                string query = @"SELECT AppointmentID, Doctor, Patient, AppointmentDate, Status, 
                        UserID, AppointmentType, PatientNotification 
                        FROM Doctorschedule 
                        WHERE Patient = @PatientName
                        ORDER BY AppointmentDate DESC";

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PatientName", $"{loggedInUsername} {loggedInLastName}");

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        bool foundNewNotification = false;

                        // Loop through the notifications and show all unread ones
                        while (reader.Read())
                        {
                            if (reader["PatientNotification"].ToString() == "1")  // Check if notification is unread
                            {
                                DateTime apptDate = Convert.ToDateTime(reader["AppointmentDate"]);
                                string apptTime = apptDate.ToString("h:mm tt");
                                string status = reader["Status"].ToString();

                                // Create a new Popup for the unread notification
                                PopupNotifier popup = new PopupNotifier();

                                // Set the title and content of the notification based on the status
                                if (status == "Cancelled")
                                {
                                    popup.TitleText = "APPOINTMENT CANCELLED";
                                    popup.ContentText = $"Dr. {reader["Doctor"]} has cancelled your appointment\n" +
                                                        $"scheduled for {apptDate:MMMM d, yyyy} at {apptTime}";
                                }
                                else
                                {
                                    popup.TitleText = "APPOINTMENT CONFIRMED";
                                    popup.ContentText = $"Dr. {reader["Doctor"]} has confirmed your appointment\n" +
                                                        $"on {apptDate:MMMM d, yyyy} at {apptTime}";
                                }

                                // Show the popup
                                popup.Popup();

                                // Add the popup to the activePopups list
                                activePopups.Add(popup);

                                // Mark the notification as read in the database
                                MarkNotificationAsRead(reader["AppointmentID"].ToString());

                                // Update the flag to indicate that a new notification was found
                                foundNewNotification = true;
                            }
                        }

                        // If no new notifications were found, show a message saying "No new notifications"
                        if (!foundNewNotification)
                        {
                            PopupNotifier noNotifications = new PopupNotifier();
                            noNotifications.TitleText = "NO NEW NOTIFICATIONS";
                            noNotifications.ContentText = "You have no unread notifications";
                            noNotifications.Popup();
                        }
                    }
                }
            }
        }
       


        private void picture_clear_Click(object sender, EventArgs e)
        {
            /// Clear all active notifications
            foreach (var popup in activePopups)
            {
                popup.Delay = 5000;  // Close each popup
            }

            // Clear the list of active popups
            activePopups.Clear();
        }
        private bool HasUnreadNotifications()
        {
            using (OleDbConnection con = BaseClass.GetConnection())
            {
                con.Open();
                string query = @"SELECT COUNT(*) 
                 FROM Doctorschedule 
                 WHERE Patient = @PatientName
                 AND PatientNotification = '1'";

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PatientName", $"{loggedInUsername} {loggedInLastName}");
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void redDot_Click(object sender, EventArgs e)
        {

        }
    }
}
