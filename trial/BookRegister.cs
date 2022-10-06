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
    public partial class BookRegister : Form
    {
        public BookRegister()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }
            adate.Text = pdate.Text = null;
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }
            adate.Text = pdate.Text = null;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (adate.Text == "" || pdate.Text == " " || author.Text == " " || title.Text == " " || bookno.Text == " " || publisher.Text == " " || isbn.Text == " " || tpage.Text==" ")
            {
                MessageBox.Show("Empty Fields Not Allowed", "ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            else if (title.Text != "")
            {
                int quantity=0;
                SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");

                con.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Books]
           ([BookNumber]
           ,[Author]
           ,[Title]
           ,[ISBN]
           ,[Publisher]
           ,[PublicationDate]
           ,[NoOfPages]
           ,[AddedDate])
             VALUES
            ('" + bookno.Text + "','" + author.Text +"', '" + title.Text + "', '" + isbn.Text + "', '" + publisher.Text + "', '" + pdate.Text + "', '" +tpage.Text + "', '" +adate.Text + "') " , con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    if(MessageBox.Show("Book already exists \n Do you want to increase the quantity ? ", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                    quantity++;
                }
                else
                    MessageBox.Show("Book Inserted", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }
    }
}
