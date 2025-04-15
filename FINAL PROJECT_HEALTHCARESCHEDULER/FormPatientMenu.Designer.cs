namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class FormPatientMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel2 = new Panel();
            btn_meeting = new Button();
            btn_appointments = new Button();
            btn_logoutpatient = new Button();
            btn_upschedpatient = new Button();
            btn_cancel = new Button();
            btn_update = new Button();
            btn_schedule = new Button();
            lblWelcome = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label3 = new Label();
            lbl_exitpatient = new Label();
            panelContainer = new Panel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(34, 77, 83);
            panel2.Controls.Add(btn_meeting);
            panel2.Controls.Add(btn_appointments);
            panel2.Controls.Add(btn_logoutpatient);
            panel2.Controls.Add(btn_upschedpatient);
            panel2.Controls.Add(btn_cancel);
            panel2.Controls.Add(btn_update);
            panel2.Controls.Add(btn_schedule);
            panel2.Controls.Add(lblWelcome);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel2.Location = new Point(0, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 631);
            panel2.TabIndex = 3;
            // 
            // btn_meeting
            // 
            btn_meeting.FlatAppearance.BorderSize = 0;
            btn_meeting.FlatStyle = FlatStyle.Flat;
            btn_meeting.ForeColor = Color.White;
            btn_meeting.Location = new Point(21, 494);
            btn_meeting.Name = "btn_meeting";
            btn_meeting.Size = new Size(208, 50);
            btn_meeting.TabIndex = 8;
            btn_meeting.Text = "ONLINE MEETING";
            btn_meeting.UseVisualStyleBackColor = true;
            btn_meeting.Click += btn_meeting_Click;
            // 
            // btn_appointments
            // 
            btn_appointments.FlatAppearance.BorderSize = 0;
            btn_appointments.FlatStyle = FlatStyle.Flat;
            btn_appointments.ForeColor = Color.White;
            btn_appointments.Location = new Point(21, 438);
            btn_appointments.Name = "btn_appointments";
            btn_appointments.Size = new Size(208, 50);
            btn_appointments.TabIndex = 7;
            btn_appointments.Text = "VIEW APPOINTMENTS";
            btn_appointments.UseVisualStyleBackColor = true;
            btn_appointments.Click += btn_appointments_Click;
            // 
            // btn_logoutpatient
            // 
            btn_logoutpatient.FlatAppearance.BorderSize = 0;
            btn_logoutpatient.FlatStyle = FlatStyle.Flat;
            btn_logoutpatient.ForeColor = Color.White;
            btn_logoutpatient.Location = new Point(21, 580);
            btn_logoutpatient.Name = "btn_logoutpatient";
            btn_logoutpatient.Size = new Size(208, 29);
            btn_logoutpatient.TabIndex = 6;
            btn_logoutpatient.Text = "LOGOUT";
            btn_logoutpatient.UseVisualStyleBackColor = true;
            btn_logoutpatient.Click += btn_logoutpatient_Click;
            // 
            // btn_upschedpatient
            // 
            btn_upschedpatient.FlatAppearance.BorderSize = 0;
            btn_upschedpatient.FlatStyle = FlatStyle.Flat;
            btn_upschedpatient.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_upschedpatient.ForeColor = Color.White;
            btn_upschedpatient.Location = new Point(21, 380);
            btn_upschedpatient.Name = "btn_upschedpatient";
            btn_upschedpatient.Size = new Size(208, 52);
            btn_upschedpatient.TabIndex = 5;
            btn_upschedpatient.Text = "VIEW UPCOMING SCHEDULE";
            btn_upschedpatient.UseVisualStyleBackColor = true;
            btn_upschedpatient.Click += btn_upschedpatient_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.FlatAppearance.BorderSize = 0;
            btn_cancel.FlatStyle = FlatStyle.Flat;
            btn_cancel.ForeColor = Color.White;
            btn_cancel.Location = new Point(21, 336);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(208, 29);
            btn_cancel.TabIndex = 4;
            btn_cancel.Text = "CANCEL APPOINTMENT";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // btn_update
            // 
            btn_update.FlatAppearance.BorderSize = 0;
            btn_update.FlatStyle = FlatStyle.Flat;
            btn_update.ForeColor = Color.White;
            btn_update.Location = new Point(21, 281);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(208, 29);
            btn_update.TabIndex = 3;
            btn_update.Text = "UPDATE APPOINTMENT";
            btn_update.UseVisualStyleBackColor = true;
            btn_update.Click += btn_update_Click;
            // 
            // btn_schedule
            // 
            btn_schedule.FlatAppearance.BorderSize = 0;
            btn_schedule.FlatStyle = FlatStyle.Flat;
            btn_schedule.ForeColor = Color.White;
            btn_schedule.Location = new Point(21, 206);
            btn_schedule.Name = "btn_schedule";
            btn_schedule.Size = new Size(208, 52);
            btn_schedule.TabIndex = 2;
            btn_schedule.Text = "SCHEDULE APPOINTMENT";
            btn_schedule.UseVisualStyleBackColor = true;
            btn_schedule.Click += btn_schedule_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(12, 156);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(179, 20);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "WELCOME, PATIENT!";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.patient;
            pictureBox1.Location = new Point(60, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(119, 110);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lbl_exitpatient);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1105, 45);
            panel1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(3, 14);
            label3.Name = "label3";
            label3.Size = new Size(212, 20);
            label3.TabIndex = 3;
            label3.Text = "HEALTHCARE SYSTEM";
            // 
            // lbl_exitpatient
            // 
            lbl_exitpatient.AutoSize = true;
            lbl_exitpatient.BackColor = Color.Red;
            lbl_exitpatient.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lbl_exitpatient.ForeColor = Color.Black;
            lbl_exitpatient.Location = new Point(1071, 9);
            lbl_exitpatient.Name = "lbl_exitpatient";
            lbl_exitpatient.Size = new Size(27, 25);
            lbl_exitpatient.TabIndex = 2;
            lbl_exitpatient.Text = "X";
            lbl_exitpatient.Click += label2_Click;
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.MistyRose;
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(250, 45);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(855, 631);
            panelContainer.TabIndex = 4;
            // 
            // FormPatientMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 676);
            Controls.Add(panelContainer);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPatientMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPatientName";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button btn_appointments;
        private Button btn_logoutpatient;
        private Button btn_upschedpatient;
        private Button btn_cancel;
        private Button btn_update;
        private Button btn_schedule;
        private Label lblWelcome;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label3;
        private Label lbl_exitpatient;
        private Panel panelContainer;
        private Button btn_meeting;
    }
}