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

    public partial class EditDoctorProfile : Form
    {
        private string originalFirstName;
        private string originalLastName;
        private OleDbConnection conn = BaseClass.GetConnection();
        public EditDoctorProfile(string firstName, string lastName)
        {
            InitializeComponent();
            originalFirstName = firstName;
            originalLastName = lastName;

            this.Load += EditDoctorProfile_Load;
            //btnSave.Click += btnSave_Click;
            //btnChangePicture.Click += btnChangePicture_Click;

            // Make tbx_editname read-only
            tbx_editname.ReadOnly = true;
            tbx_editname.BorderStyle = BorderStyle.None;
            tbx_editname.BackColor = this.BackColor;
            tbx_editname.TabStop = false;
            tbx_editspecialization.ReadOnly = true;
            tbx_editspecialization.BorderStyle = BorderStyle.None;
            tbx_editspecialization.BackColor = this.BackColor;
            tbx_editspecialization.TabStop = false;

            // Stretch image
            picture_displaydoctoredit.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void EditDoctorProfile_Load(object sender, EventArgs e)
        {
            // Show full name in the read-only textbox
            tbx_editname.Text = $"{originalFirstName.Trim()} {originalLastName.Trim()}";

            try
            {
                conn.Open();
                string query = @"SELECT PhoneNumber, EmailAddress, SocialMedia, AppPassword,
                                MedicalLicenseNumber, YearsOfExperience, MedicalSchool,
                                BoardCertified, HomeAddress, Specialty, ProfilePicture
                         FROM USERS 
                         WHERE FirstName = ? AND LastName = ?";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", originalFirstName);
                    cmd.Parameters.AddWithValue("?", originalLastName);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tbx_editphone.Text = reader["PhoneNumber"].ToString();
                            tbx_editemail.Text = reader["EmailAddress"].ToString();
                            tbx_editsocial.Text = reader["SocialMedia"].ToString();
                            tbx_editapppass.Text = reader["AppPassword"].ToString();
                            tbx_editlicense.Text = reader["MedicalLicenseNumber"].ToString();
                            tbx_edityear.Text = reader["YearsOfExperience"].ToString();
                            tbx_editmedschool.Text = reader["MedicalSchool"].ToString();
                            tbx_editcertified.Text = reader["BoardCertified"].ToString();
                            tbx_editaddress.Text = reader["HomeAddress"].ToString();
                            tbx_editspecialization.Text = reader["Specialty"].ToString();

                            if (reader["ProfilePicture"] != DBNull.Value)
                            {
                                byte[] imgData = (byte[])reader["ProfilePicture"];
                                using (var ms = new System.IO.MemoryStream(imgData))
                                {
                                    picture_displaydoctoredit.Image = Image.FromStream(ms);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Doctor not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading doctor profile: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void picture_displaydoctoredit_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbx_editphone.Text) ||
         string.IsNullOrWhiteSpace(tbx_editemail.Text) ||
         string.IsNullOrWhiteSpace(tbx_editsocial.Text) ||
         string.IsNullOrWhiteSpace(tbx_editapppass.Text) ||
         string.IsNullOrWhiteSpace(tbx_editlicense.Text) ||
         string.IsNullOrWhiteSpace(tbx_edityear.Text) ||
         string.IsNullOrWhiteSpace(tbx_editcertified.Text) ||
         string.IsNullOrWhiteSpace(tbx_editaddress.Text) ||
         string.IsNullOrWhiteSpace(tbx_editspecialization.Text) ||
         string.IsNullOrWhiteSpace(tbx_editmedschool.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            byte[] imageBytes = null;

            if (picture_displaydoctoredit.Image != null)
            {
                try
                {
                    using (var ms = new System.IO.MemoryStream())
                    {
                        using (var bmp = new Bitmap(picture_displaydoctoredit.Image))
                        {
                            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // ✅ Use PNG
                        }
                        imageBytes = ms.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Image save error: " + ex.Message);
                }
            }

            try
            {
                conn.Open();

                string updateQuery = @"UPDATE USERS SET 
            PhoneNumber = ?, 
            EmailAddress = ?, 
            SocialMedia = ?, 
            AppPassword = ?, 
            MedicalLicenseNumber = ?, 
            YearsOfExperience = ?, 
            MedicalSchool = ?, 
            BoardCertified = ?,
            HomeAddress= ?,
            ProfilePicture = ?,
            Specialty= ?
            WHERE FirstName = ? AND LastName = ?";

                OleDbCommand cmd = new OleDbCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("?", tbx_editphone.Text);
                cmd.Parameters.AddWithValue("?", tbx_editemail.Text);
                cmd.Parameters.AddWithValue("?", tbx_editsocial.Text);
                cmd.Parameters.AddWithValue("?", tbx_editapppass.Text);
                cmd.Parameters.AddWithValue("?", tbx_editlicense.Text);
                cmd.Parameters.AddWithValue("?", tbx_edityear.Text);
                cmd.Parameters.AddWithValue("?", tbx_editmedschool.Text);
                cmd.Parameters.AddWithValue("?", tbx_editcertified.Text);
                cmd.Parameters.AddWithValue("?", tbx_editaddress.Text);
                cmd.Parameters.AddWithValue("?", imageBytes ?? (object)DBNull.Value); // ✅ image
                cmd.Parameters.AddWithValue("?", tbx_editspecialization.Text);
                cmd.Parameters.AddWithValue("?", originalFirstName);
                cmd.Parameters.AddWithValue("?", originalLastName);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Doctor profile updated successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed. Doctor not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void lbl_exitedit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_editupload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select Profile Picture";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Dispose the old image if any
                        picture_displaydoctoredit.Image?.Dispose();

                        // Clone the image into memory so it's not locked
                        using (var tempImg = new Bitmap(openFileDialog.FileName))
                        {
                            picture_displaydoctoredit.Image = new Bitmap(tempImg); // in-memory clone
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message);
                    }
                }
            }
        }
    }
}
