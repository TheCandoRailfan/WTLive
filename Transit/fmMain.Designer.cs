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
            this.lblStop = new System.Windows.Forms.Label();
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
            this.txtBus2 = new System.Windows.Forms.TextBox();
            this.lblBusTo = new System.Windows.Forms.Label();
            this.timCheckStat = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.lbFeatures = new System.Windows.Forms.ListBox();
            this.lblStopFeat = new System.Windows.Forms.Label();
            this.btnOpenAdv = new System.Windows.Forms.Button();
            this.btnNearby = new System.Windows.Forms.Button();
            this.txtMaxDist = new System.Windows.Forms.TextBox();
            this.lblKm = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnWebsite = new System.Windows.Forms.Button();
            this.cmbBusType = new System.Windows.Forms.ComboBox();
            this.lblBusType = new System.Windows.Forms.Label();
            this.lblBusLen = new System.Windows.Forms.Label();
            this.cmbBusLength = new System.Windows.Forms.ComboBox();
            this.lblBus = new System.Windows.Forms.Label();
            this.btnRoute = new System.Windows.Forms.Button();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.lblRtDest = new System.Windows.Forms.Label();
            this.txtBusLk = new System.Windows.Forms.TextBox();
            this.btnBus = new System.Windows.Forms.Button();
            this.lblOTGBus = new System.Windows.Forms.Label();
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
            this.btnModeChange = new System.Windows.Forms.Button();
            this.lblRtList = new System.Windows.Forms.Label();
            this.rtxtRtList = new System.Windows.Forms.RichTextBox();
            this.btnOtherInfo = new System.Windows.Forms.Button();
            this.txtRun = new System.Windows.Forms.TextBox();
            this.lblRun = new System.Windows.Forms.Label();
            this.lblStopNum = new System.Windows.Forms.Label();
            this.lblColour = new System.Windows.Forms.Label();
            this.cmbColour = new System.Windows.Forms.ComboBox();
            this.cmbBikeRack = new System.Windows.Forms.ComboBox();
            this.lblBike = new System.Windows.Forms.Label();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.timAllBuses = new System.Windows.Forms.Timer(this.components);
            this.grpCancelled.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(43, 326);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(29, 23);
            this.btnGo.TabIndex = 18;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtStopNum
            // 
            this.txtStopNum.Location = new System.Drawing.Point(4, 22);
            this.txtStopNum.MaxLength = 5;
            this.txtStopNum.Name = "txtStopNum";
            this.txtStopNum.Size = new System.Drawing.Size(100, 20);
            this.txtStopNum.TabIndex = 1;
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStop.Location = new System.Drawing.Point(0, 2);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(52, 20);
            this.lblStop.TabIndex = 2;
            this.lblStop.Text = "Stop:";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(103, 49);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(128, 13);
            this.lblStart.TabIndex = 4;
            this.lblStart.Text = "Start Time (24h, optional):";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(4, 46);
            this.txtStart.MaxLength = 5;
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(100, 20);
            this.txtStart.TabIndex = 2;
            // 
            // lblRoutes
            // 
            this.lblRoutes.AutoSize = true;
            this.lblRoutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoutes.Location = new System.Drawing.Point(103, 72);
            this.lblRoutes.Name = "lblRoutes";
            this.lblRoutes.Size = new System.Drawing.Size(90, 13);
            this.lblRoutes.TabIndex = 14;
            this.lblRoutes.Text = "Routes (optional):";
            // 
            // txtRte
            // 
            this.txtRte.Location = new System.Drawing.Point(4, 69);
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
            this.btnStop.Location = new System.Drawing.Point(125, 326);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(77, 23);
            this.btnStop.TabIndex = 18;
            this.btnStop.Text = "Stop Refresh";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Location = new System.Drawing.Point(4, 270);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(88, 17);
            this.chkAuto.TabIndex = 16;
            this.chkAuto.Text = "Auto Refresh";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(4, 290);
            this.txtInterval.MaxLength = 3;
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(34, 20);
            this.txtInterval.TabIndex = 17;
            this.txtInterval.Text = "30";
            // 
            // lblRefresh
            // 
            this.lblRefresh.AutoSize = true;
            this.lblRefresh.Location = new System.Drawing.Point(40, 293);
            this.lblRefresh.Name = "lblRefresh";
            this.lblRefresh.Size = new System.Drawing.Size(152, 13);
            this.lblRefresh.TabIndex = 48;
            this.lblRefresh.Text = "Refresh Interval (15+ seconds)";
            // 
            // lblOnOff
            // 
            this.lblOnOff.AutoSize = true;
            this.lblOnOff.Location = new System.Drawing.Point(40, 310);
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
            this.chkRev.Location = new System.Drawing.Point(93, 270);
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
            this.lblOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOther.Location = new System.Drawing.Point(0, 208);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(59, 20);
            this.lblOther.TabIndex = 56;
            this.lblOther.Text = "Other:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(4, 228);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 14;
            // 
            // lblDestCont
            // 
            this.lblDestCont.AutoSize = true;
            this.lblDestCont.Location = new System.Drawing.Point(104, 231);
            this.lblDestCont.Name = "lblDestCont";
            this.lblDestCont.Size = new System.Drawing.Size(73, 13);
            this.lblDestCont.TabIndex = 57;
            this.lblDestCont.Text = "Dest Contains";
            // 
            // txtBus
            // 
            this.txtBus.Location = new System.Drawing.Point(4, 127);
            this.txtBus.MaxLength = 3;
            this.txtBus.Name = "txtBus";
            this.txtBus.Size = new System.Drawing.Size(36, 20);
            this.txtBus.TabIndex = 4;
            // 
            // lblBusRange
            // 
            this.lblBusRange.AutoSize = true;
            this.lblBusRange.Location = new System.Drawing.Point(104, 130);
            this.lblBusRange.Name = "lblBusRange";
            this.lblBusRange.Size = new System.Drawing.Size(44, 13);
            this.lblBusRange.TabIndex = 59;
            this.lblBusRange.Text = "Number";
            // 
            // txtBus2
            // 
            this.txtBus2.Location = new System.Drawing.Point(68, 127);
            this.txtBus2.MaxLength = 3;
            this.txtBus2.Name = "txtBus2";
            this.txtBus2.Size = new System.Drawing.Size(36, 20);
            this.txtBus2.TabIndex = 5;
            // 
            // lblBusTo
            // 
            this.lblBusTo.AutoSize = true;
            this.lblBusTo.Location = new System.Drawing.Point(46, 130);
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
            this.lblStatus.Location = new System.Drawing.Point(453, 341);
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
            this.lbFeatures.Location = new System.Drawing.Point(707, 366);
            this.lbFeatures.Name = "lbFeatures";
            this.lbFeatures.Size = new System.Drawing.Size(230, 100);
            this.lbFeatures.TabIndex = 67;
            // 
            // lblStopFeat
            // 
            this.lblStopFeat.AutoSize = true;
            this.lblStopFeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStopFeat.Location = new System.Drawing.Point(702, 339);
            this.lblStopFeat.Name = "lblStopFeat";
            this.lblStopFeat.Size = new System.Drawing.Size(160, 25);
            this.lblStopFeat.TabIndex = 68;
            this.lblStopFeat.Text = "Stop Features";
            // 
            // btnOpenAdv
            // 
            this.btnOpenAdv.Location = new System.Drawing.Point(4, 444);
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
            this.btnNearby.Location = new System.Drawing.Point(4, 420);
            this.btnNearby.Name = "btnNearby";
            this.btnNearby.Size = new System.Drawing.Size(105, 23);
            this.btnNearby.TabIndex = 24;
            this.btnNearby.Text = "Nearby Stops";
            this.btnNearby.UseVisualStyleBackColor = true;
            this.btnNearby.Click += new System.EventHandler(this.btnNearby_Click);
            // 
            // txtMaxDist
            // 
            this.txtMaxDist.Location = new System.Drawing.Point(111, 421);
            this.txtMaxDist.MaxLength = 3;
            this.txtMaxDist.Name = "txtMaxDist";
            this.txtMaxDist.Size = new System.Drawing.Size(33, 20);
            this.txtMaxDist.TabIndex = 23;
            this.txtMaxDist.Text = "2";
            this.txtMaxDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblKm
            // 
            this.lblKm.AutoSize = true;
            this.lblKm.Location = new System.Drawing.Point(146, 425);
            this.lblKm.Name = "lblKm";
            this.lblKm.Size = new System.Drawing.Size(21, 13);
            this.lblKm.TabIndex = 72;
            this.lblKm.Text = "km";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(4, 466);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(935, 20);
            this.lblMessage.TabIndex = 73;
            this.lblMessage.Text = "System Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnWebsite
            // 
            this.btnWebsite.Enabled = false;
            this.btnWebsite.Location = new System.Drawing.Point(110, 444);
            this.btnWebsite.Name = "btnWebsite";
            this.btnWebsite.Size = new System.Drawing.Size(89, 23);
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
            "Xcelsior"});
            this.cmbBusType.Location = new System.Drawing.Point(4, 150);
            this.cmbBusType.Name = "cmbBusType";
            this.cmbBusType.Size = new System.Drawing.Size(100, 21);
            this.cmbBusType.TabIndex = 6;
            // 
            // lblBusType
            // 
            this.lblBusType.AutoSize = true;
            this.lblBusType.Location = new System.Drawing.Point(104, 154);
            this.lblBusType.Name = "lblBusType";
            this.lblBusType.Size = new System.Drawing.Size(36, 13);
            this.lblBusType.TabIndex = 77;
            this.lblBusType.Text = "Model";
            // 
            // lblBusLen
            // 
            this.lblBusLen.AutoSize = true;
            this.lblBusLen.Location = new System.Drawing.Point(104, 178);
            this.lblBusLen.Name = "lblBusLen";
            this.lblBusLen.Size = new System.Drawing.Size(40, 13);
            this.lblBusLen.TabIndex = 79;
            this.lblBusLen.Text = "Length";
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
            this.cmbBusLength.Location = new System.Drawing.Point(4, 174);
            this.cmbBusLength.Name = "cmbBusLength";
            this.cmbBusLength.Size = new System.Drawing.Size(100, 21);
            this.cmbBusLength.TabIndex = 7;
            // 
            // lblBus
            // 
            this.lblBus.AutoSize = true;
            this.lblBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBus.Location = new System.Drawing.Point(0, 104);
            this.lblBus.Name = "lblBus";
            this.lblBus.Size = new System.Drawing.Size(45, 20);
            this.lblBus.TabIndex = 80;
            this.lblBus.Text = "Bus:";
            // 
            // btnRoute
            // 
            this.btnRoute.Location = new System.Drawing.Point(4, 396);
            this.btnRoute.Name = "btnRoute";
            this.btnRoute.Size = new System.Drawing.Size(105, 23);
            this.btnRoute.TabIndex = 22;
            this.btnRoute.Text = "Route Destinations";
            this.btnRoute.UseVisualStyleBackColor = true;
            this.btnRoute.Click += new System.EventHandler(this.btnRoute_Click);
            // 
            // txtRoute
            // 
            this.txtRoute.Location = new System.Drawing.Point(111, 398);
            this.txtRoute.MaxLength = 4;
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(33, 20);
            this.txtRoute.TabIndex = 21;
            this.txtRoute.Text = "10";
            this.txtRoute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRtDest
            // 
            this.lblRtDest.AutoSize = true;
            this.lblRtDest.Location = new System.Drawing.Point(144, 401);
            this.lblRtDest.Name = "lblRtDest";
            this.lblRtDest.Size = new System.Drawing.Size(36, 13);
            this.lblRtDest.TabIndex = 83;
            this.lblRtDest.Text = "Route";
            // 
            // txtBusLk
            // 
            this.txtBusLk.Location = new System.Drawing.Point(111, 374);
            this.txtBusLk.Name = "txtBusLk";
            this.txtBusLk.Size = new System.Drawing.Size(33, 20);
            this.txtBusLk.TabIndex = 19;
            this.txtBusLk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnBus
            // 
            this.btnBus.Location = new System.Drawing.Point(4, 372);
            this.btnBus.Name = "btnBus";
            this.btnBus.Size = new System.Drawing.Size(105, 23);
            this.btnBus.TabIndex = 20;
            this.btnBus.Text = "Bus On The Go";
            this.btnBus.UseVisualStyleBackColor = true;
            this.btnBus.Click += new System.EventHandler(this.btnBus_Click);
            // 
            // lblOTGBus
            // 
            this.lblOTGBus.AutoSize = true;
            this.lblOTGBus.Location = new System.Drawing.Point(144, 377);
            this.lblOTGBus.Name = "lblOTGBus";
            this.lblOTGBus.Size = new System.Drawing.Size(25, 13);
            this.lblOTGBus.TabIndex = 86;
            this.lblOTGBus.Text = "Bus";
            // 
            // grpCancelled
            // 
            this.grpCancelled.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpCancelled.Controls.Add(this.rdoCancel);
            this.grpCancelled.Controls.Add(this.rdoEitherCancel);
            this.grpCancelled.Controls.Add(this.rdoNoCancel);
            this.grpCancelled.Location = new System.Drawing.Point(215, 231);
            this.grpCancelled.Name = "grpCancelled";
            this.grpCancelled.Size = new System.Drawing.Size(71, 70);
            this.grpCancelled.TabIndex = 53;
            this.grpCancelled.TabStop = false;
            this.grpCancelled.Text = "Cancelled";
            // 
            // rdoCancel
            // 
            this.rdoCancel.AutoSize = true;
            this.rdoCancel.Location = new System.Drawing.Point(6, 14);
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
            this.rdoEitherCancel.Location = new System.Drawing.Point(6, 48);
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
            this.rdoNoCancel.Location = new System.Drawing.Point(6, 31);
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
            this.chkShowMins.Location = new System.Drawing.Point(4, 251);
            this.chkShowMins.Name = "chkShowMins";
            this.chkShowMins.Size = new System.Drawing.Size(170, 17);
            this.chkShowMins.TabIndex = 15;
            this.chkShowMins.Text = "Relative Time Within        Mins";
            this.chkShowMins.UseVisualStyleBackColor = true;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(245, 444);
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
            this.btnReset.Location = new System.Drawing.Point(200, 444);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(43, 23);
            this.btnReset.TabIndex = 27;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // rtxtList
            // 
            this.rtxtList.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtList.Location = new System.Drawing.Point(292, 3);
            this.rtxtList.Name = "rtxtList";
            this.rtxtList.ReadOnly = true;
            this.rtxtList.Size = new System.Drawing.Size(645, 335);
            this.rtxtList.TabIndex = 90;
            this.rtxtList.Text = "";
            this.rtxtList.WordWrap = false;
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Location = new System.Drawing.Point(73, 326);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(51, 23);
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
            this.lblTime.Location = new System.Drawing.Point(748, 2);
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
            this.btnSearch.Location = new System.Drawing.Point(104, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(49, 23);
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
            this.btnExitFullScr.Location = new System.Drawing.Point(900, 2);
            this.btnExitFullScr.Name = "btnExitFullScr";
            this.btnExitFullScr.Size = new System.Drawing.Size(48, 81);
            this.btnExitFullScr.TabIndex = 93;
            this.btnExitFullScr.Text = "X";
            this.btnExitFullScr.UseVisualStyleBackColor = false;
            this.btnExitFullScr.Visible = false;
            this.btnExitFullScr.Click += new System.EventHandler(this.btnExitFullScr_Click);
            // 
            // txtETAMax
            // 
            this.txtETAMax.Location = new System.Drawing.Point(122, 249);
            this.txtETAMax.MaxLength = 3;
            this.txtETAMax.Name = "txtETAMax";
            this.txtETAMax.Size = new System.Drawing.Size(22, 20);
            this.txtETAMax.TabIndex = 94;
            this.txtETAMax.Text = "60";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(105, 46);
            this.txtDate.MaxLength = 10;
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 96;
            this.txtDate.Visible = false;
            // 
            // btnModeChange
            // 
            this.btnModeChange.Location = new System.Drawing.Point(200, 421);
            this.btnModeChange.Name = "btnModeChange";
            this.btnModeChange.Size = new System.Drawing.Size(88, 23);
            this.btnModeChange.TabIndex = 98;
            this.btnModeChange.Text = "Dark Mode";
            this.btnModeChange.UseVisualStyleBackColor = true;
            this.btnModeChange.Click += new System.EventHandler(this.btnModeChange_Click);
            // 
            // lblRtList
            // 
            this.lblRtList.AutoSize = true;
            this.lblRtList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRtList.Location = new System.Drawing.Point(287, 339);
            this.lblRtList.Name = "lblRtList";
            this.lblRtList.Size = new System.Drawing.Size(86, 25);
            this.lblRtList.TabIndex = 100;
            this.lblRtList.Text = "Routes";
            // 
            // rtxtRtList
            // 
            this.rtxtRtList.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtRtList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.rtxtRtList.Location = new System.Drawing.Point(292, 366);
            this.rtxtRtList.Name = "rtxtRtList";
            this.rtxtRtList.ReadOnly = true;
            this.rtxtRtList.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtRtList.Size = new System.Drawing.Size(413, 101);
            this.rtxtRtList.TabIndex = 101;
            this.rtxtRtList.Text = "";
            this.rtxtRtList.WordWrap = false;
            // 
            // btnOtherInfo
            // 
            this.btnOtherInfo.Location = new System.Drawing.Point(203, 326);
            this.btnOtherInfo.Name = "btnOtherInfo";
            this.btnOtherInfo.Size = new System.Drawing.Size(52, 23);
            this.btnOtherInfo.TabIndex = 102;
            this.btnOtherInfo.Text = "Bus List";
            this.btnOtherInfo.UseVisualStyleBackColor = true;
            this.btnOtherInfo.Click += new System.EventHandler(this.btnOtherInfo_Click);
            // 
            // txtRun
            // 
            this.txtRun.Location = new System.Drawing.Point(157, 175);
            this.txtRun.Name = "txtRun";
            this.txtRun.Size = new System.Drawing.Size(76, 20);
            this.txtRun.TabIndex = 103;
            // 
            // lblRun
            // 
            this.lblRun.AutoSize = true;
            this.lblRun.Location = new System.Drawing.Point(233, 179);
            this.lblRun.Name = "lblRun";
            this.lblRun.Size = new System.Drawing.Size(27, 13);
            this.lblRun.TabIndex = 104;
            this.lblRun.Text = "Run";
            // 
            // lblStopNum
            // 
            this.lblStopNum.AutoSize = true;
            this.lblStopNum.Location = new System.Drawing.Point(151, 26);
            this.lblStopNum.Name = "lblStopNum";
            this.lblStopNum.Size = new System.Drawing.Size(69, 13);
            this.lblStopNum.TabIndex = 105;
            this.lblStopNum.Text = "Stop Number";
            // 
            // lblColour
            // 
            this.lblColour.AutoSize = true;
            this.lblColour.Location = new System.Drawing.Point(233, 130);
            this.lblColour.Name = "lblColour";
            this.lblColour.Size = new System.Drawing.Size(61, 13);
            this.lblColour.TabIndex = 107;
            this.lblColour.Text = "Sign Colour";
            // 
            // cmbColour
            // 
            this.cmbColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColour.FormattingEnabled = true;
            this.cmbColour.Items.AddRange(new object[] {
            "Any",
            "Orange",
            "White"});
            this.cmbColour.Location = new System.Drawing.Point(157, 127);
            this.cmbColour.Name = "cmbColour";
            this.cmbColour.Size = new System.Drawing.Size(76, 21);
            this.cmbColour.TabIndex = 106;
            // 
            // cmbBikeRack
            // 
            this.cmbBikeRack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBikeRack.FormattingEnabled = true;
            this.cmbBikeRack.Items.AddRange(new object[] {
            "Either",
            "Yes",
            "No"});
            this.cmbBikeRack.Location = new System.Drawing.Point(157, 151);
            this.cmbBikeRack.Name = "cmbBikeRack";
            this.cmbBikeRack.Size = new System.Drawing.Size(76, 21);
            this.cmbBikeRack.TabIndex = 108;
            // 
            // lblBike
            // 
            this.lblBike.AutoSize = true;
            this.lblBike.Location = new System.Drawing.Point(233, 156);
            this.lblBike.Name = "lblBike";
            this.lblBike.Size = new System.Drawing.Size(57, 13);
            this.lblBike.TabIndex = 109;
            this.lblBike.Text = "Bike Rack";
            // 
            // btnGetAll
            // 
            this.btnGetAll.Location = new System.Drawing.Point(200, 396);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(88, 23);
            this.btnGetAll.TabIndex = 110;
            this.btnGetAll.Text = "Get All Buses";
            this.btnGetAll.UseVisualStyleBackColor = true;
            this.btnGetAll.Visible = false;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // timAllBuses
            // 
            this.timAllBuses.Interval = 5000;
            this.timAllBuses.Tick += new System.EventHandler(this.timAllBuses_Tick);
            // 
            // fmMain
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(944, 471);
            this.Controls.Add(this.btnExitFullScr);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblStopName);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.rtxtList);
            this.Controls.Add(this.btnFullScreen);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.grpCancelled);
            this.Controls.Add(this.lblOTGBus);
            this.Controls.Add(this.btnBus);
            this.Controls.Add(this.txtBusLk);
            this.Controls.Add(this.lblRtDest);
            this.Controls.Add(this.txtRoute);
            this.Controls.Add(this.btnRoute);
            this.Controls.Add(this.lblBus);
            this.Controls.Add(this.lblBusLen);
            this.Controls.Add(this.cmbBusLength);
            this.Controls.Add(this.lblBusType);
            this.Controls.Add(this.cmbBusType);
            this.Controls.Add(this.btnWebsite);
            this.Controls.Add(this.lblKm);
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
            this.Controls.Add(this.lblOnOff);
            this.Controls.Add(this.lblRefresh);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblRoutes);
            this.Controls.Add(this.txtRte);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.txtStopNum);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.chkRev);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtETAMax);
            this.Controls.Add(this.chkShowMins);
            this.Controls.Add(this.btnModeChange);
            this.Controls.Add(this.rtxtRtList);
            this.Controls.Add(this.lblRtList);
            this.Controls.Add(this.btnOtherInfo);
            this.Controls.Add(this.lblStopNum);
            this.Controls.Add(this.lblBike);
            this.Controls.Add(this.cmbBikeRack);
            this.Controls.Add(this.txtRun);
            this.Controls.Add(this.lblRun);
            this.Controls.Add(this.lblColour);
            this.Controls.Add(this.cmbColour);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnGetAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WTLive";
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.grpCancelled.ResumeLayout(false);
            this.grpCancelled.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtStopNum;
        private System.Windows.Forms.Label lblStop;
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
        private System.Windows.Forms.TextBox txtBus2;
        private System.Windows.Forms.Label lblBusTo;
        private System.Windows.Forms.Timer timCheckStat;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lbFeatures;
        private System.Windows.Forms.Label lblStopFeat;
        private System.Windows.Forms.Button btnOpenAdv;
        private System.Windows.Forms.Button btnNearby;
        private System.Windows.Forms.TextBox txtMaxDist;
        private System.Windows.Forms.Label lblKm;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnWebsite;
        private System.Windows.Forms.ComboBox cmbBusType;
        private System.Windows.Forms.Label lblBusType;
        private System.Windows.Forms.Label lblBusLen;
        private System.Windows.Forms.ComboBox cmbBusLength;
        private System.Windows.Forms.Label lblBus;
        private System.Windows.Forms.Button btnRoute;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Label lblRtDest;
        private System.Windows.Forms.TextBox txtBusLk;
        private System.Windows.Forms.Button btnBus;
        private System.Windows.Forms.Label lblOTGBus;
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
        private System.Windows.Forms.Button btnModeChange;
        private System.Windows.Forms.Label lblRtList;
        private System.Windows.Forms.RichTextBox rtxtRtList;
        private System.Windows.Forms.Button btnOtherInfo;
        private System.Windows.Forms.TextBox txtRun;
        private System.Windows.Forms.Label lblRun;
        private System.Windows.Forms.Label lblStopNum;
        private System.Windows.Forms.Label lblColour;
        private System.Windows.Forms.ComboBox cmbColour;
        private System.Windows.Forms.ComboBox cmbBikeRack;
        private System.Windows.Forms.Label lblBike;
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.Timer timAllBuses;
    }
}

