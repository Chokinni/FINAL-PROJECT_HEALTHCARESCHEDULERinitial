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
using NAudio.Wave;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class UpcomingSchedule : BaseClass

    {
        
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private readonly string soundFilePath = @"C:\Users\Lenovo - i5 13th Gen\Downloads\iphone.mp3";
        public UpcomingSchedule(string firstName,string lastName)
        {
            InitializeComponent();
            loggedInFirstName = firstName;
            loggedInLastName = lastName;
        }

        private void btn_loadUpcoming_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection con = GetConnection())
                {
                    con.Open();

                    string fullPatientName = $"{loggedInFirstName} {loggedInLastName}";
                    DateTime now = DateTime.Now;
                    DateTime threeHoursLater = now.AddHours(3);

                    // Query for patient's upcoming appointments
                    string query = @"SELECT 
                                    Doctor,
                                    Specialization,
                                    AppointmentDate,
                                    Status,
                                    AppointmentType
                                FROM Patientsschedule 
                                WHERE Patient = @PatientName
                                AND Status = 'Accepted'
                                AND AppointmentDate BETWEEN @Now AND @ThreeHoursLater
                                ORDER BY AppointmentDate";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@PatientName", fullPatientName);
                        cmd.Parameters.AddWithValue("@Now", now.ToString("yyyy/MM/dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@ThreeHoursLater", threeHoursLater.ToString("yyyy/MM/dd HH:mm:ss"));

                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind to DataGridView
                        table_UpcomingSched.DataSource = dt;
                        if (table_UpcomingSched.Columns.Contains("DoctorNotification"))
                            table_UpcomingSched.Columns["DoctorNotification"].Visible = false;

                        if (table_UpcomingSched.Columns.Contains("IsUpdated"))
                            table_UpcomingSched.Columns["IsUpdated"].Visible = false;
                        var dgv = table_UpcomingSched;

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

                        if (dt.Rows.Count > 0)
                        {
                            // Format columns
                            table_UpcomingSched.Columns["AppointmentDate"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
                            table_UpcomingSched.Columns["Doctor"].HeaderText = "Doctor";
                            table_UpcomingSched.Columns["Specialization"].HeaderText = "Specialty";
                            table_UpcomingSched.Columns["AppointmentDate"].HeaderText = "Appointment Time";
                            table_UpcomingSched.Columns["Status"].HeaderText = "Status";
                            table_UpcomingSched.Columns["AppointmentType"].HeaderText = "Appointment Type";

                            // Auto-size columns
                            table_UpcomingSched.AutoResizeColumns();
                            table_UpcomingSched.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                            PlayAlertSound();
                            MessageBox.Show($"You have {dt.Rows.Count} upcoming appointments in the next 3 hours!",
                                          "Upcoming Appointments",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No upcoming appointments in the next 3 hours.",
                                          "Information",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                        }
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


        private void PlayAlertSound()
        {
            try
            {
                
                // Clean up previous playback
                outputDevice?.Stop();
                outputDevice?.Dispose();
                audioFile?.Dispose();

                // Initialize new playback
                audioFile = new AudioFileReader(soundFilePath);
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not play alert sound: {ex.Message}",
                              "Audio Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
            }
        }
        public void StopAlertSound()
        {
            try
            {
                
                outputDevice?.Stop();
                outputDevice?.Dispose();
                outputDevice = null;

                audioFile?.Dispose();
                audioFile = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error stopping sound: {ex.Message}");
            }
        }
       


    }
}
