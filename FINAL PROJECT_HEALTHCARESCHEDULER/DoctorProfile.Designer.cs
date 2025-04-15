namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class DoctorProfile
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
            picture_display = new PictureBox();
            lbl_name = new Label();
            lbl_phone = new Label();
            lbl_email = new Label();
            panel1 = new Panel();
            lbl_socials = new Label();
            lbl_medicalschool = new Label();
            lbl_homeadd = new Label();
            lbl_certified = new Label();
            lbl_experience = new Label();
            lbl_medicallicense = new Label();
            lbl_exitdoctor = new Label();
            lbl_specialty = new Label();
            lbl_info = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)picture_display).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // picture_display
            // 
            picture_display.Location = new Point(22, 26);
            picture_display.Name = "picture_display";
            picture_display.Size = new Size(241, 224);
            picture_display.TabIndex = 0;
            picture_display.TabStop = false;
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.BackColor = Color.Transparent;
            lbl_name.Location = new Point(291, 46);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(32, 20);
            lbl_name.TabIndex = 1;
            lbl_name.Text = "Dr. ";
            // 
            // lbl_phone
            // 
            lbl_phone.AutoSize = true;
            lbl_phone.BackColor = Color.Transparent;
            lbl_phone.Location = new Point(291, 158);
            lbl_phone.Name = "lbl_phone";
            lbl_phone.Size = new Size(53, 20);
            lbl_phone.TabIndex = 3;
            lbl_phone.Text = "Phone:";
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.BackColor = Color.Transparent;
            lbl_email.Location = new Point(291, 213);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(49, 20);
            lbl_email.TabIndex = 4;
            lbl_email.Text = "Email:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 211, 172);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lbl_socials);
            panel1.Controls.Add(lbl_medicalschool);
            panel1.Controls.Add(lbl_homeadd);
            panel1.Controls.Add(lbl_certified);
            panel1.Controls.Add(lbl_experience);
            panel1.Controls.Add(lbl_medicallicense);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 364);
            panel1.Name = "panel1";
            panel1.Size = new Size(1012, 310);
            panel1.TabIndex = 5;
            // 
            // lbl_socials
            // 
            lbl_socials.AutoSize = true;
            lbl_socials.BackColor = Color.Transparent;
            lbl_socials.Location = new Point(540, 209);
            lbl_socials.Name = "lbl_socials";
            lbl_socials.Size = new Size(98, 20);
            lbl_socials.TabIndex = 10;
            lbl_socials.Text = "Social Media:";
            // 
            // lbl_medicalschool
            // 
            lbl_medicalschool.AutoSize = true;
            lbl_medicalschool.BackColor = Color.Transparent;
            lbl_medicalschool.Location = new Point(540, 142);
            lbl_medicalschool.Name = "lbl_medicalschool";
            lbl_medicalschool.Size = new Size(114, 20);
            lbl_medicalschool.TabIndex = 9;
            lbl_medicalschool.Text = "Medical School:";
            // 
            // lbl_homeadd
            // 
            lbl_homeadd.AutoSize = true;
            lbl_homeadd.BackColor = Color.Transparent;
            lbl_homeadd.Location = new Point(540, 78);
            lbl_homeadd.Name = "lbl_homeadd";
            lbl_homeadd.Size = new Size(110, 20);
            lbl_homeadd.TabIndex = 8;
            lbl_homeadd.Text = "Home Address:";
            // 
            // lbl_certified
            // 
            lbl_certified.AutoSize = true;
            lbl_certified.BackColor = Color.Transparent;
            lbl_certified.Location = new Point(36, 209);
            lbl_certified.Name = "lbl_certified";
            lbl_certified.Size = new Size(113, 20);
            lbl_certified.TabIndex = 7;
            lbl_certified.Text = "Board Certified:";
            // 
            // lbl_experience
            // 
            lbl_experience.AutoSize = true;
            lbl_experience.BackColor = Color.Transparent;
            lbl_experience.Location = new Point(36, 142);
            lbl_experience.Name = "lbl_experience";
            lbl_experience.Size = new Size(140, 20);
            lbl_experience.TabIndex = 6;
            lbl_experience.Text = "Years of Experience:";
            // 
            // lbl_medicallicense
            // 
            lbl_medicallicense.AutoSize = true;
            lbl_medicallicense.BackColor = Color.Transparent;
            lbl_medicallicense.Location = new Point(36, 78);
            lbl_medicallicense.Name = "lbl_medicallicense";
            lbl_medicallicense.Size = new Size(175, 20);
            lbl_medicallicense.TabIndex = 5;
            lbl_medicallicense.Text = "Medical License Number:";
            // 
            // lbl_exitdoctor
            // 
            lbl_exitdoctor.AutoSize = true;
            lbl_exitdoctor.BackColor = Color.Red;
            lbl_exitdoctor.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lbl_exitdoctor.ForeColor = Color.Black;
            lbl_exitdoctor.Location = new Point(985, -1);
            lbl_exitdoctor.Name = "lbl_exitdoctor";
            lbl_exitdoctor.Size = new Size(27, 25);
            lbl_exitdoctor.TabIndex = 6;
            lbl_exitdoctor.Text = "X";
            lbl_exitdoctor.Click += lbl_exitdoctor_Click;
            // 
            // lbl_specialty
            // 
            lbl_specialty.AutoSize = true;
            lbl_specialty.BackColor = Color.Transparent;
            lbl_specialty.Location = new Point(291, 97);
            lbl_specialty.Name = "lbl_specialty";
            lbl_specialty.Size = new Size(72, 20);
            lbl_specialty.TabIndex = 2;
            lbl_specialty.Text = "Specialty:";
            // 
            // lbl_info
            // 
            lbl_info.AutoSize = true;
            lbl_info.BackColor = Color.Transparent;
            lbl_info.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_info.Location = new Point(569, 17);
            lbl_info.Name = "lbl_info";
            lbl_info.Size = new Size(389, 32);
            lbl_info.TabIndex = 18;
            lbl_info.Text = "PERSONAL INFORMATION";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(36, 10);
            label1.Name = "label1";
            label1.Size = new Size(460, 32);
            label1.TabIndex = 19;
            label1.Text = "PROFESSIONAL CREDENTIALS";
            // 
            // DoctorProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.blue_bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1012, 674);
            Controls.Add(lbl_info);
            Controls.Add(lbl_exitdoctor);
            Controls.Add(panel1);
            Controls.Add(lbl_email);
            Controls.Add(lbl_phone);
            Controls.Add(lbl_specialty);
            Controls.Add(lbl_name);
            Controls.Add(picture_display);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DoctorProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DoctorProfile";
            Load += DoctorProfile_Load;
            ((System.ComponentModel.ISupportInitialize)picture_display).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picture_display;
        private Label lbl_name;
        private Label lbl_phone;
        private Label lbl_email;
        private Panel panel1;
        private Label lbl_socials;
        private Label lbl_homeadd;
        private Label lbl_exitdoctor;
        private Label lbl_medicalschool;
        private Label lbl_certified;
        private Label lbl_experience;
        private Label lbl_medicallicense;
        private Label lbl_specialty;
        private Label label1;
        private Label lbl_info;
    }
}