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
    public partial class Login : Form
    {
        System.Media.SoundPlayer player= new System.Media.SoundPlayer();
        int k = 0, n = 0, kk = 0, nn = 0;
        SqlConnection
                con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");

        public object WindowsState { get; private set; }

        public Login()
        {
            InitializeComponent();
            player.SoundLocation = "ss.wav";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            textBox1.Focus();
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';

            }
            else
            {
                textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';


            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {




        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            if (textBox2.Text == "" && textBox1.Text == "")

            {
               // player.Play();
                MessageBox.Show("Fields Empty");
                textBox1.BackColor = Color.Bisque;
                textBox2.BackColor = Color.Bisque;
            }
            else if (textBox1.Text == "")
            {
                //player.Play();
                MessageBox.Show("Username Empty");
                textBox1.BackColor = Color.Bisque;
            }
            else if (textBox2.Text == "")
            {
                //player.Play();
                MessageBox.Show("Password Empty");
                textBox2.BackColor = Color.Bisque;
            }

            else
            {
                SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Admin where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    using (MDIParent1 frrmmm = new MDIParent1(textBox1.Text, textBox2.Text, 20))
                    {
                        this.Hide();
                        frrmmm.ShowDialog();

                    }

                }

                else
                {
                    check();
                    check2();
                    check3();




                }
            }
        }
        private void check()
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Admin where Username!='" + textBox1.Text + "'and Password='" + textBox2.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {

                k = 1;
            }


        }
        private void check2()
        {
            SqlConnection
                con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Admin where Username='" + textBox1.Text + "'and Password!='" + textBox2.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {

                n = 1;

            }

        }
        private void check3()
        {


            password();



        }


        private void Button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        private void password()
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Admin where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                MDIParent1 frrmmm = new MDIParent1(textBox1.Text, textBox2.Text, 10);

                frrmmm.ShowDialog();
            }
            else
            {

                checkad1();
                checkad2();
                checkad3();


            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkad1()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Admin where username!='" + textBox1.Text + "'and password='" + textBox2.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {

                kk = 1;
            }

        }
        private void checkad2()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Admin where username='" + textBox1.Text + "'and password!='" + textBox2.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {

                nn = 1;

            }

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void checkad3()
        {
            


            if (k == 1 || kk == 1 && n == 0 && nn == 0)
            {
               // player.Play();
                MessageBox.Show(" Invalid Username");
                textBox1.BackColor = Color.Bisque;
                kk = 0; k = 0;
            }
            else if (n == 1 || nn == 1 && k == 0 && kk == 0)
            {
               // player.Play();
                MessageBox.Show("Invalid Password");
                textBox2.BackColor = Color.Bisque;
                n = 0; nn = 0;
            }
            else
            {
               // player.Play();
                MessageBox.Show("User Not Registered");
                textBox1.BackColor = Color.Bisque;
                textBox2.BackColor = Color.Bisque;
                n = 0; k = 0; kk = 0; nn = 0;
            }

        }

        private void Button1_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TextBox1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        int mov, movX, movY;
        private void Panel5_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textBox2.Text == "" && textBox1.Text == "")
                {
                   // player.Play();
                    MessageBox.Show("Fields Empty");
                }
                else if (textBox1.Text == "")
                {
                   // player.Play();
                    MessageBox.Show("Username Empty");
                }
                else if (textBox2.Text == "")
                {
                   // player.Play();
                    MessageBox.Show("Password Empty");
                }


                else
                {
                    SqlConnection
                     con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Admin where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Close();

                    if (dt.Rows.Count > 0)
                    {
                        using (MDIParent1 frrmmm = new MDIParent1(textBox1.Text, textBox2.Text, 20))
                        {
                            this.Hide();
                            frrmmm.ShowDialog();

                        }

                    }

                    else
                    {
                        check();
                        check2();
                        check3();




                    }
                }
            }
        }

        private void Panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if(mov==1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void Panel5_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
           if (pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
            else if (pictureBox2.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }
            else if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
            }
            else if (pictureBox4.Visible == true)
            {
                pictureBox4.Visible = false;
                pictureBox1.Visible = true;
            }
           
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       


       

        public void closeform()
        {
            this.Close();

        }


    }
}

