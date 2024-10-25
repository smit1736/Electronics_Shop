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
    public partial class user_dashboard : Form
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

        int userId;
        private string username;
        public user_dashboard(int userId, string full_name)
        {
            InitializeComponent();
            this.userId = userId;  // Save the user ID
            this.username = full_name;  // Store the passed username

            // Display the username in the label3
            label3.Text = "Hello, " + full_name;  // Display username in label3
        }
        

        void connection()
        {
            con = new SqlConnection(s);
            con.Open();
        }

       
        public user_dashboard()
        {
            InitializeComponent();
        }

        private void product_view(product_view pv)
        {
            panel2.Controls.Clear();
            pv.TopLevel = false;
            pv.FormBorderStyle = FormBorderStyle.None;
            pv.Dock = DockStyle.Fill;
            panel2.Controls.Add(pv);
            pv.Show();
        }

        private void checkout(checkout co)
        {
            panel2.Controls.Clear();
            co.TopLevel = false;
            co.FormBorderStyle = FormBorderStyle.None;
            co.Dock = DockStyle.Fill;
            panel2.Controls.Add(co);
            co.Show();
        }

        private void user_home(user_home hm)
        {
            panel2.Controls.Clear();
            hm.TopLevel = false;
            hm.FormBorderStyle = FormBorderStyle.None;
            hm.Dock = DockStyle.Fill;
            panel2.Controls.Add(hm);
            hm.Show();
        }

        private void address(address a)
        {
            panel2.Controls.Clear();
            a.TopLevel = false;
            a.FormBorderStyle = FormBorderStyle.None;
            a.Dock = DockStyle.Fill;
            panel2.Controls.Add(a);
            a.Show();
        }

        private void order_summary(order_summary os)
        {
            panel2.Controls.Clear();
            os.TopLevel = false;
            os.FormBorderStyle = FormBorderStyle.None;
            os.Dock = DockStyle.Fill;
            panel2.Controls.Add(os);
            os.Show();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            user_home hm = new user_home(userId);
            user_home(hm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            product_view pv = new product_view(userId);
            product_view(pv);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            address a = new address(userId);
            address(a);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            order_summary os = new order_summary();
            order_summary(os);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void user_dashboard_Load(object sender, EventArgs e)
        {
            user_home hm = new user_home(userId);
            user_home(hm);
            label3.Text = "Hello, " + username;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}








