using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login.UserControls
{
    public partial class Park_out : UserControl
    {
        private SqlConnection sc = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        private HashSet<string> plateNumbers = new HashSet<string>();

        public ListView carListView { get { return listView1; } }

        public Park_out()
        {
            InitializeComponent();

            carListView.View = View.Details;
            carListView.FullRowSelect = true;


            // Load data when the control is initialized
            Load += Park_out_Load;
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            if (carListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a parked vehicle to park out.");
                return;
            }

            ListViewItem selectedItem = carListView.SelectedItems[0];
            string plateNumber = selectedItem.SubItems[0].Text;

            // Delete the record from the database
            DeleteRecord(plateNumber);

            // Remove selected item from the ListView
            carListView.Items.Remove(selectedItem);

            DateTime parkInTime;
            if (!DateTime.TryParse(selectedItem.SubItems[3].Text, out parkInTime))
            {
                MessageBox.Show("Error parsing park in time.");
                return;
            }

            TimeSpan timeSpent = DateTime.Now - parkInTime;
            int hoursSpent = (int)Math.Ceiling(timeSpent.TotalHours);

            // Get vehicle type
            string vehicleType = selectedItem.SubItems[1].Text;

            // Calculate the amount to be paid
            double amountToBePaid = CalculateAmountToBePaid(vehicleType, hoursSpent);

            plateNumber = selectedItem.SubItems[0].Text;
            string brand = selectedItem.SubItems[2].Text;
            string message = "Plate Number: " + plateNumber + "\n" +
                             "Vehicle Type: " + vehicleType + "\n" +
                             "Brand: " + brand + "\n" +
                             "Time Spent: " + hoursSpent + " hours/s" + "\n" +
                             "Amount to be paid: Php " + amountToBePaid.ToString("F2");

            DialogResult result = MessageBox.Show(message, "Park Out Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                // Remove selected items
                carListView.Items.Remove(selectedItem);
            }
        }

        private void DeleteRecord(string plateNumber)
        {
            try
            {
                using (SqlConnection sc = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
                {
                    sc.Open();

                    // Delete record with specified plate number
                    string deleteQuery = "DELETE FROM ParkingList WHERE v_plate = @plate";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, sc))
                    {
                        cmd.Parameters.AddWithValue("@plate", plateNumber);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                MessageBox.Show("SQL error occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private double CalculateAmountToBePaid(string vehicleType, int hoursSpent)
        {
            double flagDownRate = 0;
            double hourlyRate = 0;

            switch (vehicleType)
            {
                case "Motorbike":
                    flagDownRate = 20;
                    hourlyRate = 5;
                    break;
                case "SUV":
                case "Van":
                    flagDownRate = 40;
                    hourlyRate = 20;
                    break;
                case "Sedan":
                    flagDownRate = 30;
                    hourlyRate = 15;
                    break;
                default:
                    break;
            }

            double amountToBePaid = flagDownRate + (hourlyRate * hoursSpent);
            return amountToBePaid;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Park_out_Load(object sender, EventArgs e)
        {
            displayData();
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void displayData()
        {
            sc.ConnectionString = "Data Source=(localdb)\\Projects;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            sc.Open();

            cmd = new SqlCommand("SELECT * FROM ParkingList", sc);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "master"); // Use the actual table name

            // Clear existing items
            listView1.Items.Clear();

            // Assuming the table has columns: v_id, v_plate, v_type, v_brand, v_time
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                // Create a new ListViewItem
                ListViewItem item = new ListViewItem(row["v_plate"].ToString());
                item.SubItems.Add(row["v_type"].ToString());
                item.SubItems.Add(row["v_brand"].ToString());
                item.SubItems.Add(row["v_time"].ToString());

                // Add the item to the ListView
                listView1.Items.Add(item);
            }

            sc.Close();
        }

    }
}
