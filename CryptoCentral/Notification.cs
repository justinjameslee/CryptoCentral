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
    public partial class Notification : Form
    {
        public Notification(string message, AlertType type)
        {
            InitializeComponent();

            label1.Text = message;

            switch (type)
            {
                case AlertType.success:
                    this.BackColor = Color.SeaGreen;
                    break;
                case AlertType.info:
                    this.BackColor = Color.Gray;
                    break;
                case AlertType.warning:
                    this.BackColor = Color.Crimson;
                    break;
                case AlertType.error:
                    this.BackColor = Color.FromArgb(255, 128, 0);
                    break;


            }
        }

        public enum AlertType
        {
            success, info, warning, error
        }

        public static void Alert(string message, AlertType type)
        {
            new CryptoCentral.Notification(message, type).Show();
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            Login LoginLocation = new Login();
            this.Location = new Point(LoginLocation.Location.X + 35, LoginLocation.Location.Y);

            timerShow.Start();
        }

        int interval = 0;

        private void timerShow_Tick(object sender, EventArgs e)
        {
            if (this.Top < 60)
            {
                this.Top += interval;
                interval += 2;
            }
        }

        private void timerDisappear_Tick(object sender, EventArgs e)
        {
            timerClose.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timerClose.Start();
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.2;
            }
            else
            {
                this.Close();
            }
        }
    }

    
}
