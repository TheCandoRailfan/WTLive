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
    public partial class fmRoute : Form
    {
        string[] List = new string[20];
        string[] List2 = new string[20];
        int Blank = 0;
        int RouteDarkMode;

        public fmRoute()
        {
            InitializeComponent();
        }

        private void fmRoute_Load(object sender, EventArgs e)
        {
            if (fmMain.DarkMode == 1)
            {
                SetDarkMode();
            }
            GetInfo();
        }

        private void GetInfo()
        {
            string URLString = "https://api.winnipegtransit.com/v3/routes/" + fmMain.RouteLook.ToUpper() + "?api-key=yxCT5Ca2Ep5AVLc0z6zz&usage=long";
            XmlTextReader reader = new XmlTextReader(URLString);
            string LastName = "";
            string LastNameB = "";
            string X = "";

            int Num = 0;
            int X1 = 0;
            Blank = 0; 

            Num = 0;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        {
                            LastNameB = LastName;
                            LastName = reader.Name;

                            if (LastName == "variant")
                            {
                                Num++;
                                while (reader.MoveToNextAttribute()) // Read the attributes.
                                    List[Num] = reader.Value;
                                //Console.WriteLine(List[Num]);
                            }
                            break;
                        }
                    case XmlNodeType.Text: //Display the text in each element.
                        {
                            if (LastName == "name")
                            {
                                lblRoute.Text = reader.Value;
                            }
                            else if (LastName == "number")
                            {
                                lblRoute.Text = "Route " + reader.Value;
                            }                          
                            break;
                        }
                    case XmlNodeType.EndElement: //Display the end of the element.  
                        {
                            break;
                        }
                }
            }
            for (int i = 1; i <= Num; i++)
            {
                List2[i] = "";
                LookUpVariants(List[i], i);
            }

            for (int i = 1; i <= Num; i++)
            {
                for (int i2 = 2; i2 <= Num; i2++)
                {
                    if (List2[i2 - 1].IndexOf("Inbound") != -1 && List2[i2].IndexOf("Outbound") != -1)
                    {
                        X = List2[i2 - 1];
                        List2[i2 - 1] = List2[i2];
                        List2[i2] = X;
                    }
                }
            }

            for (int i = 1; i <= Num; i++)
            {
                if (i > 1) { if(List2[i - 1].IndexOf("Outbound") != -1 && List2[i].IndexOf("Inbound") != -1) { rtxtVariants.Text += (char)10; Blank = i; } }
                X1 = List2[i].IndexOf(" - Outbound");
                if (X1 == -1) { X1 = List2[i].IndexOf(" - Inbound"); }

                //lbVariants.Items.Add(List2[i].Substring(0,X1));
                rtxtVariants.Text += List2[i].Substring(0, X1) + (char) 10;
            }
            //lbVariants.SelectedIndex = 0;
        }

        private void LookUpVariants(String LUV1, int i)
        {
            String URLString = "https://api.winnipegtransit.com/v3/" + LUV1 + "?api-key=yxCT5Ca2Ep5AVLc0z6zz&usage=long";
           
            XmlTextReader reader = new XmlTextReader(URLString);
            String LastName = "";
            String LastNameB = "";
            //String X = "";
            //String[] List = new string[20];

            //int Num = 0;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        {
                            LastNameB = LastName;
                            LastName = reader.Name;
                            break;
                        }
                    case XmlNodeType.Text: //Display the text in each element.
                        {
                            if (LastName == "name")
                            {
                                List2[i] = (reader.Value);
                            }
                            break;
                        }
                    case XmlNodeType.EndElement: //Display the end of the element.  
                        {
                            break;
                        }
                }
            }

            if (LUV1.IndexOf(fmMain.RouteLook.ToUpper() + "-1") != -1)
            {
                List2[i] += " - Inbound";
            }
            else
            {
                List2[i] += " - Outbound";
            }
        }

        private void SetDarkMode()
        {
            RouteDarkMode = 1;
            this.BackColor = Color.Black;
            lblRoute.ForeColor = Color.DarkGray;
            rtxtVariants.BackColor = Color.DarkGray;
        }

        private void SetLightMode()
        {
            RouteDarkMode = 0;
            this.BackColor = Color.WhiteSmoke;
            lblRoute.ForeColor = Color.Black;
            rtxtVariants.BackColor = Color.White;
        }

        private void GetDest(String Var)
        {
            String URLString = "https://api.winnipegtransit.com/v3/" + Var + "/destinations?api-key=yxCT5Ca2Ep5AVLc0z6zz&usage=long";
            //Console.WriteLine(URLString);
            XmlTextReader reader = new XmlTextReader(URLString);
            String LastName = "";
            //String X = "";

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
                            {
                                lbDest.Items.Add(reader.Value);
                            }
                            break;
                        }
                    case XmlNodeType.EndElement: //Display the end of the element.  
                        {
                            break;
                        }
                }
            }
        }

        private void timDark_Tick(object sender, EventArgs e)
        {
            if (fmMain.DarkMode != RouteDarkMode)
            {
                RouteDarkMode = fmMain.DarkMode;

                if (fmMain.DarkMode == 1)
                {
                    SetDarkMode();
                }
                else if (fmMain.DarkMode == 0)
                {
                    SetLightMode();
                }
            }
        }
    }
}
