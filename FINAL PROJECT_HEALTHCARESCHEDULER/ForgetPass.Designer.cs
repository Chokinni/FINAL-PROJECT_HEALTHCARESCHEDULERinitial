namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class ForgetPass
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
            panelVerification = new Panel();
            txtConfirmPassword = new TextBox();
            tbx_email = new TextBox();
            label1 = new Label();
            label4 = new Label();
            btn_sendcode = new Button();
            txt_NewPassword = new TextBox();
            label3 = new Label();
            btn_change = new Button();
            tbx_forget = new TextBox();
            label2 = new Label();
            panelVerification.SuspendLayout();
            SuspendLayout();
            // 
            // panelVerification
            // 
            panelVerification.BackColor = SystemColors.ActiveCaption;
            panelVerification.BackgroundImage = Properties.Resources.blue_bg;
            panelVerification.BackgroundImageLayout = ImageLayout.Stretch;
            panelVerification.Controls.Add(txtConfirmPassword);
            panelVerification.Controls.Add(tbx_email);
            panelVerification.Controls.Add(label1);
            panelVerification.Controls.Add(label4);
            panelVerification.Controls.Add(btn_sendcode);
            panelVerification.Controls.Add(txt_NewPassword);
            panelVerification.Controls.Add(label3);
            panelVerification.Controls.Add(btn_change);
            panelVerification.Controls.Add(tbx_forget);
            panelVerification.Controls.Add(label2);
            panelVerification.Location = new Point(1, 2);
            panelVerification.Name = "panelVerification";
            panelVerification.Size = new Size(603, 512);
            panelVerification.TabIndex = 13;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(217, 390);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(173, 27);
            txtConfirmPassword.TabIndex = 22;
            // 
            // tbx_email
            // 
            tbx_email.Location = new Point(217, 62);
            tbx_email.Name = "tbx_email";
            tbx_email.Size = new Size(173, 27);
            tbx_email.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(226, 27);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 13;
            label1.Text = "Enter Email Address:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(217, 355);
            label4.Name = "label4";
            label4.Size = new Size(130, 20);
            label4.TabIndex = 21;
            label4.Text = "Confirm Password:";
            // 
            // btn_sendcode
            // 
            btn_sendcode.BackColor = Color.FromArgb(34, 77, 83);
            btn_sendcode.FlatAppearance.BorderSize = 0;
            btn_sendcode.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 176, 161);
            btn_sendcode.FlatAppearance.MouseOverBackColor = Color.FromArgb(8, 176, 161);
            btn_sendcode.FlatStyle = FlatStyle.Flat;
            btn_sendcode.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_sendcode.ForeColor = Color.White;
            btn_sendcode.Location = new Point(232, 118);
            btn_sendcode.Name = "btn_sendcode";
            btn_sendcode.Size = new Size(143, 29);
            btn_sendcode.TabIndex = 17;
            btn_sendcode.Text = "SEND ";
            btn_sendcode.UseVisualStyleBackColor = false;
            btn_sendcode.Click += btn_sendcode_Click_1;
            // 
            // txt_NewPassword
            // 
            txt_NewPassword.Location = new Point(217, 299);
            txt_NewPassword.Name = "txt_NewPassword";
            txt_NewPassword.Size = new Size(173, 27);
            txt_NewPassword.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(217, 264);
            label3.Name = "label3";
            label3.Size = new Size(145, 20);
            label3.TabIndex = 19;
            label3.Text = "Enter New Password:";
            // 
            // btn_change
            // 
            btn_change.BackColor = Color.FromArgb(34, 77, 83);
            btn_change.FlatAppearance.BorderSize = 0;
            btn_change.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 176, 161);
            btn_change.FlatAppearance.MouseOverBackColor = Color.FromArgb(8, 176, 161);
            btn_change.FlatStyle = FlatStyle.Flat;
            btn_change.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_change.ForeColor = Color.White;
            btn_change.Location = new Point(227, 454);
            btn_change.Name = "btn_change";
            btn_change.Size = new Size(143, 29);
            btn_change.TabIndex = 18;
            btn_change.Text = "SUBMIT";
            btn_change.UseVisualStyleBackColor = false;
            btn_change.Click += btn_change_Click_1;
            // 
            // tbx_forget
            // 
            tbx_forget.Location = new Point(217, 209);
            tbx_forget.Name = "tbx_forget";
            tbx_forget.Size = new Size(173, 27);
            tbx_forget.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(217, 174);
            label2.Name = "label2";
            label2.Size = new Size(161, 20);
            label2.TabIndex = 15;
            label2.Text = "Enter verification code:";
            // 
            // ForgetPass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.blue_bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(603, 515);
            Controls.Add(panelVerification);
            Name = "ForgetPass";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgetPass";
            panelVerification.ResumeLayout(false);
            panelVerification.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelVerification;
        private TextBox txtConfirmPassword;
        private Label label4;
        private TextBox txt_NewPassword;
        private Label label3;
        private Button btn_change;
        private Button btn_sendcode;
        private TextBox tbx_forget;
        private Label label2;
        private TextBox tbx_email;
        private Label label1;
    }
}