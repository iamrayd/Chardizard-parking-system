using System;
using System.Windows.Forms;

namespace Login.UserControls
{
    public partial class Park_in : UserControl
    {
        private Park_out parkOutInstance;

        public Park_in()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // If motorbike radio button is checked
            if (radioButton1.Checked)
            {
                // Populate combobox1 with motorbike brands
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(new string[] { "Ducati", "Nmax", "BMW", "Kawasaki", "Yamaha", "Honda" });

                comboBox2.Items.Clear();
                comboBox2.Text = "Motorbike";
                comboBox2.Items.Add("Motorbike");
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
                comboBox1.Items.AddRange(new string[] { "Toyota", "Kia", "Mitsubishi", "Chevrolet", "Toyota", "Mazda", "Audi", "Tesla", "Mercedes" });

                comboBox2.Items.Clear();
                comboBox2.Text = "Select Type";
                comboBox2.Items.AddRange(new string[] { "SUV", "Van", "Sedan" });
            }
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
            foreach (ListViewItem item in parkOutInstance.ParkedCarListView.Items)
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
                parkOutInstance.AddItemToListView(plateNumber, vehicleType, brand, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
                parkOutInstance.AddItemToListView(plateNumber, vehicleType, brand, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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

        private void Park_in_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
