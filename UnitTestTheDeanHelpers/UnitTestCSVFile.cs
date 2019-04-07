using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheDeanHelpers.Model;

namespace UnitTestTheDeanHelpers
{
    [TestClass]
    public class UnitTestCSVFile
    {
        [TestMethod]
        public void TestEquablePositive()
        {
            #region Arrange

            CSVFile expectedCSVFile = new CSVFile();
            CSVFile actualCSVFile = new CSVFile();

            #endregion

            #region Assert

            Assert.IsTrue(expectedCSVFile.Equals(actualCSVFile));

            #endregion
        }

        [TestMethod]
        public void TestEquableNegative()
        {
            #region Arrange

            CSVFile expectedCSVFile = new CSVFile();
            CSVFile actualCSVFile = new CSVFile();

            #endregion

            #region Action

            actualCSVFile.Columns.Add(new Column()
            {
                Id = 1,
                Name = "test",
                IsActive = true
            });

            #endregion

            #region Assert

            Assert.IsFalse(expectedCSVFile.Equals(actualCSVFile));

            #endregion
        }
    }
}
