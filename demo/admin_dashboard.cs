using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo
{
    public partial class admin_dashboard : Form
    {


        public admin_dashboard()
        {
            InitializeComponent();
        }

        private void admin_dashboard_Load(object sender, EventArgs e)
        {
            admin_home ah = new admin_home();
            admin_home(ah);
        }

        private void userlist(users_list ul)
        {
            panel2.Controls.Clear();
            ul.TopLevel = false;
            ul.FormBorderStyle = FormBorderStyle.None;
            ul.Dock = DockStyle.Fill;
            panel2.Controls.Add(ul);
            ul.Show();
        }

        private void product(product p)
        {
            panel2.Controls.Clear();           
            p.TopLevel = false;
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            panel2.Controls.Add(p);
            p.Show();
        }
        private void olpanel(order_list ori)
        {
            panel2.Controls.Clear();
            ori.TopLevel = false;
            ori.FormBorderStyle = FormBorderStyle.None;
            ori.Dock = DockStyle.Fill;
            panel2.Controls.Add(ori);
            ori.Show();
        }
        private void admin_home(admin_home ah)
        {
            panel2.Controls.Clear();
            ah.TopLevel = false;
            ah.FormBorderStyle = FormBorderStyle.None;
            ah.Dock = DockStyle.Fill;
            panel2.Controls.Add(ah);
            ah.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            admin_home ah = new admin_home();
            admin_home(ah);
     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            users_list ul = new users_list();
            userlist(ul); 
        }
 
        private void button3_Click(object sender, EventArgs e)
        {  
            product p = new product();
            product(p);    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            order_list ori = new order_list();
            olpanel(ori);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            add_product ap = new add_product();
           
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void admin_dashboard_Load_1(object sender, EventArgs e)
        {
            admin_home ah = new admin_home();
            admin_home(ah); 
        }
    }
}
