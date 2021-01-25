using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Notepad_
{
    public partial class SettingsForm : Form
    {
        public Settings settings = new Settings();

        public SettingsForm()
        {
            InitializeComponent();
        }

        public SettingsForm(Settings s)
        {
            InitializeComponent();
            settings = s;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            settings.interval = (int)numericUpDown1.Value;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = settings.interval;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                settings.color1 = Color.White;
                settings.color2 = Color.Blue;
                SettingsForm_Activated(sender, e);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                settings.color1 = Color.White;
                settings.color2 = Color.Green;
                SettingsForm_Activated(sender, e);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                settings.color1 = Color.White;
                settings.color2 = Color.Purple;
                SettingsForm_Activated(sender, e);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                settings.color1 = Color.FromArgb(20, 20, 20);
                settings.color2 = Color.Red;
                SettingsForm_Activated(sender, e);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                settings.color1 = Color.FromArgb(20, 20, 20);
                settings.color2 = Color.Purple;
                SettingsForm_Activated(sender, e);
            }
        }

        private void SettingsForm_Activated(object sender, EventArgs e)
        {
            this.BackColor = settings.color1;
            this.ForeColor = settings.color2;
            foreach (Control item in this.Controls)
            {
                item.BackColor = settings.color1;
                item.ForeColor = settings.color2;
            }
        }
    }
}
