using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
namespace demo
{
    public partial class order_summary : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        DataGridViewCellEventArgs es;

        String s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\demo\demo\demo\Properties\electronic_shop.mdf;Integrated Security=True";
        String i, d;
        int id;

        void connection()
        {
            con = new SqlConnection(s);
            con.Open();
        }
        private int productId;
        private string productName;
        private string productPrice;
        private int quantity;
        private int userId;
        private string discountPercentage;
        private void LoadAddressPanel()
        {
            foreach (Control control in this.Controls)
            {
                if (control != panel1)
                {
                    control.Visible = false;
                }
            }

            panel1.Visible = true;  // Show the full-screen panel

            // Clear any previous controls in panel4
            panel1.Controls.Clear();

            // Create an instance of the address form and pass the userId
            address addressForm = new address(userId); // Pass the user ID
            addressForm.TopLevel = false;
            addressForm.FormBorderStyle = FormBorderStyle.None;
            addressForm.Dock = DockStyle.Fill;  // Ensure it fills panel4

            // Add the address form to panel4
            panel1.Controls.Add(addressForm);
            addressForm.Show();
        }
        public order_summary(int userId, int productId, string productName, string productPrice, int quantity,string discountPercentage)
        {
            InitializeComponent();
            this.userId = userId;
            this.productId = productId;
            this.productName = productName;
            this.productPrice = productPrice;
            this.quantity = quantity;
            this.discountPercentage = discountPercentage;
        }

        public order_summary()
        {
            InitializeComponent();
        }

       
       

        private void order_summary_Load(object sender, EventArgs e)
        {
            label1.Text = productName;
            label2.Text = productPrice;
            label3.Text = quantity.ToString();
            label4.Text = discountPercentage;
            // Check if productPrice is null or empty

            if (!string.IsNullOrEmpty(discountPercentage) && discountPercentage != "0")
            {
                label4.Text = discountPercentage + " (which is already applied on the product)";
            }
            else
            {
                label4.Text = "No discount"; // If there's no discount
            }
            if (string.IsNullOrEmpty(productPrice))
            {
              
                return;  // Exit the method early if productPrice is null
            }

            // Remove any currency symbols or non-numeric characters
            string cleanPrice = new string(productPrice.Where(c => char.IsDigit(c) || c == '.').ToArray());

            decimal price;
            if (decimal.TryParse(cleanPrice, out price))
            {
                decimal discount = 0;

                // Try to parse the discountPercentage string to decimal
                if (decimal.TryParse(discountPercentage.TrimEnd('%'), out decimal discountPercent))
                {
                    // Convert percentage to a decimal (e.g., 10% becomes 0.10)
                    discount = (discountPercent / 100) * price * quantity;
                }

                // Calculate total after applying discount
                decimal totalPrice = (price * quantity) - discount;

                // Display the final total after discount in label5, formatted as currency
                label5.Text = totalPrice.ToString("C");
            }
            else
            {
                MessageBox.Show("Invalid product price format.");
                label5.Text = "N/A";
            }
        
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime orderDate = DateTime.Now;
            string orderStatus = "Pending"; // Set default order status

            decimal totalAmount;
            decimal price;
            if (decimal.TryParse(new string(productPrice.Where(c => char.IsDigit(c) || c == '.').ToArray()), out price))
            {
                totalAmount = price * quantity ;
            }
            else
            {
                MessageBox.Show("Invalid product price format.");
                return;
            }
          
           
            try
            {

                connection();

                    // 1. Insert into Orders table
                    string orderQuery = "INSERT INTO Orders (UserID, OrderDate, TotalAmount, OrderStatus) OUTPUT INSERTED.OrderID VALUES (@UserID, @OrderDate, @TotalAmount, @OrderStatus)";
                    SqlCommand orderCommand = new SqlCommand(orderQuery, con);
                    orderCommand.Parameters.AddWithValue("@UserID", userId);
                    orderCommand.Parameters.AddWithValue("@OrderDate", orderDate);
                    orderCommand.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    orderCommand.Parameters.AddWithValue("@OrderStatus", orderStatus);

                    // Get the generated OrderID after the insert
                    int orderId = (int)orderCommand.ExecuteScalar();

                    // 2. Insert into OrderDetails table using the generated OrderID
                    string orderDetailsQuery = "INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price) VALUES (@OrderID, @ProductID, @Quantity, @Price)";
                    SqlCommand orderDetailsCommand = new SqlCommand(orderDetailsQuery, con);
                    orderDetailsCommand.Parameters.AddWithValue("@OrderID", orderId);
                    orderDetailsCommand.Parameters.AddWithValue("@ProductID", productId);
                    orderDetailsCommand.Parameters.AddWithValue("@Quantity", quantity);
                    orderDetailsCommand.Parameters.AddWithValue("@Price", price);

                    orderDetailsCommand.ExecuteNonQuery();

                MessageBox.Show("Order placed successfully!");
                LoadAddressPanel();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error placing order: " + ex.Message);
            }
        }
    }

}
