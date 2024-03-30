namespace Space_Runner
{
    partial class GameOverScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.gameOverTextLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Showcard Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.TitleLabel.Location = new System.Drawing.Point(360, 134);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(238, 50);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "SPACE RUN";
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.playButton.Font = new System.Drawing.Font("Showcard Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(211, 244);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(199, 101);
            this.playButton.TabIndex = 4;
            this.playButton.Text = "Play Again";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // gameOverTextLabel
            // 
            this.gameOverTextLabel.AutoSize = true;
            this.gameOverTextLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameOverTextLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gameOverTextLabel.Location = new System.Drawing.Point(387, 416);
            this.gameOverTextLabel.Name = "gameOverTextLabel";
            this.gameOverTextLabel.Size = new System.Drawing.Size(0, 20);
            this.gameOverTextLabel.TabIndex = 5;
            this.gameOverTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.exitButton.Font = new System.Drawing.Font("Showcard Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(530, 244);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(199, 101);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // GameOverScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.gameOverTextLabel);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.TitleLabel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "GameOverScreen";
            this.Size = new System.Drawing.Size(1000, 650);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label gameOverTextLabel;
        private System.Windows.Forms.Button exitButton;
    }
}
