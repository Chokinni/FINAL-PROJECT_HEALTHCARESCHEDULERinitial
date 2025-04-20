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
    public partial class OnlineMeeting : BaseClass
    {
        public OnlineMeeting(string firstName, string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;
        }
        private DataTable originalData;

        private void btn_loadschedmeeting_Click(object sender, EventArgs e)
        {
            // Clear existing data from the table to avoid duplicates
            table_OnlinemeetingAppointment.DataSource = null;

            // SQL query to get only the "Online" appointments that are accepted by the doctor
            string query = "SELECT Doctor, Patient, AppointmentType, Status, MeetingLink, AppointmentDate, MeetingStatus " +
               "FROM Meetingtwo " +
               "WHERE AppointmentType = 'Online' AND Status = 'Accepted' AND Patient = @Patient";

            using (OleDbConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        // Add parameters to avoid SQL injection
                        cmd.Parameters.AddWithValue("?", loggedInFirstName + " " + loggedInLastName);

                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the new data to the table
                        table_OnlinemeetingAppointment.DataSource = dt;
                        var dgv = table_OnlinemeetingAppointment;

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
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading schedule: " + ex.Message);
                }
            }

        }

        private void btn_join_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (table_OnlinemeetingAppointment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a meeting to join.");
                return;
            }

            try
            {
                // Get the meeting link from the selected row
                DataGridViewRow row = table_OnlinemeetingAppointment.SelectedRows[0];
                string meetLink = row.Cells["MeetingLink"].Value?.ToString();
                string meetingStatus = row.Cells["MeetingStatus"].Value?.ToString();

                // Validate that the meeting link exists
                if (string.IsNullOrEmpty(meetLink))
                {
                    MessageBox.Show("No meeting link available for this appointment. Please schedule the meeting first.");
                    return;
                }
                if (meetingStatus == "Finished")
                {
                    MessageBox.Show("This meeting has already finished. You cannot join it.");
                    return;
                }

                // Open the WebView_joinmeet form with the meeting link
                WebView_joinpatient joinMeetpatientForm = new WebView_joinpatient(loggedInFirstName, loggedInLastName, meetLink);
                joinMeetpatientForm.Show();

                // Initialize the WebView and navigate to the meeting link
                joinMeetpatientForm.InitializeWebViewAndJoin();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error joining meeting: " + ex.Message);
            }
        }

        private void txt_searchDoctor_TextChanged(object sender, EventArgs e)
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
                table_OnlinemeetingAppointment.DataSource = originalData;
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
            table_OnlinemeetingAppointment.DataSource = filteredData;

            if (filteredData.Rows.Count == 0)
            {
                MessageBox.Show("No appointments found with this doctor.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
