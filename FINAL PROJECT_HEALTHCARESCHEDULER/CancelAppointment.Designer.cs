namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class CancelAppointment
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
            tbx_doctorupdate = new TextBox();
            btn_cancel = new Button();
            datetime_sched = new DateTimePicker();
            lbl_datetime = new Label();
            lbl_docname = new Label();
            table_CancelAppointment = new DataGridView();
            btn_LoadAppCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)table_CancelAppointment).BeginInit();
            SuspendLayout();
            // 
            // tbx_doctorupdate
            // 
            tbx_doctorupdate.Location = new Point(170, 469);
            tbx_doctorupdate.Name = "tbx_doctorupdate";
            tbx_doctorupdate.Size = new Size(125, 27);
            tbx_doctorupdate.TabIndex = 18;
            // 
            // btn_cancel
            // 
            btn_cancel.BackColor = Color.LimeGreen;
            btn_cancel.FlatAppearance.BorderSize = 0;
            btn_cancel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cancel.Location = new Point(186, 537);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(173, 29);
            btn_cancel.TabIndex = 17;
            btn_cancel.Text = "CANCEL";
            btn_cancel.UseVisualStyleBackColor = false;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // datetime_sched
            // 
            datetime_sched.Location = new Point(513, 469);
            datetime_sched.Name = "datetime_sched";
            datetime_sched.Size = new Size(240, 27);
            datetime_sched.TabIndex = 16;
            // 
            // lbl_datetime
            // 
            lbl_datetime.AutoSize = true;
            lbl_datetime.Location = new Point(400, 474);
            lbl_datetime.Name = "lbl_datetime";
            lbl_datetime.Size = new Size(107, 20);
            lbl_datetime.TabIndex = 15;
            lbl_datetime.Text = "Date and Time";
            // 
            // lbl_docname
            // 
            lbl_docname.AutoSize = true;
            lbl_docname.Location = new Point(100, 469);
            lbl_docname.Name = "lbl_docname";
            lbl_docname.Size = new Size(55, 20);
            lbl_docname.TabIndex = 14;
            lbl_docname.Text = "Doctor";
            // 
            // table_CancelAppointment
            // 
            table_CancelAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_CancelAppointment.Location = new Point(49, 40);
            table_CancelAppointment.Name = "table_CancelAppointment";
            table_CancelAppointment.RowHeadersWidth = 51;
            table_CancelAppointment.Size = new Size(754, 393);
            table_CancelAppointment.TabIndex = 13;
            // 
            // btn_LoadAppCancel
            // 
            btn_LoadAppCancel.BackColor = Color.LimeGreen;
            btn_LoadAppCancel.FlatAppearance.BorderSize = 0;
            btn_LoadAppCancel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_LoadAppCancel.Location = new Point(403, 537);
            btn_LoadAppCancel.Name = "btn_LoadAppCancel";
            btn_LoadAppCancel.Size = new Size(235, 29);
            btn_LoadAppCancel.TabIndex = 19;
            btn_LoadAppCancel.Text = "Load Schedule";
            btn_LoadAppCancel.UseVisualStyleBackColor = false;
            // 
            // CancelAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            Controls.Add(btn_LoadAppCancel);
            Controls.Add(tbx_doctorupdate);
            Controls.Add(btn_cancel);
            Controls.Add(datetime_sched);
            Controls.Add(lbl_datetime);
            Controls.Add(lbl_docname);
            Controls.Add(table_CancelAppointment);
            Name = "CancelAppointment";
            Size = new Size(1105, 676);
            ((System.ComponentModel.ISupportInitialize)table_CancelAppointment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbx_doctorupdate;
        private Button btn_cancel;
        private DateTimePicker datetime_sched;
        private Label lbl_datetime;
        private Label lbl_docname;
        private DataGridView table_CancelAppointment;
        private Button btn_LoadAppCancel;
    }
}
