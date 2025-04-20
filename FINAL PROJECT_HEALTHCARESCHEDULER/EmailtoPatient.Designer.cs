namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class EmailtoPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailtoPatient));
            lbl_to = new Label();
            label2 = new Label();
            label3 = new Label();
            tbx_To = new TextBox();
            tbx_subject = new TextBox();
            richbox_message = new RichTextBox();
            btn_submit = new Button();
            picture_attach = new PictureBox();
            lb_Attachment = new Label();
            lbl_exitdoctor = new Label();
            ((System.ComponentModel.ISupportInitialize)picture_attach).BeginInit();
            SuspendLayout();
            // 
            // lbl_to
            // 
            lbl_to.AutoSize = true;
            lbl_to.BackColor = Color.Transparent;
            lbl_to.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lbl_to.ForeColor = Color.Yellow;
            lbl_to.Location = new Point(95, 24);
            lbl_to.Name = "lbl_to";
            lbl_to.Size = new Size(36, 20);
            lbl_to.TabIndex = 0;
            lbl_to.Text = "To:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Yellow;
            label2.Location = new Point(94, 122);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 1;
            label2.Text = "Subject:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Yellow;
            label3.Location = new Point(95, 238);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 2;
            label3.Text = "Message";
            // 
            // tbx_To
            // 
            tbx_To.Location = new Point(110, 55);
            tbx_To.Multiline = true;
            tbx_To.Name = "tbx_To";
            tbx_To.Size = new Size(151, 34);
            tbx_To.TabIndex = 3;
            // 
            // tbx_subject
            // 
            tbx_subject.Location = new Point(110, 154);
            tbx_subject.Multiline = true;
            tbx_subject.Name = "tbx_subject";
            tbx_subject.Size = new Size(151, 34);
            tbx_subject.TabIndex = 4;
            // 
            // richbox_message
            // 
            richbox_message.Location = new Point(95, 277);
            richbox_message.Name = "richbox_message";
            richbox_message.Size = new Size(595, 207);
            richbox_message.TabIndex = 5;
            richbox_message.Text = "";
            // 
            // btn_submit
            // 
            btn_submit.BackColor = Color.Aqua;
            btn_submit.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_submit.ForeColor = Color.Black;
            btn_submit.Location = new Point(95, 540);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(94, 36);
            btn_submit.TabIndex = 33;
            btn_submit.Text = "SUBMIT";
            btn_submit.UseVisualStyleBackColor = false;
            btn_submit.Click += btn_submit_Click;
            // 
            // picture_attach
            // 
            picture_attach.BackColor = Color.Transparent;
            picture_attach.BackgroundImage = (Image)resources.GetObject("picture_attach.BackgroundImage");
            picture_attach.BackgroundImageLayout = ImageLayout.Stretch;
            picture_attach.Location = new Point(197, 535);
            picture_attach.Name = "picture_attach";
            picture_attach.Size = new Size(38, 41);
            picture_attach.TabIndex = 34;
            picture_attach.TabStop = false;
            picture_attach.Click += picture_attach_Click;
            // 
            // lb_Attachment
            // 
            lb_Attachment.AutoSize = true;
            lb_Attachment.BackColor = Color.Transparent;
            lb_Attachment.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Attachment.Location = new Point(261, 548);
            lb_Attachment.Name = "lb_Attachment";
            lb_Attachment.Size = new Size(59, 20);
            lb_Attachment.TabIndex = 35;
            lb_Attachment.Text = "label1";
            lb_Attachment.Click += lb_Attachment_Click;
            // 
            // lbl_exitdoctor
            // 
            lbl_exitdoctor.AutoSize = true;
            lbl_exitdoctor.BackColor = Color.Red;
            lbl_exitdoctor.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lbl_exitdoctor.ForeColor = Color.Black;
            lbl_exitdoctor.Location = new Point(977, 7);
            lbl_exitdoctor.Name = "lbl_exitdoctor";
            lbl_exitdoctor.Size = new Size(27, 25);
            lbl_exitdoctor.TabIndex = 36;
            lbl_exitdoctor.Text = "X";
            lbl_exitdoctor.Click += lbl_exitdoctor_Click;
            // 
            // EmailtoPatient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.blue_bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1016, 637);
            Controls.Add(lbl_exitdoctor);
            Controls.Add(lb_Attachment);
            Controls.Add(picture_attach);
            Controls.Add(btn_submit);
            Controls.Add(richbox_message);
            Controls.Add(tbx_subject);
            Controls.Add(tbx_To);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lbl_to);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmailtoPatient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmailtoPatient";
            ((System.ComponentModel.ISupportInitialize)picture_attach).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_to;
        private Label label2;
        private Label label3;
        private TextBox tbx_To;
        private TextBox tbx_subject;
        private RichTextBox richbox_message;
        private Button btn_submit;
        private PictureBox picture_attach;
        private Label lb_Attachment;
        private Label lbl_exitdoctor;
    }
}