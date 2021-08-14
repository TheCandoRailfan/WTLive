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
using System.IO;

namespace Transit
{
    public partial class fmMain : Form
    {
        String StopNum; public static String StopNum2;
        String Start = "";
        String Route;
        String Search;
        String Run;
        String SearchRun;
        bool MinsETA;
        int[] SearchBus = new int[2];
        String BusType = ""; int BusTypeMatch = 0;
        String BusLength = ""; int BusLengthMatch = 0;
        String BusColour = ""; int BusColourMatch = 0;
        int FontSize = 16;
        public static int FirstSearch = 1;
        public static String[] StopList = System.IO.File.ReadAllLines(@"Stops\stops.txt");
        public static String[] RunList; int RunStopFound;

        public static int DarkMode = 0;

        String[] ToReplace = new string[100];
        String[] Replacement = new string[100];

        String ErrMessage = "";
        String ErrMessage2 = "";

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
        DateTime dt = DateTime.Now; int DayOfWeek;
        String[] List = new string[1001]; String[] ListCol = new string[1001]; String[] ListBCol = new string[1001];
        String Col = ""; String BCol = "";

        String[] RtList = new string[50]; int[] RtNumList = new int[50]; int NumRtLst = 0; String Temp; int TempNum;
        String[] ListColRtLst = new string[50]; String[] ListBColRtLst = new string[50];

        public static bool[] BusList = new bool[1000];
        public static bool[] BusListBkRack = new bool[1000];
        public static String[] BusListRunNum = new string[1000];

        public static bool[] BusList2 = new bool[1000];
        public static bool[] BusListBkRack2 = new bool[1000];
        public static String[] BusListRunNum2 = new string[1000];

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
            BusColour = cmbColour.Text;

            //btnNearby.Enabled = true;
            btnWebsite.Enabled = true;

            Cancel = rdoCancel.Checked;
            NoCancel = rdoNoCancel.Checked;
            Reverse = chkRev.Checked;
            Search = txtSearch.Text.ToUpper();
            MinsETA = chkShowMins.Checked;

            SearchRun = txtRun.Text;

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

            if (txtDate.Text == "")
            {
                dt = DateTime.Now;
            }
            else
            {
                dt = new DateTime(int.Parse(txtDate.Text.Substring(0,4)), int.Parse(txtDate.Text.Substring(5, 2)), int.Parse(txtDate.Text.Substring(8, 2)));
            }

            if ((dt.Month == 7 && dt.Day == 1))
            {
                DayOfWeek = 4;
            }
            else if (dt.DayOfWeek == System.DayOfWeek.Sunday | (dt.Month == 12 && dt.Day == 25) | (dt.Month == 12 && dt.Day == 26) | (dt.Month == 1 && dt.Day == 1))
            {
                DayOfWeek = 3;
            }
            else if (dt.DayOfWeek == System.DayOfWeek.Saturday)
            {
                DayOfWeek = 2;
            }
            else if (dt.DayOfWeek == System.DayOfWeek.Monday | dt.DayOfWeek == System.DayOfWeek.Tuesday | dt.DayOfWeek == System.DayOfWeek.Wednesday | dt.DayOfWeek == System.DayOfWeek.Thursday | dt.DayOfWeek == System.DayOfWeek.Friday)
            {
                DayOfWeek = 1;
            }

