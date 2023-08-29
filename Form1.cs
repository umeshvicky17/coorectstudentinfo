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

namespace technosus2
{
    public partial class Form1 : Form
    {

        static String cnstr = "server=umesh-pc\\sqlexpress;database=technosus;Integrated security = true";
        SqlConnection mycnn = new SqlConnection(cnstr);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                mycnn.Open();
               // MessageBox.Show("Success");
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand myinsert = new SqlCommand();
                myinsert.Connection = mycnn;
                myinsert.CommandType = CommandType.Text;
                myinsert.CommandText = "insert into Student values (" + textBox6.Text + ",'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + ",'" + textBox5.Text + "','" + textBox7.Text + "')";
               

                myinsert.ExecuteNonQuery();
                MessageBox.Show("Table record added");
                clear();
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand myupdate = new SqlCommand();
                myupdate.Connection = mycnn;
                myupdate.CommandType = CommandType.Text;
                myupdate.CommandText = "update Student set homeadress = '" + textBox5.Text + "' where id = " + textBox6.Text + "";
                myupdate.ExecuteNonQuery();
                MessageBox.Show("employeee record updated.....");
                myupdate.Dispose();
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        public void clear()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Focus();
        }
            private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand mydelete = new SqlCommand();
                mydelete.Connection = mycnn;
                mydelete.CommandType = CommandType.Text;
                mydelete.CommandText = "delete from Student where id = " + textBox8.Text + "";
                mydelete.ExecuteNonQuery();
                MessageBox.Show("employeee record deleted.....");
                clear();
                mydelete.Dispose();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Error in query");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter("select * from Student", mycnn);
                adp.Fill(ds, "tab");
                dataGridView1.DataSource = ds.Tables["tab"];
                dataGridView1.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter("select * from Student where id=" + Convert.ToInt32(textBox8.Text), mycnn);
                adp.Fill(ds, "tab");
                dataGridView1.DataSource = ds.Tables["tab"];
                dataGridView1.Show();



                SqlDataReader dr;
                SqlCommand mycmd = new SqlCommand();
                mycmd.Connection = mycnn;
                mycmd.CommandText = "select * from Student where id=" + Convert.ToInt32(textBox8.Text);
                dr = mycmd.ExecuteReader();
                if (dr.HasRows)
                {
                  
                    dr.Read();
                    textBox6.Text = dr[0].ToString();
                    textBox1.Text = dr[1].ToString();
                    textBox2.Text = dr[2].ToString();
                    textBox3.Text = dr[3].ToString();
                    textBox4.Text = dr[4].ToString();
                    textBox5.Text = dr[5].ToString();
                    textBox7.Text = dr[6].ToString();
                }
            

               
                    else
                    {
                        MessageBox.Show("No record found");
                        clear();
                    }
                    dr.Close();

                
            }
            else if (radioButton2.Checked == true)
            {
               
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter adp = new SqlDataAdapter("select * from Student where studentname like '%" + textBox9.Text+"%'", mycnn);
                    adp.Fill(ds, "tab");
                    dataGridView1.DataSource = ds.Tables["tab"];
                    dataGridView1.Show();
                }
            }
            else if (radioButton3.Checked == true)
            {
              
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter adp = new SqlDataAdapter("select * from Student where registrationdate= cast('" + textBox10.Text+"' as date)", mycnn);
                    adp.Fill(ds, "tab");
                    dataGridView1.DataSource = ds.Tables["tab"];
                    dataGridView1.Show();
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
