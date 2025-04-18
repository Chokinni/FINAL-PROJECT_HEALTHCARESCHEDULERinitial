namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    partial class WebViewcreateMeet
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
            webview_createmeet = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webview_createmeet).BeginInit();
            SuspendLayout();
            // 
            // webview_createmeet
            // 
            webview_createmeet.AllowExternalDrop = true;
            webview_createmeet.CreationProperties = null;
            webview_createmeet.DefaultBackgroundColor = Color.White;
            webview_createmeet.Location = new Point(-2, -2);
            webview_createmeet.Name = "webview_createmeet";
            webview_createmeet.Size = new Size(1013, 604);
            webview_createmeet.TabIndex = 0;
            webview_createmeet.ZoomFactor = 1D;
            webview_createmeet.Click += webview_createmeet_Click;
            // 
            // WebViewcreateMeet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1012, 601);
            Controls.Add(webview_createmeet);
            Name = "WebViewcreateMeet";
            Text = "WebViewcreateMeet";
            Load += WebViewcreateMeet_Load;
            ((System.ComponentModel.ISupportInitialize)webview_createmeet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webview_createmeet;
    }
}