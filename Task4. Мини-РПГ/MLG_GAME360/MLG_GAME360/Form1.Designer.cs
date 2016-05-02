namespace MLG_GAME360
{
    partial class Form1
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
            this.HistoryEvents = new System.Windows.Forms.ListBox();
            this.NewGame = new System.Windows.Forms.Button();
            this.Step = new System.Windows.Forms.Button();
            this.PlayerStats = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HistoryEvents
            // 
            this.HistoryEvents.FormattingEnabled = true;
            this.HistoryEvents.Location = new System.Drawing.Point(144, 11);
            this.HistoryEvents.Name = "HistoryEvents";
            this.HistoryEvents.Size = new System.Drawing.Size(802, 277);
            this.HistoryEvents.TabIndex = 0;
            // 
            // NewGame
            // 
            this.NewGame.Location = new System.Drawing.Point(12, 23);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(105, 23);
            this.NewGame.TabIndex = 1;
            this.NewGame.Text = "NewGame";
            this.NewGame.UseVisualStyleBackColor = true;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // Step
            // 
            this.Step.Location = new System.Drawing.Point(12, 66);
            this.Step.Name = "Step";
            this.Step.Size = new System.Drawing.Size(105, 23);
            this.Step.TabIndex = 2;
            this.Step.Text = "Step";
            this.Step.UseVisualStyleBackColor = true;
            this.Step.Click += new System.EventHandler(this.Step_Click);
            // 
            // PlayerStats
            // 
            this.PlayerStats.AutoSize = true;
            this.PlayerStats.Location = new System.Drawing.Point(141, 302);
            this.PlayerStats.Name = "PlayerStats";
            this.PlayerStats.Size = new System.Drawing.Size(60, 13);
            this.PlayerStats.TabIndex = 3;
            this.PlayerStats.Text = "PlayerStats";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 358);
            this.Controls.Add(this.PlayerStats);
            this.Controls.Add(this.Step);
            this.Controls.Add(this.NewGame);
            this.Controls.Add(this.HistoryEvents);
            this.Name = "Form1";
            this.Text = "MLG_GAME";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox HistoryEvents;
        private System.Windows.Forms.Button NewGame;
        private System.Windows.Forms.Button Step;
        private System.Windows.Forms.Label PlayerStats;
    }
}

