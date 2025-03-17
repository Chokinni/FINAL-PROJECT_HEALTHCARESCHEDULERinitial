namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class Form1 : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            panel1 = new Panel();
            NEXT = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            lbl_exit = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(80, 68);
            label1.Name = "label1";
            label1.Size = new Size(454, 23);
            label1.TabIndex = 0;
            label1.Text = "HELLO! WELCOME TO MY HEALTHCARE SCHEDULER!";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(NEXT);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.ForeColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(241, 112);
            panel1.Name = "panel1";
            panel1.Size = new Size(609, 453);
            panel1.TabIndex = 1;
            // 
            // NEXT
            // 
            NEXT.Font = new Font("Swis721 Blk BT", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            NEXT.Location = new Point(221, 342);
            NEXT.Name = "NEXT";
            NEXT.Size = new Size(172, 29);
            NEXT.TabIndex = 4;
            NEXT.Text = "NEXT";
            NEXT.UseVisualStyleBackColor = true;
            NEXT.Click += NEXT_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.patient;
            pictureBox2.Location = new Point(333, 136);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(147, 161);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.pngwing_com;
            pictureBox1.Image = Properties.Resources.pngwing_com;
            pictureBox1.Location = new Point(134, 136);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(147, 161);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lbl_exit
            // 
            lbl_exit.AutoSize = true;
            lbl_exit.BackColor = Color.IndianRed;
            lbl_exit.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            lbl_exit.ForeColor = SystemColors.ActiveCaptionText;
            lbl_exit.Location = new Point(1036, 9);
            lbl_exit.Name = "lbl_exit";
            lbl_exit.Size = new Size(26, 28);
            lbl_exit.TabIndex = 2;
            lbl_exit.Text = "X";
            lbl_exit.Click += lbl_exit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1074, 662);
            Controls.Add(lbl_exit);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button NEXT;
        private Label lbl_exit;
    }
}
