namespace Space_Runner
{
    partial class InstructionsScreen
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
            this.InstructionsTitleLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InstructionsTitleLabel
            // 
            this.InstructionsTitleLabel.AutoSize = true;
            this.InstructionsTitleLabel.Font = new System.Drawing.Font("Showcard Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsTitleLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.InstructionsTitleLabel.Location = new System.Drawing.Point(71, 10);
            this.InstructionsTitleLabel.Name = "InstructionsTitleLabel";
            this.InstructionsTitleLabel.Size = new System.Drawing.Size(538, 50);
            this.InstructionsTitleLabel.TabIndex = 3;
            this.InstructionsTitleLabel.Text = "SPACE RUN INSTRUCTIONS";
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.backButton.Font = new System.Drawing.Font("Showcard Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.backButton.Location = new System.Drawing.Point(245, 399);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(186, 101);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // InstructionsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.InstructionsTitleLabel);
            this.Name = "InstructionsScreen";
            this.Size = new System.Drawing.Size(698, 503);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InstructionsTitleLabel;
        private System.Windows.Forms.Button backButton;
    }
}
