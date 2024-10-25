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
    
    public partial class users_list : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        DataGridViewCellEventArgs es;
        int id1;

        String s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\demo\demo\demo\Properties\electronic_shop.mdf;Integrated Security=True";
        String i, d;
        int id;

        void connection()
        {
            con = new SqlConnection(s);
            con.Open();
        }
        public users_list()
        {
            InitializeComponent();
        }

        private void users_list_Load(object sender, EventArgs e)
        {
           

            
            dataGridView1.BackgroundColor = Color.White;

          
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;

            gridfill();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) 
            {
                try
                {
                    connection();

                    
                    id1 = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["user_id"].Value);

                    
                    var confirmResult = MessageBox.Show("Are you sure to delete this user?",
                                                         "Confirm Delete",
                                                         MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {
                  
                        cmd = new SqlCommand("DELETE FROM register WHERE user_id = @user_id", con);
                        cmd.Parameters.AddWithValue("@user_id", id1);

                        cmd.ExecuteNonQuery();

                        
                        gridfill();

                        MessageBox.Show("User deleted successfully from the database.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message);
                }
                finally
                {
                    con.Close(); 
                }
            }

        }

        private void nameSearchTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click_TextChanged(object sender, EventArgs e)
        {
            string userId = buttonSearch_Click.Text.Trim();

            // Check if the input is a valid integer (since user_id is an integer)
            if (int.TryParse(userId, out int id))
            {
                SearchDataById(userId);
            }
           
        }

        private void SearchDataById(string userId)
        {
            try
            {
                connection();  

                
                string query = "SELECT user_id, user_name, mobile_no, email_id, password FROM register WHERE user_id = @userId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", userId); 

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close(); 
                }
            }
        }
        void gridfill()
        {
            try
            {
                connection();
                da = new SqlDataAdapter("SELECT user_id, user_name, mobile_no, email_id FROM register", con);
                ds = new DataSet();
                da.Fill(ds); 
                dataGridView1.DataSource = ds.Tables[0]; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
