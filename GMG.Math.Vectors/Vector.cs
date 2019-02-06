using System;

namespace GMG.Math.Vectors
{
    public class Vector
    {
        public Vector()
        {
            //default
        }

        public Vector(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public double DotProduct(Vector vector)
        {
            var r2 = X * vector.X + Y * vector.Y + Z * vector.Z;
            return r2;
        }

        public Vector CrossProduct(Vector vector)
        {
            var result = new Vector
            {
                X = Y * vector.Z - Z * vector.Y,
                Y = -(X * vector.Z - Z * vector.X),
                Z = X * vector.Y - Y * vector.X,
            };
            return result;
        }

        public double Magnitude()
        {
            var r2 = DotProduct(this);
            var r = System.Math.Sqrt(r2);
            return r;
        }

        public Vector Normalize()
        {
            var m = Magnitude();
            var v = new Vector
            {
                X = X / m,
                Y = Y / m,
                Z = Z / m
            };
            return v;
        }

        static public Vector Random()
        {
            var random = new Random();
            var vector = new Vector();
            var m = 1.0;
            do
            {
                vector.X = 2.0 * random.NextDouble() - 1.0;
                vector.Y = 2.0 * random.NextDouble() - 1.0;
                vector.Z = 2.0 * random.NextDouble() - 1.0;
                m = vector.Magnitude();
            } while (m > 1.0);
            if (m != 0)
            {
                vector.X /= m;
                vector.Y /= m;
                vector.Z /= m;
            }
            return vector;
        }

        //https://en.wikipedia.org/wiki/Spherical_coordinate_system
        //https://en.wikipedia.org/wiki/File:3D_Spherical.svg

        public double Theta
        {
            get
            {
                var r = Magnitude();
                var th = System.Math.Acos(Z / r);
                return th;
            }
        }

        public double Phi
        {
            get
            {
                var phi = System.Math.Atan(Y / X);
                return phi;
            }
        }

        static public Vector FromSphericalCoordinates(double r, double theta, double phi)
        {
            var x = r * System.Math.Sin(theta) * System.Math.Cos(phi);
            var y = r * System.Math.Sin(theta) * System.Math.Sin(phi);
            var z = r * System.Math.Cos(theta);
            var v = new Vector
            {
                X = x,
                Y = y,
                Z = z
            };
            return v;
        }
    }
}
