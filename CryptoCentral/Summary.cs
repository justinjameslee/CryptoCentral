using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoCentral
{
    public partial class Summary : Form
    {
        public Summary()
        {
            InitializeComponent();
            customGroup05.Left = (this.ClientSize.Width - customGroup05.Size.Width) / 2;
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

        public void GETINFOSummary()
        {
            try
            {
                SummaryCalculation.GETINFO(Options.coin1FN, Options.coin1, lblCustomCv01, lblCustomBTCv01, lblCustom1Hc01, lblCustom24Hc01, lblCustom7Dc01, lblCustom1Hp01, lblCustom24Hp01, lblCustom7Dp01, lblCustomC01, lblCustomBTC01, lblCustomUpdatedv01, customGroup01);
                SummaryCalculation.GETINFO(Options.coin2FN, Options.coin2, lblCustomCv02, lblCustomBTCv02, lblCustom1Hc02, lblCustom24Hc02, lblCustom7Dc02, lblCustom1Hp02, lblCustom24Hp02, lblCustom7Dp02, lblCustomC02, lblCustomBTC02, lblCustomUpdatedv02, customGroup02);
                SummaryCalculation.GETINFO(Options.coin3FN, Options.coin3, lblCustomCv03, lblCustomBTCv03, lblCustom1Hc03, lblCustom24Hc03, lblCustom7Dc03, lblCustom1Hp03, lblCustom24Hp03, lblCustom7Dp03, lblCustomC03, lblCustomBTC03, lblCustomUpdatedv03, customGroup03);
                SummaryCalculation.GETINFO(Options.coin4FN, Options.coin4, lblCustomCv04, lblCustomBTCv04, lblCustom1Hc04, lblCustom24Hc04, lblCustom7Dc04, lblCustom1Hp04, lblCustom24Hp04, lblCustom7Dp04, lblCustomC04, lblCustomBTC04, lblCustomUpdatedv04, customGroup04);
                SummaryCalculation.GETINFO(Options.coin5FN, Options.coin5, lblCustomCv05, lblCustomBTCv05, lblCustom1Hc05, lblCustom24Hc05, lblCustom7Dc05, lblCustom1Hp05, lblCustom24Hp05, lblCustom7Dp05, lblCustomC05, lblCustomBTC05, lblCustomUpdatedv05, customGroup05);
                SummaryCalculation.GETINFO(Options.coin6FN, Options.coin6, lblCustomCv06, lblCustomBTCv06, lblCustom1Hc06, lblCustom24Hc06, lblCustom7Dc06, lblCustom1Hp06, lblCustom24Hp06, lblCustom7Dp06, lblCustomC06, lblCustomBTC06, lblCustomUpdatedv06, customGroup06);
                SummaryCalculation.GETINFO(Options.coin7FN, Options.coin7, lblCustomCv07, lblCustomBTCv07, lblCustom1Hc07, lblCustom24Hc07, lblCustom7Dc07, lblCustom1Hp07, lblCustom24Hp07, lblCustom7Dp07, lblCustomC07, lblCustomBTC07, lblCustomUpdatedv07, customGroup07);
                SummaryCalculation.GETINFO(Options.coin8FN, Options.coin8, lblCustomCv08, lblCustomBTCv08, lblCustom1Hc08, lblCustom24Hc08, lblCustom7Dc08, lblCustom1Hp08, lblCustom24Hp08, lblCustom7Dp08, lblCustomC08, lblCustomBTC08, lblCustomUpdatedv08, customGroup08);
                SummaryCalculation.GETINFO(Options.coin9FN, Options.coin9, lblCustomCv09, lblCustomBTCv09, lblCustom1Hc09, lblCustom24Hc09, lblCustom7Dc09, lblCustom1Hp09, lblCustom24Hp09, lblCustom7Dp09, lblCustomC09, lblCustomBTC09, lblCustomUpdatedv09, customGroup09);
                Crypto.SYNCED = true;
            }
            catch (Exception)
            {

            }
        }

        public void HidecustomRefresh()
        {
            HideorShowRefresh(customRefresh01, false);
            HideorShowRefresh(customRefresh02, false);
            HideorShowRefresh(customRefresh03, false);
            HideorShowRefresh(customRefresh04, false);
            HideorShowRefresh(customRefresh05, false);
            HideorShowRefresh(customRefresh06, false);
            HideorShowRefresh(customRefresh07, false);
            HideorShowRefresh(customRefresh08, false);
            HideorShowRefresh(customRefresh09, false);
        }
        public void ShowcustomRefresh()
        {
            HideorShowRefresh(customRefresh01, true);
            HideorShowRefresh(customRefresh02, true);
            HideorShowRefresh(customRefresh03, true);
            HideorShowRefresh(customRefresh04, true);
            HideorShowRefresh(customRefresh05, true);
            HideorShowRefresh(customRefresh06, true);
            HideorShowRefresh(customRefresh07, true);
            HideorShowRefresh(customRefresh08, true);
            HideorShowRefresh(customRefresh09, true);
        }

        public void HideorShowRefresh(PictureBox Refresh, bool Status)
        {
            if (Status == true)
            {
                Refresh.Image = Image.FromFile(@"Resources\RefreshAnimation-24px.gif");
            }
            else if (Status == false)
            {
                Refresh.Image = Image.FromFile(@"Resources\reload.png");
            }
        }

        private void Summary_Load(object sender, EventArgs e)
        {

        }

        public void MaximizeSettings()
        {
            
        }
    }
}
