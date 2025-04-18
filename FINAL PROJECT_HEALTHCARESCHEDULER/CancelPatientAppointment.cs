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
using System.Net;
using System.Net.Mail;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class CancelPatientAppointment : BaseClass
    {

        private int selectedUserID; // Store the selected appointment's UserID
        private DateTime selectedAppointmentDate;

        public CancelPatientAppointment(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;
        }

        private void datetime_cancelPatientAppointment_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_loadschedforcancel_Click(object sender, EventArgs e)
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
                        WHERE (Status = @StatusPending OR Status = @StatusCancelled)
                          AND Doctor = @Doctor";
                    using (OleDbCommand pendingCmd = new OleDbCommand(pendingQuery, con))
                    {
                        pendingCmd.Parameters.AddWithValue("@Status", "Pending");
                        pendingCmd.Parameters.AddWithValue("@StatusCancelled", "Cancelled");
                        pendingCmd.Parameters.AddWithValue("@Doctor", loggedInFirstName + " " + loggedInLastName); // Logged-in doctor's name

                        // Step 2: Execute the query and load the data into a DataTable
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(pendingCmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Step 3: Bind the DataTable to your table control (e.g., DataGridView)
                            table_CancelpatientAppointment.DataSource = dt;
                            table_CancelpatientAppointment.Columns["PatientNotification"].Visible = false;

                            var dgv = table_CancelpatientAppointment;

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
                            // Optional: Display a success message
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Appointments loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No appointments found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_cancelpatientAppointment_Click(object sender, EventArgs e)
        {

            if (table_CancelpatientAppointment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to cancel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 2: Get the selected row
            DataGridViewRow selectedRow = table_CancelpatientAppointment.SelectedRows[0];

            // Step 3: Retrieve the AppointmentID and current Status from the selected row
            int appointmentID = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
            string currentStatus = selectedRow.Cells["Status"].Value.ToString();
            selectedUserID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
            selectedAppointmentDate = Convert.ToDateTime(selectedRow.Cells["AppointmentDate"].Value);
            string patientFullName = selectedRow.Cells["Patient"].Value?.ToString();
            string appointmentType = selectedRow.Cells["AppointmentType"].Value?.ToString();

            // Step 4: Check if the current status is "Pending"
            if (currentStatus != "Pending")
            {
                MessageBox.Show("Only appointments with 'Pending' status can be cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Split patient name
            string[] nameParts = patientFullName.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length < 2)
            {
                MessageBox.Show("Patient name format is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        cmd.Parameters.AddWithValue("@Status", "Cancelled");
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
                                SendAppointmentCancellationEmail(
                                    patientEmail,
                                    patientFullName,
                                    $"{loggedInFirstName} {loggedInLastName}",
                                    selectedAppointmentDate,
                                    appointmentType,
                                    doctorEmail,
                                    doctorAppPassword);

                                MessageBox.Show("Appointment cancelled and notification email sent!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                NotifyPatient(patientFullName);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Appointment cancelled but failed to send email: {ex.Message}", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            btn_loadschedforcancel_Click(sender, e); // Refresh the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Failed to cancel appointment. Please try again.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error cancelling appointment: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void SendAppointmentCancellationEmail(
string patientEmail,
string patientName,
string doctorName,
DateTime appointmentDate,
string appointmentType,
string senderEmail,
string senderPassword)
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

            string subject = $"Appointment with Dr. {doctorName.Split(' ')[0]} Cancelled";
            string dateFormatted = appointmentDate.ToString("dddd, MMMM d, yyyy");
            string timeFormatted = appointmentDate.ToString("h:mm tt");

            string appointmentDetailsHtml = $@"
        <p><strong>Date:</strong> {dateFormatted}</p>
        <p><strong>Time:</strong> {timeFormatted}</p>
        <p><strong>Type:</strong> {appointmentType}</p>";

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
            background-color: #e74c3c;
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
        <h2>Appointment Cancellation Notice</h2>
    </div>

    <div class='content'>
        <p>Dear {patientName},</p>
        <p>We regret to inform you that your appointment with <strong>Dr. {doctorName}</strong> has been cancelled.</p>

        <div class='appointment-details'>
            <h3 style='margin-top: 0; color: #e74c3c;'>Cancelled Appointment Details</h3>
            {appointmentDetailsHtml}
        </div>

        <p>We apologize for any inconvenience this may cause. Please contact our office to reschedule:</p>
        <p><strong>Doctor's Phone:</strong> {doctorPhone}</p>
        <p><strong>Doctor's Email:</strong> {doctorEmailContact}</p>

        <p>Thank you for your understanding.</p>
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
                MessageBox.Show("Failed to send cancellation email.\n\n" + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_delete_Click(object sender, EventArgs e)
        {
            // Step 1: Check if a row is selected in the DataGridView
            if (table_CancelpatientAppointment.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            // Step 2: Retrieve AppointmentID, UserID, and Status from the selected row
            int appointmentID;
            int userID;
            string status;

            // Ensure AppointmentID, UserID, and Status are valid
            if (!int.TryParse(table_CancelpatientAppointment.CurrentRow.Cells["AppointmentID"].Value.ToString(), out appointmentID))
            {
                MessageBox.Show("Invalid AppointmentID. Cannot delete.");
                return;
            }

            if (!int.TryParse(table_CancelpatientAppointment.CurrentRow.Cells["UserID"].Value.ToString(), out userID))
            {
                MessageBox.Show("Invalid UserID. Cannot delete.");
                return;
            }

            status = table_CancelpatientAppointment.CurrentRow.Cells["Status"].Value.ToString();

            // Step 3: Check if the status is "Cancelled"
            if (status != "Cancelled")
            {
                MessageBox.Show("Only appointments with 'Cancelled' status can be deleted.");
                return;
            }

            // Step 4: Use DatabaseHelper to get a connection
            using (OleDbConnection con = BaseClass.GetConnection())
            {
                try
                {
                    con.Open();

                    // Step 5: Check if the UserID exists in the Users table
                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE ID = @UserID";
                    using (OleDbCommand checkUserCmd = new OleDbCommand(checkUserQuery, con))
                    {
                        checkUserCmd.Parameters.AddWithValue("@UserID", userID);
                        int userCount = (int)checkUserCmd.ExecuteScalar();

                        if (userCount == 0)
                        {
                            MessageBox.Show("UserID does not exist in the Users table. Cannot delete appointment.");
                            return;
                        }
                    }

                    // Step 6: Delete the appointment from the Appointments table (only if status is "Cancelled")
                    string deleteAppointmentQuery = @"
                DELETE FROM Appointments 
                WHERE AppointmentID = @AppointmentID 
                  AND UserID = @UserID 
                  AND Status = @Status";
                    using (OleDbCommand cmd = new OleDbCommand(deleteAppointmentQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@Status", "Cancelled");

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cancelled appointment deleted successfully.");
                            table_CancelpatientAppointment.Rows.RemoveAt(table_CancelpatientAppointment.CurrentRow.Index); // Remove the row from the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Deletion failed. Appointment may not have 'Cancelled' status or does not exist.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        
        private void NotifyPatient(string patientName)
        {
            // Create new popup and show it immediately
            var popup = new PopupNotifier();
            popup.TitleText = "APPOINTMENT CANCELLED";
            popup.ContentText = $"Dr. {loggedInFirstName} cancelled the patient's appointment!";
            popup.Popup();
        }
        private void CreateNewNotification(int userId, string status)
        {
            using (OleDbConnection con = BaseClass.GetConnection())
            {
                con.Open();

                // First clear any existing notifications for this user
                string clearQuery = @"UPDATE Doctorschedule 
                                SET PatientNotification = '0' 
                                WHERE UserID = @UserID";

                // Then add the new notification
                string notifyQuery = @"UPDATE Doctorschedule 
                                 SET PatientNotification = '1', 
                                     Status = @Status
                                 WHERE UserID = @UserID 
                                 AND AppointmentDate = @AppointmentDate";

                using (OleDbCommand clearCmd = new OleDbCommand(clearQuery, con))
                {
                    clearCmd.Parameters.AddWithValue("@UserID", userId);
                    clearCmd.ExecuteNonQuery();
                }

                using (OleDbCommand notifyCmd = new OleDbCommand(notifyQuery, con))
                {
                    notifyCmd.Parameters.AddWithValue("@Status", status);
                    notifyCmd.Parameters.AddWithValue("@UserID", userId);
                    notifyCmd.Parameters.AddWithValue("@AppointmentDate", selectedAppointmentDate);
                    notifyCmd.ExecuteNonQuery();
                }
            }
        }


    }
}
