using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            UpdateAppointment updschedule = new UpdateAppointment(loggedInUsername,loggedInLastName);
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
            OnlineMeeting onlinemeet = new OnlineMeeting();
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
    }
}
