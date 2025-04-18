namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class OnlineMeeting
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
            table_OnlinemeetingAppointment = new DataGridView();
            btn_join = new Button();
            lbl_Myonlinemeeting = new Label();
            btn_loadschedmeeting = new Button();
            ((System.ComponentModel.ISupportInitialize)table_OnlinemeetingAppointment).BeginInit();
            SuspendLayout();
            // 
            // table_OnlinemeetingAppointment
            // 
            table_OnlinemeetingAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_OnlinemeetingAppointment.Location = new Point(51, 84);
            table_OnlinemeetingAppointment.Name = "table_OnlinemeetingAppointment";
            table_OnlinemeetingAppointment.RowHeadersWidth = 51;
            table_OnlinemeetingAppointment.Size = new Size(754, 393);
            table_OnlinemeetingAppointment.TabIndex = 14;
            // 
            // btn_join
            // 
            btn_join.BackColor = Color.LimeGreen;
            btn_join.FlatAppearance.BorderSize = 0;
            btn_join.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_join.Location = new Point(239, 519);
            btn_join.Name = "btn_join";
            btn_join.Size = new Size(151, 29);
            btn_join.TabIndex = 18;
            btn_join.Text = "JOIN MEETING";
            btn_join.UseVisualStyleBackColor = false;
            btn_join.Click += btn_join_Click;
            // 
            // lbl_Myonlinemeeting
            // 
            lbl_Myonlinemeeting.AutoSize = true;
            lbl_Myonlinemeeting.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Myonlinemeeting.Location = new Point(51, 50);
            lbl_Myonlinemeeting.Name = "lbl_Myonlinemeeting";
            lbl_Myonlinemeeting.Size = new Size(209, 20);
            lbl_Myonlinemeeting.TabIndex = 19;
            lbl_Myonlinemeeting.Text = "MY ONLINE MEETINGS";
            // 
            // btn_loadschedmeeting
            // 
            btn_loadschedmeeting.BackColor = Color.LimeGreen;
            btn_loadschedmeeting.FlatAppearance.BorderSize = 0;
            btn_loadschedmeeting.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_loadschedmeeting.Location = new Point(407, 519);
            btn_loadschedmeeting.Name = "btn_loadschedmeeting";
            btn_loadschedmeeting.Size = new Size(161, 29);
            btn_loadschedmeeting.TabIndex = 20;
            btn_loadschedmeeting.Text = "LOAD SCHEDULE";
            btn_loadschedmeeting.UseVisualStyleBackColor = false;
            btn_loadschedmeeting.Click += btn_loadschedmeeting_Click;
            // 
            // OnlineMeeting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_loadschedmeeting);
            Controls.Add(lbl_Myonlinemeeting);
            Controls.Add(btn_join);
            Controls.Add(table_OnlinemeetingAppointment);
            Name = "OnlineMeeting";
            Size = new Size(1105, 676);
            ((System.ComponentModel.ISupportInitialize)table_OnlinemeetingAppointment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView table_OnlinemeetingAppointment;
        private Button btn_join;
        private Label lbl_Myonlinemeeting;
        private Button btn_loadschedmeeting;
    }
}
