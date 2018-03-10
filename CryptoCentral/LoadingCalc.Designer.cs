namespace CryptoCentral
{
    partial class LoadingCalc
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
            this.NoBorder = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            this.LoadingPanelGif = new System.Windows.Forms.PictureBox();
            this.LoadingIndicator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingPanelGif)).BeginInit();
            this.SuspendLayout();
            // 
            // NoBorder
            // 
            this.NoBorder.ElipseRadius = 0;
            this.NoBorder.TargetControl = this;
            // 
            // timerLoading
            // 
            this.timerLoading.Enabled = true;
            this.timerLoading.Interval = 10;
            this.timerLoading.Tick += new System.EventHandler(this.timerLoading_Tick);
            // 
            // LoadingPanelGif
            // 
            this.LoadingPanelGif.Image = global::CryptoCentral.Properties.Resources.Double_Ring_1_5s_200px;
            this.LoadingPanelGif.Location = new System.Drawing.Point(311, 134);
            this.LoadingPanelGif.Name = "LoadingPanelGif";
            this.LoadingPanelGif.Size = new System.Drawing.Size(200, 200);
            this.LoadingPanelGif.TabIndex = 70;
            this.LoadingPanelGif.TabStop = false;
            // 
            // LoadingIndicator
            // 
            this.LoadingIndicator.BackColor = System.Drawing.Color.Transparent;
            this.LoadingIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.LoadingIndicator.ForeColor = System.Drawing.Color.DarkOrange;
            this.LoadingIndicator.Location = new System.Drawing.Point(366, 213);
            this.LoadingIndicator.Name = "LoadingIndicator";
            this.LoadingIndicator.Size = new System.Drawing.Size(86, 44);
            this.LoadingIndicator.TabIndex = 71;
            this.LoadingIndicator.Text = "100";
            this.LoadingIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadingCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(843, 468);
            this.Controls.Add(this.LoadingIndicator);
            this.Controls.Add(this.LoadingPanelGif);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingCalc";
            this.Text = "Loading";
            this.Load += new System.EventHandler(this.Loading_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LoadingPanelGif)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse NoBorder;
        private System.Windows.Forms.Timer timerLoading;
        public System.Windows.Forms.PictureBox LoadingPanelGif;
        public System.Windows.Forms.Label LoadingIndicator;
    }
}