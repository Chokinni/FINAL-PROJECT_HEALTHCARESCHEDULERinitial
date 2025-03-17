namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class CancelPatientAppointment
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
            tbx_doctorupdate = new TextBox();
            btn_cancelpatientAppointment = new Button();
            datetime_cancelPatientAppointment = new DateTimePicker();
            lbl_datetime = new Label();
            lbl_cancelpatient = new Label();
            table_CancelpatientAppointment = new DataGridView();
            btn_loadschedforcancel = new Button();
            ((System.ComponentModel.ISupportInitialize)table_CancelpatientAppointment).BeginInit();
            SuspendLayout();
            // 
            // tbx_doctorupdate
            // 
            tbx_doctorupdate.Location = new Point(154, 462);
            tbx_doctorupdate.Margin = new Padding(4, 3, 4, 3);
            tbx_doctorupdate.Name = "tbx_doctorupdate";
            tbx_doctorupdate.Size = new Size(155, 24);
            tbx_doctorupdate.TabIndex = 24;
            // 
            // btn_cancelpatientAppointment
            // 
            btn_cancelpatientAppointment.BackColor = Color.LimeGreen;
            btn_cancelpatientAppointment.FlatAppearance.BorderSize = 0;
            btn_cancelpatientAppointment.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cancelpatientAppointment.Location = new Point(210, 528);
            btn_cancelpatientAppointment.Margin = new Padding(4, 3, 4, 3);
            btn_cancelpatientAppointment.Name = "btn_cancelpatientAppointment";
            btn_cancelpatientAppointment.Size = new Size(154, 26);
            btn_cancelpatientAppointment.TabIndex = 23;
            btn_cancelpatientAppointment.Text = "CANCEL";
            btn_cancelpatientAppointment.UseVisualStyleBackColor = false;
            // 
            // datetime_cancelPatientAppointment
            // 
            datetime_cancelPatientAppointment.Location = new Point(487, 461);
            datetime_cancelPatientAppointment.Margin = new Padding(4, 3, 4, 3);
            datetime_cancelPatientAppointment.Name = "datetime_cancelPatientAppointment";
            datetime_cancelPatientAppointment.Size = new Size(286, 24);
            datetime_cancelPatientAppointment.TabIndex = 22;
            // 
            // lbl_datetime
            // 
            lbl_datetime.AutoSize = true;
            lbl_datetime.Location = new Point(346, 465);
            lbl_datetime.Margin = new Padding(4, 0, 4, 0);
            lbl_datetime.Name = "lbl_datetime";
            lbl_datetime.Size = new Size(117, 18);
            lbl_datetime.TabIndex = 21;
            lbl_datetime.Text = "Date and Time";
            // 
            // lbl_cancelpatient
            // 
            lbl_cancelpatient.AutoSize = true;
            lbl_cancelpatient.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_cancelpatient.Location = new Point(67, 462);
            lbl_cancelpatient.Margin = new Padding(4, 0, 4, 0);
            lbl_cancelpatient.Name = "lbl_cancelpatient";
            lbl_cancelpatient.Size = new Size(60, 18);
            lbl_cancelpatient.TabIndex = 20;
            lbl_cancelpatient.Text = "Patient";
            // 
            // table_CancelpatientAppointment
            // 
            table_CancelpatientAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_CancelpatientAppointment.Location = new Point(38, 50);
            table_CancelpatientAppointment.Margin = new Padding(4, 3, 4, 3);
            table_CancelpatientAppointment.Name = "table_CancelpatientAppointment";
            table_CancelpatientAppointment.RowHeadersWidth = 51;
            table_CancelpatientAppointment.Size = new Size(754, 393);
            table_CancelpatientAppointment.TabIndex = 19;
            // 
            // btn_loadschedforcancel
            // 
            btn_loadschedforcancel.BackColor = Color.LimeGreen;
            btn_loadschedforcancel.FlatAppearance.BorderSize = 0;
            btn_loadschedforcancel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_loadschedforcancel.Location = new Point(399, 528);
            btn_loadschedforcancel.Margin = new Padding(4, 3, 4, 3);
            btn_loadschedforcancel.Name = "btn_loadschedforcancel";
            btn_loadschedforcancel.Size = new Size(197, 26);
            btn_loadschedforcancel.TabIndex = 25;
            btn_loadschedforcancel.Text = "LOAD SCHEDULE";
            btn_loadschedforcancel.UseVisualStyleBackColor = false;
            // 
            // CancelPatientAppointment
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_loadschedforcancel);
            Controls.Add(tbx_doctorupdate);
            Controls.Add(btn_cancelpatientAppointment);
            Controls.Add(datetime_cancelPatientAppointment);
            Controls.Add(lbl_datetime);
            Controls.Add(lbl_cancelpatient);
            Controls.Add(table_CancelpatientAppointment);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CancelPatientAppointment";
            Size = new Size(1105, 676);
            ((System.ComponentModel.ISupportInitialize)table_CancelpatientAppointment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbx_doctorupdate;
        private Button btn_cancelpatientAppointment;
        private DateTimePicker datetime_cancelPatientAppointment;
        private Label lbl_datetime;
        private Label lbl_cancelpatient;
        private DataGridView table_CancelpatientAppointment;
        private Button btn_loadschedforcancel;
    }
}
