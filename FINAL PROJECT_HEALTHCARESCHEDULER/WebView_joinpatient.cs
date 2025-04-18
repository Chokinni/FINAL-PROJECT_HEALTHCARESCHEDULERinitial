using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class WebView_joinpatient : Form
    {
        string loggedInUsername;
        private string loggedInLastName;
        private string meetLink;
        public WebView_joinpatient(string firstName, string lastName, string meetLink)
        {
            InitializeComponent();
            loggedInUsername = firstName;// Store username in a variable
            loggedInLastName = lastName;
            this.meetLink = meetLink;

            this.Text = $"Join Online Consultation - Patient {firstName} {lastName}";

            // Initialize when the form loads
            this.Load += WebView_joinpatient_Load;
        }

        private async void WebView_joinpatient_Load(object sender, EventArgs e)
        {
            await InitializeWebViewAndJoin();
        }

        public async Task InitializeWebViewAndJoin()
        {
            try
            {
                // Initialize the WebView2 environment
                await webview_patient.EnsureCoreWebView2Async(null);

                // Configure WebView2 settings
                webview_patient.CoreWebView2.Settings.IsZoomControlEnabled = true;
                webview_patient.CoreWebView2.Settings.AreDefaultContextMenusEnabled = true;
                webview_patient.CoreWebView2.Settings.IsStatusBarEnabled = true;

                // Enable microphone and camera permissions for the meeting
                webview_patient.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = true;
                webview_patient.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = true;

                // Navigate to the meeting link with additional parameters
                if (!string.IsNullOrEmpty(meetLink))
                {
                    // Add parameters to auto-join and set display name
                    string enhancedLink = meetLink;

                    // If the link doesn't already have parameters, add a question mark
                    if (!enhancedLink.Contains("?"))
                        enhancedLink += "?";
                    else
                        enhancedLink += "&";

                    // Add parameters for auto-joining
                    enhancedLink += $"authuser=0&hs=178&pli=1&authuser=0&name=Dr.+{Uri.EscapeDataString(loggedInUsername)}+{Uri.EscapeDataString(loggedInLastName)}";

                    webview_patient.CoreWebView2.Navigate(enhancedLink);
                }
                else
                {
                    MessageBox.Show("Meeting link is empty or invalid.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing WebView: " + ex.Message);
            }
        }
    }
}
