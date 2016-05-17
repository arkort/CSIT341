namespace GeneratorPl
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.генерацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.случайнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сВыборомКолчичестваСловToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.генерацияАлгоримомМарковаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьСловаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ввестиТекстToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.задатьКоличесвоСловToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.генерацияToolStripMenuItem,
            this.загрузитьСловаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(546, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // генерацияToolStripMenuItem
            // 
            this.генерацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.случайнаяToolStripMenuItem,
            this.сВыборомКолчичестваСловToolStripMenuItem,
            this.генерацияАлгоримомМарковаToolStripMenuItem});
            this.генерацияToolStripMenuItem.Name = "генерацияToolStripMenuItem";
            this.генерацияToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.генерацияToolStripMenuItem.Text = "Генерация";
            // 
            // случайнаяToolStripMenuItem
            // 
            this.случайнаяToolStripMenuItem.Name = "случайнаяToolStripMenuItem";
            this.случайнаяToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.случайнаяToolStripMenuItem.Text = "Случайная";
            this.случайнаяToolStripMenuItem.Click += new System.EventHandler(this.случайнаяToolStripMenuItem_Click);
            // 
            // сВыборомКолчичестваСловToolStripMenuItem
            // 
            this.сВыборомКолчичестваСловToolStripMenuItem.Name = "сВыборомКолчичестваСловToolStripMenuItem";
            this.сВыборомКолчичестваСловToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.сВыборомКолчичестваСловToolStripMenuItem.Text = "С указанием колличества слов";
            this.сВыборомКолчичестваСловToolStripMenuItem.Click += new System.EventHandler(this.сВыборомКолчичестваСловToolStripMenuItem_Click);
            // 
            // генерацияАлгоримомМарковаToolStripMenuItem
            // 
            this.генерацияАлгоримомМарковаToolStripMenuItem.Name = "генерацияАлгоримомМарковаToolStripMenuItem";
            this.генерацияАлгоримомМарковаToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.генерацияАлгоримомМарковаToolStripMenuItem.Text = "Генерация Алгоримом Маркова";
            this.генерацияАлгоримомМарковаToolStripMenuItem.Click += new System.EventHandler(this.генерацияАлгоримомМарковаToolStripMenuItem_Click);
            // 
            // загрузитьСловаToolStripMenuItem
            // 
            this.загрузитьСловаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изФайлаToolStripMenuItem,
            this.ввестиТекстToolStripMenuItem,
            this.задатьКоличесвоСловToolStripMenuItem});
            this.загрузитьСловаToolStripMenuItem.Name = "загрузитьСловаToolStripMenuItem";
            this.загрузитьСловаToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.загрузитьСловаToolStripMenuItem.Text = "Загрузить";
            // 
            // изФайлаToolStripMenuItem
            // 
            this.изФайлаToolStripMenuItem.Name = "изФайлаToolStripMenuItem";
            this.изФайлаToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.изФайлаToolStripMenuItem.Text = "Из файла";
            this.изФайлаToolStripMenuItem.Click += new System.EventHandler(this.изФайлаToolStripMenuItem_Click);
            // 
            // ввестиТекстToolStripMenuItem
            // 
            this.ввестиТекстToolStripMenuItem.Name = "ввестиТекстToolStripMenuItem";
            this.ввестиТекстToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.ввестиТекстToolStripMenuItem.Text = "Ввести текст";
            this.ввестиТекстToolStripMenuItem.Click += new System.EventHandler(this.ввестиТекстToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(209, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // задатьКоличесвоСловToolStripMenuItem
            // 
            this.задатьКоличесвоСловToolStripMenuItem.Name = "задатьКоличесвоСловToolStripMenuItem";
            this.задатьКоличесвоСловToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.задатьКоличесвоСловToolStripMenuItem.Text = "Задать количесво слов";
            this.задатьКоличесвоСловToolStripMenuItem.Click += new System.EventHandler(this.задатьКоличесвоСловToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(315, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(527, 316);
            this.listBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 352);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem генерацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem случайнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сВыборомКолчичестваСловToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьСловаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ввестиТекстToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem генерацияАлгоримомМарковаToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem задатьКоличесвоСловToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

