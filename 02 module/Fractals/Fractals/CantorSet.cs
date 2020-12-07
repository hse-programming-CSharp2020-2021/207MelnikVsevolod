using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fractals
{
    public class CantorSet : Fractal
    {
        // Width of the line.
        static public int width = 10;

        public CantorSet(int depth, int max_depth, int length, int x, int y)
            : base(depth, max_depth, length, x, y)
        {

        }

        /// <summary>
        /// Render cantor set.
        /// </summary>
        /// <param name="target"> Target of the rendering. </param>
        public override void Render(Graphics target)
        {
            Pen pen = new Pen(GetColor());
            // Draw line.
            target.FillRectangle(pen.Brush, X, Y, Length, width);

            // Render next recursion level.
            if (depth < MaxDepth)
            {
                // Stop if fractal is too small.
                if (Length / 3 == 0)
                    return;

                CantorSet cs1 = 
                    new CantorSet(depth + 1, MaxDepth, Length / 3, X, Y + width * 2);
                cs1.Render(target);
                CantorSet cs2 = 
                    new CantorSet(depth + 1, MaxDepth, Length / 3, X + Length / 3 * 2, Y + width * 2);
                cs2.Render(target);
            }
        }
    }
}
