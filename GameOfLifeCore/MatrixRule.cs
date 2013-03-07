using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeCore.Interfaces;

namespace GameOfLifeCore
{
    /// <summary>
    /// This class will define how a given cell would evolve for 2 dimension.
    /// </summary>
    public class MatrixRule : IRule
    {
        INeighbourRule neighbourRule;

       // create static instance of cell as being alive.
        static ISpecification<Cell> aliveSpec = new AliveSpecification();

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="neighbourRule"></param>
        public MatrixRule(INeighbourRule neighbourRule)
        {
            this.neighbourRule = neighbourRule;
        }


        /// <summary>
        /// Evolve the cell by applying rule.
        /// </summary>
        /// <param name="cell">cell to evolve.</param>
        /// <returns> return the evolve cell.</returns>
        public Cell CellToEvolve(Cell cell)
        {
            if(cell == null)
                throw new ArgumentNullException("Cell can't be null.");

            Cell purposecell = new Cell(cell.RowNumber, cell.ColNumber, false);

            int aliveneighbours = this.neighbourRule.FindNeighbourCells(cell, aliveSpec).Count;

            if (cell.IsAlive)
            {
                if (aliveneighbours == 2 || aliveneighbours == 3)
                    purposecell.IsAlive = true;
            }

            else if (aliveneighbours == 3)
            {
                purposecell.IsAlive = true;
            }
                   
            return purposecell;
        }
    }
}
