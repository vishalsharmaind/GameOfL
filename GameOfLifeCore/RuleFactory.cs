using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeCore.Interfaces;

namespace GameOfLifeCore
{
    public class RuleFactory : IRuleFactory
    {
        public IRule CreateRule(INeighbourRule neighbourRule)
        {
            //This will return hard code rule, this need to be driven through config.
            return new MatrixRule(neighbourRule);
        }
    }
}
