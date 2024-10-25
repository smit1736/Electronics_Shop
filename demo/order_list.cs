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
    public partial class order_list : Form
    {
        SqlConnection con;//used for connection
        SqlCommand cmd;//insert update dlt
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

        public order_list()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }


        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
        private void LoadOrders()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\demo\demo\demo\Properties\electronic_shop.mdf;Integrated Security=True";

            string query = "SELECT OrderID, UserID, OrderDate, TotalAmount, OrderStatus FROM Orders";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Clear previous content
                    tableLayoutPanelOrders.Controls.Clear();
                    tableLayoutPanelOrders.RowCount = 0;  // Reset the rows
                    tableLayoutPanelOrders.ColumnCount = 5;  // We know we have 5 columns

                    // Add header row with style
                    AddTableHeader();

                    // Add data rows
                    foreach (DataRow row in dt.Rows)
                    {
                        AddOrderRow(row);
                    }

                    // Ensure auto-size and refresh
                    tableLayoutPanelOrders.AutoSize = true;
                    tableLayoutPanelOrders.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading orders: " + ex.Message);
                }
            }
        }

        private void AddTableHeader()
        {
            tableLayoutPanelOrders.RowCount = 1;  // Set the first row for the header

            // Create styled headers
            AddStyledHeader("Order ID", 0);
            AddStyledHeader("User ID", 1);
            AddStyledHeader("Order Date", 2);
            AddStyledHeader("Total Amount", 3);
            AddStyledHeader("Order Status", 4);
        }

        private void AddStyledHeader(string text, int column)
        {
            Label headerLabel = new Label
            {
                Text = text,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightGray,  // Header background color
                BorderStyle = BorderStyle.FixedSingle,  // Border for the header
                Padding = new Padding(10),  // Add padding for better spacing
                Font = new Font("Arial", 10, FontStyle.Bold)  // Optional: change font for header
            };
            tableLayoutPanelOrders.Controls.Add(headerLabel, column, 0);  // Add header to row 0
        }

        private void AddOrderRow(DataRow row)
        {
            int currentRow = tableLayoutPanelOrders.RowCount++;  // Increment the row count

            AddStyledCell(row["OrderID"].ToString(), 0, currentRow);
            AddStyledCell(row["UserID"].ToString(), 1, currentRow);
            AddStyledCell(Convert.ToDateTime(row["OrderDate"]).ToString("MM/dd/yyyy"), 2, currentRow);
            AddStyledCell(Convert.ToDecimal(row["TotalAmount"]).ToString("C"), 3, currentRow);
            AddStyledCell(row["OrderStatus"].ToString(), 4, currentRow);
        }

        private void AddStyledCell(string text, int column, int row)
        {
            Label cellLabel = new Label
            {
                Text = text,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle,  // Border for each cell
                Padding = new Padding(5)  // Padding to make the text more readable
            };
            tableLayoutPanelOrders.Controls.Add(cellLabel, column, row);  // Add cell to the current row and column
        }


    }

}
