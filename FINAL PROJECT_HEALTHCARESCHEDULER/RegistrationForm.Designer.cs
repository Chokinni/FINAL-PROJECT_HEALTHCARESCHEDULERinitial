namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            reg_showpass = new CheckBox();
            lbl_alreadyowned = new Label();
            btn_reglogin = new Button();
            picturebox_hospital = new PictureBox();
            btn_signup = new Button();
            tbx_regpassword = new TextBox();
            tbx_regusername = new TextBox();
            lbl_regpass = new Label();
            lbl_reguser = new Label();
            panel1 = new Panel();
            label4 = new Label();
            picture_patient = new PictureBox();
            picture_doc = new PictureBox();
            lbl_welcomeregister = new Label();
            tbx_firstname = new TextBox();
            lbl_regFirstname = new Label();
            tbx_lastname = new TextBox();
            lbl_reglastname = new Label();
            cmbRole = new ComboBox();
            lbl_role = new Label();
            lbl_specialty = new Label();
            exitlbl = new Label();
            cbx_specialty = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)picturebox_hospital).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture_patient).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_doc).BeginInit();
            SuspendLayout();
            // 
            // reg_showpass
            // 
            reg_showpass.AutoSize = true;
            reg_showpass.BackColor = Color.Transparent;
            reg_showpass.Location = new Point(401, 366);
            reg_showpass.Name = "reg_showpass";
            reg_showpass.Size = new Size(132, 24);
            reg_showpass.TabIndex = 20;
            reg_showpass.Text = "Show Password";
            reg_showpass.UseVisualStyleBackColor = false;
            reg_showpass.CheckedChanged += reg_showpass_CheckedChanged;
            // 
            // lbl_alreadyowned
            // 
            lbl_alreadyowned.AutoSize = true;
            lbl_alreadyowned.BackColor = Color.Transparent;
            lbl_alreadyowned.Font = new Font("Microsoft Sans Serif", 10F);
            lbl_alreadyowned.Location = new Point(548, 538);
            lbl_alreadyowned.Name = "lbl_alreadyowned";
            lbl_alreadyowned.Size = new Size(201, 20);
            lbl_alreadyowned.TabIndex = 19;
            lbl_alreadyowned.Text = "Already have an account?";
            // 
            // btn_reglogin
            // 
            btn_reglogin.BackColor = Color.FromArgb(34, 77, 83);
            btn_reglogin.FlatAppearance.BorderSize = 0;
            btn_reglogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 176, 161);
            btn_reglogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(8, 176, 161);
            btn_reglogin.FlatStyle = FlatStyle.Flat;
            btn_reglogin.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_reglogin.ForeColor = Color.White;
            btn_reglogin.Location = new Point(584, 571);
            btn_reglogin.Name = "btn_reglogin";
            btn_reglogin.Size = new Size(143, 29);
            btn_reglogin.TabIndex = 18;
            btn_reglogin.Text = "LOGIN";
            btn_reglogin.UseVisualStyleBackColor = false;
            btn_reglogin.Click += btn_reglogin_Click;
            // 
            // picturebox_hospital
            // 
            picturebox_hospital.BackColor = Color.Transparent;
            picturebox_hospital.Image = (Image)resources.GetObject("picturebox_hospital.Image");
            picturebox_hospital.Location = new Point(584, 12);
            picturebox_hospital.Name = "picturebox_hospital";
            picturebox_hospital.Size = new Size(143, 126);
            picturebox_hospital.SizeMode = PictureBoxSizeMode.StretchImage;
            picturebox_hospital.TabIndex = 17;
            picturebox_hospital.TabStop = false;
            // 
            // btn_signup
            // 
            btn_signup.BackColor = Color.FromArgb(34, 77, 83);
            btn_signup.FlatAppearance.BorderSize = 0;
            btn_signup.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 176, 161);
            btn_signup.FlatAppearance.MouseOverBackColor = Color.FromArgb(8, 176, 161);
            btn_signup.FlatStyle = FlatStyle.Flat;
            btn_signup.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_signup.ForeColor = Color.White;
            btn_signup.Location = new Point(584, 476);
            btn_signup.Name = "btn_signup";
            btn_signup.Size = new Size(143, 29);
            btn_signup.TabIndex = 16;
            btn_signup.Text = "SIGN-UP";
            btn_signup.UseVisualStyleBackColor = false;
            btn_signup.Click += btn_signup_Click;
            // 
            // tbx_regpassword
            // 
            tbx_regpassword.Location = new Point(401, 321);
            tbx_regpassword.Multiline = true;
            tbx_regpassword.Name = "tbx_regpassword";
            tbx_regpassword.PasswordChar = '*';
            tbx_regpassword.Size = new Size(232, 27);
            tbx_regpassword.TabIndex = 15;
            // 
            // tbx_regusername
            // 
            tbx_regusername.Location = new Point(401, 233);
            tbx_regusername.Multiline = true;
            tbx_regusername.Name = "tbx_regusername";
            tbx_regusername.Size = new Size(232, 34);
            tbx_regusername.TabIndex = 14;
            // 
            // lbl_regpass
            // 
            lbl_regpass.AutoSize = true;
            lbl_regpass.BackColor = Color.Transparent;
            lbl_regpass.Font = new Font("Microsoft Sans Serif", 10F);
            lbl_regpass.Location = new Point(398, 287);
            lbl_regpass.Name = "lbl_regpass";
            lbl_regpass.Size = new Size(83, 20);
            lbl_regpass.TabIndex = 13;
            lbl_regpass.Text = "Password";
            // 
            // lbl_reguser
            // 
            lbl_reguser.AutoSize = true;
            lbl_reguser.BackColor = Color.Transparent;
            lbl_reguser.Font = new Font("Microsoft Sans Serif", 10F);
            lbl_reguser.Location = new Point(398, 200);
            lbl_reguser.Name = "lbl_reguser";
            lbl_reguser.Size = new Size(86, 20);
            lbl_reguser.TabIndex = 12;
            lbl_reguser.Text = "Username";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(34, 77, 83);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(picture_patient);
            panel1.Controls.Add(picture_doc);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(386, 654);
            panel1.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(27, 299);
            label4.Name = "label4";
            label4.Size = new Size(332, 20);
            label4.TabIndex = 3;
            label4.Text = "HEALTHCARE SCHEDULER SYSTEM";
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
            // lbl_welcomeregister
            // 
            lbl_welcomeregister.AutoSize = true;
            lbl_welcomeregister.BackColor = Color.Transparent;
            lbl_welcomeregister.Font = new Font("Microsoft Sans Serif", 10F);
            lbl_welcomeregister.Location = new Point(569, 158);
            lbl_welcomeregister.Name = "lbl_welcomeregister";
            lbl_welcomeregister.Size = new Size(180, 20);
            lbl_welcomeregister.TabIndex = 21;
            lbl_welcomeregister.Text = "REGISTER ACCOUNT";
            // 
            // tbx_firstname
            // 
            tbx_firstname.Location = new Point(672, 314);
            tbx_firstname.Multiline = true;
            tbx_firstname.Name = "tbx_firstname";
            tbx_firstname.Size = new Size(232, 34);
            tbx_firstname.TabIndex = 23;
            // 
            // lbl_regFirstname
            // 
            lbl_regFirstname.AutoSize = true;
            lbl_regFirstname.BackColor = Color.Transparent;
            lbl_regFirstname.Font = new Font("Microsoft Sans Serif", 10F);
            lbl_regFirstname.Location = new Point(669, 281);
            lbl_regFirstname.Name = "lbl_regFirstname";
            lbl_regFirstname.Size = new Size(92, 20);
            lbl_regFirstname.TabIndex = 22;
            lbl_regFirstname.Text = "First Name";
            // 
            // tbx_lastname
            // 
            tbx_lastname.Location = new Point(675, 233);
            tbx_lastname.Multiline = true;
            tbx_lastname.Name = "tbx_lastname";
            tbx_lastname.Size = new Size(232, 34);
            tbx_lastname.TabIndex = 25;
            // 
            // lbl_reglastname
            // 
            lbl_reglastname.AutoSize = true;
            lbl_reglastname.BackColor = Color.Transparent;
            lbl_reglastname.Font = new Font("Microsoft Sans Serif", 10F);
            lbl_reglastname.Location = new Point(672, 200);
            lbl_reglastname.Name = "lbl_reglastname";
            lbl_reglastname.Size = new Size(91, 20);
            lbl_reglastname.TabIndex = 24;
            lbl_reglastname.Text = "Last Name";
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "DOCTOR", "PATIENT" });
            cmbRole.Location = new Point(753, 366);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(151, 28);
            cmbRole.TabIndex = 26;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // lbl_role
            // 
            lbl_role.AutoSize = true;
            lbl_role.BackColor = Color.Transparent;
            lbl_role.Font = new Font("Microsoft Sans Serif", 10F);
            lbl_role.Location = new Point(693, 370);
            lbl_role.Name = "lbl_role";
            lbl_role.Size = new Size(43, 20);
            lbl_role.TabIndex = 27;
            lbl_role.Text = "Role";
            // 
            // lbl_specialty
            // 
            lbl_specialty.AutoSize = true;
            lbl_specialty.BackColor = Color.Transparent;
            lbl_specialty.Font = new Font("Microsoft Sans Serif", 10F);
            lbl_specialty.Location = new Point(523, 419);
            lbl_specialty.Name = "lbl_specialty";
            lbl_specialty.Size = new Size(99, 20);
            lbl_specialty.TabIndex = 28;
            lbl_specialty.Text = "SPECIALTY";
            // 
            // exitlbl
            // 
            exitlbl.AutoSize = true;
            exitlbl.BackColor = Color.IndianRed;
            exitlbl.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            exitlbl.ForeColor = SystemColors.ActiveCaptionText;
            exitlbl.Location = new Point(907, 0);
            exitlbl.Name = "exitlbl";
            exitlbl.Size = new Size(26, 28);
            exitlbl.TabIndex = 30;
            exitlbl.Text = "X";
            exitlbl.Click += exitlbl_Click;
            // 
            // cbx_specialty
            // 
            cbx_specialty.FormattingEnabled = true;
            cbx_specialty.Items.AddRange(new object[] { "CARDIOLOGY", "PEDIATRICS", "GYNECOLOGIST", "NEUROLOGY", "DERMATOLOGY", "NEPHROLOGY", "OPHTHALMOLOGY", "ORTHOPEDICS" });
            cbx_specialty.Location = new Point(637, 416);
            cbx_specialty.Name = "cbx_specialty";
            cbx_specialty.Size = new Size(151, 28);
            cbx_specialty.TabIndex = 31;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.blue_bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(933, 654);
            Controls.Add(cbx_specialty);
            Controls.Add(exitlbl);
            Controls.Add(lbl_specialty);
            Controls.Add(lbl_role);
            Controls.Add(cmbRole);
            Controls.Add(tbx_lastname);
            Controls.Add(lbl_reglastname);
            Controls.Add(tbx_firstname);
            Controls.Add(lbl_regFirstname);
            Controls.Add(lbl_welcomeregister);
            Controls.Add(reg_showpass);
            Controls.Add(lbl_alreadyowned);
            Controls.Add(btn_reglogin);
            Controls.Add(picturebox_hospital);
            Controls.Add(btn_signup);
            Controls.Add(tbx_regpassword);
            Controls.Add(tbx_regusername);
            Controls.Add(lbl_regpass);
            Controls.Add(lbl_reguser);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)picturebox_hospital).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picture_patient).EndInit();
            ((System.ComponentModel.ISupportInitialize)picture_doc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox reg_showpass;
        private Label lbl_alreadyowned;
        private Button btn_reglogin;
        private PictureBox picturebox_hospital;
        private Button btn_signup;
        private TextBox tbx_regpassword;
        private TextBox tbx_regusername;
        private Label lbl_regpass;
        private Label lbl_reguser;
        private Panel panel1;
        private Label label4;
        private PictureBox picture_patient;
        private PictureBox picture_doc;
        private Label lbl_welcomeregister;
        private TextBox tbx_firstname;
        private Label lbl_regFirstname;
        private TextBox tbx_lastname;
        private Label lbl_reglastname;
        private ComboBox cmbRole;
        private Label lbl_role;
        private Label lbl_specialty;
        private Label exitlbl;
        private ComboBox cbx_specialty;
    }
}