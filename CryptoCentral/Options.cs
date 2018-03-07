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

        private void Options_Load(object sender, EventArgs e)
        {
            
        }

        private void Pagev_SelectedIndexChanged(object sender, EventArgs e)
        {
            Crypto CryptoForm = new Crypto();
            Options OptionsForm = new Options();

            CryptoForm.SyncingTest();      //Show that new data is being processed.
            if (Crypto.NewSave == true)        //Check if this was caused by a new page creation.
            {
                OptionsForm.lblNoSaveVisible = false;
                OptionsForm.lblNewPageText = "New Page Created";
                OptionsForm.lblNewPageVisible = true;
                Crypto.NewSave = false;
            }
            else
            {
                CryptoForm.SelectedIndexChanged(OptionsForm.PagevSelectedIndex);      //Update the data with new txt file coins based on page index.
                CryptoForm.UpdatingCurrentPage();                          //Updates Header Page Number.
            }
            CryptoForm.btnPageLeft.Image = Image.FromFile(@"C:\Users\" + Environment.UserName + @"\Documents\GitHub\CryptoCentral\Images\left-arrow-still-24px.png");
            CryptoForm.btnPageRight.Image = Image.FromFile(@"C:\Users\" + Environment.UserName + @"\Documents\GitHub\CryptoCentral\Images\right-arrow-still-24px.png");
        }
        private void Currencyv_SelectedIndexChanged(object sender, EventArgs e)
        {
            Crypto CryptoForm = new Crypto();
            Options OptionsForm = new Options();

            if (OptionsForm.CurrencyvSelectedIndex == 0)
            {
                OptionsForm.CurrencyvSelectedIndex = 0;
                Crypto.PublicCurrencyIndex = 0;
                OptionsForm.TimePeriodvClear();
                OptionsForm.TimePeriodvAddItem("USD ($)");
                OptionsForm.TimePeriodvAddItem("BTC (Satoshi)");
                OptionsForm.lblCurrencyPreviewSET = "XXX/USD";
            }
            else if (OptionsForm.CurrencyvSelectedIndex == 1)
            {
                OptionsForm.CurrencyvSelectedIndex = 1;
                Crypto.PublicCurrencyIndex = 1;
                OptionsForm.TimePeriodvClear();
                OptionsForm.TimePeriodvAddItem("AUD ($)");
                OptionsForm.TimePeriodvAddItem("BTC (Satoshi)");
                OptionsForm.lblCurrencyPreviewSET = "XXX/AUD";
            }
            CryptoForm.SyncingTest();      //Refreshs Data.
            OptionsForm.lblDefaultSetVisible = false;
        }
        private void Timezonev_SelectedIndexChanged(object sender, EventArgs e)
        {
            Crypto CryptoForm = new Crypto();
            Options OptionsForm = new Options();

            if (OptionsForm.TimeZonevSelectedIndex == 0)
            {
                Crypto.TimeZoneNumber = 0;
            }
            else if (OptionsForm.TimeZonevSelectedIndex == 1)
            {
                Crypto.TimeZoneNumber = 1;
            }

            CryptoForm.SyncingTest();      //Refreshes Data.
            OptionsForm.lblTimeSetVisible = false;
        }
        private void TimePeriodCurrencyv_SelectedIndexChanged(object sender, EventArgs e)
        {
            Crypto CryptoForm = new Crypto();
            Options OptionsForm = new Options();

            if (OptionsForm.TimePeriodvText == "USD ($)")
            {
                Crypto.TimePeriodNumber = 0;
            }
            else if (OptionsForm.TimePeriodvText == "AUD ($)")
            {
                Crypto.TimePeriodNumber = 1;
            }
            else if (OptionsForm.TimePeriodvText == "BTC (Satoshi)")
            {
                Crypto.TimePeriodNumber = 2;
            }

            CryptoForm.SyncingTest();
        }

        private void HeaderPoolv_SelectedIndexChanged(object sender, EventArgs e)
        {
            Crypto CryptoForm = new Crypto();
            CryptoForm.GETWorkers();
        }

        private void HeaderWorkerv_SelectedIndexChanged(object sender, EventArgs e)
        {
            Crypto CryptoForm = new Crypto();
            CryptoForm.GETWorkerInfo();
        }

        private void OptionsNHWalletsv_SelectedIndexChanged(object sender, EventArgs e)
        {
            Crypto CryptoForm = new Crypto();
            Crypto.CurrentNHWallet = OptionsNHWalletsv.Text;
            CryptoForm.GETWorkers();
        }

        private void OptionsZPWalletsv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HeaderMiningCurrencyv_SelectedIndexChanged(object sender, EventArgs e)
        {
            Crypto CryptoForm = new Crypto();
            Options OptionsForm = new Options();
            if (OptionsForm.HeaderWorkervText != "")
            {
                CryptoForm.GETWorkerInfo();
            }
        }

        private void btnOptionsZPSave_Click(object sender, EventArgs e)
        {
            Crypto CryptoForm = new Crypto();
            OptionsMiningClick(lblZPWalletSaved, lblZPWalletSaved, lblZPDefaultSet, lblZPRemove, lblZPClear, txtOptionsZPv, Crypto.ZPWallets, Crypto.NewZPWallet, "ZPool");
            CryptoForm.GETPools();
        }

        private void btnOptionsZPDefault_Click(object sender, EventArgs e)
        {
            Crypto CryptoForm = new Crypto();
            OptionsMiningClick(lblZPDefaultSet, lblZPWalletSaved, lblZPDefaultSet, lblZPRemove, lblZPClear, txtOptionsZPv, Crypto.ZPWallets, Crypto.NewZPWallet, "ZPool");
            CryptoForm.GETPools();
        }

        private void btnOptionsZPRemove_Click(object sender, EventArgs e)
        {
            OptionsMiningClick(lblZPRemove, lblZPWalletSaved, lblZPDefaultSet, lblZPRemove, lblZPClear, txtOptionsZPv, Crypto.ZPWallets, Crypto.NewZPWallet, "ZPool");
        }

        private void btnOptionsZPClear_Click(object sender, EventArgs e)
        {
            OptionsMiningClick(lblZPClear, lblZPWalletSaved, lblZPDefaultSet, lblZPRemove, lblZPClear, txtOptionsZPv, Crypto.ZPWallets, Crypto.NewZPWallet, "ZPool");
        }
        private void btnOptionsNHSave_Click(object sender, EventArgs e)
        {
            Crypto CryptoForm = new Crypto();
            OptionsMiningClick(lblNHWalletSaved, lblNHWalletSaved, lblNHDefaultSet, lblNHRemove, lblNHClear, txtOptionsNHv, Crypto.NHWallets, Crypto.NewNHWallet, "Nicehash");
            CryptoForm.GETPools();
        }
        private void btnOptionsNHDefault_Click(object sender, EventArgs e)
        {
            Crypto CryptoForm = new Crypto();
            OptionsMiningClick(lblNHDefaultSet, lblNHWalletSaved, lblNHDefaultSet, lblNHRemove, lblNHClear, txtOptionsNHv, Crypto.NHWallets, Crypto.NewNHWallet, "Nicehash");
            CryptoForm.GETPools();
        }

        private void btnOptionsNHRemove_Click(object sender, EventArgs e)
        {
            OptionsMiningClick(lblNHRemove, lblNHWalletSaved, lblNHDefaultSet, lblNHRemove, lblNHClear, txtOptionsNHv, Crypto.NHWallets, Crypto.NewNHWallet, "Nicehash");
        }

        private void btnOptionsNHClear_Click(object sender, EventArgs e)
        {
            OptionsMiningClick(lblNHClear, lblNHWalletSaved, lblNHDefaultSet, lblNHRemove, lblNHClear, txtOptionsNHv, Crypto.NHWallets, Crypto.NewNHWallet, "Nicehash");
        }

        void OptionsMiningClick(Label lblCheck, Label WalletSaved, Label DefaultSet, Label Remove, Label Clear, TextBox Input, List<string> Wallets, string NewWallet, string Pool)
        {
            Crypto CryptoForm = new Crypto();
            WalletSaved.Visible = false;
            DefaultSet.Visible = false;
            Remove.Visible = false;
            Clear.Visible = false;
            Wallets = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Crypto.Profile) + @"\Mining\" + Pool + ".txt").ToList();
            NewWallet = Input.Text;
            if (lblCheck.Name == Clear.Name)
            {
                DialogResult Result = MessageBox.Show("ARE YOU SURE?", "Confirmation", MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    Crypto.NHWallets.Clear();
                    File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Crypto.Profile) + @"\Mining\" + Pool + ".txt", Wallets);
                    lblCheck.Text = "WALLETS CLEARED";
                    lblCheck.Visible = true;
                    CryptoForm.GETWallets();
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
                    Crypto.WalletIndexChecker = Wallets.FindIndex(x => x.StartsWith(NewWallet));
                    bool WalletDuplicate = Wallets.Contains(NewWallet);
                    if (WalletDuplicate != true)
                    {
                        if (NewWallet != "")
                        {
                            if (lblCheck.Name == DefaultSet.Name)
                            {
                                Wallets.Insert(0, NewWallet);
                                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Crypto.Profile) + @"\Mining\" + Pool + ".txt", Wallets);
                                lblCheck.Text = "DEFAULT SET";
                                lblCheck.Visible = true;
                                Input.Text = "";
                                CryptoForm.GETWallets();
                            }
                            else if (lblCheck.Name == WalletSaved.Name)
                            {
                                Wallets.Add(NewWallet);
                                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Crypto.Profile) + @"\Mining\" + Pool + ".txt", Wallets);
                                lblCheck.Text = "WALLET SAVED";
                                lblCheck.Visible = true;
                                Input.Text = "";
                                CryptoForm.GETWallets();
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
                    else if (lblCheck.Name == DefaultSet.Name && Crypto.WalletIndexChecker == 0)
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
                                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Crypto.Profile) + @"\Mining\" + Pool + ".txt", Wallets);
                                lblCheck.Text = "DEFAULT SET";
                                lblCheck.Visible = true;
                                Input.Text = "";
                                CryptoForm.GETWallets();
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
                        File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Crypto.Profile) + @"\Mining\" + Pool + ".txt", Wallets);
                        lblCheck.Text = "WALLET REMOVED";
                        lblCheck.Visible = true;
                        Input.Text = "";
                        CryptoForm.GETWallets();
                    }
                }
            }
        }

        private void btnMiningSettings_Click(object sender, EventArgs e)
        {
            Options OptionsForm = new Options();
            Crypto.StartingMiningSettings.Clear();
            Crypto.StartingMiningSettings.Add(OptionsForm.HeaderPoolvText);
            Crypto.StartingMiningSettings.Add(OptionsForm.HeaderWorkervText);
            Crypto.StartingMiningSettings.Add(Convert.ToString(OptionsForm.HeaderMiningCurrencyvSelectedIndex));
            File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Crypto.Profile) + @"\Mining\Default.txt", Crypto.StartingMiningSettings);
        }

        //SETTINGS BUTTONS
        //ALLOWS CUSTOM COIN ENTRIES TO BE EDITTED
        private void btnEditSummary_Click(object sender, EventArgs e)
        {
            Options OptionsForm = new Options();
            EaseOptionsMethods EaseMethodsO = new EaseOptionsMethods();
            EaseMethodsO.EditSummary();
            OptionsForm.btnEditSummaryVisible = false;
            OptionsForm.btnClearSummaryVisible = true;
        }
        //CONFIRMS INPUTTED COINS AND SWITCHES TEXTBOX TO READ ONLY
        private void btnConfirmSummary_Click(object sender, EventArgs e)
        {
            Options OptionsForm = new Options();
            EaseOptionsMethods EaseMethodsO = new EaseOptionsMethods();
            EaseMethodsO.ConfirmSummary();
            OptionsForm.btnEditSummaryVisible = true;
            OptionsForm.btnClearSummaryVisible = false;
        }
        //CLEARS ALL ENTRIES
        private void btnClearSummary_Click(object sender, EventArgs e)
        {
            Options OptionsForm = new Options();
            OptionsForm.txtCustom01Text = "";
            OptionsForm.txtCustom01Text = "";
            OptionsForm.txtCustom01Text = "";
            OptionsForm.txtCustom01Text = "";
            OptionsForm.txtCustom01Text = "";
            OptionsForm.txtCustom01Text = "";
            OptionsForm.txtCustom01Text = "";
            OptionsForm.txtCustom01Text = "";
            OptionsForm.txtCustom01Text = "";
        }

        //SAVES CURRENT PAGE SELECTION TO MEMORY
        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            Crypto CryptoForm = new Crypto();
            Options OptionsForm = new Options();
            CryptoForm.SaveProfile();
            OptionsForm.lblSavedVisible = true;
            int CurrentPage = OptionsForm.PagevSelectedIndex + 1;
            int CurrentIndex = OptionsForm.PagevSelectedIndex;
            OptionsForm.lblSavedText = "Saved to Page " + Convert.ToString(CurrentPage);
        }

        //CREATES A NEW PAGE
        private void btnNewPage_Click(object sender, EventArgs e)
        {
            Crypto CryptoForm = new Crypto();
            Options OptionsForm = new Options();
            EaseOptionsMethods EaseMethodsO = new EaseOptionsMethods();
            EaseMethodsO.HideConfirmationLabelsNewSave();
            Crypto.NewSave = true;
            Crypto.pages = Crypto.pages + 1;
            if (Crypto.pages == 7)     //MAKES SURE THE MAX PAGE IS 7 | //FOR NOW
            {
                Crypto.pages = Crypto.pages - 1;
                OptionsForm.lblMaxPagesVisible = true;
                OptionsForm.lblNoSaveVisible = false;
                OptionsForm.lblNewPageVisible = false;
                Crypto.NewSave = false;
            }
            else
            {
                OptionsForm.PagevAddItem(new Crypto.Item(Convert.ToString(Crypto.pages), Crypto.pages));
                Crypto.Pages = Convert.ToString(Crypto.pages);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Crypto.Profile) + @"\Pages.txt", Crypto.Pages);
                OptionsForm.PagevSelectedIndex = Crypto.pages - 1;
                Crypto.CurrentPage = OptionsForm.PagevSelectedIndex + 1;
                CryptoForm.lblCurrentPageText = "PAGE " + Convert.ToString(Crypto.CurrentPage);
                EaseMethodsO.EmptySummary();     //EMPTYS THE SUMMARY COINS FOR NEW PAGE INPUTS
            }
        }

        //SET DEFAULT TIMEZONE SELECTION
        private void btnTimeDefault_Click(object sender, EventArgs e)
        {
            Options OptionsForm = new Options();
            Crypto.StartingTimeZone = Convert.ToString(OptionsForm.TimeZonevSelectedIndex);
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Crypto.Profile) + @"\TimeZone.txt", Crypto.StartingTimeZone);
            OptionsForm.lblTimeSetVisible = true;
        }

        //SET DEFAULT CURRENCY SELECTION
        private void btnCurrencyDefault_Click(object sender, EventArgs e)
        {
            Options OptionsForm = new Options();
            Crypto.StartingCurrency = Convert.ToString(OptionsForm.CurrencyvSelectedIndex);
            Crypto.StartingPeriod = Convert.ToString(OptionsForm.TimePeriodvText);
            Crypto.StartingCurrency = Crypto.StartingCurrency + "AND" + Crypto.StartingPeriod;
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Crypto.Profile) + @"\Currency.txt", Crypto.StartingCurrency);
            OptionsForm.lblDefaultSetVisible = true;
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
            OptionsNHWalletsv.DataSource = Crypto.BindWallet.DataSource;
        }

        public void OptionsZPWalletsvDataSource()
        {
            OptionsZPWalletsv.DataSource = Crypto.BindWallet.DataSource;
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
