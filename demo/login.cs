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
    public partial class login : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        DataGridViewCellEventArgs es;

        String s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\demo\demo\demo\Properties\electronic_shop.mdf;Integrated Security=True";
        String i, d;
        int id;
        int userId;
        void connection()
        {
            con = new SqlConnection(s);
            con.Open();
        }
        public static class UserSession
        {
            public static int UserID { get; set; }  
        }
        public login()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            user_login ul = new user_login();
            ul.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection();

            string checkLoginQuery = "SELECT user_id, user_name FROM register WHERE email_id = @email_id AND password = @password";

            cmd = new SqlCommand(checkLoginQuery, con);
            cmd.Parameters.AddWithValue("@email_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                userId= Convert.ToInt32(reader["user_id"]);
                string full_name = reader["user_name"].ToString();

                MessageBox.Show("Login successful! User ID: " + userId);



                user_dashboard dash = new user_dashboard(userId, full_name);

                this.Hide();
                dash.Show();
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }

            reader.Close();
            con.Close();

        }
    }
}
