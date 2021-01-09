namespace GwiezdnaFlota
{
    partial class GameWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.MenuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ScorePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ScoreTextBox = new System.Windows.Forms.TextBox();
            this.ButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.NextLevelButton = new System.Windows.Forms.Button();
            this.RestartLevelButton = new System.Windows.Forms.Button();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.MenuPanel.SuspendLayout();
            this.ScorePanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.AllowDrop = true;
            this.MenuPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MenuPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.MenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MenuPanel.Controls.Add(this.ScorePanel);
            this.MenuPanel.Controls.Add(this.ButtonPanel);
            this.MenuPanel.Location = new System.Drawing.Point(0, 590);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(1002, 126);
            this.MenuPanel.TabIndex = 1;
            // 
            // ScorePanel
            // 
            this.ScorePanel.Controls.Add(this.ScoreTextBox);
            this.ScorePanel.Location = new System.Drawing.Point(3, 3);
            this.ScorePanel.Name = "ScorePanel";
            this.ScorePanel.Size = new System.Drawing.Size(516, 94);
            this.ScorePanel.TabIndex = 0;
            // 
            // ScoreTextBox
            // 
            this.ScoreTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ScoreTextBox.Location = new System.Drawing.Point(3, 3);
            this.ScoreTextBox.Multiline = true;
            this.ScoreTextBox.Name = "ScoreTextBox";
            this.ScoreTextBox.ReadOnly = true;
            this.ScoreTextBox.Size = new System.Drawing.Size(374, 80);
            this.ScoreTextBox.TabIndex = 0;
            this.ScoreTextBox.Text = "Score:";
            this.ScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.NextLevelButton);
            this.ButtonPanel.Controls.Add(this.RestartLevelButton);
            this.ButtonPanel.Location = new System.Drawing.Point(525, 3);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(466, 100);
            this.ButtonPanel.TabIndex = 1;
            // 
            // NextLevelButton
            // 
            this.NextLevelButton.Location = new System.Drawing.Point(3, 3);
            this.NextLevelButton.Name = "NextLevelButton";
            this.NextLevelButton.Size = new System.Drawing.Size(200, 80);
            this.NextLevelButton.TabIndex = 0;
            this.NextLevelButton.Text = "Next Level";
            this.NextLevelButton.UseVisualStyleBackColor = true;
            this.NextLevelButton.Click += new System.EventHandler(this.NextLevelButton_Click);
            // 
            // RestartLevelButton
            // 
            this.RestartLevelButton.Location = new System.Drawing.Point(209, 3);
            this.RestartLevelButton.Name = "RestartLevelButton";
            this.RestartLevelButton.Size = new System.Drawing.Size(200, 80);
            this.RestartLevelButton.TabIndex = 1;
            this.RestartLevelButton.Text = "Restart Level";
            this.RestartLevelButton.UseVisualStyleBackColor = true;
            this.RestartLevelButton.Click += new System.EventHandler(this.RestartLevelButton_Click);
            // 
            // GamePanel
            // 
            this.GamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.GamePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GamePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GamePanel.BackgroundImage")));
            this.GamePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GamePanel.Location = new System.Drawing.Point(0, 0);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(1002, 589);
            this.GamePanel.TabIndex = 2;
            this.GamePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GamePanel_MouseClick);
            this.GamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GamePanel_MouseMove);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 717);
            this.Controls.Add(this.GamePanel);
            this.Controls.Add(this.MenuPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "GameWindow";
            this.Text = "Gwiezdna Flota";
            this.MenuPanel.ResumeLayout(false);
            this.ScorePanel.ResumeLayout(false);
            this.ScorePanel.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MenuPanel;
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.FlowLayoutPanel ScorePanel;
        private System.Windows.Forms.TextBox ScoreTextBox;
        private System.Windows.Forms.FlowLayoutPanel ButtonPanel;
        private System.Windows.Forms.Button NextLevelButton;
        private System.Windows.Forms.Button RestartLevelButton;
    }
}

