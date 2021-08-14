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
        int SearchDarkMode = 0;

        public fmSearch()
        {
            InitializeComponent();
        }

        private void PrintItems()
        {
            int Num = 0;

            lbStopList.Items.Clear();
            foreach (string line in fmMain.StopList)
            {
                if (line != null && Num < 50 && (line.ToUpper().IndexOf(txtSearch.Text.ToUpper()) != -1 | txtSearch.Text == "")) { Num++; lbStopList.Items.Add(line); StopList2[Num] = line; }
            }
            if (Num < 50) { this.Text = "Stop Search (" + Num + ") - WTLive"; } else { this.Text = "Stop Search (" + Num + "+) - WTLive"; }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PrintItems(); //Print stops that include the search string.
        }

        private void lbStopList_DoubleClick(object sender, EventArgs e)
        {
            CloseForm(); //Close the window, if a stop is selected.
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            CloseForm(); //Close the window, if a stop is selected.
        }

        private void CloseForm()
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

            //if (fmMain.FirstSearch == 1) { fmMain.StopList = System.IO.File.ReadAllLines(@"stops.txt"); }
            PrintItems();
            fmMain.FirstSearch = 0;
        }

        private void fmSearch_Load(object sender, EventArgs e)
        {
            if (fmMain.DarkMode == 1)
            {
                SetDarkMode();
            }
        }

        private void SetDarkMode()
        {
            SearchDarkMode = 1;
            this.BackColor = Color.Black;
            lblLoading.ForeColor = Color.DarkGray;
            txtSearch.BackColor = Color.DarkGray;
            lbStopList.BackColor = Color.DarkGray;
        }

        private void SetLightMode()
        {
            SearchDarkMode = 0;
            this.BackColor = Color.WhiteSmoke;
            lblLoading.ForeColor = Color.Black;
            txtSearch.BackColor = Color.White;
            lbStopList.BackColor = Color.White;
        }

        private void timDark_Tick(object sender, EventArgs e)
        {
            if (fmMain.DarkMode != SearchDarkMode)
            {
                SearchDarkMode = fmMain.DarkMode;

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
