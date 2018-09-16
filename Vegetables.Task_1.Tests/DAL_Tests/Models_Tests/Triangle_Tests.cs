using System;
using System.Windows;
using NUnit.Framework;
using Vegetables.Task_1.DAL.Models;

namespace Vegetables.Task_1.Tests.DAL_Tests.Models_Tests
{
    [TestFixture]
    public class Triangle_Tests
    {
        [Test]
        public void MiddlePoint_Test()
        {
            //Arrange
            var triangle = new Triangle(new Point(-3, -2), new Point(0, 4), new Point(3, -2));
            //Act
            var middlePoint = triangle.MiddlePoint;
            //Assert
            Assert.AreEqual(new Point(0,0), middlePoint);
        }

        [Test]
        public void Perimeter_Test()
        {
            //Arrange
            var triangle = new Triangle(new Point(-3, -2), new Point(0, 4), new Point(3, -2));
            var expected = 6.708203932499369 + 6.708203932499369 + 6;
            //Act
            var perimeter = triangle.Perimeter();
            //Assert
            Assert.AreEqual(expected, perimeter);
        }

        [Test]
        public void Area_Test()
        {
            //Arrange
            var triangle = new Triangle(new Point(-3, -2), new Point(0, 4), new Point(3, -2));
            var halfPerimeter = (6.708203932499369 + 6.708203932499369 + 6) / 2;
            var expected = Math.Sqrt(halfPerimeter * (halfPerimeter - 6.708203932499369) *
                                     (halfPerimeter - 6.708203932499369) * (halfPerimeter - 6));
            //Act
            var area = triangle.Area();
            //Assert
            Assert.AreEqual(expected, area);
        }
    }
}
