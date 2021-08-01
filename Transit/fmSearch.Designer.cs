
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
            this.lblLoading = new System.Windows.Forms.Label();
            this.timLoad = new System.Windows.Forms.Timer(this.components);
            this.btnGo = new System.Windows.Forms.Button();
            this.timDark = new System.Windows.Forms.Timer(this.components);
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
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblLoading.Location = new System.Drawing.Point(160, 8);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(264, 20);
            this.lblLoading.TabIndex = 2;
            this.lblLoading.Text = "Loading - May Take a Few Moments";
            // 
            // timLoad
            // 
            this.timLoad.Enabled = true;
            this.timLoad.Interval = 200;
            this.timLoad.Tick += new System.EventHandler(this.timLoad_Tick);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(261, 79);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(29, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // timDark
            // 
            this.timDark.Enabled = true;
            this.timDark.Interval = 250;
            this.timDark.Tick += new System.EventHandler(this.timDark_Tick);
            // 
            // fmSearch
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(574, 145);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbStopList);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.btnGo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stop Search - WTLive";
            this.Load += new System.EventHandler(this.fmSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbStopList;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Timer timLoad;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Timer timDark;
    }
}