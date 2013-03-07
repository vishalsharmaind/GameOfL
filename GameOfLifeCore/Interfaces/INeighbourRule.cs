using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeCore.Interfaces
{
    public interface INeighbourRule
    {
        /// <summary>
        /// Method to decide the neighbours for a given cell that meets a given specification.
        /// </summary>
        /// <param name="cell">Cells whose neighbour need to check.</param>
        /// <param name="specification">neighbouring cells specification.</param>
        /// <returns>reutrns the collection of cells that meet the specification criteria.</returns>
        ICollection<Cell> FindNeighbourCells(Cell cell, ISpecification<Cell> specification);
    }
}
