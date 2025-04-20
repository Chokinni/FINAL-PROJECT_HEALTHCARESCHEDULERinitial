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
            try
            {
                using (OleDbConnection conn = BaseClass.GetConnection())
                {
                    conn.Open();

                    // Flexible query that handles both single-name and full-name cases
                    string query = @"SELECT * FROM USERS 
                           WHERE [Role]='PATIENT' 
                           AND (
                               (TRIM([FirstName]) = TRIM(@FirstName) AND TRIM([LastName]) = TRIM(@LastName))
                               OR
                               (TRIM([FirstName]) = TRIM(@FullName) AND [LastName] IS NULL)
                               OR
                               (TRIM([FirstName]) + ' ' + TRIM([LastName]) = TRIM(@FullName))
                           )";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName?.Trim() ?? "");
                        cmd.Parameters.AddWithValue("@LastName", lastName?.Trim() ?? "");
                        cmd.Parameters.AddWithValue("@FullName", $"{firstName?.Trim()} {lastName?.Trim()}".Trim());

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Display patient information
                                lbl_name.Text = "Fullname: " + reader["FirstName"].ToString() + " " +
                                              (reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : "");

                                lbl_email.Text = "Email: " + reader["EmailAddress"].ToString();
                                lbl_homeadd.Text = "Home Address: " + reader["HomeAddress"].ToString();
                                lbl_phone.Text = "Phone Number: " + reader["PhoneNumber"].ToString();
                                lbl_socials.Text = "Social Media: " + reader["SocialMedia"].ToString();
                                lbl_contactname.Text = "Contact Person Name: " + reader["ContactPerson"].ToString();
                                lbl_relationship.Text = "Relationship: " + reader["Relationship"].ToString();
                                lbl_contactemergency.Text = "Emergency Contact: " + reader["EmergencyNo"].ToString();

                                // Profile picture
                                if (reader["ProfilePicture"] != DBNull.Value)
                                {
                                    byte[] imageBytes = (byte[])reader["ProfilePicture"];
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        picture_displaypatient.Image = Image.FromStream(ms);
                                        picture_displaypatient.SizeMode = PictureBoxSizeMode.Zoom;
                                    }
                                }
                                else
                                {
                                    picture_displaypatient.Image = null;
                                }

                                // Birth date
                                if (reader["BirthDate"] != DBNull.Value)
                                {
                                    DateTime birthDate = Convert.ToDateTime(reader["BirthDate"]);
                                    lbl_birthdate.Text = "Birth Date: " + birthDate.ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                    lbl_birthdate.Text = "Birth Date: N/A";
                                }

                                // Gender
                                lbl_gender.Text = reader["Gender"] != DBNull.Value ?
                                    $"Gender: {reader["Gender"].ToString().Trim()}" : "Gender: N/A";
                            }
                            else
                            {
                                MessageBox.Show($"Patient not found: {firstName} {lastName}");
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patient profile: {ex.Message}");
                this.Close();
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
