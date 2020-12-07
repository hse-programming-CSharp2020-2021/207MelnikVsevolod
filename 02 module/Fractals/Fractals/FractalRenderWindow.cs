using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Fractals
{
    /// <summary>
    /// Fractal rendering window.
    /// </summary>
    public partial class FractalRenderWindow : Form
    {
        public FractalRenderWindow()
        {
            InitializeComponent();
        }

        // Coordinates of the fractal on window.
        int x = 20, y = 20;
        // Scale of the fractal.
        int scale = 1;
        // Length of the fractal's element (without scale).
        int length = 120;
        /// <summary>
        /// Fractal, which is rendering in this window.
        /// </summary>
        public Fractal fractal;


        /// <summary>
        /// Load and configure window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FractalRenderWindow_Load(object sender, EventArgs e)
        {
            this.MinimumSize = Screen.PrimaryScreen.WorkingArea.Size / 3;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
        }


        /// <summary>
        /// Process pressed keys.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FractalRenderWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Move fractal.
            if (e.KeyChar == 'w' || e.KeyChar == 'ц')
                y -= 5;
            if (e.KeyChar == 's' || e.KeyChar == 'ы')
                y += 5;
            if (e.KeyChar == 'a' || e.KeyChar == 'ф')
                x -= 5;
            if (e.KeyChar == 'd' || e.KeyChar == 'в')
                x += 5;

            // Scale fractal.
            if (e.KeyChar == 'e' || e.KeyChar == 'у')
            {
                if (scale == 1)
                    scale = 2;
                else if (scale == 2)
                    scale = 3;
                else if (scale == 3)
                    scale = 5;
            }
            if (e.KeyChar == 'q' || e.KeyChar == 'й')
            {
                if (scale == 5)
                    scale = 3;
                else if (scale == 3)
                    scale = 2;
                else
                    scale = 1;
            }

            // Return to default settings.
            if (e.KeyChar == ' ')
            {
                FractalRenderWindow_Shown(sender, e);
            }
            pictureBox.Refresh();
        }


        /// <summary>
        /// Change depth of the recursion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depthUpDown_ValueChanged(object sender, EventArgs e)
        {
            fractal.MaxDepth = (int)depthUpDown.Value;
            pictureBox.Refresh();
        }


        /// <summary>
        /// Change width of the Cantor's set lines.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void widthUpDown_ValueChanged(object sender, EventArgs e)
        {
            CantorSet.width = (int)widthUpDown.Value;
            pictureBox.Refresh();
        }


        /// <summary>
        /// Change max depth of the fractal for optimization.
        /// </summary>
        private void ChangeMaxDepth()
        {
            if (fractal is SierpinskiСarpet)
                depthUpDown.Maximum = 7;
            else if (fractal is SierpinskiTriangle)
                depthUpDown.Maximum = 8;
            else if (fractal is KochCurve)
                depthUpDown.Maximum = 8;
            else
                depthUpDown.Maximum = 10;
        }


        /// <summary>
        /// Configure UI for Pythagoras tree.
        /// </summary>
        private void PythagorasTreeUI()
        {
            if (fractal is PythagorasTree)
            {
                y += length;
                x = length / 2;
                angleLabel1.Show();
                angleLabel2.Show();
                ratioLabel.Show();
                angleUpDown1.Show();
                angleUpDown2.Show();
                ratioUpDown.Show();
            }
            else
            {
                angleLabel1.Hide();
                angleLabel2.Hide();
                ratioLabel.Hide();
                angleUpDown1.Hide();
                angleUpDown2.Hide();
                ratioUpDown.Hide();
            }
        }


        /// <summary>
        /// Configure UI for Cantor set.
        /// </summary>
        private void CantorSetUI()
        {
            if (fractal is CantorSet)
            {
                widthLabel.Show();
                widthUpDown.Show();
            }
            else
            {
                widthLabel.Hide();
                widthUpDown.Hide();
            }
        }


        /// <summary>
        /// Show window and configure starting coordinates.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FractalRenderWindow_Shown(object sender, EventArgs e)
        {
            x = 20;
            y = 20;
            scale = 1;
            // Scale fractal to window's size.
            length = Math.Min(pictureBox.Width - 20, pictureBox.Height - 20);

            ChangeMaxDepth();
            // Show or hide buttons of specific fractals.
            PythagorasTreeUI();
            CantorSetUI();
        }

        
        /// <summary>
        /// Resize window and scale fractal to it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FractalRenderWindow_Resize(object sender, EventArgs e)
        {
            int old_length = length;
            length = Math.Min(pictureBox.Width - 20, pictureBox.Height - 20);
            x = x * length / old_length;
            y = y * length / old_length;
            pictureBox.Refresh();
        }


        /// <summary>
        /// Save rendered image to file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        Bitmap picture = new Bitmap(pictureBox.Width, pictureBox.Height);
                        fractal.Render(Graphics.FromImage(picture));
                        picture.Save(myStream, System.Drawing.Imaging.ImageFormat.Png);
                        myStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении картинки: " + ex.Message);
            }
        }


        /// <summary>
        /// Change ratio of the Pythagoras tree lines.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ratioUpDown_ValueChanged(object sender, EventArgs e)
        {
            PythagorasTree.ratio = (double)ratioUpDown.Value;
            pictureBox.Refresh();
        }


        /// <summary>
        /// Change angle of the first branch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void angleUpDown1_ValueChanged(object sender, EventArgs e)
        {
            PythagorasTree.angle1 = (double)angleUpDown1.Value;
            pictureBox.Refresh();
        }


        /// <summary>
        /// Change angle of the second branch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void angleUpDown2_ValueChanged(object sender, EventArgs e)
        {
            PythagorasTree.angle2 = (double)angleUpDown2.Value;
            pictureBox.Refresh();
        }


        /// <summary>
        /// Change start color for rendering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorButton1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = Fractal.startColor;

            // Update the color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                Fractal.startColor = MyDialog.Color;
            pictureBox.Refresh();
        }


        /// <summary>
        /// Change end color for rendering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorButton2_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = Fractal.endColor;

            // Update the color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                Fractal.endColor = MyDialog.Color;
            pictureBox.Refresh();
        }


        /// <summary>
        /// Render fractal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Update fractal.
            fractal.X = x;
            fractal.Y = y;
            if (fractal is DragonsCurve)
            {
                DragonsCurve dc = fractal as DragonsCurve;
                dc.lastX = x + length * scale / 2;
                dc.lastY = y + length * scale / 2;
            }
            fractal.Length = length * scale;

            // Prepare for rendering.
            Graphics g = e.Graphics;
            Pen background = new Pen(Color.FromArgb(35, 35, 35));
            g.FillRectangle(background.Brush, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));

            // Update color buttons.
            colorButton1.FlatAppearance.BorderColor = Fractal.startColor;
            colorButton2.FlatAppearance.BorderColor = Fractal.endColor;

            // Render fractal.
            try
            {
                fractal.Render(e.Graphics);
            }
            catch
            {
                MessageBox.Show("Поздравляем, у вас exception! Отрисовка невозможна. Уменьшите глубину рекурсии.");
            }
        }
    }
}
