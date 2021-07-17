using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Linq;

namespace Transit
{
    public partial class fmMain : Form
    {
        String StopNum;
        String Start;
        String Route;
        String Date;
        String Search;
        bool MinsETA;
        int[] SearchBus = new int[2];
        String BusType = "";
        int BusTypeMatch = 0;
        String BusLength = "";
        int BusLengthMatch = 0;
        int FontSize = 16;
        String BikeType;
        public static String[] XY = new string[2];
        public static String StopName = "";
        public static String Dist = "";
        public static String RouteLook = "";
        bool Reverse;
        bool NoCancel; bool Cancel;
        String LastMessage = "";
        String LastStat = "";

        public fmMain()
        {
            InitializeComponent();
            //rtxtList.KeyDown += rtxtList_KeyDown;
        }

        private void rtxtList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { ExitFullScr(); }
        }

        public void ExitFullScr()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Normal;
            rtxtList.Size = new Size(645, 406);
            rtxtList.Location = new Point(298,3);
            FontSize = 16;
            lblStopName.Visible = false;
            lblTime.Visible = false;
            timUpdateTime.Enabled = false;

            try
            {
                GetList();
            }
            catch (System.Net.WebException exception)
            {
                if (exception.Message.IndexOf("(500) Internal Server Error") != -1) { rtxtList.Text = "Server Error"; }
                else { MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK); }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            String X = "";

            StopNum = txtStopNum.Text;

