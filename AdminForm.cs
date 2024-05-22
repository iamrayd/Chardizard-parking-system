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
using System.Data;

namespace Login
{
    public partial class AdminForm : Form
    {
        private SqlConnection sc = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        public AdminForm()
        {
            InitializeComponent();
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.Visible = false;
            comboBox1.Visible = false;
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            label1.Visible = true;
            label3.Visible = true;
            listView1.Visible = true;
            listView2.Visible = false;
            comboBox1.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            listView1.Visible = false;
            listView2.Visible = true;
            comboBox1.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
        private void displayData(string databaseName)
        {
            sc.ConnectionString = "Data Source=(localdb)\\Projects;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            sc.Open();

            cmd = new SqlCommand("SELECT * FROM " + databaseName, sc);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "master"); 

            // Clear existing items
            listView2.Items.Clear();

            // Assuming the table has columns: v_id, v_plate, v_type, v_brand, v_time
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                // Create a new ListViewItem
                ListViewItem item = new ListViewItem(row["v_plate"].ToString());
                item.SubItems.Add(row["v_type"].ToString());
                item.SubItems.Add(row["v_brand"].ToString());
                item.SubItems.Add(row["v_time"].ToString());

                // Add the item to the ListView
                listView2.Items.Add(item);
            }

            sc.Close();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // Get the selected floor
            string selectedFloor = comboBox1.SelectedItem.ToString();

            // Determine which database to use based on the selected floor
            string databaseName = "";

            switch (selectedFloor)
            {
                case "Floor 1":
                    databaseName = "ParkingList";
                    break;
                case "Floor 2":
                    databaseName = "ParkingList2";
                    break;
                case "Floor 3":
                    databaseName = "ParkingList3";
                    break;
                case "Floor 4":
                    databaseName = "ParkingList4";
                    break;
                default:
                    // Handle any other cases here
                    break;
            }

            // Populate the ListView from the selected database
            displayData(databaseName);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Get the selected floor
            string selectedFloor = comboBox1.SelectedItem.ToString();

            // Determine which database to use based on the selected floor
            string databaseName = "";

            switch (selectedFloor)
            {
                case "Floor 1":
                    databaseName = "ParkingList";
                    break;
                case "Floor 2":
                    databaseName = "ParkingList2";
                    break;
                case "Floor 3":
                    databaseName = "ParkingList3";
                    break;
                case "Floor 4":
                    databaseName = "ParkingList4";
                    break;
                default:
                    // Handle any other cases here
                    break;
            }

            // Populate the ListView from the selected database
            displayData(databaseName);
        }

        
    }
}
