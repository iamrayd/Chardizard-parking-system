using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Login.UserControls
{
    public partial class Park_in : UserControl
    {
        private SqlConnection sc = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

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
                comboBox1.Text = "Select Brand";
                comboBox2.Items.Clear();
                comboBox2.Text = "Motorbike";
                comboBox2.Items.Add("Motorbike");
                comboBox2.SelectedItem = comboBox2.Text;
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
                comboBox1.Text = "Select Brand";

                comboBox2.Items.Clear();
                comboBox2.Text = "Select Type";
                comboBox2.Items.AddRange(new string[] { "SUV", "Van", "Sedan" });
            }
        }

        private void parkBtn_Click(object sender, EventArgs e)
        {
            string databaseName = GetSelectedFloorDatabaseName();
            // Ensure that plate number is entered
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter plate number.");
                return;
            }

            // Ensure that vehicle type is entered
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select a vehicle type.");
                return;
            }

            // Ensure that a brand is selected
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a brand.");
                return;
            }

            string plateNumber = textBox1.Text;
            string vehicleType = radioButton1.Checked ? radioButton1.Text : comboBox2.SelectedItem.ToString();
            string brand = comboBox1.SelectedItem.ToString();

    
            // Add data to the corresponding database
            AddDataToDatabase(plateNumber, vehicleType, brand, databaseName);

            // Clear input fields for the next entry
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private string GetSelectedFloorDatabaseName()
        {
            string selectedFloor = comboBox3.SelectedItem.ToString();

            switch (selectedFloor)
            {
                case "Floor 1":
                    return "ParkingList";
                case "Floor 2":
                    return "ParkingList2";
                case "Floor 3":
                    return "ParkingList3";
                case "Floor 4":
                    return "ParkingList4";
                default:
                    return ""; // Handle invalid selection appropriately
            }
        }

private void AddDataToDatabase(string plateNumber, string vehicleType, string brand, string databaseName)
{
    try
    {
        if (IsParkingFull())
        {
            MessageBox.Show("Parking is full!", "Parking Full", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        string connectionString = "Data Source=(localdb)\\Projects;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Insert data into the specified database using parameters
            string insertQuery = "INSERT INTO " + databaseName + "(v_plate, v_type, v_brand, v_time) VALUES (@plate, @type, @brand, @time)";
            SqlCommand cmd = new SqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@plate", plateNumber);
            cmd.Parameters.AddWithValue("@type", vehicleType);
            cmd.Parameters.AddWithValue("@brand", brand);
            cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.ExecuteNonQuery();
        }

        MessageBox.Show("Parked successfully!");
        
    }
    catch (SqlException ex)
    {
        // Handle SQL exceptions
        if (ex.Number == 2627 || ex.Number == 2601)
        {
            // Handle unique constraint violation
            MessageBox.Show("A vehicle with the same plate number already exists.", "Duplicate Plate Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            // Handle other SQL exceptions
            MessageBox.Show("SQL error occurred: " + ex.Message);
        }
    }
    catch (Exception ex)
    {
        // Handle other exceptions
        MessageBox.Show("An error occurred: " + ex.Message);
    }
}


        private bool IsParkingFull()
        {   
            string databaseName = GetSelectedFloorDatabaseName();
            try
            {
                using (SqlConnection sc = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
                {
                    sc.Open();

                    // Query to count the number of entries in ParkingList
                    string query = "SELECT COUNT(*) FROM " + databaseName;
                    using (SqlCommand cmd = new SqlCommand(query, sc))
                    {
                        int count = (int)cmd.ExecuteScalar();
                        return count >= 25; // Return true if count is equal to or greater than 25 (parking is full)
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                MessageBox.Show("SQL error occurred: " + ex.Message);
                return false; // Assume parking is not full in case of error
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
                return false; // Assume parking is not full in case of error
            }
        }

        private void Park_in_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }
    }
}
