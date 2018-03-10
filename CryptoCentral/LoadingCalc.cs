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
    public partial class LoadingCalc : Form
    {
        public LoadingCalc()
        {
            InitializeComponent();
        }

        Bitmap LoadingPath = new Bitmap(@"Resources\Double Ring-1.5s-200px.gif");
        public static int LoadingValue = 0;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  //Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void Loading_Load(object sender, EventArgs e)
        {

        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            if (LoadingValue >= 100 && Crypto.Loading == true)
            {
                Crypto.Loading = false;
                LoadingValue = 0;
            }
            else if (LoadingValue < 100 && Crypto.Loading == true)
            {
                LoadingValue = LoadingValue + 1;
                LoadingIndicator.Text = Convert.ToString(LoadingValue);
                LoadingIndicator.Left = (this.ClientSize.Width - LoadingIndicator.Size.Width) / 2;
                LoadingPanelGif.Left = (this.ClientSize.Width - LoadingPanelGif.Size.Width) / 2;
                LoadingIndicator.Top = (this.ClientSize.Height - LoadingIndicator.Size.Height) / 2;
                LoadingPanelGif.Top = (this.ClientSize.Height - LoadingPanelGif.Size.Height) / 2;
            }
            else
            {

            }
        }

        private void CenterPictureBox(PictureBox picBox, Bitmap picImage)
        {
            picBox.Image = picImage;
            picBox.Location = new Point((picBox.Parent.ClientSize.Width / 2) - (picImage.Width / 2),
                                        (picBox.Parent.ClientSize.Height / 2) - (picImage.Height / 2));
            picBox.Refresh();
        }
    }
}
