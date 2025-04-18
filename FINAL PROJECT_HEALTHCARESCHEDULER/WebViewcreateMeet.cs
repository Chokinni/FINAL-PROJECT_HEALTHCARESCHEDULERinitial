using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class WebViewcreateMeet : Form
    {
        string loggedInUsername;
        private string loggedInLastName;
        private string meetLink;
        public WebViewcreateMeet(string firstName, string lastName, string meetLink)
        {
            InitializeComponent();
            loggedInUsername = firstName;// Store username in a variable
            loggedInLastName = lastName;
            this.meetLink = meetLink;
            // Set window title
            this.Text = $"Online Consultation - Dr. {firstName} {lastName}";

            // Initialize WebView2 when the form loads
            this.Load += WebViewcreateMeet_Load;
        }

        private void webview_createmeet_Click(object sender, EventArgs e)
        {

        }

        private async void WebViewcreateMeet_Load(object sender, EventArgs e)
        {
            // Initialize WebView2 environment
            await InitializeWebView();

            // Ensure that CoreWebView2 is initialized before navigating
            if (webview_createmeet.CoreWebView2 != null)
            {
                string htmlMessage = "<html><body><h2>Meeting Created</h2><p>Your meeting has been successfully created. Please check your calendar for the details.</p></body></html>";
                webview_createmeet.CoreWebView2.NavigateToString(htmlMessage);
            }
            else
            {
                MessageBox.Show("WebView2 is not initialized yet.");
            }
        }
        public async Task InitializeWebView()
        {
            // Initialize the WebView2 control
            await webview_createmeet.EnsureCoreWebView2Async(null);

            // Optional: Add any required WebView2 settings
            webview_createmeet.CoreWebView2.Settings.IsZoomControlEnabled = true;
            webview_createmeet.CoreWebView2.Settings.AreDefaultContextMenusEnabled = true;
            webview_createmeet.CoreWebView2.Settings.IsStatusBarEnabled = true;
        }
        public CoreWebView2 CoreWebViewControl
        {
            get { return webview_createmeet.CoreWebView2; }
        }

    }
}
