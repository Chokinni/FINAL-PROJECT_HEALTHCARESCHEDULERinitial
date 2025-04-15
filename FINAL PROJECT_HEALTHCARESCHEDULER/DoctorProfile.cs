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
    public partial class DoctorProfile : Form
    {
        private string firstName;
        private string lastName;
        public DoctorProfile(string firstName, string lastName)
        {
            InitializeComponent();
            this.firstName = firstName;
            this.lastName = lastName;


            
        }

        private void lbl_exitdoctor_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DoctorProfile_Load(object sender, EventArgs e)
        {
            using (OleDbConnection conn = BaseClass.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM USERS WHERE [Role]='DOCTOR' AND [FirstName]=@FirstName AND [LastName]=@LastName";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lbl_name.Text = "Fullname: Dr. " + reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                            lbl_specialty.Text = "Specialization: " + reader["Specialty"].ToString();
                            lbl_email.Text = "Email: " + reader["EmailAddress"].ToString();
                            lbl_certified.Text = "Board Certified: " + reader["BoardCertified"].ToString();
                            lbl_experience.Text = "Years of Experience: " + reader["YearsofExperience"].ToString();
                            lbl_homeadd.Text = "Home Address: " + reader["HomeAddress"].ToString();
                            lbl_medicallicense.Text = "Medical License Number: " + reader["MedicalLicenseNumber"].ToString();
                            lbl_medicalschool.Text = "Medical School: " + reader["MedicalSchool"].ToString();
                            lbl_phone.Text = "Phone Number: " + reader["PhoneNumber"].ToString();
                            lbl_socials.Text = "Social Media: " + reader["SocialMedia"].ToString();
                            if (reader["ProfilePicture"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])reader["ProfilePicture"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    picture_display.Image = Image.FromStream(ms);
                                    picture_display.SizeMode = PictureBoxSizeMode.Zoom; // Optional: makes image fit nicely
                                }
                            }
                            else
                            {
                                // Optional: Set a default image or clear the PictureBox
                                picture_display.Image = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Doctor profile not found.");
                        }
                    }
                }
            }

        }
    }
}
