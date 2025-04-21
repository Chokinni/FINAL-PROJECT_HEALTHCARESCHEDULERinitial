namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class ViewDoctorUpcomingSchedule
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_refreshDoct = new Button();
            lbl_noAppointmentDoct = new Label();
            table_DoctorUpcomingSched = new DataGridView();
            btn_loadschedupcoming = new Button();
            ((System.ComponentModel.ISupportInitialize)table_DoctorUpcomingSched).BeginInit();
            SuspendLayout();
            // 
            // btn_refreshDoct
            // 
            btn_refreshDoct.BackColor = Color.LimeGreen;
            btn_refreshDoct.FlatAppearance.BorderSize = 0;
            btn_refreshDoct.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_refreshDoct.Location = new Point(372, 374);
            btn_refreshDoct.Name = "btn_refreshDoct";
            btn_refreshDoct.Size = new Size(135, 29);
            btn_refreshDoct.TabIndex = 21;
            btn_refreshDoct.Text = "REFRESH";
            btn_refreshDoct.UseVisualStyleBackColor = false;
            btn_refreshDoct.Click += btn_refreshDoct_Click;
            // 
            // lbl_noAppointmentDoct
            // 
            lbl_noAppointmentDoct.AutoSize = true;
            lbl_noAppointmentDoct.Location = new Point(102, 383);
            lbl_noAppointmentDoct.Name = "lbl_noAppointmentDoct";
            lbl_noAppointmentDoct.Size = new Size(228, 20);
            lbl_noAppointmentDoct.TabIndex = 20;
            lbl_noAppointmentDoct.Text = "NO APPOINTMENTS FOR TODAY!";
            // 
            // table_DoctorUpcomingSched
            // 
            table_DoctorUpcomingSched.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_DoctorUpcomingSched.Location = new Point(52, 106);
            table_DoctorUpcomingSched.Name = "table_DoctorUpcomingSched";
            table_DoctorUpcomingSched.RowHeadersWidth = 51;
            table_DoctorUpcomingSched.Size = new Size(679, 237);
            table_DoctorUpcomingSched.TabIndex = 19;
            // 
            // btn_loadschedupcoming
            // 
            btn_loadschedupcoming.BackColor = Color.SkyBlue;
            btn_loadschedupcoming.FlatAppearance.BorderSize = 0;
            btn_loadschedupcoming.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_loadschedupcoming.Location = new Point(524, 374);
            btn_loadschedupcoming.Name = "btn_loadschedupcoming";
            btn_loadschedupcoming.Size = new Size(174, 38);
            btn_loadschedupcoming.TabIndex = 22;
            btn_loadschedupcoming.Text = "LOAD SCHEDULE";
            btn_loadschedupcoming.UseVisualStyleBackColor = false;
            btn_loadschedupcoming.Click += btn_loadschedupcoming_Click;
            // 
            // ViewDoctorUpcomingSchedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_loadschedupcoming);
            Controls.Add(btn_refreshDoct);
            Controls.Add(lbl_noAppointmentDoct);
            Controls.Add(table_DoctorUpcomingSched);
            Name = "ViewDoctorUpcomingSchedule";
            Size = new Size(1105, 676);
            ((System.ComponentModel.ISupportInitialize)table_DoctorUpcomingSched).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_refreshDoct;
        private Label lbl_noAppointmentDoct;
        private DataGridView table_DoctorUpcomingSched;
        private Button btn_loadschedupcoming;
    }
}
