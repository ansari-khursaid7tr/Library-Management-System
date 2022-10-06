using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trial
{
    partial class AboutBox1 : Form
    {
        static int k = 2;
        public AboutBox1()
        {
            InitializeComponent();
            
        }

        

        private void GroupBox1_Enter(object sender, EventArgs e)
        {
           


        }

        private void Keshab_Click(object sender, EventArgs e)
        {
           
      
        }

        private void AboutBox1_Load(object sender, EventArgs e)
        {
            keshabp.Visible = false; 

            khusip.Visible = false;
         
            sanjeevp.Visible = false;
            
            surajp.Visible = false;
        }

        private void Khusi_Click(object sender, EventArgs e)
        {
            
        }

        private void Sanjeev_Click(object sender, EventArgs e)
        {
           
        }

        private void Suraj_Click(object sender, EventArgs e)
        {
           
        }

        private void Keshab_Click_1(object sender, EventArgs e)
        {
            if (k % 2 == 0)
            {
                keshabp.Visible = true;
                khusi.Visible = false;
                khusip.Visible = false;
                sanjeev.Visible = false;
                sanjeevp.Visible = false;
                suraj.Visible = false;
                surajp.Visible = false;
                k++;

            }
            else
            {

                keshabp.Visible = false;
                khusi.Visible = true;
                khusip.Visible = false;
                sanjeev.Visible = true;
                sanjeevp.Visible = false;
                suraj.Visible = true;
                surajp.Visible = false;
                k++;
            }
        }

        private void Khusi_Click_1(object sender, EventArgs e)
        {
            if (k % 2 == 0)
            {
                khusip.Visible = true;
                keshab.Visible = false;
                keshabp.Visible = false;
                sanjeev.Visible = false;
                sanjeevp.Visible = false;
                suraj.Visible = false;
                surajp.Visible = false;
                k++;

            }
            else
            {
                khusip.Visible = false;
                keshab.Visible = true;
                keshabp.Visible = false;
                sanjeev.Visible = true;
                sanjeevp.Visible = false;
                suraj.Visible = true;
                surajp.Visible = false;
                k++;
            }
           
        }

        private void Sanjeev_Click_1(object sender, EventArgs e)
        {
            if (k % 2 == 0)
            {
                sanjeevp.Visible = true;
                keshab.Visible = false;
                keshabp.Visible = false;
                khusi.Visible = false;
                khusip.Visible = false;
                suraj.Visible = false;
                surajp.Visible = false;
                k++;
            }
            else
            {
                sanjeevp.Visible = false;
                keshab.Visible = true;
                keshabp.Visible = false;
                khusi.Visible = true;
                khusip.Visible = false;
                suraj.Visible = true;
                surajp.Visible = false;
                k++;
            }
            
        }

        private void Suraj_Click_1(object sender, EventArgs e)
        {
            if (k % 2 == 0)
            {
                surajp.Visible = true;
                keshab.Visible = false;
                keshabp.Visible = false;
                sanjeev.Visible = false;
                sanjeevp.Visible = false;
                khusi.Visible = false;
                khusip.Visible = false;
                k++;
            }
            else
            {
                surajp.Visible = false;
                keshab.Visible = true;
                keshabp.Visible = false;
                sanjeev.Visible = true;
                sanjeevp.Visible = false;
                khusi.Visible = true;
                khusip.Visible = false;
                k++;
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
