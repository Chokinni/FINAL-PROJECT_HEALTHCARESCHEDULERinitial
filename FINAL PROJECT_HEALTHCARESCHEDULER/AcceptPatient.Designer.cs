namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class AcceptPatient
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
            btn_confirm = new Button();
            table_AcceptAppointment = new DataGridView();
            btn_loadscheddoc = new Button();
            Patient_profilestrip = new ContextMenuStrip(components);
            viewPatientProfileToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)table_AcceptAppointment).BeginInit();
            Patient_profilestrip.SuspendLayout();
            SuspendLayout();
            // 
            // btn_confirm
            // 
            btn_confirm.BackColor = Color.LimeGreen;
            btn_confirm.FlatAppearance.BorderSize = 0;
            btn_confirm.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_confirm.Location = new Point(187, 502);
            btn_confirm.Name = "btn_confirm";
            btn_confirm.Size = new Size(236, 29);
            btn_confirm.TabIndex = 20;
            btn_confirm.Text = "CONFIRM APPOINTMENT";
            btn_confirm.UseVisualStyleBackColor = false;
            btn_confirm.Click += btn_confirm_Click;
            // 
            // table_AcceptAppointment
            // 
            table_AcceptAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_AcceptAppointment.Location = new Point(55, 58);
            table_AcceptAppointment.Name = "table_AcceptAppointment";
            table_AcceptAppointment.RowHeadersWidth = 51;
            table_AcceptAppointment.Size = new Size(754, 393);
            table_AcceptAppointment.TabIndex = 19;
            // 
            // btn_loadscheddoc
            // 
            btn_loadscheddoc.BackColor = Color.LimeGreen;
            btn_loadscheddoc.FlatAppearance.BorderSize = 0;
            btn_loadscheddoc.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_loadscheddoc.Location = new Point(443, 502);
            btn_loadscheddoc.Name = "btn_loadscheddoc";
            btn_loadscheddoc.Size = new Size(236, 29);
            btn_loadscheddoc.TabIndex = 25;
            btn_loadscheddoc.Text = "LOAD SCHEDULE";
            btn_loadscheddoc.UseVisualStyleBackColor = false;
            btn_loadscheddoc.Click += btn_loadscheddoc_Click;
            // 
            // Patient_profilestrip
            // 
            Patient_profilestrip.ImageScalingSize = new Size(20, 20);
            Patient_profilestrip.Items.AddRange(new ToolStripItem[] { viewPatientProfileToolStripMenuItem });
            Patient_profilestrip.Name = "Patient_profilestrip";
            Patient_profilestrip.Size = new Size(211, 56);
            Patient_profilestrip.Opening += Patient_profilestrip_Opening;
            // 
            // viewPatientProfileToolStripMenuItem
            // 
            viewPatientProfileToolStripMenuItem.Name = "viewPatientProfileToolStripMenuItem";
            viewPatientProfileToolStripMenuItem.Size = new Size(206, 24);
            viewPatientProfileToolStripMenuItem.Text = "View Patient Profile";
            // 
            // AcceptPatient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ContextMenuStrip = Patient_profilestrip;
            Controls.Add(btn_loadscheddoc);
            Controls.Add(btn_confirm);
            Controls.Add(table_AcceptAppointment);
            Name = "AcceptPatient";
            Size = new Size(1105, 676);
            ((System.ComponentModel.ISupportInitialize)table_AcceptAppointment).EndInit();
            Patient_profilestrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btn_confirm;
        private DataGridView table_AcceptAppointment;
        private Button btn_loadscheddoc;
        private ContextMenuStrip Patient_profilestrip;
        private ToolStripMenuItem viewPatientProfileToolStripMenuItem;
    }
}
