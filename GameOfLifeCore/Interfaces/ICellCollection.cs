using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeCore.Interfaces
{
    /// <summary>
    ///  This can be extendable either in 3 dimensional view of the cells or a 4 dimensional view of the cells.
    /// </summary>
    public interface ICellCollection
    {
        IEnumerator<Cell> GetEnumerator();
    }
}
