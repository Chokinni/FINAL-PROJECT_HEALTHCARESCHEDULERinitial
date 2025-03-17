using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class ScheduleApointment : UserControl
    {
        public ScheduleApointment()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            string selectedDateTime = datetime_selectapp.Value.ToString("MM/dd/yyyy hh:mm tt");

            datetime_selectapp.Format = DateTimePickerFormat.Custom;
            datetime_selectapp.CustomFormat = "MM/dd/yyyy hh:mm tt"; // Date + Time (12-hour format)
            datetime_selectapp.ShowUpDown = true; // Removes dropdown calendar
        }
    }
}
