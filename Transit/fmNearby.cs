using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Transit
{
    public partial class fmNearby : Form
    {
        //String[] List = new string[150];
        String[] StopList = new string[6000];
        int[] RouteGot = new int[700];
        int Dup = 0;

        public fmNearby()
        {
            InitializeComponent();
        }

        private void fmNearby_Load(object sender, EventArgs e)
        {
            GetNearby();
        }

        private void GetNearby()
        {
            int Num = 0;
            String URLString = "https://api.winnipegtransit.com/v3/stops?api-key=yxCT5Ca2Ep5AVLc0z6zz&lat=" + fmMain.XY[0] + "&lon=" + fmMain.XY[1] + "&distance=" + double.Parse(fmMain.Dist) * 1000 + "&walking=true&usage=long";
            XmlTextReader reader = new XmlTextReader(URLString);
            String LastName = "";
            String LastNameB = "";
            String LastNameUse = "";
            String Stop = "";
            String PrevStop = "";
            String StopNum = fmMain.StopName.Substring(0,5);

            String X = "";
            String X2 = "";
            int X1 = 0;

            Dup = 0;

            //int Num = 0;

            //Num = 0;

            lblTitle.Text = "Stops " + fmMain.Dist + " km walking distance of";
            lblStop.Text = fmMain.StopName;

            lbNBList.Items.Clear();
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        {
                            if (LastName == "stop" && reader.Name == "key")
                            {
                                LastNameUse = "keyStop";
                            }
                            else if (LastNameB == "stop" && LastName == "key" && reader.Name == "name")
                            {
                                LastNameUse = "keyStopName";
                            }
                            else
                            {
                                LastNameUse = reader.Name;
                            }
                            LastNameB = LastName;
                            LastName = reader.Name;
                            //Console.WriteLine("TEST");

                            break;
                        }
                    case XmlNodeType.Text: //Display the text in each element.
                        {
                            if (LastNameUse == "keyStop")
                            {
                                X = reader.Value;
                            }
                            else if (LastNameUse == "keyStopName")
                            {
                                X += " " + reader.Value;
                                X1 = reader.Value.IndexOf(" ");

                                Stop = reader.Value.Substring(X1);
                            }
                            else if (LastNameUse == "walking")
                            {
                                X1 = reader.Value.IndexOf(".");
                                if (X1 < 0) { X1 = reader.Value.Length; }

                                X += " (";

                                X2 = reader.Value.Substring(0, X1);
                                X2 = "" + double.Parse(X2) / 1000;

                                if (X2.Length < 5) { X2 += "0"; }
                                X += X2 +  " km)";
                            }
                            break;
                        }
                    case XmlNodeType.EndElement: //Display the end of the element.  
                        {
                            //CheckDup();
                            if (reader.Name == "stop")
                            {
                                // && Stop != PrevStop
                                Num++;
                                if (X.IndexOf(fmMain.StopName) == -1 && Dup == 0) { lbNBList.Items.Add(X); StopList[Num] = X; Dup = 0; PrevStop = Stop; }
                            }
                            break;
                        }
                }
            }
        }

        private void CheckDup()
        {
            String URLString = "https://api.winnipegtransit.com/v3/service-advisories?api-key=yxCT5Ca2Ep5AVLc0z6zz&usage=long&max-age=60";
            XmlTextReader reader = new XmlTextReader(URLString);
            String LastName = "";
            String X = "";
            int X1 = 0;

            //int Num = 0;
            Dup = 0;
            //Num = 0;

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
                            if (LastName == "badge-label")
                            {
                                X = reader.Value;

                                if (X == "B") { X1 = 600; } else { X1 = int.Parse(X); }

                                if (RouteGot[X1] == 1)
                                {
                                    Dup = 1;
                                }
                                RouteGot[X1] = 1;
                            }
                            break;
                        }
                    case XmlNodeType.EndElement: //Display the end of the element.  
                        {
                            break;
                        }
                }
                if (Dup == 1) { break; }
            }
        }

        private void lbNBList_DoubleClick(object sender, EventArgs e)
        {
            if (lbNBList.SelectedIndex >= 0)
            {
                fmMain.StopNum2 = StopList[lbNBList.SelectedIndex + 2].Substring(0, 5);
                Close();
            }
        }
    }
}
