using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheDeanHelpers.Model;

namespace UnitTestTheDeanHelpers
{
    [TestClass]
    public class UnitTestColumn
    {
        [TestMethod]
        public void TestEqualPositive()
        {
            #region Arrange

            string name = "test";
            Column exceptedColumn = new Column()
            {
                Id = 0,
                Name = name,
                IsActive = true
            };
            Column actualColumn = new Column()
            {
                Id = 0,
                Name = name,
                IsActive = true
            };

            #endregion

            #region Assert

            Assert.IsTrue(exceptedColumn.Equals(actualColumn));

            #endregion
        }

        [TestMethod]
        public void TestEqualNegative()
        {
            #region Arrange

            Column exceptedColumn = new Column()
            {
                Id = 0,
                Name = "test",
                IsActive = true
            };
            Column actualColumn = new Column()
            {
                Id = 1,
                Name = "test negative",
                IsActive = false
            };

            #endregion

            #region Assert

            Assert.IsFalse(exceptedColumn.Equals(actualColumn));

            #endregion
        }
    }
}
