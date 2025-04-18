namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class WebView_joinpatient
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            webview_patient = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webview_patient).BeginInit();
            SuspendLayout();
            // 
            // webview_patient
            // 
            webview_patient.AllowExternalDrop = true;
            webview_patient.CreationProperties = null;
            webview_patient.DefaultBackgroundColor = Color.White;
            webview_patient.Location = new Point(0, 1);
            webview_patient.Name = "webview_patient";
            webview_patient.Size = new Size(1151, 673);
            webview_patient.TabIndex = 0;
            webview_patient.ZoomFactor = 1D;
            // 
            // WebView_joinpatient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1151, 672);
            Controls.Add(webview_patient);
            Name = "WebView_joinpatient";
            Text = "WebView_joinpatient";
            Load += WebView_joinpatient_Load;
            ((System.ComponentModel.ISupportInitialize)webview_patient).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webview_patient;
    }
}