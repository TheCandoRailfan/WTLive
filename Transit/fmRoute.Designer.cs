namespace Transit
{
    partial class fmRoute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmRoute));
            this.lblRoute = new System.Windows.Forms.Label();
            this.lbVariants = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDest = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.Location = new System.Drawing.Point(5, 6);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(74, 25);
            this.lblRoute.TabIndex = 0;
            this.lblRoute.Text = "Route";
            // 
            // lbVariants
            // 
            this.lbVariants.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVariants.FormattingEnabled = true;
            this.lbVariants.ItemHeight = 25;
            this.lbVariants.Location = new System.Drawing.Point(10, 34);
            this.lbVariants.Name = "lbVariants";
            this.lbVariants.Size = new System.Drawing.Size(610, 354);
            this.lbVariants.TabIndex = 1;
            this.lbVariants.SelectedIndexChanged += new System.EventHandler(this.lbVariants_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "(Outbound above Inbound)";
            // 
            // lbDest
            // 
            this.lbDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDest.FormattingEnabled = true;
            this.lbDest.ItemHeight = 20;
            this.lbDest.Location = new System.Drawing.Point(626, 34);
            this.lbDest.Name = "lbDest";
            this.lbDest.Size = new System.Drawing.Size(254, 184);
            this.lbDest.TabIndex = 3;
            this.lbDest.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(621, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Places";
            this.label2.Visible = false;
            // 
            // fmRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 412);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbDest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbVariants);
            this.Controls.Add(this.lblRoute);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmRoute";
            this.Text = "Route Destinations";
            this.Load += new System.EventHandler(this.fmRoute_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.ListBox lbVariants;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbDest;
        private System.Windows.Forms.Label label2;
    }
}