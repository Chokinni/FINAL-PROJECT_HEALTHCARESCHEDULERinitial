namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class UpcomingSchedule
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
            table_UpcomingSched = new DataGridView();
            lbl_noAppointment = new Label();
            btn_refresh = new Button();
            btn_loadUpcoming = new Button();
            ((System.ComponentModel.ISupportInitialize)table_UpcomingSched).BeginInit();
            SuspendLayout();
            // 
            // table_UpcomingSched
            // 
            table_UpcomingSched.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_UpcomingSched.Location = new Point(48, 64);
            table_UpcomingSched.Name = "table_UpcomingSched";
            table_UpcomingSched.RowHeadersWidth = 51;
            table_UpcomingSched.Size = new Size(679, 334);
            table_UpcomingSched.TabIndex = 14;
            // 
            // lbl_noAppointment
            // 
            lbl_noAppointment.AutoSize = true;
            lbl_noAppointment.Location = new Point(63, 430);
            lbl_noAppointment.Name = "lbl_noAppointment";
            lbl_noAppointment.Size = new Size(228, 20);
            lbl_noAppointment.TabIndex = 15;
            lbl_noAppointment.Text = "NO APPOINTMENTS FOR TODAY!";
            // 
            // btn_refresh
            // 
            btn_refresh.BackColor = Color.LimeGreen;
            btn_refresh.FlatAppearance.BorderSize = 0;
            btn_refresh.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_refresh.Location = new Point(367, 426);
            btn_refresh.Name = "btn_refresh";
            btn_refresh.Size = new Size(143, 29);
            btn_refresh.TabIndex = 18;
            btn_refresh.Text = "REFRESH";
            btn_refresh.UseVisualStyleBackColor = false;
            // 
            // btn_loadUpcoming
            // 
            btn_loadUpcoming.BackColor = Color.LimeGreen;
            btn_loadUpcoming.FlatAppearance.BorderSize = 0;
            btn_loadUpcoming.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_loadUpcoming.Location = new Point(532, 426);
            btn_loadUpcoming.Name = "btn_loadUpcoming";
            btn_loadUpcoming.Size = new Size(159, 29);
            btn_loadUpcoming.TabIndex = 19;
            btn_loadUpcoming.Text = "LOAD SCHEDULE";
            btn_loadUpcoming.UseVisualStyleBackColor = false;
            // 
            // UpcomingSchedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_loadUpcoming);
            Controls.Add(btn_refresh);
            Controls.Add(lbl_noAppointment);
            Controls.Add(table_UpcomingSched);
            Name = "UpcomingSchedule";
            Size = new Size(1105, 676);
            ((System.ComponentModel.ISupportInitialize)table_UpcomingSched).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView table_UpcomingSched;
        private Label lbl_noAppointment;
        private Button btn_refresh;
        private Button btn_loadUpcoming;
    }
}
