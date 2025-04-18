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
            btn_insertpic = new Button();
            picture_profile = new PictureBox();
            label4 = new Label();
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
            btn_generateUsername = new Button();
            Number = new Label();
            Email = new Label();
            tbx_num = new TextBox();
            tbx_email = new TextBox();
            tbx_Licensenum = new TextBox();
            license = new Label();
            tbx_experience = new TextBox();
            Experience = new Label();
            tbx_homeadd = new TextBox();
            HomeAddress = new Label();
            tbx_certified = new TextBox();
            Certified = new Label();
            tbx_medschool = new TextBox();
            Medschool = new Label();
            tbx_media = new TextBox();
            lblmedia = new Label();
            tbx_emercon = new TextBox();
            lbl_contactemer = new Label();
            tbx_relationship = new TextBox();
            label2 = new Label();
            tbx_contactemer = new TextBox();
            label3 = new Label();
            tbx_apppass = new TextBox();
            lbl_apppass = new Label();
            ((System.ComponentModel.ISupportInitialize)picturebox_hospital).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture_profile).BeginInit();
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
            lbl_alreadyowned.Location = new Point(842, 585);
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
            btn_reglogin.Location = new Point(863, 628);
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
            picturebox_hospital.Location = new Point(878, 0);
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
            btn_signup.Location = new Point(677, 628);
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
            panel1.Controls.Add(btn_insertpic);
            panel1.Controls.Add(picture_profile);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(386, 684);
            panel1.TabIndex = 11;
            // 
            // btn_insertpic
            // 
            btn_insertpic.BackColor = Color.FromArgb(34, 77, 83);
            btn_insertpic.FlatAppearance.BorderSize = 0;
            btn_insertpic.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 176, 161);
            btn_insertpic.FlatAppearance.MouseOverBackColor = Color.FromArgb(8, 176, 161);
            btn_insertpic.FlatStyle = FlatStyle.Flat;
            btn_insertpic.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_insertpic.ForeColor = Color.White;
            btn_insertpic.Location = new Point(110, 248);
            btn_insertpic.Name = "btn_insertpic";
            btn_insertpic.Size = new Size(143, 29);
            btn_insertpic.TabIndex = 17;
            btn_insertpic.Text = "UPLOAD";
            btn_insertpic.UseVisualStyleBackColor = false;
            btn_insertpic.Click += btn_insertpic_Click;
            // 
            // picture_profile
            // 
            picture_profile.Location = new Point(71, 38);
            picture_profile.Name = "picture_profile";
            picture_profile.Size = new Size(224, 182);
            picture_profile.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_profile.TabIndex = 4;
            picture_profile.TabStop = false;
            picture_profile.Click += picture_profile_Click;
            picture_profile.Paint += picture_profile_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(27, 385);
            label4.Name = "label4";
            label4.Size = new Size(332, 20);
            label4.TabIndex = 3;
            label4.Text = "HEALTHCARE SCHEDULER SYSTEM";
            // 
            // lbl_welcomeregister
            // 
            lbl_welcomeregister.AutoSize = true;
            lbl_welcomeregister.BackColor = Color.Transparent;
            lbl_welcomeregister.Font = new Font("Microsoft Sans Serif", 10F);
            lbl_welcomeregister.Location = new Point(863, 146);
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
            lbl_specialty.Location = new Point(401, 420);
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
            exitlbl.Location = new Point(1517, 0);
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
            cbx_specialty.Location = new Point(515, 417);
            cbx_specialty.Name = "cbx_specialty";
            cbx_specialty.Size = new Size(151, 28);
            cbx_specialty.TabIndex = 31;
            // 
            // btn_generateUsername
            // 
            btn_generateUsername.BackColor = Color.FromArgb(34, 77, 83);
            btn_generateUsername.FlatAppearance.BorderSize = 0;
            btn_generateUsername.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 176, 161);
            btn_generateUsername.FlatAppearance.MouseOverBackColor = Color.FromArgb(8, 176, 161);
            btn_generateUsername.FlatStyle = FlatStyle.Flat;
            btn_generateUsername.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_generateUsername.ForeColor = Color.White;
            btn_generateUsername.Location = new Point(1043, 615);
            btn_generateUsername.Name = "btn_generateUsername";
            btn_generateUsername.Size = new Size(143, 51);
            btn_generateUsername.TabIndex = 32;
            btn_generateUsername.Text = "Generate Username";
            btn_generateUsername.UseVisualStyleBackColor = false;
            btn_generateUsername.Click += btn_generateUsername_Click;
            // 
            // Number
            // 
            Number.AutoSize = true;
            Number.BackColor = Color.Transparent;
            Number.Font = new Font("Microsoft Sans Serif", 10F);
            Number.Location = new Point(974, 200);
            Number.Name = "Number";
            Number.Size = new Size(86, 20);
            Number.TabIndex = 33;
            Number.Text = "Phone No.";
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.BackColor = Color.Transparent;
            Email.Font = new Font("Microsoft Sans Serif", 10F);
            Email.Location = new Point(1185, 200);
            Email.Name = "Email";
            Email.Size = new Size(118, 20);
            Email.TabIndex = 34;
            Email.Text = "Email Address";
            // 
            // tbx_num
            // 
            tbx_num.Location = new Point(974, 233);
            tbx_num.Multiline = true;
            tbx_num.Name = "tbx_num";
            tbx_num.Size = new Size(146, 34);
            tbx_num.TabIndex = 35;
            // 
            // tbx_email
            // 
            tbx_email.Location = new Point(1185, 233);
            tbx_email.Multiline = true;
            tbx_email.Name = "tbx_email";
            tbx_email.Size = new Size(146, 34);
            tbx_email.TabIndex = 36;
            // 
            // tbx_Licensenum
            // 
            tbx_Licensenum.Location = new Point(974, 321);
            tbx_Licensenum.Multiline = true;
            tbx_Licensenum.Name = "tbx_Licensenum";
            tbx_Licensenum.Size = new Size(146, 34);
            tbx_Licensenum.TabIndex = 38;
            // 
            // license
            // 
            license.AutoSize = true;
            license.BackColor = Color.Transparent;
            license.Font = new Font("Microsoft Sans Serif", 10F);
            license.Location = new Point(974, 286);
            license.Name = "license";
            license.Size = new Size(161, 20);
            license.TabIndex = 37;
            license.Text = "Medical License No.";
            // 
            // tbx_experience
            // 
            tbx_experience.Location = new Point(1185, 321);
            tbx_experience.Multiline = true;
            tbx_experience.Name = "tbx_experience";
            tbx_experience.Size = new Size(146, 34);
            tbx_experience.TabIndex = 40;
            // 
            // Experience
            // 
            Experience.AutoSize = true;
            Experience.BackColor = Color.Transparent;
            Experience.Font = new Font("Microsoft Sans Serif", 10F);
            Experience.Location = new Point(1172, 287);
            Experience.Name = "Experience";
            Experience.Size = new Size(159, 20);
            Experience.TabIndex = 39;
            Experience.Text = "Years of Experience";
            // 
            // tbx_homeadd
            // 
            tbx_homeadd.Location = new Point(974, 420);
            tbx_homeadd.Multiline = true;
            tbx_homeadd.Name = "tbx_homeadd";
            tbx_homeadd.Size = new Size(146, 34);
            tbx_homeadd.TabIndex = 42;
            // 
            // HomeAddress
            // 
            HomeAddress.AutoSize = true;
            HomeAddress.BackColor = Color.Transparent;
            HomeAddress.Font = new Font("Microsoft Sans Serif", 10F);
            HomeAddress.Location = new Point(974, 385);
            HomeAddress.Name = "HomeAddress";
            HomeAddress.Size = new Size(121, 20);
            HomeAddress.TabIndex = 41;
            HomeAddress.Text = "Home Address";
            // 
            // tbx_certified
            // 
            tbx_certified.Location = new Point(1365, 321);
            tbx_certified.Multiline = true;
            tbx_certified.Name = "tbx_certified";
            tbx_certified.Size = new Size(146, 34);
            tbx_certified.TabIndex = 44;
            // 
            // Certified
            // 
            Certified.AutoSize = true;
            Certified.BackColor = Color.Transparent;
            Certified.Font = new Font("Microsoft Sans Serif", 10F);
            Certified.Location = new Point(1368, 287);
            Certified.Name = "Certified";
            Certified.Size = new Size(122, 20);
            Certified.TabIndex = 43;
            Certified.Text = "Board Certified";
            // 
            // tbx_medschool
            // 
            tbx_medschool.Location = new Point(1172, 420);
            tbx_medschool.Multiline = true;
            tbx_medschool.Name = "tbx_medschool";
            tbx_medschool.Size = new Size(146, 34);
            tbx_medschool.TabIndex = 46;
            // 
            // Medschool
            // 
            Medschool.AutoSize = true;
            Medschool.BackColor = Color.Transparent;
            Medschool.Font = new Font("Microsoft Sans Serif", 10F);
            Medschool.Location = new Point(1186, 386);
            Medschool.Name = "Medschool";
            Medschool.Size = new Size(123, 20);
            Medschool.TabIndex = 45;
            Medschool.Text = "Medical School";
            // 
            // tbx_media
            // 
            tbx_media.Location = new Point(1365, 417);
            tbx_media.Multiline = true;
            tbx_media.Name = "tbx_media";
            tbx_media.Size = new Size(146, 34);
            tbx_media.TabIndex = 48;
            // 
            // lblmedia
            // 
            lblmedia.AutoSize = true;
            lblmedia.BackColor = Color.Transparent;
            lblmedia.Font = new Font("Microsoft Sans Serif", 10F);
            lblmedia.Location = new Point(1379, 383);
            lblmedia.Name = "lblmedia";
            lblmedia.Size = new Size(105, 20);
            lblmedia.TabIndex = 47;
            lblmedia.Text = "Social Media";
            // 
            // tbx_emercon
            // 
            tbx_emercon.Location = new Point(974, 508);
            tbx_emercon.Multiline = true;
            tbx_emercon.Name = "tbx_emercon";
            tbx_emercon.Size = new Size(146, 34);
            tbx_emercon.TabIndex = 50;
            // 
            // lbl_contactemer
            // 
            lbl_contactemer.AutoSize = true;
            lbl_contactemer.BackColor = Color.Transparent;
            lbl_contactemer.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_contactemer.Location = new Point(965, 475);
            lbl_contactemer.Name = "lbl_contactemer";
            lbl_contactemer.Size = new Size(191, 18);
            lbl_contactemer.TabIndex = 49;
            lbl_contactemer.Text = "Emergency Contact Person";
            // 
            // tbx_relationship
            // 
            tbx_relationship.Location = new Point(1172, 508);
            tbx_relationship.Multiline = true;
            tbx_relationship.Name = "tbx_relationship";
            tbx_relationship.Size = new Size(146, 34);
            tbx_relationship.TabIndex = 52;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 10F);
            label2.Location = new Point(1194, 474);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 51;
            label2.Text = "Relationship";
            // 
            // tbx_contactemer
            // 
            tbx_contactemer.Location = new Point(1355, 508);
            tbx_contactemer.Multiline = true;
            tbx_contactemer.Name = "tbx_contactemer";
            tbx_contactemer.Size = new Size(146, 34);
            tbx_contactemer.TabIndex = 54;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", 10F);
            label3.Location = new Point(1335, 474);
            label3.Name = "label3";
            label3.Size = new Size(195, 20);
            label3.TabIndex = 53;
            label3.Text = "Emergency Contact NO. ";
            // 
            // tbx_apppass
            // 
            tbx_apppass.Location = new Point(1365, 233);
            tbx_apppass.Multiline = true;
            tbx_apppass.Name = "tbx_apppass";
            tbx_apppass.Size = new Size(146, 34);
            tbx_apppass.TabIndex = 56;
            // 
            // lbl_apppass
            // 
            lbl_apppass.AutoSize = true;
            lbl_apppass.BackColor = Color.Transparent;
            lbl_apppass.Font = new Font("Microsoft Sans Serif", 10F);
            lbl_apppass.Location = new Point(1368, 200);
            lbl_apppass.Name = "lbl_apppass";
            lbl_apppass.Size = new Size(143, 20);
            lbl_apppass.TabIndex = 55;
            lbl_apppass.Text = "App Pass(EMAIL)";
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.blue_bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1545, 684);
            Controls.Add(tbx_apppass);
            Controls.Add(lbl_apppass);
            Controls.Add(tbx_contactemer);
            Controls.Add(label3);
            Controls.Add(tbx_relationship);
            Controls.Add(label2);
            Controls.Add(tbx_emercon);
            Controls.Add(lbl_contactemer);
            Controls.Add(tbx_media);
            Controls.Add(lblmedia);
            Controls.Add(tbx_medschool);
            Controls.Add(Medschool);
            Controls.Add(tbx_certified);
            Controls.Add(Certified);
            Controls.Add(tbx_homeadd);
            Controls.Add(HomeAddress);
            Controls.Add(tbx_experience);
            Controls.Add(Experience);
            Controls.Add(tbx_Licensenum);
            Controls.Add(license);
            Controls.Add(tbx_email);
            Controls.Add(tbx_num);
            Controls.Add(Email);
            Controls.Add(Number);
            Controls.Add(btn_generateUsername);
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
            Load += RegistrationForm_Load;
            ((System.ComponentModel.ISupportInitialize)picturebox_hospital).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picture_profile).EndInit();
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
        private Button btn_generateUsername;
        private Label Number;
        private Label Email;
        private TextBox tbx_num;
        private TextBox tbx_email;
        private TextBox tbx_Licensenum;
        private Label license;
        private TextBox tbx_experience;
        private Label Experience;
        private TextBox tbx_homeadd;
        private Label HomeAddress;
        private TextBox tbx_certified;
        private Label Certified;
        private TextBox tbx_medschool;
        private Label Medschool;
        private TextBox tbx_media;
        private Label lblmedia;
        private Button btn_insertpic;
        private PictureBox picture_profile;
        private TextBox tbx_emercon;
        private Label lbl_contactemer;
        private TextBox tbx_relationship;
        private Label label2;
        private TextBox tbx_contactemer;
        private Label label3;
        private TextBox tbx_apppass;
        private Label lbl_apppass;
    }
}