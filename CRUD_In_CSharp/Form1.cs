using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_In_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=TAISASILVA\SQLEXPRESS;Initial Catalog=Produto;User ID=sa;Password=12061996");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand command = new SqlCommand("insert into ProductInfo_Tab values ('" + int.Parse(textBox1.Text) + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox1.Text + "', getdate(), getdate())", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Well Done. Created");
            con.Close();
            BindData();
        }
        void BindData()
        {
            SqlCommand command = new SqlCommand("Select * from ProductInfo_Tab", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("update ProductInfo_Tab set ItemName = '"+textBox2.Text+ "', Design = '" + textBox3.Text + "', Color = '"+comboBox1.Text+"', UpdateDate = '"+DateTime.Parse(dateTimePicker1.Text)+"' where ProductID= '"+int.Parse(textBox1.Text)+"'", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated.");
            BindData();
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Are you sure?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Delete ProductInfo_Tab where ProductID= '" + int.Parse(textBox1.Text) + "'", con);
                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Deleted.");
                    BindData();
                }
            }
            else
            {
                MessageBox.Show("Put Product ID");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * from ProductInfo_Tab where ProductID = '"+int.Parse(textBox1.Text)+"' ", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

       
    }
}
