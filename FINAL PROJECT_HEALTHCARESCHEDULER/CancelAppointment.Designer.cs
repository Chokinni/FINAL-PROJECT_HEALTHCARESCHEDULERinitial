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
            btn_cancel = new Button();
            table_CancelAppointment = new DataGridView();
            btn_LoadAppCancel = new Button();
            btn_deleteapp = new Button();
            label1 = new Label();
            txt_searchDoctor = new TextBox();
            ((System.ComponentModel.ISupportInitialize)table_CancelAppointment).BeginInit();
            SuspendLayout();
            // 
            // btn_cancel
            // 
            btn_cancel.BackColor = Color.SkyBlue;
            btn_cancel.FlatAppearance.BorderSize = 0;
            btn_cancel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cancel.Location = new Point(83, 511);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(173, 39);
            btn_cancel.TabIndex = 17;
            btn_cancel.Text = "CANCEL";
            btn_cancel.UseVisualStyleBackColor = false;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // table_CancelAppointment
            // 
            table_CancelAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_CancelAppointment.Location = new Point(50, 82);
            table_CancelAppointment.Name = "table_CancelAppointment";
            table_CancelAppointment.RowHeadersWidth = 51;
            table_CancelAppointment.Size = new Size(754, 393);
            table_CancelAppointment.TabIndex = 13;
            // 
            // btn_LoadAppCancel
            // 
            btn_LoadAppCancel.BackColor = Color.SkyBlue;
            btn_LoadAppCancel.FlatAppearance.BorderSize = 0;
            btn_LoadAppCancel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_LoadAppCancel.Location = new Point(300, 511);
            btn_LoadAppCancel.Name = "btn_LoadAppCancel";
            btn_LoadAppCancel.Size = new Size(235, 39);
            btn_LoadAppCancel.TabIndex = 19;
            btn_LoadAppCancel.Text = "Load Schedule";
            btn_LoadAppCancel.UseVisualStyleBackColor = false;
            btn_LoadAppCancel.Click += btn_LoadAppCancel_Click;
            // 
            // btn_deleteapp
            // 
            btn_deleteapp.BackColor = Color.SkyBlue;
            btn_deleteapp.FlatAppearance.BorderSize = 0;
            btn_deleteapp.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_deleteapp.Location = new Point(557, 511);
            btn_deleteapp.Name = "btn_deleteapp";
            btn_deleteapp.Size = new Size(235, 39);
            btn_deleteapp.TabIndex = 20;
            btn_deleteapp.Text = "DELETE";
            btn_deleteapp.UseVisualStyleBackColor = false;
            btn_deleteapp.Click += btn_deleteapp_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(61, 44);
            label1.Name = "label1";
            label1.Size = new Size(123, 18);
            label1.TabIndex = 25;
            label1.Text = "Search Doctor:";
            // 
            // txt_searchDoctor
            // 
            txt_searchDoctor.Location = new Point(212, 40);
            txt_searchDoctor.Multiline = true;
            txt_searchDoctor.Name = "txt_searchDoctor";
            txt_searchDoctor.Size = new Size(177, 27);
            txt_searchDoctor.TabIndex = 24;
            txt_searchDoctor.TextChanged += txt_searchDoctor_TextChanged;
            // 
            // CancelAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            Controls.Add(label1);
            Controls.Add(txt_searchDoctor);
            Controls.Add(btn_deleteapp);
            Controls.Add(btn_LoadAppCancel);
            Controls.Add(btn_cancel);
            Controls.Add(table_CancelAppointment);
            Name = "CancelAppointment";
            Size = new Size(1105, 676);
            Load += CancelAppointment_Load;
            ((System.ComponentModel.ISupportInitialize)table_CancelAppointment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_cancel;
        private DataGridView table_CancelAppointment;
        private Button btn_LoadAppCancel;
        private Button btn_deleteapp;
        private Label label1;
        private TextBox txt_searchDoctor;
    }
}
