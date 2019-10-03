using System;

namespace Exercise1
{
    class Program
    {
        struct Point3D
        {
            private double x;
            private double y;
            private double z;

            public Point3D(double x, double y, double z) {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public Point3D(Point3D other) {
                x = other.x;
                y = other.y;
                z = other.z;
            }

            /// <summary>
            /// Distance between (0, 0, 0) and this.
            /// </summary>
            /// <returns>distance to origin</returns>
            public double DistanceToOrigin() {
                return Math.Sqrt(x * x + y * y + z * z);
            }

            /// <summary>
            /// Update all components.
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="z"></param>
            public void Update(double x, double y, double z) {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            /// <summary>
            /// Pretty print of this.
            /// </summary>
            /// <param name="name"></param>
            public void Show(string name = "") {
                var position = $"({x}; {y}; {z})";
                var distance = $"distance to origin: {DistanceToOrigin():0.00}";
                Console.WriteLine($"{name}: {position}\t {distance}");
            }

            /// <summary>
            /// Swap components between a and b.
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            public static void SwapPoints(ref Point3D a, ref Point3D b) {
                var temp = new Point3D(a);
                a.Update(b.x, b.y, b.z);
                b.Update(temp.x, temp.y, temp.z);
            }
        }

        static void Show(ref Point3D p1, ref Point3D p2) {
            p1.Show("p1");
            p2.Show("p2");
            Console.WriteLine();
        }

        static void Main(string[] args) {
            var p1 = new Point3D(1, 2, 3);
            var p2 = new Point3D(7, 8, 9);
            
            Show(ref p1, ref p2);
            Point3D.SwapPoints(ref p1, ref p2);
            Show(ref p1, ref p2);
        }
    }
}