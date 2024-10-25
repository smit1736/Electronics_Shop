using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace demo
{
    public partial class admin_home : Form
    {
        SqlConnection con;
        SqlCommand cmd;

      
        String s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\demo\demo\demo\Properties\electronic_shop.mdf;Integrated Security=True";

        public admin_home()
        {
            InitializeComponent();
            ShowLoginCount();
            ShowProductCount();
        }

        void connection()
        {
            con = new SqlConnection(s); 
            con.Open();
        }

     
        void ShowLoginCount()
        {
            try
            {
                connection(); 
                string query = "SELECT COUNT(DISTINCT user_id) AS LoginCount FROM register"; 
                cmd = new SqlCommand(query, con);
                int loginCount = (int)cmd.ExecuteScalar();  

               
                label1.Text = "Number of users logged in: " + loginCount.ToString();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();  
            }
        }

        void ShowProductCount()
        {
            try
            {
                connection();
                string query = "SELECT COUNT(*) AS ProductCount FROM Products";
                cmd = new SqlCommand(query, con);
                int productCount = (int)cmd.ExecuteScalar();

             
                label2.Text = "Number of products: " + productCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void home_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
                
        }
    }
}
