using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeemEditImage;

namespace UnitTestTeemEdit
{
    [TestClass]
    public class UnitTestImageEdit
    {
        [TestMethod]
        public void CalcImagesAndWork_Image13_Teem3_returnedImages12()
        {
            // Arrange
            int imgEdit = 13;
            int[] masSpeed = new int[] { 2, 3, 4 };
            int expectedTime = 12;

            // Act
            var tup = Person.CalcImagesAndWork(imgEdit, masSpeed);
            int actualTime = tup.Item1;

            // Assert          
            Assert.AreEqual(expectedTime, actualTime);
        }

        [TestMethod]
        public void CalcImagesAndWork_Image3_Teem4_returnedImage4()
        {
            // Arrange
            int imgEdit = 3;
            int[] masSpeed = new int[] { 3, 1, 4,5 };
            int expectedTime = 4;

            // Act
            var tup = Person.CalcImagesAndWork(imgEdit, masSpeed);
            int actualTime = tup.Item1;

            // Assert          
            Assert.AreEqual(expectedTime, actualTime);
        }

        [TestMethod]
        public void CalcImagesAndWork_Image6_Teem6_returnedImages6()
        {
            // Arrange
            int imgEdit = 6;
            int[] masSpeed = new int[] { 2, 5, 4, 3,6 };
            int expectedTime = 6;

            // Act
            var tup = Person.CalcImagesAndWork(imgEdit, masSpeed);
            int actualTime = tup.Item1;

            // Assert          
            Assert.AreEqual(expectedTime, actualTime);
        }

        [TestMethod]
        public void CalcImagesAndWork_Image3_Teem3_returnedWork_1_1_1_()
        {
            // Arrange
            int imgEdit = 3;
            int[] masSpeed = new int[] { 2, 5, 4 };
            int[] expectedWork = new int[] { 1, 1, 1 };

            // Act
            var tup = Person.CalcImagesAndWork(imgEdit, masSpeed);
            int[] actualWork = tup.Item2;

            // Assert          
            //Assert.AreEqual(expectedWork, personalWork);
            CollectionAssert.AreEqual(expectedWork, actualWork);
        }

        [TestMethod]
        public void CalcImagesAndWork_Image3_Teem4_returnedWork_1_1_1_0_()
        {
            // Arrange
            int imgEdit = 3;
            int[] masSpeed = new int[] { 2, 5, 4, 8 };
            int[] expectedWork = new int[] { 1, 1, 1, 0 };

            // Act
            var tup = Person.CalcImagesAndWork(imgEdit, masSpeed);
            int[] actualWork = tup.Item2;

            // Assert          
            //Assert.AreEqual(expectedWork, personalWork);
            CollectionAssert.AreEqual(expectedWork, actualWork);
        }

        [TestMethod]
        public void CalcImagesAndWork_Image12_Teem3_returnedWork_5_4_3_()
        {
            // Arrange
            int imgEdit = 12;
            int[] masSpeed = new int[] { 2, 3, 4 };
            int[] expectedWork = new int[] { 5, 4, 3 };

            // Act
            var tup = Person.CalcImagesAndWork(imgEdit, masSpeed);
            int[] actualWork = tup.Item2;

            // Assert          
            //Assert.AreEqual(expectedWork, personalWork);
            CollectionAssert.AreEqual(expectedWork, actualWork);
        }          
    }
}
