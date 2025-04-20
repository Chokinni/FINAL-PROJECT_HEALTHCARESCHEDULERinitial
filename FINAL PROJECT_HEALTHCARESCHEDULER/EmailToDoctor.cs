using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Data.OleDb;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class EmailToDoctor : Form
    {
        string loggedInUsername;
        private string loggedInLastName;
        private string doctorEmail;
        private string patientEmail;
        private string doctorPassword;
        private string attachmentPath;
        private string smtpServer = "smtp.gmail.com";
        private int smtpPort = 587;
        private string selectedImagePath = "";
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Lenovo - i5 13th Gen\Documents\Healthcarescheduler.accdb;";
        public EmailToDoctor(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInUsername = firstName;
            loggedInLastName = lastName;
            LoadDoctorEmail(); // Set recipient
            LoadPatientEmail(); // Set sender credentials
            SetupForm();
        }

        private void LoadDoctorEmail()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT TOP 1 EmailAddress FROM USERS WHERE Role='DOCTOR'";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            doctorEmail = result.ToString();
                            tbx_To.Text = doctorEmail; // Set doctor as recipient
                        }
                        else
                        {
                            MessageBox.Show("WELCOME!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctor email: {ex.Message}");
            }
        }

        private void LoadPatientEmail()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT EmailAddress, AppPassword FROM USERS WHERE FirstName = ? AND LastName = ? AND Role='PATIENT'";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", loggedInUsername);
                        cmd.Parameters.AddWithValue("?", loggedInLastName);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                patientEmail = reader["EmailAddress"].ToString();
                                doctorPassword = reader["AppPassword"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Patient not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient email: " + ex.Message);
            }
        }
        private void SetupForm()
        {
            picture_attach.Cursor = Cursors.Hand;
            picture_attach.Click += picture_attach_Click;
            picture_attach.BorderStyle = BorderStyle.FixedSingle;
            picture_attach.SizeMode = PictureBoxSizeMode.CenterImage;
            lb_Attachment.Text = "Click to add attachment";
        }

        

        private void picture_attach_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName; // Save actual file path
                picture_attach.Image = Image.FromFile(selectedImagePath);
                lb_Attachment.Text = "Attached: " + Path.GetFileName(selectedImagePath);
            }

        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
           

        }

        private void lb_Attachment_Click(object sender, EventArgs e)
        {

        }

        private void lbl_exitdoctor_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_exitdoctor_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_submit_Click_1(object sender, EventArgs e)
        {
            string toEmail = tbx_To.Text.Trim();   // Doctor
            string subject = tbx_subject.Text.Trim();
            string plainMessage = richbox_message.Text;

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(patientEmail, $"{loggedInUsername} {loggedInLastName}"); // Patient as sender
                mail.To.Add(toEmail); // Doctor as recipient
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = $@"
                <html>
                <body style='font-family: Arial;'>
                    <h2 style='color: #2E86C1;'>Message from Patient</h2>
                    <p><strong>Dear Doctor,</strong></p>
                    <p>{plainMessage}</p>
                    <br/>
                    <p>Best regards,</p>
                    <p style='color: #117A65; font-weight: bold;'>{loggedInUsername} {loggedInLastName}</p>
                    <hr />
                    <p style='font-size: small; color: gray;'>This message was sent via Healthcare Scheduler System.</p>
                </body>
                </html>";

                if (!string.IsNullOrEmpty(selectedImagePath))
                {
                    mail.Attachments.Add(new Attachment(selectedImagePath));
                }

                SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
                smtp.Credentials = new NetworkCredential(patientEmail, doctorPassword); // Patient credentials
                smtp.EnableSsl = true;

                smtp.Send(mail);
                MessageBox.Show("Email sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message);
            }

        }
    }
}
