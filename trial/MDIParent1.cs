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
using System.Configuration;


namespace trial
{
    public partial class MDIParent1 : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        string lab = "";
        int m = 0, ll = 0;
        Boolean flag = false;
        SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
        string imgloc = "", nn = "Female";


        int num = 0;
        
        string ku, ju;
        int nu=0;
        private int childFormNumber = 0;

        Image image;
        Rectangle rect;
        public MDIParent1(string kk, string jju, int num)
        {
            
            InitializeComponent();
            player.SoundLocation = "ss.wav";
           
            Login k1 = new Login();
            panel1.Visible = false; panel3.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel5.Visible = false;
            dataGridView1.Visible = false;
            button10.Visible = button4.Visible = false;
            pic.Visible = true;
            //printToolStripButton.Visible = false;
            // pic.Location = new Point((this.Width / 2) - (pic.Width / 2), (this.Height / 2) - (pic.Height / 2));

            ku = kk;
            ju = jju; 
            nu = num;
            label6.Text = ku;
           

            /*if (num == 10)
                adminphoto();

            else
                userphoto();*/


                show();

        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void PrintToolStripButton_Click(object sender, EventArgs e)
        {
            pic.Visible = false;
            panel1.Visible = false; panel3.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel5.Visible = false;
            dataGridView1.Visible = false;
            button10.Visible = button4.Visible = false;
            //flag = false;
            PrintLayout p= new PrintLayout();
                p.Show();
                CrystalReport2 cr = new CrystalReport2();
                SqlConnection coon = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                coon.Open();
              //  coon.ConnectionString = ConfigurationManager.ConnectionStrings["trial.Properties.Settings.registerConnectionString"];
                string j = "select ID,Name,Faculty,Semester,Phone,RollNo,Fine from Student";
                DataSet ds = new DataSet();
                SqlDataAdapter sd = new SqlDataAdapter(j, coon);
                sd.Fill(ds, "Student");
                DataTable dt = ds.Tables["Student"];
                cr.SetDataSource(ds.Tables["Student"]);
                coon.Close();
            //  p.rprt.Refresh();


           // pic.Visible = true;
            panel4.Visible = true;
            dataGridView1.Visible = true;


        }

        private void EditMenu_Click(object sender, EventArgs e)
        {
           

        }





        private void MDIParent1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Time.Text = DateTime.Now.ToLongTimeString();
            Date.Text = DateTime.Now.ToLongDateString();
            
            
            
        }

