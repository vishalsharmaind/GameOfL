using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLifeCore;

namespace TestProject
{
    [TestClass]
    public class GridTest
    {
        private static Game grid;
        private TestContext testContextInstance;


        /// <summary>
        ///Gets or sets the test context.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [ClassInitialize()]
        public static void ClassIntialize(TestContext testContext)
        {
            grid = GridHelper.GetGridWithAllDeadCell();
        }

        [TestMethod]
        public void GridConstructorPositiveTest()
        {
            Assert.AreEqual(grid.RowCount, 4);
            Assert.AreEqual(grid.ColumnCount, 4);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Argument out of bound")]
        public void GridConstructorNegativeTest()
        {
            int rows = -1;
            int columns = 0;
            Game target = new Game(rows, columns);
        }

        [TestMethod]
        public void CellCount()
        {
            int count = 0;
            foreach (Cell cell in grid)
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    count++;
                }
            }
            Assert.AreEqual(16, count);
        }

        
    }
}
