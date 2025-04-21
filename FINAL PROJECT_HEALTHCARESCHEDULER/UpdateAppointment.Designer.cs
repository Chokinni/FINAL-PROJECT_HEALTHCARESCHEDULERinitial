namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class UpdateAppointment
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
            components = new System.ComponentModel.Container();
            table_UpdateAppointment = new DataGridView();
            lbl_datetime = new Label();
            datetime_sched = new DateTimePicker();
            btn_update = new Button();
            btn_LoadSchedule = new Button();
            rxt_searchDoctor = new TextBox();
            label1 = new Label();
            strip_viewdocprof = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)table_UpdateAppointment).BeginInit();
            SuspendLayout();
            // 
            // table_UpdateAppointment
            // 
            table_UpdateAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_UpdateAppointment.Location = new Point(53, 67);
            table_UpdateAppointment.Name = "table_UpdateAppointment";
            table_UpdateAppointment.RowHeadersWidth = 51;
            table_UpdateAppointment.Size = new Size(754, 393);
            table_UpdateAppointment.TabIndex = 0;
            // 
            // lbl_datetime
            // 
            lbl_datetime.AutoSize = true;
            lbl_datetime.Location = new Point(256, 499);
            lbl_datetime.Name = "lbl_datetime";
            lbl_datetime.Size = new Size(107, 20);
            lbl_datetime.TabIndex = 3;
            lbl_datetime.Text = "Date and Time";
            // 
            // datetime_sched
            // 
            datetime_sched.Location = new Point(369, 494);
            datetime_sched.Name = "datetime_sched";
            datetime_sched.Size = new Size(240, 27);
            datetime_sched.TabIndex = 7;
            datetime_sched.ValueChanged += datetime_sched_ValueChanged;
            // 
            // btn_update
            // 
            btn_update.BackColor = Color.SkyBlue;
            btn_update.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_update.Location = new Point(216, 556);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(147, 37);
            btn_update.TabIndex = 9;
            btn_update.Text = "UPDATE";
            btn_update.UseVisualStyleBackColor = false;
            btn_update.Click += btn_update_Click;
            // 
            // btn_LoadSchedule
            // 
            btn_LoadSchedule.BackColor = Color.SkyBlue;
            btn_LoadSchedule.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_LoadSchedule.Location = new Point(416, 556);
            btn_LoadSchedule.Name = "btn_LoadSchedule";
            btn_LoadSchedule.Size = new Size(182, 37);
            btn_LoadSchedule.TabIndex = 13;
            btn_LoadSchedule.Text = "LOAD SCHEDULE";
            btn_LoadSchedule.UseVisualStyleBackColor = false;
            btn_LoadSchedule.Click += btn_LoadSchedule_Click;
            // 
            // rxt_searchDoctor
            // 
            rxt_searchDoctor.Location = new Point(216, 25);
            rxt_searchDoctor.Multiline = true;
            rxt_searchDoctor.Name = "rxt_searchDoctor";
            rxt_searchDoctor.Size = new Size(177, 27);
            rxt_searchDoctor.TabIndex = 14;
            rxt_searchDoctor.TextChanged += rxt_searchDoctor_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(74, 29);
            label1.Name = "label1";
            label1.Size = new Size(123, 18);
            label1.TabIndex = 23;
            label1.Text = "Search Doctor:";
            // 
            // strip_viewdocprof
            // 
            strip_viewdocprof.ImageScalingSize = new Size(20, 20);
            strip_viewdocprof.Name = "strip_viewdocprof";
            strip_viewdocprof.Size = new Size(61, 4);
            strip_viewdocprof.Opening += strip_viewdocprof_Opening;
            // 
            // UpdateAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ContextMenuStrip = strip_viewdocprof;
            Controls.Add(label1);
            Controls.Add(rxt_searchDoctor);
            Controls.Add(btn_LoadSchedule);
            Controls.Add(btn_update);
            Controls.Add(datetime_sched);
            Controls.Add(lbl_datetime);
            Controls.Add(table_UpdateAppointment);
            Name = "UpdateAppointment";
            Size = new Size(1105, 676);
            Load += UpdateAppointment_Load;
            ((System.ComponentModel.ISupportInitialize)table_UpdateAppointment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView table_UpdateAppointment;
        private Label lbl_datetime;
        private DateTimePicker datetime_sched;
        private Button btn_update;
        private Button btn_LoadSchedule;
        private TextBox rxt_searchDoctor;
        private Label label1;
        private ContextMenuStrip strip_viewdocprof;
    }
}
