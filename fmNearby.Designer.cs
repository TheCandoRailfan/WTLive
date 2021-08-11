namespace Transit
{
    partial class fmNearby
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmNearby));
            this.lbNBList = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStop = new System.Windows.Forms.Label();
            this.timDark = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbNBList
            // 
            this.lbNBList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNBList.FormattingEnabled = true;
            this.lbNBList.ItemHeight = 20;
            this.lbNBList.Location = new System.Drawing.Point(8, 60);
            this.lbNBList.Name = "lbNBList";
            this.lbNBList.Size = new System.Drawing.Size(778, 364);
            this.lbNBList.TabIndex = 0;
            this.lbNBList.DoubleClick += new System.EventHandler(this.lbNBList_DoubleClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(4, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(58, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStop.Location = new System.Drawing.Point(4, 32);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(127, 25);
            this.lblStop.TabIndex = 2;
            this.lblStop.Text = "Stop Name";
            // 
            // timDark
            // 
            this.timDark.Enabled = true;
            this.timDark.Interval = 250;
            this.timDark.Tick += new System.EventHandler(this.timDark_Tick);
            // 
            // fmNearby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(794, 432);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lbNBList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmNearby";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nearby Stops - WTLive";
            this.Load += new System.EventHandler(this.fmNearby_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbNBList;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Timer timDark;
    }
}