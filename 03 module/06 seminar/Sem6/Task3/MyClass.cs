using System;

namespace Task3
{
    public struct PointS
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointS(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double Distance(PointS second)
        {
            double dx = X - second.X;
            double dy = Y - second.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    struct CircleS : IComparable<CircleS>
    {
        PointS center;
        double radius;

        PointS Center
        {
            get
            {
                return center;
            }

            set
            {
                center = value;
            }
        }

        double Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentException("Radius can't be negative.");
                radius = value;
            }
        }

        double Length
        {
            get
            {
                return 2 * radius * Math.PI;
            }
        }

        public CircleS(double x, double y, double r)
        {
            center = new PointS(x, y);
            radius = r;
        }

        int IComparable<CircleS>.CompareTo(CircleS second)
        {
            return radius.CompareTo(second.radius);
        }

        public override string ToString()
        {
            return $"Center: {center}, radius: {radius}, length: {Length}";
        }
    }
}
