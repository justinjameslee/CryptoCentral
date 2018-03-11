namespace CryptoCentral
{
    partial class DialogSuccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogSuccess));
            this.DragForm = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.FormFade = new Bunifu.Framework.UI.BunifuFormFadeTransition(this.components);
            this.timerIconDelay = new System.Windows.Forms.Timer(this.components);
            this.lblSuccess = new System.Windows.Forms.Label();
            this.btnConfirm = new Bunifu.Framework.UI.BunifuFlatButton();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.Background = new System.Windows.Forms.Panel();
            this.DragLabel = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.Background.SuspendLayout();
            this.SuspendLayout();
            // 
            // DragForm
            // 
            this.DragForm.Fixed = true;
            this.DragForm.Horizontal = true;
            this.DragForm.TargetControl = this.Background;
            this.DragForm.Vertical = true;
            // 
            // FormFade
            // 
            this.FormFade.Delay = 1;
            this.FormFade.TransitionEnd += new System.EventHandler(this.FormFade_TransitionEnd);
            // 
            // timerIconDelay
            // 
            this.timerIconDelay.Enabled = true;
            this.timerIconDelay.Interval = 4000;
            this.timerIconDelay.Tick += new System.EventHandler(this.timerIconDelay_Tick);
            // 
            // lblSuccess
            // 
            this.lblSuccess.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuccess.ForeColor = System.Drawing.Color.Gray;
            this.lblSuccess.Location = new System.Drawing.Point(-4, 163);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(531, 41);
            this.lblSuccess.TabIndex = 3;
            this.lblSuccess.Text = "Success";
            this.lblSuccess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(180)))), ((int)(((byte)(63)))));
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirm.BorderRadius = 7;
            this.btnConfirm.ButtonText = "OK";
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.DisabledColor = System.Drawing.Color.Gray;
            this.btnConfirm.Iconcolor = System.Drawing.Color.Transparent;
            this.btnConfirm.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Iconimage")));
            this.btnConfirm.Iconimage_right = null;
            this.btnConfirm.Iconimage_right_Selected = null;
            this.btnConfirm.Iconimage_Selected = null;
            this.btnConfirm.IconMarginLeft = 0;
            this.btnConfirm.IconMarginRight = 0;
            this.btnConfirm.IconRightVisible = false;
            this.btnConfirm.IconRightZoom = 0D;
            this.btnConfirm.IconVisible = false;
            this.btnConfirm.IconZoom = 90D;
            this.btnConfirm.IsTab = false;
            this.btnConfirm.Location = new System.Drawing.Point(200, 217);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(180)))), ((int)(((byte)(63)))));
            this.btnConfirm.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(210)))), ((int)(((byte)(63)))));
            this.btnConfirm.OnHoverTextColor = System.Drawing.Color.White;
            this.btnConfirm.selected = false;
            this.btnConfirm.Size = new System.Drawing.Size(122, 48);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "OK";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfirm.Textcolor = System.Drawing.Color.White;
            this.btnConfirm.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Visible = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // picIcon
            // 
            this.picIcon.Image = global::CryptoCentral.Properties.Resources.DialogSuccess;
            this.picIcon.Location = new System.Drawing.Point(70, -40);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(385, 251);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // Background
            // 
            this.Background.BackColor = System.Drawing.Color.White;
            this.Background.Controls.Add(this.lblSuccess);
            this.Background.Controls.Add(this.picIcon);
            this.Background.Controls.Add(this.btnConfirm);
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Location = new System.Drawing.Point(2, 2);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(527, 313);
            this.Background.TabIndex = 4;
            // 
            // DragLabel
            // 
            this.DragLabel.Fixed = true;
            this.DragLabel.Horizontal = true;
            this.DragLabel.TargetControl = this.lblSuccess;
            this.DragLabel.Vertical = true;
            // 
            // DialogSuccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(531, 317);
            this.Controls.Add(this.Background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DialogSuccess";
            this.Opacity = 0D;
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog";
            this.Load += new System.EventHandler(this.DialogSuccess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.Background.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl DragForm;
        private Bunifu.Framework.UI.BunifuFormFadeTransition FormFade;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Timer timerIconDelay;
        private Bunifu.Framework.UI.BunifuFlatButton btnConfirm;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.Panel Background;
        private Bunifu.Framework.UI.BunifuDragControl DragLabel;
    }
}