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
    
        public partial class address : Form
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;
            DataGridViewCellEventArgs es;
     
            String s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\demo\demo\demo\Properties\electronic_shop.mdf;Integrated Security=True";
            String i, d;
            int userId;
            Panel panel4;

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
        public address(int user_id)
            {
                InitializeComponent();
                this.userId = user_id;
            InitializePanel4();
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            }

            public address()
            {
                InitializeComponent();
            
            }
            void connection()
            {
  
                con = new SqlConnection(s);
                con.Open();
            }
            private void textBox6_TextChanged(object sender, EventArgs e)
            {

            }

            private void panel1_Paint(object sender, PaintEventArgs e)
            {

            }

            private void address_Load(object sender, EventArgs e)
            {

            }

       




            private void button1_Click_1(object sender, EventArgs e)
            {
                connection(); 

                try
                {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    MessageBox.Show("Please select a country.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Please enter your first name.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Please enter your mobile number.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Please enter your email.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    MessageBox.Show("Please enter an area.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox8.Text))
                {
                    MessageBox.Show("Please enter a pincode.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    MessageBox.Show("Please enter a city.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox9.Text))
                {
                    MessageBox.Show("Please enter a state.");
                    return;
                }

                
                if (userId <= 0)
                    {
                        MessageBox.Show("Invalid user ID.");
                        return;
                    }
                    else
                    { 
     
                    cmd = new SqlCommand("SELECT user_id FROM register WHERE user_id = @userId", con);
              
                
                    cmd = new SqlCommand("INSERT INTO Address(country, fname, mobile_no, email, house_no, area, landmark, pincode, city, state, customer_id) " + "VALUES('" + comboBox1.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox8.Text + "', '" + textBox7.Text + "', '" + textBox9.Text + "', '" + @userId + "')", con);

                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();


                    MessageBox.Show("Address added successfully.");
                        LoadOrderSummaryPanel();


                    }
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

            private void LoadOrderSummaryPanel()
            {

            foreach (Control control in this.Controls)
            {
                if (control != panel4)
                {
                    control.Visible = false;
                }
            }
            
                  order_summary orderSummaryForm = new order_summary();  // Pass the user ID
                orderSummaryForm.TopLevel = false;
                orderSummaryForm.FormBorderStyle = FormBorderStyle.None;
                orderSummaryForm.Dock = DockStyle.Fill;  // Ensure it fills panel2

                panel4.Controls.Clear();
                 panel4.Visible = true;
            // Add the order summary form to panel2
                 panel4.Controls.Add(orderSummaryForm);
                
                orderSummaryForm.Show();
            }

       
        private void textBox5_TextChanged(object sender, EventArgs e)
            {

            }

            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void button2_Click(object sender, EventArgs e)
            {
           
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
                textBox7.Text = string.Empty;
                textBox8.Text = string.Empty;
                textBox9.Text = string.Empty;

            
                comboBox1.SelectedIndex = -1;

                textBox1.Focus();
            }

            private void button1_Click(object sender, EventArgs e)
            {
          
        }

        }
    }
