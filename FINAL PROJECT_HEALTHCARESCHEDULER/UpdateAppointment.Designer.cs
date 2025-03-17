namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class UpdateAppointment
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
            table_UpdateAppointment = new DataGridView();
            lbl_doctor = new Label();
            lbl_datetime = new Label();
            datetime_sched = new DateTimePicker();
            btn_update = new Button();
            tbx_doctorupdate = new TextBox();
            btn_LoadSchedule = new Button();
            ((System.ComponentModel.ISupportInitialize)table_UpdateAppointment).BeginInit();
            SuspendLayout();
            // 
            // table_UpdateAppointment
            // 
            table_UpdateAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_UpdateAppointment.Location = new Point(45, 51);
            table_UpdateAppointment.Name = "table_UpdateAppointment";
            table_UpdateAppointment.RowHeadersWidth = 51;
            table_UpdateAppointment.Size = new Size(754, 393);
            table_UpdateAppointment.TabIndex = 0;
            // 
            // lbl_doctor
            // 
            lbl_doctor.AutoSize = true;
            lbl_doctor.Location = new Point(96, 480);
            lbl_doctor.Name = "lbl_doctor";
            lbl_doctor.Size = new Size(55, 20);
            lbl_doctor.TabIndex = 2;
            lbl_doctor.Text = "Doctor";
            // 
            // lbl_datetime
            // 
            lbl_datetime.AutoSize = true;
            lbl_datetime.Location = new Point(396, 485);
            lbl_datetime.Name = "lbl_datetime";
            lbl_datetime.Size = new Size(107, 20);
            lbl_datetime.TabIndex = 3;
            lbl_datetime.Text = "Date and Time";
            // 
            // datetime_sched
            // 
            datetime_sched.Location = new Point(509, 480);
            datetime_sched.Name = "datetime_sched";
            datetime_sched.Size = new Size(240, 27);
            datetime_sched.TabIndex = 7;
            // 
            // btn_update
            // 
            btn_update.BackColor = Color.LimeGreen;
            btn_update.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_update.Location = new Point(205, 549);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(147, 29);
            btn_update.TabIndex = 9;
            btn_update.Text = "UPDATE";
            btn_update.UseVisualStyleBackColor = false;
            // 
            // tbx_doctorupdate
            // 
            tbx_doctorupdate.Location = new Point(166, 480);
            tbx_doctorupdate.Name = "tbx_doctorupdate";
            tbx_doctorupdate.Size = new Size(125, 27);
            tbx_doctorupdate.TabIndex = 12;
            // 
            // btn_LoadSchedule
            // 
            btn_LoadSchedule.BackColor = Color.LimeGreen;
            btn_LoadSchedule.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_LoadSchedule.Location = new Point(405, 549);
            btn_LoadSchedule.Name = "btn_LoadSchedule";
            btn_LoadSchedule.Size = new Size(182, 29);
            btn_LoadSchedule.TabIndex = 13;
            btn_LoadSchedule.Text = "LOAD SCHEDULE";
            btn_LoadSchedule.UseVisualStyleBackColor = false;
            // 
            // UpdateAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_LoadSchedule);
            Controls.Add(tbx_doctorupdate);
            Controls.Add(btn_update);
            Controls.Add(datetime_sched);
            Controls.Add(lbl_datetime);
            Controls.Add(lbl_doctor);
            Controls.Add(table_UpdateAppointment);
            Name = "UpdateAppointment";
            Size = new Size(1105, 676);
            Load += UpdateAppointment_Load;
            ((System.ComponentModel.ISupportInitialize)table_UpdateAppointment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView table_UpdateAppointment;
        private Label lbl_doctor;
        private Label lbl_datetime;
        private DateTimePicker datetime_sched;
        private Button btn_update;
        private TextBox tbx_doctorupdate;
        private Button btn_LoadSchedule;
    }
}
