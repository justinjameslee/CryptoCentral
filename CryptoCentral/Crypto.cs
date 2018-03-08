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


        public string lblCurrentPageText
        {
            get { return lblCurrentPage.Text; }
            set { lblCurrentPage.Text = value; }
        }

        public bool LoadingPanelVisible
        {
            get { return LoadingPanel.Visible; }
            set { LoadingPanel.Visible = value; }
        }

        //Used for saving and reading files. Refer to Method: Options.cs
        public class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public Crypto()
        {
            InitializeComponent();
        }

        public static bool SummaryLoading = false;

        //Creating Varaibles For Moving Form.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //Creating Lists for JSON.
        List<MarketCap> Coins;
        public static List<MarketCap> CoinsDetailed;
        List<NHAlgos> NHAlgo;

        //Creating public varaibles.

        //Storing Json output as a string.
        string jsonString;

        //Custom Coin inputs as Symbols eg "BTC".
        public static string coin1 = "";
        public static string coin2 = "";
        public static string coin3 = "";
        public static string coin4 = "";
        public static string coin5 = "";
        public static string coin6 = "";
        public static string coin7 = "";
        public static string coin8 = "";
        public static string coin9 = "";

        //Custom Coin inputs as full name eg "bitcoin".
        public static string coin1FN = "";
        public static string coin2FN = "";
        public static string coin3FN = "";
        public static string coin4FN = "";
        public static string coin5FN = "";
        public static string coin6FN = "";
        public static string coin7FN = "";
        public static string coin8FN = "";
        public static string coin9FN = "";

        //Variables related to saving to text files.
        public static string PageNumber;
        public static string Pages;
        public static string StartingCurrency;
        public static string StartingTimeZone;
        public static string StartingPeriod;
        public static int CurrencyNumber;
        public static int TimeZoneNumber;
        public static int TimePeriodNumber;
        public static int pages = 1;
        public static int PageCalculation;

        //Storing Inputed Coins in an array | New profile ready.
        public static string[] ProfileLoad = { "BTC", "", "", "", "", "", "", "", "", "" };
        public static string[] ProfileCoinsLoaded = new string[10];

        //Booleans to Specify the current selected panel.
        public static bool bOptions = false;
        public static bool bSummary = true;
        public static bool bMining = false;
        public static bool ConfirmAllowed = false;
        public static bool ProfileLoaded = false;
        public static bool NewSave;
        public static bool SYNCED;
        public static bool SYNCING;
        public static bool ChangingPage = false;

        //Profile Number    | Work In Progress - Comes from Login Screen.
        public static double Profile;

        //Variables that are not indexed. Eg Index: 0 is Page 1.
        public static int CurrentPage;
        public static int MaxPages;

        //Variables to control Universal Syncing.
        public static int intSyncTimer;
        public static string stringSyncTimer;



        /// MINING.
        //Price Taken from BTC Summary Price to Calculate Profit for Worker.
        public static double UniversalBTCPrice;

        //Binding Data Source.
        public static BindingSource BindWallet = new BindingSource();


        //NICEHASH VARIABLES.
        public static List<string> NHWallets;
        public static string NewNHWallet;
        public static string[] NHWalletsA;
        public static string CurrentNHWallet;

        //Reading txtfile the line it is reading.
        public static string lineWorker;
        public static string lineNHAlgo;
        public static string lineHashRate;

        //Variables for sorting Nicehash API Data. | NH = Nicehash
        //NH Workers.
        public static string NHRelWorkers;
        public static string[] NHRelWorkersA;

        //NH Profitability.
        public static string NHProfitability;
        public static string NHRelProfit;
        public static string[] NHRelProfitA;

        //NH Algorithims.
        public static string NHActualAlgoS;
        public static int NHActualAlgoI;

        //NH Calculating Profit
        public static string NHCalcProfitRate;
        public static double NHCalcProfitBTCD;
        public static string NHCalcProfitBTC;
        public static string NHCalcProfitBTCM;
        public static string NHCalcProfitBTCY;



        //Universal Mining Variables.
        public static int WalletIndexChecker;
        public static string[] SepDATA;
        public static string WorkerID;
        public static string DATA;
        public static string SCurrentAlgo;
        public static string KeyCurrentAlgo;
        public static string Verified;
        public static double CurrentHashRate;
        public static double CurrentRejectRate;
        public static string SHashEnd;
        public static string SCurrentHashRate;
        public static string SCurrentRejectRate;
        public static double DEfficiency;
        public static string SEfficiency;
        public static double SUpTimeBeforeCalc;
        public static string WorkerIDCheck;
        public static int TimeIndexRemove;
        public static bool TimeCalc = false;

        //Used to Reset the UpTimeValues;
        public static string STimeDays = null;
        public static string STimeHours = null;
        public static string STimeMins = null;
        public static string STimeSeconds = null;

        //Recording Actual Profit.
        public static Dictionary<int, string> RealProfit = new Dictionary<int, string>();

        //List for Workers
        public static List<string> SepProfit = new List<string>();
        public static List<string> SepWorkers = new List<string>();
        public static List<string> RealWorkers = new List<string>();
        public static List<string> StartingMiningSettings = new List<string>();



        //ZPOOL Variables
        public static List<string> ZPWallets;
        public static string NewZPWallet;
        public static string[] ZPWalletsA;
        public static string CurrentZPWallet;


        public static string CURRENCY;
        public static int PublicCurrencyIndex;
        public static int PublicPeriodIndex;

        //Resetting Positions of Panels and Header.
        void Summary01RESET()
        {
            MainContainer.Controls.Clear();
            Reference.SummaryForm.TopLevel = false;
            Reference.SummaryForm.Size = new Size(842, 468);
            Reference.SummaryForm.AutoScroll = false;
            Reference.SummaryForm.Dock = DockStyle.Fill;
            MainContainer.Controls.Add(Reference.SummaryForm);
            SidebarTransition.Show(MainContainer);
            Reference.SummaryForm.Show();
            SummaryLoading = true;
            
        }
        void OptionsRESET()
        {
            MainContainer.Visible = false;
            MainContainer.Controls.Clear();
            Reference.OptionsForm.TopLevel = false;
            Reference.OptionsForm.Size = new Size(842, 468);
            Reference.OptionsForm.AutoScroll = false;
            Reference.OptionsForm.Dock = DockStyle.Fill;

            MainContainer.Controls.Add(Reference.OptionsForm);
            Reference.OptionsForm.Show();
            SidebarTransition.Show(MainContainer);
        }
        void MiningRESET()
        {
            Mining01.Location = new Point(222, 71);
            Mining01.Size = new Size(842, 468);
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
        //Checking and Creating Required Files
        void CreateMustFiles()
        {
            if (!File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Pages.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page0.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\TimeZone.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\TimePeriod.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Nicehash.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\ZPool.txt"))
            {
                Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile));
                Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining");
                Pages = Convert.ToString(pages);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Pages.txt", Pages);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt", Convert.ToString(0));
                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page0.txt", ProfileLoad);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt", Convert.ToString(0));
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\TimeZone.txt", Convert.ToString(0));
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\TimePeriod.txt", "USD ($)");
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Nicehash.txt", "");
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\ZPool.txt", "");
            }
        }


        private void Crypto_Load(object sender, EventArgs e)
        {
            ProfileLoaded = false;      //PLACEHOLDER. | Will Implement Guest Login Screen.
            Profile = 0;                //PLACEHOLDER. | Taken from Login Screen.
            CreateMustFiles();          //Make sure all required files exist.
            LoadProfile(Profile);       //Load Profile Number.
            TestCoinSummary();          //Test if txt file has valid coins and assign them to varaibles.
            Summary01RESET();           //Populate the Summary Page with Data.
            HeaderDefaultRESET();       //MOVE all Header properties to correct location.
            HeaderMiningRESET();        //MOVE all Mining Header propertities to correct location.
            HeaderDefault();            //HIDE all header properties except default ones.
            Reference.OptionsForm.PagevSelectedIndex = Convert.ToInt32(PageNumber);  //Setting Page Index to Saved Page Number on txt file.
            intSyncTimer = 31;          //On first countdown users sees it counting down from 30.
            lblSyncTimer.Location = new Point(789, 7);  // ** FIX **
            GETWallets();                                           //MINING | Gets All Wallet Info.
            GETPools();                                             //MINING | Gets All Available Pools.
            SetDefault();                                           //MINING | Set Default Worker Settings.
            Mining01.Visible = false;                               //Hide Mining Panel.
            Footer.Location = new Point(222, 539);
            this.Size = new Size(1064, 577);
            this.CenterToScreen();
            GETINFOSummary();                                 //Getting ALL API Information.
            GETWorkerInfo();                                  //Get ALL Relevant Mining Info
            Reference.OptionsForm.lblSaveFoundVisible = false;                    //Not Required on first startup.
            btnHome.selected = true;

            LoadingPanel.Controls.Clear();
            Reference.LoadingForm.TopLevel = true;
            Reference.LoadingForm.Size = new Size(842, 468);
            Reference.LoadingForm.AutoScroll = false;
            Reference.LoadingForm.Dock = DockStyle.Fill;
            LoadingPanel.Controls.Add(Reference.LoadingForm);
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
            PageNumber = Convert.ToString(Reference.OptionsForm.PagevSelectedIndex);     //Saves the Last Page the user was viewing.
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt", PageNumber);
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
            
            HideAll();
            Summary01RESET();
            HeaderDefault();
        }
        private void btnMining_Click(object sender, EventArgs e)
        {
            HideAll();
            bMining = true;
            Mining01.Visible = true;
            MiningRESET();
            HeaderDefault();

        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            HideAll();
            OptionsRESET();
            HeaderDefault();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            HideAll();
            bSummary = true;
            Summary01RESET();
            HeaderDefault();
        }

        //Function for Loading the Selected Profile.
        //ProfileNumber is sourced from LoginScreen.
        public void LoadProfile(double ProfileNumber)
        {
            try
            {
                StartingPeriod = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\TimePeriod.txt");
                StartingTimeZone = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\TimeZone.txt");
                StartingCurrency = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt");
                PageNumber = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt");
                Pages = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Pages.txt");
                CurrencyNumber = Convert.ToInt32(StartingCurrency);
                TimeZoneNumber = Convert.ToInt32(StartingTimeZone);
                PageCalculation = Convert.ToInt32(Pages);
                for (int i = 0; i < PageCalculation; i++)
                {
                    Reference.OptionsForm.PagevAddItem(new Item(Convert.ToString(pages), pages));      //Add Item to Combo Box based on txt file.
                    pages = pages + 1;                                              //Universal Way of Checking Current Page Number.
                    if (pages > PageCalculation)
                    {
                        pages = pages - 1;                                          //Pages is added before the end of the loop this ensures it is correct.
                    }

                }

                //Setting Correct Starting Index for Combo Boxes.
                if (CurrencyNumber == 0)
                {
                    Reference.OptionsForm.CurrencyvSelectedIndex = 0;
                    PublicCurrencyIndex = 0;
                    Reference.OptionsForm.TimePeriodvClear();
                    Reference.OptionsForm.TimePeriodvAddItem("USD ($)");
                    Reference.OptionsForm.TimePeriodvAddItem("BTC (Satoshi)");
                    Reference.OptionsForm.lblCurrencyPreviewSET = "XXX/USD";
                }
                else if (CurrencyNumber == 1)
                {
                    Reference.OptionsForm.CurrencyvSelectedIndex = 1;
                    PublicCurrencyIndex = 1;
                    Reference.OptionsForm.TimePeriodvClear();
                    Reference.OptionsForm.TimePeriodvAddItem("AUD ($)");
                    Reference.OptionsForm.TimePeriodvAddItem("BTC (Satoshi)");
                    Reference.OptionsForm.lblCurrencyPreviewSET = "XXX/AUD";
                }


                if (TimeZoneNumber == 0)
                {
                    Reference.OptionsForm.TimeZonevSelectedIndex = 0;
                }
                else if (TimeZoneNumber == 1)
                {
                    Reference.OptionsForm.TimeZonevSelectedIndex = 1;
                }

                if (StartingPeriod == "USD ($)")
                {
                    TimePeriodNumber = 0;
                }
                else if (StartingPeriod == "AUD ($)")
                {
                    TimePeriodNumber = 1;
                }
                else if (StartingPeriod == "BTC (Satoshi)")
                {
                    TimePeriodNumber = 2;
                }

                //Set all lines from txt file into Array
                //Set Custonm Coins to data taken from the Array
                ProfileCoinsLoaded = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page" + PageNumber + ".txt");
                coin1 = ProfileCoinsLoaded[0];
                coin2 = ProfileCoinsLoaded[1];
                coin3 = ProfileCoinsLoaded[2];
                coin4 = ProfileCoinsLoaded[3];
                coin5 = ProfileCoinsLoaded[4];
                coin6 = ProfileCoinsLoaded[5];
                coin7 = ProfileCoinsLoaded[6];
                coin8 = ProfileCoinsLoaded[7];
                coin9 = ProfileCoinsLoaded[8];
                Reference.OptionsForm.txtCustom01Text = coin1;
                Reference.OptionsForm.txtCustom02Text = coin2;
                Reference.OptionsForm.txtCustom03Text = coin3;
                Reference.OptionsForm.txtCustom04Text = coin4;
                Reference.OptionsForm.txtCustom05Text = coin5;
                Reference.OptionsForm.txtCustom06Text = coin6;
                Reference.OptionsForm.txtCustom07Text = coin7;
                Reference.OptionsForm.txtCustom08Text = coin8;
                Reference.OptionsForm.txtCustom09Text = coin9;
                TestCoinSummary();
                GETINFOSummary();
                ProfileLoaded = true;       //Make sure program understands profile loaded successfully. 
            }
            catch (Exception)
            {
                lblSync.Text = "Saving Error";
                lblSync.Visible = true;
            }
        }
        //Updating Header Page Number
        public void UpdatingCurrentPage()
        {
            CurrentPage = Reference.OptionsForm.PagevSelectedIndex + 1;
            lblCurrentPage.Text = "PAGE " + Convert.ToString(CurrentPage);
        }

        //Function for when Index Changes
        public void IndexChanged(int SelectedIndex)
        {
            //Ensures that it is reading from the correct index file.
            ProfileCoinsLoaded = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page" + Convert.ToString(SelectedIndex) + ".txt");
            coin1 = ProfileCoinsLoaded[0];
            coin2 = ProfileCoinsLoaded[1];
            coin3 = ProfileCoinsLoaded[2];
            coin4 = ProfileCoinsLoaded[3];
            coin5 = ProfileCoinsLoaded[4];
            coin6 = ProfileCoinsLoaded[5];
            coin7 = ProfileCoinsLoaded[6];
            coin8 = ProfileCoinsLoaded[7];
            coin9 = ProfileCoinsLoaded[8];
            Reference.OptionsForm.txtCustom01Text = coin1;
            Reference.OptionsForm.txtCustom02Text = coin2;
            Reference.OptionsForm.txtCustom03Text = coin3;
            Reference.OptionsForm.txtCustom04Text = coin4;
            Reference.OptionsForm.txtCustom05Text = coin5;
            Reference.OptionsForm.txtCustom06Text = coin6;
            Reference.OptionsForm.txtCustom07Text = coin7;
            Reference.OptionsForm.txtCustom08Text = coin8;
            Reference.OptionsForm.txtCustom09Text = coin9;
            TestCoinSummary();
            Reference.EaseMethodsO.HideConfirmationLabelsSave();
        }
        public void SelectedIndexChanged(int Index)
        {
            Reference.OptionsForm.lblMaxPagesVisible = false;
            if (Reference.OptionsForm.PagevSelectedIndex == Index)
            {
                try
                {
                    IndexChanged(Reference.OptionsForm.PagevSelectedIndex);      //Method that undergos the process of updating the coins from txt file.
                }
                catch (Exception)
                {
                    Reference.EaseMethodsO.EmptySummary();
                    TestCoinSummary();
                    GETINFOSummary();
                    Reference.EaseMethodsO.HideConfirmationLabelsNoSave();
                }
            }
        }

        //Confirming New Coin Inputs.
        public void ConfirmOptionCoins()
        {
            if (ProfileLoaded != true)
            {
                SetConfirmationSummary();
            }
        }
        //Set Coin Variables to Inputted Coins.
        public void SetConfirmationSummary()
        {
            coin1 = Reference.OptionsForm.txtCustom01Text;
            coin2 = Reference.OptionsForm.txtCustom02Text;
            coin3 = Reference.OptionsForm.txtCustom03Text;
            coin4 = Reference.OptionsForm.txtCustom04Text;
            coin5 = Reference.OptionsForm.txtCustom05Text;
            coin6 = Reference.OptionsForm.txtCustom06Text;
            coin7 = Reference.OptionsForm.txtCustom07Text;
            coin8 = Reference.OptionsForm.txtCustom08Text;
            coin9 = Reference.OptionsForm.txtCustom09Text;
        }
        //Saved Essential Data to txtfile based on Profile Number;
        public void SaveProfile()
        {
            ProfileLoad[0] = coin1;
            ProfileLoad[1] = coin2;
            ProfileLoad[2] = coin3;
            ProfileLoad[3] = coin4;
            ProfileLoad[4] = coin5;
            ProfileLoad[5] = coin6;
            ProfileLoad[6] = coin7;
            ProfileLoad[7] = coin8;
            ProfileLoad[8] = coin9;
            PageNumber = Convert.ToString(Reference.OptionsForm.PagevSelectedIndex);
            Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile));
            File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page" + PageNumber + ".txt", ProfileLoad);
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt", PageNumber);
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
        void GETINFOSummary()
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
                else if (bMining == true)
                {
                    if (Reference.OptionsForm.HeaderPoolvText == "NICEHASH")
                    {
                        GETNHWorkerRefresh();
                    }
                    GETWorkerInfo();
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

        //TESTING NEW COIN INPUTS 
        public void TestCoinSummary()
        {
            ConfirmOptionCoins();
            TestOptionCoins(ref coin1, ref coin1FN);
            TestOptionCoins(ref coin2, ref coin2FN);
            TestOptionCoins(ref coin3, ref coin3FN);
            TestOptionCoins(ref coin4, ref coin4FN);
            TestOptionCoins(ref coin5, ref coin5FN);
            TestOptionCoins(ref coin6, ref coin6FN);
            TestOptionCoins(ref coin7, ref coin7FN);
            TestOptionCoins(ref coin8, ref coin8FN);
            TestOptionCoins(ref coin9, ref coin9FN);
        }
        //LOGIC BEHIND ALLOCATING NEW STRING FOR INPUTTED CUSTOM COIN
        public void TestOptionCoins(ref string RealCoin, ref string RealCoinFN)
        {
            try
            {
                double counting = 0;

                Coins = JsonConvert.DeserializeObject<List<MarketCap>>(EaseMethods.API(@"https://api.coinmarketcap.com/v1/ticker/?start=0&limit=0"));
                if (RealCoin.ToUpper() == "BTC" || RealCoin.ToUpper() == "BITCOIN")    
                {
                    RealCoin = "BTC";
                    RealCoinFN = "bitcoin";
                }
                else if (RealCoin == "")
                {
                    RealCoin = "";
                    RealCoinFN = "";
                }
                else
                {
                    foreach (var coin in Coins)
                    {
                        counting = counting + 1;
                        if (coin.name.ToUpper() == RealCoin.ToUpper())
                        {
                            RealCoin = coin.symbol;
                            RealCoinFN = coin.id.ToLower();
                            break;
                        }
                        else if (coin.symbol == RealCoin.ToUpper())
                        {
                            RealCoin = coin.symbol;
                            RealCoinFN = coin.id;
                            break;
                        }
                        else if (counting == 1545)      //MAX COINS IN API READER
                        {
                            RealCoin = "";
                            RealCoinFN = "";
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                lblSync.Text = "Coin Error";
                lblSync.Visible = true;
            }

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
                MaxPages = Convert.ToInt32(Pages);
                MaxPages = MaxPages - 1;
                if (Reference.OptionsForm.PagevSelectedIndex != MaxPages)
                {
                    btnPageRight.Enabled = true;
                    Reference.OptionsForm.PagevSelectedIndex = Reference.OptionsForm.PagevSelectedIndex + 1;
                    UpdatingCurrentPage();
                }
            }
        }




        //MINING
        public void SetDefault()
        {
            StartingMiningSettings.Clear();
            if (!File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Default.txt"))
            {
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Default.txt", "EMPTY");
                Reference.OptionsForm.HeaderPoolvText = "";
                Reference.OptionsForm.HeaderWorkervText = "SELECT A POOL";
                Reference.OptionsForm.HeaderMiningCurrencyvText = "";
            }
            else
            {
                StartingMiningSettings = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Default.txt").ToList();
                string test = StartingMiningSettings[0];
                if (test == "EMPTY")
                {
                    Reference.OptionsForm.HeaderPoolvText = "";
                    Reference.OptionsForm.HeaderWorkervText = "SELECT A POOL";
                    Reference.OptionsForm.HeaderMiningCurrencyvText = "";
                }
                else
                {
                    Reference.OptionsForm.HeaderPoolvText = StartingMiningSettings[0];
                    Reference.OptionsForm.HeaderWorkervText = StartingMiningSettings[1];
                    Reference.OptionsForm.HeaderMiningCurrencyvSelectedIndex = Convert.ToInt32(StartingMiningSettings[2]);
                }
            }
        }
        public void GETWallets()
        {
            NHWallets = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Nicehash.txt").ToList();
            NHWalletsA = NHWallets.ToArray();
            BindWallet.DataSource = NHWalletsA;
            Reference.OptionsForm.OptionsNHWalletsvDataSource();
            CurrentNHWallet = Reference.OptionsForm.OptionsNHWalletsvText;

            ZPWallets = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\ZPool.txt").ToList();
            ZPWalletsA = ZPWallets.ToArray();
            BindWallet.DataSource = ZPWalletsA;
            Reference.OptionsForm.OptionsZPWalletsvDataSource();
            CurrentZPWallet = Reference.OptionsForm.OptionsZPWalletsvText;

        }
        public void GETPools()
        {
            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Nicehash.txt"))
            {
                if (Reference.OptionsForm.HeaderWorkervContainsNH) { }
                else
                {
                    Reference.OptionsForm.HeaderPoolvAddItem("NICEHASH");
                }
            }
            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\ZPool.txt"))
            {
                if (Reference.OptionsForm.HeaderWorkervContainsZP) { }
                else
                {
                    Reference.OptionsForm.HeaderPoolvAddItem("ZPOOL");
                }
            }
        }
        public void GETNHWorkerRefresh()
        {
            string url = @"https://api.nicehash.com/api?method=stats.provider.workers&addr=" + CurrentNHWallet;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                lineWorker = reader.ReadToEnd();
                NHRelWorkers = getBetween(lineWorker, ":[", "\"algo");
                NHRelWorkersA = Regex.Split(NHRelWorkers, "],");
                SepWorkers = NHRelWorkersA.OfType<string>().ToList();
                for (int x = 0; x < SepWorkers.Count; x++)
                {
                    if (SepWorkers[x] != "")
                    {
                        WorkerID = SepWorkers[x];
                        WorkerID = EaseMethods.RemoveforMiningKeepingCurly(WorkerID);
                        int RemoveA = WorkerID.LastIndexOf("{");
                        if (RemoveA > 0)
                        {
                            WorkerID = WorkerID.Substring(0, RemoveA);
                        }
                        else if (RemoveA == 0)
                        {
                            WorkerID = "EMPTY";
                        }
                        if (bMining == false)
                        {
                            Reference.OptionsForm.HeaderWorkervAddItem(WorkerID);
                            RealWorkers.Add(WorkerID);
                        }
                    }
                    else if (SepWorkers[x] == "")
                    {
                        break;
                    }

                }
            }
        }
        public void GETWorkers()
        {
            Reference.OptionsForm.HeaderWorkervClear();
            
            if (Reference.OptionsForm.HeaderPoolvText == "NICEHASH")
            {
                GETNHWorkerRefresh();
            }
        }
        public void WorkerTimeCalculation()
        {
            if (SUpTimeBeforeCalc == 0)
            {
                lblWorkerUpTimev.Text = "Just Started";
            }
            else
            {
                while (TimeCalc == false)
                {
                    if ((SUpTimeBeforeCalc / 86400) < 1 && STimeDays == null)
                    {
                        STimeDays = "";
                    }
                    else if ((SUpTimeBeforeCalc / 86400) >= 1 && STimeDays == null)
                    {
                        STimeDays = Convert.ToString(SUpTimeBeforeCalc / 86400);
                        STimeDays = EaseMethods.RemoveAfterLetter(STimeDays, ".");
                        STimeDays = " " + STimeDays + "D";
                    }
                    else if ((SUpTimeBeforeCalc / 3600) < 1 && STimeHours == null)
                    {
                        STimeHours = "";
                    }
                    else if ((SUpTimeBeforeCalc / 3600) >= 1 && STimeHours == null)
                    {
                        if (SUpTimeBeforeCalc / 3600 > 24)
                        {
                            STimeHours = Convert.ToString((SUpTimeBeforeCalc / 3600) - 24);
                            STimeHours = EaseMethods.RemoveAfterLetter(STimeHours, ".");
                            STimeHours = " " + STimeHours + "H";
                        }
                        else
                        {
                            STimeHours = Convert.ToString(SUpTimeBeforeCalc / 3600);
                            STimeHours = EaseMethods.RemoveAfterLetter(STimeHours, ".");
                            STimeHours = " " + STimeHours + "H";
                        }
                    }
                    else if (((SUpTimeBeforeCalc / 60) % 60) < 1 && STimeMins == null)
                    {
                        STimeMins = "";
                    }
                    else if (((SUpTimeBeforeCalc / 60) % 60) >= 1 && STimeMins == null)
                    {
                        STimeMins = Convert.ToString((SUpTimeBeforeCalc / 60) % 60);
                        STimeMins = EaseMethods.RemoveAfterLetter(STimeMins, ".");
                        STimeMins = " " + STimeMins + "M";
                    }
                    else if ((SUpTimeBeforeCalc % 60) < 1 && STimeSeconds == null)
                    {
                        STimeSeconds = "";
                    }
                    else if ((SUpTimeBeforeCalc % 60) >= 1 && STimeSeconds == null)
                    {
                        STimeSeconds = Convert.ToString(SUpTimeBeforeCalc % 60);
                        STimeSeconds = EaseMethods.RemoveAfterLetter(STimeSeconds, ".");
                        STimeSeconds = " " + STimeSeconds + "S";
                    }
                    else
                    {
                        TimeCalc = true;
                    }
                }
                lblWorkerUpTimev.Text = STimeDays + STimeHours + STimeMins + STimeSeconds;
            }
        }
        
        public void GETWorkerInfoNH()
        {
            lblWorkerIDv.Text = WorkerID;

            SUpTimeBeforeCalc = SUpTimeBeforeCalc * 60;
            WorkerTimeCalculation();

            if (Verified == "1")
            {
                lblWorkerVerifiedv.Text = "YES";
                lblWorkerVerifiedv.ForeColor = Color.LightGreen;
            }
            else if (Verified == "0")
            {
                lblWorkerVerifiedv.Text = "NO";
                lblWorkerVerifiedv.ForeColor = Color.Red;
            }

            StreamReader NHAlgoReader = new StreamReader(@"Resources\NHAlgo.txt");
            {
                while ((lineNHAlgo = NHAlgoReader.ReadLine()) != null)
                {
                    if (lineNHAlgo.Contains(KeyCurrentAlgo))
                    {
                        SCurrentAlgo = lineNHAlgo;
                        SCurrentAlgo = getBetween(SCurrentAlgo, ": \"", "\"");
                        break;
                    }
                }
            }

            StreamReader HashRateReader = new StreamReader(@"Resources\HashRates.txt");
            {
                while ((lineHashRate = HashRateReader.ReadLine()) != null)
                {
                    if (lineHashRate.Contains(SCurrentAlgo))
                    {
                        SHashEnd = lineHashRate;
                        SHashEnd = getBetween(SHashEnd, ": \"", "\"");
                        break;
                    }
                }
            }

            SCurrentHashRate = Convert.ToString(CurrentHashRate) + " " + SHashEnd;
            lblWorkerHashv.Text = SCurrentHashRate;
            lblWorkerAlgov.Text = SCurrentAlgo;
            lblWorkerAddress.Text = CurrentNHWallet;
        }
        public void GETWorkerNHReject()
        {
            DEfficiency = CurrentRejectRate / CurrentHashRate;
            DEfficiency = DEfficiency * 100;
            DEfficiency = Math.Round(DEfficiency, 0);
            DEfficiency = 100 - DEfficiency;


            GETWorkerInfoNH();

            SCurrentRejectRate = Convert.ToString(CurrentRejectRate) + " " + SHashEnd;
            lblWorkerRejectv.Text = SCurrentRejectRate;

            SEfficiency = Convert.ToString(DEfficiency) + "%";
            lblWorkerEfficiencyv.Text = SEfficiency;
            lblWorkerEfficiencyv.ForeColor = Color.Red;
        }
        public void GETWorkerNHProfit()
        {
            RealProfit.Clear();

            string url = @"https://api.nicehash.com/api?method=stats.provider.ex&addr=" + CurrentNHWallet;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                lineWorker = reader.ReadToEnd();
                NHRelProfit = getBetween(lineWorker, ":[", "],\"nh_wallet");
                NHRelProfitA = Regex.Split(NHRelProfit, "},{");
                SepProfit = NHRelProfitA.OfType<string>().ToList();
                for (int x = 0; x < SepProfit.Count; x++)
                {
                    if (SepProfit[x] != "")
                    {
                        NHProfitability = SepProfit[x];
                        NHActualAlgoS = SepProfit[x];
                        NHProfitability = getBetween(NHProfitability, "profitability", ",\"data");
                        NHProfitability = EaseMethods.RemoveExtraText(NHProfitability);

                        NHActualAlgoS = EaseMethods.RemoveonlyCurly(NHActualAlgoS);
                        NHActualAlgoS = NHActualAlgoS + "}";
                        NHActualAlgoS = getBetween(NHActualAlgoS, "algo", "}");
                        NHActualAlgoS = EaseMethods.RemoveExtraText(NHActualAlgoS);
                        NHActualAlgoI = Convert.ToInt32(NHActualAlgoS);

                        RealProfit.Add(NHActualAlgoI, NHProfitability);
                    }
                    else if (SepProfit[x] == "")
                    {
                        break;
                    }

                }
            }
        }
        public void GETWorkerCalcProfit()
        {
            NHCalcProfitRate = RealProfit[Convert.ToInt32(SepDATA[5])];
            NHCalcProfitBTCD = Math.Round(Convert.ToDouble(NHCalcProfitRate) * CurrentHashRate, 8);
            if (Reference.OptionsForm.HeaderMiningCurrencyvSelectedIndex == 0)
            {
                lblProfitv.Text = Convert.ToString(NHCalcProfitBTCD);
                lblProfitMv.Text = Convert.ToString(Math.Round(NHCalcProfitBTCD * 30.4167, 8));
                lblProfitYv.Text = Convert.ToString(Math.Round(NHCalcProfitBTCD * 365, 8));
                lblProfit.Text = "BTC/DAY";
                lblProfitM.Text = "BTC/MONTH";
                lblProfitY.Text = "BTC/YEAR";
            }
            else if (Reference.OptionsForm.HeaderMiningCurrencyvSelectedIndex == 1)
            {
                lblProfitv.Text = "$" + string.Format("{0:#,0.00}", NHCalcProfitBTCD * UniversalBTCPrice);
                lblProfitMv.Text = "$" + string.Format("{0:#,0.00}", (NHCalcProfitBTCD * 30.4167) * UniversalBTCPrice);
                lblProfitYv.Text = "$" + string.Format("{0:#,0.00}", (NHCalcProfitBTCD * 365) * UniversalBTCPrice);
                lblProfit.Text = "USD/DAY";
                lblProfitM.Text = "USD/MONTH";
                lblProfitY.Text = "USD/YEAR";
            }
        }
        public void HideMiningLogos()
        {
            MiningNH.Visible = false;
            MiningZPOOL.Visible = false;
        }
        public void GETWorkerInfo()
        {
            HideMiningLogos();
            STimeDays = null;
            STimeHours = null;
            STimeMins = null;
            STimeSeconds = null;
            TimeCalc = false;
            WorkerID = Reference.OptionsForm.HeaderWorkervText;

            if (Reference.OptionsForm.HeaderPoolvText == "NICEHASH")
            {
                MiningNH.Location = new Point(26, 30);
                MiningNH.Visible = true;

                for (int x = 0; x < SepWorkers.Count; x++)
                {
                    WorkerID = SepWorkers[x];
                    WorkerID = EaseMethods.RemoveforMiningKeepingCurly(WorkerID);
                    int RemoveA = WorkerID.LastIndexOf("{");
                    if (RemoveA > 0)
                    {
                        WorkerID = WorkerID.Substring(0, RemoveA);
                    }
                    else if (RemoveA == 0)
                    {
                        WorkerID = "EMPTY";
                    }

                    if (WorkerID == Reference.OptionsForm.HeaderWorkervText)
                    {
                        DATA = SepWorkers[x];
                        try
                        {
                            char last = DATA[DATA.Length - 1];
                            if (last != ']')
                            {
                                DATA = DATA + "]";
                            }
                        }
                        catch (Exception)
                        {
                            
                        }
                        break;
                    }
                }

                DATA = getBetween(DATA, ",{\"", "]");
                DATA = EaseMethods.RemoveExtraText(DATA);
                WorkerIDCheck = EaseMethods.RemoveCommas(DATA);
                SepDATA = DATA.Split(',');

                GETWorkerNHProfit();

                if (SepDATA.Length == 6)
                {
                    //Setting Array Values to Variables
                    CurrentHashRate = Convert.ToDouble(SepDATA[0]);
                    SUpTimeBeforeCalc = Convert.ToDouble(SepDATA[1]);
                    Verified = SepDATA[2];
                    lblWorkerDifficultyv.Text = SepDATA[3];
                    KeyCurrentAlgo = "\"" + SepDATA[5] + "\"";

                    //Use New Variables to Calculate Displayable Data
                    GETWorkerInfoNH();

                    //Set Leftover Labels
                    lblWorkerRejectv.Text = "0 " + SHashEnd;
                    lblWorkerEfficiencyv.Text = "100%";
                    lblWorkerEfficiencyv.ForeColor = Color.LightGreen;

                    //Calculate Profitability
                    GETWorkerCalcProfit();
                }
                else if (SepDATA.Length == 7)
                {
                    //Setting Array Values to Variables
                    CurrentHashRate = Convert.ToDouble(SepDATA[0]);
                    CurrentRejectRate = Convert.ToDouble(SepDATA[1]);
                    SUpTimeBeforeCalc = Convert.ToDouble(SepDATA[2]);
                    Verified = SepDATA[3];
                    lblWorkerDifficultyv.Text = SepDATA[4];
                    KeyCurrentAlgo = "\"" + SepDATA[6] + "\"";

                    //Use New Variables Including Rejected Speed | Set Labels 
                    GETWorkerNHReject();
                }
                else if (SepDATA.Length == 8)
                {
                    //Setting Array Values to Variables
                    CurrentHashRate = Convert.ToDouble(SepDATA[0]);
                    CurrentRejectRate = Convert.ToDouble(SepDATA[1]) + Convert.ToDouble(SepDATA[2]);
                    SUpTimeBeforeCalc = Convert.ToDouble(SepDATA[3]);
                    Verified = SepDATA[4];
                    lblWorkerDifficultyv.Text = SepDATA[5];
                    KeyCurrentAlgo = "\"" + SepDATA[7] + "\"";

                    //Use New Variables Including Rejected Speed | Set Labels 
                    GETWorkerNHReject();

                    //Calculate Profitability
                    GETWorkerCalcProfit();
                }
                else if (SepDATA.Length == 9)
                {
                    //Setting Array Values to Variables
                    CurrentHashRate = Convert.ToDouble(SepDATA[0]);
                    CurrentRejectRate = Convert.ToDouble(SepDATA[1]) + Convert.ToDouble(SepDATA[2]) + Convert.ToDouble(SepDATA[3]);
                    SUpTimeBeforeCalc = Convert.ToDouble(SepDATA[3]);
                    Verified = SepDATA[5];
                    lblWorkerDifficultyv.Text = SepDATA[6];
                    KeyCurrentAlgo = "\"" + SepDATA[8] + "\"";

                    //Use New Variables Including Rejected Speed | Set Labels 
                    GETWorkerNHReject();

                    //Calculate Profitability
                    GETWorkerCalcProfit();
                }
                else if (SepDATA.Length == 10)
                {
                    //Setting Array Values to Variables
                    CurrentHashRate = Convert.ToDouble(SepDATA[0]);
                    CurrentRejectRate = Convert.ToDouble(SepDATA[1]) + Convert.ToDouble(SepDATA[2]) + Convert.ToDouble(SepDATA[3]) + Convert.ToDouble(SepDATA[4]);
                    SUpTimeBeforeCalc = Convert.ToDouble(SepDATA[4]);
                    Verified = SepDATA[6];
                    lblWorkerDifficultyv.Text = SepDATA[7];
                    KeyCurrentAlgo = "\"" + SepDATA[9] + "\"";

                    //Use New Variables Including Rejected Speed | Set Labels 
                    GETWorkerNHReject();

                    //Calculate Profitability
                    GETWorkerCalcProfit();
                }
                else
                {
                    //If Nicehash API is Updated this Formula could potentially break
                    MessageBox.Show("NICEHASH API IS DELAYED - PLEASE TRY AGAIN LATER");
                    lblWorkerIDv.Text = "No Data";
                    lblWorkerAlgov.Text = "No Data";
                    lblWorkerDifficultyv.Text = "No Data";
                    lblWorkerUpTimev.Text = "No Data";
                    lblWorkerVerifiedv.Text = "No Data";
                    lblWorkerVerifiedv.ForeColor = Color.Black;
                    lblWorkerEfficiencyv.Text = "No Data";
                    lblWorkerEfficiencyv.ForeColor = Color.Black;
                    lblWorkerHashv.Text = "No Data";
                    lblWorkerRejectv.Text = "No Data";
                    lblProfitv.Text = "No Data";
                }
            }
            SYNCED = true;
        }
        public string getBetween(string strSource, string strStart, string strEnd)
        {
            try
            {
                int Start, End;
                if (strSource.Contains(strStart) && strSource.Contains(strEnd))
                {
                    Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                    End = strSource.IndexOf(strEnd, Start);
                    return strSource.Substring(Start, End - Start);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
            
        }

        private void MiningNH_Click(object sender, EventArgs e)
        {

        }

        private void SidebarTransition_AllAnimationsCompleted(object sender, EventArgs e)
        {
            MainContainer.Visible = true;
        }
    }
}
