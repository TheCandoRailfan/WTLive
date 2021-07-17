namespace Transit
{
    partial class fmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.btnGo = new System.Windows.Forms.Button();
            this.txtStopNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRte = new System.Windows.Forms.TextBox();
            this.timAutoGet = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOnOff = new System.Windows.Forms.Label();
            this.lblStopName = new System.Windows.Forms.Label();
            this.calCalendar = new System.Windows.Forms.MonthCalendar();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkRev = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rdoBike = new System.Windows.Forms.RadioButton();
            this.rdoNoBike = new System.Windows.Forms.RadioButton();
            this.rdoBikeorNoBike = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBus2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.timCheckStat = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.lbFeatures = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnOpenAdv = new System.Windows.Forms.Button();
            this.btnNearby = new System.Windows.Forms.Button();
            this.txtMaxDist = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnWebsite = new System.Windows.Forms.Button();
            this.cmbBusType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbBusLength = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnRoute = new System.Windows.Forms.Button();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBusLk = new System.Windows.Forms.TextBox();
            this.btnBus = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoCancel = new System.Windows.Forms.RadioButton();
            this.rdoEitherCancel = new System.Windows.Forms.RadioButton();
            this.rdoNoCancel = new System.Windows.Forms.RadioButton();
            this.chkShowMins = new System.Windows.Forms.CheckBox();
            this.btnAbout = new System.Windows.Forms.Button();
            this.timGoBtn = new System.Windows.Forms.Timer(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.rtxtList = new System.Windows.Forms.RichTextBox();
            this.btnFullScreen = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.timUpdateTime = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(49, 386);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(35, 23);
            this.btnGo.TabIndex = 18;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtStopNum
            // 
            this.txtStopNum.Location = new System.Drawing.Point(7, 28);
            this.txtStopNum.MaxLength = 5;
            this.txtStopNum.Name = "txtStopNum";
            this.txtStopNum.Size = new System.Drawing.Size(100, 20);
            this.txtStopNum.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stop Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Start Time (24h, optional):";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(7, 79);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(100, 20);
            this.txtStart.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Routes (blank for all):";
            // 
            // txtRte
            // 
            this.txtRte.Location = new System.Drawing.Point(7, 130);
            this.txtRte.Name = "txtRte";
            this.txtRte.Size = new System.Drawing.Size(100, 20);
            this.txtRte.TabIndex = 3;
            // 
            // timAutoGet
            // 
            this.timAutoGet.Interval = 30000;
            this.timAutoGet.Tick += new System.EventHandler(this.timAutoGet_Tick);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(86, 386);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(78, 23);
            this.btnStop.TabIndex = 18;
            this.btnStop.Text = "Stop Refresh";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Location = new System.Drawing.Point(8, 330);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(88, 17);
            this.chkAuto.TabIndex = 16;
            this.chkAuto.Text = "Auto Refresh";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(7, 350);
            this.txtInterval.MaxLength = 3;
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(34, 20);
            this.txtInterval.TabIndex = 17;
            this.txtInterval.Text = "30";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Refresh Interval (5+ seconds)";
            // 
            // lblOnOff
            // 
            this.lblOnOff.AutoSize = true;
            this.lblOnOff.Location = new System.Drawing.Point(46, 370);
            this.lblOnOff.Name = "lblOnOff";
            this.lblOnOff.Size = new System.Drawing.Size(88, 13);
            this.lblOnOff.TabIndex = 50;
            this.lblOnOff.Text = "Refresh Disabled";
            // 
            // lblStopName
            // 
            this.lblStopName.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblStopName.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStopName.ForeColor = System.Drawing.Color.White;
            this.lblStopName.Location = new System.Drawing.Point(0, 0);
            this.lblStopName.Name = "lblStopName";
            this.lblStopName.Size = new System.Drawing.Size(127, 22);
            this.lblStopName.TabIndex = 51;
            this.lblStopName.Text = "Stop Name";
            this.lblStopName.UseMnemonic = false;
            this.lblStopName.Visible = false;
            // 
            // calCalendar
            // 
            this.calCalendar.Location = new System.Drawing.Point(239, 375);
            this.calCalendar.Name = "calCalendar";
            this.calCalendar.TabIndex = 52;
            this.calCalendar.Visible = false;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(252, 353);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(103, 17);
            this.chkDate.TabIndex = 53;
            this.chkDate.Text = "Use Date Below";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.Visible = false;
            // 
            // chkRev
            // 
            this.chkRev.AutoSize = true;
            this.chkRev.Location = new System.Drawing.Point(97, 330);
            this.chkRev.Name = "chkRev";
            this.chkRev.Size = new System.Drawing.Size(95, 17);
            this.chkRev.TabIndex = 80;
            this.chkRev.Text = "Reverse Order";
            this.chkRev.UseVisualStyleBackColor = true;
            this.chkRev.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 25);
            this.label5.TabIndex = 56;
            this.label5.Text = "Other";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(7, 287);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Dest Contains";
            // 
            // txtBus
            // 
            this.txtBus.Location = new System.Drawing.Point(7, 181);
            this.txtBus.MaxLength = 3;
            this.txtBus.Name = "txtBus";
            this.txtBus.Size = new System.Drawing.Size(36, 20);
            this.txtBus.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "Bus Range";
            // 
            // rdoBike
            // 
            this.rdoBike.AutoSize = true;
            this.rdoBike.Location = new System.Drawing.Point(6, 16);
            this.rdoBike.Name = "rdoBike";
            this.rdoBike.Size = new System.Drawing.Size(43, 17);
            this.rdoBike.TabIndex = 8;
            this.rdoBike.Text = "Yes";
            this.rdoBike.UseVisualStyleBackColor = true;
            // 
            // rdoNoBike
            // 
            this.rdoNoBike.AutoSize = true;
            this.rdoNoBike.Location = new System.Drawing.Point(6, 39);
            this.rdoNoBike.Name = "rdoNoBike";
            this.rdoNoBike.Size = new System.Drawing.Size(39, 17);
            this.rdoNoBike.TabIndex = 9;
            this.rdoNoBike.Text = "No";
            this.rdoNoBike.UseVisualStyleBackColor = true;
            // 
            // rdoBikeorNoBike
            // 
            this.rdoBikeorNoBike.AutoSize = true;
            this.rdoBikeorNoBike.Checked = true;
            this.rdoBikeorNoBike.Location = new System.Drawing.Point(6, 62);
            this.rdoBikeorNoBike.Name = "rdoBikeorNoBike";
            this.rdoBikeorNoBike.Size = new System.Drawing.Size(52, 17);
            this.rdoBikeorNoBike.TabIndex = 10;
            this.rdoBikeorNoBike.TabStop = true;
            this.rdoBikeorNoBike.Text = "Either";
            this.rdoBikeorNoBike.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.rdoBike);
            this.groupBox1.Controls.Add(this.rdoBikeorNoBike);
            this.groupBox1.Controls.Add(this.rdoNoBike);
            this.groupBox1.Location = new System.Drawing.Point(221, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(71, 83);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bike Rack";
            // 
            // txtBus2
            // 
            this.txtBus2.Location = new System.Drawing.Point(71, 181);
            this.txtBus2.MaxLength = 3;
            this.txtBus2.Name = "txtBus2";
            this.txtBus2.Size = new System.Drawing.Size(36, 20);
            this.txtBus2.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "to";
            // 
            // timCheckStat
            // 
            this.timCheckStat.Enabled = true;
            this.timCheckStat.Interval = 180000;
            this.timCheckStat.Tick += new System.EventHandler(this.timCheckStat_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(459, 412);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(122, 20);
            this.lblStatus.TabIndex = 66;
            this.lblStatus.Text = "Transit Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFeatures
            // 
            this.lbFeatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFeatures.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbFeatures.FormattingEnabled = true;
            this.lbFeatures.ItemHeight = 24;
            this.lbFeatures.Location = new System.Drawing.Point(298, 435);
            this.lbFeatures.Name = "lbFeatures";
            this.lbFeatures.Size = new System.Drawing.Size(645, 100);
            this.lbFeatures.TabIndex = 67;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(293, 409);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 25);
            this.label9.TabIndex = 68;
            this.label9.Text = "Stop Features";
            // 
            // btnOpenAdv
            // 
            this.btnOpenAdv.Location = new System.Drawing.Point(6, 514);
            this.btnOpenAdv.Name = "btnOpenAdv";
            this.btnOpenAdv.Size = new System.Drawing.Size(105, 23);
            this.btnOpenAdv.TabIndex = 25;
            this.btnOpenAdv.Text = "Service Advisories";
            this.btnOpenAdv.UseVisualStyleBackColor = true;
            this.btnOpenAdv.Click += new System.EventHandler(this.btnOpenAdv_Click);
            // 
            // btnNearby
            // 
            this.btnNearby.Enabled = false;
            this.btnNearby.Location = new System.Drawing.Point(6, 487);
            this.btnNearby.Name = "btnNearby";
            this.btnNearby.Size = new System.Drawing.Size(105, 23);
            this.btnNearby.TabIndex = 24;
            this.btnNearby.Text = "Nearby Stops";
            this.btnNearby.UseVisualStyleBackColor = true;
            this.btnNearby.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMaxDist
            // 
            this.txtMaxDist.Location = new System.Drawing.Point(113, 488);
            this.txtMaxDist.MaxLength = 3;
            this.txtMaxDist.Name = "txtMaxDist";
            this.txtMaxDist.Size = new System.Drawing.Size(33, 20);
            this.txtMaxDist.TabIndex = 23;
            this.txtMaxDist.Text = "2";
            this.txtMaxDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(148, 492);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 72;
            this.label10.Text = "km";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(12, 539);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(931, 20);
            this.lblMessage.TabIndex = 73;
            this.lblMessage.Text = "System Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnWebsite
            // 
            this.btnWebsite.Enabled = false;
            this.btnWebsite.Location = new System.Drawing.Point(112, 514);
            this.btnWebsite.Name = "btnWebsite";
            this.btnWebsite.Size = new System.Drawing.Size(92, 23);
            this.btnWebsite.TabIndex = 26;
            this.btnWebsite.Text = "Transit Website";
            this.btnWebsite.UseVisualStyleBackColor = true;
            this.btnWebsite.Click += new System.EventHandler(this.btnWebsite_Click);
            // 
            // cmbBusType
            // 
            this.cmbBusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusType.FormattingEnabled = true;
            this.cmbBusType.Items.AddRange(new object[] {
            "Any",
            "D30LF",
            "D40LF (All)",
            "D40LF (Regular)",
            "D40LF (Ex-CT)",
            "D60LF",
            "D40LFR",
            "XD40",
            "XD60",
            "-LF",
            "-LFR",
            "Xcelsior",
            "Orange Sign",
            "White Sign"});
            this.cmbBusType.Location = new System.Drawing.Point(7, 207);
            this.cmbBusType.Name = "cmbBusType";
            this.cmbBusType.Size = new System.Drawing.Size(100, 21);
            this.cmbBusType.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(113, 211);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 77;
            this.label11.Text = "Bus Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(113, 238);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 79;
            this.label12.Text = "Bus Length";
            // 
            // cmbBusLength
            // 
            this.cmbBusLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusLength.FormattingEnabled = true;
            this.cmbBusLength.Items.AddRange(new object[] {
            "Any",
            "30 Feet",
            "40 Feet",
            "60 Feet"});
            this.cmbBusLength.Location = new System.Drawing.Point(7, 234);
            this.cmbBusLength.Name = "cmbBusLength";
            this.cmbBusLength.Size = new System.Drawing.Size(100, 21);
            this.cmbBusLength.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(2, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 25);
            this.label13.TabIndex = 80;
            this.label13.Text = "Bus:";
            // 
            // btnRoute
            // 
            this.btnRoute.Location = new System.Drawing.Point(6, 460);
            this.btnRoute.Name = "btnRoute";
            this.btnRoute.Size = new System.Drawing.Size(105, 23);
            this.btnRoute.TabIndex = 22;
            this.btnRoute.Text = "Route Destinations";
            this.btnRoute.UseVisualStyleBackColor = true;
            this.btnRoute.Click += new System.EventHandler(this.btnRoute_Click);
            // 
            // txtRoute
            // 
            this.txtRoute.Location = new System.Drawing.Point(113, 462);
            this.txtRoute.MaxLength = 4;
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(33, 20);
            this.txtRoute.TabIndex = 21;
            this.txtRoute.Text = "10";
            this.txtRoute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(146, 465);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 83;
            this.label14.Text = "Route";
            // 
            // txtBusLk
            // 
            this.txtBusLk.Location = new System.Drawing.Point(113, 435);
            this.txtBusLk.Name = "txtBusLk";
            this.txtBusLk.Size = new System.Drawing.Size(33, 20);
            this.txtBusLk.TabIndex = 19;
            this.txtBusLk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnBus
            // 
            this.btnBus.Location = new System.Drawing.Point(6, 433);
            this.btnBus.Name = "btnBus";
            this.btnBus.Size = new System.Drawing.Size(105, 23);
            this.btnBus.TabIndex = 20;
            this.btnBus.Text = "Bus On The Go";
            this.btnBus.UseVisualStyleBackColor = true;
            this.btnBus.Click += new System.EventHandler(this.btnBus_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(146, 438);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(25, 13);
            this.label15.TabIndex = 86;
            this.label15.Text = "Bus";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.rdoCancel);
            this.groupBox2.Controls.Add(this.rdoEitherCancel);
            this.groupBox2.Controls.Add(this.rdoNoCancel);
            this.groupBox2.Location = new System.Drawing.Point(221, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(71, 84);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cancelled";
            // 
            // rdoCancel
            // 
            this.rdoCancel.AutoSize = true;
            this.rdoCancel.Location = new System.Drawing.Point(6, 15);
            this.rdoCancel.Name = "rdoCancel";
            this.rdoCancel.Size = new System.Drawing.Size(43, 17);
            this.rdoCancel.TabIndex = 11;
            this.rdoCancel.Text = "Yes";
            this.rdoCancel.UseVisualStyleBackColor = true;
            // 
            // rdoEitherCancel
            // 
            this.rdoEitherCancel.AutoSize = true;
            this.rdoEitherCancel.Checked = true;
            this.rdoEitherCancel.Location = new System.Drawing.Point(6, 61);
            this.rdoEitherCancel.Name = "rdoEitherCancel";
            this.rdoEitherCancel.Size = new System.Drawing.Size(52, 17);
            this.rdoEitherCancel.TabIndex = 13;
            this.rdoEitherCancel.TabStop = true;
            this.rdoEitherCancel.Text = "Either";
            this.rdoEitherCancel.UseVisualStyleBackColor = true;
            // 
            // rdoNoCancel
            // 
            this.rdoNoCancel.AutoSize = true;
            this.rdoNoCancel.Location = new System.Drawing.Point(6, 38);
            this.rdoNoCancel.Name = "rdoNoCancel";
            this.rdoNoCancel.Size = new System.Drawing.Size(39, 17);
            this.rdoNoCancel.TabIndex = 12;
            this.rdoNoCancel.Text = "No";
            this.rdoNoCancel.UseVisualStyleBackColor = true;
            // 
            // chkShowMins
            // 
            this.chkShowMins.AutoSize = true;
            this.chkShowMins.Location = new System.Drawing.Point(8, 311);
            this.chkShowMins.Name = "chkShowMins";
            this.chkShowMins.Size = new System.Drawing.Size(166, 17);
            this.chkShowMins.TabIndex = 15;
            this.chkShowMins.Text = "Mins to Arrival (< 60 Min Only)";
            this.chkShowMins.UseVisualStyleBackColor = true;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(252, 514);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(43, 23);
            this.btnAbout.TabIndex = 29;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // timGoBtn
            // 
            this.timGoBtn.Interval = 5000;
            this.timGoBtn.Tick += new System.EventHandler(this.timGoBtn_Tick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(205, 514);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(45, 23);
            this.btnReset.TabIndex = 27;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // rtxtList
            // 
            this.rtxtList.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtList.Location = new System.Drawing.Point(298, 3);
            this.rtxtList.Name = "rtxtList";
            this.rtxtList.ReadOnly = true;
            this.rtxtList.Size = new System.Drawing.Size(645, 406);
            this.rtxtList.TabIndex = 90;
            this.rtxtList.Text = "";
            this.rtxtList.WordWrap = false;
            this.rtxtList.DoubleClick += new System.EventHandler(this.rtxtList_DoubleClick);
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Enabled = false;
            this.btnFullScreen.Location = new System.Drawing.Point(205, 489);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(90, 23);
            this.btnFullScreen.TabIndex = 28;
            this.btnFullScreen.Text = "Full Screen";
            this.btnFullScreen.UseVisualStyleBackColor = true;
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblTime.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(754, 2);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(200, 68);
            this.lblTime.TabIndex = 91;
            this.lblTime.Text = "11:00";
            this.lblTime.UseMnemonic = false;
            this.lblTime.Visible = false;
            // 
            // timUpdateTime
            // 
            this.timUpdateTime.Interval = 1000;
            this.timUpdateTime.Tick += new System.EventHandler(this.timUpdateTime_Tick);
            // 
            // fmMain
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 542);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.rtxtList);
            this.Controls.Add(this.btnFullScreen);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.chkShowMins);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnBus);
            this.Controls.Add(this.txtBusLk);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRoute);
            this.Controls.Add(this.btnRoute);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbBusLength);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbBusType);
            this.Controls.Add(this.btnWebsite);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMaxDist);
            this.Controls.Add(this.btnNearby);
            this.Controls.Add(this.btnOpenAdv);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbFeatures);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBus2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblStopName);
            this.Controls.Add(this.lblOnOff);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStopNum);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkRev);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.calCalendar);
            this.Controls.Add(this.chkDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmMain";
            this.Text = "Stop Schedule";
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtStopNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRte;
        private System.Windows.Forms.Timer timAutoGet;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOnOff;
        private System.Windows.Forms.Label lblStopName;
        private System.Windows.Forms.MonthCalendar calCalendar;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkRev;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdoBike;
        private System.Windows.Forms.RadioButton rdoNoBike;
        private System.Windows.Forms.RadioButton rdoBikeorNoBike;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBus2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timCheckStat;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lbFeatures;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnOpenAdv;
        private System.Windows.Forms.Button btnNearby;
        private System.Windows.Forms.TextBox txtMaxDist;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnWebsite;
        private System.Windows.Forms.ComboBox cmbBusType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbBusLength;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnRoute;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBusLk;
        private System.Windows.Forms.Button btnBus;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoCancel;
        private System.Windows.Forms.RadioButton rdoEitherCancel;
        private System.Windows.Forms.RadioButton rdoNoCancel;
        private System.Windows.Forms.CheckBox chkShowMins;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Timer timGoBtn;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RichTextBox rtxtList;
        private System.Windows.Forms.Button btnFullScreen;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timUpdateTime;
    }
}

