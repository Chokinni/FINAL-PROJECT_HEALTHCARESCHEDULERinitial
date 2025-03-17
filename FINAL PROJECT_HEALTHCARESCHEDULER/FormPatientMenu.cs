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
        public FormPatientMenu(string firstName)
        {
            InitializeComponent();
            loggedInUsername = firstName; // Store username in a variable

            lblWelcome.Text = "Welcome, Patient " + loggedInUsername; // Example usage
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_schedule_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            ScheduleApointment schedule = new ScheduleApointment();
            schedule.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(schedule);

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UpdateAppointment updschedule = new UpdateAppointment();
            updschedule.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(updschedule);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            CancelAppointment cancelschedule = new CancelAppointment();
            cancelschedule.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(cancelschedule);
        }

        private void btn_upschedpatient_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UpcomingSchedule upcschedule = new UpcomingSchedule();
            upcschedule.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(upcschedule);
        }

        private void btn_appointments_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            ViewAppointment viewschedule = new ViewAppointment();
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
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
