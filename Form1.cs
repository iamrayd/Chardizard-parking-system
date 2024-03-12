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

namespace Login
{
    public partial class Form1 : Form
    {
        private const string UsernamePlaceholder = "Username";
        private const string PasswordPlaceholder = "Password";

        public Form1()
        {
            InitializeComponent();
            InitializeCustomButton();


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

        private void InitializeCustomButton()
        {
            // Set slightly rounded edges for loginBtn
            GraphicsPath buttonPath = new GraphicsPath();
            Rectangle rect = loginBtn.ClientRectangle;
            int radius = 10; // Adjust the radius for the roundness of the corners
            buttonPath.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            buttonPath.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            buttonPath.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            buttonPath.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            buttonPath.CloseFigure();
            loginBtn.Region = new Region(buttonPath);
        }

       

        private void loginBtn_Click(object sender, EventArgs e)
        {

            if (usernameTxt.Text != "" && passwordTxt.Text != "")
            {
                if (usernameTxt.Text != "Richard" || passwordTxt.Text != "TheGreat")
                {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Login successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2 fr2 = new Form2();
                    fr2.Show();
                    this.Hide();
                }
            }
            else
                MessageBox.Show("Please fillup required field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                usernameTxt.ForeColor = Color.Black;
            }
        }

        private void UsernameTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTxt.Text))
            {
                usernameTxt.Text = UsernamePlaceholder;
                usernameTxt.ForeColor = Color.Gray;
                
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
            }
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordTxt.Text != PasswordPlaceholder)
            {
                passwordTxt.PasswordChar = '*'; // Enable password masking for user input
                passwordTxt.ForeColor = Color.Black;
            }
            else
            {
                passwordTxt.PasswordChar = '\0'; // Disable password masking for placeholder
                passwordTxt.ForeColor = Color.Gray;
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
                passwordTxt.ForeColor = Color.Gray;
            }
        }

    }
}
