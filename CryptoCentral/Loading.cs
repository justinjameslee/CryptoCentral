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
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            if (SummaryLoadingBar.Value >= 100 && Crypto.Loading == true)
            {
                Reference.CryptoForm.LoadingPanel.Visible = false;
                Crypto.Loading = false;
                SummaryLoadingBar.Value = 0;
            }
            else if (SummaryLoadingBar.Value < 100 && Crypto.Loading == true)
            {
                Reference.CryptoForm.LoadingPanel.Visible = true;
                SummaryLoadingBar.Value = SummaryLoadingBar.Value + 1;
            }
            else
            {

            }
        }
    }
}
