namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class ScheduleApointment
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
            lbl_specialization = new Label();
            cbx_specialization = new ComboBox();
            lbl_doctors = new Label();
            cbx_doctor = new ComboBox();
            lbl_appdate = new Label();
            datetime_selectapp = new DateTimePicker();
            btn_confirm = new Button();
            RBTN_facetoface = new RadioButton();
            RBTN_Online = new RadioButton();
            SuspendLayout();
            // 
            // lbl_specialization
            // 
            lbl_specialization.AutoSize = true;
            lbl_specialization.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_specialization.Location = new Point(190, 262);
            lbl_specialization.Name = "lbl_specialization";
            lbl_specialization.Size = new Size(200, 18);
            lbl_specialization.TabIndex = 0;
            lbl_specialization.Text = "ENTER SPECIALIZATION";
            // 
            // cbx_specialization
            // 
            cbx_specialization.FormattingEnabled = true;
            cbx_specialization.Items.AddRange(new object[] { "CARDIOLOGY", "PEDIATRICS", "GYNECOLOGIST", "NEUROLOGY", "DERMATOLOGY", "NEPHROLOGY", "OPHTHALMOLOGY", "ORTHOPEDICS" });
            cbx_specialization.Location = new Point(396, 258);
            cbx_specialization.Name = "cbx_specialization";
            cbx_specialization.Size = new Size(151, 28);
            cbx_specialization.TabIndex = 1;
            cbx_specialization.SelectedIndexChanged += cbx_specialization_SelectedIndexChanged;
            // 
            // lbl_doctors
            // 
            lbl_doctors.AutoSize = true;
            lbl_doctors.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_doctors.Location = new Point(190, 312);
            lbl_doctors.Name = "lbl_doctors";
            lbl_doctors.Size = new Size(180, 18);
            lbl_doctors.TabIndex = 2;
            lbl_doctors.Text = "AVAILABLE DOCTORS";
            // 
            // cbx_doctor
            // 
            cbx_doctor.FormattingEnabled = true;
            cbx_doctor.Items.AddRange(new object[] { "CARDIOLOGY", "PEDIATRICS", "GYNECOLOGIST", "NEUROLOGY", "DERMATOLOGY", "NEPHROLOGY", "OHTHALMOLOGY", "ORTHOPEDICS" });
            cbx_doctor.Location = new Point(396, 312);
            cbx_doctor.Name = "cbx_doctor";
            cbx_doctor.Size = new Size(151, 28);
            cbx_doctor.TabIndex = 3;
            // 
            // lbl_appdate
            // 
            lbl_appdate.AutoSize = true;
            lbl_appdate.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_appdate.Location = new Point(190, 364);
            lbl_appdate.Name = "lbl_appdate";
            lbl_appdate.Size = new Size(243, 18);
            lbl_appdate.TabIndex = 4;
            lbl_appdate.Text = "SELECT APPOINTMENT DATE";
            // 
            // datetime_selectapp
            // 
            datetime_selectapp.Location = new Point(451, 358);
            datetime_selectapp.Name = "datetime_selectapp";
            datetime_selectapp.Size = new Size(247, 27);
            datetime_selectapp.TabIndex = 5;
            datetime_selectapp.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // btn_confirm
            // 
            btn_confirm.BackColor = Color.LimeGreen;
            btn_confirm.FlatAppearance.BorderSize = 0;
            btn_confirm.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_confirm.Location = new Point(312, 449);
            btn_confirm.Name = "btn_confirm";
            btn_confirm.Size = new Size(235, 29);
            btn_confirm.TabIndex = 6;
            btn_confirm.Text = "CONFIRM APPOINTMENT";
            btn_confirm.UseVisualStyleBackColor = false;
            btn_confirm.Click += btn_confirm_Click;
            // 
            // RBTN_facetoface
            // 
            RBTN_facetoface.AutoSize = true;
            RBTN_facetoface.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RBTN_facetoface.Location = new Point(295, 410);
            RBTN_facetoface.Name = "RBTN_facetoface";
            RBTN_facetoface.Size = new Size(128, 22);
            RBTN_facetoface.TabIndex = 7;
            RBTN_facetoface.TabStop = true;
            RBTN_facetoface.Text = "Face to Face";
            RBTN_facetoface.UseVisualStyleBackColor = true;
            // 
            // RBTN_Online
            // 
            RBTN_Online.AutoSize = true;
            RBTN_Online.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RBTN_Online.Location = new Point(472, 410);
            RBTN_Online.Name = "RBTN_Online";
            RBTN_Online.Size = new Size(77, 22);
            RBTN_Online.TabIndex = 8;
            RBTN_Online.TabStop = true;
            RBTN_Online.Text = "Online";
            RBTN_Online.UseVisualStyleBackColor = true;
            // 
            // ScheduleApointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(RBTN_Online);
            Controls.Add(RBTN_facetoface);
            Controls.Add(btn_confirm);
            Controls.Add(datetime_selectapp);
            Controls.Add(lbl_appdate);
            Controls.Add(cbx_doctor);
            Controls.Add(lbl_doctors);
            Controls.Add(cbx_specialization);
            Controls.Add(lbl_specialization);
            Name = "ScheduleApointment";
            Size = new Size(1105, 676);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_specialization;
        private ComboBox cbx_specialization;
        private Label lbl_doctors;
        private ComboBox cbx_doctor;
        private Label lbl_appdate;
        private DateTimePicker datetime_selectapp;
        private Button btn_confirm;
        private RadioButton RBTN_facetoface;
        private RadioButton RBTN_Online;
    }
}
