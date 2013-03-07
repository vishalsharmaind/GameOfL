using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeCore.Interfaces
{
    /// <summary>
    /// Create an instance of Rule.
    /// </summary>
    public interface IRuleFactory
    {
        /// <summary>
        /// create instance of rule.
        /// </summary>
        /// <param name="neighbourRule">Instance of neighbour rule for which rule is configured with.</param>
        /// <returns>return new instance of rule.</returns>
        IRule CreateRule(INeighbourRule neighbourRule);
    }
}
