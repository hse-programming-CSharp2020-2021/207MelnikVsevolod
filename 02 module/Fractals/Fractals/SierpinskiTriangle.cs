using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fractals
{
    public class SierpinskiTriangle : Fractal
    {
        public SierpinskiTriangle(int depth, int max_depth, int length, int x, int y)
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
            int height = (int)(Length * Math.Sin(Math.PI / 3));
            // Draw triangle.
            target.DrawLine(pen, X, Y + height, X + Length, Y + height);
            target.DrawLine(pen, X, Y + height, X + Length / 2, Y);
            target.DrawLine(pen, X + Length, Y + height, X + Length / 2, Y);
            // Render next recursion level.
            if (depth < MaxDepth)
            {
                // Stop if fractal is too small.
                if (Length / 2 == 0)
                    return;
                SierpinskiTriangle st1 = 
                    new SierpinskiTriangle(depth + 1, MaxDepth, Length / 2, X, Y + height / 2);
                st1.Render(target);
                SierpinskiTriangle st2 = 
                    new SierpinskiTriangle(depth + 1, MaxDepth, Length / 2, X + Length / 2, Y + height / 2);
                st2.Render(target);
                SierpinskiTriangle st3 = 
                    new SierpinskiTriangle(depth + 1, MaxDepth, Length / 2, X + Length / 4, Y);
                st3.Render(target);
            }
        }
    }
}
