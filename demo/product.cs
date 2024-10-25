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
    public partial class product : Form
    {
        SqlConnection con;
        SqlCommand cmd;
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
        public product()
        {
            InitializeComponent();
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            connection();
            fillGrid();
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

     
        private void product_Load(object sender, EventArgs e)
        {
            gridFill();
            connection();
            fillGrid();
            
        }
        void gridFill()
        {
            connection();
            da = new SqlDataAdapter("select * from Products", con);

            DataTable dt = new DataTable(); 
            da.Fill(dt);

            dt.Columns.Add("images", Type.GetType("System.Byte[]"));

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataRow drow in dt.Rows)
            {
                drow["images"] = File.ReadAllBytes(drow["ProductImage"].ToString());
            }

            dataGridView1.DataSource = dt;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (button1.Text == "Add")
            {
                try
                {
                    connection();

                    // Ensure file is selected before copying it
                    if (!string.IsNullOrEmpty(openFileDialog1.FileName) && File.Exists(openFileDialog1.FileName))
                    {
                        d = Application.StartupPath + "\\images\\" + openFileDialog1.SafeFileName;
                        System.IO.File.Copy(openFileDialog1.FileName, d, true); // Copy image to the designated path
                    }
                    else
                    {
                        d = "";
                    }

                    cmd = new SqlCommand("insert into Products(ProductID,ProductCompany,ProductName,Category,Price,DiscountPercentage,OfferPrice,Description,StockQuantity,ProductImage) values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + d + "')", con);

                    cmd.ExecuteNonQuery();
                    fillGrid();
                    gridFill();
                }
                catch (Exception se)
                {
                    MessageBox.Show("" + se);
                }
            }
            else
            {
                connection();
                id = Convert.ToInt16(dataGridView1.Rows[es.RowIndex].Cells["ProductID"].Value);

                // Check if a new image was selected
                if (!string.IsNullOrEmpty(openFileDialog1.FileName) && File.Exists(openFileDialog1.FileName))
                {
                    d = Application.StartupPath + "\\images\\" + openFileDialog1.SafeFileName;
                    System.IO.File.Copy(openFileDialog1.FileName, d, true); // Copy new image to the designated path
                }
                else
                {
                    // If no new image is selected, use the existing image
                    d = dataGridView1.Rows[es.RowIndex].Cells["ProductImage"].Value.ToString();
                }

                // Update product information with or without a new image
                cmd = new SqlCommand("Update Products set ProductID = '" + textBox1.Text + "'," + "ProductCompany = '" + comboBox1.Text + "'," + "ProductName = '" + textBox2.Text + "'," + "Category = '" + comboBox2.Text + "'," + "Price = '" + textBox4.Text + "'," + "DiscountPercentage = '" + textBox5.Text + "'," + "OfferPrice = '" + textBox6.Text + "'," + "Description = '" + textBox7.Text + "'," + "StockQuantity = '" + textBox8.Text + "'," + "ProductImage = '" + d + "' where ProductID = '" + id + "'", con);

                cmd.ExecuteNonQuery();
                fillGrid();
                gridFill();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            uploading();
        }
        void fillGrid()
        {
            connection();
            da = new SqlDataAdapter("select * from Products", con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                es = e; 
            }
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Update")  // For Update
            {
                button1.Text = "Update";
                es = e;
                connection();
                id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["ProductID"].Value);

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ProductID"].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ProductCompany"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Category"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["DiscountPercentage"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["OfferPrice"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["StockQuantity"].Value.ToString();
                string imagePath = dataGridView1.Rows[e.RowIndex].Cells["ProductImage"].Value.ToString();

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath)) // Ensure the image path is valid and exists
                {
                    pictureBox1.Load(imagePath); // Display the existing image in pictureBox1
                }
            }
            else  // For Delete
            {
                id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["ProductID"].Value);
                cmd = new SqlCommand("delete from Products where ProductID = '" + id + "'", con);
                cmd.ExecuteNonQuery();
                gridFill();
                fillGrid();
            }
        
    }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

     
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click_1(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {

        }

       

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

    }
}

