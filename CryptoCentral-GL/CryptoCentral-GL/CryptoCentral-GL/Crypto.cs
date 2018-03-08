using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoCentral_GL
{
    public partial class Crypto : Form
    {
        public Crypto()
        {
            InitializeComponent();
        }

        private void Crypto_Load(object sender, EventArgs e)
        {
            Footer.Location = new Point(222, 539);
            this.Size = new Size(1064, 577);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MainContainer.Controls.Clear();
            Reference.SummaryForm.TopLevel = true;
            Reference.SummaryForm.Size = new Size(842, 468);
            Reference.SummaryForm.AutoScroll = false;
            Reference.SummaryForm.Dock = DockStyle.Fill;
            MainContainer.Controls.Add(Reference.SummaryForm);
            Reference.SummaryForm.Show();
            MainContainer.Visible = false;
            SidebarTransition.Show(MainContainer);
        }

        private void btnMining_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }
    }
}
