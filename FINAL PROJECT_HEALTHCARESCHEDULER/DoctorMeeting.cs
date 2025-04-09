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
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class DoctorMeeting : UserControl
    {
        private string loggedInFirstName;
        private string loggedInLastName;
        public DoctorMeeting(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;
        }

        private void btn_loadschedmeet_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection connection = DatabaseHelper.GetConnection())
                {
                    // Query to select meetings for the logged-in doctor
                    string query = @"SELECT AppointmentID, Doctor, Patient, MeetingLink, MeetingStatus, 
                           AppointmentDate, CreatedDate, UserID 
                           FROM DoctorOnlineMeeting 
                           WHERE Doctor = @doctorName
                           ORDER BY AppointmentDate";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@doctorName", $"{loggedInFirstName} {loggedInLastName}");

                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    connection.Open();
                    adapter.Fill(dataTable);

                    // Assuming you have a DataGridView named dataGridView1 on your form
                    table_CreateMeeting.DataSource = dataTable;

                    // Optional: Format the DataGridView columns
                    if (table_CreateMeeting.Columns.Count > 0)
                    {
                        table_CreateMeeting.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                        // Format date columns
                        table_CreateMeeting.Columns["AppointmentDate"].DefaultCellStyle.Format = "g";
                        table_CreateMeeting.Columns["CreatedDate"].DefaultCellStyle.Format = "g";

                        // Set more descriptive headers if needed
                        table_CreateMeeting.Columns["AppointmentID"].HeaderText = "Appointment ID";
                        table_CreateMeeting.Columns["MeetingLink"].HeaderText = "Meeting Link";
                        table_CreateMeeting.Columns["MeetingStatus"].HeaderText = "Status";
                        table_CreateMeeting.Columns["AppointmentDate"].HeaderText = "Appointment Date";
                        table_CreateMeeting.Columns["CreatedDate"].HeaderText = "Created Date";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading meeting schedule: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
