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
            label1 = new Label();
            txt_searchPatient = new TextBox();
            ((System.ComponentModel.ISupportInitialize)table_CancelpatientAppointment).BeginInit();
            SuspendLayout();
            // 
            // btn_cancelpatientAppointment
            // 
            btn_cancelpatientAppointment.BackColor = Color.SkyBlue;
            btn_cancelpatientAppointment.FlatAppearance.BorderSize = 0;
            btn_cancelpatientAppointment.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cancelpatientAppointment.Location = new Point(129, 503);
            btn_cancelpatientAppointment.Margin = new Padding(4, 3, 4, 3);
            btn_cancelpatientAppointment.Name = "btn_cancelpatientAppointment";
            btn_cancelpatientAppointment.Size = new Size(154, 35);
            btn_cancelpatientAppointment.TabIndex = 23;
            btn_cancelpatientAppointment.Text = "CANCEL";
            btn_cancelpatientAppointment.UseVisualStyleBackColor = false;
            btn_cancelpatientAppointment.Click += btn_cancelpatientAppointment_Click;
            // 
            // table_CancelpatientAppointment
            // 
            table_CancelpatientAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_CancelpatientAppointment.Location = new Point(40, 83);
            table_CancelpatientAppointment.Margin = new Padding(4, 3, 4, 3);
            table_CancelpatientAppointment.Name = "table_CancelpatientAppointment";
            table_CancelpatientAppointment.RowHeadersWidth = 51;
            table_CancelpatientAppointment.Size = new Size(754, 393);
            table_CancelpatientAppointment.TabIndex = 19;
            // 
            // btn_loadschedforcancel
            // 
            btn_loadschedforcancel.BackColor = Color.SkyBlue;
            btn_loadschedforcancel.FlatAppearance.BorderSize = 0;
            btn_loadschedforcancel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_loadschedforcancel.Location = new Point(318, 503);
            btn_loadschedforcancel.Margin = new Padding(4, 3, 4, 3);
            btn_loadschedforcancel.Name = "btn_loadschedforcancel";
            btn_loadschedforcancel.Size = new Size(197, 35);
            btn_loadschedforcancel.TabIndex = 25;
            btn_loadschedforcancel.Text = "LOAD SCHEDULE";
            btn_loadschedforcancel.UseVisualStyleBackColor = false;
            btn_loadschedforcancel.Click += btn_loadschedforcancel_Click;
            // 
            // btn_delete
            // 
            btn_delete.BackColor = Color.SkyBlue;
            btn_delete.FlatAppearance.BorderSize = 0;
            btn_delete.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_delete.Location = new Point(542, 507);
            btn_delete.Margin = new Padding(4, 3, 4, 3);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(197, 31);
            btn_delete.TabIndex = 26;
            btn_delete.Text = "DELETE";
            btn_delete.UseVisualStyleBackColor = false;
            btn_delete.Click += btn_delete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(51, 40);
            label1.Name = "label1";
            label1.Size = new Size(123, 18);
            label1.TabIndex = 29;
            label1.Text = "Search Patient:";
            // 
            // txt_searchPatient
            // 
            txt_searchPatient.Location = new Point(193, 36);
            txt_searchPatient.Multiline = true;
            txt_searchPatient.Name = "txt_searchPatient";
            txt_searchPatient.Size = new Size(177, 27);
            txt_searchPatient.TabIndex = 28;
            txt_searchPatient.TextChanged += txt_searchPatient_TextChanged;
            // 
            // CancelPatientAppointment
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(txt_searchPatient);
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
            PerformLayout();
        }

        #endregion
        private Button btn_cancelpatientAppointment;
        private DataGridView table_CancelpatientAppointment;
        private Button btn_loadschedforcancel;
        private Button btn_delete;
        private Label label1;
        private TextBox txt_searchPatient;
    }
}
