using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TugasBesar
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string qry;

        private void Form3_Load(object sender, EventArgs e)
        {
            Con.ConnectionString = "Data Source = DESKTOP-J1DNFS8\\SQLEXPRESS; Initial Catalog=LAUNDRY; Integrated Security=True";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                qry = "SELECT*FROM Table_laundry";
                cmd = new SqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = qry;
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                dg1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                da.Dispose();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double berat = double.Parse(textBox3.Text);
            textBox4.Text = (3000 * berat).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 X = new Form4();
            X.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                qry = "INSERT INTO Table_laundry (Nota,Nama,Tanggal,Berat,Harga)VALUES('" + textBox1.Text + "','" + textBox2.Text + "','"
                + dateTimePicker1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                cmd.Connection = Con;
                cmd.CommandText = qry;
                MessageBox.Show("Berhasil Disimpan");
                Con.Open();
                cmd.ExecuteNonQuery();
                button3_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                qry = "DELETE FROM Table_laundry WHERE Nota = " + dg1.CurrentRow.Cells["Nota"].FormattedValue;
                cmd.Connection = Con;
                cmd.CommandText = qry;
                MessageBox.Show("Berhasil Disimpan");
                Con.Open();
                cmd.ExecuteNonQuery();
                button3_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
        }

        
    }
}
