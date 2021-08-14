using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transit
{
    public partial class fmOtherInfo : Form
    {
        int BusListDarkMode = 0;
        String[] BusList = new string[1000]; int[] BusListBus = new int[1000]; String[] BusListRun = new String[1000]; int CurSort = 1;
        String[] BusListAll = new string[1000]; int[] BusListBusAll = new int[1000]; String[] BusListRunAll = new String[1000]; int CurSortAll = 1;
        int Count = 0; int CountAll = 0;

        public fmOtherInfo()
        {
            InitializeComponent();
        }

        private void fmOtherInfo_Load(object sender, EventArgs e)
        {
            if (fmMain.DarkMode == 1)
            {
                SetDarkMode();
            }

            Count = 0;
            CountAll = 0;

            rtxtBusList.Text = "";
            for (int i = 1; i <= 999; i++)
            {
                if (fmMain.BusList[i] == true)
                {
                    Count++;

                    BusList[Count] = "Bus " + i + ", ";
                    if (fmMain.BusListBkRack[i] == true) { BusList[Count] += "🚲"; } else { BusList[Count] += "🚳"; }
                    if (fmMain.BusListRunNum[i] != "") { BusList[Count] += ", " + fmMain.BusListRunNum[i]; }
                    BusList[Count] += "" + (char)10;

                    BusListBus[Count] = i;
                    BusListRun[Count] = fmMain.BusListRunNum[i];
                    rtxtBusList.AppendText(BusList[Count]);
                }
                if (fmMain.BusList2[i] == true)
                {
                    CountAll++;

                    BusListAll[CountAll] = "Bus " + i + ", ";
                    if (fmMain.BusListBkRack2[i] == true) { BusListAll[CountAll] += "🚲"; } else { BusListAll[CountAll] += "🚳"; }
                    if (fmMain.BusListRunNum2[i] != "") { BusListAll[CountAll] += ", " + fmMain.BusListRunNum2[i]; }
                    BusListAll[CountAll] += "" + (char)10;

                    BusListBusAll[CountAll] = i;
                    BusListRunAll[CountAll] = fmMain.BusListRunNum2[i];
                    rtxtBusListAll.AppendText(BusListAll[CountAll]);
                }
            }
            rtxtBusList.SelectionStart = 0;
            rtxtBusList.ScrollToCaret();
            this.Text = "Bus List (" + Count + ", " + CountAll + ") - WTLive";
        }

        private void btnSortRuns_Click(object sender, EventArgs e)
        {
            if (CurSort == 1)
            {
                btnSortRuns.Text = "Sort by Bus";
                CurSort = 2;
                SortByRun();
            }
            else if (CurSort == 2)
            {
                btnSortRuns.Text = "Sort by Runs";
                CurSort = 1;
                SortByBus();
            }
        }

        private void btnSortRunsAll_Click(object sender, EventArgs e)
        {
            if (CurSortAll == 1)
            {
                btnSortRunsAll.Text = "Sort by Bus";
                CurSortAll = 2;
                SortByRunAll();
            }
            else if (CurSortAll == 2)
            {
                btnSortRunsAll.Text = "Sort by Runs";
                CurSortAll = 1;
                SortByBusAll();
            }
        }

        private void SortByRun()
        {
            String X; int X2; int X3; int X4; int X5; int X6;


            for (int i = 1; i <= Count; i++)
            {
                for (int i2 = 2; i2 <= Count; i2++)
                {
                    X3 = BusListRun[i2 - 1].IndexOf("-");
                    X3 = int.Parse(BusListRun[i2 - 1].Substring(0, X3));

                    X4 = BusListRun[i2].IndexOf("-");
                    X4 = int.Parse(BusListRun[i2].Substring(0, X4));

                    if (X3 > X4)
                    {
                        X = BusList[i2 - 1];
                        BusList[i2 - 1] = BusList[i2];
                        BusList[i2] = X;

                        X = BusListRun[i2 - 1];
                        BusListRun[i2 - 1] = BusListRun[i2];
                        BusListRun[i2] = X;

                        X2 = BusListBus[i2 - 1];
                        BusListBus[i2 - 1] = BusListBus[i2];
                        BusListBus[i2] = X2;
                    }
                }
            }

            for (int i = 1; i <= Count; i++)
            {
                for (int i2 = 2; i2 <= Count; i2++)
                {
                    X3 = BusListRun[i2 - 1].IndexOf("-");
                    X3 = int.Parse(BusListRun[i2 - 1].Substring(0, X3));

                    X4 = BusListRun[i2].IndexOf("-");
                    X4 = int.Parse(BusListRun[i2].Substring(0, X4));


                    X5 = BusListRun[i2 - 1].IndexOf("-");
                    X5 = int.Parse(BusListRun[i2 - 1].Substring(X5 + 1));

                    X6 = BusListRun[i2].IndexOf("-");
                    X6 = int.Parse(BusListRun[i2].Substring(X6 + 1));

                    if (X3 == X4 && X5 > X6)
                    {
                        X = BusList[i2 - 1];
                        BusList[i2 - 1] = BusList[i2];
                        BusList[i2] = X;

                        X = BusListRun[i2 - 1];
                        BusListRun[i2 - 1] = BusListRun[i2];
                        BusListRun[i2] = X;

                        X2 = BusListBus[i2 - 1];
                        BusListBus[i2 - 1] = BusListBus[i2];
                        BusListBus[i2] = X2;
                    }
                }
            }

            rtxtBusList.Text = "";
            for (int i = 1; i <= Count; i++)
            {
                rtxtBusList.AppendText(BusList[i]);
            }
        }

        private void SortByBus()
        {
            String X; int X2;

            for (int i = 1; i <= Count; i++)
            {
                for (int i2 = 2; i2 <= Count; i2++)
                {
                    if (BusListBus[i2 - 1] > BusListBus[i2])
                    {
                        X = BusList[i2 - 1];
                        BusList[i2 - 1] = BusList[i2];
                        BusList[i2] = X;

                        X = BusListRun[i2 - 1];
                        BusListRun[i2 - 1] = BusListRun[i2];
                        BusListRun[i2] = X;

                        X2 = BusListBus[i2 - 1];
                        BusListBus[i2 - 1] = BusListBus[i2];
                        BusListBus[i2] = X2;
                    }
                }
            }

            rtxtBusList.Text = "";
            for (int i = 1; i <= Count; i++)
            {
                rtxtBusList.AppendText(BusList[i]);
            }
        }

        private void SortByRunAll()
        {
            String X; int X2; int X3; int X4; int X5; int X6;

            for (int i = 1; i <= CountAll; i++)
            {
                for (int i2 = 2; i2 <= CountAll; i2++)
                {
                    X3 = BusListRunAll[i2 - 1].IndexOf("-");
                    X3 = int.Parse(BusListRunAll[i2 - 1].Substring(0, X3));

                    X4 = BusListRunAll[i2].IndexOf("-");
                    X4 = int.Parse(BusListRunAll[i2].Substring(0, X4));

                    if (X3 > X4)
                    {
                        X = BusListAll[i2 - 1];
                        BusListAll[i2 - 1] = BusListAll[i2];
                        BusListAll[i2] = X;

                        X = BusListRunAll[i2 - 1];
                        BusListRunAll[i2 - 1] = BusListRunAll[i2];
                        BusListRunAll[i2] = X;

                        X2 = BusListBusAll[i2 - 1];
                        BusListBusAll[i2 - 1] = BusListBusAll[i2];
                        BusListBusAll[i2] = X2;
                    }
                }
            }

            for (int i = 1; i <= CountAll; i++)
            {
                for (int i2 = 2; i2 <= CountAll; i2++)
                {
                    X3 = BusListRunAll[i2 - 1].IndexOf("-");
                    X3 = int.Parse(BusListRunAll[i2 - 1].Substring(0, X3));

                    X4 = BusListRunAll[i2].IndexOf("-");
                    X4 = int.Parse(BusListRunAll[i2].Substring(0, X4));


                    X5 = BusListRunAll[i2 - 1].IndexOf("-");
                    X5 = int.Parse(BusListRunAll[i2 - 1].Substring(X5 + 1));

                    X6 = BusListRunAll[i2].IndexOf("-");
                    X6 = int.Parse(BusListRunAll[i2].Substring(X6 + 1));

                    if (X3 == X4 && X5 > X6)
                    {
                        X = BusListAll[i2 - 1];
                        BusListAll[i2 - 1] = BusListAll[i2];
                        BusListAll[i2] = X;

                        X = BusListRunAll[i2 - 1];
                        BusListRunAll[i2 - 1] = BusListRunAll[i2];
                        BusListRunAll[i2] = X;

                        X2 = BusListBusAll[i2 - 1];
                        BusListBusAll[i2 - 1] = BusListBusAll[i2];
                        BusListBusAll[i2] = X2;
                    }
                }
            }

            rtxtBusListAll.Text = "";
            for (int i = 1; i <= CountAll; i++)
            {
                rtxtBusListAll.AppendText(BusListAll[i]);
            }
        }

        private void SortByBusAll()
        {
            String X; int X2;

            for (int i = 1; i <= CountAll; i++)
            {
                for (int i2 = 2; i2 <= CountAll; i2++)
                {
                    if (BusListBusAll[i2 - 1] > BusListBusAll[i2])
                    {
                        X = BusListAll[i2 - 1];
                        BusListAll[i2 - 1] = BusListAll[i2];
                        BusListAll[i2] = X;

                        X = BusListRunAll[i2 - 1];
                        BusListRunAll[i2 - 1] = BusListRunAll[i2];
                        BusListRunAll[i2] = X;

                        X2 = BusListBusAll[i2 - 1];
                        BusListBusAll[i2 - 1] = BusListBusAll[i2];
                        BusListBusAll[i2] = X2;
                    }
                }
            }

            rtxtBusListAll.Text = "";
            for (int i = 1; i <= CountAll; i++)
            {
                rtxtBusListAll.AppendText(BusListAll[i]);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 999; i++)
            {
                fmMain.BusList2[i] = false;
                fmMain.BusListBkRack2[i] = false;
                fmMain.BusListRunNum2[i] = "";
            }
            rtxtBusListAll.Text = "";
            CountAll = 0;
            this.Text = "Bus List (" + Count + ", " + CountAll + ") - WTLive";
        }

        private void timDark_Tick(object sender, EventArgs e)
        {
            if (fmMain.DarkMode != BusListDarkMode)
            {
                BusListDarkMode = fmMain.DarkMode;

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

        private void SetDarkMode()
        {
            BusListDarkMode = 1;
            this.BackColor = Color.Black;
            lblCurStop.ForeColor = Color.DarkGray;
            lblAll.ForeColor = Color.DarkGray;
            rtxtBusList.BackColor = Color.DarkGray;
            rtxtBusListAll.BackColor = Color.DarkGray;
        }

        private void SetLightMode()
        {
            BusListDarkMode = 0;
            this.BackColor = Color.WhiteSmoke;
            lblCurStop.ForeColor = Color.Black;
            lblAll.ForeColor = Color.Black;
            rtxtBusList.BackColor = Color.White;
            rtxtBusListAll.BackColor = Color.White;
        }
    }
}
