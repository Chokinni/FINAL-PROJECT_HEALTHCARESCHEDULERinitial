namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class DoctorMeeting
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorMeeting));
            lbl_MyonlinemeetingDOC = new Label();
            btn_startmeeting = new Button();
            table_CreateMeeting = new DataGridView();
            btn_SCHEDULE = new Button();
            btn_loadschedmeet = new Button();
            btn_check = new Button();
            label1 = new Label();
            txt_searchPatient = new TextBox();
            ((System.ComponentModel.ISupportInitialize)table_CreateMeeting).BeginInit();
            SuspendLayout();
            // 
            // lbl_MyonlinemeetingDOC
            // 
            lbl_MyonlinemeetingDOC.AutoSize = true;
            lbl_MyonlinemeetingDOC.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_MyonlinemeetingDOC.Location = new Point(35, 23);
            lbl_MyonlinemeetingDOC.Name = "lbl_MyonlinemeetingDOC";
            lbl_MyonlinemeetingDOC.Size = new Size(209, 20);
            lbl_MyonlinemeetingDOC.TabIndex = 22;
            lbl_MyonlinemeetingDOC.Text = "MY ONLINE MEETINGS";
            // 
            // btn_startmeeting
            // 
            btn_startmeeting.BackColor = Color.SkyBlue;
            btn_startmeeting.FlatAppearance.BorderSize = 0;
            btn_startmeeting.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_startmeeting.Location = new Point(277, 543);
            btn_startmeeting.Name = "btn_startmeeting";
            btn_startmeeting.Size = new Size(195, 44);
            btn_startmeeting.TabIndex = 21;
            btn_startmeeting.Text = "START MEETING";
            btn_startmeeting.UseVisualStyleBackColor = false;
            btn_startmeeting.Click += btn_startmeeting_Click;
            // 
            // table_CreateMeeting
            // 
            table_CreateMeeting.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_CreateMeeting.Location = new Point(36, 119);
            table_CreateMeeting.Name = "table_CreateMeeting";
            table_CreateMeeting.RowHeadersWidth = 51;
            table_CreateMeeting.Size = new Size(754, 393);
            table_CreateMeeting.TabIndex = 20;
            // 
            // btn_SCHEDULE
            // 
            btn_SCHEDULE.BackColor = Color.SkyBlue;
            btn_SCHEDULE.FlatAppearance.BorderSize = 0;
            btn_SCHEDULE.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_SCHEDULE.Location = new Point(48, 543);
            btn_SCHEDULE.Name = "btn_SCHEDULE";
            btn_SCHEDULE.Size = new Size(197, 44);
            btn_SCHEDULE.TabIndex = 27;
            btn_SCHEDULE.Text = "SCHEDULE MEETING";
            btn_SCHEDULE.UseVisualStyleBackColor = false;
            btn_SCHEDULE.Click += btn_SCHEDULE_Click;
            // 
            // btn_loadschedmeet
            // 
            btn_loadschedmeet.BackColor = Color.SkyBlue;
            btn_loadschedmeet.FlatAppearance.BorderSize = 0;
            btn_loadschedmeet.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_loadschedmeet.Location = new Point(513, 543);
            btn_loadschedmeet.Name = "btn_loadschedmeet";
            btn_loadschedmeet.Size = new Size(176, 44);
            btn_loadschedmeet.TabIndex = 28;
            btn_loadschedmeet.Text = "LOAD SCHEDULE";
            btn_loadschedmeet.UseVisualStyleBackColor = false;
            btn_loadschedmeet.Click += btn_loadschedmeet_Click;
            // 
            // btn_check
            // 
            btn_check.BackColor = Color.Transparent;
            btn_check.BackgroundImage = (Image)resources.GetObject("btn_check.BackgroundImage");
            btn_check.BackgroundImageLayout = ImageLayout.Stretch;
            btn_check.Location = new Point(715, 543);
            btn_check.Name = "btn_check";
            btn_check.Size = new Size(49, 42);
            btn_check.TabIndex = 29;
            btn_check.UseVisualStyleBackColor = false;
            btn_check.Click += btn_check_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(65, 80);
            label1.Name = "label1";
            label1.Size = new Size(123, 18);
            label1.TabIndex = 31;
            label1.Text = "Search Patient:";
            // 
            // txt_searchPatient
            // 
            txt_searchPatient.Location = new Point(207, 76);
            txt_searchPatient.Multiline = true;
            txt_searchPatient.Name = "txt_searchPatient";
            txt_searchPatient.Size = new Size(177, 27);
            txt_searchPatient.TabIndex = 30;
            txt_searchPatient.TextChanged += txt_searchPatient_TextChanged;
            // 
            // DoctorMeeting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(txt_searchPatient);
            Controls.Add(btn_check);
            Controls.Add(btn_loadschedmeet);
            Controls.Add(btn_SCHEDULE);
            Controls.Add(lbl_MyonlinemeetingDOC);
            Controls.Add(btn_startmeeting);
            Controls.Add(table_CreateMeeting);
            Name = "DoctorMeeting";
            Size = new Size(1105, 676);
            ((System.ComponentModel.ISupportInitialize)table_CreateMeeting).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_MyonlinemeetingDOC;
        private Button btn_startmeeting;
        private DataGridView table_CreateMeeting;
        private Button btn_SCHEDULE;
        private Button btn_loadschedmeet;
        private Button btn_check;
        private Label label1;
        private TextBox txt_searchPatient;
    }
}
