namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            panel1 = new Panel();
            lbl_APPNAME = new Label();
            picture_patient = new PictureBox();
            picture_doc = new PictureBox();
            lbl_exit = new Label();
            lbl_username = new Label();
            lbl_password = new Label();
            tbx_username = new TextBox();
            tbx_password = new TextBox();
            btn_signin = new Button();
            picture_hospital = new PictureBox();
            btn_register = new Button();
            lbl_noacc = new Label();
            showpasslogin = new CheckBox();
            btn_forgotpass = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture_patient).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_doc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_hospital).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 150, 136);
            panel1.Controls.Add(lbl_APPNAME);
            panel1.Controls.Add(picture_patient);
            panel1.Controls.Add(picture_doc);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 700);
            panel1.TabIndex = 0;
            // 
            // lbl_APPNAME
            // 
            lbl_APPNAME.AutoSize = true;
            lbl_APPNAME.BackColor = Color.Transparent;
            lbl_APPNAME.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl_APPNAME.ForeColor = Color.White;
            lbl_APPNAME.Location = new Point(33, 396);
            lbl_APPNAME.Name = "lbl_APPNAME";
            lbl_APPNAME.Size = new Size(348, 37);
            lbl_APPNAME.TabIndex = 3;
            lbl_APPNAME.Text = "HEALTHCARE SCHEDULER";
            // 
            // picture_patient
            // 
            picture_patient.Image = Properties.Resources.patient2;
            picture_patient.Location = new Point(230, 230);
            picture_patient.Name = "picture_patient";
            picture_patient.Size = new Size(120, 140);
            picture_patient.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_patient.TabIndex = 1;
            picture_patient.TabStop = false;
            // 
            // picture_doc
            // 
            picture_doc.Image = Properties.Resources.doctor3;
            picture_doc.Location = new Point(50, 230);
            picture_doc.Name = "picture_doc";
            picture_doc.Size = new Size(120, 140);
            picture_doc.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_doc.TabIndex = 0;
            picture_doc.TabStop = false;
            // 
            // lbl_exit
            // 
            lbl_exit.AutoSize = true;
            lbl_exit.BackColor = Color.FromArgb(220, 53, 69);
            lbl_exit.Cursor = Cursors.Hand;
            lbl_exit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_exit.ForeColor = Color.White;
            lbl_exit.Location = new Point(1051, 9);
            lbl_exit.Name = "lbl_exit";
            lbl_exit.Size = new Size(25, 28);
            lbl_exit.TabIndex = 1;
            lbl_exit.Text = "X";
            lbl_exit.Click += label1_Click;
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.BackColor = Color.Transparent;
            lbl_username.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_username.ForeColor = Color.FromArgb(0, 150, 136);
            lbl_username.Location = new Point(571, 248);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(89, 23);
            lbl_username.TabIndex = 2;
            lbl_username.Text = "Username";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.BackColor = Color.Transparent;
            lbl_password.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_password.ForeColor = Color.FromArgb(0, 150, 136);
            lbl_password.Location = new Point(571, 328);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(85, 23);
            lbl_password.TabIndex = 3;
            lbl_password.Text = "Password";
            // 
            // tbx_username
            // 
            tbx_username.BorderStyle = BorderStyle.FixedSingle;
            tbx_username.Font = new Font("Segoe UI", 11F);
            tbx_username.Location = new Point(571, 278);
            tbx_username.Multiline = true;
            tbx_username.Name = "tbx_username";
            tbx_username.Size = new Size(350, 40);
            tbx_username.TabIndex = 4;
            // 
            // tbx_password
            // 
            tbx_password.BorderStyle = BorderStyle.FixedSingle;
            tbx_password.Font = new Font("Segoe UI", 11F);
            tbx_password.Location = new Point(571, 358);
            tbx_password.Multiline = true;
            tbx_password.Name = "tbx_password";
            tbx_password.PasswordChar = '●';
            tbx_password.Size = new Size(350, 40);
            tbx_password.TabIndex = 5;
            // 
            // btn_signin
            // 
            btn_signin.BackColor = Color.FromArgb(0, 150, 136);
            btn_signin.Cursor = Cursors.Hand;
            btn_signin.FlatAppearance.BorderSize = 0;
            btn_signin.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 130, 116);
            btn_signin.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 170, 156);
            btn_signin.FlatStyle = FlatStyle.Flat;
            btn_signin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_signin.ForeColor = Color.White;
            btn_signin.Location = new Point(571, 439);
            btn_signin.Name = "btn_signin";
            btn_signin.Size = new Size(350, 45);
            btn_signin.TabIndex = 6;
            btn_signin.Text = "SIGN IN";
            btn_signin.UseVisualStyleBackColor = false;
            btn_signin.Click += btn_signin_Click;
            // 
            // picture_hospital
            // 
            picture_hospital.BackColor = Color.Transparent;
            picture_hospital.Image = (Image)resources.GetObject("picture_hospital.Image");
            picture_hospital.Location = new Point(655, 36);
            picture_hospital.Name = "picture_hospital";
            picture_hospital.Size = new Size(174, 172);
            picture_hospital.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_hospital.TabIndex = 7;
            picture_hospital.TabStop = false;
            // 
            // btn_register
            // 
            btn_register.BackColor = Color.FromArgb(0, 150, 136);
            btn_register.Cursor = Cursors.Hand;
            btn_register.FlatAppearance.BorderSize = 0;
            btn_register.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 130, 116);
            btn_register.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 170, 156);
            btn_register.FlatStyle = FlatStyle.Flat;
            btn_register.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_register.ForeColor = Color.White;
            btn_register.Location = new Point(571, 581);
            btn_register.Name = "btn_register";
            btn_register.Size = new Size(350, 45);
            btn_register.TabIndex = 8;
            btn_register.Text = "REGISTER";
            btn_register.UseVisualStyleBackColor = false;
            btn_register.Click += button1_Click;
            // 
            // lbl_noacc
            // 
            lbl_noacc.AutoSize = true;
            lbl_noacc.BackColor = Color.Transparent;
            lbl_noacc.Font = new Font("Segoe UI", 9F);
            lbl_noacc.ForeColor = Color.FromArgb(0, 150, 136);
            lbl_noacc.Location = new Point(666, 547);
            lbl_noacc.Name = "lbl_noacc";
            lbl_noacc.Size = new Size(163, 20);
            lbl_noacc.TabIndex = 9;
            lbl_noacc.Text = "Don't have an account?";
            // 
            // showpasslogin
            // 
            showpasslogin.AutoSize = true;
            showpasslogin.BackColor = Color.Transparent;
            showpasslogin.Font = new Font("Segoe UI", 9F);
            showpasslogin.ForeColor = Color.FromArgb(0, 150, 136);
            showpasslogin.Location = new Point(571, 409);
            showpasslogin.Name = "showpasslogin";
            showpasslogin.Size = new Size(132, 24);
            showpasslogin.TabIndex = 10;
            showpasslogin.Text = "Show Password";
            showpasslogin.UseVisualStyleBackColor = false;
            showpasslogin.CheckedChanged += showpasslogin_CheckedChanged;
            // 
            // btn_forgotpass
            // 
            btn_forgotpass.BackColor = Color.Transparent;
            btn_forgotpass.Cursor = Cursors.Hand;
            btn_forgotpass.FlatAppearance.BorderSize = 0;
            btn_forgotpass.FlatStyle = FlatStyle.Flat;
            btn_forgotpass.Font = new Font("Segoe UI", 10F, FontStyle.Underline);
            btn_forgotpass.ForeColor = Color.FromArgb(0, 150, 136);
            btn_forgotpass.Location = new Point(571, 503);
            btn_forgotpass.Name = "btn_forgotpass";
            btn_forgotpass.Size = new Size(350, 30);
            btn_forgotpass.TabIndex = 58;
            btn_forgotpass.Text = "Forgot Password?";
            btn_forgotpass.UseVisualStyleBackColor = false;
            btn_forgotpass.Click += btn_forgotpass_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1084, 700);
            Controls.Add(btn_forgotpass);
            Controls.Add(showpasslogin);
            Controls.Add(lbl_noacc);
            Controls.Add(btn_register);
            Controls.Add(picture_hospital);
            Controls.Add(btn_signin);
            Controls.Add(tbx_password);
            Controls.Add(tbx_username);
            Controls.Add(lbl_password);
            Controls.Add(lbl_username);
            Controls.Add(lbl_exit);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOGIN";
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picture_patient).EndInit();
            ((System.ComponentModel.ISupportInitialize)picture_doc).EndInit();
            ((System.ComponentModel.ISupportInitialize)picture_hospital).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lbl_exit;
        private Label lbl_username;
        private Label lbl_password;
        private TextBox tbx_username;
        private TextBox tbx_password;
        private Button btn_signin;
        private PictureBox picture_patient;
        private PictureBox picture_doc;
        private Label lbl_APPNAME;
        private PictureBox picture_hospital;
        private Button btn_register;
        private Label lbl_noacc;
        private CheckBox showpasslogin;
        private Button btn_forgotpass;
    }
}