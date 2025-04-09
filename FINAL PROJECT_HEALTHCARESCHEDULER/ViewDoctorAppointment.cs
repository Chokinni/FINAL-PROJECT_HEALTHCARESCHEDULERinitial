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
    public partial class ViewDoctorAppointment : UserControl
    {

        private string loggedInFirstName;
        private string loggedInLastName;
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
            using (OleDbConnection con = DatabaseHelper.GetConnection())
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
                            table_ViewDoctorAppointment.AutoResizeColumns();
                            table_ViewDoctorAppointment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
    }
}
