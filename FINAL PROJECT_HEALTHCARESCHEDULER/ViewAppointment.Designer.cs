namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class ViewAppointment
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
            table_ViewPatientAppointment = new DataGridView();
            lbl_noAppointment = new Label();
            btn_loadAppointments = new Button();
            ((System.ComponentModel.ISupportInitialize)table_ViewPatientAppointment).BeginInit();
            SuspendLayout();
            // 
            // table_ViewPatientAppointment
            // 
            table_ViewPatientAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_ViewPatientAppointment.Location = new Point(41, 32);
            table_ViewPatientAppointment.Name = "table_ViewPatientAppointment";
            table_ViewPatientAppointment.RowHeadersWidth = 51;
            table_ViewPatientAppointment.Size = new Size(754, 393);
            table_ViewPatientAppointment.TabIndex = 14;
            // 
            // lbl_noAppointment
            // 
            lbl_noAppointment.AutoSize = true;
            lbl_noAppointment.Location = new Point(75, 454);
            lbl_noAppointment.Name = "lbl_noAppointment";
            lbl_noAppointment.Size = new Size(162, 20);
            lbl_noAppointment.TabIndex = 16;
            lbl_noAppointment.Text = "YOUR APPOINTMENTS!";
            // 
            // btn_loadAppointments
            // 
            btn_loadAppointments.BackColor = Color.LimeGreen;
            btn_loadAppointments.FlatAppearance.BorderSize = 0;
            btn_loadAppointments.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_loadAppointments.Location = new Point(321, 450);
            btn_loadAppointments.Name = "btn_loadAppointments";
            btn_loadAppointments.Size = new Size(161, 29);
            btn_loadAppointments.TabIndex = 19;
            btn_loadAppointments.Text = "LOAD SCHEDULE";
            btn_loadAppointments.UseVisualStyleBackColor = false;
            // 
            // ViewAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_loadAppointments);
            Controls.Add(lbl_noAppointment);
            Controls.Add(table_ViewPatientAppointment);
            Name = "ViewAppointment";
            Size = new Size(1105, 676);
            ((System.ComponentModel.ISupportInitialize)table_ViewPatientAppointment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView table_ViewPatientAppointment;
        private Label lbl_noAppointment;
        private Button btn_loadAppointments;
    }
}
