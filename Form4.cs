using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = userTxt.Text.Trim();
            string password = passTxt.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username or password cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection sc = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
                {
                    sc.Open();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO UserInfo (u_name, u_pass) VALUES (@Username, @Password)", sc))
                    {
                        cmd.Parameters.AddWithValue("@Username", userTxt.Text);
                        cmd.Parameters.AddWithValue("@Password", passTxt.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registered Successfully");
                this.Hide();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint violation error number
                {
                    MessageBox.Show("Username or password already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lineShape2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form fr1 = new Form1();
            fr1.Show();
            fr1.Enabled = true;
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void userTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form fr1 = new Form1();
            fr1.Show();
            fr1.Enabled = true;
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
