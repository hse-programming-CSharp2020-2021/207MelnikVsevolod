using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fractals
{
    /// <summary>
    /// Fractal class.
    /// </summary>
    public class Fractal
    {
        public static Color startColor = Color.White, endColor = Color.White;

        // Depth of recursion.
        protected int depth;

        // Max depth of recursion.
        public int MaxDepth
        {
            get; set;
        }

        // Coordinates of the fractal.
        public int X
        {
            get; set;
        }
        public int Y
        {
            get; set;
        }

        // Length of the line.
        public int Length
        {
            get; set;
        }

        public Fractal()
        {

        }


        /// <summary>
        /// Create fractal with arguments.
        /// </summary>
        /// <param name="depth"> Depth of the recursion. </param>
        /// <param name="max_depth"> Max depth of the recursion. </param>
        /// <param name="length"> Lenght of the fractal's element. </param>
        /// <param name="x"> X coordinate of the fractal's start. </param>
        /// <param name="y"> Y coordinate of the fractal's start. </param>
        public Fractal(int depth, int max_depth, int length, int x, int y)
        {
            this.depth = depth;
            MaxDepth = max_depth;
            Length = length;
            X = x;
            Y = y;
        }


        /// <summary>
        /// Get color for current iteration in the gradient.
        /// </summary>
        /// <returns> Color of current iteration. </returns>
        protected Color GetColor()
        {
            int r = (int)startColor.R + depth * ((int)endColor.R - startColor.R) / MaxDepth;
            int g = (int)startColor.G + depth * ((int)endColor.G - startColor.G) / MaxDepth;
            int b = (int)startColor.B + depth * ((int)endColor.B - startColor.B) / MaxDepth;
            return Color.FromArgb(r, g, b);
        }


        /// <summary>
        /// Render fractal.
        /// </summary>
        /// <param name="target"> Target of the rendering. </param>
        virtual public void Render(Graphics target)
        {

        }
    }
}
