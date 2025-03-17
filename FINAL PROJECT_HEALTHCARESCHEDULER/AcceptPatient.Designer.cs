namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class AcceptPatient
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
            btn_confirm = new Button();
            table_AcceptAppointment = new DataGridView();
            lbl_patientname = new Label();
            tbx_patientname = new TextBox();
            datetime_Doctor = new DateTimePicker();
            lbk_datetime = new Label();
            btn_loadscheddoc = new Button();
            ((System.ComponentModel.ISupportInitialize)table_AcceptAppointment).BeginInit();
            SuspendLayout();
            // 
            // btn_confirm
            // 
            btn_confirm.BackColor = Color.LimeGreen;
            btn_confirm.FlatAppearance.BorderSize = 0;
            btn_confirm.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_confirm.Location = new Point(178, 539);
            btn_confirm.Name = "btn_confirm";
            btn_confirm.Size = new Size(236, 29);
            btn_confirm.TabIndex = 20;
            btn_confirm.Text = "CONFIRM APPOINTMENT";
            btn_confirm.UseVisualStyleBackColor = false;
            // 
            // table_AcceptAppointment
            // 
            table_AcceptAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_AcceptAppointment.Location = new Point(55, 58);
            table_AcceptAppointment.Name = "table_AcceptAppointment";
            table_AcceptAppointment.RowHeadersWidth = 51;
            table_AcceptAppointment.Size = new Size(754, 393);
            table_AcceptAppointment.TabIndex = 19;
            // 
            // lbl_patientname
            // 
            lbl_patientname.AutoSize = true;
            lbl_patientname.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_patientname.Location = new Point(70, 476);
            lbl_patientname.Name = "lbl_patientname";
            lbl_patientname.Size = new Size(81, 18);
            lbl_patientname.TabIndex = 21;
            lbl_patientname.Text = "PATIENT ";
            // 
            // tbx_patientname
            // 
            tbx_patientname.Location = new Point(157, 472);
            tbx_patientname.Name = "tbx_patientname";
            tbx_patientname.Size = new Size(125, 27);
            tbx_patientname.TabIndex = 22;
            // 
            // datetime_Doctor
            // 
            datetime_Doctor.Location = new Point(558, 475);
            datetime_Doctor.Name = "datetime_Doctor";
            datetime_Doctor.Size = new Size(247, 27);
            datetime_Doctor.TabIndex = 24;
            // 
            // lbk_datetime
            // 
            lbk_datetime.AutoSize = true;
            lbk_datetime.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbk_datetime.Location = new Point(309, 481);
            lbk_datetime.Name = "lbk_datetime";
            lbk_datetime.Size = new Size(243, 18);
            lbk_datetime.TabIndex = 23;
            lbk_datetime.Text = "SELECT APPOINTMENT DATE";
            // 
            // btn_loadscheddoc
            // 
            btn_loadscheddoc.BackColor = Color.LimeGreen;
            btn_loadscheddoc.FlatAppearance.BorderSize = 0;
            btn_loadscheddoc.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_loadscheddoc.Location = new Point(434, 539);
            btn_loadscheddoc.Name = "btn_loadscheddoc";
            btn_loadscheddoc.Size = new Size(236, 29);
            btn_loadscheddoc.TabIndex = 25;
            btn_loadscheddoc.Text = "LOAD SCHEDULE";
            btn_loadscheddoc.UseVisualStyleBackColor = false;
            // 
            // AcceptPatient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_loadscheddoc);
            Controls.Add(datetime_Doctor);
            Controls.Add(lbk_datetime);
            Controls.Add(tbx_patientname);
            Controls.Add(lbl_patientname);
            Controls.Add(btn_confirm);
            Controls.Add(table_AcceptAppointment);
            Name = "AcceptPatient";
            Size = new Size(1105, 676);
            ((System.ComponentModel.ISupportInitialize)table_AcceptAppointment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_confirm;
        private DataGridView table_AcceptAppointment;
        private Label lbl_patientname;
        private TextBox tbx_patientname;
        private DateTimePicker datetime_Doctor;
        private Label lbk_datetime;
        private Button btn_loadscheddoc;
    }
}
