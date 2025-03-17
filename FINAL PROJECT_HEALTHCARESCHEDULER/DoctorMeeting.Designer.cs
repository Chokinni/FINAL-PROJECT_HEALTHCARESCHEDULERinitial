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
            lbl_MyonlinemeetingDOC = new Label();
            btn_startmeeting = new Button();
            table_CreateMeeting = new DataGridView();
            lbl_datetime = new Label();
            lbl_meetinglink = new Label();
            tbx_link = new TextBox();
            btn_SCHEDULE = new Button();
            btn_loadschedmeet = new Button();
            datetime_meetapp = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)table_CreateMeeting).BeginInit();
            SuspendLayout();
            // 
            // lbl_MyonlinemeetingDOC
            // 
            lbl_MyonlinemeetingDOC.AutoSize = true;
            lbl_MyonlinemeetingDOC.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_MyonlinemeetingDOC.Location = new Point(36, 39);
            lbl_MyonlinemeetingDOC.Name = "lbl_MyonlinemeetingDOC";
            lbl_MyonlinemeetingDOC.Size = new Size(209, 20);
            lbl_MyonlinemeetingDOC.TabIndex = 22;
            lbl_MyonlinemeetingDOC.Text = "MY ONLINE MEETINGS";
            // 
            // btn_startmeeting
            // 
            btn_startmeeting.BackColor = Color.LimeGreen;
            btn_startmeeting.FlatAppearance.BorderSize = 0;
            btn_startmeeting.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_startmeeting.Location = new Point(293, 561);
            btn_startmeeting.Name = "btn_startmeeting";
            btn_startmeeting.Size = new Size(179, 29);
            btn_startmeeting.TabIndex = 21;
            btn_startmeeting.Text = "START MEETING";
            btn_startmeeting.UseVisualStyleBackColor = false;
            // 
            // table_CreateMeeting
            // 
            table_CreateMeeting.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_CreateMeeting.Location = new Point(36, 73);
            table_CreateMeeting.Name = "table_CreateMeeting";
            table_CreateMeeting.RowHeadersWidth = 51;
            table_CreateMeeting.Size = new Size(754, 393);
            table_CreateMeeting.TabIndex = 20;
            // 
            // lbl_datetime
            // 
            lbl_datetime.AutoSize = true;
            lbl_datetime.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_datetime.Location = new Point(51, 492);
            lbl_datetime.Name = "lbl_datetime";
            lbl_datetime.Size = new Size(134, 18);
            lbl_datetime.TabIndex = 23;
            lbl_datetime.Text = "DATE AND TIME";
            // 
            // lbl_meetinglink
            // 
            lbl_meetinglink.AutoSize = true;
            lbl_meetinglink.Location = new Point(500, 490);
            lbl_meetinglink.Name = "lbl_meetinglink";
            lbl_meetinglink.Size = new Size(106, 20);
            lbl_meetinglink.TabIndex = 25;
            lbl_meetinglink.Text = "MEETING LINK";
            // 
            // tbx_link
            // 
            tbx_link.Location = new Point(612, 487);
            tbx_link.Name = "tbx_link";
            tbx_link.Size = new Size(125, 27);
            tbx_link.TabIndex = 26;
            // 
            // btn_SCHEDULE
            // 
            btn_SCHEDULE.BackColor = Color.LimeGreen;
            btn_SCHEDULE.FlatAppearance.BorderSize = 0;
            btn_SCHEDULE.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_SCHEDULE.Location = new Point(51, 561);
            btn_SCHEDULE.Name = "btn_SCHEDULE";
            btn_SCHEDULE.Size = new Size(196, 29);
            btn_SCHEDULE.TabIndex = 27;
            btn_SCHEDULE.Text = "SCHEDULE MEETING";
            btn_SCHEDULE.UseVisualStyleBackColor = false;
            // 
            // btn_loadschedmeet
            // 
            btn_loadschedmeet.BackColor = Color.LimeGreen;
            btn_loadschedmeet.FlatAppearance.BorderSize = 0;
            btn_loadschedmeet.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_loadschedmeet.Location = new Point(530, 561);
            btn_loadschedmeet.Name = "btn_loadschedmeet";
            btn_loadschedmeet.Size = new Size(174, 29);
            btn_loadschedmeet.TabIndex = 28;
            btn_loadschedmeet.Text = "LOAD SCHEDULE";
            btn_loadschedmeet.UseVisualStyleBackColor = false;
            // 
            // datetime_meetapp
            // 
            datetime_meetapp.Location = new Point(204, 486);
            datetime_meetapp.Name = "datetime_meetapp";
            datetime_meetapp.Size = new Size(247, 27);
            datetime_meetapp.TabIndex = 29;
            // 
            // DoctorMeeting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(datetime_meetapp);
            Controls.Add(btn_loadschedmeet);
            Controls.Add(btn_SCHEDULE);
            Controls.Add(tbx_link);
            Controls.Add(lbl_meetinglink);
            Controls.Add(lbl_datetime);
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
        private Label lbl_datetime;
        private Label lbl_meetinglink;
        private TextBox tbx_link;
        private Button btn_SCHEDULE;
        private Button btn_loadschedmeet;
        private DateTimePicker datetime_meetapp;
    }
}
