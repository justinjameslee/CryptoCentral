namespace CryptoCentral
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation5 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.SideBar = new System.Windows.Forms.Panel();
            this.lblLogoText = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picGoldline = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.btnSignIn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnSignUpConfirm = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panelSignUp = new System.Windows.Forms.Panel();
            this.lblPasswordUp = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtPasswordUp = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblEmailUp = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtEmailUp = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblLastName = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtUsername = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblFirstName = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblSignUp = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnSignUp = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panelSignIn = new System.Windows.Forms.Panel();
            this.btnSignInConfirm = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lblPasswordIn = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtPasswordIn = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblEmailIn = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtEmailIn = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.lblSignIn = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.Transition = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.ButtonHighlight = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.SideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGoldline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelSignUp.SuspendLayout();
            this.panelSignIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // SideBar
            // 
            this.SideBar.BackColor = System.Drawing.Color.DarkOrange;
            this.SideBar.Controls.Add(this.lblLogoText);
            this.SideBar.Controls.Add(this.picLogo);
            this.Transition.SetDecoration(this.SideBar, BunifuAnimatorNS.DecorationType.None);
            this.SideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideBar.Location = new System.Drawing.Point(0, 0);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(213, 669);
            this.SideBar.TabIndex = 0;
            this.SideBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            // 
            // lblLogoText
            // 
            this.Transition.SetDecoration(this.lblLogoText, BunifuAnimatorNS.DecorationType.None);
            this.lblLogoText.Font = new System.Drawing.Font("Nexa Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogoText.ForeColor = System.Drawing.Color.White;
            this.lblLogoText.Location = new System.Drawing.Point(0, 403);
            this.lblLogoText.Name = "lblLogoText";
            this.lblLogoText.Size = new System.Drawing.Size(213, 37);
            this.lblLogoText.TabIndex = 2;
            this.lblLogoText.Text = "Crypto Central";
            this.lblLogoText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogoText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            // 
            // picLogo
            // 
            this.Transition.SetDecoration(this.picLogo, BunifuAnimatorNS.DecorationType.None);
            this.picLogo.Image = global::CryptoCentral.Properties.Resources.Logo_100px;
            this.picLogo.Location = new System.Drawing.Point(38, 259);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(135, 129);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            this.picLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            // 
            // picGoldline
            // 
            this.picGoldline.BackColor = System.Drawing.Color.Transparent;
            this.Transition.SetDecoration(this.picGoldline, BunifuAnimatorNS.DecorationType.None);
            this.picGoldline.Image = global::CryptoCentral.Properties.Resources.logo_goldline;
            this.picGoldline.Location = new System.Drawing.Point(271, 11);
            this.picGoldline.Name = "picGoldline";
            this.picGoldline.Size = new System.Drawing.Size(433, 53);
            this.picGoldline.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGoldline.TabIndex = 1;
            this.picGoldline.TabStop = false;
            this.picGoldline.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            // 
            // picClose
            // 
            this.Transition.SetDecoration(this.picClose, BunifuAnimatorNS.DecorationType.None);
            this.picClose.Image = global::CryptoCentral.Properties.Resources.Delete_100px;
            this.picClose.Location = new System.Drawing.Point(710, 12);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(30, 30);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picClose.TabIndex = 7;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.ActiveBorderThickness = 1;
            this.btnSignIn.ActiveCornerRadius = 1;
            this.btnSignIn.ActiveFillColor = System.Drawing.Color.Orange;
            this.btnSignIn.ActiveForecolor = System.Drawing.Color.White;
            this.btnSignIn.ActiveLineColor = System.Drawing.Color.Orange;
            this.btnSignIn.BackColor = System.Drawing.Color.White;
            this.btnSignIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSignIn.BackgroundImage")));
            this.btnSignIn.ButtonText = "SIGN IN";
            this.btnSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Transition.SetDecoration(this.btnSignIn, BunifuAnimatorNS.DecorationType.None);
            this.btnSignIn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSignIn.IdleBorderThickness = 1;
            this.btnSignIn.IdleCornerRadius = 1;
            this.btnSignIn.IdleFillColor = System.Drawing.Color.White;
            this.btnSignIn.IdleForecolor = System.Drawing.Color.Black;
            this.btnSignIn.IdleLineColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(349, 72);
            this.btnSignIn.Margin = new System.Windows.Forms.Padding(5);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(138, 63);
            this.btnSignIn.TabIndex = 8;
            this.btnSignIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnSignUpConfirm
            // 
            this.btnSignUpConfirm.ActiveBorderThickness = 1;
            this.btnSignUpConfirm.ActiveCornerRadius = 1;
            this.btnSignUpConfirm.ActiveFillColor = System.Drawing.Color.DarkOrange;
            this.btnSignUpConfirm.ActiveForecolor = System.Drawing.Color.White;
            this.btnSignUpConfirm.ActiveLineColor = System.Drawing.Color.DarkOrange;
            this.btnSignUpConfirm.BackColor = System.Drawing.Color.White;
            this.btnSignUpConfirm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSignUpConfirm.BackgroundImage")));
            this.btnSignUpConfirm.ButtonText = "SIGN UP";
            this.btnSignUpConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Transition.SetDecoration(this.btnSignUpConfirm, BunifuAnimatorNS.DecorationType.None);
            this.btnSignUpConfirm.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUpConfirm.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSignUpConfirm.IdleBorderThickness = 1;
            this.btnSignUpConfirm.IdleCornerRadius = 1;
            this.btnSignUpConfirm.IdleFillColor = System.Drawing.Color.Orange;
            this.btnSignUpConfirm.IdleForecolor = System.Drawing.Color.White;
            this.btnSignUpConfirm.IdleLineColor = System.Drawing.Color.Orange;
            this.btnSignUpConfirm.Location = new System.Drawing.Point(27, 397);
            this.btnSignUpConfirm.Margin = new System.Windows.Forms.Padding(5);
            this.btnSignUpConfirm.Name = "btnSignUpConfirm";
            this.btnSignUpConfirm.Size = new System.Drawing.Size(388, 63);
            this.btnSignUpConfirm.TabIndex = 10;
            this.btnSignUpConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSignUpConfirm.Click += new System.EventHandler(this.btnSignUpConfirm_Click);
            // 
            // panelSignUp
            // 
            this.panelSignUp.Controls.Add(this.lblPasswordUp);
            this.panelSignUp.Controls.Add(this.txtPasswordUp);
            this.panelSignUp.Controls.Add(this.lblEmailUp);
            this.panelSignUp.Controls.Add(this.btnSignUpConfirm);
            this.panelSignUp.Controls.Add(this.txtEmailUp);
            this.panelSignUp.Controls.Add(this.lblLastName);
            this.panelSignUp.Controls.Add(this.txtUsername);
            this.panelSignUp.Controls.Add(this.lblFirstName);
            this.panelSignUp.Controls.Add(this.txtName);
            this.panelSignUp.Controls.Add(this.lblSignUp);
            this.Transition.SetDecoration(this.panelSignUp, BunifuAnimatorNS.DecorationType.None);
            this.panelSignUp.Location = new System.Drawing.Point(803, 137);
            this.panelSignUp.Name = "panelSignUp";
            this.panelSignUp.Size = new System.Drawing.Size(433, 483);
            this.panelSignUp.TabIndex = 11;
            this.panelSignUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            // 
            // lblPasswordUp
            // 
            this.lblPasswordUp.AutoSize = true;
            this.Transition.SetDecoration(this.lblPasswordUp, BunifuAnimatorNS.DecorationType.None);
            this.lblPasswordUp.Font = new System.Drawing.Font("Nexa Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordUp.ForeColor = System.Drawing.Color.Black;
            this.lblPasswordUp.Location = new System.Drawing.Point(24, 303);
            this.lblPasswordUp.Name = "lblPasswordUp";
            this.lblPasswordUp.Size = new System.Drawing.Size(68, 16);
            this.lblPasswordUp.TabIndex = 8;
            this.lblPasswordUp.Text = "Password";
            this.lblPasswordUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPasswordUp
            // 
            this.txtPasswordUp.BorderColorFocused = System.Drawing.Color.Orange;
            this.txtPasswordUp.BorderColorIdle = System.Drawing.Color.Gray;
            this.txtPasswordUp.BorderColorMouseHover = System.Drawing.Color.Orange;
            this.txtPasswordUp.BorderThickness = 2;
            this.txtPasswordUp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Transition.SetDecoration(this.txtPasswordUp, BunifuAnimatorNS.DecorationType.None);
            this.txtPasswordUp.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPasswordUp.ForeColor = System.Drawing.Color.Black;
            this.txtPasswordUp.isPassword = true;
            this.txtPasswordUp.Location = new System.Drawing.Point(27, 323);
            this.txtPasswordUp.Margin = new System.Windows.Forms.Padding(4);
            this.txtPasswordUp.Name = "txtPasswordUp";
            this.txtPasswordUp.Size = new System.Drawing.Size(388, 44);
            this.txtPasswordUp.TabIndex = 7;
            this.txtPasswordUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblEmailUp
            // 
            this.lblEmailUp.AutoSize = true;
            this.Transition.SetDecoration(this.lblEmailUp, BunifuAnimatorNS.DecorationType.None);
            this.lblEmailUp.Font = new System.Drawing.Font("Nexa Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailUp.ForeColor = System.Drawing.Color.Black;
            this.lblEmailUp.Location = new System.Drawing.Point(24, 198);
            this.lblEmailUp.Name = "lblEmailUp";
            this.lblEmailUp.Size = new System.Drawing.Size(40, 16);
            this.lblEmailUp.TabIndex = 6;
            this.lblEmailUp.Text = "Email";
            this.lblEmailUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEmailUp
            // 
            this.txtEmailUp.BorderColorFocused = System.Drawing.Color.Orange;
            this.txtEmailUp.BorderColorIdle = System.Drawing.Color.Gray;
            this.txtEmailUp.BorderColorMouseHover = System.Drawing.Color.Orange;
            this.txtEmailUp.BorderThickness = 2;
            this.txtEmailUp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Transition.SetDecoration(this.txtEmailUp, BunifuAnimatorNS.DecorationType.None);
            this.txtEmailUp.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtEmailUp.ForeColor = System.Drawing.Color.Black;
            this.txtEmailUp.isPassword = false;
            this.txtEmailUp.Location = new System.Drawing.Point(27, 218);
            this.txtEmailUp.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailUp.Name = "txtEmailUp";
            this.txtEmailUp.Size = new System.Drawing.Size(388, 44);
            this.txtEmailUp.TabIndex = 5;
            this.txtEmailUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.Transition.SetDecoration(this.lblLastName, BunifuAnimatorNS.DecorationType.None);
            this.lblLastName.Font = new System.Drawing.Font("Nexa Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.ForeColor = System.Drawing.Color.Black;
            this.lblLastName.Location = new System.Drawing.Point(222, 96);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(71, 16);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Username";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderColorFocused = System.Drawing.Color.Orange;
            this.txtUsername.BorderColorIdle = System.Drawing.Color.Gray;
            this.txtUsername.BorderColorMouseHover = System.Drawing.Color.Orange;
            this.txtUsername.BorderThickness = 2;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Transition.SetDecoration(this.txtUsername, BunifuAnimatorNS.DecorationType.None);
            this.txtUsername.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.isPassword = false;
            this.txtUsername.Location = new System.Drawing.Point(225, 116);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(190, 44);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.Transition.SetDecoration(this.lblFirstName, BunifuAnimatorNS.DecorationType.None);
            this.lblFirstName.Font = new System.Drawing.Font("Nexa Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.ForeColor = System.Drawing.Color.Black;
            this.lblFirstName.Location = new System.Drawing.Point(24, 96);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(68, 16);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "Full Name";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.BorderColorFocused = System.Drawing.Color.Orange;
            this.txtName.BorderColorIdle = System.Drawing.Color.Gray;
            this.txtName.BorderColorMouseHover = System.Drawing.Color.Orange;
            this.txtName.BorderThickness = 2;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Transition.SetDecoration(this.txtName, BunifuAnimatorNS.DecorationType.None);
            this.txtName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.isPassword = false;
            this.txtName.Location = new System.Drawing.Point(27, 116);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(190, 44);
            this.txtName.TabIndex = 1;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblSignUp
            // 
            this.Transition.SetDecoration(this.lblSignUp, BunifuAnimatorNS.DecorationType.None);
            this.lblSignUp.Font = new System.Drawing.Font("Nexa Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignUp.ForeColor = System.Drawing.Color.Black;
            this.lblSignUp.Location = new System.Drawing.Point(3, 17);
            this.lblSignUp.Name = "lblSignUp";
            this.lblSignUp.Size = new System.Drawing.Size(427, 48);
            this.lblSignUp.TabIndex = 0;
            this.lblSignUp.Text = "Sign Up Form";
            this.lblSignUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSignUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            // 
            // btnSignUp
            // 
            this.btnSignUp.ActiveBorderThickness = 1;
            this.btnSignUp.ActiveCornerRadius = 1;
            this.btnSignUp.ActiveFillColor = System.Drawing.Color.Orange;
            this.btnSignUp.ActiveForecolor = System.Drawing.Color.White;
            this.btnSignUp.ActiveLineColor = System.Drawing.Color.Orange;
            this.btnSignUp.BackColor = System.Drawing.Color.White;
            this.btnSignUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSignUp.BackgroundImage")));
            this.btnSignUp.ButtonText = "SIGN UP";
            this.btnSignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Transition.SetDecoration(this.btnSignUp, BunifuAnimatorNS.DecorationType.None);
            this.btnSignUp.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSignUp.IdleBorderThickness = 1;
            this.btnSignUp.IdleCornerRadius = 1;
            this.btnSignUp.IdleFillColor = System.Drawing.Color.White;
            this.btnSignUp.IdleForecolor = System.Drawing.Color.Black;
            this.btnSignUp.IdleLineColor = System.Drawing.Color.White;
            this.btnSignUp.Location = new System.Drawing.Point(497, 72);
            this.btnSignUp.Margin = new System.Windows.Forms.Padding(5);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(138, 63);
            this.btnSignUp.TabIndex = 12;
            this.btnSignUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // panelSignIn
            // 
            this.panelSignIn.Controls.Add(this.bunifuCustomLabel1);
            this.panelSignIn.Controls.Add(this.btnSignInConfirm);
            this.panelSignIn.Controls.Add(this.lblPasswordIn);
            this.panelSignIn.Controls.Add(this.txtPasswordIn);
            this.panelSignIn.Controls.Add(this.lblEmailIn);
            this.panelSignIn.Controls.Add(this.txtEmailIn);
            this.panelSignIn.Controls.Add(this.lblSignIn);
            this.Transition.SetDecoration(this.panelSignIn, BunifuAnimatorNS.DecorationType.None);
            this.panelSignIn.Location = new System.Drawing.Point(270, 136);
            this.panelSignIn.Name = "panelSignIn";
            this.panelSignIn.Size = new System.Drawing.Size(433, 483);
            this.panelSignIn.TabIndex = 13;
            this.panelSignIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            // 
            // btnSignInConfirm
            // 
            this.btnSignInConfirm.ActiveBorderThickness = 1;
            this.btnSignInConfirm.ActiveCornerRadius = 1;
            this.btnSignInConfirm.ActiveFillColor = System.Drawing.Color.DarkOrange;
            this.btnSignInConfirm.ActiveForecolor = System.Drawing.Color.White;
            this.btnSignInConfirm.ActiveLineColor = System.Drawing.Color.DarkOrange;
            this.btnSignInConfirm.BackColor = System.Drawing.Color.White;
            this.btnSignInConfirm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSignInConfirm.BackgroundImage")));
            this.btnSignInConfirm.ButtonText = "SIGN IN";
            this.btnSignInConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Transition.SetDecoration(this.btnSignInConfirm, BunifuAnimatorNS.DecorationType.None);
            this.btnSignInConfirm.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignInConfirm.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSignInConfirm.IdleBorderThickness = 1;
            this.btnSignInConfirm.IdleCornerRadius = 1;
            this.btnSignInConfirm.IdleFillColor = System.Drawing.Color.Orange;
            this.btnSignInConfirm.IdleForecolor = System.Drawing.Color.White;
            this.btnSignInConfirm.IdleLineColor = System.Drawing.Color.Orange;
            this.btnSignInConfirm.Location = new System.Drawing.Point(27, 361);
            this.btnSignInConfirm.Margin = new System.Windows.Forms.Padding(5);
            this.btnSignInConfirm.Name = "btnSignInConfirm";
            this.btnSignInConfirm.Size = new System.Drawing.Size(388, 63);
            this.btnSignInConfirm.TabIndex = 11;
            this.btnSignInConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSignInConfirm.Click += new System.EventHandler(this.btnSignInConfirm_Click);
            // 
            // lblPasswordIn
            // 
            this.lblPasswordIn.AutoSize = true;
            this.Transition.SetDecoration(this.lblPasswordIn, BunifuAnimatorNS.DecorationType.None);
            this.lblPasswordIn.Font = new System.Drawing.Font("Nexa Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordIn.ForeColor = System.Drawing.Color.Black;
            this.lblPasswordIn.Location = new System.Drawing.Point(24, 256);
            this.lblPasswordIn.Name = "lblPasswordIn";
            this.lblPasswordIn.Size = new System.Drawing.Size(68, 16);
            this.lblPasswordIn.TabIndex = 8;
            this.lblPasswordIn.Text = "Password";
            this.lblPasswordIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPasswordIn
            // 
            this.txtPasswordIn.BorderColorFocused = System.Drawing.Color.Orange;
            this.txtPasswordIn.BorderColorIdle = System.Drawing.Color.Gray;
            this.txtPasswordIn.BorderColorMouseHover = System.Drawing.Color.Orange;
            this.txtPasswordIn.BorderThickness = 2;
            this.txtPasswordIn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Transition.SetDecoration(this.txtPasswordIn, BunifuAnimatorNS.DecorationType.None);
            this.txtPasswordIn.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPasswordIn.ForeColor = System.Drawing.Color.Black;
            this.txtPasswordIn.isPassword = true;
            this.txtPasswordIn.Location = new System.Drawing.Point(27, 276);
            this.txtPasswordIn.Margin = new System.Windows.Forms.Padding(4);
            this.txtPasswordIn.Name = "txtPasswordIn";
            this.txtPasswordIn.Size = new System.Drawing.Size(388, 44);
            this.txtPasswordIn.TabIndex = 7;
            this.txtPasswordIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblEmailIn
            // 
            this.lblEmailIn.AutoSize = true;
            this.Transition.SetDecoration(this.lblEmailIn, BunifuAnimatorNS.DecorationType.None);
            this.lblEmailIn.Font = new System.Drawing.Font("Nexa Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailIn.ForeColor = System.Drawing.Color.Black;
            this.lblEmailIn.Location = new System.Drawing.Point(24, 134);
            this.lblEmailIn.Name = "lblEmailIn";
            this.lblEmailIn.Size = new System.Drawing.Size(40, 16);
            this.lblEmailIn.TabIndex = 6;
            this.lblEmailIn.Text = "Email";
            this.lblEmailIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEmailIn
            // 
            this.txtEmailIn.BorderColorFocused = System.Drawing.Color.Orange;
            this.txtEmailIn.BorderColorIdle = System.Drawing.Color.Gray;
            this.txtEmailIn.BorderColorMouseHover = System.Drawing.Color.Orange;
            this.txtEmailIn.BorderThickness = 2;
            this.txtEmailIn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Transition.SetDecoration(this.txtEmailIn, BunifuAnimatorNS.DecorationType.None);
            this.txtEmailIn.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtEmailIn.ForeColor = System.Drawing.Color.Black;
            this.txtEmailIn.isPassword = false;
            this.txtEmailIn.Location = new System.Drawing.Point(27, 154);
            this.txtEmailIn.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailIn.Name = "txtEmailIn";
            this.txtEmailIn.Size = new System.Drawing.Size(388, 44);
            this.txtEmailIn.TabIndex = 5;
            this.txtEmailIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblSignIn
            // 
            this.Transition.SetDecoration(this.lblSignIn, BunifuAnimatorNS.DecorationType.None);
            this.lblSignIn.Font = new System.Drawing.Font("Nexa Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignIn.ForeColor = System.Drawing.Color.Black;
            this.lblSignIn.Location = new System.Drawing.Point(3, 18);
            this.lblSignIn.Name = "lblSignIn";
            this.lblSignIn.Size = new System.Drawing.Size(427, 48);
            this.lblSignIn.TabIndex = 0;
            this.lblSignIn.Text = "Sign In Form";
            this.lblSignIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSignIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            // 
            // Transition
            // 
            this.Transition.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.Transition.Cursor = null;
            animation5.AnimateOnlyDifferences = true;
            animation5.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.BlindCoeff")));
            animation5.LeafCoeff = 0F;
            animation5.MaxTime = 1F;
            animation5.MinTime = 0F;
            animation5.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.MosaicCoeff")));
            animation5.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation5.MosaicShift")));
            animation5.MosaicSize = 0;
            animation5.Padding = new System.Windows.Forms.Padding(0);
            animation5.RotateCoeff = 0F;
            animation5.RotateLimit = 0F;
            animation5.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.ScaleCoeff")));
            animation5.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.SlideCoeff")));
            animation5.TimeCoeff = 0F;
            animation5.TransparencyCoeff = 1F;
            this.Transition.DefaultAnimation = animation5;
            // 
            // ButtonHighlight
            // 
            this.ButtonHighlight.BackColor = System.Drawing.Color.Transparent;
            this.Transition.SetDecoration(this.ButtonHighlight, BunifuAnimatorNS.DecorationType.None);
            this.ButtonHighlight.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.ButtonHighlight.LineThickness = 5;
            this.ButtonHighlight.Location = new System.Drawing.Point(350, 130);
            this.ButtonHighlight.Name = "ButtonHighlight";
            this.ButtonHighlight.Size = new System.Drawing.Size(137, 5);
            this.ButtonHighlight.TabIndex = 14;
            this.ButtonHighlight.Transparency = 255;
            this.ButtonHighlight.Vertical = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuCustomLabel1
            // 
            this.Transition.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Crimson;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(23, 90);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(214, 28);
            this.bunifuCustomLabel1.TabIndex = 12;
            this.bunifuCustomLabel1.Text = "Invalid Email / Password";
            this.bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1390, 669);
            this.Controls.Add(this.ButtonHighlight);
            this.Controls.Add(this.picGoldline);
            this.Controls.Add(this.panelSignIn);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.panelSignUp);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.SideBar);
            this.Transition.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.SideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGoldline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panelSignUp.ResumeLayout(false);
            this.panelSignUp.PerformLayout();
            this.panelSignIn.ResumeLayout(false);
            this.panelSignIn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SideBar;
        private System.Windows.Forms.PictureBox picGoldline;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblLogoText;
        private System.Windows.Forms.PictureBox picClose;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSignIn;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSignUpConfirm;
        private System.Windows.Forms.Panel panelSignUp;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSignUp;
        private Bunifu.Framework.UI.BunifuCustomLabel lblSignUp;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtName;
        private Bunifu.Framework.UI.BunifuCustomLabel lblFirstName;
        private Bunifu.Framework.UI.BunifuCustomLabel lblLastName;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtUsername;
        private Bunifu.Framework.UI.BunifuCustomLabel lblEmailUp;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtEmailUp;
        private Bunifu.Framework.UI.BunifuCustomLabel lblPasswordUp;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtPasswordUp;
        private System.Windows.Forms.Panel panelSignIn;
        private Bunifu.Framework.UI.BunifuCustomLabel lblPasswordIn;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtPasswordIn;
        private Bunifu.Framework.UI.BunifuCustomLabel lblEmailIn;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtEmailIn;
        private Bunifu.Framework.UI.BunifuCustomLabel lblSignIn;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSignInConfirm;
        private BunifuAnimatorNS.BunifuTransition Transition;
        private Bunifu.Framework.UI.BunifuSeparator ButtonHighlight;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
    }
}