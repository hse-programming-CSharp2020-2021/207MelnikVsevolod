using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
            timer1.Interval = 70;
        }

        float xz, yz;
        float one;
        float rz;
        float wz, hz;
        float teta0 = (float)(5 * Math.PI / 4);
        float R0;
        float rs;
        float ws, hs;
        float dt = (float)(Math.PI / 100);
        int kz = 15, ks = 4, k = 1, kr = 1, kOne = 100;
        float maxHeight = 80;
        bool go_down = false;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!timer1.Enabled)
                PictureData();
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics target = e.Graphics;
            Pen whitePen = new Pen(Color.White);
            Pen bluePen = new Pen(Color.Blue);
            target.FillEllipse(whitePen.Brush, ws, hs, 2 * rs, 2 * rs);
            target.FillEllipse(bluePen.Brush, wz, hz, 2 * rz, 2 * rz);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PictureData();
            k++;
            pictureBox1.Refresh();
        }

        private void PictureData()
        {
            if (go_down)
                maxHeight *= (float)0.97;
            xz = pictureBox1.Size.Width / 2;
            yz = pictureBox1.Size.Height / 2;
            one = Math.Min(xz, yz) / kOne;
            rz = one * kz;
            wz = xz - rz; hz = yz - rz;
            rs = one * ks;
            ws = wz; hs = hz;
            float R;
            R0 = (float)Math.Sqrt((ws - xz) * (ws - xz) + (hs - yz) * (hs - yz));
            float dR = one * kr;
            R = Math.Min(R0 + k * dR, one * maxHeight);
            ws = (float)(R * Math.Cos(teta0 + k * dt)) + xz;
            hs = (float)(R * Math.Sin(teta0 + k * dt)) + yz;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                startButton.Text = "Посадка";
            }
            else
                go_down = true;
        }
    }
}