        private void PasswordchangeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            button10.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel1.Visible = panel7.Visible = false;
            pic.Visible = false;
            SqlConnection
              con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Admin where Username='" + ku + "'and Password='" + ju + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            if (label6.Text == "admin")
            {
                ModifyPassword frm1 = new ModifyPassword();
                //frm1.MdiParent = this;
                frm1.ShowDialog();
            }
            else
            {
                //player.Play();
                MessageBox.Show("Administrator Only! ", " Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            panel1.Visible = false; panel3.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel5.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = button10.Visible = false;
            pic.Visible = true;
        }

        

        private void NormalUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* SqlConnection
                   con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Admin where Username='" + ku+ "'and Password='" + ju + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Users Only!!!");
            }
            else
            {
                
                Form5 frm = new Form5(ku);
                frm.ShowDialog();
            }*/
        }

        private void AdministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {

         
        }

        private void AdministratorPageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SqlConnection
                  con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from Admin where Username='" + ku+ "'and Password='" +ju + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {



                //Form4 frm11 = new Form4(ku,ju);
                //frm11.ShowDialog();
            }
            else
            {
                player.Play();
                MessageBox.Show("Administrator Only", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ToolsMenu_Click(object sender, EventArgs e)
        {
            button10.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel1.Visible = panel7.Visible = false;
            pic.Visible = false;
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from Admin where Username='" + ku + "'and Password='" + ju + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            
                AboutBox1 frm11 = new AboutBox1();
                //frm11.MdiParent = this;
                frm11.ShowDialog();
           
           
               // player.Play();
               // MessageBox.Show("Administrator Only! ", " Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           

            panel1.Visible = false; panel3.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel5.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = button10.Visible = false;
            pic.Visible = true;
        }
        private void show()
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select ID,Name,Faculty,Semester,BookIssue,BookReturn,Fine,Phone,EmailID,RollNo,Gender,Address,Book1,Book2,Book3,Book4,Book5,Book6,Book7 from Student", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
             
        }

        private void ViewMenu_Click(object sender, EventArgs e)
        {
           
        }

        private void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            check14();
            if(num==1)
            {
                player.Play();
                if (MessageBox.Show("Are you sure?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    delete();
                    num = 0;
                }
            }
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {  
           
            check14();
            


        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void showselect()
            
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select ID,Name,Faculty,Semester,BookIssue,BookReturn,Book1,Book2,Book3,Book4,Book5,Book6,Book7,Fine from Student where  ID='" + textBox1.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void check14()
        {
            if (textBox1.Text == "")
            {
                player.Play();
                MessageBox.Show("Select ID", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select ID from Student where ID='" + textBox1.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    num = 1;
                    showselect();
                    photo();



                }
                else
                {
                    player.Play();
                    MessageBox.Show("ID Mismatched", " ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void check15()
        {

            if (textBox1.Text == "")
            {
                player.Play();
                MessageBox.Show("Select ID", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select ID from Student where ID='" + textBox1.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    flag = true;



                }
                else

                { MessageBox.Show("ID Mismatched", " ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    player.Play();
                }
            }
        }

        private void photo()
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");

            con.Open();
           SqlCommand cmd = new SqlCommand("SELECT Photo from Student where ID='" + textBox1.Text + "'", con);
            SqlDataReader DataReaderr = cmd.ExecuteReader();
            DataReaderr.Read();



            if (DataReaderr.HasRows)
            {
                byte[] imag = ((byte[])DataReaderr[0]);

                if (imag == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    MemoryStream mysteam = new MemoryStream(imag);
                    pictureBox1.Image = Image.FromStream(mysteam);
                }
            }
            else
            {
                player.Play();
                MessageBox.Show("Image Not Available", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();

        }

        private void WindowsMenu_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_2(object sender, EventArgs e)
        {
            check14();
            if(num==1)
            {
                update();
                showselect();
                num = 0;
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void delete()
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("delete Student where ID=@a1", con);
            jj.Parameters.Add("@a1", Convert.ToInt32(textBox1.Text));
            SqlDataReader sse;
            sse = jj.ExecuteReader();
            MessageBox.Show("Successfully Removed", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            show();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void  update()
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("UPDATE Student SET BookIssue=@a1,BookReturn=@a2,Fine=@a3,Book1=@a4,Book2=@a5,Book3=@a6,Book4=@a7,Book5=@a8,Book6=@a9,Book7=@a10 where ID='"+textBox1.Text+"'", con);
            jj.Parameters.Add("a1", Convert.ToDateTime(dateTimePicker1.Text));
            jj.Parameters.Add("a2", Convert.ToDateTime(dateTimePicker2.Text));
            jj.Parameters.Add("a3",(textBox2.Text));
            jj.Parameters.Add("a4", label49.Text);
            jj.Parameters.Add("a5", label50.Text);
            jj.Parameters.Add("a6", label51.Text);
            jj.Parameters.Add("a7", label52.Text);
            jj.Parameters.Add("a8", label53.Text);
            jj.Parameters.Add("a9", label54.Text);
            jj.Parameters.Add("a10", label55.Text);
            label49.Text = label50.Text = label51.Text = label52.Text = label53.Text = label54.Text = label55.Text = "";


            jj.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Entered", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void adminphoto()
        {
            /* SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Photo from Admin where username='" + ku+ "'", con);
            SqlDataReader DataReaderr = cmd.ExecuteReader();
            DataReaderr.Read();




            if (DataReaderr.HasRows)
            {
                byte[] imag = ((byte[])DataReaderr[0]);

                if (imag == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    MemoryStream mysteam = new MemoryStream(imag);
                    pictureBox2.Image = Image.FromStream(mysteam);
                }
            }

            con.Close();*/
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" && comboBox2.Text != "")
            {
                SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select ID,Name,Faculty,Semester,BookIssue,BookReturn,Book1,Book2,Book3,Book4,Book5,Book6,Book7,Fine from Student where  Semester='" + comboBox2.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else if (comboBox2.Text != "" && comboBox1.Text != "")
            {
                SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select ID,Name,Faculty,Semester,BookIssue,BookReturn,Book1,Book2,Book3,Book4,Book5,Book6,Book7,Fine from Student where  Faculty='" + comboBox1.Text + "'and Semester='" + comboBox2.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }


        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "" && comboBox1.Text != "")

            {
                SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select ID,Name,Faculty,Semester,BookIssue,BookReturn,Book1,Book2,Book3,Book4,Book5,Book6,Book7,Fine from Student where  faculty='" + comboBox1.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
               
                sda.Fill(dt);
              
                dataGridView1.DataSource = dt;
                con.Close();
            }

            else if (comboBox2.Text != "" && comboBox1.Text != "")
            {
                SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select ID,Name,Faculty,Semester,BookIssue,BookReturn,Book1,Book2,Book3,Book4,Book5,Book6,Book7,Fine from Student where  faculty='" + comboBox1.Text + "'and semester='" + comboBox2.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            check15();
            if (flag == true)
            {
                panel1.Visible = true;
                panel6.Visible = false;
                panel7.Visible = false;
                flag = false;
            }


        }

        private void Button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = true;
         
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;


        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void MaskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MaskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            string kk;
            kk = textBox7.Text;





            if (textBox8.Text == "" || maskedTextBox3.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || maskedTextBox1.Text == "" || textBox7.Text == "" || maskedTextBox4.Text == "" || pictureBox3.ImageLocation == null || textBox5.Text == "" || (checkBox1.Checked == false&& checkBox2.Checked == false))
            {
                player.Play();
                MessageBox.Show("Empty Fields Not Allowed", "ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            else if (maskedTextBox1.Text != "" && ll == 0)
            {

                SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");

                con.Open();
                SqlCommand cmd = new SqlCommand("select ID from Student where ID='" + maskedTextBox1.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    player.Play();
                    MessageBox.Show("Student already exists", "ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ll = 0;

                }
                else
                    ll = 2;

            }

            else if (textBox7.Text != "" && m == 0)
            {
                if ((kk.Contains("@gmail")||kk.Contains("@yahoo")||kk.Contains("@hotmail")||kk.Contains("@outlook"))&&kk.Contains(".com"))
                    m = 1;
                else
                {
                    player.Play();
                    MessageBox.Show("Invalid Email", "ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m = 0;
                }
            }





            else

            {
                m = 0;

                if (checkBox1.Checked == true)
                    nn = "Male";
                insert();
            }
        }




        private void insert()
        { 
            int idd=0,year=Convert.ToInt32(maskedTextBox1.Text),roll= Convert.ToInt32(maskedTextBox4.Text);
            int a = 50000;
            Random rnd = new Random();
            if (comboBox4.Text == "BE Computer")
            {
                idd = rnd.Next(0, a);
            }
            else if (comboBox4.Text == "BE Civil")
                idd = rnd.Next(0, a);
            else if (comboBox4.Text == "BCA")
                idd = rnd.Next(0, a);
            else if (comboBox4.Text == "BBA")
                idd = rnd.Next(0, a);


            byte[] image = null;
            FileStream streaam = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
            BinaryReader bos = new BinaryReader(streaam);
            image = bos.ReadBytes((int)streaam.Length);

            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Student]
           ([ID]
           ,[Year]
           ,[Name]
           ,[Faculty]
           ,[Semester]
           ,[Phone]
           ,[EmailID]
           ,[RollNo]
           ,[Photo]
           ,[Gender]
           ,[Address])

            VALUES
           ('" + idd+"','" + maskedTextBox1.Text + "','" + textBox8.Text + "','" + comboBox4.Text + "','" + comboBox3.Text + "','" + comboBox5.Text + maskedTextBox3.Text + "','" + textBox7.Text + "','" + maskedTextBox4.Text + "',@imagge,'" + nn + "','" + textBox5.Text + "' )", con);

            cmd.Parameters.Add(new SqlParameter("@imagge", image));
            cmd.ExecuteNonQuery();
            //cmd.ExecuteNonQuery();
            MessageBox.Show("Student Registered \n \t " + " ID is " + idd, "ID Registration ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }



            private void Button7_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
            panel1.Visible = false;
            panel4.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = false;
            button10.Visible = false;
            textBox8.Text = "";
            maskedTextBox3.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            maskedTextBox1.Text = "";
            textBox7.Text = "";
            maskedTextBox4.Text = "";
            textBox5.Text = "";
            checkBox1.Checked = checkBox2.Checked = false;
            comboBox5.Text = " ";
            pictureBox3.Image = null;
            pic.Visible = true;

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void Label21_Click(object sender, EventArgs e)
        {

        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label24_Click(object sender, EventArgs e)
        {

        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label25_Click(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
                SqlCommand cmd1 = new SqlCommand("UPDATE Student SET Name=@aaa1 where ID =@aaa2", con);
                cmd1.Parameters.Add("aaa1", textBox9.Text);
            cmd1.Parameters.Add("aaa2", textBox1.Text);
           


                SqlCommand cmd2 = new SqlCommand("UPDATE Student SET Semester=@aaa1 where ID =@aaa2", con);
                cmd2.Parameters.Add("@aaa1", textBox10.Text); cmd2.Parameters.Add("aaa2", textBox1.Text);


            SqlCommand cmd3 = new SqlCommand("UPDATE Student SET Phone=@aaa1 where ID =@aaa2", con);
            cmd3.Parameters.Add("@aaa1", (maskedTextBox2.Text));
            cmd3.Parameters.Add("aaa2", textBox1.Text);


            SqlCommand cmd4 = new SqlCommand("UPDATE Student SET EmailID=@aaa1 where ID =@aaa2", con);
                cmd4.Parameters.Add("@aaa1", textBox12.Text);
            cmd4.Parameters.Add("aaa2", textBox1.Text);




            SqlCommand cmd5 = new SqlCommand("UPDATE Student SET Adresss=@aaa1 where ID =@aaa2", con);
                cmd5.Parameters.Add("@aaa1", textBox13.Text);
            cmd5.Parameters.Add("aaa2", textBox1.Text);

            if (textBox9.Text != "")
                    cmd1.ExecuteNonQuery();

                if (textBox10.Text != "")
                    cmd2.ExecuteNonQuery();

                if (maskedTextBox2.Text != "")
                    cmd3.ExecuteNonQuery();

                if (textBox12.Text != "")
                    cmd4.ExecuteNonQuery();

                if (textBox13.Text != "")
                    cmd5.ExecuteNonQuery();
                con.Close();
            MessageBox.Show("Successfully Updated", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            show();
            
        


        }

        private void MaskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void TextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            
            
                check15();
            if (flag == true)
            {
                panel1.Visible = false;
                panel3.Visible = false;
                panel6.Visible = false;
                panel7.Visible = true;
              
                
            }
            

        }

        private void Button11_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            dataGridView1.Visible = true;
            show();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            maskedTextBox3.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            maskedTextBox1.Text = "";
            textBox7.Text = "";
            maskedTextBox4.Text = "";
            textBox5.Text = "";
            checkBox1.Checked = checkBox2.Checked = false;
            comboBox5.Text = " ";
            pictureBox3.Image = null;
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label27_Click(object sender, EventArgs e)
        {

        }

        private void Panel6_Paint(object sender, PaintEventArgs e)
        {
            panel6.Visible = true;
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            dataGridView1.Visible = true;
        }

        private void Button13_Click(object sender, EventArgs e)
        {            string buk=textBox3.Text;
            if (label49.Text == "")
            label49.Text = buk;
            
            else if (label50.Text == "")
                label50.Text = buk;

            else if (label51.Text == "")
                label51.Text = buk;

            else if (label52.Text == "")
                label52.Text = buk;

            else if (label53.Text == "")
                label53.Text = buk;

            else if (label54.Text == "")
                label54.Text = buk;

            else if (label55.Text == "")
                label55.Text = buk;
                


        }

        private void Label34_Click(object sender, EventArgs e)
        {

        }

        private void Label35_Click(object sender, EventArgs e)
        {

        }

        private void Label36_Click(object sender, EventArgs e)
        {

        }

        private void Label37_Click(object sender, EventArgs e)
        {

        }

        private void Label38_Click(object sender, EventArgs e)
        {

        }

        private void Label39_Click(object sender, EventArgs e)
        {

        }

        private void Label40_Click(object sender, EventArgs e)
        {

        }

        private void Label27_Click_1(object sender, EventArgs e)
        {

        }

        private void Label28_Click(object sender, EventArgs e)
        {

        }

        private void Label29_Click(object sender, EventArgs e)
        {

        }

        private void Label30_Click(object sender, EventArgs e)
        {

        }

        private void Label31_Click(object sender, EventArgs e)
        {

        }

        private void Label32_Click(object sender, EventArgs e)
        {

        }

        private void Label33_Click(object sender, EventArgs e)
        {

        }

        private void Button17_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            dataGridView1.Visible = false;

        }

        private void Label32_Click_1(object sender, EventArgs e)
        {

        }

        private void Label39_Click_1(object sender, EventArgs e)
        {

        }

        private void Button18_Click(object sender, EventArgs e)
        {
            label34.Text = "";
            
        }

        private void Button19_Click(object sender, EventArgs e)
        {

            label35.Text = "";
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            label36.Text = "";
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            label37.Text = "";
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            label38.Text = "";
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            label39.Text = "";
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            label40.Text = "";
        }

        private void showbooks()
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * FROM Student where ID='" + textBox1.Text + "'", con);

            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                label49.Text = (dr["Book1"].ToString());
                label50.Text = (dr["Book2"].ToString());
                label51.Text = (dr["Book3"].ToString());
                label52.Text = (dr["Book4"].ToString());
                label53.Text = (dr["Book5"].ToString());
                label54.Text = (dr["Book6"].ToString());
                label55.Text = (dr["Book7"].ToString());

            }
            con.Close();
            panel5.Visible = true;

        }

        private void Button15_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            showbooks();

        }

        private void Button30_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("update Student SET Book6=@a1 where ID='" + textBox1.Text + "'", con);

            jj.Parameters.Add("@a1", lab);
            jj.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Removed", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            showbooks();
            
        }

        private void Button25_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("UPDATE Student SET Book1=@a1 where ID='"+textBox1.Text+"'", con);
            
            jj.Parameters.Add("@a1", lab);
            jj.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Removed", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            showbooks();
        }

        private void Button26_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("UPDATE Student SET Book2=@a1 where ID='" + textBox1.Text + "'", con);

            jj.Parameters.Add("@a1", lab);
            jj.ExecuteNonQuery();
            con.Close();
            showbooks();

        }

        private void Button27_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("UPDATE Student SET Book3=@a1 where ID='" + textBox1.Text + "'", con);

            jj.Parameters.Add("@a1", lab);
            jj.ExecuteNonQuery();
            con.Close();
            showbooks();
        }

        private void Button28_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("UPDATE Student SET Book4=@a1 where ID='" + textBox1.Text + "'", con);

            jj.Parameters.Add("@a1", lab);
            jj.ExecuteNonQuery();
            con.Close();
            showbooks();
        }

        private void Button29_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("UPDATE Student SET Book5=@a1 where ID='" + textBox1.Text + "'", con);

            jj.Parameters.Add("@a1", lab);
            jj.ExecuteNonQuery();
            con.Close();
            showbooks();
        }

        private void Button31_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("UPDATE Student SET Book7=@a1 where ID='" + textBox1.Text + "'", con);

            jj.Parameters.Add("@a1", lab);
            jj.ExecuteNonQuery();
            con.Close();
            showbooks();
        }

        private void Button32_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            dataGridView1.Visible = true;
            show();
        }

        private void TextBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button33_Click(object sender, EventArgs e)
        {

        }

        private void Button33_Click_1(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("UPDATE Student SET Name=@aaa1 where ID =@aaa2", con);
            cmd1.Parameters.Add("aaa1", textBox9.Text);
            cmd1.Parameters.Add("aaa2", textBox1.Text);



            SqlCommand cmd2 = new SqlCommand("UPDATE Student SET Semester=@aaa1 where ID =@aaa2", con);
            cmd2.Parameters.Add("@aaa1", textBox10.Text); cmd2.Parameters.Add("aaa2", textBox1.Text);


            SqlCommand cmd3 = new SqlCommand("UPDATE Student SET Phone=@aaa1 where ID =@aaa2", con);
            cmd3.Parameters.Add("@aaa1", (comboBox6.Text + maskedTextBox2.Text));
            cmd3.Parameters.Add("aaa2", textBox1.Text);


            SqlCommand cmd4 = new SqlCommand("UPDATE Student SET EmailID=@aaa1 where ID =@aaa2", con);
            cmd4.Parameters.Add("@aaa1", textBox12.Text);
            cmd4.Parameters.Add("aaa2", textBox1.Text);




            SqlCommand cmd5 = new SqlCommand("UPDATE Student SET Address=@aaa1 where ID =@aaa2", con);
            cmd5.Parameters.Add("@aaa1", textBox13.Text);
            cmd5.Parameters.Add("aaa2", textBox1.Text);

            if (textBox9.Text != "")
                cmd1.ExecuteNonQuery();

            if (textBox10.Text != "")
                cmd2.ExecuteNonQuery();

            if (maskedTextBox2.Text != "")
                cmd3.ExecuteNonQuery();

            if (textBox12.Text != "")
                cmd4.ExecuteNonQuery();

            if (textBox13.Text != "")
                cmd5.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            show();

        }

        private void Label26_Click(object sender, EventArgs e)
        {

        }

        private void MaskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Label45_Click(object sender, EventArgs e)
        {

        }

        private void Label46_Click(object sender, EventArgs e)
        {

        }

        private void Label49_Click(object sender, EventArgs e)
        {

        }

        private void Button9_Click_1(object sender, EventArgs e)
        {
            panel5.Visible = false;
            dataGridView1.Visible = true;
        }

        private void Panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Button38_Click(object sender, EventArgs e)
        {
            label54.Text = "";
        }

        private void Button11_Click_1(object sender, EventArgs e)
        {
            label49.Text ="";
        }

        private void Button34_Click(object sender, EventArgs e)
        {
            label50.Text = "";
        }

        private void Button35_Click(object sender, EventArgs e)
        {
            label51.Text = "";
        }

        private void Label51_Click(object sender, EventArgs e)
        {

        }

        private void Button36_Click(object sender, EventArgs e)
        {
            label52.Text = "";
        }

        private void Button37_Click(object sender, EventArgs e)
        {
            label53.Text = "";
        }

        private void Button39_Click(object sender, EventArgs e)
        {
            label55.Text = "";
        }

        private void Button40_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("update Student SET Book1=@a1 where ID='" + textBox1.Text + "'", con);

            jj.Parameters.Add("@a1", lab);
            jj.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Removed", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            showbooks();
        }

        private void Button41_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("update Student SET Book2=@a1 where ID='" + textBox1.Text + "'", con);

            jj.Parameters.Add("@a1", lab);
            jj.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Removed", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            showbooks();
        }

        private void Button42_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("update Student SET Book3=@a1 where ID='" + textBox1.Text + "'", con);

            jj.Parameters.Add("@a1", lab);
            jj.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Removed", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            showbooks();
        }

        private void Button43_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("update Student SET Book4=@a1 where ID='" + textBox1.Text + "'", con);

            jj.Parameters.Add("@a1", lab);
            jj.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Removed", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            showbooks();
        }

        private void Button44_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("update Student SET Book5=@a1 where ID='" + textBox1.Text + "'", con);

            jj.Parameters.Add("@a1", lab);
            jj.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Removed", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            showbooks();
        }

        private void Button45_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("update Student SET Book6=@a1 where ID='" + textBox1.Text + "'", con);

            jj.Parameters.Add("@a1", lab);
            jj.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Removed", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            showbooks();
        }

        private void Button46_Click(object sender, EventArgs e)
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand jj = new SqlCommand("update Student SET Book7=@a1 where ID='" + textBox1.Text + "'", con);

            jj.Parameters.Add("@a1", lab);
            jj.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Removed", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            showbooks();
        }

        private void DisplayStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //printToolStripButton.Visible = true;
           
            button4.Visible = true;
            button10.Visible = true;
            panel4.Visible = true;
            dataGridView1.Visible = true;
            pic.Visible = false;
            SqlConnection
              con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select *  from Student", con);// where ID='" + textBox1.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            pictureBox1.Image = null;
            textBox1.Text = " ";
            con.Close();



           // printToolStripButton.Visible = false;


        }

        private void NewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button10.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            pic.Visible = false;

            
        }

        private void SignOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frm = new Login();
            frm.Show();
        }

        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button10.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel1.Visible = panel7.Visible = false;
            pic.Visible = false;
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from Admin where Username='" + ku + "'and Password='" + ju + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            if (label6.Text == "admin")
            {
                AdminRegister frm11 = new AdminRegister();
                //frm11.MdiParent = this;
                frm11.ShowDialog();
            }
            else
            {
               // player.Play();
                MessageBox.Show("Administrator Only! ", " Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            panel1.Visible = false; panel3.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel5.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = button10.Visible = false;
            pic.Visible = true;
        }

        private void ModifyUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button10.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel1.Visible = panel7.Visible = false;
            pic.Visible = false;
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from Admin where Username='" + ku + "'and Password='" + ju + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            if (label6.Text == "admin")
            {
                ModifyUser frm11 = new ModifyUser();
                //frm11.MdiParent = this;
                frm11.ShowDialog();
            }
            else
            {
               // player.Play();
                MessageBox.Show("Administrator Only! ", " Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            panel1.Visible = false; panel3.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel5.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = button10.Visible = false;
            pic.Visible = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void NewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button10.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel1.Visible = panel7.Visible = false;
            pic.Visible = false;

            BookRegister frm11 = new BookRegister();
            //frm11.MdiParent = this;
            frm11.ShowDialog();       

            panel1.Visible = false; panel3.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel5.Visible = false;
            dataGridView1.Visible = false;
            pic.Visible = true;
            button4.Visible = button10.Visible = false;
        }

        private void DisplayBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button10.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel1.Visible = panel7.Visible = false;
            pic.Visible = false;

            BookDisplay frmab = new BookDisplay();
           
            frmab.ShowDialog();
          //  ModifyBook frm12 = new ModifyBook();
           // frm12.MdiParent = this;
           // frm12.ShowDialog();

            panel1.Visible = false; panel3.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel5.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = button10.Visible = false;
            pic.Visible = true;
        }

        private void HomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pic.Visible = true;
            panel1.Visible = false; panel3.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel5.Visible = false;
            dataGridView1.Visible = false;
            button10.Visible = button4.Visible = false;
        }

        private void Pic_Click(object sender, EventArgs e)
        {

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            int width = this.Width;
            int height = this.Height;
            /* if(pic.Location.X > width - pic.Width)
             {
                 pic.Location = new Point(1, pic.Location.Y);
             }
             else
             {
                 pic.Location = new Point(pic.Location.X + 100, pic.Location.Y);

                 PictureBox1.Location = New Point((Form1.Width / 2) - (PictureBox1.Width / 2), (Form1.Height / 2) - (PictureBox1.Height / 2)

             }*/
           
            
        }

        private void PictureBox2_Click_1(object sender, EventArgs e)
        {
            pic.Visible = false;
            panel1.Visible = false; panel3.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel5.Visible = false;
            dataGridView1.Visible = false;
            button10.Visible = button4.Visible = false;
            //flag = false;
            PrintLayout p = new PrintLayout();
            p.Show();
            CrystalReport2 cr = new CrystalReport2();
            SqlConnection coon = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            coon.Open();
            //  coon.ConnectionString = ConfigurationManager.ConnectionStrings["trial.Properties.Settings.registerConnectionString"];
            string j = "select ID,Name,Faculty,Semester,Phone,RollNo,Fine from Student";
            DataSet ds = new DataSet();
            SqlDataAdapter sd = new SqlDataAdapter(j, coon);
            sd.Fill(ds, "Student");
            DataTable dt = ds.Tables["Student"];
            cr.SetDataSource(ds.Tables["Student"]);
            coon.Close();
            //  p.rprt.Refresh();


            // pic.Visible = true;
            panel4.Visible = true;
            dataGridView1.Visible = true;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgloc = dialog.FileName.ToString();
                pictureBox3.ImageLocation = imgloc;

            }
        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void userphoto()
        {
            SqlConnection
                 con = new SqlConnection(@"Data Source=DESKTOP-T3T4QIC\SQLEXPRESS;Initial Catalog=Final;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Photo from Admin where username='" + ku + "'", con);
            SqlDataReader DataReaderr = cmd.ExecuteReader();
            DataReaderr.Read();




            if (DataReaderr.HasRows)
            {
                byte[] imag = ((byte[])DataReaderr[0]);

                if (imag == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    MemoryStream mysteam = new MemoryStream(imag);
                    //pictureBox2.Image = Image.FromStream(mysteam);
                    pictureBox1.Image = null;
                }
            }

            con.Close();
        }




    }
}
    
