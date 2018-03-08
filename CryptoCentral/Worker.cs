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
    public partial class Worker : Form
    {
        public Worker()
        {
            InitializeComponent();
        }

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

        //MINING
        public void SetDefault()
        {
            StartingMiningSettings.Clear();
            if (!File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Options.Profile) + @"\Mining\Default.txt"))
            {
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Options.Profile) + @"\Mining\Default.txt", "EMPTY");
                Reference.OptionsForm.HeaderPoolvText = "";
                Reference.OptionsForm.HeaderWorkervText = "SELECT A POOL";
                Reference.OptionsForm.HeaderMiningCurrencyvText = "";
            }
            else
            {
                StartingMiningSettings = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Options.Profile) + @"\Mining\Default.txt").ToList();
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
            NHWallets = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Options.Profile) + @"\Mining\Nicehash.txt").ToList();
            NHWalletsA = NHWallets.ToArray();
            Options.BindWallet.DataSource = NHWalletsA;
            Reference.OptionsForm.OptionsNHWalletsvDataSource();
            CurrentNHWallet = Reference.OptionsForm.OptionsNHWalletsvText;

            ZPWallets = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Options.Profile) + @"\Mining\ZPool.txt").ToList();
            ZPWalletsA = ZPWallets.ToArray();
            Options.BindWallet.DataSource = ZPWalletsA;
            Reference.OptionsForm.OptionsZPWalletsvDataSource();
            CurrentZPWallet = Reference.OptionsForm.OptionsZPWalletsvText;

        }
        public void GETPools()
        {
            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Options.Profile) + @"\Mining\Nicehash.txt"))
            {
                if (Reference.OptionsForm.HeaderWorkervContainsNH) { }
                else
                {
                    Reference.OptionsForm.HeaderPoolvAddItem("NICEHASH");
                }
            }
            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Options.Profile) + @"\Mining\ZPool.txt"))
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
                NHRelWorkers = Reference.EaseMethods.getBetween(lineWorker, ":[", "\"algo");
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
                        if (Crypto.bWorker == false)
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
                        SCurrentAlgo = Reference.EaseMethods.getBetween(SCurrentAlgo, ": \"", "\"");
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
                        SHashEnd = Reference.EaseMethods.getBetween(SHashEnd, ": \"", "\"");
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
                NHRelProfit = Reference.EaseMethods.getBetween(lineWorker, ":[", "],\"nh_wallet");
                NHRelProfitA = Regex.Split(NHRelProfit, "},{");
                SepProfit = NHRelProfitA.OfType<string>().ToList();
                for (int x = 0; x < SepProfit.Count; x++)
                {
                    if (SepProfit[x] != "")
                    {
                        NHProfitability = SepProfit[x];
                        NHActualAlgoS = SepProfit[x];
                        NHProfitability = Reference.EaseMethods.getBetween(NHProfitability, "profitability", ",\"data");
                        NHProfitability = EaseMethods.RemoveExtraText(NHProfitability);

                        NHActualAlgoS = EaseMethods.RemoveonlyCurly(NHActualAlgoS);
                        NHActualAlgoS = NHActualAlgoS + "}";
                        NHActualAlgoS = Reference.EaseMethods.getBetween(NHActualAlgoS, "algo", "}");
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
                lblProfitv.Text = "$" + string.Format("{0:#,0.00}", NHCalcProfitBTCD * Crypto.UniversalBTCPrice);
                lblProfitMv.Text = "$" + string.Format("{0:#,0.00}", (NHCalcProfitBTCD * 30.4167) * Crypto.UniversalBTCPrice);
                lblProfitYv.Text = "$" + string.Format("{0:#,0.00}", (NHCalcProfitBTCD * 365) * Crypto.UniversalBTCPrice);
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

                DATA = Reference.EaseMethods.getBetween(DATA, ",{\"", "]");
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
            Crypto.SYNCED = true;
        }
    }
}
