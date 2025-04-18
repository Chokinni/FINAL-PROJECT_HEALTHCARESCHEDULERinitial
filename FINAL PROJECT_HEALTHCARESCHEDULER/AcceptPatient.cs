using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using System.Net;
using System.Net.Mail;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class AcceptPatient : BaseClass
    {



        public AcceptPatient(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;

            CustomizeButton(btn_confirm);  // Custom styling for btn_confirm
            CustomizeButton(btn_loadscheddoc); // Custom styling for btn_loadscheddoc
                                               // Add other button customizations if necessary

        }

        private void CustomizeButton(Button btn)
        {
            btn.BackColor = Color.SkyBlue; // Background color
            btn.ForeColor = Color.White; // Text color
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Font style and size
            btn.Size = new Size(150, 40); // Set button size
            btn.FlatStyle = FlatStyle.Flat; // Removes default 3D look
            btn.FlatAppearance.BorderSize = 0; // Remove border
            btn.UseVisualStyleBackColor = false; // Ensures no default visual style

            // Add hover effect for better user interaction
            btn.MouseEnter += (sender, e) =>
            {
                btn.BackColor = Color.LightSkyBlue; // Lighter color on hover
            };

            btn.MouseLeave += (sender, e) =>
            {
                btn.BackColor = Color.SkyBlue; // Original color when mouse leaves
            };
        }
        private void MakeRoundedButton(Button btn, int radius)
        {
            var bounds = new Rectangle(0, 0, btn.Width, btn.Height);
            int diameter = radius * 2;
            var path = new System.Drawing.Drawing2D.GraphicsPath();

            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90); // Top left
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90); // Top right
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90); // Bottom right
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90); // Bottom left
            path.CloseFigure();

            btn.Region = new Region(path);
        }




        private void datetime_Doctor_ValueChanged(object sender, EventArgs e)
        {
            //string selectedDateTime = datetime_Doctor.Value.ToString("MM/dd/yyyy hh:mm tt");

            //datetime_Doctor.Format = DateTimePickerFormat.Custom;
            // datetime_Doctor.CustomFormat = "MM/dd/yyyy hh:mm tt"; // Date + Time (12-hour format)
            // datetime_Doctor.ShowUpDown = true; // Removes dropdown calendar
        }

        private void btn_loadscheddoc_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    // Step 1: Retrieve pending appointments for the logged-in doctor
                    string pendingQuery = @"
            SELECT * 
            FROM Doctorschedule 
            WHERE Status = @Status 
              AND Doctor = @Doctor";
                    using (OleDbCommand pendingCmd = new OleDbCommand(pendingQuery, con))
                    {
                        pendingCmd.Parameters.AddWithValue("@Status", "Pending");
                        pendingCmd.Parameters.AddWithValue("@Doctor", loggedInFirstName + " " + loggedInLastName);

                        // Step 2: Execute the query and load the data into a DataTable
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(pendingCmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Step 3: Bind the DataTable to your DataGridView
                            table_AcceptAppointment.DataSource = dt;

                            // Hide "Doctor" column if it exists
                            if (table_AcceptAppointment.Columns.Contains("Doctor") &&
                            table_AcceptAppointment.Columns.Contains("PatientNotification"))
                            {
                                table_AcceptAppointment.Columns["Doctor"].Visible = false;
                                table_AcceptAppointment.Columns["PatientNotification"].Visible = false;
                            }

                            // ✅ DESIGN: Apply healthcare-style DataGridView formatting
                            var dgv = table_AcceptAppointment;

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

                            // Optional: Display a message
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Pending appointments loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No pending appointments found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading pending appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void ConfirmMeeting(int appointmentID)
        {
            using (OleDbConnection con = BaseClass.GetConnection())
            {
                try
                {
                    con.Open();

                    string userQuery = "SELECT ID FROM USERS WHERE [FirstName] = @FirstName AND [LastName] = @LastName";
                    using (OleDbCommand userCmd = new OleDbCommand(userQuery, con))
                    {
                        userCmd.Parameters.AddWithValue("@FirstName", loggedInFirstName);
                        userCmd.Parameters.AddWithValue("@LastName", loggedInLastName);

                        object result = userCmd.ExecuteScalar();
                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int userID = Convert.ToInt32(result);
                        string meetStatus = "Pending";
                        string meetLink = "On the Making";
                        string doctorName = loggedInFirstName + " " + loggedInLastName;

                        string insertQuery = @"INSERT INTO Meeting ([MeetingStatus], [UserID], [MeetingLink], [DoctorName], [AppointmentID])
                                       VALUES (@MeetingStatus, @UserID, @MeetingLink, @DoctorName, @AppointmentID)";

                        using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, con))
                        {
                            insertCmd.Parameters.AddWithValue("@MeetingStatus", meetStatus);
                            insertCmd.Parameters.AddWithValue("@UserID", userID);
                            insertCmd.Parameters.AddWithValue("@MeetingLink", meetLink);
                            insertCmd.Parameters.AddWithValue("@DoctorName", doctorName);
                            insertCmd.Parameters.AddWithValue("@AppointmentID", appointmentID);

                            int rowsAffected = insertCmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Meeting successfully confirmed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Meeting confirmation failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (table_AcceptAppointment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to confirm.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = table_AcceptAppointment.SelectedRows[0];
            int appointmentID = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
            string currentStatus = selectedRow.Cells["Status"].Value.ToString();
            string patientFullName = selectedRow.Cells["Patient"].Value.ToString();
            DateTime appointmentDate = Convert.ToDateTime(selectedRow.Cells["AppointmentDate"].Value);

            if (currentStatus != "Pending")
            {
                MessageBox.Show("Only appointments with 'Pending' status can be confirmed.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] nameParts = patientFullName.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length < 2)
            {
                MessageBox.Show("Patient name format is invalid.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string patientFirstName = nameParts[0];
            string patientLastName = nameParts[1];

            using (OleDbConnection con = BaseClass.GetConnection())
            {
                try
                {
                    con.Open();

                    // Get patient's email
                    string patientEmail = "";
                    string getPatientEmailQuery = @"
                        SELECT EmailAddress 
                        FROM USERS 
                        WHERE FirstName = @PatientFirstName AND LastName = @PatientLastName";

                    using (OleDbCommand patientEmailCmd = new OleDbCommand(getPatientEmailQuery, con))
                    {
                        patientEmailCmd.Parameters.AddWithValue("@PatientFirstName", patientFirstName);
                        patientEmailCmd.Parameters.AddWithValue("@PatientLastName", patientLastName);

                        object patientEmailResult = patientEmailCmd.ExecuteScalar();
                        if (patientEmailResult != null)
                        {
                            patientEmail = patientEmailResult.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Could not find patient's email address.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Get doctor's email credentials
                    string doctorEmail = "";
                    string doctorAppPassword = "";

                    string appointmentType = selectedRow.Cells["AppointmentType"].Value.ToString();
                    string getDoctorCredsQuery = @"
                        SELECT EmailAddress, AppPassword 
                        FROM USERS 
                        WHERE FirstName = @DoctorFirstName AND LastName = @DoctorLastName";

                    using (OleDbCommand doctorCredsCmd = new OleDbCommand(getDoctorCredsQuery, con))
                    {
                        doctorCredsCmd.Parameters.AddWithValue("@DoctorFirstName", loggedInFirstName);
                        doctorCredsCmd.Parameters.AddWithValue("@DoctorLastName", loggedInLastName);

                        using (OleDbDataReader doctorReader = doctorCredsCmd.ExecuteReader())
                        {
                            if (doctorReader.Read())
                            {
                                doctorEmail = doctorReader["EmailAddress"].ToString();
                                doctorAppPassword = doctorReader["AppPassword"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Could not find doctor's email credentials.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // Update appointment status
                    string updateQuery = @"
                        UPDATE Doctorschedule 
                        SET Status = @Status 
                        WHERE AppointmentID = @AppointmentID";

                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Status", "Accepted");
                        cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Mark that patient needs notification
                            string updateNotifQuery = @"UPDATE Doctorschedule 
                                  SET PatientNotification = '1' 
                                  WHERE AppointmentID = @AppointmentID";

                            using (OleDbCommand notifCmd = new OleDbCommand(updateNotifQuery, con))
                            {
                                notifCmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
                                notifCmd.ExecuteNonQuery();
                            }
                            // Send email notification
                            try
                            {
                                SendAppointmentConfirmationEmail(
                                    patientEmail,
                                    patientFullName,
                                    $"{loggedInFirstName} {loggedInLastName}",
                                    appointmentDate,
                                   
                                    doctorEmail,
                                    doctorAppPassword, appointmentType);

                                 // Refresh the DataGridView
                                MessageBox.Show("Appointment confirmed and notification email sent!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                NotifyPatient(patientFullName);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Appointment confirmed but failed to send email: {ex.Message}", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            ConfirmMeeting(appointmentID);
                            btn_loadscheddoc_Click(sender, e);

                        }
                        else
                        {
                            MessageBox.Show("Failed to confirm appointment. Please try again.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error confirming appointment: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void SendAppointmentConfirmationEmail(
                string patientEmail,
                string patientName,
                string doctorName,
                DateTime appointmentDate,
                string senderEmail,
                string senderPassword,
                string appointmentType)
        {
            string clinicName = "Cebu South General Hospital";
            string clinicAddress = "National Road, Tuyan, Naga City, 6037 Cebu, Philippines";

            string doctorPhone = "";
            string doctorEmailContact = "";

            using (OleDbConnection con = BaseClass.GetConnection())
            {
                try
                {
                    con.Open();
                    string contactQuery = @"
                SELECT PhoneNumber, EmailAddress 
                FROM USERS 
                WHERE [Role] = 'DOCTOR' 
                AND FirstName = @FirstName 
                AND LastName = @LastName";

                    string[] doctorNames = doctorName.Split(' ');
                    string docFirstName = doctorNames.Length > 0 ? doctorNames[0] : "";
                    string docLastName = doctorNames.Length > 1 ? string.Join(" ", doctorNames.Skip(1)) : "";

                    using (OleDbCommand contactCmd = new OleDbCommand(contactQuery, con))
                    {
                        contactCmd.Parameters.AddWithValue("@FirstName", docFirstName);
                        contactCmd.Parameters.AddWithValue("@LastName", docLastName);

                        using (OleDbDataReader reader = contactCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                doctorPhone = reader["PhoneNumber"].ToString();
                                doctorEmailContact = reader["EmailAddress"].ToString();
                            }
                        }
                    }
                }
                catch
                {
                    doctorPhone = "+63 32 123 4567";
                    doctorEmailContact = "info@cebusouthgeneral.com";
                }
            }

            string subject = appointmentType.ToUpper() == "ONLINE"
                ? $"Online Appointment with Dr. {doctorName.Split(' ')[0]} Confirmed"
                : $"Your Appointment with Dr. {doctorName.Split(' ')[0]} Has Been Confirmed";

            string dateFormatted = appointmentDate.ToString("dddd, MMMM d, yyyy");
            string timeFormatted = appointmentDate.ToString("h:mm tt");

            string appointmentDetailsHtml = appointmentType.ToUpper() == "ONLINE"
                ? $@"
            <p><strong>Date:</strong> {dateFormatted}</p>
            <p><strong>Time:</strong> {timeFormatted}</p>
            <p><strong>Mode:</strong> Online Consultation</p>"
                : $@"
            <p><strong>Date:</strong> {dateFormatted}</p>
            <p><strong>Time:</strong> {timeFormatted}</p>
            <p><strong>Location:</strong> {clinicName}</p>
            <p><strong>Address:</strong> {clinicAddress}</p>";

            string messageBody = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{
            font-family: 'Segoe UI', Arial, sans-serif;
            line-height: 1.6;
            color: #333;
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
        }}
        .header {{
            background-color: #1a73e8;
            color: white;
            padding: 20px;
            text-align: center;
            border-radius: 5px 5px 0 0;
        }}
        .content {{
            padding: 25px;
            background-color: #f9f9f9;
            border: 1px solid #e0e0e0;
            border-top: none;
        }}
        .footer {{
            padding: 15px;
            text-align: center;
            font-size: 12px;
            color: #777;
            background-color: #f1f1f1;
            border: 1px solid #e0e0e0;
            border-top: none;
            border-radius: 0 0 5px 5px;
        }}
        .appointment-details {{
            background-color: white;
            border: 1px solid #e0e0e0;
            border-radius: 5px;
            padding: 15px;
            margin: 20px 0;
        }}
        .logo {{
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 10px;
        }}
    </style>
</head>
<body>
    <div class='header'>
        <div class='logo'>{clinicName}</div>
        <h2>{(appointmentType.ToUpper() == "ONLINE" ? "Online Appointment Confirmed" : "Appointment Confirmed")}</h2>
    </div>

    <div class='content'>
        <p>Dear {patientName},</p>
        <p>{(appointmentType.ToUpper() == "ONLINE"
                    ? $"Your online appointment with <strong>Dr. {doctorName}</strong> has been successfully confirmed."
                    : $"We're pleased to confirm your appointment with <strong>Dr. {doctorName}</strong>.")}</p>

        <div class='appointment-details'>
            <h3 style='margin-top: 0; color: #1a73e8;'>Appointment Details</h3>
            {appointmentDetailsHtml}
        </div>

        {(appointmentType.ToUpper() == "ONLINE"
                    ? $"<p>The video call link will be provided to you by <strong>Dr. {doctorName}</strong> before your appointment.</p>"
                    : "<p>Please arrive <strong>15 minutes early</strong> to complete necessary paperwork.</p>")}

        <p>If you need assistance or wish to reschedule, feel free to contact:</p>
        <p><strong>Doctor's Phone:</strong> {doctorPhone}</p>
        <p><strong>Doctor's Email:</strong> {doctorEmailContact}</p>

        <p>We look forward to {(appointmentType.ToUpper() == "ONLINE" ? "assisting you virtually" : "seeing you soon")}.</p>
    </div>

    <div class='footer'>
        <p>© {DateTime.Now.Year} {clinicName}. All rights reserved.</p>
        <p>{clinicAddress}</p>
    </div>
</body>
</html>";

            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    smtpClient.Timeout = 10000;

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(senderEmail, $"Dr. {doctorName}");
                        mailMessage.To.Add(patientEmail);
                        mailMessage.Subject = subject;
                        mailMessage.Body = messageBody;
                        mailMessage.IsBodyHtml = true;
                        mailMessage.Priority = MailPriority.High;

                        smtpClient.Send(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error or notify admin here
                MessageBox.Show("Failed to send confirmation email.\n\n" + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Patient_profilestrip_Opening(object sender, CancelEventArgs e)
        {
            if (table_AcceptAppointment.SelectedRows.Count > 0)
            {
                string fullName = table_AcceptAppointment.SelectedRows[0].Cells["Patient"].Value.ToString();

                // Split full name into parts
                string[] nameParts = fullName.Trim().Split(' ');

                // Assign first and last name
                string firstName = nameParts.Length > 0 ? nameParts[0] : "";
                string lastName = nameParts.Length > 1 ? string.Join(" ", nameParts.Skip(1)) : "";

                // Open the patient profile form with first and last name
                PatientProfile profileForm = new PatientProfile(firstName, lastName);
                profileForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }
        private PopupNotifier currentPopup = null;
        private void NotifyPatient(string patientName)
        {
            // Dispose the current popup if it exists
            if (currentPopup != null)
            {
                currentPopup.Dispose();
            }

            // Create new popup
            currentPopup = new PopupNotifier();
            currentPopup.TitleText = "APPOINTMENT ACCEPTED";
            currentPopup.ContentText = $"Dr. {loggedInFirstName} confirmed patient's appointment!";
            currentPopup.Popup();
        }
    }
}
