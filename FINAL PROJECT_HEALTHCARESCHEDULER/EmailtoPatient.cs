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
    public partial class EmailtoPatient : Form
    {
        string loggedInUsername;
        private string loggedInLastName;
        
        private string patientEmail;
        private string attachmentPath;
        private string smtpServer = "smtp.gmail.com";
        private int smtpPort = 587;

        // Add this to store the current doctor's info
        private string doctorEmail;
        private string doctorPassword;
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Lenovo - i5 13th Gen\Documents\Healthcarescheduler.accdb;";


        public EmailtoPatient(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInUsername = firstName; // Store username in a variable
            loggedInLastName = lastName;
            this.doctorEmail = doctorEmail; // New, but this seems redundant
            LoadPatientEmail(); // Pass the parameters correctly
            LoadDoctorEmail();
            SetupForm();
        }
        private void LoadPatientEmail()
        {
            try
            {
                using (OleDbConnection conn = BaseClass.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT EmailAddress FROM USERS WHERE [FirstName]=@FirstName AND [LastName]=@LastName AND [Role]='PATIENT'";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", loggedInUsername);  // Use loggedInUsername
                        cmd.Parameters.AddWithValue("@LastName", loggedInLastName);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            patientEmail = result.ToString();
                            tbx_To.Text = patientEmail;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patient email: {ex.Message}");
            }
        }
        private void LoadDoctorEmail()
        {
            try
            {
                using (OleDbConnection conn = BaseClass.GetConnection())
                {
                    conn.Open();

                    // Get the first doctor account from the database
                    string query = "SELECT TOP 1 EmailAddress, AppPassword FROM USERS WHERE Role='DOCTOR'";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                doctorEmail = reader["EmailAddress"].ToString();
                                doctorPassword = reader["AppPassword"].ToString();

                                // Output both the doctorEmail and doctorPassword to the console (or a message box)
                                Console.WriteLine($"Doctor Email: {doctorEmail}");
                                Console.WriteLine($"Doctor Password: {doctorPassword}");

                                if (string.IsNullOrEmpty(doctorEmail) || string.IsNullOrEmpty(doctorPassword))
                                {
                                    MessageBox.Show("WELCOME!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("No doctor account found. Please check your database.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctor email: {ex.Message}");
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

        private string selectedImagePath = ""; // Declare at form level

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
            string toEmail = tbx_To.Text.Trim();
            string subject = tbx_subject.Text.Trim();
            string plainMessage = richbox_message.Text;
            string attachmentPath = picture_attach.ImageLocation; // From image box

            // Get sender's email and password from database
            string senderEmail = "", appPassword = "";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT EmailAddress, AppPassword FROM USERS WHERE FirstName = ? AND LastName = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", loggedInUsername);
                    cmd.Parameters.AddWithValue("?", loggedInLastName);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            senderEmail = reader["EmailAddress"].ToString();
                            appPassword = reader["AppPassword"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Sender (doctor) not found in database.");
                            return;
                        }
                    }
                }
            }

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail, $"Dr. {loggedInUsername} {loggedInLastName}"); // ✅ With "Dr." in sender display
                mail.To.Add(toEmail);
                mail.Subject = subject;

                // 🧠 Enhanced HTML Message Body
                mail.Body = $@"
        <html>
        <body style='font-family: Arial;'>
            <h2 style='color: #2E86C1;'>Doctor's Message</h2>
            <p><strong>Dear Patient,</strong></p>
            <p>{plainMessage}</p>
            <br/>
            <p>Best regards,</p>
            <p style='color: #117A65; font-weight: bold;'>Dr. {loggedInUsername} {loggedInLastName}</p>
            <hr />
            <p style='font-size: small; color: gray;'>This message was sent via Healthcare Scheduler System.</p>
        </body>
        </html>";
                mail.IsBodyHtml = true;

                // 📎 Attach image if available
                try
                {
                    if (!string.IsNullOrEmpty(selectedImagePath))
                    {
                        mail.Attachments.Add(new Attachment(selectedImagePath));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Attachment failed: " + ex.Message);
                }

                // Extra attachment from image box (optional)
                if (!string.IsNullOrEmpty(attachmentPath))
                {
                    mail.Attachments.Add(new Attachment(attachmentPath));
                }

                // ✉️ Send the email via Gmail SMTP
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(senderEmail, appPassword);
                smtp.EnableSsl = true;

                smtp.Send(mail);
                MessageBox.Show("Email sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message);
            }

        }

        private void lb_Attachment_Click(object sender, EventArgs e)
        {

        }

        private void lbl_exitdoctor_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
