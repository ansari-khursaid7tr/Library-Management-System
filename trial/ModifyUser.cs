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
    public partial class ModifyUser : Form
    {
        public ModifyUser()
        {
            InitializeComponent();
        }

        private void Button47_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from Admin where Username = '" + textBox4.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            MessageBox.Show("User Removed", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Show();
            tbl_user.Refresh();
        }

        private void Button48_Click(object sender, EventArgs e)
        {
            SqlConnection
               con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Admin set Contact = '" + comboBox6.Text + textBox6.Text + "', EmailID= '" + textBox11.Text + "' where Username = '" +textBox4.Text +"'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            MessageBox.Show("User Updated", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Show();
            tbl_user.Show();
        }

        private void Tbl_user_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbl_user.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModifyUser_Load(object sender, EventArgs e)
        {
            SqlConnection
              con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Username, Contact, EmailID  from Admin", con);// where ID='" + textBox1.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tbl_user.DataSource = dt;
            Show();
            con.Close();
        }
    }
}
