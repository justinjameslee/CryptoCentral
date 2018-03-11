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
    public partial class DialogSuccess : Form
    {
        public DialogSuccess(string _message)
        {
            InitializeComponent();
            lblSuccess.Text = _message;
        }

        private void DialogSuccess_Load(object sender, EventArgs e)
        {
            FormFade.ShowAsyc(this);
            picIcon.Visible = true;
            picIcon.Enabled = true;
            
        }

        private void FormFade_TransitionEnd(object sender, EventArgs e)
        {
            timerIconDelay.Start();
        }

        private void timerIconDelay_Tick(object sender, EventArgs e)
        {
            picIcon.Enabled = false;
            timerIconDelay.Stop();
            btnConfirm.Visible = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void ShowDialog(string message)
        {
            DialogSuccess DialogS = new DialogSuccess(message);
            DialogS.ShowDialog();
        }
    }
}
