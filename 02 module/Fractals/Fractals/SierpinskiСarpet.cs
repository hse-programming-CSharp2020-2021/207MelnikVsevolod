using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Fractals
{
    public class SierpinskiСarpet : Fractal
    {
        public SierpinskiСarpet(int depth, int max_depth, int length, int x, int y)
            : base(depth, max_depth, length, x, y)
        {

        }


        /// <summary>
        /// Render fractal.
        /// </summary>
        /// <param name="e"> Target of the rendering. </param>
        public override void Render(Graphics target)
        {
            Pen pen = new Pen(GetColor());
            Pen blackPen = new Pen(Color.FromArgb(35, 35, 35));
            int l = Length;
            // Draw big square.
            target.FillRectangle(pen.Brush, X, Y, l, l);
            target.FillRectangle(blackPen.Brush, X + l / 3, Y + l / 3, l / 3, l / 3);
            // Render next recursion level.
            if (depth < MaxDepth)
            {
                // Draw 8 fractals recursively.
                // Stop if fractal is too small.
                if (Length / 3 == 0)
                    return;
                for (int i = 0; i < 3; ++i)
                    for (int j = 0; j < 3; ++j)
                    {
                        // Skip center square.
                        if (i == j && i == 1)
                            continue;
                        SierpinskiСarpet sc = 
                            new SierpinskiСarpet(depth + 1, MaxDepth, Length / 3, X + i * l / 3, Y + j * l / 3);
                        sc.Render(target);
                    }
            }
        }
    }
}
