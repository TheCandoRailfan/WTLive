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
        }
        public void GetList()
        {
            //lbList.Items.Clear();
            //lbList.Items.Add("Loading");

            String StartB = Start;

            if (StartB.Length == 11 | StartB.Length == 0) { StartB += DateTime.Now.ToString("HH:mm:ss"); }

            String URLString = "https://api.winnipegtransit.com/v3/stops/" + StopNum + "/schedule?api-key=yxCT5Ca2Ep5AVLc0z6zz&start=" + StartB + "&end=&route=" + Route + "&usage=long";
            String LastName = "";
            String LastNameB = "";


            String[] List = new string[701];
            double[] ListTime = new double[701];
            double[] ListSchTime = new double[701];
            String Temp = "";
            double TempTime = 0;
            int Count = 0;
            int TimeSec = (DateTime.Now.Hour * 3600) + (DateTime.Now.Minute * 60) + DateTime.Now.Second;

            if (TimeSec < 14400) { TimeSec += 86400;  }

            String SchTime = "";
            String Time = "";
            String RouteNm = "";
            String Bus = ", Bus 000";
            String Bike = ", ---";
            String Cancelled = "";

            int RtDash;

            XmlTextReader reader = new XmlTextReader(URLString);

            //int Num = 0;

            //lblMessage.Text = URLString;

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
                            //MessageBox.Show(LastName, "Service Alert", MessageBoxButtons.OK);
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
                        //Console.WriteLine(reader.Name);
                        //Console.WriteLine(reader.Value);
                        //Console.WriteLine(">");
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
                                RouteNm = "";
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
                            //SchTime = SchTime.Substring(0, 5);
                            //MessageBox.Show(LastName, "Service Alert", MessageBoxButtons.OK);
                        }
                        else if (LastName == "keyTime")
                        {
                            //Num += 1;
                            Time = reader.Value.Substring(reader.Value.Length - 8, 8);
                            //Console.WriteLine("Time: " + reader.Value);
                        }
                        else if (LastName == "keyDest")
                        {
                            RouteNm += " " + reader.Value;
                            //Console.WriteLine("Time: " + reader.Value);
                        }
                        else if (LastName == "keyStop")
                        {
                            StopName = StopNum + " " + reader.Value;
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
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.  
                                                 //Console.WriteLine(">");
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


                                    ListSchTime[Count] = (Double.Parse(SchTime.Substring(0, 2)) * 3600) + (Double.Parse(SchTime.Substring(3, 2)) * 60) + Double.Parse(SchTime.Substring(6, 2));
                                    ListTime[Count] = (Double.Parse(Time.Substring(0, 2)) * 3600) + (Double.Parse(Time.Substring(3, 2)) * 60) + Double.Parse(Time.Substring(6, 2));

                                    if (ListTime[Count] < 14400) { ListTime[Count] += 86400; }
                                    if (ListSchTime[Count] < 14400) { ListSchTime[Count] += 86400; }

                                    if (MinsETA == false) { List[Count] = Time.Substring(0, 5); }
                                    else { List[Count] = Math.Round((ListTime[Count] - TimeSec) / 60).ToString() + " Mins"; }

                                    List[Count] += Bus + Bike + " - " + RouteNm + Cancelled;

                                    if (ListTime[Count] - ListSchTime[Count] >= 60) { List[Count] += " (" + Math.Round((ListTime[Count] - ListSchTime[Count]) / 60).ToString() + "m L, " + SchTime.Substring(0, 5) + ")"; }
                                    if (ListSchTime[Count] - ListTime[Count] >= 60) { List[Count] += " (" + Math.Round((ListSchTime[Count] - ListTime[Count]) / 60).ToString() + "m E, " + SchTime.Substring(0, 5) + ")"; }

                                    //Console.WriteLine(ListTime[Count]);
                                    //lbList.Items.Add(Time + Bus + Bike + " - " + RouteNm );
                                }
                            }
                            Bus = ", Bus 000";
                            Bike = ", ---";
                        }
                        break;
                }

            }
            //Console.WriteLine(list[1]);
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
                    }
                }
            }


            lbList.Items.Clear();
            for (int i = 1; i <= Count; i++)
            {
                lbList.Items.Add(List[i]);
            }
        }

        private void timAutoGet_Tick(object sender, EventArgs e)
        {
            GetList();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timAutoGet.Enabled = false;
            lblOnOff.Text = "Refresh Disabled";
            btnStop.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckStat();
            cmbBusType.SelectedIndex = 0;
            cmbBusLength.SelectedIndex = 0;
        }

        private void timCheckStat_Tick(object sender, EventArgs e)
        {
            CheckStat();
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
                                    MessageBox.Show(reader.Value + (char)10 + "(" + DateTime.Now.ToString("HH:mm:ss") + ")", StatType, MessageBoxButtons.OK);
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
            MessageBox.Show("This program is made by Taylor Woolston. It is not produced by, affiliated with or endorsed by Winnipeg Transit.", "About", MessageBoxButtons.OK);
        }

        private void timGoBtn_Tick(object sender, EventArgs e)
        {
            btnGo.Enabled = true;
            if (lblStopName.Text != "Stop Name") { btnNearby.Enabled = true; }
            btnRoute.Enabled = true;
            btnOpenAdv.Enabled = true;

            timGoBtn.Enabled = false;
        }

        private void DisableBtns()
        {
            btnGo.Enabled = false;
            btnNearby.Enabled = false;
            btnRoute.Enabled = false;
            btnOpenAdv.Enabled = false;

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

            lbList.Items.Clear();
            lbFeatures.Items.Clear();
            lblStopName.Text = "Stop Name";

            btnNearby.Enabled = false;
            btnWebsite.Enabled = false;
        }
    }
}