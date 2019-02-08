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
    }
}
