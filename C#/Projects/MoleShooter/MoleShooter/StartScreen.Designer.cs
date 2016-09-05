namespace MoleShooter
{
    partial class StartScreen
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
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.startGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startGameButton
            // 
            this.startGameButton.BackColor = System.Drawing.Color.YellowGreen;
            this.startGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startGameButton.Location = new System.Drawing.Point(178, 42);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(254, 70);
            this.startGameButton.TabIndex = 0;
            this.startGameButton.Text = "START GAME";
            this.startGameButton.UseVisualStyleBackColor = false;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MoleShooter.Properties.Resources.StartScreenBackground;
            this.ClientSize = new System.Drawing.Size(600, 438);
            this.Controls.Add(this.startGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StartScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start Screen";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button startGameButton;
    }
}