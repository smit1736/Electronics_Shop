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

    public partial class product_view : Form
    {
        private Panel panel4;
        SqlConnection con;//used for connection
        SqlCommand cmd;//insert update dlt
        SqlDataAdapter da;
        DataSet ds;
        DataGridViewCellEventArgs es;

        String s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\demo\demo\demo\Properties\electronic_shop.mdf;Integrated Security=True";
        String i, d;
        int id;
        int currentIndex = 0; // Index for browsing products
        DataTable productTable;
        const int ProductsPerPage = 3;
        private int userId;
        


        void connection()
        {
            con = new SqlConnection(s);
            con.Open();
        }

        public product_view(int userId)
        {
            this.userId=userId;
            InitializeComponent();
            InitializePanel4();
            FetchProductInformation();

         
        }
        private void InitializePanel4()
        {
            // Create and set panel4 properties
            panel4 = new Panel();
            panel4.Name = "panel4";
            panel4.Dock = DockStyle.Fill;  // Set to fill the entire form
            panel4.Visible = false;  // Initially, the panel will be hidden
            panel4.BackColor = Color.LightGray;  // Optional: Set a background color

            // Add the panel to the form's controls
            this.Controls.Add(panel4);
        }

        private void FetchProductInformation()
        {

            try
            {
                connection();
                cmd = new SqlCommand("SELECT ProductID,ProductName, Description, Price, DiscountPercentage, OfferPrice, StockQuantity, ProductImage FROM Products", con);
                da = new SqlDataAdapter(cmd);
                productTable = new DataTable();
                da.Fill(productTable);

                if (productTable.Rows.Count > 0)
                {
                    DisplayProducts(0); // Display first three products
                }
                else
                {
                    MessageBox.Show("No products found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching product information: " + ex.Message);
            }
            finally
            {
                con?.Close();
            }

        }
        private void DisplayProducts(int startIndex)
        {
            // Clear previous product details
            ClearProductDetails();

            textBox1.Visible = true; // Always visible since one product exists
            textBox2.Visible = productTable.Rows.Count > 1; // Show if there is more than 1 product
            textBox3.Visible = productTable.Rows.Count > 2;
            // By default, hide all buttons
            button8.Visible = button11.Visible = false;

            for (int i = 0; i < ProductsPerPage; i++)
            {
                int index = startIndex + i;
                if (index < productTable.Rows.Count)
                {
                    DataRow row = productTable.Rows[index];

                    // Display product details in labels and pictureboxes
                    switch (i)
                    {
                        case 0:
                            DisplayProductDetails(row, label22, label1, label2, label3, label4, label5, label6, pictureBox1);
                            label22.Text = row["ProductID"].ToString(); // Set ProductID for the first product
                            break;
                        case 1:
                            DisplayProductDetails(row, label23, label7, label9, label11, label12, label10, label8, pictureBox2);
                            label23.Text = row["ProductID"].ToString(); // Set ProductID for the second product
                            button8.Visible = true;  // Show the button for the second product if available
                            break;
                        case 2:
                            DisplayProductDetails(row, label24, label13, label15, label17, label18, label16, label14, pictureBox3);
                            label24.Text = row["ProductID"].ToString(); // Set ProductID for the third product
                            button11.Visible = true;  // Show the button for the third product if available
                            break;
                    }
                }
            }

            // Hide buttons if fewer than three products are displayed
            int remainingProducts = productTable.Rows.Count - startIndex;

            if (remainingProducts < 3)
            {
                button11.Visible = false;  // Hide button11 if fewer than 3 products are displayed
            }

            if (remainingProducts < 2)
            {
                button8.Visible = false;  // Hide button8 if fewer than 2 products are displayed
            }
        }



        private void ClearProductDetails()
        {
            // Clear previous product details
            label1.Text = label2.Text = label3.Text = label4.Text = label5.Text = label6.Text = "";
            label7.Text = label9.Text = label11.Text = label12.Text = label10.Text = label8.Text = "";
            label13.Text = label15.Text = label17.Text = label18.Text = label16.Text = label14.Text = "";

            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
        }

        private void DisplayProductDetails(DataRow row,Label idLabel,Label nameLabel, Label descLabel, Label priceLabel,
    Label discountLabel, Label offerPriceLabel, Label stockLabel, PictureBox pictureBox)
        {
            idLabel.Text = "Product Id:" + row["ProductID"].ToString();
            nameLabel.Text = "Product Name: " + row["ProductName"].ToString();
            descLabel.Text = "Description: " + row["Description"].ToString();
            priceLabel.Text = "Price: ₹" + row["Price"].ToString();
            discountLabel.Text = "Discount: " + row["DiscountPercentage"].ToString() + "%";
            offerPriceLabel.Text = "Offer Price: ₹" + row["OfferPrice"].ToString();
            stockLabel.Text = "Stock Quantity: " + row["StockQuantity"].ToString();
         



            // Display product image in PictureBox
            string imagePath = row["ProductImage"].ToString();
            if (File.Exists(imagePath))
            {
                pictureBox.Image = Image.FromFile(imagePath);
            }
            else
            {
                pictureBox.Image = null;
                MessageBox.Show("Image file not found for: " + row["ProductName"].ToString());
            }

         


            // Set up quantity buttons

        
        }

           

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex -= ProductsPerPage;
                DisplayProducts(currentIndex);
            }
            else
            {
                MessageBox.Show("This is the first page of products.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentIndex + ProductsPerPage < productTable.Rows.Count)
            {
                currentIndex += ProductsPerPage;
                DisplayProducts(currentIndex);
            }
            else
            {
                MessageBox.Show("This is the last page of products.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        




       


        private void button5_Click(object sender, EventArgs e)
        {
            int selectedProductId = Convert.ToInt32(label22.Text);
            string productName = label1.Text;
            string productPrice = label5.Text;
            string discountPercentage = label4.Text;
            // Fetch the quantity from comboBox1
            int quantity;
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && int.TryParse(textBox1.Text, out quantity) && quantity > 0)
            {
                // Proceed with the valid quantity
                LoadOrderSummaryPanel(selectedProductId, productName, productPrice, quantity, discountPercentage);
            }
            else
            {
                MessageBox.Show("Please select a valid quantity for Product 1.");
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            int selectedProductId = Convert.ToInt32(label23.Text);
            string productName = label7.Text;
            string productPrice = label10.Text;
            string discountPercentage = label12.Text;
            int quantity;
           
            if (!string.IsNullOrWhiteSpace(textBox2.Text) && int.TryParse(textBox2.Text, out quantity) && quantity > 0)
            {
               
                LoadOrderSummaryPanel(selectedProductId, productName, productPrice, quantity, discountPercentage);
            }
            else
            {
                MessageBox.Show("Please select a valid quantity for Product 1.");
            }

        }
        private void button11_Click(object sender, EventArgs e)
        {
            int selectedProductId = Convert.ToInt32(label24.Text);
            string productName = label13.Text;
            string productPrice = label16.Text;
            string discountPercentage = label18.Text;
            int quantity;
           
            if (!string.IsNullOrWhiteSpace(textBox3.Text) && int.TryParse(textBox3.Text, out quantity) && quantity > 0)
            {
                
                LoadOrderSummaryPanel(selectedProductId, productName, productPrice, quantity, discountPercentage);
            }
            else
            {
                MessageBox.Show("Please select a valid quantity for Product 1.");
            }

        }
        private void LoadOrderSummaryPanel(int productId, string productName, string price, int quantity, string discountPercentage)
        {

            foreach (Control control in this.Controls)
            {
                if (control != panel4)
                {
                    control.Visible = false;
                }
            }

            // Create an instance of the order summary form and pass the required parameters
            order_summary orderSummaryForm = new order_summary(userId, productId, productName, price, quantity, discountPercentage);
            orderSummaryForm.TopLevel = false;
            orderSummaryForm.FormBorderStyle = FormBorderStyle.None;
            orderSummaryForm.Dock = DockStyle.Fill;  // Ensure it fills panel4

            // Add the order summary form to panel4
            panel4.Controls.Clear();
            panel4.Visible = true;
            panel4.Controls.Add(orderSummaryForm);

            // Show the order summary form
            orderSummaryForm.Show();
        }
        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void product_view_Load(object sender, EventArgs e)
        {

            InitializePlaceholders();
        }
        private void InitializePlaceholders()
        {
            // Set up placeholder text and event handlers for textBox1
            SetupPlaceholder(textBox1, "Enter Quantity");

            // Set up placeholder text and event handlers for textBox2
            SetupPlaceholder(textBox2, "Enter Quantity");

            // Set up placeholder text and event handlers for textBox3
            SetupPlaceholder(textBox3, "Enter Quantity");
        }

        private void SetupPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.ForeColor = Color.Gray;
            textBox.Text = placeholderText;

            textBox.GotFocus += (sender, e) => RemovePlaceholder(textBox, placeholderText);
            textBox.LostFocus += (sender, e) => ShowPlaceholder(textBox, placeholderText);
        }

        private void RemovePlaceholder(TextBox textBox, string placeholderText)
        {
            if (textBox.Text == placeholderText)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        // Restore placeholder text if the TextBox is empty
        private void ShowPlaceholder(TextBox textBox, string placeholderText)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.ForeColor = Color.Gray;
                textBox.Text = placeholderText;
            }
        }
        private void panelAddress_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void qtyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadAddressPanel(int productId, string productName, string price, int quantity)
        {
            foreach (Control control in this.Controls)
            {
                if (control != panel4)
                {
                    control.Visible = false;
                }
            }

            panel4.Visible = true;  // Show the full-screen panel

            // Clear any previous controls in panel4
            panel4.Controls.Clear();

            // Create an instance of the address form and pass the userId
            address addressForm = new address(userId); // Pass the user ID
            addressForm.TopLevel = false;
            addressForm.FormBorderStyle = FormBorderStyle.None;
            addressForm.Dock = DockStyle.Fill;  // Ensure it fills panel4

            // Add the address form to panel4
            panel4.Controls.Add(addressForm);
            addressForm.Show();
        }

    }

}

