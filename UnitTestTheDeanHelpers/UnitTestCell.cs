using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheDeanHelpers.Model;

namespace UnitTestTheDeanHelpers
{
    [TestClass]
    public class UnitTestCell
    {
        [TestMethod]
        public void TestEqualPositive()
        {
            #region Arrange

            Cell exceptedCell = new Cell()
            {
                ColumnId = 0,
                RowId = 0,
                Value = "test"
            };
            Cell actualCell = new Cell()
            {
                ColumnId = 0,
                RowId = 0,
                Value = "test"
            };

            #endregion

            #region Assert

            Assert.IsTrue(exceptedCell.Equals(actualCell));

            #endregion
        }

        [TestMethod]
        public void TestEqualNegative()
        {
            #region Arrange

            Cell exceptedCell = new Cell()
            {
                ColumnId = 0,
                RowId = 0,
                Value = "test"
            };
            Cell actualCell = new Cell()
            {
                ColumnId = 1,
                RowId = 1,
                Value = "negative test"
            };

            #endregion

            #region Assert

            Assert.IsFalse(exceptedCell.Equals(actualCell));

            #endregion
        }
    }
}
