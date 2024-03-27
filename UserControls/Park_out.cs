using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Login.UserControls
{
    public partial class Park_out : UserControl
    {
        private HashSet<string> plateNumbers = new HashSet<string>();

        public ListView ParkedCarListView { get; private set; }

        public Park_out()
        {
            InitializeComponent();

            ParkedCarListView = new ListView();
            ParkedCarListView.View = View.Details;
            // Add columns to the ListView
            ParkedCarListView.Columns.Add("Plate Number", 176);
            ParkedCarListView.Columns.Add("Vehicle Type", 176);
            ParkedCarListView.Columns.Add("Vehicle Brand", 176);
            ParkedCarListView.Columns.Add("Time In", 176); // Assuming this is Park In Time
        }

        public void AddItemToListView(string plateNumber, string vehicleType, string brand, string parkInTime)
        {
            if (ParkedCarListView.InvokeRequired)
            {
                ParkedCarListView.Invoke(new MethodInvoker(delegate {
                    AddCarDetailsToListView(plateNumber, vehicleType, brand, parkInTime);
                }));
            }
            else
            {
                AddCarDetailsToListView(plateNumber, vehicleType, brand, parkInTime);
            }
        }

        private void AddCarDetailsToListView(string plateNumber, string vehicleType, string brand, string parkInTime)
        {
            if (ParkedCarListView.Items.Count >= 50)
            {
                MessageBox.Show("Parking is full. Cannot add more vehicles.");
                return;
            }

            // Check for duplicate plate number
            if (plateNumbers.Contains(plateNumber))
            {
                MessageBox.Show("Plate number already exists. Please enter a unique plate number.");
                return;
            }

            // If plate number is unique, add it to the HashSet
            plateNumbers.Add(plateNumber);

            ListViewItem item = new ListViewItem(plateNumber);
            item.SubItems.Add(vehicleType);
            item.SubItems.Add(brand);
            item.SubItems.Add(parkInTime); // Park in time passed as parameter
            ParkedCarListView.Items.Add(item);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ParkedCarListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a parked vehicle to park out.");
                return;
            }

            ListViewItem selectedItem = ParkedCarListView.SelectedItems[0];

            string plateNumber = selectedItem.SubItems[0].Text;

            // Remove plate number from the HashSet
            plateNumbers.Remove(plateNumber);

            ParkedCarListView.Items.Remove(selectedItem);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Your code for listView1_SelectedIndexChanged
        }

        private void Park_out_Load(object sender, EventArgs e)
        {
            // Your code for Park_out_Load
        }
    }
}
