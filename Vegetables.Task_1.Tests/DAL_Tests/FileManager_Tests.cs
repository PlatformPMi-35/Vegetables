using System;
using System.IO;
using NUnit.Framework;
using Vegetables.Task_1.DAL.Managers;

namespace Vegetables.Task_1.Tests.DAL_Tests
{
    [TestFixture]
    public class FileManager_Tests
    {
        private string _path;
        private FileManager _fileManager;

        [SetUp]
        public void Setup()
        {
            File.Create(Directory.GetCurrentDirectory() + "\\Test.csv");
            _fileManager = new FileManager();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(Directory.GetCurrentDirectory() + "\\Test.csv");
        }

        [Test]
        public void LoadWithNullPath_Test()
        {
            //Arrange
            //Act
            Assert.Throws<ArgumentNullException>(() => _fileManager.Load(null));
        }
    }
}
