using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Fractals
{
    public class DragonsCurve : Fractal
    {
        // Coordinates of the curve's end.
        public int lastX, lastY;
        public DragonsCurve(int depth, int max_depth, int length, int x, int y, int lastX=0, int lastY=0)
            : base(depth, max_depth, length, x, y)
        {
            this.lastX = lastX;
            this.lastY = lastY;
        }

        /// <summary>
        /// Render pythagoras tree.
        /// </summary>
        /// <param name="target"> Target of the rendering. </param>
        public override void Render(Graphics target)
        {
            Pen pen = new Pen(GetColor());

            // Render next recursion level.
            if (depth < MaxDepth)
            {
                // Calculate new coordinates.
                int newLastX = (X + lastX) / 2 + (lastY - Y) / 2;
                int newLastY = (Y + lastY) / 2 - (lastX - X) / 2;
                DragonsCurve dc1 = 
                    new DragonsCurve(depth + 1, MaxDepth, Length, X, Y, newLastX, newLastY);
                DragonsCurve dc2 = 
                    new DragonsCurve(depth + 1, MaxDepth, Length, lastX, lastY, newLastX, newLastY);
                dc1.Render(target);
                dc2.Render(target);
            }
            else
            {
                // Render last level of recursion.
                target.DrawLine(pen, X, Y, lastX, lastY);
            }
        }
    }

}
