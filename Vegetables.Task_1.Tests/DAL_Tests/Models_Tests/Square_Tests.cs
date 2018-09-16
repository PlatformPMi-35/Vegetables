using System.Windows;
using NUnit.Framework;
using Vegetables.Task_1.DAL.Models;

namespace Vegetables.Task_1.Tests.DAL_Tests.Models_Tests
{
    [TestFixture]
    public class Square_Tests
    {
        [Test]
        public void MiddlePoint_Test()
        {
            //Arrange
            var firstSquare = new Square(new Point(0, 5), new Point(5, 0));
            var secondSquare = new Square(new Point(0, 5), new Point(0, -5));
            var thirdSquare = new Square(new Point(5, 0), new Point(-5, 0));

            //Act
            var firstMiddlePoint = firstSquare.MiddlePoint;
            var secondMiddlePoint = secondSquare.MiddlePoint;
            var thirdMiddlePoint = thirdSquare.MiddlePoint;
            //Assert
            Assert.AreEqual(new Point(2.5, 2.5), firstMiddlePoint);
            Assert.AreEqual(new Point(0, 0), secondMiddlePoint);
            Assert.AreEqual(new Point(0, 0), thirdMiddlePoint);
        }

        [Test]
        public void Perimeter_Test()
        {
            //Arrange
            var square = new Square(new Point(0, 5), new Point(5, 0));
            //Act
            var perimeter = square.Perimeter();
            //Assert
            Assert.AreEqual(20, perimeter);
        }

        [Test]
        public void Area_Test()
        {
            //Arrange
            var square = new Square(new Point(0, 5), new Point(5, 0));
            //Act
            var area = square.Area();
            //Assert
            Assert.AreEqual(25, area);
        }
    }
}
