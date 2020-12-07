using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fractals
{
    public class PythagorasTree : Fractal
    {
        // Ratio of the lines between levels of the recursion.
        static public double ratio = 0.7;
        // Angles of the 2 branches.
        static public double angle1 = -60;
        static public double angle2 = 60;
        // Angle of the current element.
        double angle = 0;

        public PythagorasTree(int depth, int max_depth, int length, int x, int y, double angle=-90)
            : base(depth, max_depth, length, x, y)
        {
            this.angle = angle;
        }


        /// <summary>
        /// Render pythagoras tree.
        /// </summary>
        /// <param name="target"> Target of the rendering. </param>
        public override void Render(Graphics target)
        {
            Pen pen = new Pen(GetColor());

            // Difference between start and finish of the line coordinates.
            int dx = (int)(Length / 3.5 * Math.Cos(angle * Math.PI / 180));
            int dy = (int)(Length / 3.5 * Math.Sin(angle * Math.PI / 180));
            target.DrawLine(pen, X, Y, X + dx, Y + dy);
            // Render next recursion level.
            if (depth < MaxDepth)
            {
                // Stop if fractal is too small.
                if ((int)(Length * ratio) == 0)
                    return;

                PythagorasTree pt1 = 
                    new PythagorasTree(depth + 1, MaxDepth, (int)(Length * ratio), X + dx, Y + dy, angle + angle1);
                PythagorasTree pt2 = 
                    new PythagorasTree(depth + 1, MaxDepth, (int)(Length * ratio), X + dx, Y + dy, angle + angle2);
                pt1.Render(target);
                pt2.Render(target);
            }
        }
    }
}
