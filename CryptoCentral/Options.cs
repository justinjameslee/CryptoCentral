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

namespace CryptoCentral
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
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

        public bool ConfirmAllowed = false;

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
        public static bool ProfileLoaded = false;
        public static bool NewSave;

        //Profile Number    | Work In Progress - Comes from Login Screen.
        public static double Profile;

        //Storing Inputed Coins in an array | New profile ready.
        public static string[] ProfileLoad = { "BTC", "", "", "", "", "", "", "", "", "" };
        public static string[] ProfileCoinsLoaded = new string[10];

        public static string CURRENCY;
        public static int PublicCurrencyIndex;
        public static int PublicPeriodIndex;

        //Creating Lists for JSON.
        public static List<MarketCap> Coins;
        public static List<MarketCap> CoinsDetailed;

        //Binding Data Source.
        public static BindingSource BindWallet = new BindingSource();

        private void Options_Load(object sender, EventArgs e)
        {
            
        }

        //Checking and Creating Required Files
        public static void CreateMustFiles()
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

        //SETTINGS BUTTON FUNCTIONS
        //CUT DOWN ON LINES OF CODE
        public static void EditSummaryIndividual(TextBox Custom)
        {
            Custom.ReadOnly = false;
            Custom.BackColor = Color.White;
        }
        //REPEAT ABOVE FUNCTION FOR ALL CUSTOM COINS
        public void EditSummary()
        {
            EditSummaryIndividual(txtCustom01);
            EditSummaryIndividual(txtCustom02);
            EditSummaryIndividual(txtCustom03);
            EditSummaryIndividual(txtCustom04);
            EditSummaryIndividual(txtCustom05);
            EditSummaryIndividual(txtCustom06);
            EditSummaryIndividual(txtCustom07);
            EditSummaryIndividual(txtCustom08);
            EditSummaryIndividual(txtCustom09);
            ProfileLoaded = false;
            ConfirmAllowed = true;
        }

        //CUT DOWN ON LINES OF CODE
        public static void EmptySummaryIndividual(TextBox Custom)
        {
            Custom.ReadOnly = false;
            Custom.BackColor = Color.White;
            Custom.Text = "";
        }
        //REPEAT ABOVE FUNCTION FOR ALL CUSTOM COINS
        public void EmptySummary()
        {
            EmptySummaryIndividual(txtCustom01);
            EmptySummaryIndividual(txtCustom02);
            EmptySummaryIndividual(txtCustom03);
            EmptySummaryIndividual(txtCustom04);
            EmptySummaryIndividual(txtCustom05);
            EmptySummaryIndividual(txtCustom06);
            EmptySummaryIndividual(txtCustom07);
            EmptySummaryIndividual(txtCustom08);
            EmptySummaryIndividual(txtCustom09);
            TestCoinSummary();
            Reference.SummaryForm.GETINFOSummary();
        }

        //CUT DOWN ON LINES OF CODE
        public static void ConfirmSummaryIndividual(TextBox Custom)
        {
            Custom.BackColor = Color.WhiteSmoke;
            Custom.ReadOnly = true;
        }
        //REPEAT ABOVE FUNCTION FOR ALL CUSTOM COINS
        public void ConfirmSummary()
        {
            while (ConfirmAllowed == true)
            {
                ConfirmSummaryIndividual(txtCustom01);
                ConfirmSummaryIndividual(txtCustom02);
                ConfirmSummaryIndividual(txtCustom03);
                ConfirmSummaryIndividual(txtCustom04);
                ConfirmSummaryIndividual(txtCustom05);
                ConfirmSummaryIndividual(txtCustom06);
                ConfirmSummaryIndividual(txtCustom07);
                ConfirmSummaryIndividual(txtCustom08);
                ConfirmSummaryIndividual(txtCustom09);
                lblConfirmed.Visible = true;
                TestCoinSummary();
                Reference.SummaryForm.GETINFOSummary();
                ConfirmAllowed = false;
            }
        }

        private void Pagev_SelectedIndexChanged(object sender, EventArgs e)
        {

            Reference.CryptoForm.SyncingTest();      //Show that new data is being processed.
            if (NewSave == true)        //Check if this was caused by a new page creation.
            {
                lblNoSaveVisible = false;
                lblNewPageText = "New Page Created";
                lblNewPageVisible = true;
                NewSave = false;
            }
            else
            {
                SelectedIndexChanged(PagevSelectedIndex);      //Update the data with new txt file coins based on page index.
                Reference.CryptoForm.UpdatingCurrentPage();                          //Updates Header Page Number.
            }
            Reference.CryptoForm.btnPageLeft.Image = Image.FromFile(@"C:\Users\" + Environment.UserName + @"\Documents\GitHub\CryptoCentral\Images\left-arrow-still-24px.png");
            Reference.CryptoForm.btnPageRight.Image = Image.FromFile(@"C:\Users\" + Environment.UserName + @"\Documents\GitHub\CryptoCentral\Images\right-arrow-still-24px.png");
        }
        private void Currencyv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrencyvSelectedIndex == 0)
            {
                CurrencyvSelectedIndex = 0;
                PublicCurrencyIndex = 0;
                TimePeriodvClear();
                TimePeriodvAddItem("USD ($)");
                TimePeriodvAddItem("BTC (Satoshi)");
                lblCurrencyPreviewSET = "XXX/USD";
            }
            else if (CurrencyvSelectedIndex == 1)
            {
                CurrencyvSelectedIndex = 1;
                PublicCurrencyIndex = 1;
                TimePeriodvClear();
                TimePeriodvAddItem("AUD ($)");
                TimePeriodvAddItem("BTC (Satoshi)");
                lblCurrencyPreviewSET = "XXX/AUD";
            }
            Reference.CryptoForm.SyncingTest();      //Refreshs Data.
            lblDefaultSetVisible = false;
        }
        private void Timezonev_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TimeZonevSelectedIndex == 0)
            {
                TimeZoneNumber = 0;
            }
            else if (TimeZonevSelectedIndex == 1)
            {
                TimeZoneNumber = 1;
            }

            Reference.CryptoForm.SyncingTest();      //Refreshes Data.
            lblTimeSetVisible = false;
        }
        private void TimePeriodCurrencyv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TimePeriodvText == "USD ($)")
            {
                TimePeriodNumber = 0;
            }
            else if (TimePeriodvText == "AUD ($)")
            {
                TimePeriodNumber = 1;
            }
            else if (TimePeriodvText == "BTC (Satoshi)")
            {
                TimePeriodNumber = 2;
            }

            Reference.CryptoForm.SyncingTest();
        }

        private void HeaderPoolv_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reference.WorkerForm.GETWorkers();
        }

        private void HeaderWorkerv_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reference.WorkerForm.GETWorkerInfo();
        }

        private void OptionsNHWalletsv_SelectedIndexChanged(object sender, EventArgs e)
        {
            Worker.CurrentNHWallet = OptionsNHWalletsv.Text;
            Reference.WorkerForm.GETWorkers();
        }

        private void OptionsZPWalletsv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HeaderMiningCurrencyv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HeaderWorkervText != "")
            {
                Reference.WorkerForm.GETWorkerInfo();
            }
        }

        private void btnOptionsZPSave_Click(object sender, EventArgs e)
        {
            OptionsMiningClick(lblZPWalletSaved, lblZPWalletSaved, lblZPDefaultSet, lblZPRemove, lblZPClear, txtOptionsZPv, Worker.ZPWallets, Worker.NewZPWallet, "ZPool");
            Reference.WorkerForm.GETPools();
        }

        private void btnOptionsZPDefault_Click(object sender, EventArgs e)
        {
            OptionsMiningClick(lblZPDefaultSet, lblZPWalletSaved, lblZPDefaultSet, lblZPRemove, lblZPClear, txtOptionsZPv, Worker.ZPWallets, Worker.NewZPWallet, "ZPool");
            Reference.WorkerForm.GETPools();
        }

        private void btnOptionsZPRemove_Click(object sender, EventArgs e)
        {
            OptionsMiningClick(lblZPRemove, lblZPWalletSaved, lblZPDefaultSet, lblZPRemove, lblZPClear, txtOptionsZPv, Worker.ZPWallets, Worker.NewZPWallet, "ZPool");
        }

        private void btnOptionsZPClear_Click(object sender, EventArgs e)
        {
            OptionsMiningClick(lblZPClear, lblZPWalletSaved, lblZPDefaultSet, lblZPRemove, lblZPClear, txtOptionsZPv, Worker.ZPWallets, Worker.NewZPWallet, "ZPool");
        }
        private void btnOptionsNHSave_Click(object sender, EventArgs e)
        {
            OptionsMiningClick(lblNHWalletSaved, lblNHWalletSaved, lblNHDefaultSet, lblNHRemove, lblNHClear, txtOptionsNHv, Worker.NHWallets, Worker.NewNHWallet, "Nicehash");
            Reference.WorkerForm.GETPools();
        }
        private void btnOptionsNHDefault_Click(object sender, EventArgs e)
        {
            OptionsMiningClick(lblNHDefaultSet, lblNHWalletSaved, lblNHDefaultSet, lblNHRemove, lblNHClear, txtOptionsNHv, Worker.NHWallets, Worker.NewNHWallet, "Nicehash");
            Reference.WorkerForm.GETPools();
        }

        private void btnOptionsNHRemove_Click(object sender, EventArgs e)
        {
            OptionsMiningClick(lblNHRemove, lblNHWalletSaved, lblNHDefaultSet, lblNHRemove, lblNHClear, txtOptionsNHv, Worker.NHWallets, Worker.NewNHWallet, "Nicehash");
        }

        private void btnOptionsNHClear_Click(object sender, EventArgs e)
        {
            OptionsMiningClick(lblNHClear, lblNHWalletSaved, lblNHDefaultSet, lblNHRemove, lblNHClear, txtOptionsNHv, Worker.NHWallets, Worker.NewNHWallet, "Nicehash");
        }

        void OptionsMiningClick(Label lblCheck, Label WalletSaved, Label DefaultSet, Label Remove, Label Clear, TextBox Input, List<string> Wallets, string NewWallet, string Pool)
        {
            WalletSaved.Visible = false;
            DefaultSet.Visible = false;
            Remove.Visible = false;
            Clear.Visible = false;
            Wallets = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\" + Pool + ".txt").ToList();
            NewWallet = Input.Text;
            if (lblCheck.Name == Clear.Name)
            {
                DialogResult Result = MessageBox.Show("ARE YOU SURE?", "Confirmation", MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    Worker.NHWallets.Clear();
                    File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\" + Pool + ".txt", Wallets);
                    lblCheck.Text = "WALLETS CLEARED";
                    lblCheck.Visible = true;
                    Reference.WorkerForm.GETWallets();
                }
            }
            else
            {
                if (NewWallet.Length < 25 || NewWallet.Length > 34)
                {
                    lblCheck.Text = "INVALID BITCOIN ADDRESS";
                    lblCheck.Visible = true;
                }
                else
                {
                    Worker.WalletIndexChecker = Wallets.FindIndex(x => x.StartsWith(NewWallet));
                    bool WalletDuplicate = Wallets.Contains(NewWallet);
                    if (WalletDuplicate != true)
                    {
                        if (NewWallet != "")
                        {
                            if (lblCheck.Name == DefaultSet.Name)
                            {
                                Wallets.Insert(0, NewWallet);
                                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\" + Pool + ".txt", Wallets);
                                lblCheck.Text = "DEFAULT SET";
                                lblCheck.Visible = true;
                                Input.Text = "";
                                Reference.WorkerForm.GETWallets();
                            }
                            else if (lblCheck.Name == WalletSaved.Name)
                            {
                                Wallets.Add(NewWallet);
                                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\" + Pool + ".txt", Wallets);
                                lblCheck.Text = "WALLET SAVED";
                                lblCheck.Visible = true;
                                Input.Text = "";
                                Reference.WorkerForm.GETWallets();
                            }
                            else if (lblCheck.Name == Remove.Name)
                            {
                                lblCheck.Text = "CANNOT REMOVE NEW WALLET";
                                lblCheck.Visible = true;
                                Input.Text = "";
                            }
                        }
                        else
                        {
                            lblCheck.Text = "INPUT IS EMPTY";
                            lblCheck.Visible = true;
                        }
                    }
                    else if (lblCheck.Name == DefaultSet.Name && Worker.WalletIndexChecker == 0)
                    {
                        lblCheck.Text = "ALREADY SET TO DEFAULT";
                        lblCheck.Visible = true;
                        Input.Text = "";
                    }
                    else if (lblCheck.Name == DefaultSet.Name)
                    {
                        if (NewWallet != "")
                        {
                            if (lblCheck.Name == DefaultSet.Name)
                            {
                                Wallets.Remove(NewWallet);
                                Wallets.Insert(0, NewWallet);
                                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\" + Pool + ".txt", Wallets);
                                lblCheck.Text = "DEFAULT SET";
                                lblCheck.Visible = true;
                                Input.Text = "";
                                Reference.WorkerForm.GETWallets();
                            }
                            else
                            {
                                lblCheck.Text = "INPUT IS EMPTY";
                                lblCheck.Visible = true;
                            }
                        }
                    }
                    else if (lblCheck.Name == WalletSaved.Name)
                    {
                        lblCheck.Text = "WALLET ALREADY SAVED";
                        lblCheck.Visible = true;
                        Input.Text = "";
                    }
                    else if (lblCheck.Name == Remove.Name)
                    {
                        Wallets.Remove(NewWallet);
                        File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\" + Pool + ".txt", Wallets);
                        lblCheck.Text = "WALLET REMOVED";
                        lblCheck.Visible = true;
                        Input.Text = "";
                        Reference.WorkerForm.GETWallets();
                    }
                }
            }
        }

        private void btnMiningSettings_Click(object sender, EventArgs e)
        {
            Worker.StartingMiningSettings.Clear();
            Worker.StartingMiningSettings.Add(HeaderPoolvText);
            Worker.StartingMiningSettings.Add(HeaderWorkervText);
            Worker.StartingMiningSettings.Add(Convert.ToString(HeaderMiningCurrencyvSelectedIndex));
            File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Default.txt", Worker.StartingMiningSettings);
        }

        //SETTINGS BUTTONS
        //ALLOWS CUSTOM COIN ENTRIES TO BE EDITTED
        private void btnEditSummary_Click(object sender, EventArgs e)
        {
            EditSummary();
            btnEditSummaryVisible = false;
            btnClearSummaryVisible = true;
        }
        //CONFIRMS INPUTTED COINS AND SWITCHES TEXTBOX TO READ ONLY
        private void btnConfirmSummary_Click(object sender, EventArgs e)
        {
            ConfirmSummary();
            btnEditSummaryVisible = true;
            btnClearSummaryVisible = false;
        }
        //CLEARS ALL ENTRIES
        private void btnClearSummary_Click(object sender, EventArgs e)
        {
            txtCustom01Text = "";
            txtCustom02Text = "";
            txtCustom03Text = "";
            txtCustom04Text = "";
            txtCustom05Text = "";
            txtCustom06Text = "";
            txtCustom07Text = "";
            txtCustom08Text = "";
            txtCustom09Text = "";
        }

        //SAVES CURRENT PAGE SELECTION TO MEMORY
        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            SaveProfile();
            lblSavedVisible = true;
            int CurrentPage = PagevSelectedIndex + 1;
            int CurrentIndex = PagevSelectedIndex;
            lblSavedText = "Saved to Page " + Convert.ToString(CurrentPage);
        }

        //CREATES A NEW PAGE
        private void btnNewPage_Click(object sender, EventArgs e)
        {
            Reference.EaseMethodsO.HideConfirmationLabelsNewSave();
            NewSave = true;
            pages = pages + 1;
            if (pages == 7)     //MAKES SURE THE MAX PAGE IS 7 | //FOR NOW
            {
                pages = pages - 1;
                lblMaxPagesVisible = true;
                lblNoSaveVisible = false;
                lblNewPageVisible = false;
                NewSave = false;
            }
            else
            {
                PagevAddItem(new Item(Convert.ToString(pages), pages));
                Pages = Convert.ToString(pages);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Pages.txt", Pages);
                PagevSelectedIndex = pages - 1;
                Crypto.CurrentPage = PagevSelectedIndex + 1;
                Reference.CryptoForm.lblCurrentPage.Text = "PAGE " + Convert.ToString(Crypto.CurrentPage);
                Reference.EaseMethodsO.EmptySummary();     //EMPTYS THE SUMMARY COINS FOR NEW PAGE INPUTS
            }
        }

        //SET DEFAULT TIMEZONE SELECTION
        private void btnTimeDefault_Click(object sender, EventArgs e)
        {
            StartingTimeZone = Convert.ToString(TimeZonevSelectedIndex);
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\TimeZone.txt", StartingTimeZone);
            lblTimeSetVisible = true;
        }

        //SET DEFAULT CURRENCY SELECTION
        private void btnCurrencyDefault_Click(object sender, EventArgs e)
        {
            StartingCurrency = Convert.ToString(CurrencyvSelectedIndex);
            StartingPeriod = Convert.ToString(TimePeriodvText);
            StartingCurrency = StartingCurrency + "AND" + StartingPeriod;
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt", StartingCurrency);
            lblDefaultSetVisible = true;
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
                    PagevAddItem(new Item(Convert.ToString(pages), pages));      //Add Item to Combo Box based on txt file.
                    pages = pages + 1;                                              //Universal Way of Checking Current Page Number.
                    if (pages > PageCalculation)
                    {
                        pages = pages - 1;                                          //Pages is added before the end of the loop this ensures it is correct.
                    }

                }

                //Setting Correct Starting Index for Combo Boxes.
                if (CurrencyNumber == 0)
                {
                    CurrencyvSelectedIndex = 0;
                    PublicCurrencyIndex = 0;
                    TimePeriodvClear();
                    TimePeriodvAddItem("USD ($)");
                    TimePeriodvAddItem("BTC (Satoshi)");
                    lblCurrencyPreviewSET = "XXX/USD";
                }
                else if (CurrencyNumber == 1)
                {
                    CurrencyvSelectedIndex = 1;
                    PublicCurrencyIndex = 1;
                    TimePeriodvClear();
                    TimePeriodvAddItem("AUD ($)");
                    TimePeriodvAddItem("BTC (Satoshi)");
                    lblCurrencyPreviewSET = "XXX/AUD";
                }


                if (TimeZoneNumber == 0)
                {
                    TimeZonevSelectedIndex = 0;
                }
                else if (TimeZoneNumber == 1)
                {
                    TimeZonevSelectedIndex = 1;
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
                txtCustom01Text = coin1;
                txtCustom02Text = coin2;
                txtCustom03Text = coin3;
                txtCustom04Text = coin4;
                txtCustom05Text = coin5;
                txtCustom06Text = coin6;
                txtCustom07Text = coin7;
                txtCustom08Text = coin8;
                txtCustom09Text = coin9;
                TestCoinSummary();
                Reference.CryptoForm.GETINFOSummary();
                ProfileLoaded = true;       //Make sure program understands profile loaded successfully. 
            }
            catch (Exception)
            {
                Reference.CryptoForm.lblSync.Text = "Saving Error";
                Reference.CryptoForm.lblSync.Visible = true;
            }
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
            txtCustom01Text = coin1;
            txtCustom02Text = coin2;
            txtCustom03Text = coin3;
            txtCustom04Text = coin4;
            txtCustom05Text = coin5;
            txtCustom06Text = coin6;
            txtCustom07Text = coin7;
            txtCustom08Text = coin8;
            txtCustom09Text = coin9;
            TestCoinSummary();
            Reference.EaseMethodsO.HideConfirmationLabelsSave();
        }
        public void SelectedIndexChanged(int Index)
        {
            lblMaxPagesVisible = false;
            if (PagevSelectedIndex == Index)
            {
                try
                {
                    IndexChanged(PagevSelectedIndex);      //Method that undergos the process of updating the coins from txt file.
                }
                catch (Exception)
                {
                    Reference.EaseMethodsO.EmptySummary();
                    TestCoinSummary();
                    Reference.CryptoForm.GETINFOSummary();
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
            coin1 = txtCustom01Text;
            coin2 = txtCustom02Text;
            coin3 = txtCustom03Text;
            coin4 = txtCustom04Text;
            coin5 = txtCustom05Text;
            coin6 = txtCustom06Text;
            coin7 = txtCustom07Text;
            coin8 = txtCustom08Text;
            coin9 = txtCustom09Text;
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
            PageNumber = Convert.ToString(PagevSelectedIndex);
            Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile));
            File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page" + PageNumber + ".txt", ProfileLoad);
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt", PageNumber);
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
                Reference.CryptoForm.lblSync.Text = "Coin Error";
                Reference.CryptoForm.lblSync.Visible = true;
            }

        }











        public void PagevAddItem(object Item)
        {
            Pagev.Items.Add(Item);
        }



        public void TimePeriodvAddItem(object Item)
        {
            TimePeriodv.Items.Add(Item);
        }

        public void HeaderWorkervAddItem(object Item)
        {
           HeaderWorkerv.Items.Add(Item);
        }

        public void HeaderPoolvAddItem(object Item)
        {
            HeaderPoolv.Items.Add(Item);
        }


        public void TimePeriodvClear()
        {
            TimePeriodv.Items.Clear();
        }

        public void HeaderWorkervClear()
        {
            HeaderWorkerv.Items.Clear();
        }

        public string lblCurrencyPreviewSET
        {
            set { lblCurrencyPreview.Text = value; }
        }
        



        public int PagevSelectedIndex
        {
            get { return Pagev.SelectedIndex; }
            set { Pagev.SelectedIndex = value; }
        }

        public int CurrencyvSelectedIndex
        {
            get { return Currencyv.SelectedIndex; }
            set { Currencyv.SelectedIndex = value; }
        }

        public int TimeZonevSelectedIndex
        {
            get { return TimeZonev.SelectedIndex; }
            set { TimeZonev.SelectedIndex = value; }
        }

        public int HeaderMiningCurrencyvSelectedIndex
        {
            get { return HeaderMiningCurrencyv.SelectedIndex; }
            set { HeaderMiningCurrencyv.SelectedIndex = value; }
        }



        public bool lblSaveFoundVisible
        {
            get { return lblSaveFound.Visible; }
            set { lblSaveFound.Visible = value; }
        }

        public bool lblConfirmedVisible
        {
            get { return lblConfirmed.Visible; }
            set { lblConfirmed.Visible = value; }
        }

        public bool lblMaxPagesVisible
        {
            get { return lblMaxPages.Visible; }
            set { lblMaxPages.Visible = value; }
        }

        public bool lblDefaultSetVisible
        {
            get { return lblDefaultSet.Visible; }
            set { lblDefaultSet.Visible = value; }
        }

        public bool lblNoSaveVisible
        {
            get { return lblDefaultSet.Visible; }
            set { lblDefaultSet.Visible = value; }
        }

        public bool lblNewPageVisible
        {
            get { return lblNewPage.Visible; }
            set { lblNewPage.Visible = value; }
        }

        public bool lblTimeSetVisible
        {
            get { return lblTimeSet.Visible; }
            set { lblTimeSet.Visible = value; }
        }

        public bool lblSavedVisible
        {
            get { return lblSaved.Visible; }
            set { lblSaved.Visible = value; }
        }

        public bool btnEditSummaryVisible
        {
            get { return btnEditSummary.Visible; }
            set { btnEditSummary.Visible = value; }
        }

        public bool btnClearSummaryVisible
        {
            get { return btnClearSummary.Visible; }
            set { btnClearSummary.Visible = value; }
        }

        public bool HeaderWorkervContainsNH
        {
            get { return HeaderPoolv.Items.Contains("NICEHASH");  }
        }

        public bool HeaderWorkervContainsZP
        {
            get { return HeaderPoolv.Items.Contains("ZPOOL"); }
        }


        public void OptionsNHWalletsvDataSource()
        {
            OptionsNHWalletsv.DataSource = BindWallet.DataSource;
        }

        public void OptionsZPWalletsvDataSource()
        {
            OptionsZPWalletsv.DataSource = BindWallet.DataSource;
        }





        public Point lblHeaderPoolLocation
        {
            set { lblHeaderPool.Location = value; }
        }

        public Point HeaderPoolvLocation
        {
            set { HeaderPoolv.Location = value; }
        }

        public Point lblHeaderWorkerLocation
        {
            set { lblHeaderWorker.Location = value; }
        }

        public Point HeaderWorkervLocation
        {
            set { HeaderWorkerv.Location = value; }
        }

        public Point lblHeaderMiningCurrencyLocation
        {
            set { lblHeaderMiningCurrency.Location = value; }
        }

        public Point HeaderMiningCurrencyvLocation
        {
            set { HeaderMiningCurrencyv.Location = value; }
        }



        public string txtCustom01Text
        {
            get { return txtCustom01.Text; }
            set { txtCustom01.Text = value; }
        }
        public string txtCustom02Text
        {
            get { return txtCustom02.Text; }
            set { txtCustom02.Text = value; }
        }
        public string txtCustom03Text
        {
            get { return txtCustom03.Text; }
            set { txtCustom03.Text = value; }
        }
        public string txtCustom04Text
        {
            get { return txtCustom04.Text; }
            set { txtCustom04.Text = value; }
        }
        public string txtCustom05Text
        {
            get { return txtCustom05.Text; }
            set { txtCustom05.Text = value; }
        }
        public string txtCustom06Text
        {
            get { return txtCustom06.Text; }
            set { txtCustom06.Text = value; }
        }
        public string txtCustom07Text
        {
            get { return txtCustom07.Text; }
            set { txtCustom07.Text = value; }
        }
        public string txtCustom08Text
        {
            get { return txtCustom08.Text; }
            set { txtCustom08.Text = value; }
        }
        public string txtCustom09Text
        {
            get { return txtCustom09.Text; }
            set { txtCustom09.Text = value; }
        }



        public string lblNewPageText
        {
            set { lblNewPage.Text = value; }
        }

        public string TimePeriodvText
        {
            get { return lblTimeSet.Text; }
            set { TimePeriodv.Text = value; }
        }

        public string lblSavedText
        {
            get { return lblSaved.Text; }
            set { lblSaved.Text = value; }
        }

        public string HeaderPoolvText
        {
            get { return HeaderPoolv.Text; }
            set { HeaderPoolv.Text = value; }
        }

        public string HeaderWorkervText
        {
            get { return HeaderWorkerv.Text; }
            set { HeaderWorkerv.Text = value; }
        }

        public string HeaderMiningCurrencyvText
        {
            get { return HeaderMiningCurrencyv.Text; }
            set { HeaderMiningCurrencyv.Text = value; }
        }

        public string OptionsZPWalletsvText
        {
            get { return OptionsZPWalletsv.Text; }
            set { OptionsZPWalletsv.Text = value; }
        }

        public string OptionsNHWalletsvText
        {
            get { return OptionsNHWalletsv.Text; }
            set { OptionsNHWalletsv.Text = value; }
        }

        
    }
}
