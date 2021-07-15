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
    public partial class fmAdvisory : Form
    {
        String[] List = new string[50];

        public fmAdvisory()
        {
            InitializeComponent();
        }

        private void fmAdvisory_Load(object sender, EventArgs e)
        {
            GetAdvs();
        }

        public void GetAdvs()
        {
            String URLString = "https://api.winnipegtransit.com/v3/service-advisories?api-key=yxCT5Ca2Ep5AVLc0z6zz&usage=long"; //&max-age=60";
            XmlTextReader reader = new XmlTextReader(URLString);
            String LastName = "";
            String X = "";
            String X2 = "";
            int ExtSpace = 0;

            int Num = 0;

            Num = 0;
            lbAdvisories.Items.Clear();

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
                            if (LastName == "title")
                            {
                                Num += 1;
                                X = reader.Value;
                                ExtSpace = 0;
                            }
                            else if (LastName == "body")
                            {
                                X2 = reader.Value;

                                for (int i = 0; i < X2.Length; i++)
                                {
                                    if (X2.Length - i > 4)
                                    {
                                        if (X2.Substring(i, 4) == "* **")
                                        {
                                            if (ExtSpace == 0) { ExtSpace = 1; } else { List[Num - 1] += (char)10; }
                                            i += 3;
                                        }
                                        else if (X2.Substring(i, 4) == ")** ")
                                        {
                                            List[Num - 1] += ") ";
                                            i += 3;
                                        }
                                        else if (X2.Substring(i, 3) == "** ")
                                        {
                                            List[Num - 1] += " • ";
                                            i += 2;
                                        }
                                        else if (X2.Substring(i, 2) == "* ")
                                        {
                                            List[Num - 1] += " • ";
                                            i += 1;
                                        }
                                        else
                                        {
                                            List[Num - 1] += X2.Substring(i, 1);
                                        }
                                    }
                                    else
                                    {
                                        List[Num - 1] += X2.Substring(i, 1);
                                    }
                                    
                                }
                            }
                            else if (LastName == "updated-at")
                            {
                                //X += " (" + reader.Value.Substring(0, 10) + ")";
                                lbAdvisories.Items.Add(X);
                            }
                            break;
                        }
                    case XmlNodeType.EndElement: //Display the end of the element.  
                        {
                            break;
                        }
                }
            }
            this.Text = "Service Advisories (" + Num + ")";
            lbAdvisories.SelectedIndex = 0;
            rtxtAdvisory.Text = List[0];
        }

        private void timRefresh_Tick(object sender, EventArgs e)
        {
            GetAdvs();
        }

        private void lbAdvisories_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtxtAdvisory.Text = List[lbAdvisories.SelectedIndex];

            rtxtAdvisory.SelectionStart = 0;
            rtxtAdvisory.ScrollToCaret();
        }
    }
}
