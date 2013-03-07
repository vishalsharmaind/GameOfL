using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeCore
{
    public class Cell
    {
        private int rowNumber;
        private int colNumber;
        private bool proposedState = false;
        /// <summary>
        /// Return the Row Number.
        /// </summary>
        public int RowNumber { get { return rowNumber; } }

        /// <summary>
        /// Return the Column Number.
        /// </summary>
        public int ColNumber { get { return colNumber ;} }

        /// <summary>
        /// Get and Set whether cell is Alive or dead.
        /// </summary>
        public bool IsAlive { get; set; }

        /// <summary>
        /// Default contrutor of the class.
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="colNumber"></param>
        /// <param name="isAlive"></param>
        public Cell(int rowNumber,int colNumber,bool isAlive)
        {
            this.rowNumber = rowNumber;
            this.colNumber = colNumber;
            this.IsAlive = isAlive;

        }

        /// <summary>
        /// This method sets sets the current state of the Cell to the purposed state.
        /// </summary>
        public void ApplyNewState()
        {
            this.IsAlive = proposedState;
        }

        /// <summary>
        /// This method sets the new state to whatever the evolved state.
        /// </summary>
        /// <param name="isAlive"></param>
        public void SetNewState( bool isAlive)
        {
            proposedState = isAlive;
        }

    }
}

