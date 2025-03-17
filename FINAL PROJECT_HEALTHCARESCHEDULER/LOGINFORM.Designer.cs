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
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture_patient).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_doc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_hospital).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(34, 77, 83);
            panel1.Controls.Add(lbl_APPNAME);
            panel1.Controls.Add(picture_patient);
            panel1.Controls.Add(picture_doc);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(386, 654);
            panel1.TabIndex = 0;
            // 
            // lbl_APPNAME
            // 
            lbl_APPNAME.AutoSize = true;
            lbl_APPNAME.BackColor = Color.Transparent;
            lbl_APPNAME.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_APPNAME.ForeColor = Color.White;
            lbl_APPNAME.Location = new Point(27, 299);
            lbl_APPNAME.Name = "lbl_APPNAME";
            lbl_APPNAME.Size = new Size(332, 20);
            lbl_APPNAME.TabIndex = 3;
            lbl_APPNAME.Text = "HEALTHCARE SCHEDULER SYSTEM";
            // 
            // picture_patient
            // 
            picture_patient.Image = Properties.Resources.patient2;
            picture_patient.Location = new Point(193, 143);
            picture_patient.Name = "picture_patient";
            picture_patient.Size = new Size(101, 120);
            picture_patient.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_patient.TabIndex = 1;
            picture_patient.TabStop = false;
            // 
            // picture_doc
            // 
            picture_doc.Image = Properties.Resources.doctor3;
            picture_doc.Location = new Point(86, 143);
            picture_doc.Name = "picture_doc";
            picture_doc.Size = new Size(101, 120);
            picture_doc.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_doc.TabIndex = 0;
            picture_doc.TabStop = false;
            // 
            // lbl_exit
            // 
            lbl_exit.AutoSize = true;
            lbl_exit.BackColor = Color.IndianRed;
            lbl_exit.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lbl_exit.ForeColor = SystemColors.ActiveCaptionText;
            lbl_exit.Location = new Point(895, 9);
            lbl_exit.Name = "lbl_exit";
            lbl_exit.Size = new Size(26, 28);
            lbl_exit.TabIndex = 1;
            lbl_exit.Text = "X";
            lbl_exit.Click += label1_Click;
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.BackColor = Color.Transparent;
            lbl_username.Font = new Font("Microsoft Sans Serif", 10F);
            lbl_username.Location = new Point(542, 252);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(86, 20);
            lbl_username.TabIndex = 2;
            lbl_username.Text = "Username";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.BackColor = Color.Transparent;
            lbl_password.Font = new Font("Microsoft Sans Serif", 10F);
            lbl_password.Location = new Point(542, 339);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(83, 20);
            lbl_password.TabIndex = 3;
            lbl_password.Text = "Password";
            // 
            // tbx_username
            // 
            tbx_username.Location = new Point(545, 285);
            tbx_username.Multiline = true;
            tbx_username.Name = "tbx_username";
            tbx_username.Size = new Size(232, 34);
            tbx_username.TabIndex = 4;
            // 
            // tbx_password
            // 
            tbx_password.Location = new Point(545, 373);
            tbx_password.Multiline = true;
            tbx_password.Name = "tbx_password";
            tbx_password.PasswordChar = '*';
            tbx_password.Size = new Size(232, 27);
            tbx_password.TabIndex = 5;
            // 
            // btn_signin
            // 
            btn_signin.BackColor = Color.FromArgb(34, 77, 83);
            btn_signin.FlatAppearance.BorderSize = 0;
            btn_signin.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 176, 161);
            btn_signin.FlatAppearance.MouseOverBackColor = Color.FromArgb(8, 176, 161);
            btn_signin.FlatStyle = FlatStyle.Flat;
            btn_signin.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_signin.ForeColor = Color.White;
            btn_signin.Location = new Point(591, 448);
            btn_signin.Name = "btn_signin";
            btn_signin.Size = new Size(143, 29);
            btn_signin.TabIndex = 6;
            btn_signin.Text = "SIGN-IN";
            btn_signin.UseVisualStyleBackColor = false;
            btn_signin.Click += btn_signin_Click;
            // 
            // picture_hospital
            // 
            picture_hospital.BackColor = Color.Transparent;
            picture_hospital.Image = (Image)resources.GetObject("picture_hospital.Image");
            picture_hospital.Location = new Point(591, 52);
            picture_hospital.Name = "picture_hospital";
            picture_hospital.Size = new Size(143, 126);
            picture_hospital.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_hospital.TabIndex = 7;
            picture_hospital.TabStop = false;
            // 
            // btn_register
            // 
            btn_register.BackColor = Color.FromArgb(34, 77, 83);
            btn_register.FlatAppearance.BorderSize = 0;
            btn_register.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 176, 161);
            btn_register.FlatAppearance.MouseOverBackColor = Color.FromArgb(8, 176, 161);
            btn_register.FlatStyle = FlatStyle.Flat;
            btn_register.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_register.ForeColor = Color.White;
            btn_register.Location = new Point(591, 543);
            btn_register.Name = "btn_register";
            btn_register.Size = new Size(143, 29);
            btn_register.TabIndex = 8;
            btn_register.Text = "REGISTER";
            btn_register.UseVisualStyleBackColor = false;
            btn_register.Click += button1_Click;
            // 
            // lbl_noacc
            // 
            lbl_noacc.AutoSize = true;
            lbl_noacc.BackColor = Color.Transparent;
            lbl_noacc.Font = new Font("Microsoft Sans Serif", 10F);
            lbl_noacc.Location = new Point(576, 510);
            lbl_noacc.Name = "lbl_noacc";
            lbl_noacc.Size = new Size(171, 20);
            lbl_noacc.TabIndex = 9;
            lbl_noacc.Text = "Have no account yet?";
            // 
            // showpasslogin
            // 
            showpasslogin.AutoSize = true;
            showpasslogin.BackColor = Color.Transparent;
            showpasslogin.Location = new Point(545, 406);
            showpasslogin.Name = "showpasslogin";
            showpasslogin.Size = new Size(132, 24);
            showpasslogin.TabIndex = 10;
            showpasslogin.Text = "Show Password";
            showpasslogin.UseVisualStyleBackColor = false;
            showpasslogin.CheckedChanged += showpasslogin_CheckedChanged;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.blue_bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(933, 654);
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
    }
}