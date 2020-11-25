using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int p1, p2;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int t = p2;
            p2 = 2 * p2 + p1;
            p1 = t;
            if (p1 < 0)
            {
                p1 = 1;
                p2 = 2;
                MessageBox.Show("Переполнение");
            }
            label1.Text = "Член ряда Пелла: " + p1.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            p1 = 1;
            p2 = 2;
            label1.Text = "Член ряда Пелла: " + p1.ToString();
        }
    }
}
