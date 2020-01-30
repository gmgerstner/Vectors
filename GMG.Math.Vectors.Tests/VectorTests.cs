using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GMG.Math.Vectors.Tests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void DotProduct()
        {
            //arrange
            var v1 = new Vector { X = 1, Y = 1, Z = 0 };
            var v2 = new Vector { X = 1, Y = 1, Z = 1 };

            //act
            var r = v1.DotProduct(v2);

            //assert
            Assert.IsTrue(r == 2);
        }

        [TestMethod]
        public void CrossProduct()
        {
            //arrange
            var v1 = new Vector { X = 1, Y = 0, Z = 0 };
            var v2 = new Vector { X = 0, Y = 0, Z = 1 };

            //act
            var r = v1.CrossProduct(v2);
            var m = r.Magnitude();

            //assert
            Assert.IsTrue(m == 1);
        }

        [TestMethod]
        public void Magnitude()
        {
            //arrange
            var v1 = new Vector { X = 3, Y = 4, Z = 0 };

            //act
            var m = v1.Magnitude();

            //assert
            Assert.IsTrue(m == 5);
        }

        [TestMethod]
        public void Normalize()
        {
            //arrange
            var v1 = new Vector { X = 1, Y = 0, Z = 0 };

            //act
            var m = v1.Magnitude();

            //assert
            Assert.IsTrue(m == 1);
        }

        [TestMethod]
        public void Random()
        {
        }

        [TestMethod]
        public void Theta()
        {
            //arrange
            var v1 = new Vector { X = 1, Y = 1, Z = 0 };

            //act
            var th = v1.Theta;

            //assert
            var val = System.Math.Abs(th - System.Math.PI / 2);
            val = System.Math.Round(val, 5);//close enough?
            Assert.IsTrue(val == 0);
        }

        [TestMethod]
        public void Phi()
        {
            //arrange
            var v1 = new Vector { X = 1, Y = 1, Z = 1 };

            //act
            var phi = v1.Phi;

            //assert
            var val = System.Math.Abs(phi - System.Math.PI / 4);
            val = System.Math.Round(val, 5);//close enough?
            Assert.IsTrue(val == 0);
        }

        [TestMethod]
        public void FromSphericalCoordinates()
        {
            //arrange
            var r = System.Math.Sqrt(3.0);
            var th = System.Math.Asin(System.Math.Sqrt(2.0 / 3.0));
            var phi = System.Math.PI / 4.0;
            var expected = new Vector { X = 1.0, Y = 1.0, Z = 1.0 };

            //act
            var actual = Vector.FromSphericalCoordinates(r, th, phi);

            //assert
            var val = expected.CrossProduct(actual).Magnitude();
            val = System.Math.Round(val, 5);//close enough?
            Assert.IsTrue(val == 0);
        }

        [TestMethod]
        public void Plus()
        {
            //arrange
            var a = new Vector(1, 1, 1);
            var b = new Vector(2, 2, 2);
            var c = new Vector(3, 3, 3);

            //act
            var d = a + b;

            //assert
            Assert.AreEqual(c, d);
        }

        [TestMethod]
        public void Subtract()
        {
            //arrange
            var a = new Vector(1, 1, 1);
            var b = new Vector(2, 2, 2);
            var c = new Vector(3, 3, 3);

            //act
            var d = c - b;

            //assert
            Assert.AreEqual(a, d);
        }

        [TestMethod]
        public void Negative()
        {
            //arrange
            var a = new Vector(1, 2, 3);
            var b = new Vector(-1, -2, -3);

            //act
            var d = -a;

            //assert
            Assert.AreEqual(b, d);
        }

        [TestMethod]
        public void Multiply()
        {
            //arrange
            var a = 3.0;
            var b = new Vector(2, 2, 2);
            var c = new Vector(6, 6, 6);

            //act
            var d = a * b;
            var e = b * a;

            //assert
            Assert.AreEqual(c, d);
            Assert.AreEqual(c, e);
        }

        [TestMethod]
        public void Divide()
        {
            //arrange
            var a = 2.0;
            var b = new Vector(2, 2, 2);
            var c = new Vector(1, 1, 1);

            //act
            var d = b / a;

            //assert
            Assert.AreEqual(c, d);
        }

        [TestMethod]
        public void Equals()
        {
            //arrange
            var a = new Vector(2, 2, 2);
            var b = new Vector(1, 1, 1);
            var c = new Vector(1, 1, 1);

            //act
            var isNotSame = (a == b);
            var isSame = (b == c);

            //assert
            Assert.AreEqual(false, isNotSame);
            Assert.AreEqual(true, isSame);
        }

        [TestMethod]
        public void GetIndexer()
        {
            //arrange
            var a = new Vector(10, 20, 30);
            //act
            var x = a[0];
            var y = a[1];
            var z = a[2];

            //assert
            Assert.AreEqual(x, a.X);
            Assert.AreEqual(y, a.Y);
            Assert.AreEqual(z, a.Z);
        }

        [TestMethod]
        public void SetIndexer()
        {
            //arrange
            var a = new Vector();
            var x = 100;
            var y = 200;
            var z = 300;

            //act
            a[0] = x;
            a[1] = y;
            a[2] = z;

            //assert
            Assert.AreEqual(x, a.X);
            Assert.AreEqual(y, a.Y);
            Assert.AreEqual(z, a.Z);
        }
    }
}
