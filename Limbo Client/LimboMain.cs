using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace Limbo_Client
{
    public partial class LimboMain : Form
    {
        // Default constructor; totally fine for this
        public LimboMain()
        {
            InitializeComponent();
        }

        // Store some session variables:
        public string username = null;
        public string politeName = null;
        public string token = null;

        // Use the same HTTP client throughout the client
        public HttpClient webClient = new HttpClient();

        // The URI of the web server is hard-coded for now
        // I don't foresee any issues with this for the time being...
        public Uri serverUri = new Uri("http://ec2-54-186-32-0.us-west-2.compute.amazonaws.com");

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void loginStatus_Click(object sender, EventArgs e)
        {

        }

        private void loginMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm(this);
            DialogResult result = lf.ShowDialog();
            if (result == DialogResult.OK)
            {
                loginStatus.Text = "Logged in as " + username;
                logoutMenuItem.Visible = true;
                loginMenuItem.Visible = false;
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logoutMenuItem_Click(object sender, EventArgs e)
        {
            username = null;
            politeName = null;
            token = null;
            loginStatus.Text = "Not logged in";
            logoutMenuItem.Visible = false;
            loginMenuItem.Visible = true;
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }
    }
}
