using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeCore.Interfaces
{
    public interface IGameOfLife
    {
        /// <summary>
        /// Method for single generation of evolution.
        /// </summary>
        void Evolve();

        /// <summary>
        /// Property to get the current generation.
        /// </summary>
        int GenerationNumber
        {
            get;
        }
    }
}
