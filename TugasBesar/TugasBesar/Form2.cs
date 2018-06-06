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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection Conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string qry;

        private void Form2_Load(object sender, EventArgs e)
        {
            Conn.ConnectionString = "Data Source = DESKTOP-J1DNFS8\\SQLEXPRESS; Initial Catalog=LAUNDRY; Integrated Security=True";
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 X = new Form4();
            X.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                qry = "SELECT*FROM Table_His";
                cmd = new SqlCommand();
                cmd.Connection = Conn;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                qry = "INSERT INTO Table_His (Nota,Nama,Tanggal)VALUES('" + textBox1.Text + "','" + textBox2.Text + "','"
                + dateTimePicker1.Text + "')";
                cmd.Connection = Conn;
                cmd.CommandText = qry;
                MessageBox.Show("Berhasil Disimpan");
                Conn.Open();
                cmd.ExecuteNonQuery();
                button2_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                qry = "DELETE FROM Table_His WHERE Nota = " + dg1.CurrentRow.Cells["Nota"].FormattedValue;
                cmd.Connection = Conn;
                cmd.CommandText = qry;
                MessageBox.Show("Berhasil Disimpan");
                Conn.Open();
                cmd.ExecuteNonQuery();
                button2_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
        }
    }
}
