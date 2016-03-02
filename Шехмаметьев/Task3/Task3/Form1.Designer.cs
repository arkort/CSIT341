namespace Task3
{
    partial class drawingForm
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
            this.chooseDrawFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openXMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToBinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToBinaryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromBinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBinary = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chooseDrawFileDialog
            // 
            this.chooseDrawFileDialog.FileName = "openFileDialog1";
            this.chooseDrawFileDialog.Filter = "Saved drawings|*.dat|XML files|*.xml";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openXMLFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(693, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openXMLFileToolStripMenuItem
            // 
            this.openXMLFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToBinaryToolStripMenuItem,
            this.saveToBinaryToolStripMenuItem1,
            this.loadFromBinaryToolStripMenuItem});
            this.openXMLFileToolStripMenuItem.Name = "openXMLFileToolStripMenuItem";
            this.openXMLFileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.openXMLFileToolStripMenuItem.Text = "File";
            // 
            // saveToBinaryToolStripMenuItem
            // 
            this.saveToBinaryToolStripMenuItem.Name = "saveToBinaryToolStripMenuItem";
            this.saveToBinaryToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.saveToBinaryToolStripMenuItem.Text = "Open XML file...";
            this.saveToBinaryToolStripMenuItem.Click += new System.EventHandler(this.openXmlFileToolStripMenuItem_Click);
            // 
            // saveToBinaryToolStripMenuItem1
            // 
            this.saveToBinaryToolStripMenuItem1.Name = "saveToBinaryToolStripMenuItem1";
            this.saveToBinaryToolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
            this.saveToBinaryToolStripMenuItem1.Text = "Save to binary...";
            this.saveToBinaryToolStripMenuItem1.Click += new System.EventHandler(this.saveToBinaryToolStripMenuItem1_Click);
            // 
            // loadFromBinaryToolStripMenuItem
            // 
            this.loadFromBinaryToolStripMenuItem.Name = "loadFromBinaryToolStripMenuItem";
            this.loadFromBinaryToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.loadFromBinaryToolStripMenuItem.Text = "Load from binary...";
            this.loadFromBinaryToolStripMenuItem.Click += new System.EventHandler(this.loadFromBinaryToolStripMenuItem_Click);
            // 
            // saveBinary
            // 
            this.saveBinary.Filter = "Binary files|*.dat";
            // 
            // drawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 255);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "drawingForm";
            this.Text = "Figure drawing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog chooseDrawFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openXMLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToBinaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToBinaryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadFromBinaryToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveBinary;
    }
}

