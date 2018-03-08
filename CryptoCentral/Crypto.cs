using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Threading;

namespace CryptoCentral
{
    public partial class Crypto : Form
    {

        public Crypto()
        {
            InitializeComponent();
        }

        public static bool Loading = false;

        //Creating Varaibles For Moving Form.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //Creating Lists for JSON.
        List<NHAlgos> NHAlgo;

        //Creating public varaibles.

        //Storing Json output as a string.
        string jsonString;
        

        //Booleans to Specify the current selected panel.
        public static bool bOptions = false;
        public static bool bSummary = true;
        public static bool bWorker = false;
        

        public static bool SYNCED;
        public static bool SYNCING;
        public static bool ChangingPage = false;
        

        //Variables that are not indexed. Eg Index: 0 is Page 1.
        public static int CurrentPage;
        public static int MaxPages;

        //Variables to control Universal Syncing.
        int intSyncTimer;
        public static string stringSyncTimer;



        /// MINING.
        //Price Taken from BTC Summary Price to Calculate Profit for Worker.
        public static double UniversalBTCPrice;


        void BringtoFront(Panel PanelControl)
        {
            PanelControl.BringToFront();
        }

        //Resetting Positions of Panels and Header.
        void LoadingRESET()
        {
            SidebarTransition.Show(LoadingPanel);
        }
        void SummaryRESET()
        {
            bSummary = true;
            bWorker = false;
            bOptions = false;
        }
        
        void OptionsRESET()
        {
            bSummary = false;
            bWorker = false;
            bOptions = true;
        }
        void WorkerRESET()
        {
            bSummary = false;
            bWorker = true;
            bOptions = false;
        }
        void HeaderDefaultRESET()
        {
            btnPageLeft.Location = new Point(6, 7);
            lblCurrentPage.Location = new Point(36, 9);
            btnPageRight.Location = new Point(115, 7);
            lblSync.Location = new Point(638, 9);
            gifRefreshing.Location = new Point(758, 7);
            btnRefresh.Location = new Point(758, 7);
        }
        void HeaderMiningRESET()
        {
            Reference.OptionsForm.lblHeaderPoolLocation = new Point(13, 40);
            Reference.OptionsForm.HeaderPoolvLocation = new Point(83, 38);
            Reference.OptionsForm.lblHeaderWorkerLocation = new Point(234, 40);
            Reference.OptionsForm.HeaderWorkervLocation = new Point(334, 38);
            Reference.OptionsForm.lblHeaderMiningCurrencyLocation = new Point(530, 40);
            Reference.OptionsForm.HeaderMiningCurrencyvLocation = new Point(651, 38);
        }

        private void Crypto_Load(object sender, EventArgs e)
        {
            SummaryContainer.Location = new Point(222, 71); 
            SummaryContainer.Size = new Size(842, 468);
            OptionsContainer.Location = new Point(222, 71);
            OptionsContainer.Size = new Size(842, 468);
            WorkerContainer.Location = new Point(222, 71);
            WorkerContainer.Size = new Size(842, 468);
            LoadingPanel.Location = new Point(222, 71);
            LoadingPanel.Size = new Size(842, 468);

            LoadingPanel.Controls.Clear();
            Reference.LoadingForm.TopLevel = false;
            Reference.LoadingForm.Size = new Size(842, 468);
            Reference.LoadingForm.AutoScroll = false;
            Reference.LoadingForm.Dock = DockStyle.Fill;
            LoadingPanel.Controls.Add(Reference.LoadingForm);
            Reference.LoadingForm.Show();
            LoadingPanel.BringToFront();

            SummaryContainer.Controls.Clear();
            Reference.SummaryForm.TopLevel = false;
            Reference.SummaryForm.Size = new Size(842, 468);
            Reference.SummaryForm.AutoScroll = false;
            Reference.SummaryForm.Dock = DockStyle.Fill;
            SummaryContainer.Controls.Add(Reference.SummaryForm);
            Reference.SummaryForm.Show();

            WorkerContainer.Controls.Clear();
            Reference.WorkerForm.TopLevel = false;
            Reference.WorkerForm.Size = new Size(842, 468);
            Reference.WorkerForm.AutoScroll = false;
            Reference.WorkerForm.Dock = DockStyle.Fill;
            WorkerContainer.Controls.Add(Reference.WorkerForm);
            Reference.WorkerForm.Show();

            OptionsContainer.Controls.Clear();
            Reference.OptionsForm.TopLevel = false;
            Reference.OptionsForm.Size = new Size(842, 468);
            Reference.OptionsForm.AutoScroll = false;
            Reference.OptionsForm.Dock = DockStyle.Fill;
            OptionsContainer.Controls.Add(Reference.OptionsForm);
            Reference.OptionsForm.Show();

            

            



            Options.ProfileLoaded = false;      //PLACEHOLDER. | Will Implement Guest Login Screen.
            Options.Profile = 0;                //PLACEHOLDER. | Taken from Login Screen.
            Options.CreateMustFiles();          //Make sure all required files exist.
            Reference.OptionsForm.LoadProfile(Options.Profile);       //Load Profile Number.
            Reference.OptionsForm.TestCoinSummary();          //Test if txt file has valid coins and assign them to varaibles.
            SummaryRESET();           //Populate the Summary Page with Data.
            HeaderDefaultRESET();       //MOVE all Header properties to correct location.
            HeaderMiningRESET();        //MOVE all Mining Header propertities to correct location.
            HeaderDefault();            //HIDE all header properties except default ones.
            Reference.OptionsForm.PagevSelectedIndex = Convert.ToInt32(Options.PageNumber);  //Setting Page Index to Saved Page Number on txt file.
            intSyncTimer = 31;          //On first countdown users sees it counting down from 30.
            lblSyncTimer.Location = new Point(789, 7);  // ** FIX **
            Reference.WorkerForm.GETWallets();                                           //MINING | Gets All Wallet Info.
            Reference.WorkerForm.GETPools();                                             //MINING | Gets All Available Pools.
            Reference.WorkerForm.SetDefault();                                           //MINING | Set Default Worker Settings.                               
            Footer.Location = new Point(222, 539);
            this.Size = new Size(1064, 577);
            this.CenterToScreen();
            GETINFOSummary();                                 //Getting ALL API Information.
            Reference.WorkerForm.GETWorkerInfo();                                  //Get ALL Relevant Mining Info
            Reference.OptionsForm.lblSaveFoundVisible = false;                    //Not Required on first startup.
            btnHome.selected = true;
            Loading = true;
        }

