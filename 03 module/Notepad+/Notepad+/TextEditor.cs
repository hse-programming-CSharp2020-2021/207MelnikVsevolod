using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Notepad_
{
    public partial class TextEditor : UserControl
    {
        string buffer;
        public Settings settings = new Settings();
        public string filePath = "";

        public RichTextBox EditorTextBox
        {
            get { return richTextBox1; }
        }

        public TextEditor()
        {
            InitializeComponent();
        }

        public TextEditor(Settings s)
        {
            InitializeComponent();
            settings = s;
            BackColor = s.color1;
            ForeColor = s.color2;
            richTextBox1.BackColor = s.color1;
            richTextBox1.ForeColor = s.color2;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextEditor_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem allMenuItem = new ToolStripMenuItem("Выбрать всё");
            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Копировать");
            ToolStripMenuItem removeMenuItem = new ToolStripMenuItem("Вырезать");
            ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem("Вставить");
            ToolStripMenuItem formatMenuItem = new ToolStripMenuItem("Форматирование");

            contextMenuStrip1.Items.AddRange(new[] { allMenuItem, copyMenuItem, removeMenuItem, pasteMenuItem, formatMenuItem });
            richTextBox1.ContextMenuStrip = contextMenuStrip1;

            allMenuItem.Click += allMenuItem_Click;
            copyMenuItem.Click += copyMenuItem_Click;
            pasteMenuItem.Click += pasteMenuItem_Click;
            removeMenuItem.Click += removeMenuItem_Click;
            formatMenuItem.Click += formatMenuItem_Click;
        }

        // Вставка текста.
        void pasteMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        // Копирование текста.
        void copyMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
                Clipboard.SetText(richTextBox1.SelectedText);
        }

        // Вырезать текст.
        void removeMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                Clipboard.SetText(richTextBox1.SelectedText);
                richTextBox1.SelectedText = "";
            }
        }

        // Выбрать весь текст.
        void allMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        // Изменить шрифт.
        void formatMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = richTextBox1.SelectionFont;
            dialog.ShowDialog();
            richTextBox1.SelectionFont = dialog.Font;
        }

        /// <summary>
        /// Save text to file.
        /// </summary>
        public void SaveFile()
        {
            try
            {
                richTextBox1.SaveFile(filePath);
            }
            catch (Exception e)
            {
                try
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.ShowDialog();
                    filePath = dialog.FileName;
                    richTextBox1.SaveFile(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось сохранить, так как " + ex.Message);
                }
            }
        }

        void pass()
        {

        }

        /// <summary>
        /// Save file automatically.
        /// </summary>
        public void AutoSave()
        {
            try
            {
                richTextBox1.SaveFile(filePath);
            }
            catch (Exception ex)
            {
                pass();
            }
        }
    }
}
