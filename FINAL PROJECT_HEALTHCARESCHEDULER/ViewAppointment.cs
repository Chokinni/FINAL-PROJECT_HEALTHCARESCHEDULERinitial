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
    public partial class ViewAppointment : BaseClass
    {

        public ViewAppointment(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;
            btn_searchDoctor.Visible = false;
        }

        private DataTable originalData;
        private void btn_loadAppointments_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = GetConnection())
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
                                if (table_ViewPatientAppointment.Columns.Contains("DoctorNotification"))
                                    table_ViewPatientAppointment.Columns["DoctorNotification"].Visible = false;

                                if (table_ViewPatientAppointment.Columns.Contains("IsUpdated"))
                                    table_ViewPatientAppointment.Columns["IsUpdated"].Visible = false;
                                var dgv = table_ViewPatientAppointment;

                                dgv.EnableHeadersVisualStyles = false;
                                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
                                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                                dgv.ColumnHeadersHeight = 35;

                                dgv.DefaultCellStyle.BackColor = Color.White;
                                dgv.DefaultCellStyle.ForeColor = Color.Black;
                                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                                dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                                dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

                                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

                                dgv.RowTemplate.Height = 30;
                                dgv.GridColor = Color.LightGray;

                                dgv.BorderStyle = BorderStyle.Fixed3D;
                                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                dgv.AutoResizeColumns();

                                originalData = dt;

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

        private void txt_searchDoctor_TextChanged(object sender, EventArgs e)
        {
            if (txt_searchDoctor.Text.Length >= 2)
            {
                SearchByDoctorName();
            }
            else if (txt_searchDoctor.Text.Length == 0)
            {
                // Reset to show all when search box is cleared
                table_ViewPatientAppointment.DataSource = originalData;
            }
        }

        private void btn_searchDoctor_Click(object sender, EventArgs e)
        {
            SearchByDoctorName();

        }

        private void SearchByDoctorName()
        {
            if (originalData == null)
            {
                MessageBox.Show("Please load appointments first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string searchText = txt_searchDoctor.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                // If search text is empty, show all records
                table_ViewPatientAppointment.DataSource = originalData;
                return;
            }

            // Create a new DataTable with the same schema
            DataTable filteredData = originalData.Clone();

            // Filter rows based on doctor name
            foreach (DataRow row in originalData.Rows)
            {
                // Adjust "DoctorName" to the actual column name in your table
                if (row["Doctor"].ToString().ToLower().Contains(searchText))
                {
                    filteredData.ImportRow(row);
                }
            }

            // Update the DataGridView with filtered results
            table_ViewPatientAppointment.DataSource = filteredData;

            if (filteredData.Rows.Count == 0)
            {
                MessageBox.Show("No appointments found with this doctor.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void strip_viewdocprofile_Opening(object sender, CancelEventArgs e)
        {
            if (table_ViewPatientAppointment.SelectedRows.Count > 0)
            {
                string fullName = table_ViewPatientAppointment.SelectedRows[0].Cells["Doctor"].Value.ToString();

                // NEW: Better name handling
                string[] nameParts = fullName.Trim().Split(new[] { ' ' }, 2); // Split into max 2 parts

                string firstName = nameParts[0];
                string lastName = nameParts.Length > 1 ? nameParts[1] : ""; // Handle single-word names

                // DEBUG: Show what we're searching for
                MessageBox.Show($"Searching for:\nFirst Name: '{firstName}'\nLast Name: '{lastName}'",
                              "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DoctorProfile profileFormdoc = new DoctorProfile(firstName, lastName);
                profileFormdoc.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }
    }
}
