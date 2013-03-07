using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeCore.Interfaces;

namespace GameOfLifeCore
{
    /// <summary>
    /// Defining Rule for Chekcing out neighbours cell for 2 dimension matrix.
    /// </summary>
    public class MatrixNeighbourCellRule : INeighbourRule
    {
        private Game grid;

        /// <summary>
        /// To find neighbours of pass cell in optimized way, the rule must be self aware of strucutre in which it's contained.
        /// </summary>
        /// <param name="grid"></param>
        public MatrixNeighbourCellRule(Game grid)
        {
            this.grid = grid;
        }
        
        /// <summary>
        /// This method will return the list of cells that meet the specification.
        /// <param name="cell"> source cell, whose neighbours need to find </param>
        /// <param name="specification">Actual specification, which need to pass by neighbours.  </param>
        /// <returns>return the cell collection which pass the specification. </returns>
        public ICollection<Cell> FindNeighbourCells(Cell cell, ISpecification<Cell> specification)
        {
            if(cell == null)
                throw new ArgumentNullException("Cell can't be empty");

            List<Cell> cells = new List<Cell>();

            int startRow;
            int startCol;
            int endRow;
            int endCol;

            int colIndex = cell.ColNumber;
            int rowIndex = cell.RowNumber;

            GetValidStartRowAndCol(rowIndex, colIndex, out startRow, out startCol);
            GetValidEndRowAndCol(rowIndex, colIndex, out endRow, out endCol);

            for (int xcoord = startRow; xcoord <= endRow; xcoord++)
            {
                for (int ycoord = startCol; ycoord <= endCol; ycoord++)
                {
                    if (!(xcoord == rowIndex && ycoord == colIndex))
                    {
                        if (specification == null)
                            cells.Add(grid[xcoord, ycoord]);
                        else
                            if (specification.IsSpecificationMeet(grid[xcoord, ycoord]))
                                cells.Add(grid[xcoord, ycoord]);
                    }
                }
            }
            return cells;

        }

        /// <summary>
        /// Get the index of row and column from where search will start.
        /// </summary>
        /// <param name="row">cell row number</param>
        /// <param name="col">cell column number</param>
        /// <param name="startRow">starting row to start search</param>
        /// <param name="startCol">starting col to start search</param>
        private void GetValidStartRowAndCol(int row, int col, out int startRow, out int startCol)
        {
            startRow = row > 0 ? row - 1 : 0;
            startCol = col > 0 ? col - 1 : 0;
        }

        /// <summary>
        /// Get the index of row and column, where to stop the search.
        /// </summary>
        /// <param name="row"> cell row number</param>
        /// <param name="col">cell column number</param>
        /// <param name="endRow">end row to stop the search</param>
        /// <param name="endCol">end column to stop the search</param>
        private void GetValidEndRowAndCol(int row, int col, out int endRow, out int endCol)
        {
            endCol = col + 1 < grid.ColumnCount ? col + 1 : grid.ColumnCount - 1;
            endRow = row + 1 < grid.RowCount ? row + 1 : grid.RowCount - 1;
        }
    }
}
