using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractals
{
    /// <summary>
    /// Main form of the app.
    /// </summary>
    public partial class FractalsWindow : Form
    {
        public FractalsWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Show factorial choosing table.
        /// </summary>
        private void ChooseFractal()
        {
            tableLayoutPanel1.Show();
        }


        /// <summary>
        /// Load and configue window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FractalsWindow_Load(object sender, EventArgs e)
        {
            this.MinimumSize = Screen.PrimaryScreen.WorkingArea.Size / 3;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            ChooseFractal();
        }


        /// <summary>
        /// Launch Pythagoras tree rendering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FractalRenderWindow fractalRender = new FractalRenderWindow();
            fractalRender.fractal = new PythagorasTree(1, 3, 120, 50, 50);
            fractalRender.Show();
        }


        /// <summary>
        /// Launch Sierpinski carpet rendering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            FractalRenderWindow fractalRender = new FractalRenderWindow();
            fractalRender.fractal = new SierpinskiСarpet(1, 3, 120, 50, 50);
            fractalRender.Show();
        }


        /// <summary>
        /// Launch Sierpinski triangle rendering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            FractalRenderWindow fractalRender = new FractalRenderWindow();
            fractalRender.fractal = new SierpinskiTriangle(1, 3, 120, 50, 50);
            fractalRender.Show();
        }


        /// <summary>
        /// Launch Cantor set rendering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            FractalRenderWindow fractalRender = new FractalRenderWindow();
            fractalRender.fractal = new CantorSet(1, 3, 120, 50, 50);
            fractalRender.Show();
        }


        /// <summary>
        /// Launch Koch curve rendering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            FractalRenderWindow fractalRender = new FractalRenderWindow();
            fractalRender.fractal = new KochCurve(1, 3, 120, 50, 50);
            fractalRender.Show();
        }


        /// <summary>
        /// Launch dragon curve rendering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            FractalRenderWindow fractalRender = new FractalRenderWindow();
            fractalRender.fractal = new DragonsCurve(1, 3, 120, 50, 50);
            fractalRender.Show();
        }


        /// <summary>
        /// Open help window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpButton_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void FractalsWindow_Shown(object sender, EventArgs e)
        {
            helpButton_Click(sender, e);
        }
    }
}
