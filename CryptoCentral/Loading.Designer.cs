namespace CryptoCentral
{
    partial class Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.NoBorder = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.SummaryLoadingBar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // NoBorder
            // 
            this.NoBorder.ElipseRadius = 0;
            this.NoBorder.TargetControl = this;
            // 
            // SummaryLoadingBar
            // 
            this.SummaryLoadingBar.animated = false;
            this.SummaryLoadingBar.animationIterval = 5;
            this.SummaryLoadingBar.animationSpeed = 300;
            this.SummaryLoadingBar.AutoSize = true;
            this.SummaryLoadingBar.BackColor = System.Drawing.Color.White;
            this.SummaryLoadingBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SummaryLoadingBar.BackgroundImage")));
            this.SummaryLoadingBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.SummaryLoadingBar.ForeColor = System.Drawing.Color.DarkOrange;
            this.SummaryLoadingBar.LabelVisible = true;
            this.SummaryLoadingBar.LineProgressThickness = 8;
            this.SummaryLoadingBar.LineThickness = 5;
            this.SummaryLoadingBar.Location = new System.Drawing.Point(311, 146);
            this.SummaryLoadingBar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.SummaryLoadingBar.MaxValue = 100;
            this.SummaryLoadingBar.Name = "SummaryLoadingBar";
            this.SummaryLoadingBar.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.SummaryLoadingBar.ProgressColor = System.Drawing.Color.Orange;
            this.SummaryLoadingBar.Size = new System.Drawing.Size(201, 201);
            this.SummaryLoadingBar.TabIndex = 69;
            this.SummaryLoadingBar.Value = 0;
            // 
            // timerLoading
            // 
            this.timerLoading.Enabled = true;
            this.timerLoading.Interval = 50;
            this.timerLoading.Tick += new System.EventHandler(this.timerLoading_Tick);
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(843, 468);
            this.Controls.Add(this.SummaryLoadingBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loading";
            this.Text = "Loading";
            this.Load += new System.EventHandler(this.Loading_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse NoBorder;
        private Bunifu.Framework.UI.BunifuCircleProgressbar SummaryLoadingBar;
        private System.Windows.Forms.Timer timerLoading;
    }
}