            if (StopNum.Length == 0) { MessageBox.Show("The stop number is blank!", "Error", MessageBoxButtons.OK); }
            else if (StopNum.Length != 5) { MessageBox.Show("The stop number must be 5 digits long!", "Error", MessageBoxButtons.OK); }
            else
            {
                DisableBtns();

                BusType = cmbBusType.Text;
                BusLength = cmbBusLength.Text;

                //btnNearby.Enabled = true;
                btnWebsite.Enabled = true;

                Cancel = rdoCancel.Checked;
                NoCancel = rdoNoCancel.Checked;
                Reverse = chkRev.Checked;
                Search = txtSearch.Text.ToUpper();
                MinsETA = chkShowMins.Checked;
                SearchBus[0] = 0;
                SearchBus[1] = 1000;

                if (txtBus.Text != "") { SearchBus[0] = int.Parse(txtBus.Text); }
                if (txtBus2.Text != "") { SearchBus[1] = int.Parse(txtBus2.Text); }

                if (rdoBike.Checked == true) { BikeType = "🚲"; }
                if (rdoNoBike.Checked == true) { BikeType = "🚳"; }
                if (rdoBikeorNoBike.Checked == true) { BikeType = ""; }

                Start = txtStart.Text + ":00";

                if (Start == ":00") { Start = ""; }
                if (Start.Length == 7) { Start = "0" + Start; }
                //Console.WriteLine(Start);

                calCalendar.MaxSelectionCount = 1;

                Route = txtRte.Text.ToUpper();

                if (chkDate.Checked == true) { Date = calCalendar.SelectionRange.Start.ToString().Substring(0, 10); Start = Date + "T" + Start; } else { Date = ""; }

                //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));

                try 
                {
                    GetList();
                    GetFeatures();
                

                    double X1;

                    if (txtInterval.Text != "")
                    {
                       X1 = double.Parse(txtInterval.Text) * 1000;
                        if (X1 >= 5000)
                        {
                            timAutoGet.Interval = (Int32)X1;

                            X = Convert.ToString(60.0 / (X1 / 1000.0));
                            if (X.Length > 4) { X = X.Substring(0, 4); }

                            if (chkAuto.Checked == true && timAutoGet.Interval != 0) { timAutoGet.Enabled = true; lblOnOff.Text = "Refresh Enabled (" + Convert.ToString(X1 / 1000) + " Seconds, " + X + " Per Minute)"; btnStop.Enabled = true; }
                            if (chkAuto.Checked == false | timAutoGet.Interval == 0) { timAutoGet.Enabled = false; lblOnOff.Text = "Refresh Disabled"; btnStop.Enabled = false; }
                        }
                        else { timAutoGet.Enabled = false; lblOnOff.Text = "Refresh Disabled"; btnStop.Enabled = false; if (chkAuto.Checked == true) { MessageBox.Show("The refresh interval must be at least 5 seconds! Auto refresh will be disabled.", "Warning", MessageBoxButtons.OK); } }
                    }
                    else { timAutoGet.Enabled = false; lblOnOff.Text = "Refresh Disabled"; btnStop.Enabled = false; if (chkAuto.Checked == true) { MessageBox.Show("The refresh interval cannot be blank! Auto refresh will be disabled.", "Warning", MessageBoxButtons.OK); } }
                }
                catch (System.Net.WebException exception)
                {
                    if (exception.Message.IndexOf("(404) Not Found") != -1) 
                    {
                        MessageBox.Show("Stop Number Doesn't Exist!", "Error", MessageBoxButtons.OK);
                        btnStop.Enabled = false;
                        timAutoGet.Enabled = false;
                        lblOnOff.Text = "Refresh Disabled";
                    }
                    else if (exception.Message.IndexOf("(500) Internal Server Error") != -1) { MessageBox.Show("Winnipeg Transit Server Error", "Error", MessageBoxButtons.OK); }
                    else { MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK); }
                }
            }
        }
        public void GetList()
        {
                String StartB = Start;

                if (StartB.Length == 11 | StartB.Length == 0) { StartB += DateTime.Now.ToString("HH:mm:ss"); }

                String URLString = "https://api.winnipegtransit.com/v3/stops/" + StopNum + "/schedule?api-key=yxCT5Ca2Ep5AVLc0z6zz&start=" + StartB + "&end=&route=" + Route + "&usage=long";
                String LastName = "";
                String LastNameB = "";


                String[] List = new string[1001];
                double[] ListTime = new double[1001];
                double[] ListSchTime = new double[1001];
                String[] ListCol = new string[1001];
                String[] ListBCol = new string[1001];
                String Col = "";
                String BCol = "";

                String Temp = "";
                double TempTime = 0;
                String TempCol = "";
                String TempBCol = "";

                int Count = 0;
                int TimeSec = (DateTime.Now.Hour * 3600) + (DateTime.Now.Minute * 60) + DateTime.Now.Second;

                if (TimeSec < 14400) { TimeSec += 86400; }

                String SchTime = "";
                String Time = "";
                String RouteNm = "";
                String Bus = ", Bus 000";
                String Bike = ", ---";
                String Cancelled = "";

                int RtDash;
                int X; int X2; DateTime dt = new DateTime();

                XmlTextReader reader = new XmlTextReader(URLString);

            while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            if (LastName == "bus" && reader.Name == "key")
                            {
                                LastName = "keyBus";
                            }
                            else if (LastName == "variant" && reader.Name == "key")
                            {
                                LastName = "keyRt";
                            }
                            else if (LastNameB == "stop" && LastName == "key" && reader.Name == "name")
                            {
                                LastName = "keyStop";
                            }
                            else if (LastName == "departure" && reader.Name == "scheduled")
                            {
                                LastName = "keySch";
                            }
                            else if (LastNameB == "departure" && LastName == "scheduled" && reader.Name == "estimated")
                            {
                                LastName = "keyTime";
                            }
                            else if (LastName == "keyRt")
                            {
                                LastName = "keyDest";
                            }
                            else
                            {
                                LastNameB = LastName;
                                LastName = reader.Name;
                            }
                            break;
                        case XmlNodeType.Text: //Display the text in each element.
                            if (LastName == "keyBus")
                            {
                                Bus = ", Bus " + reader.Value;
                            }
                            else if (LastName == "keyRt")
                            {
                                RtDash = reader.Value.IndexOf("-");
                                if (reader.Value.Substring(0, RtDash) == "101" | reader.Value.Substring(0, RtDash) == "102" | reader.Value.Substring(0, RtDash) == "110")
                                {
                                    RouteNm = reader.Value.Substring(0, RtDash) + " DART";
                                }
                                else
                                {
                                    RouteNm = reader.Value.Substring(0, RtDash);
                                }
                            }
                            else if (LastName == "keySch")
                            {
                                LastNameB = "departure";
                                LastName = "scheduled";
                                SchTime = reader.Value.Substring(reader.Value.Length - 8, 8);
                            }
                            else if (LastName == "keyTime")
                            {
                                Time = reader.Value.Substring(reader.Value.Length - 8, 8);
                            }
                            else if (LastName == "keyDest")
                            {
                                if (RouteNm == "101 DART" | RouteNm == "102 DART" | RouteNm == "110 DART")
                                {
                                    RouteNm += "";
                                }
                                else
                                {
                                    RouteNm += " " + reader.Value;
                                }
                            }
                            else if (LastName == "keyStop")
                            {
                                StopName = StopNum + " " + reader.Value;
                                this.Text = "Stop Schedule - " + StopNum + " " + reader.Value;
                                lblStopName.Text = StopNum + " " + reader.Value;
                            }
                            else if (LastName == "bike-rack")
                            {
                                if (reader.Value == "true") { Bike = ", 🚲"; } else { Bike = ", 🚳"; }
                            }
                            else if (LastName == "latitude")
                            {
                                XY[0] = reader.Value;
                            }
                            else if (LastName == "longitude")
                            {
                                XY[1] = reader.Value;
                            }
                            else if (LastName == "cancelled")
                            {
                                if (reader.Value == "true") { Cancelled = " - ❌❌❌"; } else { Cancelled = ""; }
                            }
                            else if (LastName == "color")
                            {
                                Col = reader.Value;
                            }
                            else if (LastName == "background-color")
                            {
                                BCol = reader.Value;
                            }
                            break;
                        case XmlNodeType.EndElement: //Display the end of the element.  
                            if (reader.Name == "scheduled-stop")
                            {
                                BusTypeMatch = 0;
                                if (BusType == "Any") { BusTypeMatch = 1; }
                                else if (BusType == "D30LF")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 930 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 949) { BusTypeMatch = 1; }
                                }
                                else if (BusType == "D40LF (All)")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 201 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 281) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 510 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 599) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 641 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 664) { BusTypeMatch = 1; }
                                }
                                else if (BusType == "D40LF (Reg)")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 201 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 281) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 510 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 599) { BusTypeMatch = 1; }
                                }
                                else if (BusType == "D40LF (Ex-CT)")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 641 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 664) { BusTypeMatch = 1; }
                                }
                                else if (BusType == "D60LF")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 971 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 990) { BusTypeMatch = 1; }
                                }
                                else if (BusType == "D40LFR")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 101 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 169) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 601 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 640) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 701 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 830) { BusTypeMatch = 1; }
                                }
                                else if (BusType == "XD40")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 170 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 199) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 300 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 369) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 401 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 471) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 831 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 888) { BusTypeMatch = 1; }
                                }
                                else if (BusType == "XD60")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 371 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 398) { BusTypeMatch = 1; }
                                }
                                else if (BusType == "-LF")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 201 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 281) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 510 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 599) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 641 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 664) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 930 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 949) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 971 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 990) { BusTypeMatch = 1; }
                                }
                                else if (BusType == "-LFR")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 101 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 169) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 601 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 640) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 701 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 830) { BusTypeMatch = 1; }
                                }
                                else if (BusType == "Xcelsior")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 170 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 199) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 300 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 369) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 371 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 398) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 401 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 471) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 831 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 888) { BusTypeMatch = 1; }
                                }
                                else if (BusType == "Orange Sign")
                                {
                                    BusTypeMatch = 1;
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) == 369) { BusTypeMatch = 0; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 436 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 471) { BusTypeMatch = 0; }
                                }
                                else if (BusType == "White Sign")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) == 369) { BusTypeMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 436 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 471) { BusTypeMatch = 1; }
                                }

                                BusLengthMatch = 0;
                                if (BusLength == "Any") { BusLengthMatch = 1; }
                                else if (BusLength == "30 Feet")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 930 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 949) { BusLengthMatch = 1; }
                                }
                                else if (BusLength == "40 Feet")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 101 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 169) { BusLengthMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 170 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 199) { BusLengthMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 201 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 281) { BusLengthMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 300 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 369) { BusLengthMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 401 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 471) { BusLengthMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 510 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 599) { BusLengthMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 601 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 640) { BusLengthMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 641 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 664) { BusLengthMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 701 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 830) { BusLengthMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 831 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 888) { BusLengthMatch = 1; }
                                }
                                else if (BusLength == "60 Feet")
                                {
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 371 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 398) { BusLengthMatch = 1; }
                                    if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 971 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 990) { BusLengthMatch = 1; }
                                }

                                //Console.WriteLine(Bus);
                                if ((Search == "" | RouteNm.ToUpper().IndexOf(Search) != -1) && (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= SearchBus[0] && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= SearchBus[1]) && (BikeType == "" | Bike.IndexOf(BikeType) != -1) && BusTypeMatch == 1 && BusLengthMatch == 1 && (Cancelled == "" | NoCancel == false) && (Cancelled == " - ❌❌❌" | Cancel == false))
                                {
                                    if (double.Parse(StartB.Substring(0, 2)) + (double.Parse(StartB.Substring(3, 2)) / 60) >= 2.8334 | Bike != ", ---")
                                    {
                                        if (Bus == ", Bus 000") { Bus = ", Bus -----"; }
                                        Count += 1;
                                        ListCol[Count] = Col;
                                        ListBCol[Count] = BCol;

                                        ListSchTime[Count] = (Double.Parse(SchTime.Substring(0, 2)) * 3600) + (Double.Parse(SchTime.Substring(3, 2)) * 60) + Double.Parse(SchTime.Substring(6, 2));
                                        ListTime[Count] = (Double.Parse(Time.Substring(0, 2)) * 3600) + (Double.Parse(Time.Substring(3, 2)) * 60) + Double.Parse(Time.Substring(6, 2));

                                        if (ListTime[Count] < 14400) { ListTime[Count] += 86400; }
                                        if (ListSchTime[Count] < 14400) { ListSchTime[Count] += 86400; }

                                        if (MinsETA == false | Math.Round((ListTime[Count] - TimeSec) / 60) >= 60 | Math.Round((ListTime[Count] - TimeSec) / 60) < 0) { List[Count] = Time.Substring(0, 5); }
                                        else
                                        {
                                            if (Math.Round((ListTime[Count] - TimeSec) / 60) == 0)
                                            {
                                                List[Count] = "-Due-";
                                            }
                                            else if (Math.Round((ListTime[Count] - TimeSec) / 60) == 1)
                                            {
                                            List[Count] = "1 Min";
                                            }
                                            else
                                            {
                                                List[Count] = Math.Round((ListTime[Count] - TimeSec) / 60).ToString() + " Mins";
                                            }
                                        }

                                        //List[Count] += ", ";
                                        //if (MinsETA == true) { List[Count] += new String(' ', 9 - List[Count].Length); }

                                        List[Count] += Bus + Bike + " - "+ RouteNm;

                                        if (ListTime[Count] - ListSchTime[Count] >= 60) { List[Count] += " (" + Math.Round((ListTime[Count] - ListSchTime[Count]) / 60).ToString() + "m L, " + SchTime.Substring(0, 5) + ")"; }
                                        if (ListSchTime[Count] - ListTime[Count] >= 60) { List[Count] += " (" + Math.Round((ListSchTime[Count] - ListTime[Count]) / 60).ToString() + "m E, " + SchTime.Substring(0, 5) + ")"; }

                                        List[Count] += Cancelled;
                                    }
                                }
                                Bus = ", Bus 000";
                                Bike = ", ---";
                            }
                            break;
                    }

                }

            for (int i = 1; i <= Count; i++)
                {
                    for (int i2 = 2; i2 <= Count; i2++)
                    {
                        if ((ListTime[i2 - 1] > ListTime[i2] && Reverse == false) | (ListTime[i2 - 1] < ListTime[i2] && Reverse == true))
                        {
                            Temp = List[i2 - 1];
                            List[i2 - 1] = List[i2];
                            List[i2] = Temp;

                            TempTime = ListTime[i2 - 1];
                            ListTime[i2 - 1] = ListTime[i2];
                            ListTime[i2] = TempTime;

                            TempCol = ListCol[i2 - 1];
                            ListCol[i2 - 1] = ListCol[i2];
                            ListCol[i2] = TempCol;

                            TempBCol = ListBCol[i2 - 1];
                            ListBCol[i2 - 1] = ListBCol[i2];
                            ListBCol[i2] = TempBCol;
                        }
                    }
                }

                rtxtList.Text = "";
                for (int i = 1; i <= Count; i++)
                {
                    if (List[i].IndexOf(" - ❌❌❌") != -1) { rtxtList.SelectionFont = new Font("Microsoft Sans Serif", FontSize, FontStyle.Strikeout); rtxtList.SelectionColor = Color.Red; } else { rtxtList.SelectionFont = new Font("Microsoft Sans Serif", FontSize, FontStyle.Regular); }
                    X = List[i].IndexOf(" - ");
                    X += 3;
                    X2 = List[i].IndexOf(" ", X);
                    rtxtList.AppendText(List[i].Substring(0, X));

                    if (List[i].IndexOf(" - ❌❌❌") != -1) { rtxtList.SelectionColor = Color.Red; } else { rtxtList.SelectionColor = Color.FromArgb(int.Parse(ListCol[i].Substring(1, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(ListCol[i].Substring(3, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(ListCol[i].Substring(5, 2), System.Globalization.NumberStyles.HexNumber)); }

                    if (List[i].Substring(X, 3) == "24 " && (dt.DayOfWeek == DayOfWeek.Sunday | List[i].IndexOf("Polo Park") != -1 | List[i].IndexOf("Portage & Tylehurst") != -1 | StopNum == "10881"))
                    {
                        rtxtList.SelectionBackColor = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        rtxtList.SelectionBackColor = Color.FromArgb(int.Parse(ListBCol[i].Substring(1, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(ListBCol[i].Substring(3, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(ListBCol[i].Substring(5, 2), System.Globalization.NumberStyles.HexNumber));
                    }

                    rtxtList.AppendText(" " + List[i].Substring(X, X2 - X) + " ");
                    X += X2 - X;

                    rtxtList.SelectionColor = Color.Black;
                    rtxtList.SelectionBackColor = Color.White;

                    X2 = List[i].IndexOf(" (");
                    if (X2 == -1)
                    {
                        if (List[i].IndexOf(" - ❌❌❌") != -1)
                        {
                            rtxtList.SelectionColor = Color.Red;
                            rtxtList.AppendText(List[i].Substring(X, List[i].IndexOf(" - ❌❌❌") - X) + (char)10);
                        }
                        else
                        {
                            rtxtList.AppendText(List[i].Substring(X) + (char)10);
                        }
                    }
                    else
                    {
                        if (List[i].IndexOf(" - ❌❌❌") != -1) { rtxtList.SelectionColor = Color.Red; }

                        rtxtList.AppendText(List[i].Substring(X, X2 - X + 2));
                        if (List[i].IndexOf(" L, ") != -1)
                        {
                            rtxtList.SelectionColor = Color.Red;
                        }
                        else if (List[i].IndexOf(" E, ") != -1)
                        {
                            rtxtList.SelectionColor = Color.Blue;
                        }

                        X = List[i].IndexOf(")");
                        rtxtList.AppendText(List[i].Substring(X2 + 2, X - X2 - 2));
                        if (List[i].IndexOf(" - ❌❌❌") != -1) { rtxtList.SelectionColor = Color.Red; } else { rtxtList.SelectionColor = Color.Black; }
                        rtxtList.AppendText(List[i].Substring(X, 1) + (char)10);
                    }
                }
                rtxtList.SelectionStart = 0;
                rtxtList.ScrollToCaret();
                rtxtList.SelectionColor = Color.Black;
                rtxtList.SelectionBackColor = Color.White;

                if (rtxtList.Text == "") { rtxtList.Text = "Nothing to Show"; }
        }

        private void timAutoGet_Tick(object sender, EventArgs e)
        {
            try
            {
                GetList();
            }
            catch (System.Net.WebException exception)
            {
                if (exception.Message.IndexOf("(500) Internal Server Error") != -1) { rtxtList.Text = "Server Error"; }
                else { MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK); }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timAutoGet.Enabled = false;
            lblOnOff.Text = "Refresh Disabled";
            btnStop.Enabled = false;
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            CheckStat();
            cmbBusType.SelectedIndex = 0;
            cmbBusLength.SelectedIndex = 0;
        }

        private void timCheckStat_Tick(object sender, EventArgs e)
        {
            try
            {
                CheckStat();
            }
            catch (System.Net.WebException exception)
            {
                if (exception.Message.IndexOf("(500) Internal Server Error") != -1) { }
                else { MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK); }
            }
        }

        public void CheckStat()
        {
            String URLString = "https://api.winnipegtransit.com/v3/statuses/schedule?api-key=yxCT5Ca2Ep5AVLc0z6zz&usage=long";
            XmlTextReader reader = new XmlTextReader(URLString);
            String LastName = "";
            String StatValue = "";
            String Status = "";

            //lblStatus.Text = "";

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        {
                            LastName = reader.Name;
                            break;
                        }
                    case XmlNodeType.Text: //Display the text in each element.
                        {
                            if (LastName == "message")
                                { if (StatValue != "regular") { 
                                    Status = reader.Value;
                                   
                                    if (reader.Value != LastStat)
                                    {
                                        LastStat = reader.Value;
                                        MessageBox.Show(reader.Value + (char)10 + "(" + DateTime.Now.ToString("HH:mm:ss") + ", " + StatValue + ")", "Service Alert", MessageBoxButtons.OK);
                                    }
                                } 
                            }
                            else if (LastName == "value")
                                { StatValue = reader.Value; }
                            break;
                        }
                    case XmlNodeType.EndElement: //Display the end of the element.  
                        {
                            break;
                        }
                }
            }
            lblStatus.Text = Status;

            URLString = "https://api.winnipegtransit.com/v3/system-messages?api-key=yxCT5Ca2Ep5AVLc0z6zz&usage=long";
            reader = new XmlTextReader(URLString);
            LastName = "";
            String StatType = "";
            String Message = "";

            //lblMessage.Text = "";

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        {
                            LastName = reader.Name;
                            break;
                        }
                    case XmlNodeType.Text: //Display the text in each element.
                        {
                            if (LastName == "message")
                            {
                                Message = reader.Value; 

                                if (reader.Value != LastMessage)
                                {
                                    LastMessage = reader.Value;
                                    if (reader.Value != "") { MessageBox.Show(reader.Value + (char)10 + "(" + DateTime.Now.ToString("HH:mm:ss") + ")", StatType, MessageBoxButtons.OK); }
                                }
                            }
                            else if (LastName == "type")
                                { StatType = reader.Value; }
                            break;
                        }
                    case XmlNodeType.EndElement: //Display the end of the element.  
                        {
                            break;
                        }
                }
            }

            lblMessage.Text = Message;
            if (Message == "") { 
                this.Size = new Size(971, 581);
            } 
            else 
            {
                this.Size = new Size(971, 601);
            }
        }

        private void btnOpenAdv_Click(object sender, EventArgs e)
        {
            fmAdvisory Adv = new fmAdvisory();
            Adv.Show();
        }

        private void GetFeatures()
        {
            lbFeatures.Items.Clear();
            String URLString = "https://api.winnipegtransit.com/v3/stops/" + StopNum + "/features?api-key=yxCT5Ca2Ep5AVLc0z6zz&usage=long";
            XmlTextReader reader = new XmlTextReader(URLString);
            String LastName = "";

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        {
                            LastName = reader.Name;
                            break;
                        }
                    case XmlNodeType.Text: //Display the text in each element.
                        {
                            if (LastName == "name")
                            { lbFeatures.Items.Add(reader.Value); }
                            break;
                        }
                    case XmlNodeType.EndElement: //Display the end of the element.  
                        {
                            break;
                        }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMaxDist.Text != "")
            {
                DisableBtns();
                Dist = txtMaxDist.Text;
                fmNearby Nb = new fmNearby();
                Nb.Show();
            }
            else { MessageBox.Show("The distance box cannot be blank!", "Error", MessageBoxButtons.OK); }
        }

        private void btnWebsite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://winnipegtransit.com/en/stops/" + StopNum);
        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            if (txtRoute.Text != "")
            {
                DisableBtns();
                RouteLook = txtRoute.Text;
                fmRoute Rte = new fmRoute();
                Rte.Show();
            }
            else { MessageBox.Show("The route box cannot be blank!", "Error", MessageBoxButtons.OK); }
        }

        private void btnBus_Click(object sender, EventArgs e)
        {
            string BusLook = txtBusLk.Text;
            System.Diagnostics.Process.Start("https://m.winnipegtransit.com/onthego/bus/" + BusLook);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program is made by Taylor Woolston. It is not produced by, affiliated with or endorsed by Winnipeg Transit. V1.2 - 2021-07-17", "About", MessageBoxButtons.OK);
            //MessageBox.Show("This program is not produced by, affiliated with or endorsed by Winnipeg Transit.", "About", MessageBoxButtons.OK);
        }

        private void timGoBtn_Tick(object sender, EventArgs e)
        {
            btnGo.Enabled = true;
            if (this.Text != "Stop Schedule") { btnNearby.Enabled = true; }
            btnRoute.Enabled = true;
            btnOpenAdv.Enabled = true;
            btnFullScreen.Enabled = true;

            timGoBtn.Enabled = false;
        }

        private void DisableBtns()
        {
            btnGo.Enabled = false;
            btnNearby.Enabled = false;
            btnRoute.Enabled = false;
            btnOpenAdv.Enabled = false;
            btnFullScreen.Enabled = false;

            timGoBtn.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtStopNum.Text = "";
            txtStart.Text = "";
            txtRte.Text = "";
            txtBus.Text = "";
            txtBus2.Text = "";
            cmbBusType.SelectedIndex = 0;
            cmbBusLength.SelectedIndex = 0;
            txtSearch.Text = "";
            chkShowMins.Checked = false;
            chkAuto.Checked = false;
            chkRev.Checked = false;
            txtInterval.Text = "30";

            timAutoGet.Enabled = false;
            lblOnOff.Text = "Refresh Disabled";
            btnStop.Enabled = false;

            rdoBikeorNoBike.Checked = true;
            rdoEitherCancel.Checked = true;

            txtBusLk.Text = "";
            txtRoute.Text = "10";
            txtMaxDist.Text = "2";

            rtxtList.Text = "";
            lbFeatures.Items.Clear();
            lblStopName.Text = "Stop Name";

            btnNearby.Enabled = false;
            btnWebsite.Enabled = false;
            btnFullScreen.Enabled = false;

            this.Text = "Stop Schedule";
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            UpdateTime();

            rtxtList.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 80);
            rtxtList.Location = new Point(0, 80);
            lblStopName.Size = new Size(Screen.PrimaryScreen.Bounds.Width, 80);
            
            FontSize = 48;
            lblTime.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 165, 0);
            lblStopName.Visible = true;
            lblTime.Visible = true;

            timUpdateTime.Enabled = true;

            try
            {
                GetList();
            }
            catch (System.Net.WebException exception)
            {
                if (exception.Message.IndexOf("(500) Internal Server Error") != -1) { rtxtList.Text = "Server Error"; }
                else { MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK); }
            }
        }

        private void rtxtList_DoubleClick (object sender, EventArgs e)
        {
            ExitFullScr();
        }

        private void timUpdateTime_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            if (DateTime.Now.Minute < 10)
            {
                lblTime.Text = DateTime.Now.Hour.ToString() + ":0" + DateTime.Now.Minute.ToString();
            }
            else
            {
                lblTime.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            }
        }
    }
}