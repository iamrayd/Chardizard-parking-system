using Login.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form2 : Form
    {
        //private string userName;

        public Form2(string userName)
        {
            InitializeComponent();
            Home uc = new Home();
            addUserControl(uc);
            userLabel.Text = userName;


        }

        private void closeLabel_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void minimizeLabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }




        private void logoutBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logging off", "Log out", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Close Form2
            this.Close();

            // Show Form1
            Form1 form1 = new Form1();
            form1.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Close ParkInForm without performing any action
            this.Close();
        }

       
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Form2 parentForm = this.FindForm() as Form2;
            // Check if the button click event was triggered by logoutBtn
            if (sender == guna2Button4 && parentForm != null)
            {
                // Ask user for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Close the parent Form2
                    parentForm.Close();

                    // Open Form1 as a dialog
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                }
            }
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Home uc = new Home();
            addUserControl(uc);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Park_in uc = new Park_in();
            addUserControl(uc);

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Park_out uc = new Park_out();
            addUserControl(uc);

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        public void ShowHomeDashboard()
        {
            // Assuming Home is a control within Form2
            Home homeDashboard = new Home();
            // Assuming panelContainer is the container where the Home control is placed
            addUserControl(homeDashboard);
        }

        private void userLabel_Click(object sender, EventArgs e)
        {

        }

    }
}


