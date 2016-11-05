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
using Newtonsoft.Json;

namespace Limbo_Client
{
    public partial class LoginForm : Form
    {
        // Default constructor; not much use, but we can leave it in for now
        public LoginForm()
        {
            InitializeComponent();
        }

        // Store a reference to the calling form (should be the main form)
        private LimboMain mainForm = null;

        public LoginForm(Form callingForm)
        {
            mainForm = callingForm as LimboMain;
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameField.Text;
            string password = passwordField.Text;
            if (username == "")
            {
                statusText.Text = "Enter a username.";
                return;
            }
            else if (password == "")
            {
                statusText.Text = "Enter a password.";
                return;
            }
            else
            {
                await login(username, password);
            }
        }

        private async Task login(String username, String password)
        {
            // Let the user know you're logging in...
            statusText.Text = "Logging in...";
            // Prep the credentials for sending
            var credentials = new List<KeyValuePair<string, string>>();
            credentials.Add(new KeyValuePair<string, string>("username", username));
            credentials.Add(new KeyValuePair<string, string>("password", password));
            var payload = new FormUrlEncodedContent(credentials);
            Uri loginUri = new Uri("http://ec2-54-186-32-0.us-west-2.compute.amazonaws.com:8000/api/api-token-auth/");
            // Send the credentials
            var response = await this.mainForm.webClient.PostAsync(loginUri, payload);
            // If the response is OK, we're logged in!
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Receive and parse the token
                var json = await response.Content.ReadAsStringAsync();
                Token tempToken = JsonConvert.DeserializeObject<Token>(json);
                this.mainForm.token = tempToken.token;
                this.mainForm.username = username;
                statusText.Text = "Logged in!";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                statusText.Text = "Login credentials invalid!";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                statusText.Text = "Server error; please try again.";
            }
            else
            {
                statusText.Text = "Unspecified error; please try again.";
            }
        }
    }

    // Define a class for parsing the JSON containing the authentication token
    public class Token
    {
        public string token { get; set; }
    }
}
