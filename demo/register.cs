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
    public partial class SignUp : Form
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

        public SignUp()
        {
            InitializeComponent();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Mobile number cannot be empty.");
                return;
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Email ID cannot be empty.");
                return;
            }

            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Password cannot be empty.");
                return;
            }
            connection();

            try
            {

                cmd = new SqlCommand("insert into register(user_name,mobile_no,email_id,password) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", con);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Resister Successfully");
                this.Hide();
                login l = new login();
                l.Show();
            }
            catch (Exception ex)
            {
                // Handle any errors
                MessageBox.Show("An error occurred: " + ex.Message);
            }



        }
        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            user_login ul = new user_login();
            ul.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
