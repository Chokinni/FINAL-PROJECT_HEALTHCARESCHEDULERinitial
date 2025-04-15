using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btn_reglogin_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void exitlbl_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {

            // Ensure role is not null
            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a role!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string role = cmbRole.SelectedItem.ToString();
            string firstName = tbx_firstname.Text.Trim();
            string lastName = tbx_lastname.Text.Trim();
            string username = tbx_regusername.Text.Trim().ToUpper();
            string phonenum = tbx_num.Text.Trim();
            string emailadd = tbx_email.Text.Trim();
            string medicallicense = tbx_Licensenum.Text.Trim();
            string experience = tbx_experience.Text.Trim();
            string homeadd = tbx_homeadd.Text.Trim();
            string certified = tbx_certified.Text.Trim();
            string school = tbx_medschool.Text.Trim();
            string Social = tbx_media.Text.Trim();
            string contactper = tbx_emercon.Text.Trim();

            string relationship = tbx_relationship.Text.Trim();

            string emercontact = tbx_contactemer.Text.Trim();   
            string apppassword= tbx_apppass.Text.Trim();    


            //string password = tbx_regpassword.Text.Trim();
            string password = HashPassword(tbx_regpassword.Text.Trim());
            string specialty = (role == "DOCTOR") ? cbx_specialty.Text.Trim() : "N/A";
            if (picture_profile.Image == null)
            {
                MessageBox.Show("Please upload a profile picture!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Basic common validation
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(phonenum) || string.IsNullOrEmpty(emailadd) ||
                string.IsNullOrEmpty(homeadd) || string.IsNullOrEmpty(Social) || string.IsNullOrEmpty(contactper)
                || string.IsNullOrEmpty(relationship) || string.IsNullOrEmpty(emercontact) || string.IsNullOrEmpty(apppassword))
            {
                MessageBox.Show("Please fill in all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (role == "DOCTOR")
            {
                if (string.IsNullOrEmpty(specialty) || string.IsNullOrEmpty(medicallicense) ||
                    string.IsNullOrEmpty(experience) || string.IsNullOrEmpty(certified) || string.IsNullOrEmpty(school))
                {
                    MessageBox.Show("Please complete all doctor-specific fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (picture_profile.Image == null)
                {
                    MessageBox.Show("Please upload a profile picture!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            string doctorPattern = @"^D\d{2}-\d{4}-\d{3}$";
            string patientPattern = @"^P\d{2}-\d{4}-\d{3}$";


            // Validate username format based on role
            if (role == "DOCTOR" && !Regex.IsMatch(username, doctorPattern))
            {
                MessageBox.Show("Invalid username format for Doctor! Format: DYY-XXXX-XXX", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (role == "PATIENT" && !Regex.IsMatch(username, patientPattern))
            {
                MessageBox.Show("Invalid username format for Patient! Format: PYY-XXXX-XXX", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (OleDbConnection con = BaseClass.GetConnection())
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO Users (Firstname, Lastname, Username, [Password], Role, Specialty, PhoneNumber, EmailAddress, MedicalLicenseNumber, YearsofExperience, BoardCertified, HomeAddress, MedicalSchool, SocialMedia, ProfilePicture, ContactPerson, Relationship, EmergencyNo, AppPassword) " +
                                   "VALUES (@Firstname, @Lastname, @Username, @Password, @Role, @Specialty, @PhoneNumber, @EmailAddress, @MedicalLicenseNumber, @YearsofExperience, @BoardCertified, @HomeAddress, @MedicalSchool, @SocialMedia, @imgData, @ContactPerson, @Relationship, @EmergencyNo,@AppPassword)";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@Specialty", specialty);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phonenum);
                    cmd.Parameters.AddWithValue("@EmailAddress", emailadd);
                    cmd.Parameters.AddWithValue("@MedicalLicenseNumber", medicallicense);
                    cmd.Parameters.AddWithValue("@YearsofExperience", experience);
                    cmd.Parameters.AddWithValue("@BoardCertified", certified);
                    cmd.Parameters.AddWithValue("@HomeAddress", homeadd);
                    cmd.Parameters.AddWithValue("@MedicalSchool", school);
                    cmd.Parameters.AddWithValue("@SocialMedia", Social);
                    if (picture_profile.Image != null)
                    {
                        byte[] imgData = ImageToByteArray(picture_profile.Image);
                        cmd.Parameters.AddWithValue("@ProfilePicture", imgData);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProfilePicture", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@ContactPerson", contactper);
                    cmd.Parameters.AddWithValue("@Relationship", relationship);
                    cmd.Parameters.AddWithValue("@EmergencyNo", emercontact);
                    cmd.Parameters.AddWithValue("@AppPassword", apppassword);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbx_specialty_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isDoctor = cmbRole.SelectedItem.ToString() == "DOCTOR";

            cbx_specialty.Enabled = isDoctor;
            tbx_Licensenum.Enabled = isDoctor;
            tbx_experience.Enabled = isDoctor;
            tbx_certified.Enabled = isDoctor;
            tbx_medschool.Enabled = isDoctor;
            tbx_relationship.Enabled = !isDoctor;
            tbx_contactemer.Enabled = !isDoctor;
            tbx_emercon.Enabled = !isDoctor;


            if (!isDoctor)
            {
                cbx_specialty.Text = "";
                tbx_Licensenum.Text = "N/A";
                tbx_experience.Text = "N/A";
                tbx_certified.Text = "N/A";
                tbx_medschool.Text = "N/A";
                tbx_emercon.Text = "";
                tbx_contactemer.Text = "";
                tbx_relationship.Text = "";

            }
            else
            {
                tbx_Licensenum.Text = "";
                tbx_experience.Text = "";
                tbx_certified.Text = "";
                tbx_medschool.Text = "";
                
                tbx_emercon.Text = "N/A";
                tbx_contactemer.Text = "N/A";
                tbx_relationship.Text = "N/A";
            }






            if (cmbRole.SelectedItem.ToString() == "DOCTOR")
            {
                cbx_specialty.Enabled = true;  // Enable Specialty textbox for Doctors
            }
            else
            {
                cbx_specialty.Enabled = false; // Disable and clear Specialty textbox for Patients
                cbx_specialty.Text = "";
            }
        }

        private void reg_showpass_CheckedChanged(object sender, EventArgs e)
        {
            tbx_regpassword.PasswordChar = reg_showpass.Checked ? '\0' : '*';
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                string hashedpassword = Convert.ToBase64String(hashBytes);
                return hashedpassword;
            }
        }

        private void btn_generateUsername_Click(object sender, EventArgs e)
        {
            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a role first.", "Role Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = cmbRole.SelectedItem.ToString();
            string prefix = (role == "DOCTOR") ? "D" : "P";

            // Generate current year in two-digit format
            string year = DateTime.Now.ToString("yy");

            // Generate random parts
            Random rnd = new Random();
            int mid = rnd.Next(1000, 9999);   // 4 digits
            int end = rnd.Next(100, 999);     // 3 digits

            string generatedUsername = $"{prefix}{year}-{mid}-{end}";
            tbx_regusername.Text = generatedUsername;
        }

        private void btn_insertpic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picture_profile.Image = Image.FromFile(openFileDialog.FileName);
                picture_profile.Tag = openFileDialog.FileName; // store file path temporarily
            }

        }
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            
        }

        private void picture_profile_Click(object sender, EventArgs e)
        {
            
        }

        private void picture_profile_Paint(object sender, PaintEventArgs e)
        {
            // Define light blue color
            Color lightBlue = Color.LightBlue;

            // Define the border thickness
            int borderThickness = 3;

            // Draw rectangle border
            using (Pen borderPen = new Pen(lightBlue, borderThickness))
            {
                // Adjust rectangle size to avoid cutting the border
                Rectangle rect = new Rectangle(0, 0, picture_profile.Width - 1, picture_profile.Height - 1);
                e.Graphics.DrawRectangle(borderPen, rect);
            }

        }
    }

}

