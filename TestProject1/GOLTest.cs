using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLifeCore;
using GameOfLifeCore.Interfaces;

namespace TestProject
{
    [TestClass]
    public class GOLTest
    {
        private static Game grid;
        private static MatrixNeighbourCellRule rule;


        [ClassInitialize()]
        public static void ClassIntializer(TestContext testContext)
        {
            grid = GridHelper.GetGridWithAllDeadCell();
            rule = new MatrixNeighbourCellRule(grid);
        }

        [TestMethod()]
        public void TopSecondCellNeighbours()
        {
            int target = 5;
            int actual = rule.FindNeighbourCells(grid[0, 1], null).Count;
            Assert.AreEqual(target, actual);
        }

        [TestMethod]
        public void GridWithTopLeftAlive()
        {
            grid = GridHelper.GetGridWithTopLeftAlive();
            INeighbourRuleFactory neighbourRuleFactory = new NeighbourRuleFactory();
            IRuleFactory ruleFactory = new RuleFactory();
            GameOfLife Gol = new GameOfLife(grid, ruleFactory, neighbourRuleFactory);
            Gol.Evolve();
            Assert.AreEqual(false, grid[0, 0].IsAlive);
        
        }

        [TestMethod]
        public void GetGridWithDiagonalNeighbourAliveofMiddleCellDead()
        {
            grid = GridHelper.GetGridWithDiagonalNeighbourAliveofMiddleCellDead();
            INeighbourRuleFactory neighbourRuleFactory = new NeighbourRuleFactory();
            IRuleFactory ruleFactory = new RuleFactory();
            GameOfLife Gol = new GameOfLife(grid, ruleFactory, neighbourRuleFactory);
            Gol.Evolve();
            Assert.AreEqual(false, grid[0, 0].IsAlive);
            Gol.Evolve();
            Assert.AreEqual(false, grid[0, 2].IsAlive);
            Gol.Evolve();
            Assert.AreEqual(Gol.GenerationNumber, 4);
        }

        [TestMethod]
        public void GetGridWithNeighbourAliveOfMiddelCell()
        {
            grid = GridHelper.GetGridWithDiagonalNeighbourAliveofMiddleCellDead();
            INeighbourRuleFactory neighbourRuleFactory = new NeighbourRuleFactory();
            IRuleFactory ruleFactory = new RuleFactory();
            GameOfLife Gol = new GameOfLife(grid, ruleFactory, neighbourRuleFactory);
            Gol.Evolve();
            Cell cell = grid[0, 2];
            Assert.AreEqual(false, cell.IsAlive);

        }

        [TestMethod]
        public void CheckEvoluation()
        {
           INeighbourRuleFactory neighbourRuleFactory = new NeighbourRuleFactory(); 
           IRuleFactory ruleFactory = new RuleFactory();
           GameOfLife Gol = new GameOfLife(grid, ruleFactory, neighbourRuleFactory);
           Gol.Evolve();
           Assert.AreEqual(2, Gol.GenerationNumber);
        }

        [TestMethod()]
        public void TopLeftCellNeighbours()
        {
            int target = 3;
            int actual = rule.FindNeighbourCells(grid[0, 0], null).Count;
            Assert.AreEqual(target, actual);
        }

        [TestMethod]
        public void GameConstuctorPositive()
        {
            int rows = 2;
            int columns = 2;
            Game target = new Game(rows, columns);
            Assert.AreEqual(target.RowCount, 2);
            Assert.AreEqual(target.ColumnCount, 2);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Row and Column size must be greater than zero")]
        public void GameConstructorExceptionTest2()
        {
            int rows = 0;
            int columns = -1;
            Game target = new Game(rows, columns);
        }

        /// <summary>
        ///A default test for Init
        ///</summary>
        [TestMethod()]
        public void InitDefaultValueTest()
        {
            
            Game target = GridHelper.GetGridWithAllDeadCell();
            Assert.AreEqual(target[0, 0].IsAlive, false);
            Assert.AreEqual(target[0, 1].IsAlive, false);
            Assert.AreEqual(target[1, 0].IsAlive, false);
            Assert.AreEqual(target[1, 1].IsAlive, false);
        }


    }
}
