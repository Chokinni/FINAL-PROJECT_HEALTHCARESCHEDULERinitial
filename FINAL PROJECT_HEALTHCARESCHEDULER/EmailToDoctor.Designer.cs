namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class EmailToDoctor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailToDoctor));
            lb_Attachment = new Label();
            picture_attach = new PictureBox();
            btn_submit = new Button();
            richbox_message = new RichTextBox();
            tbx_subject = new TextBox();
            tbx_To = new TextBox();
            label3 = new Label();
            label2 = new Label();
            lbl_to = new Label();
            lbl_exitdoctor = new Label();
            ((System.ComponentModel.ISupportInitialize)picture_attach).BeginInit();
            SuspendLayout();
            // 
            // lb_Attachment
            // 
            lb_Attachment.AutoSize = true;
            lb_Attachment.BackColor = Color.Transparent;
            lb_Attachment.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Attachment.Location = new Point(276, 553);
            lb_Attachment.Name = "lb_Attachment";
            lb_Attachment.Size = new Size(59, 20);
            lb_Attachment.TabIndex = 44;
            lb_Attachment.Text = "label1";
            // 
            // picture_attach
            // 
            picture_attach.BackColor = Color.Transparent;
            picture_attach.BackgroundImage = (Image)resources.GetObject("picture_attach.BackgroundImage");
            picture_attach.BackgroundImageLayout = ImageLayout.Stretch;
            picture_attach.Location = new Point(212, 540);
            picture_attach.Name = "picture_attach";
            picture_attach.Size = new Size(38, 41);
            picture_attach.TabIndex = 43;
            picture_attach.TabStop = false;
            // 
            // btn_submit
            // 
            btn_submit.BackColor = Color.Aqua;
            btn_submit.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_submit.ForeColor = Color.Black;
            btn_submit.Location = new Point(110, 545);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(94, 36);
            btn_submit.TabIndex = 42;
            btn_submit.Text = "SUBMIT";
            btn_submit.UseVisualStyleBackColor = false;
            btn_submit.Click += btn_submit_Click_1;
            // 
            // richbox_message
            // 
            richbox_message.Location = new Point(110, 282);
            richbox_message.Name = "richbox_message";
            richbox_message.Size = new Size(595, 207);
            richbox_message.TabIndex = 41;
            richbox_message.Text = "";
            // 
            // tbx_subject
            // 
            tbx_subject.Location = new Point(125, 159);
            tbx_subject.Multiline = true;
            tbx_subject.Name = "tbx_subject";
            tbx_subject.Size = new Size(151, 34);
            tbx_subject.TabIndex = 40;
            // 
            // tbx_To
            // 
            tbx_To.Location = new Point(125, 60);
            tbx_To.Multiline = true;
            tbx_To.Name = "tbx_To";
            tbx_To.Size = new Size(151, 34);
            tbx_To.TabIndex = 39;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Yellow;
            label3.Location = new Point(110, 243);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 38;
            label3.Text = "Message";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Yellow;
            label2.Location = new Point(109, 127);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 37;
            label2.Text = "Subject:";
            // 
            // lbl_to
            // 
            lbl_to.AutoSize = true;
            lbl_to.BackColor = Color.Transparent;
            lbl_to.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lbl_to.ForeColor = Color.Yellow;
            lbl_to.Location = new Point(110, 29);
            lbl_to.Name = "lbl_to";
            lbl_to.Size = new Size(36, 20);
            lbl_to.TabIndex = 36;
            lbl_to.Text = "To:";
            // 
            // lbl_exitdoctor
            // 
            lbl_exitdoctor.AutoSize = true;
            lbl_exitdoctor.BackColor = Color.Red;
            lbl_exitdoctor.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lbl_exitdoctor.ForeColor = Color.Black;
            lbl_exitdoctor.Location = new Point(977, 9);
            lbl_exitdoctor.Name = "lbl_exitdoctor";
            lbl_exitdoctor.Size = new Size(27, 25);
            lbl_exitdoctor.TabIndex = 45;
            lbl_exitdoctor.Text = "X";
            lbl_exitdoctor.Click += lbl_exitdoctor_Click_1;
            // 
            // EmailToDoctor
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
            Name = "EmailToDoctor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmailToDoctor";
            ((System.ComponentModel.ISupportInitialize)picture_attach).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_Attachment;
        private PictureBox picture_attach;
        private Button btn_submit;
        private RichTextBox richbox_message;
        private TextBox tbx_subject;
        private TextBox tbx_To;
        private Label label3;
        private Label label2;
        private Label lbl_to;
        private Label lbl_exitdoctor;
    }
}