            try
            {
                GetList();
                GetFeatures();
                GetRoutes(0);

                double X1;

                if (txtInterval.Text != "")
                {
                    X1 = double.Parse(txtInterval.Text) * 1000;
                    if (X1 >= 15000)
                    {
                        timAutoGet.Interval = (Int32)X1;

                        X = Convert.ToString(60.0 / (X1 / 1000.0));
                        if (X.Length > 4) { X = X.Substring(0, 4); }

                        if (chkAuto.Checked == true && timAutoGet.Interval != 0) { timAutoGet.Enabled = true; lblOnOff.Text = "Refresh Enabled (" + Convert.ToString(X1 / 1000) + " Seconds, " + X + " Per Minute)"; btnStop.Enabled = true; }
                        if (chkAuto.Checked == false | timAutoGet.Interval == 0) { timAutoGet.Enabled = false; lblOnOff.Text = "Refresh Disabled"; btnStop.Enabled = false; }
                    }
                    else { timAutoGet.Enabled = false; lblOnOff.Text = "Refresh Disabled"; btnStop.Enabled = false; if (chkAuto.Checked == true) { MessageBox.Show("The refresh interval must be at least 15 seconds! Auto refresh will be disabled.", "Warning", MessageBoxButtons.OK); } }
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
            ToReplace[1] = "Downtown (City Hall)"; Replacement[1] = "City Hall";
            ToReplace[2] = "St. Vital Centre via River Road"; Replacement[2] = "St. Vital Centre";
            ToReplace[3] = "Centre Street via Bridgwater"; Replacement[3] = "Bridgwater Centre";
            ToReplace[4] = "Wolseley-Provencher via Provencher"; Replacement[4] = "Wolseley via Provencher";
            ToReplace[5] = "WalMart via McPhillips"; Replacement[5] = "Templeton via McPhillips";
            ToReplace[6] = "via Leila"; Replacement[6] = "Leila";
            ToReplace[7] = "Whyte Ridge via Scurfield"; Replacement[7] = "Whyte Ridge";
            ToReplace[8] = "Seel Station via Fort Garry Industrial Park"; Replacement[8] = "Seel Station";
            ToReplace[9] = "Kenaston via Fort Garry Industrial Park"; Replacement[9] = "Kenaston";
            ToReplace[10] = "Whyte Ridge via Chevrier"; Replacement[10] = "Whyte Ridge";
            ToReplace[11] = "Windermere via Pembina"; Replacement[11] = "Windermere";
            ToReplace[12] = "Beaumont station via Industrial Park"; Replacement[12] = "Beaumont Station";
            ToReplace[13] = "Kenaston Common via Industrial Park"; Replacement[13] = "Kenaston Common";
            ToReplace[14] = "Outlet Mall via Wilkes"; Replacement[14] = "Outlet Mall";
            ToReplace[15] = "Logan via Sherbrook"; Replacement[15] = "Logan";
            ToReplace[16] = "Beaumont Station via Stafford"; Replacement[16] = "Beaumont Station";
            ToReplace[17] = "Fort and Assiniboine via Maryland"; Replacement[17] = "Fort & Assiniboine";
            ToReplace[18] = "City Hall via Sherbrook"; Replacement[18] = "City Hall";
            ToReplace[19] = "Maples via Health Sciences Centre"; Replacement[19] = "Maples";
            ToReplace[20] = "U of Manitoba"; Replacement[20] = "University of Manitoba";
            ToReplace[21] = "Westdale via Kenaston"; Replacement[21] = "Westdale";
            ToReplace[22] = "Polo Park via Kenaston"; Replacement[22] = "Polo Park";
            ToReplace[23] = "Portage & Tylehurst via Kenaston"; Replacement[23] = "Portage & Tylehurst";
            ToReplace[24] = "Whyte Ridge via Kenaston Common"; Replacement[24] = "Whyte Ridge";
            ToReplace[25] = "Markham Station via Richmond West"; Replacement[25] = "Markham Station";
            ToReplace[26] = "University of Manitoba via Richmond West"; Replacement[26] = "University of Manitoba";
            ToReplace[27] = "University of Manitoba via Killarney"; Replacement[27] = "U of Manitoba via Killarney";
            ToReplace[28] = "University of Manitoba via Dalhousie"; Replacement[28] = "U of Manitoba via Dalhousie";
            ToReplace[29] = "University of Manitoba via Downtown"; Replacement[29] = "University of Manitoba";
            ToReplace[28] = "University of Manitoba via Dalhousie"; Replacement[28] = "U of Manitoba via Dalhousie";
            ToReplace[29] = "University of Manitoba via Downtown"; Replacement[29] = "University of Manitoba";
            ToReplace[30] = "Fort Garry Industrial Park via Lindenwoods East"; Replacement[30] = "Fort Garry Industrial";
            ToReplace[31] = "Seel Station via Lindenwoods East"; Replacement[31] = "Seel Station";
            ToReplace[32] = "Seel Station via Wildwood"; Replacement[32] = "Seel Station";
            ToReplace[33] = "Fort Garry Industrial Park via Wildwood"; Replacement[33] = "Fort Garry Industrial";
            ToReplace[34] = "Kenaston via Lindenwoods West"; Replacement[34] = "Kenaston";
            ToReplace[35] = "Beaumont Station via Lindenwoods West"; Replacement[35] = "Beaumont Station";
            ToReplace[36] = "St.Vital Centre via Meadowood"; Replacement[36] = "St. Vital Centre via Meadowood";
            ToReplace[37] = "St.Vital Centre"; Replacement[37] = "St. Vital Centre";
            ToReplace[38] = "Paterson Loop via Southdale"; Replacement[38] = "Windsor Park";
            ToReplace[39] = "Island Lakes via Southdale Centre"; Replacement[39] = "Island Lakes";
            ToReplace[40] = "Plaza Dr via St. Vital Centre"; Replacement[40] = "Plaza Drive";

            for (int i = 1; i <= 999; i++)
            {
                BusList[i] = false;
                BusListBkRack[i] = false;
                BusListRunNum[i] = "";
            }

            String StartB = Start;
            int ExtraChars = 0;

            if (StartB.Length == 10 | StartB.Length == 0) { StartB += DateTime.Now.ToString("HH:mm:ss"); }
            if (StartB.IndexOf("T") != -1) { ExtraChars = 11; } else { ExtraChars = 0; }

            //System.Console.WriteLine(StartB);

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
            String RunTime = "";
            String RouteNm = "";
            String RouteNmRun = "";
            String Bus = ", Bus 000";
            int BusNum = 0;
            String Bike = ", ---";
            String Cancelled = "";

            int RtDash;

            Count = 0;
            XmlTextReader reader = new XmlTextReader(URLString);

            if (File.Exists(@"Stops\" + StopNum + "-" + DayOfWeek + ".txt"))
            {
                RunList = File.ReadAllLines(@"Stops\" + StopNum + "-" + DayOfWeek + ".txt");
                RunStopFound = 1;
            }
            else
            {
                RunStopFound = 0;
            }

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
                            BusNum = 0;
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
                            BusNum = int.Parse(reader.Value);
                        }
                        else if (LastName == "keyRt")
                        {
                            RtDash = reader.Value.IndexOf("-");
                            if (reader.Value.Substring(0, RtDash) == "101" | reader.Value.Substring(0, RtDash) == "102" | reader.Value.Substring(0, RtDash) == "110")
                            {
                                RouteNm = reader.Value.Substring(0, RtDash) + " On-Request";
                            }
                            else
                            {
                                RouteNm = reader.Value.Substring(0, RtDash);
                            }
                            RouteNmRun = reader.Value.Substring(0, RtDash);
                        }
                        else if (LastName == "keySch")
                        {
                            LastNameB = "departure";
                            LastName = "scheduled";
                            SchTime = reader.Value.Substring(reader.Value.Length - 8, 8);
                            RunTime = SchTime;
                            if (RunTime.Substring(0,2) == "00")
                            {
                                RunTime = "24" + RunTime.Substring(2);
                            }
                            else if (RunTime.Substring(0, 2) == "01")
                            {
                                RunTime = "25" + RunTime.Substring(2);
                            }
                            else if (RunTime.Substring(0, 2) == "02")
                            {
                                RunTime = "26" + RunTime.Substring(2);
                            }
                        }
                        else if (LastName == "keyTime")
                        {
                            Time = reader.Value.Substring(reader.Value.Length - 8, 8);
                        }
                        else if (LastName == "keyDest")
                        {
                            if (RouteNm != "101 DART" && RouteNm != "102 DART" && RouteNm != "110 DART" & RouteNm != "101 On-Request" && RouteNm != "102 On-Request" && RouteNm != "110 On-Request")
                            {
                                X1 = 0;
                                for (int i = 1; i <= 99; i++)
                                {
                                    if (reader.Value == ToReplace[i])
                                    {
                                        RouteNm += " " + Replacement[i];
                                        X1 = 1;
                                        break;
                                    }
                                }
                                if (X1 == 0) { RouteNm += " " + reader.Value; }
                            }
                        }
                        else if (LastName == "keyStop")
                        {
                            StopName = StopNum + " " + reader.Value;

                            foreach (string line in StopList)
                            {
                                if (line.Substring(0,5) == StopNum) { StopName = line; break; }
                            }

                            this.Text = StopName + " - WTLive";
                            lblStopName.Text = StopName;
                        }
                        else if (LastName == "bike-rack")
                        {
                            if (reader.Value == "true") { Bike = ", 🚲"; } else { Bike = ", 🚳"; }
                            BusListBkRack[BusNum] = bool.Parse(reader.Value);
                            BusListBkRack2[BusNum] = bool.Parse(reader.Value);
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
                            else if (BusType == "D40LF (Regular)")
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
                                if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 480 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 499) { BusTypeMatch = 1; }
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
                                if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 480 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 499) { BusTypeMatch = 1; }
                                if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 831 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 888) { BusTypeMatch = 1; }
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
                                if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 480 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 499) { BusLengthMatch = 1; }
                                if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 971 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 990) { BusLengthMatch = 1; }
                            }

