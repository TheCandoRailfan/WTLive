using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Transit
{
    public partial class fmSearch : Form
    {
        String[] StopList2 = new string[6000];

        public fmSearch()
        {
            InitializeComponent();
        }

        private void PrintItems()
        {
            int Num = 0;

            lbStopList.Items.Clear();
            for (int i = 1; i <= 5999; i++)
            {
                if (fmMain.StopList[i] != null && (fmMain.StopList[i].ToUpper().IndexOf(txtSearch.Text.ToUpper()) != -1 | txtSearch.Text == "")) { Num++; lbStopList.Items.Add(fmMain.StopList[i]); StopList2[Num] = fmMain.StopList[i]; }
            }
        }

        private void GetStops()
        {
            String URLString = "https://api.winnipegtransit.com/v3/stops?api-key=yxCT5Ca2Ep5AVLc0z6zz&lat=49.895496&lon=-97.138458&distance=30000&usage=long";
            int Num = 0;
            String X = "";

            if (fmMain.FirstSearch == 1)
            {
                XmlTextReader reader = new XmlTextReader(URLString);
                String LastName = "";
                String LastNameB = "";
                String LastNameUse = "";
                String Stop = "";
                String PrevStop = "";

                String X2 = "";
                int X1 = 0;

                //int Num = 0;

                //Num = 0;

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
                                X += X2 + " km)";
                            }
                            break;
                        }
                        case XmlNodeType.EndElement: //Display the end of the element.  
                        {
                            if (reader.Name == "stop")
                            {
                                // && Stop != PrevStop
                                Num += 1;
                                fmMain.StopList[Num] = X;
                                PrevStop = Stop; //}
                            }
                            break;
                        }
                    }
                }

                for (int i = 1; i <= 5999; i++)
                {
                    for (int i2 = 2; i2 <= 5999; i2++)
                    {
                        if (fmMain.StopList[i2] != null)
                        {
                            if (int.Parse(fmMain.StopList[i2].Substring(0, 5)) < int.Parse(fmMain.StopList[i2 - 1].Substring(0, 5)))
                            {
                                X = fmMain.StopList[i2 - 1];
                                fmMain.StopList[i2 - 1] = fmMain.StopList[i2];
                                fmMain.StopList[i2] = X;
                            }
                        }
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PrintItems();
        }

        private void lbStopList_DoubleClick(object sender, EventArgs e)
        {
            if (lbStopList.SelectedIndex >= 0)
            {
                fmMain.StopNum2 = StopList2[lbStopList.SelectedIndex + 1].Substring(0, 5);
                Close();
            }
        }

        private void timLoad_Tick(object sender, EventArgs e)
        {
            timLoad.Enabled = false;

            try
            {
                GetStops();
                PrintItems();
                label1.Text = "Stop to Search For. To Select Stop, Double Click on it.";
                fmMain.FirstSearch = 0;
            }
            catch (System.Net.WebException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK);
                fmMain.FirstSearch = 1;
                Close();
            }
        }
    }
}
