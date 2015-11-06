namespace GameOfLifeUi
{
    partial class MainForm
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
			this.updateTimer = new System.Windows.Forms.Timer(this.components);
			this.fieldPanel = new DoubleBufferedPanel();
			this.SuspendLayout();
			// 
			// updateTimer
			// 
			this.updateTimer.Interval = 125;
			this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
			// 
			// fieldPanel
			// 
			this.fieldPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fieldPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.fieldPanel.Location = new System.Drawing.Point(12, 12);
			this.fieldPanel.Name = "fieldPanel";
			this.fieldPanel.Size = new System.Drawing.Size(266, 241);
			this.fieldPanel.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(290, 265);
			this.Controls.Add(this.fieldPanel);
			this.Name = "MainForm";
			this.Text = "Game Of Life";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer updateTimer;
		private DoubleBufferedPanel fieldPanel;
	}
}

