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
    public partial class ViewAppointment : UserControl
    {
        private string loggedInFirstName;
        private string loggedInLastName;
        public ViewAppointment(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;
        }

        private void btn_loadAppointments_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = DatabaseHelper.GetConnection())
            {
                try
                {
                    con.Open();

                    // Step 1: Retrieve the UserID of the logged-in patient
                    string userQuery = "SELECT ID FROM USERS WHERE [FirstName] = @FirstName AND [LastName] = @LastName";
                    using (OleDbCommand userCmd = new OleDbCommand(userQuery, con))
                    {
                        userCmd.Parameters.AddWithValue("@FirstName", loggedInFirstName);
                        userCmd.Parameters.AddWithValue("@LastName", loggedInLastName);

                        object result = userCmd.ExecuteScalar();
                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show("Patient not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Stop execution if patient doesn't exist
                        }
                        int userID = Convert.ToInt32(result); // Get the patient's UserID

                        // Step 2: Retrieve accepted appointments for the logged-in patient
                        string appointmentQuery = @"
                            SELECT * 
                            FROM Patientsschedule 
                            WHERE UserID = @UserID 
                              AND Status = @Status";
                        using (OleDbCommand appointmentCmd = new OleDbCommand(appointmentQuery, con))
                        {
                            appointmentCmd.Parameters.AddWithValue("@UserID", userID);
                            appointmentCmd.Parameters.AddWithValue("@Status", "Accepted");

                            // Step 3: Execute the query and load the data into a DataTable
                            using (OleDbDataAdapter adapter = new OleDbDataAdapter(appointmentCmd))
                            {
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);

                                // Step 4: Bind the DataTable to your table control (e.g., DataGridView)
                                table_ViewPatientAppointment.DataSource = dt;

                                // Optional: Display a success message
                                if (dt.Rows.Count > 0)
                                {
                                    MessageBox.Show("Accepted appointments loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No accepted appointments found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }

        }
    }
}
