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
using System.Reflection;

namespace CryptoCentral
{
    public partial class Crypto : Form
    {

        public Crypto()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // no borders.
            this.DoubleBuffered = true; // ensure double buffering is enabled.

            btnHome.IconZoom = 55;
            btnMining.IconZoom = 55;
            btnSettings.IconZoom = 55;
            btnBack.IconZoom = 55;

            btnPageLeft.Top = (PageLeft.Height - btnPageLeft.Size.Height) / 2;
            btnPageRight.Top = (PageRight.Height - btnPageRight.Size.Height) / 2;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  //Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public static bool Loading = false;
        public static bool Locked = false;

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
        
        //Price Taken from BTC Summary Price to Calculate Profit for Worker.
        public static double UniversalBTCPrice;

        PictureBox PicTemp = new PictureBox();
        Bunifu.Framework.UI.BunifuGradientPanel PanelTemp = new Bunifu.Framework.UI.BunifuGradientPanel();

        //Resetting Positions of Panels and Header.
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
        private void Crypto_Load(object sender, EventArgs e)
        {

            LoadingPanel.Controls.Clear();
            Reference.LoadingForm.TopLevel = false;
            Reference.LoadingForm.Size = new Size(843, 520);
            Reference.LoadingForm.AutoScroll = false;
            Reference.LoadingForm.Dock = DockStyle.Fill;
            LoadingPanel.Controls.Add(Reference.LoadingForm);
            Reference.LoadingForm.Show();
            LoadingPanel.BringToFront();

            SummaryContainer.Controls.Clear();
            Reference.SummaryForm.TopLevel = false;
            Reference.SummaryForm.Size = new Size(843, 520);
            Reference.SummaryForm.AutoScroll = false;
            Reference.SummaryForm.Dock = DockStyle.Fill;
            SummaryContainer.Controls.Add(Reference.SummaryForm);
            Reference.SummaryForm.Show();

            WorkerContainer.Controls.Clear();
            Reference.WorkerForm.TopLevel = false;
            Reference.WorkerForm.Size = new Size(843, 520);
            Reference.WorkerForm.AutoScroll = false;
            Reference.WorkerForm.Dock = DockStyle.Fill;
            WorkerContainer.Controls.Add(Reference.WorkerForm);
            Reference.WorkerForm.Show();

            OptionsContainer.Controls.Clear();
            Reference.OptionsForm.TopLevel = false;
            Reference.OptionsForm.Size = new Size(843, 520);
            Reference.OptionsForm.Dock = DockStyle.Fill;
            OptionsContainer.Controls.Add(Reference.OptionsForm);
            Reference.OptionsForm.Show();

            Options.ProfileLoaded = false;      //PLACEHOLDER. | Will Implement Guest Login Screen.
            Options.Profile = 0;                //PLACEHOLDER. | Taken from Login Screen.
            Options.CreateMustFiles();          //Make sure all required files exist.
            Reference.OptionsForm.LoadProfile(Options.Profile);       //Load Profile Number.
            Reference.OptionsForm.TestCoinSummary();          //Test if txt file has valid coins and assign them to varaibles.
    //        Reference.OptionsForm.OpPagev.selectedIndex = Convert.ToInt32(Options.PageNumber);  //Setting Page Index to Saved Page Number on txt file.
            //Reference.OptionsForm.lblSaveFoundVisible = false;                    //Not Required on first startup.

            //Reference.WorkerForm.GETWallets();       //MINING | Gets All Wallet Info.
            //Reference.WorkerForm.GETPools();         //MINING | Gets All Available Pools.
            //Reference.WorkerForm.SetDefault();       //MINING | Set Default Worker Settings.     
            //Reference.WorkerForm.GETWorkerInfo();    //MINING | Get ALL Relevant Mining Info

            SummaryRESET();               //Populate the Summary Page with Data.
            FooterDefault();             //HIDE all header properties except default ones.
            intSyncTimer = 31;           //On first countdown users sees it counting down from 30.
            GETINFOSummary();            //Getting ALL API Information.
             
            //Correct Programs Sizing and Location.
            Footer.Location = new Point(222, 539);
            this.Size = new Size(1135, 640);
            this.CenterToScreen();
            
            //Set Home as default and hide compress button.
            btnHome.selected = true;
            btnCompress.Visible = false;

            //Loading Screen | Default Summary Page.
            Loading = true;
            LoadingPanel.BringToFront();
            SidebarTransition.Show(LoadingPanel);
            SummaryContainer.Visible = true;
            WorkerContainer.Visible = false;
            OptionsContainer.Visible = false;

            //Page Turner Settings.
            PageLeft.GradientTopLeft = Color.White;
            PageRight.GradientTopRight = Color.White;
            PageLeftShadow.Visible = false;
            PageRightShadow.Visible = false;
        }

        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            Options.PageNumber = Convert.ToString(Reference.OptionsForm.OpPagev.selectedIndex);     //Saves the Last Page the user was viewing.
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Options.Profile) + @"\PageStart.txt", Options.PageNumber);
        }

        //Universal Hide All Function.
        void HideAll()
        {
            Reference.OptionsForm.lblConfirmed.Visible = false;
            Reference.OptionsForm.lblMaxPages.Visible = false;
            Reference.OptionsForm.lblDefaultSet.Visible = false;
        }
        void FooterDefault()
        {
            btnPageLeft.Visible = true;
            btnPageRight.Visible = true;
            lblCurrentPage.Visible = true;
        }
        //All Buttons Events
        private void btnHome_Click(object sender, EventArgs e)
        {
            HideAll();
            SummaryRESET();
            FooterDefault();
            if (bSummary == true && SummaryContainer.Visible != true && Locked == false)
            {
                Locked = true;
                SidebarTransition.Show(SummaryContainer);
                OptionsContainer.Visible = false;
                WorkerContainer.Visible = false;
            }
            
        }
        private void btnMining_Click(object sender, EventArgs e)
        {
            HideAll();
            WorkerRESET();
            FooterDefault();
            if (bWorker == true && WorkerContainer.Visible != true && Locked == false)
            {
                Locked = true;
                SummaryContainer.Visible = false;
                OptionsContainer.Visible = false;
                SidebarTransition.Show(WorkerContainer);
            }

        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            HideAll();
            OptionsRESET();
            FooterDefault();
            if (bOptions == true && OptionsContainer.Visible != true && Locked == false)
            {
                Locked = true;
                SummaryContainer.Visible = false;
                SidebarTransition.Show(OptionsContainer);
                WorkerContainer.Visible = false;
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
            Crypto.CurrentPage = Reference.OptionsForm.OpPagev.selectedIndex + 1;
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
                    if (Reference.OptionsForm.HeaderPoolv.Text == "NICEHASH")
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

        private void btnPageControlClick(object sender, EventArgs e)
        {
            try
            {
                PictureBox btnPicControl = (PictureBox)sender;
                PageControlCalc(btnPicControl, PanelTemp);
            }
            catch(Exception)
            {
                Bunifu.Framework.UI.BunifuGradientPanel btnPanelControl = (Bunifu.Framework.UI.BunifuGradientPanel)sender;
                PageControlCalc(PicTemp, btnPanelControl);
            }
        }

        void PageControlCalc(PictureBox PicControl, Bunifu.Framework.UI.BunifuGradientPanel PanelControl)
        {
            if (PicControl.Name == "btnPageLeft" || PanelControl.Name == "PageLeft")
            {
                if (Reference.OptionsForm.OpPagev.selectedIndex != 0)
                {
                    UseWaitCursor = true;
                    btnPageLeft.Enabled = true;
                    Reference.OptionsForm.OpPagev.selectedIndex = Reference.OptionsForm.OpPagev.selectedIndex - 1;
                    UpdatingCurrentPage();
                }
            }
            else if (PicControl.Name == "btnPageRight" || PanelControl.Name == "PageRight")
            {
                MaxPages = Convert.ToInt32(Options.Pages);
                MaxPages = MaxPages - 1;
                if (Reference.OptionsForm.OpPagev.selectedIndex != MaxPages)
                {
                    UseWaitCursor = true;
                    btnPageRight.Enabled = true;
                    Reference.OptionsForm.OpPagev.selectedIndex = Reference.OptionsForm.OpPagev.selectedIndex + 1;
                    UpdatingCurrentPage();
                }
            }
        }

        private void MiningNH_Click(object sender, EventArgs e)
        {

        }

        private void btnSizeChange_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                LoadingPanel.BringToFront();
                LoadingPanel.Visible = true;
                this.Visible = false;
                LoadingCalc.LoadingValue = 0;
                Loading = true;
                timerSummaryLoad.Enabled = true;
                SidebarTransition.MaxAnimationTime = 500;
                SidebarTransition.TimeStep = Convert.ToSingle(0.09);
                this.WindowState = FormWindowState.Maximized;
                MaximizeBox();
                btnCompress.Visible = true;
                btnMaximize.Visible = false;
                PageLeft.Size = new Size(55, 523);
                PageRight.Size = new Size(55, 523);
                PageLeftShadow.Size = new Size(55, 16);
                PageRightShadow.Size = new Size(55, 16);
                PageRightShadow.Location = new Point(PageRightShadow.Location.X - 24, PageRightShadow.Location.Y);
                this.CenterToScreen();
                this.Visible = true;
            }
            else
            {
                LoadingPanel.BringToFront();
                LoadingPanel.Visible = true;
                LoadingCalc.LoadingValue = 0;
                Loading = true;
                timerSummaryLoad.Enabled = true;
                SidebarTransition.MaxAnimationTime = 1500;
                SidebarTransition.TimeStep = Convert.ToSingle(0.02);
                PageLeft.Size = new Size(31, 523);
                PageRight.Size = new Size(31, 523);
                PageLeftShadow.Size = new Size(31, 16);
                PageRightShadow.Size = new Size(31, 16);
                PageRightShadow.Location = new Point(PageRightShadow.Location.X + 24, PageRightShadow.Location.Y);
                timerMinimize.Enabled = true;
            }
        }
        
        public void MaximizeBox()
        {
        }

        private void timerMinimize_Tick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnCompress.Visible = false;
            btnMaximize.Visible = true;
            this.CenterToScreen();
            timerMinimize.Enabled = false;
        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            if (Loading == false)
            {
                SidebarTransition.Hide(LoadingPanel);
                timerSummaryLoad.Enabled = false;
            }
        }

        private void SidebarTransition_AnimationCompleted(object sender, BunifuAnimatorNS.AnimationCompletedEventArg e)
        {
            Locked = false;
        }

        private void Crypto_Resize(object sender, EventArgs e)
        {
            Reference.SummaryForm.customGroup05.Left = (Reference.SummaryForm.ClientSize.Width - Reference.SummaryForm.customGroup05.Size.Width) / 2;
            btnPageLeft.Top = (PageLeft.Height - btnPageLeft.Size.Height) / 2;
            btnPageRight.Top = (PageRight.Height - btnPageRight.Size.Height) / 2;
        }

        private void PageLeft_MouseEnter(object sender, EventArgs e)
        {
            PageLeft.GradientTopLeft = Color.DarkOrange;
            PageLeftShadow.Visible = true;
        }

        private void PageLeft_MouseLeave(object sender, EventArgs e)
        {
            PageLeft.GradientTopLeft = Color.White;
            PageLeftShadow.Visible = false;
        }

        private void PageRight_MouseEnter(object sender, EventArgs e)
        {
            PageRight.GradientTopRight = Color.DarkOrange;
            PageRightShadow.Visible = true;
        }

        private void PageRight_MouseLeave(object sender, EventArgs e)
        {
            PageRight.GradientTopRight = Color.White;
            PageRightShadow.Visible = false;
        }

       
    }
}
