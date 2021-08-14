
namespace Transit
{
    partial class fmOtherInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmOtherInfo));
            this.rtxtBusList = new System.Windows.Forms.RichTextBox();
            this.btnSortRuns = new System.Windows.Forms.Button();
            this.btnSortRunsAll = new System.Windows.Forms.Button();
            this.rtxtBusListAll = new System.Windows.Forms.RichTextBox();
            this.lblCurStop = new System.Windows.Forms.Label();
            this.lblAll = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.timDark = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // rtxtBusList
            // 
            this.rtxtBusList.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtBusList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.rtxtBusList.Location = new System.Drawing.Point(7, 31);
            this.rtxtBusList.Name = "rtxtBusList";
            this.rtxtBusList.ReadOnly = true;
            this.rtxtBusList.Size = new System.Drawing.Size(223, 307);
            this.rtxtBusList.TabIndex = 0;
            this.rtxtBusList.Text = "";
            // 
            // btnSortRuns
            // 
            this.btnSortRuns.Location = new System.Drawing.Point(6, 342);
            this.btnSortRuns.Name = "btnSortRuns";
            this.btnSortRuns.Size = new System.Drawing.Size(224, 23);
            this.btnSortRuns.TabIndex = 1;
            this.btnSortRuns.Text = "Sort by Runs";
            this.btnSortRuns.UseVisualStyleBackColor = true;
            this.btnSortRuns.Click += new System.EventHandler(this.btnSortRuns_Click);
            // 
            // btnSortRunsAll
            // 
            this.btnSortRunsAll.Location = new System.Drawing.Point(235, 342);
            this.btnSortRunsAll.Name = "btnSortRunsAll";
            this.btnSortRunsAll.Size = new System.Drawing.Size(111, 23);
            this.btnSortRunsAll.TabIndex = 3;
            this.btnSortRunsAll.Text = "Sort by Runs";
            this.btnSortRunsAll.UseVisualStyleBackColor = true;
            this.btnSortRunsAll.Click += new System.EventHandler(this.btnSortRunsAll_Click);
            // 
            // rtxtBusListAll
            // 
            this.rtxtBusListAll.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtBusListAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.rtxtBusListAll.Location = new System.Drawing.Point(236, 31);
            this.rtxtBusListAll.Name = "rtxtBusListAll";
            this.rtxtBusListAll.ReadOnly = true;
            this.rtxtBusListAll.Size = new System.Drawing.Size(223, 307);
            this.rtxtBusListAll.TabIndex = 2;
            this.rtxtBusListAll.Text = "";
            // 
            // lblCurStop
            // 
            this.lblCurStop.AutoSize = true;
            this.lblCurStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblCurStop.Location = new System.Drawing.Point(3, 2);
            this.lblCurStop.Name = "lblCurStop";
            this.lblCurStop.Size = new System.Drawing.Size(135, 26);
            this.lblCurStop.TabIndex = 4;
            this.lblCurStop.Text = "Current Stop";
            // 
            // lblAll
            // 
            this.lblAll.AutoSize = true;
            this.lblAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblAll.Location = new System.Drawing.Point(232, 2);
            this.lblAll.Name = "lblAll";
            this.lblAll.Size = new System.Drawing.Size(104, 26);
            this.lblAll.TabIndex = 5;
            this.lblAll.Text = "All Buses";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(348, 342);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(111, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // timDark
            // 
            this.timDark.Enabled = true;
            this.timDark.Interval = 250;
            this.timDark.Tick += new System.EventHandler(this.timDark_Tick);
            // 
            // fmOtherInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(465, 370);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblAll);
            this.Controls.Add(this.lblCurStop);
            this.Controls.Add(this.btnSortRunsAll);
            this.Controls.Add(this.rtxtBusListAll);
            this.Controls.Add(this.btnSortRuns);
            this.Controls.Add(this.rtxtBusList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmOtherInfo";
            this.Text = "Bus List - WTLive";
            this.Load += new System.EventHandler(this.fmOtherInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtBusList;
        private System.Windows.Forms.Button btnSortRuns;
        private System.Windows.Forms.Button btnSortRunsAll;
        private System.Windows.Forms.RichTextBox rtxtBusListAll;
        private System.Windows.Forms.Label lblCurStop;
        private System.Windows.Forms.Label lblAll;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer timDark;
    }
}