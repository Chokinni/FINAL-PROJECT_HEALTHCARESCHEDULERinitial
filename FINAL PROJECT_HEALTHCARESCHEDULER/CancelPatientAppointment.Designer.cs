namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class CancelPatientAppointment
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
            btn_cancelpatientAppointment = new Button();
            table_CancelpatientAppointment = new DataGridView();
            btn_loadschedforcancel = new Button();
            btn_delete = new Button();
            ((System.ComponentModel.ISupportInitialize)table_CancelpatientAppointment).BeginInit();
            SuspendLayout();
            // 
            // btn_cancelpatientAppointment
            // 
            btn_cancelpatientAppointment.BackColor = Color.LimeGreen;
            btn_cancelpatientAppointment.FlatAppearance.BorderSize = 0;
            btn_cancelpatientAppointment.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cancelpatientAppointment.Location = new Point(127, 470);
            btn_cancelpatientAppointment.Margin = new Padding(4, 3, 4, 3);
            btn_cancelpatientAppointment.Name = "btn_cancelpatientAppointment";
            btn_cancelpatientAppointment.Size = new Size(154, 26);
            btn_cancelpatientAppointment.TabIndex = 23;
            btn_cancelpatientAppointment.Text = "CANCEL";
            btn_cancelpatientAppointment.UseVisualStyleBackColor = false;
            btn_cancelpatientAppointment.Click += btn_cancelpatientAppointment_Click;
            // 
            // table_CancelpatientAppointment
            // 
            table_CancelpatientAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_CancelpatientAppointment.Location = new Point(38, 50);
            table_CancelpatientAppointment.Margin = new Padding(4, 3, 4, 3);
            table_CancelpatientAppointment.Name = "table_CancelpatientAppointment";
            table_CancelpatientAppointment.RowHeadersWidth = 51;
            table_CancelpatientAppointment.Size = new Size(754, 393);
            table_CancelpatientAppointment.TabIndex = 19;
            // 
            // btn_loadschedforcancel
            // 
            btn_loadschedforcancel.BackColor = Color.LimeGreen;
            btn_loadschedforcancel.FlatAppearance.BorderSize = 0;
            btn_loadschedforcancel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_loadschedforcancel.Location = new Point(316, 470);
            btn_loadschedforcancel.Margin = new Padding(4, 3, 4, 3);
            btn_loadschedforcancel.Name = "btn_loadschedforcancel";
            btn_loadschedforcancel.Size = new Size(197, 26);
            btn_loadschedforcancel.TabIndex = 25;
            btn_loadschedforcancel.Text = "LOAD SCHEDULE";
            btn_loadschedforcancel.UseVisualStyleBackColor = false;
            btn_loadschedforcancel.Click += btn_loadschedforcancel_Click;
            // 
            // btn_delete
            // 
            btn_delete.BackColor = Color.LimeGreen;
            btn_delete.FlatAppearance.BorderSize = 0;
            btn_delete.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_delete.Location = new Point(536, 470);
            btn_delete.Margin = new Padding(4, 3, 4, 3);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(197, 26);
            btn_delete.TabIndex = 26;
            btn_delete.Text = "DELETE";
            btn_delete.UseVisualStyleBackColor = false;
            btn_delete.Click += btn_delete_Click;
            // 
            // CancelPatientAppointment
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_delete);
            Controls.Add(btn_loadschedforcancel);
            Controls.Add(btn_cancelpatientAppointment);
            Controls.Add(table_CancelpatientAppointment);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CancelPatientAppointment";
            Size = new Size(1105, 676);
            ((System.ComponentModel.ISupportInitialize)table_CancelpatientAppointment).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btn_cancelpatientAppointment;
        private DataGridView table_CancelpatientAppointment;
        private Button btn_loadschedforcancel;
        private Button btn_delete;
    }
}