        //Events for moving the actual form.
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)      //Left Click
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Logo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)      //Left Click
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            Options.PageNumber = Convert.ToString(Reference.OptionsForm.PagevSelectedIndex);     //Saves the Last Page the user was viewing.
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Options.Profile) + @"\PageStart.txt", Options.PageNumber);
        }

        //Universal Hide All Function.
        void HideAll()
        {
            Reference.OptionsForm.lblConfirmedVisible = false;
            Reference.OptionsForm.lblMaxPagesVisible = false;
            Reference.OptionsForm.lblDefaultSetVisible = false;
        }
        void HeaderDefault()
        {
            btnPageLeft.Visible = true;
            btnPageRight.Visible = true;
            lblCurrentPage.Visible = true;
        }
        //All Buttons Events
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (LoadingPanel.Visible != true)
            {
                Loading = true;
                LoadingPanel.BringToFront();
                SidebarTransition.Show(LoadingPanel);
                HideAll();
                SummaryRESET();
                HeaderDefault();
            }
        }
        private void btnMining_Click(object sender, EventArgs e)
        {
            if (LoadingPanel.Visible != true)
            {
                Loading = true;
                LoadingPanel.BringToFront();
                SidebarTransition.Show(LoadingPanel);
                HideAll();
                WorkerRESET();
                HeaderDefault();
            }

        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (LoadingPanel.Visible != true)
            {
                Loading = true;
                LoadingPanel.BringToFront();
                SidebarTransition.Show(LoadingPanel);
                HideAll();
                OptionsRESET();
                HeaderDefault();
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            //HideAll();
           // bSummary = true;
           // SummaryRESET();
           // HeaderDefault();
        }

        //Updating Header Page Number
        public void UpdatingCurrentPage()
        {
            Crypto.CurrentPage = Reference.OptionsForm.PagevSelectedIndex + 1;
            lblCurrentPage.Text = "PAGE " + Convert.ToString(Crypto.CurrentPage);
        }

        //AUTO FETCH DATA | 30seconds
        private void timerSyncTimer_Tick(object sender, EventArgs e)
        {
            if (intSyncTimer == 0)
            {
                SyncingTest();
                intSyncTimer = 31;
            }
            else if (SYNCED == true)
            {
                intSyncTimer = intSyncTimer - 1;
                if (intSyncTimer > 30)
                {

                }
                else
                {
                    stringSyncTimer = Convert.ToString(intSyncTimer);
                    lblSyncTimer.Text = "(" + stringSyncTimer + ")";
                }
            }
            else
            {
                intSyncTimer = intSyncTimer - 1;
                stringSyncTimer = Convert.ToString(intSyncTimer);
                lblSyncTimer.Text = "(" + stringSyncTimer + ")";
            }
        }

        //UPDATES ALL INFORMATION AFFECTING EVERY LABEL AND GROUPBOX | VERY IMPORTANT
        public void GETINFOSummary()
        {
            Reference.SummaryForm.GETINFOSummary();
        }

        //MINIMISE THE FORM
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            FormBorderStyle = FormBorderStyle.None;
        }

        //SYNCING
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SyncingTest();
        }

        //INITIATE THE SYNC
        public void SyncingTest()
        {
            Reference.SummaryForm.ShowcustomRefresh();
            UseWaitCursor = true;
            timerUpdating.Enabled = true;
            SYNCED = false;
        }

        //CONSTANTLY CHECKS IF LBLS ARE CORRECT | 50ms
        private void timerRefreshing_Tick(object sender, EventArgs e)
        {
            if (SYNCED == false)
            {
                lblSync.Text = "SYNCING...";
                gifRefreshing.Visible = true;
            }
            else if (SYNCED == true)
            {
                Reference.SummaryForm.HidecustomRefresh();
                lblSync.Text = "SYNCED";
                gifRefreshing.Visible = false;
                UseWaitCursor = false;
            }

        }

        //UPDATES THE DATA ON REFRESH | 2000ms
        private void timerUpdating_Tick(object sender, EventArgs e)
        {
            if (SYNCED == false)
            {
                Reference.SummaryForm.ShowcustomRefresh();
                lblSync.Text = "SYNCING...";        //REQUIRED FOR SYNCING LABELS TO WORK FOR PAGE SWITHCING
                gifRefreshing.Visible = true;       //REQUIRED FOR SYNCING LABELS TO WORK FOR PAGE SWITCHING
                if (bSummary == true)
                {
                    GETINFOSummary();
                }
                else if (bWorker == true)
                {
                    if (Reference.OptionsForm.HeaderPoolvText == "NICEHASH")
                    {
                        Reference.WorkerForm.GETNHWorkerRefresh();
                    }
                    Reference.WorkerForm.GETWorkerInfo();
                }
                else if (bOptions == true)
                {
                    GETINFOSummary();
                }
            }
            else if (SYNCED == true)
            {
                Reference.SummaryForm.HidecustomRefresh();
                timerUpdating.Enabled = false;
                UseWaitCursor = false;
            }
        }

        private void event_SummaryHover(object sender, EventArgs e)
        {

        }
        
        private void btnPageHoverEnter(object sender, EventArgs e)
        {

        }

        private void btnPageHoverLeave(object sender, EventArgs e)
        {
            PictureBox btnPageControl = (PictureBox)sender;

            if (btnPageControl.Name == "btnPageLeft")
            {
                btnPageControl.Image = Image.FromFile(@"C:\Users\" + Environment.UserName + @"\Documents\GitHub\CryptoCentral\Images\left-arrow-still-24px.png");
            }
            else if (btnPageControl.Name == "btnPageRight")
            {
                btnPageControl.Image = Image.FromFile(@"C:\Users\" + Environment.UserName + @"\Documents\GitHub\CryptoCentral\Images\right-arrow-still-24px.png");
            }
        }

        private void btnPageControlClick(object sender, EventArgs e)
        {
            PictureBox btnPageControl = (PictureBox)sender;

            if (btnPageControl.Name == "btnPageLeft")
            {
                btnPageControl.Image = Image.FromFile(@"C:\Users\" + Environment.UserName + @"\Documents\GitHub\CryptoCentral\Images\left-arrow-clicked-24px.png");
                if (Reference.OptionsForm.PagevSelectedIndex != 0)
                {
                    btnPageLeft.Enabled = true;
                    Reference.OptionsForm.PagevSelectedIndex = Reference.OptionsForm.PagevSelectedIndex - 1;
                    UpdatingCurrentPage();
                }
            }
            else if (btnPageControl.Name == "btnPageRight")
            {
                btnPageControl.Image = Image.FromFile(@"C:\Users\" + Environment.UserName + @"\Documents\GitHub\CryptoCentral\Images\right-arrow-clicked-24px.png");
                MaxPages = Convert.ToInt32(Options.Pages);
                MaxPages = MaxPages - 1;
                if (Reference.OptionsForm.PagevSelectedIndex != MaxPages)
                {
                    btnPageRight.Enabled = true;
                    Reference.OptionsForm.PagevSelectedIndex = Reference.OptionsForm.PagevSelectedIndex + 1;
                    UpdatingCurrentPage();
                }
            }
        }

        private void MiningNH_Click(object sender, EventArgs e)
        {

        }

        private void SidebarTransition_AllAnimationsCompleted(object sender, EventArgs e)
        {

        }

        private void timerSummaryLoad_Tick(object sender, EventArgs e)
        {
            if (Loading == false)
            {
                SidebarTransition.Hide(LoadingPanel);
                if (bSummary == true)
                {
                    OptionsContainer.SendToBack();
                    WorkerContainer.SendToBack();
                }
                else if (bOptions == true)
                {
                    SummaryContainer.SendToBack();
                    WorkerContainer.SendToBack();
                }
                else if (bWorker == true)
                {
                    SummaryContainer.SendToBack();
                    OptionsContainer.SendToBack();
                }
            }
            else if (Loading == true)
            {
                LoadingPanel.BringToFront();
                SidebarTransition.Show(LoadingPanel);
            }
        }
    }
}
