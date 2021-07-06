namespace Transit
{
    partial class fmAdvisory
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmAdvisory));
            this.lbAdvisories = new System.Windows.Forms.ListBox();
            this.lblAdvisory = new System.Windows.Forms.Label();
            this.timRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbAdvisories
            // 
            this.lbAdvisories.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAdvisories.FormattingEnabled = true;
            this.lbAdvisories.ItemHeight = 25;
            this.lbAdvisories.Location = new System.Drawing.Point(12, 12);
            this.lbAdvisories.Name = "lbAdvisories";
            this.lbAdvisories.Size = new System.Drawing.Size(631, 454);
            this.lbAdvisories.TabIndex = 0;
            this.lbAdvisories.SelectedIndexChanged += new System.EventHandler(this.lbAdvisories_SelectedIndexChanged);
            // 
            // lblAdvisory
            // 
            this.lblAdvisory.AutoSize = true;
            this.lblAdvisory.Location = new System.Drawing.Point(649, 12);
            this.lblAdvisory.MaximumSize = new System.Drawing.Size(535, 0);
            this.lblAdvisory.Name = "lblAdvisory";
            this.lblAdvisory.Size = new System.Drawing.Size(47, 13);
            this.lblAdvisory.TabIndex = 2;
            this.lblAdvisory.Text = "Advisory";
            this.lblAdvisory.UseMnemonic = false;
            // 
            // timRefresh
            // 
            this.timRefresh.Interval = 120000;
            this.timRefresh.Tick += new System.EventHandler(this.timRefresh_Tick);
            // 
            // fmAdvisory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1210, 478);
            this.Controls.Add(this.lblAdvisory);
            this.Controls.Add(this.lbAdvisories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmAdvisory";
            this.Text = "Service Advisories";
            this.Load += new System.EventHandler(this.fmAdvisory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbAdvisories;
        private System.Windows.Forms.Label lblAdvisory;
        private System.Windows.Forms.Timer timRefresh;
    }
}