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
            string password = tbx_regpassword.Text.Trim();
            ;
            string specialty = (role == "DOCTOR") ? cbx_specialty.Text.Trim() : "N/A"; // Only doctors have a specialty

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("All fields must be filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Regular expression patterns for username validation
           
            
            
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


            using (OleDbConnection con = DatabaseHelper.GetConnection())
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO Users (Firstname, Lastname, Username, [Password], Role, Specialty) " +
                                   "VALUES (@Firstname, @Lastname, @Username, @Password, @Role, @Specialty)";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@Specialty", specialty);

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
    }

}

