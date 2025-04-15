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
    public partial class ViewDoctorAppointment : BaseClass
    {


        public ViewDoctorAppointment(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;
        }

        private void ViewDoctorAppointment_Load(object sender, EventArgs e)
        {

        }

        private void btn_loadschedforpatients_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    string fullDoctorName = $"{loggedInFirstName} {loggedInLastName}";

                    // Query with only the columns you want to display
                    string query = @"SELECT 
                          AppointmentID,
                          Doctor,
                          Patient,
                          AppointmentDate,
                          Status,
                          UserID,
                          AppointmentType
                      FROM Doctorschedule 
                      WHERE Doctor = @DoctorName
                      AND Status = 'Accepted'
                      
                      ORDER BY AppointmentDate";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@DoctorName", fullDoctorName);

                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind to DataGridView
                        table_ViewDoctorAppointment.DataSource = dt;

                        if (dt.Rows.Count > 0)
                        {

                            // Then hide the Doctor column
                            if (table_ViewDoctorAppointment.Columns.Contains("Doctor"))
                            {
                                table_ViewDoctorAppointment.Columns["Doctor"].Visible = false;
                            }






                            // Format columns
                            table_ViewDoctorAppointment.Columns["AppointmentID"].HeaderText = "Appointment ID";
                            table_ViewDoctorAppointment.Columns["Patient"].HeaderText = "Patient";
                            table_ViewDoctorAppointment.Columns["AppointmentDate"].HeaderText = "Appointment Time";
                            table_ViewDoctorAppointment.Columns["Status"].HeaderText = "Status";
                            table_ViewDoctorAppointment.Columns["UserID"].HeaderText = "Patient ID";
                            table_ViewDoctorAppointment.Columns["AppointmentType"].HeaderText = "Type";

                            // Format date column
                            table_ViewDoctorAppointment.Columns["AppointmentDate"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";

                            // Auto-size columns
                            var dgv = table_ViewDoctorAppointment;

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
                            //table_ViewDoctorAppointment.AutoResizeColumns();
                            //table_ViewDoctorAppointment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                        else
                        {
                            MessageBox.Show("No upcoming online appointments found.",
                                          "Information",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading appointments: {ex.Message}",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }

        }

        private void strip_viewappointment_Opening(object sender, CancelEventArgs e)
        {
            if (table_ViewDoctorAppointment.SelectedRows.Count > 0)
            {
                string fullName = table_ViewDoctorAppointment.SelectedRows[0].Cells["Patient"].Value.ToString();

                // Split full name into parts
                string[] nameParts = fullName.Trim().Split(' ');

                // Assign first and last name
                string firstName = nameParts.Length > 0 ? nameParts[0] : "";
                string lastName = nameParts.Length > 1 ? string.Join(" ", nameParts.Skip(1)) : "";

                // Open the patient profile form with first and last name
                PatientProfile profileForm = new PatientProfile(firstName, lastName);
                profileForm.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }
    }
}
