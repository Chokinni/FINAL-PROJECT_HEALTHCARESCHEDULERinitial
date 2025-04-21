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
            components = new System.ComponentModel.Container();
            table_ViewPatientAppointment = new DataGridView();
            lbl_noAppointment = new Label();
            btn_loadAppointments = new Button();
            txt_searchDoctor = new TextBox();
            btn_searchDoctor = new Button();
            label1 = new Label();
            strip_viewdocprofile = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)table_ViewPatientAppointment).BeginInit();
            SuspendLayout();
            // 
            // table_ViewPatientAppointment
            // 
            table_ViewPatientAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_ViewPatientAppointment.Location = new Point(65, 92);
            table_ViewPatientAppointment.Name = "table_ViewPatientAppointment";
            table_ViewPatientAppointment.RowHeadersWidth = 51;
            table_ViewPatientAppointment.Size = new Size(754, 393);
            table_ViewPatientAppointment.TabIndex = 14;
            // 
            // lbl_noAppointment
            // 
            lbl_noAppointment.AutoSize = true;
            lbl_noAppointment.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_noAppointment.Location = new Point(99, 518);
            lbl_noAppointment.Name = "lbl_noAppointment";
            lbl_noAppointment.Size = new Size(193, 18);
            lbl_noAppointment.TabIndex = 16;
            lbl_noAppointment.Text = "YOUR APPOINTMENTS!";
            // 
            // btn_loadAppointments
            // 
            btn_loadAppointments.BackColor = Color.SkyBlue;
            btn_loadAppointments.FlatAppearance.BorderSize = 0;
            btn_loadAppointments.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_loadAppointments.Location = new Point(345, 510);
            btn_loadAppointments.Name = "btn_loadAppointments";
            btn_loadAppointments.Size = new Size(161, 35);
            btn_loadAppointments.TabIndex = 19;
            btn_loadAppointments.Text = "LOAD SCHEDULE";
            btn_loadAppointments.UseVisualStyleBackColor = false;
            btn_loadAppointments.Click += btn_loadAppointments_Click;
            // 
            // txt_searchDoctor
            // 
            txt_searchDoctor.Location = new Point(193, 49);
            txt_searchDoctor.Multiline = true;
            txt_searchDoctor.Name = "txt_searchDoctor";
            txt_searchDoctor.Size = new Size(166, 25);
            txt_searchDoctor.TabIndex = 20;
            txt_searchDoctor.TextChanged += txt_searchDoctor_TextChanged;
            // 
            // btn_searchDoctor
            // 
            btn_searchDoctor.Location = new Point(473, 38);
            btn_searchDoctor.Name = "btn_searchDoctor";
            btn_searchDoctor.Size = new Size(94, 29);
            btn_searchDoctor.TabIndex = 21;
            btn_searchDoctor.Text = "button1";
            btn_searchDoctor.UseVisualStyleBackColor = true;
            btn_searchDoctor.Click += btn_searchDoctor_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(52, 49);
            label1.Name = "label1";
            label1.Size = new Size(123, 18);
            label1.TabIndex = 22;
            label1.Text = "Search Doctor:";
            // 
            // strip_viewdocprofile
            // 
            strip_viewdocprofile.ImageScalingSize = new Size(20, 20);
            strip_viewdocprofile.Name = "strip_viewdocprofile";
            strip_viewdocprofile.Size = new Size(61, 4);
            strip_viewdocprofile.Opening += strip_viewdocprofile_Opening;
            // 
            // ViewAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ContextMenuStrip = strip_viewdocprofile;
            Controls.Add(label1);
            Controls.Add(btn_searchDoctor);
            Controls.Add(txt_searchDoctor);
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
        private TextBox txt_searchDoctor;
        private Button btn_searchDoctor;
        private Label label1;
        private ContextMenuStrip strip_viewdocprofile;
    }
}
