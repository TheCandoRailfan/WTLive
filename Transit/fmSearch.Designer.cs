
namespace Transit
{
    partial class fmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSearch));
            this.lbStopList = new System.Windows.Forms.ListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timLoad = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbStopList
            // 
            this.lbStopList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbStopList.FormattingEnabled = true;
            this.lbStopList.ItemHeight = 20;
            this.lbStopList.Location = new System.Drawing.Point(7, 34);
            this.lbStopList.Name = "lbStopList";
            this.lbStopList.Size = new System.Drawing.Size(561, 104);
            this.lbStopList.TabIndex = 0;
            this.lbStopList.DoubleClick += new System.EventHandler(this.lbStopList_DoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(7, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(155, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(160, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loading - May Take a Few Moments";
            // 
            // timLoad
            // 
            this.timLoad.Enabled = true;
            this.timLoad.Interval = 200;
            this.timLoad.Tick += new System.EventHandler(this.timLoad_Tick);
            // 
            // fmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 145);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbStopList);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmSearch";
            this.Text = "Stop Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbStopList;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timLoad;
    }
}