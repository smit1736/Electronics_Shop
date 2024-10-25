using System;
using System.Windows.Forms;

namespace demo
{
    public partial class user_home : Form
    {
        int userId;
       
        public user_home(int userId)
        {
            InitializeComponent();
            
            this.userId = userId; // Save the user ID
          
            

        }
      
        private void product_view(product_view pv)
        {
            panel1.Controls.Clear();
            pv.TopLevel = false;
            pv.FormBorderStyle = FormBorderStyle.None;
            pv.Dock = DockStyle.Fill;
            panel1.Controls.Add(pv);
            pv.Show();
        }
        

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            product_view pv = new product_view(userId);
            product_view(pv);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            product_view pv = new product_view(userId);
            product_view(pv);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            product_view pv = new product_view(userId);
            product_view(pv);
        }

        private void user_home_Load(object sender, EventArgs e)
        {

        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     