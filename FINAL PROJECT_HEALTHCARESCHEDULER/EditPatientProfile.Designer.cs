namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class EditPatientProfile
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
            lbl_info = new Label();
            lbl_homeadd = new Label();
            lbl_socials = new Label();
            lbl_email = new Label();
            lbl_phone = new Label();
            picture_displaydoctoredit = new PictureBox();
            lbl_name = new Label();
            panel1 = new Panel();
            btnSave = new Button();
            tbx_editcontactnum = new TextBox();
            tbx_editrelationship = new TextBox();
            tbx_editcontactname = new TextBox();
            lbl_contactemergency = new Label();
            lbl_relationship = new Label();
            lbl_contactname = new Label();
            lbl_emergency = new Label();
            tbx_editname = new TextBox();
            tbx_editphone = new TextBox();
            tbx_editemail = new TextBox();
            tbx_editsocial = new TextBox();
            tbx_editaddress = new TextBox();
            lbl_exitedit = new Label();
            button_editupload = new Button();
            tbx_editapppass = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)picture_displaydoctoredit).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_info
            // 
            lbl_info.AutoSize = true;
            lbl_info.BackColor = Color.Transparent;
            lbl_info.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_info.Location = new Point(660, 0);
            lbl_info.Name = "lbl_info";
            lbl_info.Size = new Size(389, 32);
            lbl_info.TabIndex = 24;
            lbl_info.Text = "PERSONAL INFORMATION";
            // 
            // lbl_homeadd
            // 
            lbl_homeadd.AutoSize = true;
            lbl_homeadd.BackColor = Color.Transparent;
            lbl_homeadd.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold);
            lbl_homeadd.ForeColor = Color.Yellow;
            lbl_homeadd.Location = new Point(715, 138);
            lbl_homeadd.Name = "lbl_homeadd";
            lbl_homeadd.Size = new Size(142, 20);
            lbl_homeadd.TabIndex = 18;
            lbl_homeadd.Text = "Home Address:";
            // 
            // lbl_socials
            // 
            lbl_socials.AutoSize = true;
            lbl_socials.BackColor = Color.Transparent;
            lbl_socials.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold);
            lbl_socials.ForeColor = Color.Yellow;
            lbl_socials.Location = new Point(729, 82);
            lbl_socials.Name = "lbl_socials";
            lbl_socials.Size = new Size(128, 20);
            lbl_socials.TabIndex = 19;
            lbl_socials.Text = "Social Media:";
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.BackColor = Color.Transparent;
            lbl_email.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold);
            lbl_email.ForeColor = Color.Yellow;
            lbl_email.Location = new Point(417, 195);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(66, 20);
            lbl_email.TabIndex = 23;
            lbl_email.Text = "Email:";
            // 
            // lbl_phone
            // 
            lbl_phone.AutoSize = true;
            lbl_phone.BackColor = Color.Transparent;
            lbl_phone.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold);
            lbl_phone.ForeColor = Color.Yellow;
            lbl_phone.Location = new Point(417, 138);
            lbl_phone.Name = "lbl_phone";
            lbl_phone.Size = new Size(69, 20);
            lbl_phone.TabIndex = 22;
            lbl_phone.Text = "Phone:";
            // 
            // picture_displaydoctoredit
            // 
            picture_displaydoctoredit.Location = new Point(49, 30);
            picture_displaydoctoredit.Name = "picture_displaydoctoredit";
            picture_displaydoctoredit.Size = new Size(241, 224);
            picture_displaydoctoredit.TabIndex = 20;
            picture_displaydoctoredit.TabStop = false;
            picture_displaydoctoredit.Click += picture_displaydoctoredit_Click;
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.BackColor = Color.Transparent;
            lbl_name.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_name.ForeColor = Color.Yellow;
            lbl_name.Location = new Point(417, 82);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(79, 20);
            lbl_name.TabIndex = 21;
            lbl_name.Text = "Patient:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 211, 172);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(tbx_editcontactnum);
            panel1.Controls.Add(tbx_editrelationship);
            panel1.Controls.Add(tbx_editcontactname);
            panel1.Controls.Add(lbl_contactemergency);
            panel1.Controls.Add(lbl_relationship);
            panel1.Controls.Add(lbl_contactname);
            panel1.Controls.Add(lbl_emergency);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 369);
            panel1.Name = "panel1";
            panel1.Size = new Size(1082, 344);
            panel1.TabIndex = 25;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Aqua;
            btnSave.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(895, 273);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(103, 38);
            btnSave.TabIndex = 32;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // tbx_editcontactnum
            // 
            tbx_editcontactnum.Location = new Point(229, 216);
            tbx_editcontactnum.Multiline = true;
            tbx_editcontactnum.Name = "tbx_editcontactnum";
            tbx_editcontactnum.Size = new Size(149, 27);
            tbx_editcontactnum.TabIndex = 31;
            // 
            // tbx_editrelationship
            // 
            tbx_editrelationship.Location = new Point(193, 161);
            tbx_editrelationship.Multiline = true;
            tbx_editrelationship.Name = "tbx_editrelationship";
            tbx_editrelationship.Size = new Size(149, 27);
            tbx_editrelationship.TabIndex = 30;
            // 
            // tbx_editcontactname
            // 
            tbx_editcontactname.Location = new Point(257, 104);
            tbx_editcontactname.Multiline = true;
            tbx_editcontactname.Name = "tbx_editcontactname";
            tbx_editcontactname.Size = new Size(149, 27);
            tbx_editcontactname.TabIndex = 29;
            // 
            // lbl_contactemergency
            // 
            lbl_contactemergency.AutoSize = true;
            lbl_contactemergency.BackColor = Color.Transparent;
            lbl_contactemergency.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold);
            lbl_contactemergency.ForeColor = Color.Navy;
            lbl_contactemergency.Location = new Point(49, 219);
            lbl_contactemergency.Name = "lbl_contactemergency";
            lbl_contactemergency.Size = new Size(160, 20);
            lbl_contactemergency.TabIndex = 19;
            lbl_contactemergency.Text = "Contact Number:";
            // 
            // lbl_relationship
            // 
            lbl_relationship.AutoSize = true;
            lbl_relationship.BackColor = Color.Transparent;
            lbl_relationship.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold);
            lbl_relationship.ForeColor = Color.Navy;
            lbl_relationship.Location = new Point(49, 164);
            lbl_relationship.Name = "lbl_relationship";
            lbl_relationship.Size = new Size(127, 20);
            lbl_relationship.TabIndex = 18;
            lbl_relationship.Text = "Relationship:";
            // 
            // lbl_contactname
            // 
            lbl_contactname.AutoSize = true;
            lbl_contactname.BackColor = Color.Transparent;
            lbl_contactname.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold);
            lbl_contactname.ForeColor = Color.Navy;
            lbl_contactname.Location = new Point(45, 107);
            lbl_contactname.Name = "lbl_contactname";
            lbl_contactname.Size = new Size(206, 20);
            lbl_contactname.TabIndex = 17;
            lbl_contactname.Text = "Contact Person Name:";
            // 
            // lbl_emergency
            // 
            lbl_emergency.AutoSize = true;
            lbl_emergency.BackColor = Color.Transparent;
            lbl_emergency.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_emergency.Location = new Point(35, 44);
            lbl_emergency.Name = "lbl_emergency";
            lbl_emergency.Size = new Size(288, 32);
            lbl_emergency.TabIndex = 16;
            lbl_emergency.Text = "Emergency Contact:";
            // 
            // tbx_editname
            // 
            tbx_editname.Location = new Point(502, 79);
            tbx_editname.Name = "tbx_editname";
            tbx_editname.Size = new Size(125, 27);
            tbx_editname.TabIndex = 26;
            // 
            // tbx_editphone
            // 
            tbx_editphone.Location = new Point(502, 131);
            tbx_editphone.Name = "tbx_editphone";
            tbx_editphone.Size = new Size(125, 27);
            tbx_editphone.TabIndex = 27;
            // 
            // tbx_editemail
            // 
            tbx_editemail.Location = new Point(502, 195);
            tbx_editemail.Multiline = true;
            tbx_editemail.Name = "tbx_editemail";
            tbx_editemail.Size = new Size(149, 27);
            tbx_editemail.TabIndex = 28;
            // 
            // tbx_editsocial
            // 
            tbx_editsocial.Location = new Point(863, 79);
            tbx_editsocial.Multiline = true;
            tbx_editsocial.Name = "tbx_editsocial";
            tbx_editsocial.Size = new Size(149, 27);
            tbx_editsocial.TabIndex = 29;
            // 
            // tbx_editaddress
            // 
            tbx_editaddress.Location = new Point(863, 135);
            tbx_editaddress.Multiline = true;
            tbx_editaddress.Name = "tbx_editaddress";
            tbx_editaddress.Size = new Size(149, 27);
            tbx_editaddress.TabIndex = 30;
            // 
            // lbl_exitedit
            // 
            lbl_exitedit.AutoSize = true;
            lbl_exitedit.BackColor = Color.Red;
            lbl_exitedit.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lbl_exitedit.ForeColor = Color.Black;
            lbl_exitedit.Location = new Point(1055, 0);
            lbl_exitedit.Name = "lbl_exitedit";
            lbl_exitedit.Size = new Size(27, 25);
            lbl_exitedit.TabIndex = 31;
            lbl_exitedit.Text = "X";
            lbl_exitedit.Click += lbl_exitedit_Click;
            // 
            // button_editupload
            // 
            button_editupload.BackColor = Color.Aqua;
            button_editupload.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_editupload.Location = new Point(125, 274);
            button_editupload.Name = "button_editupload";
            button_editupload.Size = new Size(94, 29);
            button_editupload.TabIndex = 32;
            button_editupload.Text = "UPLOAD";
            button_editupload.UseVisualStyleBackColor = false;
            button_editupload.Click += button_editupload_Click;
            // 
            // tbx_editapppass
            // 
            tbx_editapppass.Location = new Point(858, 195);
            tbx_editapppass.Multiline = true;
            tbx_editapppass.Name = "tbx_editapppass";
            tbx_editapppass.Size = new Size(149, 27);
            tbx_editapppass.TabIndex = 34;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Bookman Old Style", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(715, 198);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 33;
            label1.Text = "App Password:";
            // 
            // EditPatientProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.blue_bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1082, 713);
            Controls.Add(tbx_editapppass);
            Controls.Add(label1);
            Controls.Add(button_editupload);
            Controls.Add(lbl_exitedit);
            Controls.Add(tbx_editaddress);
            Controls.Add(tbx_editsocial);
            Controls.Add(tbx_editemail);
            Controls.Add(tbx_editphone);
            Controls.Add(tbx_editname);
            Controls.Add(panel1);
            Controls.Add(lbl_info);
            Controls.Add(lbl_homeadd);
            Controls.Add(lbl_socials);
            Controls.Add(lbl_email);
            Controls.Add(lbl_phone);
            Controls.Add(picture_displaydoctoredit);
            Controls.Add(lbl_name);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditPatientProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditPatientProfile";
            Load += EditPatientProfile_Load;
            ((System.ComponentModel.ISupportInitialize)picture_displaydoctoredit).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_info;
        private Label lbl_homeadd;
        private Label lbl_socials;
        private Label lbl_email;
        private Label lbl_phone;
        private PictureBox picture_displaydoctoredit;
        private Label lbl_name;
        private Panel panel1;
        private Label lbl_contactemergency;
        private Label lbl_relationship;
        private Label lbl_contactname;
        private Label lbl_emergency;
        private TextBox tbx_editcontactnum;
        private TextBox tbx_editrelationship;
        private TextBox tbx_editcontactname;
        private TextBox tbx_editname;
        private TextBox tbx_editphone;
        private TextBox tbx_editemail;
        private TextBox tbx_editsocial;
        private TextBox tbx_editaddress;
        private Button btnSave;
        private Label lbl_exitedit;
        private Button button_editupload;
        private TextBox tbx_editapppass;
        private Label label1;
    }
}