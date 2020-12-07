using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fractals
{
    public class KochCurve : Fractal
    {
        // Angle of the current curve's element.
        double angle = 0;
        public KochCurve(int depth, int max_depth, int length, int x, int y, double angle=0)
            : base(depth, max_depth, length, x, y)
        {
            this.angle = angle;
        }


        /// <summary>
        /// Render koch curve.
        /// </summary>
        /// <param name="target"> Target of the rendering. </param>
        public override void Render(Graphics target)
        {
            Pen pen = new Pen(GetColor());
            int dx = (int)(Length * Math.Cos(angle));
            int dy = (int)(Length * Math.Sin(angle));
            // Render next recursion level.
            if (depth < MaxDepth)
            {
                // Stop if fractal is too small.
                if (Length / 3 == 0)
                    return;

                // Triangle part.
                int upperPointX = (int)(X + dx / 3 + Length / 3 * Math.Cos(angle + Math.PI / 3));
                int upperPointY = (int)(Y + dy / 3 + Length / 3 * Math.Sin(angle + Math.PI / 3));
                KochCurve kc1 = 
                    new KochCurve(depth + 1, MaxDepth, Length / 3, X + dx / 3, Y + dy / 3, angle + Math.PI / 3);
                KochCurve kc2 = 
                    new KochCurve(depth + 1, MaxDepth, Length / 3, upperPointX, upperPointY, angle - Math.PI / 3);
                kc1.Render(target);
                kc2.Render(target);
                // Lines on the left and right side.
                KochCurve kc3 = 
                    new KochCurve(depth + 1, MaxDepth, Length / 3, X, Y, angle);
                KochCurve kc4 = 
                    new KochCurve(depth + 1, MaxDepth, Length / 3, X + dx * 2 / 3, Y + dy * 2 / 3, angle);
                kc3.Render(target);
                kc4.Render(target);
            }
            else
            {
                // Draw line on the last recursion level.
                target.DrawLine(pen, X, Y, X + dx, Y + dy);
            }
        }
    }
}
