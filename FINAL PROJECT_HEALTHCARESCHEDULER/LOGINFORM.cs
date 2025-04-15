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
using System.Security.Cryptography;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showpasslogin_CheckedChanged(object sender, EventArgs e)
        {
            tbx_password.PasswordChar = showpasslogin.Checked ? '\0' : '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrationForm form3 = new RegistrationForm();
            form3.Show();
            this.Hide();
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            string username = tbx_username.Text.Trim();
            string password = tbx_password.Text.Trim();





            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string hashedPassword = HashPassword(password);

            using (OleDbConnection con = BaseClass.GetConnection())
            {
                try
                {
                    con.Open();
                    string query = "SELECT FirstName, LastName, Role FROM Users WHERE Username=@Username AND Password=@Password";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) // If user is found
                    {
                        string role = reader["Role"].ToString();
                        string firstName = reader["FirstName"].ToString();
                        string lastName = reader["LastName"].ToString();
                        string fullName = firstName + " " + lastName;


                        if (role == "DOCTOR")
                        {
                            MessageBox.Show("Login successful! WELCOME DOCTOR!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormDoctorMenu doctorDashboard = new FormDoctorMenu(firstName, lastName);
                            doctorDashboard.Show();
                        }
                        else
                        {
                            MessageBox.Show("Login successful! WELCOME PATIENT!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormPatientMenu patientDashboard = new FormPatientMenu(firstName, lastName);
                            patientDashboard.Show();
                        }
                        this.Hide(); // Hide login form
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
