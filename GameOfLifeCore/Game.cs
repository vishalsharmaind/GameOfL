using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeCore.Interfaces;

namespace GameOfLifeCore
{
    /// <summary>
    /// By Default this class will impliments two dimension Array of cells.
    /// </summary>
    public class Game : ICellCollection
    {
        private Cell[][] cells;
        private int rowCount;
        private int colCount;
        private int maxLimit = 10000;
        /// <summary>
        /// Return the Row Number.
        /// </summary>
        public int RowCount { get { return rowCount; } }

        /// <summary>
        /// Return the Column Number.
        /// </summary>
        public int ColumnCount { get { return colCount; } }

        /// <summary>
        /// Indexer to get to a cell at given row and column number.
        /// </summary>
        /// <param name="rowNumber">cell row number</param>
        /// <param name="colNumber">coulumn row number</param>
        /// <returns></returns>
        public Cell this[int rowNumber, int colNumber]
        {
            get
            {
                if (colNumber < 0 || rowNumber < 0 || colNumber >= colCount || rowNumber >= rowCount)
                {
                    throw new ArgumentOutOfRangeException("Row and column should be within the define dimension.");
                }
                return cells[rowNumber][colNumber];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowCount">row limit of the grid</param>
        /// <param name="columnCount">column limit of the grid</param>
        public Game(int rowCount, int columnCount)
        {

            if ((rowCount <= 0 || columnCount <= 0) || (rowCount > maxLimit || columnCount > maxLimit))
            {
                throw new ArgumentOutOfRangeException("The rowCount and columnCount should be greater than 0 and less than 10000.");
            }

            this.rowCount = rowCount;
            this.colCount = columnCount;

            cells = new Cell[rowCount][];
            
            for (int rcount = 0; rcount < rowCount; rcount++ )
            {
                cells[rcount] = new Cell[columnCount];

                for (int colCount = 0; colCount < columnCount; colCount++)
                {
                    new Cell(rcount, colCount, false);
                    cells[rcount][colCount] = new Cell(rcount, colCount, false);
                }
            }
        }


        /// <summary>
        /// Provide the capability to enumerate through the cells.
        /// </summary>
        /// <returns> return an emumerator</returns>
        public IEnumerator<Cell> GetEnumerator()
        {
            return new GridCellEnum(this);
        }

        
    }
}
