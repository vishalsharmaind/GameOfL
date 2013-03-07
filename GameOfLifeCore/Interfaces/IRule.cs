using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeCore.Interfaces
{
    /// <summary>
    /// Rules to evaluate the evolution of a given cell.
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// evolve the cell according to the rule.
        /// </summary>
        /// <param name="cell">cell to evolve. </param>
        /// <returns></returns>
        Cell CellToEvolve(Cell cell);
    }
}
