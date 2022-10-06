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
using System.IO;

namespace trial
{
    public partial class AdminRegister : Form
    {
        int m = 0,jj=0,kk=0;
        string imgloc = "";
        SqlCommand cmd;
        SqlConnection
             con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");

        public AdminRegister()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }





        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }












        private void TextBox2_TextChanged_2(object sender, EventArgs e)
        {

        }



        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Button4_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "" || maskedTextBox1.Text == "" || textBox7.Text == "" || textBox8.Text == "" || comboBox1.Text == " " || pictureBox1.ImageLocation == null)
                MessageBox.Show("Empty Field Not Allowed", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            else if (textBox7.Text != "" && m == 0)
            {
                if (textBox7.Text.Contains("@gmail"))
                    m = 1;
                else
                    MessageBox.Show("Email Not Valid", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else if (textBox8.Text.Length < 4)
            {

                MessageBox.Show("Weak Password", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else
            {

                check();
                check2();



                if (kk == 1 || jj == 1)
                {
                    MessageBox.Show("User Already Exists", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    kk = 0;jj = 0;
                }




                else
                {
                    m = 0;
                    kk = 0;
                    jj = 0;
                    create();
                }
            }
               





            
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }
        private void create()
        {


            byte[] image = null;
            FileStream streaam = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
            BinaryReader bos = new BinaryReader(streaam);
            image = bos.ReadBytes((int)streaam.Length);


            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Admin]
           ([Username]
           ,[Contact]
           ,[EmailID]
           ,[Password]
           ,[Photo])
     VALUES


           ('" + textBox2.Text + "','" + comboBox1.Text + maskedTextBox1.Text + "','" + textBox7.Text + "','" + textBox8.Text + "',@imagge )", con);
            cmd.Parameters.Add(new SqlParameter("@imagge", image));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Admin Registered Successfully", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MaskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private void check()
        {
            con.Open();
            SqlCommand cmmd = new SqlCommand("select*from Admin where Username='" + textBox2.Text + "'", con);
            SqlDataAdapter sdda = new SqlDataAdapter(cmmd);
            DataTable ddt = new DataTable();
            sdda.Fill(ddt);
            con.Close();
            if (ddt.Rows.Count > 0)
            {
               
                jj = 1;
            }
        }

        private void FolderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void PictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox8.UseSystemPasswordChar = false;
        }

        private void PictureBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox8.UseSystemPasswordChar = true;
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || maskedTextBox1.Text == "" || textBox7.Text == "" || textBox8.Text == "" || comboBox1.Text == " ")
                MessageBox.Show("Empty Field Not Allowed", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            else if (textBox7.Text != "" && m == 0)
            {
                if (textBox7.Text.Contains("@gmail") || textBox7.Text.Contains("@outlook") || textBox7.Text.Contains("@hotmail") && textBox7.Text.Contains(".com"))
                    m = 1;
                else
                    MessageBox.Show("Email Not Valid", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else if (textBox8.Text.Length < 4)
            {

                MessageBox.Show("Weak Password", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else
            {

                check();
                check2();



                if (kk == 1 || jj == 1)
                {
                    MessageBox.Show("User Already Exists", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    kk = 0; jj = 0;
                }




                else
                {
                    m = 0;
                    kk = 0;
                    jj = 0;
                    create();
                }
            }






        }

        int mov, movX, movY;
        private void Panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button6_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgloc = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgloc;

            }
        }

            private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(mov==1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void check2()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from Admin where Username='" + textBox2.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                kk = 1;

            }
        }

       

        private void Button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgloc = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgloc;

            }
        }
    }
}
