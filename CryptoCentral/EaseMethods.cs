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
    public class EaseMethods
    {
        public static string jsonString;

        public static string RemoveExtraText(string value)
        {
            var allowedChars = "01234567890.,-";
            try
            {
                return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
            }
            catch (Exception)
            {
                return value;
            }

        }
        public static string RemoveonlyCurly(string value)
        {
            var allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890,:[].\"";
            try
            {
                return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
            }
            catch (Exception)
            {
                return value;
            }
        }
        public static string RemoveforMining(string value)
        {
            var allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890";
            try
            {
                return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
            }
            catch (Exception)
            {
                return value;
            }
        }
        public static string RemoveforMiningKeepingCurly(string value)
        {
            var allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890{}";
            try
            {
                return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
            }
            catch (Exception)
            {
                return value;
            }
        }
        public static string RemoveCommas(string value)
        {
            var allowedChars = "1234567890.";
            try
            {
                return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
            }
            catch (Exception)
            {
                return value;
            }
        }
        
        public static string RemoveAfterLetter(string Remove, string Letter)
        {
            Crypto.TimeIndexRemove = Remove.LastIndexOf(Letter);
            if (Crypto.TimeIndexRemove > 0) { Remove = Remove.Substring(0, Crypto.TimeIndexRemove); }
            return Remove;
        }
        public static string API(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    jsonString = reader.ReadToEnd();
                    return jsonString;
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
        
    }

    public class EaseOptionsMethods : Options
    {
        //EASE OF ACCESS
        //HIDE ALL LBL EXCEPT SAVE FOUND
        public void HideConfirmationLabelsSave()
        {
            lblMaxPages.Visible = false;
            lblConfirmed.Visible = false;
            lblSaved.Visible = false;
            lblNewPage.Visible = false;
            lblNoSave.Visible = false;
            lblSaveFound.Visible = true;
        }
        //HIDE ALL LBL EXCEPT NO SAVE FOUND
        public void HideConfirmationLabelsNoSave()
        {
            lblConfirmed.Visible = false;
            lblSaved.Visible = false;
            lblNewPage.Visible = false;
            lblSaveFound.Visible = false;
            lblMaxPages.Visible = false;
            lblNoSave.Visible = true;
        }
        //HIDE ALL LBL EXCEPT NEW PAGE CREATED
        public void HideConfirmationLabelsNewSave()
        {
            lblMaxPages.Visible = false;
            lblConfirmed.Visible = false;
            lblSaved.Visible = false;
            lblNoSave.Visible = false;
            lblSaveFound.Visible = false;
            lblNewPage.Visible = true;
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
            Crypto.ConfirmAllowed = true;
            Crypto.ProfileLoaded = false;
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
            Crypto CryptoForm = new Crypto();
            Summary SummaryForm = new Summary();
            EmptySummaryIndividual(txtCustom01);
            EmptySummaryIndividual(txtCustom02);
            EmptySummaryIndividual(txtCustom03);
            EmptySummaryIndividual(txtCustom04);
            EmptySummaryIndividual(txtCustom05);
            EmptySummaryIndividual(txtCustom06);
            EmptySummaryIndividual(txtCustom07);
            EmptySummaryIndividual(txtCustom08);
            EmptySummaryIndividual(txtCustom09);
            CryptoForm.TestCoinSummary();
            SummaryForm.GETINFOSummary();
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
            Crypto CryptoForm = new Crypto();
            Summary SummaryForm = new Summary();
            while (Crypto.ConfirmAllowed == true)
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
                CryptoForm.TestCoinSummary();
                SummaryForm.GETINFOSummary();
                Crypto.ConfirmAllowed = false;
            }
        }
    }
}
