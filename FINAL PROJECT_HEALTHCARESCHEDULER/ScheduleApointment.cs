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
    public partial class ScheduleApointment : BaseClass
    {

        public ScheduleApointment(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;
            // Debugging: Check if the logged-in user's name is being passed correctly
            MessageBox.Show("Logged in as: " + loggedInFirstName + " " + loggedInLastName);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            string selectedDateTime = datetime_selectapp.Value.ToString("MM/dd/yyyy hh:mm tt");

            datetime_selectapp.Format = DateTimePickerFormat.Custom;
            datetime_selectapp.CustomFormat = "MM/dd/yyyy hh:mm tt"; // Date + Time (12-hour format)
            datetime_selectapp.ShowUpDown = true; // Removes dropdown calendar
        }

        private void cbx_specialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT FirstName + ' ' + LastName FROM USERS WHERE Role='DOCTOR' AND Specialty=@Specialization";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Specialization", cbx_specialization.SelectedItem.ToString());

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        cbx_doctor.Items.Clear(); // Clear previous items
                        while (reader.Read())
                        {
                            cbx_doctor.Items.Add(reader[0].ToString()); // Add doctors to the combo box
                        }
                    }
                }
            }
        }


        private void btn_confirm_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = BaseClass.GetConnection())
            {
                try
                {
                    con.Open();
                    string appointmentType = RBTN_facetoface.Checked ? "Face to Face" : "Online";
                    if (cbx_specialization.SelectedItem == null || cbx_doctor.SelectedItem == null)
                    {
                        MessageBox.Show("Please select a specialization and a doctor.");
                        return;
                    }
                    DateTime selectedDateTime = datetime_selectapp.Value;
                    DateTime now = DateTime.Now;

                    if (selectedDateTime < now.AddHours(3))
                    {
                        MessageBox.Show("Please select a time at least 3 hours from now, even for today.");
                        return;
                    }
                    if (!RBTN_facetoface.Checked && !RBTN_Online.Checked)
                    {
                        MessageBox.Show("Please select an appointment type: Face to Face or Online.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (datetime_selectapp.Value.Year < 2025 || datetime_selectapp.Value.Year > 2026)
                    {
                        MessageBox.Show("Please select a date within the years 2025 to 2026.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Step 1: Retrieve the UserID of the logged-in user
                    string userQuery = "SELECT ID FROM USERS WHERE [FirstName] = @FirstName AND [LastName] = @LastName";
                    using (OleDbCommand userCmd = new OleDbCommand(userQuery, con))
                    {
                        userCmd.Parameters.AddWithValue("@FirstName", loggedInFirstName);
                        userCmd.Parameters.AddWithValue("@LastName", loggedInLastName);

                        object result = userCmd.ExecuteScalar();
                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Stop execution if user doesn't exist
                        }
                        int userID = Convert.ToInt32(result); // Get the user ID
                        DateTime newAppointmentDate = datetime_selectapp.Value;
                        DateTime startWindow = newAppointmentDate.AddHours(-2); // 4 hours before
                        DateTime endWindow = newAppointmentDate.AddHours(2);   // 4 hours after

                        // Step 3: Check if an appointment already exists within the 4-hour window (before or after)
                        string checkQuery = @"
                    SELECT COUNT(*) 
                    FROM Patientsschedule 
                    WHERE UserID = @UserID
                    AND Doctor = @Doctor
                      AND AppointmentDate BETWEEN @StartWindow AND @EndWindow";
                        using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, con))
                        {
                            checkCmd.Parameters.AddWithValue("@UserID", userID);
                            checkCmd.Parameters.AddWithValue("@Doctor", cbx_doctor.Text);
                            checkCmd.Parameters.AddWithValue("@StartWindow", startWindow.ToString("yyyy-MM-dd HH:mm:ss"));
                            checkCmd.Parameters.AddWithValue("@EndWindow", endWindow.ToString("yyyy-MM-dd HH:mm:ss"));

                            int existingAppointments = Convert.ToInt32(checkCmd.ExecuteScalar());
                            if (existingAppointments > 0)
                            {
                                MessageBox.Show("The appointment time is already taken. Please choose a different within 2 hours of time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return; // Stop execution if an appointment exists within the window
                            }
                        }

                        // Debugging: Display the values being inserted
                        MessageBox.Show($"Doctor: {cbx_doctor.Text}, Specialty: {cbx_specialization.Text}, Patient: {loggedInFirstName} {loggedInLastName}, Date: {datetime_selectapp.Value}, UserID: {userID}, AppointmentType: {appointmentType}");

                        // Step 2: Insert Appointment into the Appointments table
                        string insertQuery = @"INSERT INTO Patientsschedule ([Doctor],[Specialization],[Patient],[AppointmentDate],[Status],[UserID],[AppointmentType],[DoctorNotification])
                                      VALUES (@Doctor, @Specialization, @Patient, @AppointmentDate, @Status, @UserID, @AppointmentType, @DoctorNotification);";

                        using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, con))
                        {
                            insertCmd.Parameters.AddWithValue("@Doctor", cbx_doctor.Text);
                            insertCmd.Parameters.AddWithValue("@Specialization", cbx_specialization.Text);
                            insertCmd.Parameters.AddWithValue("@Patient", loggedInFirstName + " " + loggedInLastName); // Use logged-in user's name
                            insertCmd.Parameters.AddWithValue("@AppointmentDate", datetime_selectapp.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            insertCmd.Parameters.AddWithValue("@Status", "Pending");
                            insertCmd.Parameters.AddWithValue("@UserID", userID);
                            insertCmd.Parameters.AddWithValue("@AppointmentType", appointmentType);
                            insertCmd.Parameters.AddWithValue("@DoctorNotification", false);



                            int rowsAffected = insertCmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Appointment successfully booked!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Fetch doctor email credentials
                                string emailQuery = "SELECT EmailAddress, AppPassword FROM USERS WHERE [FirstName] + ' ' + [LastName] = @DoctorName";
                                using (OleDbCommand emailCmd = new OleDbCommand(emailQuery, con))
                                {
                                    emailCmd.Parameters.AddWithValue("@DoctorName", cbx_doctor.Text);
                                    using (OleDbDataReader reader = emailCmd.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            string doctorEmail = reader["EmailAddress"].ToString();
                                            string appPassword = reader["AppPassword"].ToString();

                                            // Compose email
                                            string subject = "New Appointment Notification";

                                            string body = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{
            font-family: 'Segoe UI', Tahoma, sans-serif;
            background-color: #f9f9f9;
            margin: 0;
            padding: 0;
            color: #333;
        }}
        .container {{
            max-width: 600px;
            margin: auto;
            background-color: #ffffff;
            border-radius: 8px;
            overflow: hidden;
            box-shadow: 0 0 10px rgba(0,0,0,0.05);
        }}
        .header {{
            background-color: #1a73e8;
            color: white;
            padding: 20px;
            text-align: center;
        }}
        .content {{
            padding: 30px;
        }}
        .content h3 {{
            margin-top: 0;
            color: #1a73e8;
        }}
        .details {{
            background-color: #f1f1f1;
            border-radius: 6px;
            padding: 15px;
            margin-top: 20px;
        }}
        .footer {{
            font-size: 12px;
            color: #777;
            text-align: center;
            padding: 15px;
            background-color: #f1f1f1;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h2>Cebu South General Hospital</h2>
        </div>
        <div class='content'>
            <p>Dear Dr. {cbx_doctor.Text},</p>

            <p>You have a new appointment scheduled by a patient. Please find the details below:</p>

            <div class='details'>
                <p><strong>Patient:</strong> {loggedInFirstName} {loggedInLastName}</p>
                <p><strong>Specialization:</strong> {cbx_specialization.Text}</p>
                <p><strong>Appointment Type:</strong> {appointmentType}</p>
                <p><strong>Date:</strong> {datetime_selectapp.Value:MMMM dd, yyyy}</p>
                <p><strong>Time:</strong> {datetime_selectapp.Value:hh:mm tt}</p>
            </div>

            <p>Please log in to the Hospital Scheduler system to review or manage this appointment.</p>

            <p>Thank you for your continued commitment to patient care.</p>

            <p>Best regards,<br/>Hospital Scheduler System</p>
        </div>
        <div class='footer'>
            &copy; {DateTime.Now.Year} Hospital Scheduler. All rights reserved.
        </div>
    </div>
</body>
</html>";

                                            try
                                            {
                                                string senderEmail = "migel24asid@gmail.com";
                                                string senderAppPassword = "lcvl rhgt pqki kxbk";

                                                // Send email using your own SMTP (you can use Gmail, Outlook, etc.)
                                                MailMessage mail = new MailMessage();

                                                mail.From = new MailAddress(senderEmail, "Healthcare Scheduler");
                                                mail.To.Add(doctorEmail); // Send to doctor
                                                mail.Subject = subject;
                                                mail.Body = body;
                                                mail.IsBodyHtml = true;

                                                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                                                smtpClient.Credentials = new NetworkCredential(senderEmail, senderAppPassword);
                                                smtpClient.EnableSsl = true;
                                                smtpClient.Send(mail);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Appointment booked, but failed to send email.\n" + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Doctor's email not found. Appointment booked without email notification.", "Email Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Booking failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ScheduleApointment_Load(object sender, EventArgs e)
        {

        }

        private void strip_doctorprofile_Opening(object sender, CancelEventArgs e)
        {
            if (cbx_doctor.SelectedItem == null)
            {
                MessageBox.Show("Please select a doctor first.", "No Doctor Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedDoctor = cbx_doctor.SelectedItem.ToString();

            // You can split the doctor name into first and last if needed
            string[] names = selectedDoctor.Split(' ');
            string firstName = names.Length > 0 ? names[0] : "";
            string lastName = names.Length > 1 ? names[1] : "";

            // Pass the names to the DoctorProfileForm (you'll need to create this form)
            DoctorProfile profileForm = new DoctorProfile(firstName, lastName);
            profileForm.ShowDialog(); // or .Show() if you don't want it modal
        }
    }
}
