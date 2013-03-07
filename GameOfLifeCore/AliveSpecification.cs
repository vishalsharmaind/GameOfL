using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeCore.Interfaces;

namespace GameOfLifeCore
{
    /// <summary>
    /// Specification of a cell to beign alive.
    /// </summary>
    public class AliveSpecification : ISpecification<Cell>
    {

        /// <summary>
        /// This method is used to check the specification of being alive.
        /// </summary>
        /// <param name="genObject"></param>
        /// <returns></returns>
        public bool IsSpecificationMeet(Cell genObject)
        {
            if (genObject == null)
            {
                throw new ArgumentNullException("Cell is null");
            }
            return genObject.IsAlive;
        }
    }
}
