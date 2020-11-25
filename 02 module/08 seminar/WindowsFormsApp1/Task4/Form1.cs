using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public partial class Form1 : Form
    {

        string[] data = { "один", "два", "три", "четыре", "пять"};
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(data);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(data);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            object item = listBox1.SelectedItem;
            if (item != null)
                listBox1.Items.Remove(item);
            else
                MessageBox.Show("Список пуст или нет выделенного элемента!");
        }
    }
}
