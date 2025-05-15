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
using System.Data.OleDb;
using System.Security.Cryptography;
namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class ForgetPass : Form
    {
        private string verificationCode;
        private string userEmail;
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Lenovo - i5 13th Gen\Documents\Healthcarescheduler.accdb;"; 
        public ForgetPass()
        {
            InitializeComponent();
            panelVerification.Visible = true;
        }

        private void btn_sendcode_Click(object sender, EventArgs e)
        {

        }
        private bool EmailExistsInDatabase(string email)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM USERS WHERE EmailAddress=@Email";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count == 1;
            }
        }
        private bool SendVerificationEmail(string recipientEmail, string code)
        {
            try
            {
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("migel24asid@gmail.com", "lcvl rhgt pqki kxbk");
                    smtp.Timeout = 10000; // 10 seconds timeout

                    using (var message = new MailMessage())
                    {
                        message.From = new MailAddress("migel24asid@gmail.com", "Healthcare Scheduler");
                        message.To.Add(recipientEmail);
                        message.Subject = "Your Password Reset Code";
                        message.IsBodyHtml = true;
                        message.Body = GetEmailHtmlBody(code);

                        // Add important headers to prevent spam marking
                        message.Headers.Add("Precedence", "bulk");
                        message.Headers.Add("X-Mailer", "HealthcareScheduler");
                        message.Headers.Add("X-MSMail-Priority", "Normal");
                        message.Headers.Add("X-Priority", "3");
                        message.Headers.Add("X-Auto-Response-Suppress", "All");

                        // Set important properties
                        message.DeliveryNotificationOptions = DeliveryNotificationOptions.None;
                        message.Priority = MailPriority.Normal;

                        smtp.Send(message);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
                return false;
            }
        }

        private string GetEmailHtmlBody(string code)
        {
            return $@"
<html>
<head>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Password Reset Code</title>
</head>
<body style='font-family: Arial, sans-serif; line-height: 1.6; margin: 0; padding: 0;'>
    <div style='max-width: 600px; margin: 20px auto; padding: 20px; border: 1px solid #e0e0e0; border-radius: 5px;'>
        <div style='text-align: center; margin-bottom: 20px;'>
            <h2 style='color: #2c3e50;'>Password Assistance</h2>
        </div>
        <p>Hello,</p>
        <p>We received a request to reset your password. Here's your verification code:</p>
        
        <div style='background: #f8f9fa; padding: 15px; margin: 20px 0; 
                    font-size: 24px; text-align: center; border-radius: 5px;'>
            <strong>{code}</strong>
        </div>
        
        <p>This code will expire in 10 minutes. If you didn't request this code, please ignore this email.</p>
        
        <p style='font-size: 12px; color: #7f8c8d; margin-top: 30px;'>
            For security reasons, please do not share this code with anyone. 
            Our support team will never ask you for this information.
        </p>
        
        <div style='margin-top: 30px; padding-top: 20px; border-top: 1px solid #e0e0e0; font-size: 12px; color: #7f8c8d;'>
            <p>Healthcare Scheduler Team</p>
            <p>This is an automated message - please do not reply directly to this email.</p>
        </div>
    </div>
</body>
</html>";
        }
        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }


        private void btn_change_Click(object sender, EventArgs e)
        {
         
        }

        private bool UpdatePassword(string email, string newPassword)
        {
            // Hash the password before storing it
            string hashedPassword = HashPassword(newPassword);

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "UPDATE USERS SET [Password]=@Password WHERE EmailAddress=@Email";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@Password", hashedPassword); // Now storing hashed password
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected == 1;
            }
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private void btn_sendcode_Click_1(object sender, EventArgs e)
        {
            userEmail = tbx_email.Text.Trim();

            if (string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("Please enter your email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if email exists in database
            if (!EmailExistsInDatabase(userEmail))
            {
                MessageBox.Show("Email address not found in our system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generate and send verification code
            verificationCode = GenerateVerificationCode();
            if (SendVerificationEmail(userEmail, verificationCode))
            {
                MessageBox.Show("Verification code sent to your email.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Show verification panel
                panelVerification.Visible = true;
            }
            else
            {
                MessageBox.Show("Failed to send verification code. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_change_Click_1(object sender, EventArgs e)
        {
            string enteredCode = tbx_forget.Text.Trim();
            string newPassword = txt_NewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Validate inputs
            if (string.IsNullOrEmpty(enteredCode))
            {
                MessageBox.Show("Please enter the verification code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please enter and confirm your new password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verify the code
            if (enteredCode != verificationCode)
            {
                MessageBox.Show("Invalid verification code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update password in database
            if (UpdatePassword(userEmail, newPassword))
            {
                MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
