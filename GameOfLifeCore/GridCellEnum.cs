using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeCore
{
    /// <summary>
    /// enumrator for the cell contained in a Grid.
    /// </summary>
    public class GridCellEnum: IEnumerator<Cell>
    {
        private Game grid;
        private int indexOfCurrentRow = 0;
        private int indexOfCurrentCol = -1;

        /// <summary>
        /// Default constrauctor
        /// </summary>
        /// <param name="grid"></param>
        public GridCellEnum(Game grid)
        {
            this.grid = grid;
        }

        /// <summary>
        /// return the current cell of the grid.
        /// </summary>
        public Cell Current
        {
            get { return grid[indexOfCurrentRow, indexOfCurrentCol]; }
        }

        public void Dispose()
        {
           
        }

        /// <summary>
        /// return the current cell of the grid.
        /// </summary>
        object System.Collections.IEnumerator.Current
        {
            get { return Current;}
        }

        /// <summary>
        /// this method will move the pointer location from current cell to next cell.
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            bool retval;
            if (indexOfCurrentCol >= grid.RowCount - 1 && indexOfCurrentCol >= grid.ColumnCount - 1)
                retval = false;
            else
            {
                indexOfCurrentCol++;
                if (indexOfCurrentCol == grid.ColumnCount)
                {
                    indexOfCurrentRow++;
                    indexOfCurrentCol = 0;
                }
                retval = true;
            }
            return retval;
        }

        /// <summary>
        /// Set the default value of row counter and coulmn counter.
        /// </summary>
        public void Reset()
        {
           indexOfCurrentRow = 0;
           indexOfCurrentCol = -1;
        }
    }
}
