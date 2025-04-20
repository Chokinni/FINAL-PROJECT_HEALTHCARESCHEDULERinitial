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
    public partial class EditPatientProfile : Form
    {
        private string originalFirstName;
        private string originalLastName;
        private OleDbConnection conn = BaseClass.GetConnection();


        public EditPatientProfile(string firstName, string lastName)
        {
            InitializeComponent();
            originalFirstName = firstName;
            originalLastName = lastName;

            this.Load += EditPatientProfile_Load;
            //btnSave.Click += btnSave_Click;
            //btnChangePicture.Click += btnChangePicture_Click;

            // Make tbx_editname read-only
            tbx_editname.ReadOnly = true;
            tbx_editname.BorderStyle = BorderStyle.None;
            tbx_editname.BackColor = this.BackColor;
            tbx_editname.TabStop = false;

            // Stretch image
            picture_displaydoctoredit.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_editphone.Text.Trim()) ||
      string.IsNullOrEmpty(tbx_editemail.Text.Trim()) ||
      string.IsNullOrEmpty(tbx_editsocial.Text.Trim()) ||
      string.IsNullOrEmpty(tbx_editaddress.Text.Trim()) ||
      string.IsNullOrEmpty(tbx_editrelationship.Text.Trim()) ||
      string.IsNullOrEmpty(tbx_editapppass.Text.Trim()) ||
      string.IsNullOrEmpty(tbx_editcontactnum.Text.Trim()))
            {
                MessageBox.Show("Please fill in all the required fields.");
                return;
            }
            try
            {
                conn.Open();

                byte[] imageBytes = null;
                if (picture_displaydoctoredit.Image != null)
                {
                    using (var ms = new System.IO.MemoryStream())
                    {
                        using (var bmp = new Bitmap(picture_displaydoctoredit.Image))
                        {
                            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        imageBytes = ms.ToArray();
                    }
                }

                string updateQuery = @"UPDATE USERS SET 
                    PhoneNumber = ?, 
                    EmailAddress = ?, 
                    SocialMedia = ?, 
                    HomeAddress = ?, 
                    Relationship = ?, 
                    ContactPerson = ?, 
                    EmergencyNo = ?, 
                    ProfilePicture = ?,
                    AppPassword= ?
                    WHERE FirstName = ? AND LastName = ?";

                OleDbCommand cmd = new OleDbCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("?", tbx_editphone.Text);
                cmd.Parameters.AddWithValue("?", tbx_editemail.Text);
                cmd.Parameters.AddWithValue("?", tbx_editsocial.Text);
                cmd.Parameters.AddWithValue("?", tbx_editaddress.Text);
                cmd.Parameters.AddWithValue("?", tbx_editrelationship.Text);
                cmd.Parameters.AddWithValue("?", tbx_editcontactname.Text);
                cmd.Parameters.AddWithValue("?", tbx_editcontactnum.Text);
                cmd.Parameters.AddWithValue("?", imageBytes ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("?", tbx_editapppass.Text);
                cmd.Parameters.AddWithValue("?", originalFirstName);
                cmd.Parameters.AddWithValue("?", originalLastName);


                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Patient profile updated successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed. Patient not found.");
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

        private void EditPatientProfile_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM USERS WHERE FirstName = ? AND LastName = ?";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("?", originalFirstName);
                cmd.Parameters.AddWithValue("?", originalLastName);

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tbx_editname.Text = $"{reader["FirstName"].ToString().Trim()} {reader["LastName"].ToString().Trim()}";
                    tbx_editphone.Text = reader["PhoneNumber"].ToString();
                    tbx_editemail.Text = reader["EmailAddress"].ToString();
                    tbx_editsocial.Text = reader["SocialMedia"].ToString();
                    tbx_editaddress.Text = reader["HomeAddress"].ToString();
                    tbx_editrelationship.Text = reader["Relationship"].ToString();
                    tbx_editcontactname.Text = reader["ContactPerson"].ToString();
                    tbx_editcontactnum.Text = reader["EmergencyNo"].ToString();
                    tbx_editapppass.Text = reader["AppPassword"].ToString();


                    if (reader["ProfilePicture"] != DBNull.Value)
                    {
                        byte[] imgData = (byte[])reader["ProfilePicture"];
                        using (var ms = new System.IO.MemoryStream(imgData))
                        {
                            picture_displaydoctoredit.Image = Image.FromStream(ms);
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient data:\n" + ex.Message);
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
            // Open file dialog to select a new image
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select Profile Picture";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load the selected image and display it in the PictureBox
                        picture_displaydoctoredit.Image = new Bitmap(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message);
                    }
                }
            }
        }

        private void picture_displaydoctoredit_Click(object sender, EventArgs e)
        {

        }
    }
}
