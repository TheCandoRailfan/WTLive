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
            this.rtxtAdvisory = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lbAdvisories
            // 
            this.lbAdvisories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAdvisories.FormattingEnabled = true;
            this.lbAdvisories.ItemHeight = 20;
            this.lbAdvisories.Location = new System.Drawing.Point(7, 8);
            this.lbAdvisories.Name = "lbAdvisories";
            this.lbAdvisories.Size = new System.Drawing.Size(548, 444);
            this.lbAdvisories.TabIndex = 0;
            this.lbAdvisories.SelectedIndexChanged += new System.EventHandler(this.lbAdvisories_SelectedIndexChanged);
            // 
            // lblAdvisory
            // 
            this.lblAdvisory.AutoSize = true;
            this.lblAdvisory.Location = new System.Drawing.Point(559, 8);
            this.lblAdvisory.MaximumSize = new System.Drawing.Size(504, 0);
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
            // rtxtAdvisory
            // 
            this.rtxtAdvisory.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtAdvisory.Location = new System.Drawing.Point(561, 8);
            this.rtxtAdvisory.Name = "rtxtAdvisory";
            this.rtxtAdvisory.ReadOnly = true;
            this.rtxtAdvisory.Size = new System.Drawing.Size(525, 444);
            this.rtxtAdvisory.TabIndex = 3;
            this.rtxtAdvisory.Text = "";
            // 
            // fmAdvisory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1098, 460);
            this.Controls.Add(this.rtxtAdvisory);
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
        private System.Windows.Forms.RichTextBox rtxtAdvisory;
    }
}