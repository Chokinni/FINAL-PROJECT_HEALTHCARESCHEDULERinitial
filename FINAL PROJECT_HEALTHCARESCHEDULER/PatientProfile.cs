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
    public partial class PatientProfile : Form
    {
        private string firstName;
        private string lastName;
        public PatientProfile(string firstName, string lastName)
        {
            InitializeComponent();
            this.firstName = firstName;
            this.lastName = lastName;
            
        }



        private void PatientProfile_Load(object sender, EventArgs e)
        {





            using (OleDbConnection conn = BaseClass.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM USERS WHERE [Role]='PATIENT' AND [FirstName]=@FirstName AND [LastName]=@LastName";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lbl_name.Text = "Fullname: " + reader["FirstName"].ToString() + " " + reader["LastName"].ToString();

                            lbl_email.Text = "Email: " + reader["EmailAddress"].ToString();

                            lbl_homeadd.Text = "Home Address: " + reader["HomeAddress"].ToString();

                            lbl_phone.Text = "Phone Number: " + reader["PhoneNumber"].ToString();
                            lbl_socials.Text = "Social Media: " + reader["SocialMedia"].ToString();
                            lbl_contactname.Text = "Contact Person Name: " + reader["ContactPerson"].ToString();
                            lbl_relationship.Text = "Relationship: " + reader["Relationship"].ToString();
                            lbl_contactemergency.Text = "Emergency Contact: " + reader["EmergencyNo"].ToString();
                            if (reader["ProfilePicture"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])reader["ProfilePicture"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    picture_displaypatient.Image = Image.FromStream(ms);
                                    picture_displaypatient.SizeMode = PictureBoxSizeMode.Zoom; // Optional: makes image fit nicely
                                }
                            }
                            else
                            {
                                // Optional: Set a default image or clear the PictureBox
                                picture_displaypatient.Image = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Patientprofile not found.");
                        }
                    }
                }
            }
        }

        private void lbl_exitdoctor_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_namepaint(object sender, PaintEventArgs e)
        {
            

        }
        
    }
}
