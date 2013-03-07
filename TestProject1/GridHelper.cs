using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeCore;

namespace TestProject
{
    public static class GridHelper
    {
        public static Game GetGridWithAllDeadCell()
        {
            return new Game(4, 4);
        }

        public static Game GetGridWithTopLeftAlive()
        {
            Game grid = GetGridWithAllDeadCell();
            grid[0,0].IsAlive = true;
            return grid;
        }

        public static Game GetGridWithDiagonalNeighbourAliveofMiddleCellDead()
        {
            Game grid = GetGridWithAllDeadCell();
            grid[0, 0].IsAlive = true;
            grid[0, 2].IsAlive = true;
            grid[2, 2].IsAlive = true;
            return grid;
        }

        public static Game GetGridWithNeighbourAliveOfMiddelCell()
        {
            Game grid = GetGridWithAllDeadCell();
            grid[0, 2].IsAlive = true;
            return grid;
        }

        public static Game GetGridWithTopRowAlive()
        {
            Game grid = GetGridWithAllDeadCell();
            grid[0, 0].IsAlive = true;
            grid[0, 1].IsAlive = true;
            grid[0, 2].IsAlive = true;
            grid[0, 3].IsAlive = true;
            return grid;
        }

        public static Game GetGridWithMiddleCellDeadAnd4NeighbourAlive()
        {
            Game grid = GetGridWithAllDeadCell();
            grid[0, 0].IsAlive = true;
            grid[0, 1].IsAlive = true;
            grid[1, 0].IsAlive = true;
            grid[0, 2].IsAlive = true;
            return grid;
        }
    }
}
