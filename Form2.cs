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
        public Form2()
        {
            InitializeComponent();
            // Set ListView view to Details
            listView1.View = View.Details;

            // Add columns to the ListView
            listView1.Columns.Add("Plate Number", 120);
            listView1.Columns.Add("Vehicle Type", 100);
            listView1.Columns.Add("Vehicle Brand", 100);
            listView1.Columns.Add("Time In", 150); // Assuming this is Park In Time
            listView1.FullRowSelect = true;
            listView1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            textBox1.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            welcomeLabel.Visible = false;
        }

        private void parkinBtn_Click(object sender, EventArgs e)
        {

            listView1.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            textBox1.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            welcomeLabel.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ensure that a brand is selected
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a brand.");
                return;
            }

            // Ensure that plate number is entered
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter plate number.");
                return;
            }

            // Get selected brand
            string brand = comboBox1.SelectedItem.ToString();
            string plateNumber = textBox1.Text;

            // Check for duplicate plate number
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[0].Text == plateNumber)
                {
                    MessageBox.Show("Plate number already exists. Please enter a unique plate number.");
                    return;
                }
            }

            // Check if it's a motorbike
            if (radioButton1.Checked)
            {
                // For motorbike, set vehicle type to the text of radioButton1
                string vehicleType = radioButton1.Text;
                AddCarDetailsToListView(plateNumber, vehicleType, brand, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                // Check if a vehicle type is selected for cars
                if (comboBox2.SelectedItem == null)
                {
                    MessageBox.Show("Please select a vehicle type.");
                    return;
                }
                string vehicleType = comboBox2.SelectedItem.ToString();
                AddCarDetailsToListView(plateNumber, vehicleType, brand, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            // Show success message
            MessageBox.Show("Parked Successfully.");

            // Clear input fields for the next entry
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }



        private void parkoutBtn_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            listView1.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            textBox1.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            listView1.Enabled = false;
            listView1.Height = 374;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            welcomeLabel.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a parked vehicle to park out.");
                return;
            }

            // Get selected item
            ListViewItem selectedItem = listView1.SelectedItems[0];

            // Calculate time hours spent
            DateTime parkInTime = DateTime.Parse(selectedItem.SubItems[3].Text); // Assuming the park in time is in the fourth column
            TimeSpan timeSpent = DateTime.Now - parkInTime;
            double hoursSpent = timeSpent.TotalHours;

            // Calculate the amount to be paid
            // double amountToBePaid = CalculateAmountToBePaid(hoursSpent); // Implement this method according to your fee calculation logic

            // Show dialog for payment
            string plateNumber = selectedItem.SubItems[0].Text;
            string vehicleType = selectedItem.SubItems[1].Text;
            string brand = selectedItem.SubItems[2].Text;
            string message = "Plate Number: " + plateNumber + "\n" +
                         "Vehicle Type: " + vehicleType + "\n" +
                         "Brand: " + brand + "\n" +
                         "Time Spent: " + hoursSpent.ToString("F2") + " hours\n" +  // Showing time spent with 2 decimal places
                         "Amount to be paid: ";  // Using currency format


            DialogResult result = MessageBox.Show(message, "Park Out Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                // Remove the selected item from the ListView
                listView1.Items.Remove(selectedItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            listView1.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            textBox1.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            listView1.Enabled = false;
            listView1.Height = 479;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            welcomeLabel.Visible = true;

        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            textBox1.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            welcomeLabel.Visible = false;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
           
        }



        private void closeLabel_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void minimizeLabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void AddCarDetailsToListView(string plateNumber, string vehicleType, string brand, string parkInTime)
        {
            ListViewItem item = new ListViewItem(plateNumber);
            item.SubItems.Add(vehicleType);
            item.SubItems.Add(brand);
            item.SubItems.Add(parkInTime); // Park in time passed as parameter
            listView1.Items.Add(item);
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

        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // If motorbike radio button is checked
            if (radioButton1.Checked)
            {
                // Hide combobox2
                label4.Visible = false;
                comboBox2.Visible = false;

                // Populate combobox1 with motorbike brands
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Ducati");
                comboBox1.Items.Add("Nmax");
                comboBox1.Items.Add("BMW");
                comboBox1.Items.Add("Kawasaki");
                comboBox1.Items.Add("Yamaha");
                comboBox1.Items.Add("Honda");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // If car radio button is checked
            if (radioButton2.Checked)
            {
                // Show combobox2
                comboBox2.Visible = true;
                label4.Visible = true;

                // Populate combobox1 with car brands
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Toyota");
                comboBox1.Items.Add("Kia");
                comboBox1.Items.Add("Mitsubishi");
                comboBox1.Items.Add("Chevrolet");
                comboBox1.Items.Add("Toyota");
                comboBox1.Items.Add("Mazda");
                comboBox1.Items.Add("Audi");
                comboBox1.Items.Add("Tesla");
                comboBox1.Items.Add("Mercedes");

                comboBox2.Items.Clear();
                comboBox2.Items.Add("SUV");
                comboBox2.Items.Add("Van");
                comboBox2.Items.Add("Sedan");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Close ParkInForm without performing any action
            this.Close();
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        
    }
}


