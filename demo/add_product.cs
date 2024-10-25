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
    public partial class add_product : Form
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

        public add_product()
        {
            InitializeComponent();
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        void uploading()
        {
            openFileDialog1.ShowDialog();
            try
            {
                i = openFileDialog1.FileName.ToString();
                pictureBox1.Load(i);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            uploading();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection();

                d = Application.StartupPath + "\\images\\" + openFileDialog1.SafeFileName.ToString();

                System.IO.File.Copy(i, d, true);

                cmd = new SqlCommand("insert into Products(ProductID,ProductCompany,ProductName,Category,Price,DiscountPercentage,OfferPrice,Description,StockQuantity,ProductImage) values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','"+d+"')", con);

                cmd.ExecuteNonQuery();
                
                
            }
            catch(Exception se)
            {
                MessageBox.Show(""+se);
            }
        }
    }
}
