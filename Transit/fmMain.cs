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
        String StopNum; public static String StopNum2; String LastStopNum2 = "";
        String Start = "";
        String Route;
        String Date;
        String Search;
        bool MinsETA;
        int[] SearchBus = new int[2];
        String BusType = ""; int BusTypeMatch = 0;
        String BusLength = ""; int BusLengthMatch = 0;
        int FontSize = 16;
        public static int FirstSearch = 1;
        public static String[] StopList = new string[6000];

        String ErrMessage = "";

        String BikeType;
        public static String[] XY = new string[2];
        public static String StopName = "";
        public static String Dist = "";
        public static String RouteLook = "";
        bool Reverse;
        bool NoCancel; bool Cancel;
        String LastMessage = "";
        String LastStat = "";

        int Count = 0; int X1; int X2; int ETAMax;
        DateTime dt = DateTime.Now;
        String[] List = new string[1001]; String[] ListCol = new string[1001]; String[] ListBCol = new string[1001];
        String Col = ""; String BCol = "";

        public fmMain()
        {
            InitializeComponent();
            //rtxtList.KeyDown += rtxtList_KeyDown;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            StopNum = txtStopNum.Text;
            if (StopNum.Length == 0) { MessageBox.Show("The stop number is blank!", "Error", MessageBoxButtons.OK); }
            else if (StopNum.Length != 5) { MessageBox.Show("The stop number must be 5 digits long!", "Error", MessageBoxButtons.OK); }
            else
            {
                GoPress();
            }
        }

        public void GoPress()
        {
            String X = "";
            Start = "";

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

            ETAMax = 0;
            if (txtETAMax.Text == "" && MinsETA == true)
            {
                MessageBox.Show("The max ETA in Mins times cannot be blank! 'ETA in Mins' will be disabled.", "Warning", MessageBoxButtons.OK);
                MinsETA = false;
            }
            else if (MinsETA == true)
            {
                ETAMax = int.Parse(txtETAMax.Text);
            }

            SearchBus[0] = 0;
            SearchBus[1] = 1000;

            if (txtBus.Text != "") { SearchBus[0] = int.Parse(txtBus.Text); }
            if (txtBus2.Text != "") { SearchBus[1] = int.Parse(txtBus2.Text); }

            if (rdoBike.Checked == true) { BikeType = "🚲"; }
            if (rdoNoBike.Checked == true) { BikeType = "🚳"; }
            if (rdoBikeorNoBike.Checked == true) { BikeType = ""; }

            if (txtStart.Text != "") { Start = txtStart.Text + ":00"; }
            if (Start.Length == 7) { Start = "0" + Start; }
            //Console.WriteLine(Start);

            Route = txtRte.Text.ToUpper();
            if (txtDate.Text != "") { Start = txtDate.Text + "T" + Start; }
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
                ErrMessage = exception.Message;
                ShowNetErr();
            }
        }

        public void GetList()
        {
            String StartB = Start;
            int ExtraChars = 0;

            if (StartB.Length == 10 | StartB.Length == 0) { StartB += DateTime.Now.ToString("HH:mm:ss"); }
            if (StartB.IndexOf("T") != -1) { ExtraChars = 11; } else { ExtraChars = 0; }

            System.Console.WriteLine(StartB);

            String URLString = "https://api.winnipegtransit.com/v3/stops/" + StopNum + "/schedule?api-key=yxCT5Ca2Ep5AVLc0z6zz&start=" + StartB + "&end=&route=" + Route + "&usage=long";
            String LastName = "";
            String LastNameB = "";

            double[] ListTime = new double[1001];
            double[] ListSchTime = new double[1001];

            String Temp = "";
            double TempTime = 0;
            String TempCol = "";
            String TempBCol = "";

            
            int TimeSec = (DateTime.Now.Hour * 3600) + (DateTime.Now.Minute * 60) + DateTime.Now.Second;

            if (TimeSec < 14400) { TimeSec += 86400; }

            String SchTime = "";
            String Time = "";
            String RouteNm = "";
            String Bus = ", Bus 000";
            String Bike = ", ---";
            String Cancelled = "";

            int RtDash;

            Count = 0;
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
                                //RouteNm += "";
                            }
                            else if (reader.Value == "Downtown (City Hall)")
                            {
                                RouteNm += " " + "City Hall";
                            }
                            else if (reader.Value == "St. Vital Centre via River Road")
                            {
                                RouteNm += " " + "St. Vital Centre";
                            }
                            else if (reader.Value == "Centre Street via Bridgwater")
                            {
                                RouteNm += " " + "Bridgwater Centre";
                            }
                            else if (reader.Value == "Wolseley-Provencher via Provencher")
                            {
                                RouteNm += " " + "Wolseley via Provencher";
                            }
                            else if (reader.Value == "WalMart via McPhillips")
                            {
                                RouteNm += " " + "Templeton via McPhillips";
                            }
                            else
                            {
                                RouteNm += " " + reader.Value;
                            }
                        }
                        else if (LastName == "keyStop")
                        {
                            StopName = StopNum + " " + reader.Value;
                            this.Text = "WTLive - " + StopNum + " " + reader.Value;
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
                                if (double.Parse(StartB.Substring(0 + ExtraChars, 2)) + (double.Parse(StartB.Substring(3 + ExtraChars, 2)) / 60) >= 2.8334 | Bike != ", ---")
                                {
                                    if (Bus == ", Bus 000") { Bus = ", Bus -----"; }
                                    Count += 1;
                                    ListCol[Count] = Col;
                                    ListBCol[Count] = BCol;

                                    ListSchTime[Count] = (Double.Parse(SchTime.Substring(0, 2)) * 3600) + (Double.Parse(SchTime.Substring(3, 2)) * 60) + Double.Parse(SchTime.Substring(6, 2));
                                    ListTime[Count] = (Double.Parse(Time.Substring(0, 2)) * 3600) + (Double.Parse(Time.Substring(3, 2)) * 60) + Double.Parse(Time.Substring(6, 2));

                                    if (ListTime[Count] < 14400) { ListTime[Count] += 86400; }
                                    if (ListSchTime[Count] < 14400) { ListSchTime[Count] += 86400; }

                                    if (MinsETA == false | Math.Round((ListTime[Count] - TimeSec) / 60) > ETAMax | Math.Round((ListTime[Count] - TimeSec) / 60) < 0) { List[Count] = Time.Substring(0, 5); }
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

                                    List[Count] += Bus + Bike + " - " + RouteNm;

                                    if (ListTime[Count] - ListSchTime[Count] >= 60) { List[Count] += " (+" + Math.Round((ListTime[Count] - ListSchTime[Count]) / 60).ToString() + ")"; }
                                    if (ListSchTime[Count] - ListTime[Count] >= 60) { List[Count] += " (-" + Math.Round((ListSchTime[Count] - ListTime[Count]) / 60).ToString() + ")"; }

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

            PrintResults();
        }

        private void PrintResults()
        {
            rtxtList.Text = "";
            for (int i = 1; i <= Count; i++)
            {
                if (List[i].IndexOf(" - ❌❌❌") != -1) { rtxtList.SelectionFont = new Font("Microsoft Sans Serif", FontSize, FontStyle.Strikeout); rtxtList.SelectionColor = Color.Red; } else { rtxtList.SelectionFont = new Font("Microsoft Sans Serif", FontSize, FontStyle.Regular); }
                X1 = List[i].IndexOf(" - ");
                X1 += 3;
                X2 = List[i].IndexOf(" ", X1);
                rtxtList.AppendText(List[i].Substring(0, X1));

                if (List[i].IndexOf(" - ❌❌❌") != -1) { rtxtList.SelectionColor = Color.Red; } else { rtxtList.SelectionColor = Color.FromArgb(int.Parse(ListCol[i].Substring(1, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(ListCol[i].Substring(3, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(ListCol[i].Substring(5, 2), System.Globalization.NumberStyles.HexNumber)); rtxtList.SelectionFont = new Font("Microsoft Sans Serif", FontSize, FontStyle.Bold); }

                dt = DateTime.Now;
                if (List[i].Substring(X1, 3) == "24 " && (dt.DayOfWeek == DayOfWeek.Sunday | List[i].IndexOf("Polo Park") != -1 | List[i].IndexOf("Portage & Tylehurst") != -1 | StopNum == "10881"))
                {
                    rtxtList.SelectionBackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    rtxtList.SelectionBackColor = Color.FromArgb(int.Parse(ListBCol[i].Substring(1, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(ListBCol[i].Substring(3, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(ListBCol[i].Substring(5, 2), System.Globalization.NumberStyles.HexNumber));
                }

                rtxtList.AppendText(" " + List[i].Substring(X1, X2 - X1) + " ");
                X1 += X2 - X1;

                rtxtList.SelectionColor = Color.Black;
                rtxtList.SelectionBackColor = Color.White;

                X2 = List[i].IndexOf(" (");
                if (X2 == -1)
                {
                    if (List[i].IndexOf(" - ❌❌❌") != -1)
                    {
                        rtxtList.SelectionColor = Color.Red;
                        rtxtList.AppendText(List[i].Substring(X1, List[i].IndexOf(" - ❌❌❌") - X1) + (char)10);
                    }
                    else
                    {
                        rtxtList.SelectionFont = new Font("Microsoft Sans Serif", FontSize, FontStyle.Regular);
                        rtxtList.AppendText(List[i].Substring(X1) + (char)10);
                    }
                }
                else
                {
                    if (List[i].IndexOf(" - ❌❌❌") != -1) { rtxtList.SelectionColor = Color.Red; } else { rtxtList.SelectionFont = new Font("Microsoft Sans Serif", FontSize, FontStyle.Regular); }

                    rtxtList.AppendText(List[i].Substring(X1, X2 - X1 + 2));
                    if (List[i].IndexOf("(+") != -1)
                    {
                        rtxtList.SelectionColor = Color.Red;
                    }
                    else if (List[i].IndexOf("(-") != -1)
                    {
                        rtxtList.SelectionColor = Color.Blue;
                    }

                    X1 = List[i].IndexOf(")");
                    rtxtList.AppendText(List[i].Substring(X2 + 2, X1 - X2 - 2));
                    if (List[i].IndexOf(" - ❌❌❌") != -1) { rtxtList.SelectionColor = Color.Red; } else { rtxtList.SelectionColor = Color.Black; }
                    rtxtList.AppendText(List[i].Substring(X1, 1) + (char)10);
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
                ErrMessage = exception.Message;
                ShowNetErr();
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
                ErrMessage = exception.Message;
                ShowNetErr();
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
                                    if (reader.Value != "") { MessageBox.Show(reader.Value, StatType, MessageBoxButtons.OK); }
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

        private void btnNearby_Click(object sender, EventArgs e)
        {
            if (txtMaxDist.Text != "")
            {
                DisableBtns();
                timSetStop.Enabled = true;
                Dist = txtMaxDist.Text;
                fmNearby Nb = new fmNearby();
                Nb.Show();
            }
            else { MessageBox.Show("The distance textbox cannot be blank!", "Error", MessageBoxButtons.OK); }
        }

        private void btnWebsite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://winnipegtransit.com/en/stops/" + StopNum);
        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            if (txtRoute.Text != "")
            {
                try
                {
                    DisableBtns();
                    RouteLook = txtRoute.Text;
                    fmRoute Rte = new fmRoute();
                    Rte.Show();
                }
                catch (System.Net.WebException exception)
            {
                ErrMessage = exception.Message;
                ShowNetErr();
            }
            }
            else { MessageBox.Show("The route textbox cannot be blank!", "Error", MessageBoxButtons.OK); }
        }

        private void btnBus_Click(object sender, EventArgs e)
        {
            if (txtBusLk.Text != "")
            {
                System.Diagnostics.Process.Start("https://m.winnipegtransit.com/onthego/bus/" + txtBusLk.Text);
            }
            else { MessageBox.Show("The bus textbox cannot be blank!", "Error", MessageBoxButtons.OK); }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WTLive V1.2.2 (2021-07-18)" + (char)10 + (char)10 + "This program is made by Taylor Woolston. It is not produced by, affiliated with or endorsed by Winnipeg Transit.", "About WTLive", MessageBoxButtons.OK);
            //MessageBox.Show("This program is not produced by, affiliated with or endorsed by Winnipeg Transit.", "About", MessageBoxButtons.OK);
        }

        private void timGoBtn_Tick(object sender, EventArgs e)
        {
            btnGo.Enabled = true;
            if (this.Text != "WTLive") { btnNearby.Enabled = true; }
            btnRoute.Enabled = true;
            btnOpenAdv.Enabled = true;
            btnFullScreen.Enabled = true;
            btnSearch.Enabled = true;

            timGoBtn.Enabled = false;
        }

        private void DisableBtns()
        {
            btnGo.Enabled = false;
            btnNearby.Enabled = false;
            btnRoute.Enabled = false;
            btnOpenAdv.Enabled = false;
            btnFullScreen.Enabled = false;
            btnSearch.Enabled = false;

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
            chkShowMins.Checked = true;
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

            this.Text = "WTLive";
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            StopNum = txtStopNum.Text;

            if (StopNum.Length == 0) { MessageBox.Show("The stop number is blank!", "Error", MessageBoxButtons.OK); }
            else if (StopNum.Length != 5) { MessageBox.Show("The stop number must be 5 digits long!", "Error", MessageBoxButtons.OK); }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                UpdateTime();

                rtxtList.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 80);
                rtxtList.Location = new Point(0, 80);

                lblStopName.Size = new Size(Screen.PrimaryScreen.Bounds.Width, 80);
                lblStopName.Visible = true;

                lblTime.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 235, 0);
                lblTime.Size = new Size(200, 68);
                lblTime.Visible = true;

                btnExitFullScr.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 48, 0);
                btnExitFullScr.Visible = true;
                btnExitFullScr.BringToFront();

                FontSize = 48;
                timUpdateTime.Enabled = true;
                GoPress();
            }
        }

        public void ExitFullScr()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Normal;
            rtxtList.Size = new Size(645, 406);
            rtxtList.Location = new Point(298, 3);
            FontSize = 16;
            lblStopName.Visible = false;
            lblTime.Visible = false;
            timUpdateTime.Enabled = false;
            btnExitFullScr.Visible = false;

            PrintResults();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DisableBtns();
            timSetStop.Enabled = true;
            Dist = txtMaxDist.Text;
            fmSearch Sch = new fmSearch();
            Sch.Show();
        }

        private void timSetStop_Tick(object sender, EventArgs e)
        {
            if (StopNum2 != LastStopNum2)
            {
                LastStopNum2 = StopNum2;
                txtStopNum.Text = StopNum2;
            }
         }

        private void btnExitFullScr_Click(object sender, EventArgs e)
        {
            ExitFullScr();
        }

        private void ShowNetErr()
        {
            if (ErrMessage.IndexOf("(404) Not Found") != -1)
            {
                MessageBox.Show("Stop Number Doesn't Exist!", "Error", MessageBoxButtons.OK);
                btnStop.Enabled = false;
                timAutoGet.Enabled = false;
                lblOnOff.Text = "Refresh Disabled";
            }
            else { MessageBox.Show(ErrMessage, "Error", MessageBoxButtons.OK); }
        }
    }
}