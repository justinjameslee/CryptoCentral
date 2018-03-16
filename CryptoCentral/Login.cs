using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;

namespace CryptoCentral
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Size = new Size(757, 669);
            string DatabaseConnectionString = Properties.Settings.Default.ConnectionString;
            connection = new MySqlConnection(DatabaseConnectionString);
        }

        public static MySqlConnection connection;
        public string salt;
        public string hashedpassword;
        public string NameUp;
        public string UserUp;
        public string EmailUp;

        //Create a list to store the result
        public List<string> EMAIL = new List<string>();
        public List<string> USERNAME = new List<string>();
        public List<string> HASH = new List<string>();
        public List<string> SALT = new List<string>();

        public string CreateSalt(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public string GenerateSHA256Hash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256hashstring =
                new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        public static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }

        public static byte[] HexStringToByteArray(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i/2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (panelSignUp.Left == 803)
            {
                Transition.HideSync(panelSignIn);
                panelSignIn.Left = 803;

                panelSignUp.Visible = false;
                panelSignUp.Left = 270;
                Transition.ShowSync(panelSignUp);
                panelSignUp.Refresh();

                ButtonHighlight.Left = btnSignUp.Left;
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (panelSignIn.Left == 803)
            {
                Transition.HideSync(panelSignUp);
                panelSignUp.Left = 803;

                panelSignIn.Visible = false;
                panelSignIn.Left = 270;
                Transition.ShowSync(panelSignIn);
                panelSignIn.Refresh();

                ButtonHighlight.Left = btnSignIn.Left;
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        void Incorrect(Bunifu.Framework.UI.BunifuMetroTextbox txtbox)
        {
            txtbox.BorderColorIdle = Color.Crimson;
            txtbox.BorderColorFocused = Color.Crimson;
            txtbox.BorderColorMouseHover = Color.Crimson;
        }
        void Correct(Bunifu.Framework.UI.BunifuMetroTextbox txtbox)
        {
            txtbox.BorderColorIdle = Color.Gray;
            txtbox.BorderColorFocused = Color.Orange;
            txtbox.BorderColorMouseHover = Color.Orange;
        }

        private void btnSignInConfirm_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(txtEmailIn.Text) == false && txtPasswordIn.Text.Length <= 8)
            {
                Incorrect(txtEmailIn);
                Incorrect(txtPasswordIn);
            }
            else if (txtPasswordIn.Text.Length <= 8)
            {
                Correct(txtEmailIn);
                Incorrect(txtPasswordIn);
            }
            else if (IsValidEmail(txtEmailIn.Text) == false)
            {
                Incorrect(txtEmailIn);
                Correct(txtPasswordIn);
            }
            else
            {
                try
                {
                    int Index = Select(EMAIL).IndexOf(txtEmailIn.Text);
                    hashedpassword = Select(HASH)[Index];
                    salt = Select(SALT)[Index];

                    if (hashedpassword == GenerateSHA256Hash(txtPasswordIn.Text, salt))
                    {
                        Notification.Alert("SUCCESS", Notification.AlertType.success);
                    }
                    else
                    {
                        Incorrect(txtEmailIn);
                        Incorrect(txtPasswordIn);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Email or Password is Invalid.");
                }
            }
        }

        private void btnSignUpConfirm_Click(object sender, EventArgs e)
        {

            if (txtName.Text == "")
            {
                MessageBox.Show("Full Name cannot be empty.");
            }
            else if (txtUsername.Text == "")
            {
                MessageBox.Show("Username cannot be empty.");
            }
            else if (IsValidEmail(txtEmailUp.Text) == false)
            {
                MessageBox.Show("Must be a valid email address.");
            }
            else if (txtPasswordUp.Text.Length <= 8)
            {
                MessageBox.Show("Password must be greater than 8.");
            }
            else
            {
                salt = CreateSalt(10);
                hashedpassword = GenerateSHA256Hash(txtPasswordUp.Text, salt);
                NameUp = txtName.Text;
                UserUp = txtUsername.Text;
                EmailUp = txtEmailUp.Text;

                if (Select(EMAIL).Contains(EmailUp))
                {
                    MessageBox.Show("Email already registered.");
                }
                else if (Select(USERNAME).Contains(UserUp))
                {
                    MessageBox.Show("Username already taken.");
                }
                else
                {
                    Insert();
                    DialogSuccess.ShowDialog("Thank you for registering with Crypto Central!");
                    Transition.HideSync(panelSignUp);
                    panelSignUp.Left = 803;

                    panelSignIn.Visible = false;
                    panelSignIn.Left = 270;
                    Transition.ShowSync(panelSignIn);
                    panelSignIn.Refresh();

                    ButtonHighlight.Left = btnSignIn.Left;

                    txtEmailIn.Text = EmailUp;
                    txtPasswordIn.Text = "";

                    txtName.Text = "";
                    txtUsername.Text = "";
                    txtEmailUp.Text = "";
                    txtPasswordUp.Text = "";
                }
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public void Insert()
        {
            string query = "INSERT INTO CryptoCentral (EMAIL, USERNAME, HASH, SALT) VALUES('" + EmailUp  + "', '" + UserUp + "', '" + hashedpassword + "', '" + salt + "')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;

                    case 1130:
                        MessageBox.Show("Not allowed to connected to server.");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Select statement
        public List<string> Select(List<string> Ref)
        {
            string query = "SELECT * FROM CryptoCentral";

            EMAIL.Clear();
            USERNAME.Clear();
            HASH.Clear();
            SALT.Clear();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    EMAIL.Add(dataReader["EMAIL"] + "");
                    USERNAME.Add(dataReader["USERNAME"] + "");
                    HASH.Add(dataReader["HASH"] + "");
                    SALT.Add(dataReader["SALT"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return Ref;
            }
            else
            {
                return Ref;
            }
        }
    }
}
