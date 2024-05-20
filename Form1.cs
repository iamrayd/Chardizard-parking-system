using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class Form1 : Form
    {
      

        private const string UsernamePlaceholder = "Username";
        private const string PasswordPlaceholder = "Password";

        public Form1()
        {
            InitializeComponent();

            // Assign placeholder text for username and password TextBox controls
            usernameTxt.Text = UsernamePlaceholder;
            passwordTxt.Text = PasswordPlaceholder;

            passwordTxt.PasswordChar = '\0';

            // Attach event handlers for placeholder behavior
            usernameTxt.Enter += UsernameTextBox_Enter;
            usernameTxt.Leave += UsernameTextBox_Leave;
            passwordTxt.Enter += PasswordTextBox_GotFocus;
            passwordTxt.Leave += PasswordTextBox_LostFocus;
            passwordTxt.TextChanged += PasswordTextBox_TextChanged;
            // Set placeholder text and align it in the center
            usernameTxt.Text = UsernamePlaceholder;
            usernameTxt.TextAlign = HorizontalAlignment.Center;
            usernameTxt.ForeColor = Color.Gray;
            passwordTxt.Text = PasswordPlaceholder;
            passwordTxt.TextAlign = HorizontalAlignment.Center;
            passwordTxt.ForeColor = Color.Gray;
        }
        

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;

            string connectionString = "Data Source=(localdb)\\Projects;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Construct the SQL command to select user info
                string query = "SELECT COUNT(*) FROM UserInfo WHERE u_name = @Username AND u_pass = @Password";

                // Prepare the SQL command
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set the parameters
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    // Execute the query
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Login successful
                        MessageBox.Show("Login successful");
                        string userName = username;
                        Form2 fr2 = new Form2(userName);
                        fr2.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Invalid credentials
                        MessageBox.Show("Invalid credentials!");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f4 = new Form4();
            f4.Show();
            this.Enabled = false;

        }


        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void usernameTxt_TextChanged(object sender, EventArgs e)
        {

        }


        // Event handlers for placeholder behavior
        private void UsernameTextBox_Enter(object sender, EventArgs e)
        {
            if (usernameTxt.Text == UsernamePlaceholder)
            {
                usernameTxt.Text = "";
                usernameTxt.ForeColor = Color.Silver;
            }
        }

        private void UsernameTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTxt.Text))
            {
                usernameTxt.Text = UsernamePlaceholder;
                usernameTxt.ForeColor = Color.Silver;

            }
        }

        private void PasswordTextBox_GotFocus(object sender, EventArgs e)
        {
            if (passwordTxt.Text == PasswordPlaceholder)
            {
                passwordTxt.Text = "";

            }
        }

        private void PasswordTextBox_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passwordTxt.Text))
            {
                passwordTxt.Text = PasswordPlaceholder;
                passwordTxt.ForeColor = Color.Silver;
            }
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordTxt.Text != PasswordPlaceholder)
            {
                passwordTxt.PasswordChar = '*'; // Enable password masking for user input
                passwordTxt.ForeColor = Color.Silver;
            }
            else
            {
                passwordTxt.PasswordChar = '\0'; // Disable password masking for placeholder
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            // Restore placeholders if the textboxes don't have focus and their text is empty
            if (!usernameTxt.Focused && string.IsNullOrWhiteSpace(usernameTxt.Text))
            {
                usernameTxt.Text = UsernamePlaceholder;
            }

            if (!passwordTxt.Focused && string.IsNullOrWhiteSpace(passwordTxt.Text))
            {
                passwordTxt.Text = PasswordPlaceholder;
                passwordTxt.PasswordChar = '\0'; // Disable password masking for placeholder
                passwordTxt.ForeColor = Color.Silver;
            }
        }

        private void usernameTxt_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void lineShape2_Click(object sender, EventArgs e)
        {

        }

        private void shapeContainer1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
