using System;

namespace GMG.Math.Vectors
{
    public partial class Vector
    {
        public static Vector operator +(Vector left, Vector right)
        {
            var resultant = new Vector
            {
                X = left.X + right.X,
                Y = left.Y + right.Y,
                Z = left.Z + right.Z
            };
            return resultant;
        }

        public static Vector operator *(double left, Vector right)
        {
            var resultant = new Vector
            {
                X = left * right.X,
                Y = left * right.Y,
                Z = left * right.Z
            };
            return resultant;
        }
        public static Vector operator *(Vector left, double right)
        {
            return right * left;
        }

        public static Vector operator /(Vector left, double right)
        {
            return left * (1.0 / right);
        }

        public static bool operator ==(Vector left, Vector right)
        {
            if (left.X != right.X) return false;
            if (left.Y != right.Y) return false;
            if (left.Z != right.Z) return false;
            return true;
        }

        public static bool operator !=(Vector left, Vector right)
        {
            var isEqual = true;
            if (left.X != right.X) isEqual = false;
            if (left.Y != right.Y) isEqual = false;
            if (left.Z != right.Z) isEqual = false;
            return !isEqual;
        }

        public double this[int i]
        {
            get
            {
                if (i == 0) return X;
                if (i == 1) return Y;
                if (i == 2) return Z;
                throw new NotSupportedException("Invalid index");
            }
            set
            {
                if (i == 0) { X = value; return; }
                if (i == 1) { Y = value; return; }
                if (i == 2) { Z = value; return; }
                throw new NotSupportedException("Invalid index");
            }
        }
    }
}
