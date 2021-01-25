using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Notepad_
{
    public partial class NotepadTabControl : UserControl
    {
        Settings settings = new Settings();
        public List<TextEditor> TextEditors = new List<TextEditor>();
        int currentEditor = 0;

        public NotepadTabControl()
        {
            InitializeComponent();
            AddEditor();
        }

        public NotepadTabControl(Settings s)
        {
            InitializeComponent();
            settings = s;
            UpdateUI();
            AddEditor();
        }

        private void NotepadTabControl_Load(object sender, EventArgs e)
        {

        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (currentEditor - 1 >= 0)
                currentEditor -= 1;
            textEditor1 = TextEditors[currentEditor];
        }

        public TextEditor CurrentEditor()
        {
            return TextEditors[currentEditor];
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            if (currentEditor + 1 < TextEditors.Count)
                currentEditor += 1;
            textEditor1 = TextEditors[currentEditor];
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            TextEditors.Remove(TextEditors[currentEditor]);
            currentEditor--;
            if (currentEditor < 0)
                currentEditor = 0;
            if (TextEditors.Count == 0)
                AddEditor();
            textEditor1 = TextEditors[currentEditor];
        }

        /// <summary>
        /// Add new editor to list.
        /// </summary>
        private void AddEditor()
        {
            TextEditors.Add(new TextEditor(settings));
            currentEditor = TextEditors.Count - 1;
            textEditor1 = TextEditors[currentEditor];
        }

        public void UpdateUI()
        {
            this.BackColor = settings.color1;
            this.ForeColor = settings.color2;
            buttonLeft.BackColor = settings.color1;
            buttonLeft.ForeColor = settings.color2;
            buttonLeft.FlatAppearance.BorderColor = settings.color2;
            buttonRight.BackColor = settings.color1;
            buttonRight.ForeColor = settings.color2;
            buttonRight.FlatAppearance.BorderColor = settings.color2;
            closeButton.BackColor = settings.color1;
            closeButton.ForeColor = settings.color2;
            closeButton.FlatAppearance.BorderColor = settings.color2;
            textEditor1.EditorTextBox.BackColor = settings.color1;
            textEditor1.EditorTextBox.ForeColor = settings.color2;
        }
    }
}
