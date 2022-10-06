namespace trial
{
    partial class PrintLayout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintLayout));
            this.rprt = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport21 = new trial.CrystalReport2();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rprt
            // 
            this.rprt.ActiveViewIndex = 0;
            this.rprt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rprt.Cursor = System.Windows.Forms.Cursors.Default;
            this.rprt.DisplayStatusBar = false;
            this.rprt.Location = new System.Drawing.Point(12, 43);
            this.rprt.Name = "rprt";
            this.rprt.ReportSource = this.CrystalReport21;
            this.rprt.Size = new System.Drawing.Size(1413, 705);
            this.rprt.TabIndex = 0;
            this.rprt.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1387, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 33);
            this.button3.TabIndex = 3;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // PrintLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 760);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.rprt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintLayout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Layout";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rprt;
        private System.Windows.Forms.Button button3;
        private CrystalReport2 CrystalReport21;
    }
}