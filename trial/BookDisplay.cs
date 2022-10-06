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

namespace trial
{
    public partial class BookDisplay : Form
    {
        int num = 0;     int quantity = 0;
        public BookDisplay()
        {
            InitializeComponent();
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
             if (selectbox.Text == "")
                MessageBox.Show("Select ID", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select BookNumber from Books where BookNumber='" + selectbox.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    num = 1;
                    SqlConnection
                 con1 = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("SELECT * from Books where  BookNumber='" + selectbox.Text + "'", con1);
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    dataGridView1.DataSource = dt1;
                    con1.Close();
                }
                else
                    MessageBox.Show("ID Mismatched", " ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (num == 1)
            {
                if (MessageBox.Show("Are you sure?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection
                  con2 = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                    con2.Open();
                    SqlCommand jj = new SqlCommand("delete Books where BookNumber=@a1", con2);
                    jj.Parameters.Add("@a1", Convert.ToInt32(selectbox.Text));
                    SqlDataReader sse;
                    sse = jj.ExecuteReader();
                    MessageBox.Show("Successfully Removed", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con2.Close();
                    Show();
                    num = 0;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
            selectbox.Text = " ";
        }

        private void BookDisplay_Load(object sender, EventArgs e)
        {
            SqlConnection
             con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Books", con);// where ID='" + textBox1.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            Show();
            con.Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection
            con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Books", con);// where ID='" + textBox1.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            Show();
            con.Close();
            selectbox.Text = " ";
            //quan.ResetText();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (selectbox.Text == "")
            {

                MessageBox.Show("Select ID", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            
                SqlCommand cmd = new SqlCommand("select BookNumber from Books where BookNumber='" + selectbox.Text + "'", con);
                try
                {
                    con.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("error");
                }

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                // quan.Text = quantity;
                if (dt.Rows.Count > 0)
                {
                    num = 1;
                    SqlConnection
                 con1 = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("select * Books where  BookNumber='" + selectbox.Text + "'", con1);
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt);
                    dataGridView1.DataSource = dt1;
                    con1.Close();



                }
                else
                    MessageBox.Show("ID Mismatched", " ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (selectbox.Text == "")
            {

                MessageBox.Show("Select ID", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Quantity from Books where BookNumber='" + selectbox.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                // quan.Text = quantity;
                if (dt.Rows.Count > 0)
                {
                    num = 1;
                   
                    SqlConnection
                 con1 = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("select * Books where  BookNumber='" + selectbox.Text + "'", con1);
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt);
                    dataGridView1.DataSource = dt1;
                    con1.Close();



                }
                else
                    MessageBox.Show("ID Mismatched", " ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            BookPrint p = new BookPrint();
            p.Show();
            CrystalReport8 cr = new CrystalReport8();
            SqlConnection coon = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            coon.Open();
            //  coon.ConnectionString = ConfigurationManager.ConnectionStrings["trial.Properties.Settings.registerConnectionString"];
            string j = "select * from Books";
            DataSet ds = new DataSet();
            SqlDataAdapter sd = new SqlDataAdapter(j, coon);
            sd.Fill(ds, "Books");
            DataTable dt = ds.Tables["Books"];
            cr.SetDataSource(ds.Tables["Books"]);
            coon.Close();
            //  p.rprt.Refresh();
        }
    }
}
