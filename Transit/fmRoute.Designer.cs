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
            this.lbDest = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtxtVariants = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.Location = new System.Drawing.Point(0, 4);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(74, 25);
            this.lblRoute.TabIndex = 0;
            this.lblRoute.Text = "Route";
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
            // rtxtVariants
            // 
            this.rtxtVariants.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtVariants.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtVariants.Location = new System.Drawing.Point(5, 32);
            this.rtxtVariants.Name = "rtxtVariants";
            this.rtxtVariants.ReadOnly = true;
            this.rtxtVariants.Size = new System.Drawing.Size(575, 279);
            this.rtxtVariants.TabIndex = 5;
            this.rtxtVariants.Text = "";
            // 
            // fmRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 317);
            this.Controls.Add(this.rtxtVariants);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbDest);
            this.Controls.Add(this.lblRoute);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmRoute";
            this.Text = "Route Destinations (Outbound above Inbound)";
            this.Load += new System.EventHandler(this.fmRoute_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.ListBox lbDest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtxtVariants;
    }
}