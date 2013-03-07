using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeCore.Interfaces
{
    /// <summary>
    /// create instance of neighbourRule.
    /// </summary>
    public interface INeighbourRuleFactory
    {
        /// <summary>
        /// Creates an instance of NeighbourRule depending of the different dimensions.
        /// </summary>
        /// <param name="cellCollection">Instance of ICellCollection.</param>
        /// <returns>Returns an instance of INeighbourRule</returns>
        INeighbourRule Create(ICellCollection cellCollection);
    }
}
