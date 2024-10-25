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
    public partial class user_login : Form
    {
        public user_login()
        {
            InitializeComponent();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp r = new SignUp();
            r.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.Show();
        }

        private void desktop_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
