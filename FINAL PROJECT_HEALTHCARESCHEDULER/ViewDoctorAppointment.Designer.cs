namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class ViewDoctorAppointment
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
            components = new System.ComponentModel.Container();
            lbl_Appointment = new Label();
            table_ViewDoctorAppointment = new DataGridView();
            btn_loadschedforpatients = new Button();
            strip_viewappointment = new ContextMenuStrip(components);
            viewPatientProfileToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            txt_searchPatient = new TextBox();
            lblAppointmentCount = new Label();
            ((System.ComponentModel.ISupportInitialize)table_ViewDoctorAppointment).BeginInit();
            strip_viewappointment.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_Appointment
            // 
            lbl_Appointment.AutoSize = true;
            lbl_Appointment.Location = new Point(75, 505);
            lbl_Appointment.Name = "lbl_Appointment";
            lbl_Appointment.Size = new Size(237, 20);
            lbl_Appointment.TabIndex = 18;
            lbl_Appointment.Text = "YOUR ACCEPTED APPOINTMENTS!";
            // 
            // table_ViewDoctorAppointment
            // 
            table_ViewDoctorAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_ViewDoctorAppointment.Location = new Point(41, 83);
            table_ViewDoctorAppointment.Name = "table_ViewDoctorAppointment";
            table_ViewDoctorAppointment.RowHeadersWidth = 51;
            table_ViewDoctorAppointment.Size = new Size(754, 393);
            table_ViewDoctorAppointment.TabIndex = 17;
            // 
            // btn_loadschedforpatients
            // 
            btn_loadschedforpatients.BackColor = Color.SkyBlue;
            btn_loadschedforpatients.FlatAppearance.BorderSize = 0;
            btn_loadschedforpatients.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_loadschedforpatients.Location = new Point(391, 505);
            btn_loadschedforpatients.Margin = new Padding(4, 3, 4, 3);
            btn_loadschedforpatients.Name = "btn_loadschedforpatients";
            btn_loadschedforpatients.Size = new Size(197, 35);
            btn_loadschedforpatients.TabIndex = 26;
            btn_loadschedforpatients.Text = "LOAD SCHEDULE";
            btn_loadschedforpatients.UseVisualStyleBackColor = false;
            btn_loadschedforpatients.Click += btn_loadschedforpatients_Click;
            // 
            // strip_viewappointment
            // 
            strip_viewappointment.ImageScalingSize = new Size(20, 20);
            strip_viewappointment.Items.AddRange(new ToolStripItem[] { viewPatientProfileToolStripMenuItem });
            strip_viewappointment.Name = "strip_viewappointment";
            strip_viewappointment.Size = new Size(207, 28);
            strip_viewappointment.Opening += strip_viewappointment_Opening;
            // 
            // viewPatientProfileToolStripMenuItem
            // 
            viewPatientProfileToolStripMenuItem.Name = "viewPatientProfileToolStripMenuItem";
            viewPatientProfileToolStripMenuItem.Size = new Size(206, 24);
            viewPatientProfileToolStripMenuItem.Text = "View Patient Profile";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(65, 44);
            label1.Name = "label1";
            label1.Size = new Size(123, 18);
            label1.TabIndex = 29;
            label1.Text = "Search Patient:";
            // 
            // txt_searchPatient
            // 
            txt_searchPatient.Location = new Point(207, 40);
            txt_searchPatient.Multiline = true;
            txt_searchPatient.Name = "txt_searchPatient";
            txt_searchPatient.Size = new Size(177, 27);
            txt_searchPatient.TabIndex = 28;
            txt_searchPatient.TextChanged += txt_searchPatient_TextChanged;
            // 
            // lblAppointmentCount
            // 
            lblAppointmentCount.AutoSize = true;
            lblAppointmentCount.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppointmentCount.Location = new Point(462, 44);
            lblAppointmentCount.Name = "lblAppointmentCount";
            lblAppointmentCount.Size = new Size(177, 20);
            lblAppointmentCount.TabIndex = 30;
            lblAppointmentCount.Text = "Total Appointments:";
            // 
            // ViewDoctorAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ContextMenuStrip = strip_viewappointment;
            Controls.Add(lblAppointmentCount);
            Controls.Add(label1);
            Controls.Add(txt_searchPatient);
            Controls.Add(btn_loadschedforpatients);
            Controls.Add(lbl_Appointment);
            Controls.Add(table_ViewDoctorAppointment);
            Name = "ViewDoctorAppointment";
            Size = new Size(1105, 676);
            Load += ViewDoctorAppointment_Load;
            ((System.ComponentModel.ISupportInitialize)table_ViewDoctorAppointment).EndInit();
            strip_viewappointment.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Appointment;
        private DataGridView table_ViewDoctorAppointment;
        private Button btn_loadschedforpatients;
        private ContextMenuStrip strip_viewappointment;
        private ToolStripMenuItem viewPatientProfileToolStripMenuItem;
        private Label label1;
        private TextBox txt_searchPatient;
        private Label lblAppointmentCount;
    }
}
