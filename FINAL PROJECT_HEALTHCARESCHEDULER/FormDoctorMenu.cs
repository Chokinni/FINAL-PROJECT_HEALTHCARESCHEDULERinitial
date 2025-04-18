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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class FormDoctorMenu : Form
    {
        string loggedInUsername;
        private string loggedInLastName;
        public FormDoctorMenu(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInUsername = firstName;// Store username in a variable
            loggedInLastName = lastName;// Store username in a variable
                                        //lblWelcome.AutoSize = false;
                                        // lblWelcome.MaximumSize = new Size(300, 0); // Width limit, height auto-adjusts
                                        // lblWelcome.AutoEllipsis = false;

            //lblWelcome.Text = "Welcome, Dr. " + loggedInUsername; // Example usage

            loggedInUsername = firstName;// Store username in a variable
            loggedInLastName = lastName;// Store username in a variable
            lblWelcome.Text = "Welcome, Doctor " + loggedInUsername;
            lblWelcome.AutoSize = false;
            lblWelcome.MaximumSize = new Size(300, 0); // limit width, height can grow
            lblWelcome.AutoEllipsis = false;
            lblWelcome.UseCompatibleTextRendering = true; // Fix for rendering inconsistencies

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

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelContainerDoctor.Controls.Clear();
            ViewDoctorUpcomingSchedule viewdoctapp = new ViewDoctorUpcomingSchedule(loggedInUsername, loggedInLastName);
            viewdoctapp.Dock = DockStyle.Fill;
            panelContainerDoctor.Controls.Add(viewdoctapp);
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {
            panelContainerDoctor.Controls.Clear();
            AcceptPatient acceptpatient = new AcceptPatient(loggedInUsername, loggedInLastName);
            acceptpatient.Dock = DockStyle.Fill;
            panelContainerDoctor.Controls.Add(acceptpatient);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            panelContainerDoctor.Controls.Clear();
            CancelPatientAppointment cancelpatient = new CancelPatientAppointment(loggedInUsername, loggedInLastName);
            cancelpatient.Dock = DockStyle.Fill;
            panelContainerDoctor.Controls.Add(cancelpatient);
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            panelContainerDoctor.Controls.Clear();
            ViewDoctorAppointment viewdoctor = new ViewDoctorAppointment(loggedInUsername, loggedInLastName);
            viewdoctor.Dock = DockStyle.Fill;
            panelContainerDoctor.Controls.Add(viewdoctor);
        }

        private void btn_createmeeting_Click(object sender, EventArgs e)
        {
            panelContainerDoctor.Controls.Clear();
            DoctorMeeting docmeet = new DoctorMeeting(loggedInUsername, loggedInLastName);
            docmeet.Dock = DockStyle.Fill;
            panelContainerDoctor.Controls.Add(docmeet);
        }

        private void btn_logoutDoc_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void picNotificationdoc_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = BaseClass.GetConnection())
            {
                try
                {
                    con.Open();
                    string doctorFullName = loggedInUsername + " " + loggedInLastName;
                    string query = @"
    SELECT AppointmentID, Patient, AppointmentDate, Specialization, AppointmentType, Status, IsUpdated
    FROM Patientsschedule
    WHERE Doctor = @Doctor
    AND DoctorNotification = False";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Doctor", doctorFullName);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            bool hasNotifications = false;

                            while (reader.Read())
                            {
                                hasNotifications = true;

                                int appointmentId = Convert.ToInt32(reader["AppointmentID"]);
                                string patientName = reader["Patient"].ToString();
                                DateTime appointmentTime = Convert.ToDateTime(reader["AppointmentDate"]);
                                string specialization = reader["Specialization"].ToString();
                                string appointmentType = reader["AppointmentType"].ToString();
                                string status = reader["Status"].ToString();

                                // Explicitly handle DBNull and convert the 'IsUpdated' field properly
                                int isUpdatedValue = reader["IsUpdated"] != DBNull.Value ? Convert.ToInt32(reader["IsUpdated"]) : 0;
                                bool isUpdated = (isUpdatedValue == -1); // -1 means True in Access Yes/No fields

                                if (isUpdated)
                                {
                                    // 🔄 Updated appointment
                                    PopupNotifier popupUpdate = new PopupNotifier();
                                    popupUpdate.TitleText = "Appointment Updated";
                                    popupUpdate.ContentText = $"{patientName} has rescheduled.\nNew Time: {appointmentTime:MM/dd/yyyy hh:mm tt}";
                                    popupUpdate.Popup();
                                }
                                else if (status == "Pending")
                                {
                                    // 🆕 New appointment
                                    PopupNotifier popup = new PopupNotifier();
                                    popup.TitleText = "New Appointment Request";
                                    popup.ContentText = $"{patientName} ({specialization})\n{appointmentTime:MM/dd/yyyy hh:mm tt} ({appointmentType})";
                                    popup.Popup();
                                }
                                else if (status == "Cancelled")
                                {
                                    // ❌ Cancelled appointment
                                    PopupNotifier popupCancel = new PopupNotifier();
                                    popupCancel.TitleText = "Appointment Cancelled";
                                    popupCancel.ContentText = $"{patientName} has cancelled their appointment for {appointmentTime:MM/dd/yyyy hh:mm tt}.";
                                    popupCancel.Popup();
                                }

                                MarkNotificationAsRead(appointmentId); // Sets DoctorNotification = True and optionally IsUpdated = False
                            }

                            if (!hasNotifications)
                            {
                                PopupNotifier noNotifications = new PopupNotifier();
                                noNotifications.TitleText = "No New Notifications";
                                noNotifications.ContentText = "You have no new or updated appointments.";
                                noNotifications.Popup();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading notifications: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void MarkNotificationAsRead(int appointmentId)
        {
            using (OleDbConnection con = BaseClass.GetConnection())
            {
                try
                {
                    con.Open();
                    string query = "UPDATE Patientsschedule SET DoctorNotification = True, IsUpdated = False WHERE AppointmentID = @AppointmentId";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error marking notification as read: " + ex.Message);
                }
            }
        }
    }
}
