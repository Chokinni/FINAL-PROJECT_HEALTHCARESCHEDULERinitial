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
                        string insertQuery = @"INSERT INTO Patientsschedule ([Doctor],[Specialization],[Patient],[AppointmentDate],[Status],[UserID],[AppointmentType])
                                      VALUES (@Doctor, @Specialization, @Patient, @AppointmentDate, @Status, @UserID, @AppointmentType);";

                        using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, con))
                        {
                            insertCmd.Parameters.AddWithValue("@Doctor", cbx_doctor.Text);
                            insertCmd.Parameters.AddWithValue("@Specialization", cbx_specialization.Text);
                            insertCmd.Parameters.AddWithValue("@Patient", loggedInFirstName + " " + loggedInLastName); // Use logged-in user's name
                            insertCmd.Parameters.AddWithValue("@AppointmentDate", datetime_selectapp.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            insertCmd.Parameters.AddWithValue("@Status", "Pending");
                            insertCmd.Parameters.AddWithValue("@UserID", userID);
                            insertCmd.Parameters.AddWithValue("@AppointmentType", appointmentType);



                            int rowsAffected = insertCmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Appointment successfully booked!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
