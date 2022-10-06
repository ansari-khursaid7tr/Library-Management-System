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
    public partial class ChangePassword : Form
    {
        string ku;
        public ChangePassword(string kk)
        {
            InitializeComponent();
            textBox4.Text = kk;
            ku = kk;

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }
        private void change()
        {


            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Admin SET Password=@aaa1 where Password=@aaa2", con);

            cmd.Parameters.Add("aaa1", textBox2.Text);
            cmd.Parameters.Add("aaa2", textBox1.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Password Changed Successfully");

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            textBox4.Text = ku;
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                MessageBox.Show(" EMPTY FIELD NOT ALLOWED");


            else if (textBox2.Text == textBox3.Text)
            {
                SqlConnection
                con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select*from Admin where Username= '" + textBox4.Text + "' and Password ='" + textBox1.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    change();

                }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }
            }
            else
                MessageBox.Show("Incorrect Password");
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
