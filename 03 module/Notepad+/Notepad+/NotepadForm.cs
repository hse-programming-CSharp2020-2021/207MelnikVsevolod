using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_
{
    public partial class NotepadForm : Form
    {
        Settings settings = new Settings();

        public NotepadForm()
        {
            InitializeComponent();
        }

        private void NotepadForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = settings.interval;
            timer1.Start();

            newTabStripMenuItem.Click += NewTab;
            newWindowStripMenuItem.Click += NewWindow;
            saveStripMenuItem.Click += Save;
            saveAllStripMenuItem.Click += SaveAll;
            exitStripMenuItem.Click += Exit;
            formatStripMenuItem.Click += Format;
            settingsStripMenuItem.Click += OpenSettings;
        }

        /// <summary>
        /// Create new tab.
        /// </summary>
        private void NewTab(object sender, EventArgs e)
        {
            EditorTab newTab = new EditorTab("Новый файл", settings);
            tabControl.TabPages.Add(newTab);
        }

        /// <summary>
        /// Create new window.
        /// </summary>
        private void NewWindow(object sender, EventArgs e)
        {
            NotepadForm newWindow = new NotepadForm();
            newWindow.NewTab(sender, e);
            newWindow.tabControl.TabPages.Remove(newWindow.tabPage1);
            newWindow.Show();
        }

        /// <summary>
        /// Save current file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab != null)
            {
                EditorTab tab = tabControl.SelectedTab as EditorTab;
                if (tab != null)
                    tab.SaveFile();
            }
        }

        /// <summary>
        /// Save all files opened in tabs of the current window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAll(object sender, EventArgs e)
        {
            foreach(TabPage tab in tabControl.TabPages)
            {
                EditorTab editorTab = tab as EditorTab;
                if (editorTab != null)
                    editorTab.SaveFile();
            }
        }

        /// <summary>
        /// Save all files automatically.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoSave(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabControl.TabPages)
            {
                EditorTab editorTab = tab as EditorTab;
                if (editorTab != null)
                    editorTab.AutoSave();
            }
        }

        /// <summary>
        /// Close the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Choose font for current tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Format(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab != null)
            {
                EditorTab tab = tabControl.SelectedTab as EditorTab;
                if (tab != null)
                {
                    FontDialog dialog = new FontDialog();
                    dialog.Font = tab.editor.EditorTextBox.SelectionFont;
                    dialog.ShowDialog();
                    tab.editor.EditorTextBox.SelectionFont = dialog.Font;
                }
            }
        }

        /// <summary>
        /// Open application settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSettings(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(settings);
            form.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AutoSave(sender, e);
        }

        private void NotepadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Сохранить изменения?", "Закрыть окно", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
                SaveAll(sender, e);
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        /// <summary>
        /// Apply changes in ui colors.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotepadForm_Activated(object sender, EventArgs e)
        {
            this.BackColor = settings.color3;
            this.ForeColor = settings.color2;
            foreach (Control item in this.Controls)
            {
                item.BackColor = settings.color3;
                item.ForeColor = settings.color2;
            }
            foreach (TabPage tab in tabControl.TabPages)
            {
                foreach (Control item in tab.Controls)
                {
                    item.BackColor = settings.color1;
                    item.ForeColor = settings.color2;
                }
                EditorTab editorTab = tab as EditorTab;
                if (editorTab != null)
                {
                    editorTab.editor.EditorTextBox.BackColor = settings.color1;
                    editorTab.editor.EditorTextBox.ForeColor = settings.color2;
                }
            }
        }
    }
}
