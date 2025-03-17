namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class FormDoctorMenu
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
            panel1 = new Panel();
            label3 = new Label();
            lbl_exitdoctor = new Label();
            panel2 = new Panel();
            btn_logoutDoc = new Button();
            btn_createmeeting = new Button();
            btn_upcomingsched = new Button();
            btn_view = new Button();
            btn_cancel = new Button();
            btn_accept = new Button();
            lblWelcome = new Label();
            pictureBox1 = new PictureBox();
            panelContainerDoctor = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lbl_exitdoctor);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1105, 45);
            panel1.TabIndex = 0;
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
            // lbl_exitdoctor
            // 
            lbl_exitdoctor.AutoSize = true;
            lbl_exitdoctor.BackColor = Color.Red;
            lbl_exitdoctor.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lbl_exitdoctor.ForeColor = Color.Black;
            lbl_exitdoctor.Location = new Point(1071, 9);
            lbl_exitdoctor.Name = "lbl_exitdoctor";
            lbl_exitdoctor.Size = new Size(27, 25);
            lbl_exitdoctor.TabIndex = 2;
            lbl_exitdoctor.Text = "X";
            lbl_exitdoctor.Click += label2_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(34, 77, 83);
            panel2.Controls.Add(btn_logoutDoc);
            panel2.Controls.Add(btn_createmeeting);
            panel2.Controls.Add(btn_upcomingsched);
            panel2.Controls.Add(btn_view);
            panel2.Controls.Add(btn_cancel);
            panel2.Controls.Add(btn_accept);
            panel2.Controls.Add(lblWelcome);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel2.Location = new Point(0, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 631);
            panel2.TabIndex = 1;
            // 
            // btn_logoutDoc
            // 
            btn_logoutDoc.FlatAppearance.BorderSize = 0;
            btn_logoutDoc.FlatStyle = FlatStyle.Flat;
            btn_logoutDoc.ForeColor = Color.White;
            btn_logoutDoc.Location = new Point(21, 543);
            btn_logoutDoc.Name = "btn_logoutDoc";
            btn_logoutDoc.Size = new Size(208, 50);
            btn_logoutDoc.TabIndex = 8;
            btn_logoutDoc.Text = "LOGOUT";
            btn_logoutDoc.UseVisualStyleBackColor = true;
            btn_logoutDoc.Click += btn_logoutDoc_Click;
            // 
            // btn_createmeeting
            // 
            btn_createmeeting.FlatAppearance.BorderSize = 0;
            btn_createmeeting.FlatStyle = FlatStyle.Flat;
            btn_createmeeting.ForeColor = Color.White;
            btn_createmeeting.Location = new Point(21, 469);
            btn_createmeeting.Name = "btn_createmeeting";
            btn_createmeeting.Size = new Size(208, 50);
            btn_createmeeting.TabIndex = 7;
            btn_createmeeting.Text = "CREATE MEETING";
            btn_createmeeting.UseVisualStyleBackColor = true;
            btn_createmeeting.Click += btn_createmeeting_Click;
            // 
            // btn_upcomingsched
            // 
            btn_upcomingsched.FlatAppearance.BorderSize = 0;
            btn_upcomingsched.FlatStyle = FlatStyle.Flat;
            btn_upcomingsched.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_upcomingsched.ForeColor = Color.White;
            btn_upcomingsched.Location = new Point(21, 402);
            btn_upcomingsched.Name = "btn_upcomingsched";
            btn_upcomingsched.Size = new Size(208, 52);
            btn_upcomingsched.TabIndex = 5;
            btn_upcomingsched.Text = "VIEW UPCOMING SCHEDULE";
            btn_upcomingsched.UseVisualStyleBackColor = true;
            btn_upcomingsched.Click += button4_Click;
            // 
            // btn_view
            // 
            btn_view.FlatAppearance.BorderSize = 0;
            btn_view.FlatStyle = FlatStyle.Flat;
            btn_view.ForeColor = Color.White;
            btn_view.Location = new Point(21, 352);
            btn_view.Name = "btn_view";
            btn_view.Size = new Size(208, 29);
            btn_view.TabIndex = 4;
            btn_view.Text = "VIEW APPOINTMENT";
            btn_view.UseVisualStyleBackColor = true;
            btn_view.Click += btn_view_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.FlatAppearance.BorderSize = 0;
            btn_cancel.FlatStyle = FlatStyle.Flat;
            btn_cancel.ForeColor = Color.White;
            btn_cancel.Location = new Point(21, 293);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(208, 29);
            btn_cancel.TabIndex = 3;
            btn_cancel.Text = "CANCEL APPOINTMENT";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // btn_accept
            // 
            btn_accept.FlatAppearance.BorderSize = 0;
            btn_accept.FlatStyle = FlatStyle.Flat;
            btn_accept.ForeColor = Color.White;
            btn_accept.Location = new Point(21, 234);
            btn_accept.Name = "btn_accept";
            btn_accept.Size = new Size(208, 29);
            btn_accept.TabIndex = 2;
            btn_accept.Text = "ACCEPT APPOINTMENT";
            btn_accept.UseVisualStyleBackColor = true;
            btn_accept.Click += btn_accept_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(21, 158);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(183, 20);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "WELCOME, DOCTOR!";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.doctor3;
            pictureBox1.Location = new Point(60, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(119, 110);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelContainerDoctor
            // 
            panelContainerDoctor.BackColor = Color.MistyRose;
            panelContainerDoctor.Dock = DockStyle.Fill;
            panelContainerDoctor.Location = new Point(250, 45);
            panelContainerDoctor.Name = "panelContainerDoctor";
            panelContainerDoctor.Size = new Size(855, 631);
            panelContainerDoctor.TabIndex = 5;
            // 
            // FormDoctorMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 676);
            Controls.Add(panelContainerDoctor);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDoctorMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormDoctorMenu";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label lbl_exitdoctor;
        private Label lblWelcome;
        private PictureBox pictureBox1;
        private Label label3;
        private Button btn_accept;
        private Button btn_createmeeting;
        private Button btn_upcomingsched;
        private Button btn_view;
        private Button btn_cancel;
        private Panel panelContainerDoctor;
        private Button btn_logoutDoc;
    }
}