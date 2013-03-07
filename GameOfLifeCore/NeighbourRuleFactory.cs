using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeCore.Interfaces;

namespace GameOfLifeCore
{
    /// <summary>
    /// This class will create an instance of NeighbourRule based on containing cells.
    /// </summary>
    public class NeighbourRuleFactory : INeighbourRuleFactory
    {
        /// <summary>
        /// Right now it is creating predefine object of matrix class, here we can define configurable instance for
        /// given dimension type.
        /// </summary>
        /// <param name="cellCollection"></param>
        /// <returns></returns>
        public INeighbourRule Create(ICellCollection cellCollection)
        {
            return new MatrixNeighbourCellRule((Game)cellCollection);
        }
    }
}
