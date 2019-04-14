using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheDeanHelpers.Model;

namespace UnitTestTheDeanHelpers
{
    [TestClass]
    public class UnitTestRow
    {
        [TestMethod]
        public void TestEqualPositive()
        {
            #region Arrange

            Row exceptedRow = new Row()
            {
                Id = 0,
                Cells = new List<Cell>()
                {
                    new Cell()
                    {
                        ColumnId = 0,
                        RowId = 0,
                        Value = "test"
                    }
                }
            };

            Row actualRow = new Row()
            {
                Id = 0,
                Cells = new List<Cell>()
                {
                    new Cell()
                    {
                        ColumnId = 0,
                        RowId = 0,
                        Value = "test"
                    }
                }
            };

            #endregion

            #region Assert

            Assert.IsTrue(exceptedRow.Equals(actualRow));

            #endregion
        }

        [TestMethod]
        public void TestEqualNegative()
        {
            #region Arrange

            Row exceptedRow = new Row()
            {
                Id = 0,
                Cells = new List<Cell>()
                {
                    new Cell()
                    {
                        ColumnId = 0,
                        RowId = 0,
                        Value = "test"
                    }
                }
            };

            Row actualRow = new Row()
            {
                Id = 0,
                Cells = new List<Cell>()
                {
                    new Cell()
                    {
                        ColumnId = 1,
                        RowId = 1,
                        Value = "test negative"
                    }
                }
            };

            #endregion

            #region Assert

            Assert.IsFalse(exceptedRow.Equals(actualRow));

            #endregion
        }
    }
}
