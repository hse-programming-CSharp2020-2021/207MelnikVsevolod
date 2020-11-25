using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {

        string[] text = { "один", "два", "три" };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Lines = text;
        }

        private void showList_Click(object sender, EventArgs e)
        {
            textBox1.Lines = text;
        }

        private void showNewList_Click(object sender, EventArgs e)
        {
            string res = string.Join(" ", textBox1.Lines);
            MessageBox.Show(res);
        }
    }
}
