﻿using System;
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
    public partial class admin_login : Form
    {
        public admin_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                this.Hide();
                admin_dashboard ad = new admin_dashboard();
                ad.Show();
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect ");
            }
        }

        private void admin_login_Load(object sender, EventArgs e)
        {

        }
    }
}
