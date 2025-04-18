namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class WebView_joinmeet
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
            webview_meetingol = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webview_meetingol).BeginInit();
            SuspendLayout();
            // 
            // webview_meetingol
            // 
            webview_meetingol.AllowExternalDrop = true;
            webview_meetingol.CreationProperties = null;
            webview_meetingol.DefaultBackgroundColor = Color.White;
            webview_meetingol.Location = new Point(0, 1);
            webview_meetingol.Name = "webview_meetingol";
            webview_meetingol.Size = new Size(1249, 660);
            webview_meetingol.TabIndex = 0;
            webview_meetingol.ZoomFactor = 1D;
            // 
            // WebView_joinmeet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 663);
            Controls.Add(webview_meetingol);
            Name = "WebView_joinmeet";
            Text = "WebView_joinmeet";
            Load += WebView_joinmeet_Load;
            ((System.ComponentModel.ISupportInitialize)webview_meetingol).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webview_meetingol;
    }
}