namespace Notepad_
{
    partial class NotepadForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTabStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notepadTabControl1 = new Notepad_.NotepadTabControl();
            this.tabPage1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 223);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Справка";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(786, 217);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Добро пожаловать!";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(0, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 251);
            this.tabControl.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileStripMenuItem,
            this.editStripMenuItem,
            this.formatStripMenuItem,
            this.settingsStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileStripMenuItem
            // 
            this.fileStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTabStripMenuItem,
            this.newWindowStripMenuItem,
            this.saveStripMenuItem,
            this.saveAllStripMenuItem,
            this.exitStripMenuItem});
            this.fileStripMenuItem.Name = "fileStripMenuItem";
            this.fileStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileStripMenuItem.Text = "Файл";
            // 
            // newTabStripMenuItem
            // 
            this.newTabStripMenuItem.Name = "newTabStripMenuItem";
            this.newTabStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.newTabStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.newTabStripMenuItem.Text = "Новая вкладка";
            // 
            // newWindowStripMenuItem
            // 
            this.newWindowStripMenuItem.Name = "newWindowStripMenuItem";
            this.newWindowStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.newWindowStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.newWindowStripMenuItem.Text = "Новое окно";
            // 
            // saveStripMenuItem
            // 
            this.saveStripMenuItem.Name = "saveStripMenuItem";
            this.saveStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.saveStripMenuItem.Text = "Сохранить";
            // 
            // saveAllStripMenuItem
            // 
            this.saveAllStripMenuItem.Name = "saveAllStripMenuItem";
            this.saveAllStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAllStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.saveAllStripMenuItem.Text = "Сохранить всё";
            // 
            // exitStripMenuItem
            // 
            this.exitStripMenuItem.Name = "exitStripMenuItem";
            this.exitStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.exitStripMenuItem.Text = "Выход";
            // 
            // editStripMenuItem
            // 
            this.editStripMenuItem.Name = "editStripMenuItem";
            this.editStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.editStripMenuItem.Text = "Правка";
            // 
            // formatStripMenuItem
            // 
            this.formatStripMenuItem.Name = "formatStripMenuItem";
            this.formatStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.formatStripMenuItem.Text = "Формат";
            // 
            // settingsStripMenuItem
            // 
            this.settingsStripMenuItem.Name = "settingsStripMenuItem";
            this.settingsStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.settingsStripMenuItem.Text = "Настройки";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notepadTabControl1
            // 
            this.notepadTabControl1.Location = new System.Drawing.Point(12, 284);
            this.notepadTabControl1.Name = "notepadTabControl1";
            this.notepadTabControl1.Size = new System.Drawing.Size(598, 466);
            this.notepadTabControl1.TabIndex = 2;
            // 
            // NotepadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.notepadTabControl1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NotepadForm";
            this.Text = "Notepad+";
            this.Activated += new System.EventHandler(this.NotepadForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NotepadForm_FormClosing);
            this.Load += new System.EventHandler(this.NotepadForm_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem fileStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTabStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newWindowStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private NotepadTabControl notepadTabControl1;
    }
}

