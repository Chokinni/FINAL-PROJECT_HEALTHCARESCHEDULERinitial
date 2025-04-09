using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            lblWelcome.Text = "Welcome, Dr. " + loggedInUsername; // Example usage
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
    }
}
