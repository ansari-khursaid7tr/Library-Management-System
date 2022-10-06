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
    public partial class ModifyPassword : Form
    {
        public ModifyPassword()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection
              con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("Select Password, Username from Admin where Password = '" + textBox2.Text + "' and Username = '" + textBox1.Text + "' ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (textBox3.Text != textBox4.Text)
                {

                    textBox3.BackColor = textBox4.BackColor = Color.Bisque;
                    //label6.Visible = true;

                }
                else
                {
                    SqlCommand cnd = new SqlCommand("Update Admin set Password = '" + textBox3.Text + "' where Username = '" + textBox1.Text + "' ", con);
                    SqlDataAdapter sda1 = new SqlDataAdapter(cnd);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    MessageBox.Show("Password Changed Successfully", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    Show();
                }
            }
            else
            {
                textBox2.BackColor = textBox4.BackColor = Color.Bisque;
                MessageBox.Show("Password Mismatched", "ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void PictureBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void PictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.UseSystemPasswordChar = false;
        }

        private void PictureBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.UseSystemPasswordChar = false;
        }

        private void PictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
        }
    }
}