                            BusColourMatch = 0;
                            if (BusColour == "Any") { BusColourMatch = 1; }
                            else if (BusColour == "Orange")
                            {
                                BusColourMatch = 1;
                                if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) == 369) { BusColourMatch = 0; }
                                if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 440 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 499) { BusColourMatch = 0; }
                            }
                            else if (BusColour == "White")
                            {
                                if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) == 369) { BusColourMatch = 1; }
                                if (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= 440 && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= 499) { BusColourMatch = 1; }
                            }

                            Run = "";
                            if (RunStopFound == 1)
                            {
                                //if (BusListRunNum[BusNum] != "" && BusNum != 0)
                                //{
                                //    Run = BusListRunNum[BusNum];
                                //}
                                //else
                                //{
                                    foreach (string line in RunList)
                                    {
                                        if (line.Contains(RunTime) && line.Contains("," + RouteNmRun + ",")) { X1 = line.IndexOf(","); Run = line.Substring(0, X1); BusListRunNum[BusNum] = Run; BusListRunNum2[BusNum] = Run; break; }
                                    }
                                //}
                            }

                            //Console.WriteLine(Bus);
                            if ((Search == "" | RouteNm.ToUpper().IndexOf(Search) != -1) && (SearchRun == "" | Run == SearchRun) && (int.Parse(Bus.Substring(Bus.Length - 3, 3)) >= SearchBus[0] && int.Parse(Bus.Substring(Bus.Length - 3, 3)) <= SearchBus[1]) && (BikeType == "" | Bike.IndexOf(BikeType) != -1) && BusTypeMatch == 1 && BusLengthMatch == 1 && BusColourMatch == 1 && (Cancelled == "" | NoCancel == false) && (Cancelled == " - ❌❌❌" | Cancel == false))
                            {
                                if (double.Parse(StartB.Substring(0 + ExtraChars, 2)) + (double.Parse(StartB.Substring(3 + ExtraChars, 2)) / 60) >= 2.8334 | Bike != ", ---")
                                {
                                    if (Bus == ", Bus 000") { Bus = ", Bus -----"; }
                                    Count += 1;

                                    if (Bus != ", Bus -----") { BusList[BusNum] = true; BusList2[BusNum] = true; }

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

                                    if (Run != "") { List[Count] += " (" + Run + ")"; }
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

                if (List[i].IndexOf(" - ❌❌❌") != -1) { rtxtList.SelectionColor = Color.Red; rtxtList.SelectionFont = new Font("Microsoft Sans Serif", FontSize, FontStyle.Strikeout | FontStyle.Bold); } else { rtxtList.SelectionColor = Color.FromArgb(int.Parse(ListCol[i].Substring(1, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(ListCol[i].Substring(3, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(ListCol[i].Substring(5, 2), System.Globalization.NumberStyles.HexNumber)); rtxtList.SelectionFont = new Font("Microsoft Sans Serif", FontSize, FontStyle.Bold); }

                dt = DateTime.Now;
                if (List[i].Substring(X1, 3) == "24 " && (DayOfWeek == 3 | List[i].IndexOf("Polo Park") != -1 | List[i].IndexOf("Portage & Tylehurst") != -1 | StopNum == "10881"))
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
                if (DarkMode == 0) { rtxtList.SelectionBackColor = Color.White; } else { rtxtList.SelectionBackColor = Color.DarkGray; }

                X2 = List[i].IndexOf(" (");
                if (X2 == -1)
                {
                    if (List[i].IndexOf(" - ❌❌❌") != -1)
                    {
                        rtxtList.SelectionColor = Color.Red;
                        rtxtList.SelectionFont = new Font("Microsoft Sans Serif", FontSize, FontStyle.Strikeout);
                        rtxtList.AppendText(List[i].Substring(X1, List[i].IndexOf(" - ❌❌❌") - X1));
                    }
                    else
                    {
                        rtxtList.SelectionFont = new Font("Microsoft Sans Serif", FontSize, FontStyle.Regular);
                        rtxtList.AppendText(List[i].Substring(X1));
                    }
                }
                else
                {
                    if (List[i].IndexOf(" - ❌❌❌") != -1) { rtxtList.SelectionColor = Color.Red; rtxtList.SelectionFont = new Font("Microsoft Sans Serif", FontSize, FontStyle.Strikeout); } else { rtxtList.SelectionFont = new Font("Microsoft Sans Serif", FontSize, FontStyle.Regular); }

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
                    rtxtList.AppendText(List[i].Substring(X1, 1));
                }

                X1 = List[i].IndexOf(")");
                if (X1 != -1)
                {
                    X2 = List[i].IndexOf("(", X1);
                    if (X2 != -1)
                    {
                        rtxtList.AppendText(List[i].Substring(X2 - 1));
                    }
                }
                rtxtList.AppendText((char)10 + "");
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

            for (int i = 1; i <= 999; i++)
            {
                BusList[i] = false;
                BusListBkRack[i] = false;

                BusList2[i] = false;
                BusListBkRack2[i] = false;
            }

            cmbBusType.SelectedIndex = 0;
            cmbBusLength.SelectedIndex = 0;
            cmbColour.SelectedIndex = 0;
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
                this.Size = new Size(960, 581);
            } 
            else 
            {
                this.Size = new Size(960, 601);
            }
        }

        private void btnOpenAdv_Click(object sender, EventArgs e)
        {
            DisableBtns();
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

        private void GetRoutes(int PrtOnly)
        {
            rtxtRtList.Text = "";
            String URLString = "https://api.winnipegtransit.com/v3/routes?api-key=yxCT5Ca2Ep5AVLc0z6zz&stop=" + StopNum + "&usage=long";
            XmlTextReader reader = new XmlTextReader(URLString);
            String LastName = "";
            
            String TempCol; String TempBCol; int X1;

            if (PrtOnly == 0)
            {
                NumRtLst = 0;
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
                                if (LastName == "number")
                                {
                                    NumRtLst += 1;
                                    if (reader.Value == "BLUE") { RtNumList[NumRtLst] = 0; RtList[NumRtLst] = "BLUE "; } else { RtNumList[NumRtLst] = Int32.Parse(reader.Value); }
                                }
                                else if (LastName == "name")
                                {
                                    //NumRtLst += 1;
                                    RtList[NumRtLst] = reader.Value.Substring(6);
                                    if (RtNumList[NumRtLst] == 101) { RtList[NumRtLst] = "101 St. Amant On-Request"; }
                                    else if (RtNumList[NumRtLst] == 102) { RtList[NumRtLst] = "102 Southeast On-Request"; }
                                    else if (RtNumList[NumRtLst] == 110) { RtList[NumRtLst] = "110 St. Boniface On-Request"; }
                                }
                                else if (LastName == "color")
                                {
                                    ListColRtLst[NumRtLst] = reader.Value;
                                }
                                else if (LastName == "background-color")
                                {
                                    ListBColRtLst[NumRtLst] = reader.Value;
                                }
                                break;
                            }
                        case XmlNodeType.EndElement: //Display the end of the element.  
                            {
                                break;
                            }
                    }
                }

                for (int i = 1; i <= NumRtLst; i++)
                {
                    for (int i2 = 2; i2 <= NumRtLst; i2++)
                    {
                        if (RtNumList[i2 - 1] > RtNumList[i2])
                        {
                            Temp = RtList[i2 - 1];
                            RtList[i2 - 1] = RtList[i2];
                            RtList[i2] = Temp;

                            TempNum = RtNumList[i2 - 1];
                            RtNumList[i2 - 1] = RtNumList[i2];
                            RtNumList[i2] = TempNum;

                            TempCol = ListColRtLst[i2 - 1];
                            ListColRtLst[i2 - 1] = ListColRtLst[i2];
                            ListColRtLst[i2] = TempCol;

                            TempBCol = ListBColRtLst[i2 - 1];
                            ListBColRtLst[i2 - 1] = ListBColRtLst[i2];
                            ListBColRtLst[i2] = TempBCol;
                        }
                    }
                }
            }

            for (int i = 1; i <= NumRtLst; i++)
            {
                //if (RtNumList[i] == 0) { }
                rtxtRtList.SelectionBackColor = Color.FromArgb(int.Parse(ListBColRtLst[i].Substring(1, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(ListBColRtLst[i].Substring(3, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(ListBColRtLst[i].Substring(5, 2), System.Globalization.NumberStyles.HexNumber));
                rtxtRtList.SelectionColor = Color.FromArgb(int.Parse(ListColRtLst[i].Substring(1, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(ListColRtLst[i].Substring(3, 2), System.Globalization.NumberStyles.HexNumber), int.Parse(ListColRtLst[i].Substring(5, 2), System.Globalization.NumberStyles.HexNumber));
                rtxtRtList.SelectionFont = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);

                X1 = RtList[i].IndexOf(" ", 0);
                rtxtRtList.AppendText(" " + RtList[i].Substring(0,X1 + 1));

                if (DarkMode == 0) { rtxtRtList.SelectionBackColor = Color.FromArgb(255, 255, 255); } else if (DarkMode == 1) { rtxtRtList.SelectionBackColor = Color.DarkGray; }
                rtxtRtList.SelectionColor = Color.FromArgb(0, 0, 0);
                rtxtRtList.SelectionFont = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                rtxtRtList.AppendText(RtList[i].Substring(X1));
                if (i < NumRtLst) { rtxtRtList.AppendText((char)10 + ""); }
            }
        }

        private void btnNearby_Click(object sender, EventArgs e)
        {
            if (txtMaxDist.Text == "")
            {
                MessageBox.Show("The distance textbox cannot be blank!", "Error", MessageBoxButtons.OK);
            }
            else if (Convert.ToDouble(txtMaxDist.Text) > 3)
            {
                MessageBox.Show("The distance must be no more than 3 km!", "Error", MessageBoxButtons.OK);
            }
            else 
            {
                DisableBtns();
                timSetStop.Enabled = true;
                Dist = txtMaxDist.Text;
                fmNearby Nb = new fmNearby();
                Nb.Show();
            }
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
            MessageBox.Show("WTLive V1.5 (2021-08-14)" + (char)10 + (char)10 + "This program is made by Taylor Woolston. It is not produced by, affiliated with or endorsed by Winnipeg Transit.", "About WTLive", MessageBoxButtons.OK);
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
            cmbColour.SelectedIndex = 0;
            txtSearch.Text = "";
            chkShowMins.Checked = true;
            chkAuto.Checked = false;
            chkRev.Checked = false;
            txtInterval.Text = "30";
            txtRun.Text = "";

            timAutoGet.Enabled = false;
            lblOnOff.Text = "Refresh Disabled";
            btnStop.Enabled = false;

            rdoBikeorNoBike.Checked = true;
            rdoEitherCancel.Checked = true;

            txtBusLk.Text = "";
            txtRoute.Text = "10";
            txtMaxDist.Text = "2";

            rtxtList.Text = "";
            rtxtRtList.Text = "";
            lbFeatures.Items.Clear();
            lblStopName.Text = "Stop Name";

            btnNearby.Enabled = false;
            btnWebsite.Enabled = false;
            btnFullScreen.Enabled = false;

            for (int i = 1; i <= 999; i++)
            {
                BusList[i] = false;
                BusListBkRack[i] = false;

                BusList2[i] = false;
                BusListBkRack2[i] = false;
            }

            this.Text = "WTLive";
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            StopNum = txtStopNum.Text;

            if (StopNum.Length == 0) { MessageBox.Show("The stop number is blank!", "Error", MessageBoxButtons.OK); }
            else if (StopNum.Length != 5) { MessageBox.Show("The stop number must be 5 digits long!", "Error", MessageBoxButtons.OK); }
            else
            {
                FontSize = (int)(Screen.PrimaryScreen.Bounds.Width / 40);

                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                UpdateTime();

                rtxtList.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Width / 24));
                rtxtList.Location = new Point(0, Screen.PrimaryScreen.Bounds.Width / 24);

                lblStopName.Font = new Font("Calibri", FontSize, FontStyle.Bold);
                lblStopName.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Width / 24);
                lblStopName.Visible = true;

                lblTime.Font = new Font("Calibri", FontSize, FontStyle.Bold);
                lblTime.Location = new Point(Screen.PrimaryScreen.Bounds.Width - (int)(Screen.PrimaryScreen.Bounds.Width / 8.1702127659574), 0);
                lblTime.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width / 9.6), Screen.PrimaryScreen.Bounds.Width / 24);
                lblTime.Visible = true;
                lblTime.BringToFront();

                btnExitFullScr.Location = new Point(Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 40), 0);
                btnExitFullScr.Visible = true;
                btnExitFullScr.Size = new Size(Screen.PrimaryScreen.Bounds.Width / 40, (Screen.PrimaryScreen.Bounds.Width / 24) + 1);
                btnExitFullScr.Font = new Font("Microsoft Sans Serif", Screen.PrimaryScreen.Bounds.Width / 80, FontStyle.Bold);
                btnExitFullScr.BringToFront();

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
            timSetStop.Enabled = true;
            Dist = txtMaxDist.Text;
            fmSearch Sch = new fmSearch();
            Sch.Show();
        }

        private void timSetStop_Tick(object sender, EventArgs e)
        {
            if (StopNum2 != txtStopNum.Text && StopNum2 != "")
            {
                //LastStopNum2 = StopNum2;
                txtStopNum.Text = StopNum2;
                StopNum2 = "";
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
                //MessageBox.Show("Stop Number Doesn't Exist!", "Error", MessageBoxButtons.OK);
                ErrMessage2 = (char)10 + "This may be caused by a bad stop number.";
            }
            else { ErrMessage2 = "";  }

            //btnStop.Enabled = false;
            //timAutoGet.Enabled = false;
            //lblOnOff.Text = "Refresh Disabled";

            MessageBox.Show(ErrMessage + ErrMessage2, "Error", MessageBoxButtons.OK);
        }

        private void SetLightMode()
        {
            this.BackColor = Color.WhiteSmoke;
            grpBikeRack.BackColor = Color.WhiteSmoke;
            grpCancelled.BackColor = Color.WhiteSmoke;

            lblStop.ForeColor = Color.Black;
            lblStopNum.ForeColor = Color.Black;
            lblStart.ForeColor = Color.Black;
            lblRoutes.ForeColor = Color.Black;
            lblBus.ForeColor = Color.Black;
            lblOther.ForeColor = Color.Black;
            lblRtList.ForeColor = Color.Black;
            lblStopFeat.ForeColor = Color.Black;

            lblBusRange.ForeColor = Color.Black;
            lblBusType.ForeColor = Color.Black;
            lblBusLen.ForeColor = Color.Black;
            lblColour.ForeColor = Color.Black;
            lblRun.ForeColor = Color.Black;
            lblBusTo.ForeColor = Color.Black;
            lblDestCont.ForeColor = Color.Black;
            chkShowMins.ForeColor = Color.Black;
            chkAuto.ForeColor = Color.Black;

            lblRefresh.ForeColor = Color.Black;
            lblOnOff.ForeColor = Color.Black;

            grpBikeRack.ForeColor = Color.Black;
            rdoBike.ForeColor = Color.Black;
            rdoNoBike.ForeColor = Color.Black;
            rdoBikeorNoBike.ForeColor = Color.Black;

            grpCancelled.ForeColor = Color.Black;
            rdoCancel.ForeColor = Color.Black;
            rdoNoCancel.ForeColor = Color.Black;
            rdoEitherCancel.ForeColor = Color.Black;

            rtxtList.BackColor = Color.White;
            rtxtRtList.BackColor = Color.White;
            lbFeatures.BackColor = Color.White;            

            txtStopNum.BackColor = Color.White;
            txtStart.BackColor = Color.White;
            txtDate.BackColor = Color.White;
            txtRte.BackColor = Color.White;
            txtBus.BackColor = Color.White;
            txtBus2.BackColor = Color.White;
            txtRun.BackColor = Color.White;
            txtSearch.BackColor = Color.White;
            txtETAMax.BackColor = Color.White;
            txtInterval.BackColor = Color.White;
            txtBusLk.BackColor = Color.White;
            txtRoute.BackColor = Color.White;
            txtMaxDist.BackColor = Color.White;

            lblOTGBus.ForeColor = Color.Black;
            lblRtDest.ForeColor = Color.Black;
            lblKm.ForeColor = Color.Black;

            PrintResults();
            GetRoutes(1);
            btnModeChange.Text = "Dark Mode";
        }

        private void SetDarkMode()
        {
            this.BackColor = Color.Black;
            grpBikeRack.BackColor = Color.Black;
            grpCancelled.BackColor = Color.Black;

            lblStop.ForeColor = Color.DarkGray;
            lblStopNum.ForeColor = Color.DarkGray;
            lblStart.ForeColor = Color.DarkGray;
            lblRoutes.ForeColor = Color.DarkGray;
            lblBus.ForeColor = Color.DarkGray;
            lblOther.ForeColor = Color.DarkGray;
            lblRtList.ForeColor = Color.DarkGray;
            lblStopFeat.ForeColor = Color.DarkGray;

            lblBusRange.ForeColor = Color.DarkGray;
            lblBusType.ForeColor = Color.DarkGray;
            lblBusLen.ForeColor = Color.DarkGray;
            lblColour.ForeColor = Color.DarkGray;
            lblRun.ForeColor = Color.DarkGray;
            lblBusTo.ForeColor = Color.DarkGray;
            lblDestCont.ForeColor = Color.DarkGray;
            chkShowMins.ForeColor = Color.DarkGray;
            chkAuto.ForeColor = Color.DarkGray;

            lblRefresh.ForeColor = Color.DarkGray;
            lblOnOff.ForeColor = Color.DarkGray;

            grpBikeRack.ForeColor = Color.DarkGray;
            rdoBike.ForeColor = Color.DarkGray;
            rdoNoBike.ForeColor = Color.DarkGray;
            rdoBikeorNoBike.ForeColor = Color.DarkGray;

            grpCancelled.ForeColor = Color.DarkGray;
            rdoCancel.ForeColor = Color.DarkGray;
            rdoNoCancel.ForeColor = Color.DarkGray;
            rdoEitherCancel.ForeColor = Color.DarkGray;

            rtxtList.BackColor = Color.DarkGray;
            rtxtRtList.BackColor = Color.DarkGray;
            lbFeatures.BackColor = Color.DarkGray;

            txtStopNum.BackColor = Color.DarkGray;
            txtStart.BackColor = Color.DarkGray;
            txtDate.BackColor = Color.DarkGray;
            txtRte.BackColor = Color.DarkGray;
            txtBus.BackColor = Color.DarkGray;
            txtBus2.BackColor = Color.DarkGray;
            txtRun.BackColor = Color.DarkGray;
            txtSearch.BackColor = Color.DarkGray;
            txtETAMax.BackColor = Color.DarkGray;
            txtInterval.BackColor = Color.DarkGray;
            txtBusLk.BackColor = Color.DarkGray;
            txtRoute.BackColor = Color.DarkGray;
            txtMaxDist.BackColor = Color.DarkGray;

            lblOTGBus.ForeColor = Color.DarkGray;
            lblRtDest.ForeColor = Color.DarkGray;
            lblKm.ForeColor = Color.DarkGray;

            PrintResults();
            GetRoutes(1);
            btnModeChange.Text = "Light Mode";
        }

        private void btnModeChange_Click(object sender, EventArgs e)
        {
            if (DarkMode == 0)
            {
                DarkMode = 1;
                SetDarkMode();
            }
            else
            {
                DarkMode = 0;
                SetLightMode();
            }
        }

        private void btnOtherInfo_Click(object sender, EventArgs e)
        {
            fmOtherInfo Other = new fmOtherInfo();
            Other.Show();
        }
    }
}