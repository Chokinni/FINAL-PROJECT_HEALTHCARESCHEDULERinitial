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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDoctorMenu));
            panel1 = new Panel();
            label3 = new Label();
            lbl_exitdoctor = new Label();
            panel2 = new Panel();
            picture_home = new PictureBox();
            btn_logoutDoc = new Button();
            btn_createmeeting = new Button();
            btn_upcomingsched = new Button();
            btn_view = new Button();
            btn_cancel = new Button();
            btn_accept = new Button();
            lblWelcome = new Label();
            pictureBox1 = new PictureBox();
            panelContainerDoctor = new Panel();
            picture_message = new PictureBox();
            picture_editprofile = new PictureBox();
            lbl_welcome = new Label();
            lbl_year = new Label();
            lbl_month = new Label();
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            btnLoadChart = new Button();
            cmbYear = new ComboBox();
            cmbMonth = new ComboBox();
            redDot = new PictureBox();
            picNotificationdoc = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture_home).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelContainerDoctor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture_message).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_editprofile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)redDot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picNotificationdoc).BeginInit();
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
            panel2.Controls.Add(picture_home);
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
            // picture_home
            // 
            picture_home.BackgroundImage = Properties.Resources.home;
            picture_home.BackgroundImageLayout = ImageLayout.Stretch;
            picture_home.Location = new Point(100, 581);
            picture_home.Name = "picture_home";
            picture_home.Size = new Size(45, 36);
            picture_home.TabIndex = 9;
            picture_home.TabStop = false;
            picture_home.Click += picture_home_Click;
            // 
            // btn_logoutDoc
            // 
            btn_logoutDoc.FlatAppearance.BorderSize = 0;
            btn_logoutDoc.FlatStyle = FlatStyle.Flat;
            btn_logoutDoc.ForeColor = Color.White;
            btn_logoutDoc.Location = new Point(21, 514);
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
            panelContainerDoctor.Controls.Add(picture_message);
            panelContainerDoctor.Controls.Add(picture_editprofile);
            panelContainerDoctor.Controls.Add(lbl_welcome);
            panelContainerDoctor.Controls.Add(lbl_year);
            panelContainerDoctor.Controls.Add(lbl_month);
            panelContainerDoctor.Controls.Add(plotView1);
            panelContainerDoctor.Controls.Add(btnLoadChart);
            panelContainerDoctor.Controls.Add(cmbYear);
            panelContainerDoctor.Controls.Add(cmbMonth);
            panelContainerDoctor.Controls.Add(redDot);
            panelContainerDoctor.Controls.Add(picNotificationdoc);
            panelContainerDoctor.Dock = DockStyle.Fill;
            panelContainerDoctor.Location = new Point(250, 45);
            panelContainerDoctor.Name = "panelContainerDoctor";
            panelContainerDoctor.Size = new Size(855, 631);
            panelContainerDoctor.TabIndex = 5;
            panelContainerDoctor.Paint += panelContainerDoctor_Paint;
            // 
            // picture_message
            // 
            picture_message.BackgroundImage = Properties.Resources._4202011_email_gmail_mail_logo_social_icon;
            picture_message.BackgroundImageLayout = ImageLayout.Stretch;
            picture_message.Location = new Point(643, 13);
            picture_message.Name = "picture_message";
            picture_message.Size = new Size(39, 36);
            picture_message.TabIndex = 15;
            picture_message.TabStop = false;
            picture_message.Click += picture_message_Click;
            // 
            // picture_editprofile
            // 
            picture_editprofile.BackgroundImage = Properties.Resources.pen;
            picture_editprofile.BackgroundImageLayout = ImageLayout.Stretch;
            picture_editprofile.Location = new Point(703, 13);
            picture_editprofile.Name = "picture_editprofile";
            picture_editprofile.Size = new Size(32, 36);
            picture_editprofile.TabIndex = 11;
            picture_editprofile.TabStop = false;
            picture_editprofile.Click += picture_editprofile_Click;
            // 
            // lbl_welcome
            // 
            lbl_welcome.AutoSize = true;
            lbl_welcome.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_welcome.Location = new Point(6, 6);
            lbl_welcome.Name = "lbl_welcome";
            lbl_welcome.Size = new Size(142, 18);
            lbl_welcome.TabIndex = 14;
            lbl_welcome.Text = "VIEW ANALYTICS";
            // 
            // lbl_year
            // 
            lbl_year.AutoSize = true;
            lbl_year.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_year.ForeColor = Color.Teal;
            lbl_year.Location = new Point(21, 112);
            lbl_year.Name = "lbl_year";
            lbl_year.Size = new Size(104, 20);
            lbl_year.TabIndex = 13;
            lbl_year.Text = "Enter Year:";
            // 
            // lbl_month
            // 
            lbl_month.AutoSize = true;
            lbl_month.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_month.ForeColor = Color.Teal;
            lbl_month.Location = new Point(21, 58);
            lbl_month.Name = "lbl_month";
            lbl_month.Size = new Size(117, 20);
            lbl_month.TabIndex = 12;
            lbl_month.Text = "Enter Month:";
            // 
            // plotView1
            // 
            plotView1.Location = new Point(21, 158);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(809, 334);
            plotView1.TabIndex = 11;
            plotView1.Text = "plotView1";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            plotView1.Click += plotView1_Click;
            // 
            // btnLoadChart
            // 
            btnLoadChart.BackColor = Color.Gold;
            btnLoadChart.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoadChart.ForeColor = Color.Crimson;
            btnLoadChart.Location = new Point(38, 535);
            btnLoadChart.Name = "btnLoadChart";
            btnLoadChart.Size = new Size(131, 29);
            btnLoadChart.TabIndex = 10;
            btnLoadChart.Text = "View Graph";
            btnLoadChart.UseVisualStyleBackColor = false;
            btnLoadChart.Click += btnLoadChart_Click;
            // 
            // cmbYear
            // 
            cmbYear.FormattingEnabled = true;
            cmbYear.Location = new Point(150, 109);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(151, 28);
            cmbYear.TabIndex = 9;
            // 
            // cmbMonth
            // 
            cmbMonth.FormattingEnabled = true;
            cmbMonth.Location = new Point(150, 52);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.Size = new Size(151, 28);
            cmbMonth.TabIndex = 8;
            // 
            // redDot
            // 
            redDot.BackgroundImage = (Image)resources.GetObject("redDot.BackgroundImage");
            redDot.BackgroundImageLayout = ImageLayout.Stretch;
            redDot.Location = new Point(792, 6);
            redDot.Name = "redDot";
            redDot.Size = new Size(26, 30);
            redDot.TabIndex = 7;
            redDot.TabStop = false;
            // 
            // picNotificationdoc
            // 
            picNotificationdoc.BackgroundImage = Properties.Resources.bell;
            picNotificationdoc.BackgroundImageLayout = ImageLayout.Stretch;
            picNotificationdoc.Location = new Point(755, 6);
            picNotificationdoc.Name = "picNotificationdoc";
            picNotificationdoc.Size = new Size(44, 43);
            picNotificationdoc.TabIndex = 6;
            picNotificationdoc.TabStop = false;
            picNotificationdoc.Click += picNotificationdoc_Click;
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
            ((System.ComponentModel.ISupportInitialize)picture_home).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelContainerDoctor.ResumeLayout(false);
            panelContainerDoctor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picture_message).EndInit();
            ((System.ComponentModel.ISupportInitialize)picture_editprofile).EndInit();
            ((System.ComponentModel.ISupportInitialize)redDot).EndInit();
            ((System.ComponentModel.ISupportInitialize)picNotificationdoc).EndInit();
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
        private PictureBox picNotificationdoc;
        private PictureBox redDot;
        private ComboBox cmbYear;
        private ComboBox cmbMonth;
        private Button btnLoadChart;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private PictureBox picture_home;
        private Label lbl_year;
        private Label lbl_month;
        private Label lbl_welcome;
        private PictureBox picture_editprofile;
        private PictureBox picture_message;
    }
}