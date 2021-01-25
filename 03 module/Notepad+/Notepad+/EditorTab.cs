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
    class EditorTab : TabPage
    {
        // Text editor widget.
        public TextEditor editor;
        public Settings settings = new Settings();
        public string filePath = "";

        public EditorTab() : base()
        {
            editor = new TextEditor();
            editor.settings = settings;
            this.Controls.Add(editor);
            editor.Dock = DockStyle.Fill;
            this.BorderStyle = BorderStyle.None;
        }

        public EditorTab(string text) : base(text)
        {
            editor = new TextEditor();
            editor.settings = settings;
            this.Controls.Add(editor);
            editor.Dock = DockStyle.Fill;
            this.BorderStyle = BorderStyle.None;
        }

        public EditorTab(string text, Settings s) : base(text)
        {
            settings = s;
            editor = new TextEditor(settings);
            this.Controls.Add(editor);
            editor.Dock = DockStyle.Fill;
            this.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// Save text to file.
        /// </summary>
        public void SaveFile()
        {
            try
            {
                editor.EditorTextBox.SaveFile(filePath);
            }
            catch (Exception e)
            {
                try
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.ShowDialog();
                    filePath = dialog.FileName;
                    editor.EditorTextBox.SaveFile(filePath);
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
                editor.EditorTextBox.SaveFile(filePath);
            }
            catch (Exception ex)
            {
                pass();
            }
        }
    }
}
