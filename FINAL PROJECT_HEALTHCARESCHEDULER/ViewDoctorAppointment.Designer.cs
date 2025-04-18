﻿namespace FINAL_PROJECT_HEALTHCARESCHEDULER
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
            ((System.ComponentModel.ISupportInitialize)table_ViewDoctorAppointment).BeginInit();
            strip_viewappointment.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_Appointment
            // 
            lbl_Appointment.AutoSize = true;
            lbl_Appointment.Location = new Point(73, 484);
            lbl_Appointment.Name = "lbl_Appointment";
            lbl_Appointment.Size = new Size(237, 20);
            lbl_Appointment.TabIndex = 18;
            lbl_Appointment.Text = "YOUR ACCEPTED APPOINTMENTS!";
            // 
            // table_ViewDoctorAppointment
            // 
            table_ViewDoctorAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_ViewDoctorAppointment.Location = new Point(39, 62);
            table_ViewDoctorAppointment.Name = "table_ViewDoctorAppointment";
            table_ViewDoctorAppointment.RowHeadersWidth = 51;
            table_ViewDoctorAppointment.Size = new Size(754, 393);
            table_ViewDoctorAppointment.TabIndex = 17;
            // 
            // btn_loadschedforpatients
            // 
            btn_loadschedforpatients.BackColor = Color.LimeGreen;
            btn_loadschedforpatients.FlatAppearance.BorderSize = 0;
            btn_loadschedforpatients.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_loadschedforpatients.Location = new Point(389, 484);
            btn_loadschedforpatients.Margin = new Padding(4, 3, 4, 3);
            btn_loadschedforpatients.Name = "btn_loadschedforpatients";
            btn_loadschedforpatients.Size = new Size(197, 26);
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
            strip_viewappointment.Size = new Size(211, 56);
            strip_viewappointment.Opening += strip_viewappointment_Opening;
            // 
            // viewPatientProfileToolStripMenuItem
            // 
            viewPatientProfileToolStripMenuItem.Name = "viewPatientProfileToolStripMenuItem";
            viewPatientProfileToolStripMenuItem.Size = new Size(210, 24);
            viewPatientProfileToolStripMenuItem.Text = "View Patient Profile";
            // 
            // ViewDoctorAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ContextMenuStrip = strip_viewappointment;
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
    }
}
