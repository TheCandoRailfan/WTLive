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
            this.lblStopNum = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.lblRoutes = new System.Windows.Forms.Label();
            this.txtRte = new System.Windows.Forms.TextBox();
            this.timAutoGet = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.lblRefresh = new System.Windows.Forms.Label();
            this.lblOnOff = new System.Windows.Forms.Label();
            this.lblStopName = new System.Windows.Forms.Label();
            this.chkRev = new System.Windows.Forms.CheckBox();
            this.lblOther = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblDestCont = new System.Windows.Forms.Label();
            this.txtBus = new System.Windows.Forms.TextBox();
            this.lblBusRange = new System.Windows.Forms.Label();
            this.rdoBike = new System.Windows.Forms.RadioButton();
            this.rdoNoBike = new System.Windows.Forms.RadioButton();
            this.rdoBikeorNoBike = new System.Windows.Forms.RadioButton();
            this.grpBikeRack = new System.Windows.Forms.GroupBox();
            this.txtBus2 = new System.Windows.Forms.TextBox();
            this.lblBusTo = new System.Windows.Forms.Label();
            this.timCheckStat = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.lbFeatures = new System.Windows.Forms.ListBox();
            this.lblStopFeat = new System.Windows.Forms.Label();
            this.btnOpenAdv = new System.Windows.Forms.Button();
            this.btnNearby = new System.Windows.Forms.Button();
            this.txtMaxDist = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnWebsite = new System.Windows.Forms.Button();
            this.cmbBusType = new System.Windows.Forms.ComboBox();
            this.lblBusType = new System.Windows.Forms.Label();
            this.lblBusLen = new System.Windows.Forms.Label();
            this.cmbBusLength = new System.Windows.Forms.ComboBox();
            this.lblBus = new System.Windows.Forms.Label();
            this.btnRoute = new System.Windows.Forms.Button();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBusLk = new System.Windows.Forms.TextBox();
            this.btnBus = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.grpCancelled = new System.Windows.Forms.GroupBox();
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.timSetStop = new System.Windows.Forms.Timer(this.components);
            this.btnExitFullScr = new System.Windows.Forms.Button();
            this.txtETAMax = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.grpMode = new System.Windows.Forms.GroupBox();
            this.rdoDark = new System.Windows.Forms.RadioButton();
            this.rdoLight = new System.Windows.Forms.RadioButton();
            this.grpBikeRack.SuspendLayout();
            this.grpCancelled.SuspendLayout();
            this.grpMode.SuspendLayout();
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
            // lblStopNum
            // 
            this.lblStopNum.AutoSize = true;
            this.lblStopNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStopNum.Location = new System.Drawing.Point(1, 2);
            this.lblStopNum.Name = "lblStopNum";
            this.lblStopNum.Size = new System.Drawing.Size(155, 25);
            this.lblStopNum.TabIndex = 2;
            this.lblStopNum.Text = "Stop Number:";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(1, 51);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(287, 25);
            this.lblStart.TabIndex = 4;
            this.lblStart.Text = "Start Time (24h, optional):";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(7, 79);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(100, 20);
            this.txtStart.TabIndex = 2;
            // 
            // lblRoutes
            // 
            this.lblRoutes.AutoSize = true;
            this.lblRoutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoutes.Location = new System.Drawing.Point(2, 102);
            this.lblRoutes.Name = "lblRoutes";
            this.lblRoutes.Size = new System.Drawing.Size(240, 25);
            this.lblRoutes.TabIndex = 14;
            this.lblRoutes.Text = "Routes (blank for all):";
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
            this.btnStop.Location = new System.Drawing.Point(147, 386);
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
            // lblRefresh
            // 
            this.lblRefresh.AutoSize = true;
            this.lblRefresh.Location = new System.Drawing.Point(46, 353);
            this.lblRefresh.Name = "lblRefresh";
            this.lblRefresh.Size = new System.Drawing.Size(146, 13);
            this.lblRefresh.TabIndex = 48;
            this.lblRefresh.Text = "Refresh Interval (5+ seconds)";
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
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOther.Location = new System.Drawing.Point(2, 259);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(77, 25);
            this.lblOther.TabIndex = 56;
            this.lblOther.Text = "Other:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(7, 287);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 14;
            // 
            // lblDestCont
            // 
            this.lblDestCont.AutoSize = true;
            this.lblDestCont.Location = new System.Drawing.Point(107, 290);
            this.lblDestCont.Name = "lblDestCont";
            this.lblDestCont.Size = new System.Drawing.Size(73, 13);
            this.lblDestCont.TabIndex = 57;
            this.lblDestCont.Text = "Dest Contains";
            // 
            // txtBus
            // 
            this.txtBus.Location = new System.Drawing.Point(7, 181);
            this.txtBus.MaxLength = 3;
            this.txtBus.Name = "txtBus";
            this.txtBus.Size = new System.Drawing.Size(36, 20);
            this.txtBus.TabIndex = 4;
            // 
            // lblBusRange
            // 
            this.lblBusRange.AutoSize = true;
            this.lblBusRange.Location = new System.Drawing.Point(107, 184);
            this.lblBusRange.Name = "lblBusRange";
            this.lblBusRange.Size = new System.Drawing.Size(60, 13);
            this.lblBusRange.TabIndex = 59;
            this.lblBusRange.Text = "Bus Range";
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
            // grpBikeRack
            // 
            this.grpBikeRack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpBikeRack.Controls.Add(this.rdoBike);
            this.grpBikeRack.Controls.Add(this.rdoBikeorNoBike);
            this.grpBikeRack.Controls.Add(this.rdoNoBike);
            this.grpBikeRack.Location = new System.Drawing.Point(221, 172);
            this.grpBikeRack.Name = "grpBikeRack";
            this.grpBikeRack.Size = new System.Drawing.Size(71, 83);
            this.grpBikeRack.TabIndex = 8;
            this.grpBikeRack.TabStop = false;
            this.grpBikeRack.Text = "Bike Rack";
            // 
            // txtBus2
            // 
            this.txtBus2.Location = new System.Drawing.Point(71, 181);
            this.txtBus2.MaxLength = 3;
            this.txtBus2.Name = "txtBus2";
            this.txtBus2.Size = new System.Drawing.Size(36, 20);
            this.txtBus2.TabIndex = 5;
            // 
            // lblBusTo
            // 
            this.lblBusTo.AutoSize = true;
            this.lblBusTo.Location = new System.Drawing.Point(49, 184);
            this.lblBusTo.Name = "lblBusTo";
            this.lblBusTo.Size = new System.Drawing.Size(16, 13);
            this.lblBusTo.TabIndex = 65;
            this.lblBusTo.Text = "to";
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
            // lblStopFeat
            // 
            this.lblStopFeat.AutoSize = true;
            this.lblStopFeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStopFeat.Location = new System.Drawing.Point(293, 409);
            this.lblStopFeat.Name = "lblStopFeat";
            this.lblStopFeat.Size = new System.Drawing.Size(160, 25);
            this.lblStopFeat.TabIndex = 68;
            this.lblStopFeat.Text = "Stop Features";
            // 
            // btnOpenAdv
            // 
            this.btnOpenAdv.Location = new System.Drawing.Point(6, 513);
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
            this.btnNearby.Location = new System.Drawing.Point(6, 486);
            this.btnNearby.Name = "btnNearby";
            this.btnNearby.Size = new System.Drawing.Size(105, 23);
            this.btnNearby.TabIndex = 24;
            this.btnNearby.Text = "Nearby Stops";
            this.btnNearby.UseVisualStyleBackColor = true;
            this.btnNearby.Click += new System.EventHandler(this.btnNearby_Click);
            // 
            // txtMaxDist
            // 
            this.txtMaxDist.Location = new System.Drawing.Point(113, 487);
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
            this.label10.Location = new System.Drawing.Point(148, 491);
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
            this.btnWebsite.Location = new System.Drawing.Point(112, 513);
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
            // lblBusType
            // 
            this.lblBusType.AutoSize = true;
            this.lblBusType.Location = new System.Drawing.Point(107, 211);
            this.lblBusType.Name = "lblBusType";
            this.lblBusType.Size = new System.Drawing.Size(52, 13);
            this.lblBusType.TabIndex = 77;
            this.lblBusType.Text = "Bus Type";
            // 
            // lblBusLen
            // 
            this.lblBusLen.AutoSize = true;
            this.lblBusLen.Location = new System.Drawing.Point(107, 238);
            this.lblBusLen.Name = "lblBusLen";
            this.lblBusLen.Size = new System.Drawing.Size(61, 13);
            this.lblBusLen.TabIndex = 79;
            this.lblBusLen.Text = "Bus Length";
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
            // lblBus
            // 
            this.lblBus.AutoSize = true;
            this.lblBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBus.Location = new System.Drawing.Point(2, 153);
            this.lblBus.Name = "lblBus";
            this.lblBus.Size = new System.Drawing.Size(59, 25);
            this.lblBus.TabIndex = 80;
            this.lblBus.Text = "Bus:";
            // 
            // btnRoute
            // 
            this.btnRoute.Location = new System.Drawing.Point(6, 459);
            this.btnRoute.Name = "btnRoute";
            this.btnRoute.Size = new System.Drawing.Size(105, 23);
            this.btnRoute.TabIndex = 22;
            this.btnRoute.Text = "Route Destinations";
            this.btnRoute.UseVisualStyleBackColor = true;
            this.btnRoute.Click += new System.EventHandler(this.btnRoute_Click);
            // 
            // txtRoute
            // 
            this.txtRoute.Location = new System.Drawing.Point(113, 461);
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
            this.label14.Location = new System.Drawing.Point(146, 464);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 83;
            this.label14.Text = "Route";
            // 
            // txtBusLk
            // 
            this.txtBusLk.Location = new System.Drawing.Point(113, 434);
            this.txtBusLk.Name = "txtBusLk";
            this.txtBusLk.Size = new System.Drawing.Size(33, 20);
            this.txtBusLk.TabIndex = 19;
            this.txtBusLk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnBus
            // 
            this.btnBus.Location = new System.Drawing.Point(6, 432);
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
            this.label15.Location = new System.Drawing.Point(146, 437);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(25, 13);
            this.label15.TabIndex = 86;
            this.label15.Text = "Bus";
            // 
            // grpCancelled
            // 
            this.grpCancelled.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpCancelled.Controls.Add(this.rdoCancel);
            this.grpCancelled.Controls.Add(this.rdoEitherCancel);
            this.grpCancelled.Controls.Add(this.rdoNoCancel);
            this.grpCancelled.Location = new System.Drawing.Point(221, 260);
            this.grpCancelled.Name = "grpCancelled";
            this.grpCancelled.Size = new System.Drawing.Size(71, 84);
            this.grpCancelled.TabIndex = 53;
            this.grpCancelled.TabStop = false;
            this.grpCancelled.Text = "Cancelled";
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
            this.chkShowMins.Checked = true;
            this.chkShowMins.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowMins.Location = new System.Drawing.Point(8, 311);
            this.chkShowMins.Name = "chkShowMins";
            this.chkShowMins.Size = new System.Drawing.Size(176, 17);
            this.chkShowMins.TabIndex = 15;
            this.chkShowMins.Text = "Relative Time Within          Mins";
            this.chkShowMins.UseVisualStyleBackColor = true;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(252, 513);
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
            this.btnReset.Location = new System.Drawing.Point(205, 513);
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
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Location = new System.Drawing.Point(85, 386);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(61, 23);
            this.btnFullScreen.TabIndex = 28;
            this.btnFullScreen.Text = "Go (FS)";
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
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblTime.UseMnemonic = false;
            this.lblTime.Visible = false;
            // 
            // timUpdateTime
            // 
            this.timUpdateTime.Interval = 1000;
            this.timUpdateTime.Tick += new System.EventHandler(this.timUpdateTime_Tick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(109, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(51, 23);
            this.btnSearch.TabIndex = 92;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // timSetStop
            // 
            this.timSetStop.Enabled = true;
            this.timSetStop.Interval = 125;
            this.timSetStop.Tick += new System.EventHandler(this.timSetStop_Tick);
            // 
            // btnExitFullScr
            // 
            this.btnExitFullScr.BackColor = System.Drawing.Color.Red;
            this.btnExitFullScr.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitFullScr.ForeColor = System.Drawing.Color.White;
            this.btnExitFullScr.Location = new System.Drawing.Point(906, 2);
            this.btnExitFullScr.Name = "btnExitFullScr";
            this.btnExitFullScr.Size = new System.Drawing.Size(48, 81);
            this.btnExitFullScr.TabIndex = 93;
            this.btnExitFullScr.Text = "X";
            this.btnExitFullScr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExitFullScr.UseVisualStyleBackColor = false;
            this.btnExitFullScr.Visible = false;
            this.btnExitFullScr.Click += new System.EventHandler(this.btnExitFullScr_Click);
            // 
            // txtETAMax
            // 
            this.txtETAMax.Location = new System.Drawing.Point(127, 309);
            this.txtETAMax.MaxLength = 3;
            this.txtETAMax.Name = "txtETAMax";
            this.txtETAMax.Size = new System.Drawing.Size(25, 20);
            this.txtETAMax.TabIndex = 94;
            this.txtETAMax.Text = "60";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(113, 79);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 96;
            this.txtDate.Visible = false;
            // 
            // grpMode
            // 
            this.grpMode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpMode.Controls.Add(this.rdoDark);
            this.grpMode.Controls.Add(this.rdoLight);
            this.grpMode.Location = new System.Drawing.Point(205, 447);
            this.grpMode.Name = "grpMode";
            this.grpMode.Size = new System.Drawing.Size(87, 62);
            this.grpMode.TabIndex = 97;
            this.grpMode.TabStop = false;
            this.grpMode.Text = "Mode";
            // 
            // rdoDark
            // 
            this.rdoDark.AutoSize = true;
            this.rdoDark.Location = new System.Drawing.Point(6, 40);
            this.rdoDark.Name = "rdoDark";
            this.rdoDark.Size = new System.Drawing.Size(48, 17);
            this.rdoDark.TabIndex = 1;
            this.rdoDark.Text = "Dark";
            this.rdoDark.UseVisualStyleBackColor = true;
            this.rdoDark.CheckedChanged += new System.EventHandler(this.rdoDark_CheckedChanged);
            // 
            // rdoLight
            // 
            this.rdoLight.AutoSize = true;
            this.rdoLight.Checked = true;
            this.rdoLight.Location = new System.Drawing.Point(6, 16);
            this.rdoLight.Name = "rdoLight";
            this.rdoLight.Size = new System.Drawing.Size(48, 17);
            this.rdoLight.TabIndex = 0;
            this.rdoLight.TabStop = true;
            this.rdoLight.Text = "Light";
            this.rdoLight.UseVisualStyleBackColor = true;
            this.rdoLight.CheckedChanged += new System.EventHandler(this.rdoLight_CheckedChanged);
            // 
            // fmMain
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(955, 542);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.btnExitFullScr);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.rtxtList);
            this.Controls.Add(this.btnFullScreen);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.grpCancelled);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnBus);
            this.Controls.Add(this.txtBusLk);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRoute);
            this.Controls.Add(this.btnRoute);
            this.Controls.Add(this.lblBus);
            this.Controls.Add(this.lblBusLen);
            this.Controls.Add(this.cmbBusLength);
            this.Controls.Add(this.lblBusType);
            this.Controls.Add(this.cmbBusType);
            this.Controls.Add(this.btnWebsite);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMaxDist);
            this.Controls.Add(this.btnNearby);
            this.Controls.Add(this.btnOpenAdv);
            this.Controls.Add(this.lblStopFeat);
            this.Controls.Add(this.lbFeatures);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblBusTo);
            this.Controls.Add(this.txtBus2);
            this.Controls.Add(this.lblBusRange);
            this.Controls.Add(this.txtBus);
            this.Controls.Add(this.lblDestCont);
            this.Controls.Add(this.lblOther);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblStopName);
            this.Controls.Add(this.lblOnOff);
            this.Controls.Add(this.lblRefresh);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblRoutes);
            this.Controls.Add(this.txtRte);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.lblStopNum);
            this.Controls.Add(this.txtStopNum);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.grpBikeRack);
            this.Controls.Add(this.chkRev);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtETAMax);
            this.Controls.Add(this.chkShowMins);
            this.Controls.Add(this.grpMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WTLive";
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.grpBikeRack.ResumeLayout(false);
            this.grpBikeRack.PerformLayout();
            this.grpCancelled.ResumeLayout(false);
            this.grpCancelled.PerformLayout();
            this.grpMode.ResumeLayout(false);
            this.grpMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtStopNum;
        private System.Windows.Forms.Label lblStopNum;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label lblRoutes;
        private System.Windows.Forms.TextBox txtRte;
        private System.Windows.Forms.Timer timAutoGet;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label lblRefresh;
        private System.Windows.Forms.Label lblOnOff;
        private System.Windows.Forms.Label lblStopName;
        private System.Windows.Forms.CheckBox chkRev;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblDestCont;
        private System.Windows.Forms.TextBox txtBus;
        private System.Windows.Forms.Label lblBusRange;
        private System.Windows.Forms.RadioButton rdoBike;
        private System.Windows.Forms.RadioButton rdoNoBike;
        private System.Windows.Forms.RadioButton rdoBikeorNoBike;
        private System.Windows.Forms.GroupBox grpBikeRack;
        private System.Windows.Forms.TextBox txtBus2;
        private System.Windows.Forms.Label lblBusTo;
        private System.Windows.Forms.Timer timCheckStat;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lbFeatures;
        private System.Windows.Forms.Label lblStopFeat;
        private System.Windows.Forms.Button btnOpenAdv;
        private System.Windows.Forms.Button btnNearby;
        private System.Windows.Forms.TextBox txtMaxDist;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnWebsite;
        private System.Windows.Forms.ComboBox cmbBusType;
        private System.Windows.Forms.Label lblBusType;
        private System.Windows.Forms.Label lblBusLen;
        private System.Windows.Forms.ComboBox cmbBusLength;
        private System.Windows.Forms.Label lblBus;
        private System.Windows.Forms.Button btnRoute;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBusLk;
        private System.Windows.Forms.Button btnBus;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox grpCancelled;
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
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Timer timSetStop;
        private System.Windows.Forms.Button btnExitFullScr;
        private System.Windows.Forms.TextBox txtETAMax;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.GroupBox grpMode;
        private System.Windows.Forms.RadioButton rdoDark;
        private System.Windows.Forms.RadioButton rdoLight;
    }
}

