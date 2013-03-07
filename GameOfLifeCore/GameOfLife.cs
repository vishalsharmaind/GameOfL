using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeCore.Interfaces;

namespace GameOfLifeCore
{
    /// <summary>
    /// General implimentation of Game of Life
    /// </summary>
    public class GameOfLife : IGameOfLife
    {
        private ICellCollection grid;
        private IRuleFactory ruleFactory;
        private INeighbourRuleFactory neighbouruleFactory;

        private int generationNumber;
       
        /// <summary>
        /// get the current generation number.
        /// </summary>
        public int GenerationNumber { get { return generationNumber; } }

        /// <summary>
        /// Default constructor of the class,which will define the correct configration of rule factory and neighbourrule factory.
        /// </summary>
        /// <param name="grid">collectiion of cells</param>
        /// <param name="ruleFactory"> Factory to create rule. </param>
        /// <param name="neighbourRule">Factory to create neighbour rule.</param>
        public GameOfLife(ICellCollection grid, IRuleFactory ruleFactory, INeighbourRuleFactory neighbouruleFactory)
        {
            this.generationNumber = 1;
            this.grid = grid;
            this.ruleFactory = ruleFactory;
            this.neighbouruleFactory = neighbouruleFactory;

        }

        private IRule GetRule()
        {
            INeighbourRule neighbourrule = neighbouruleFactory.Create(grid);
            IRule evolutionrule = ruleFactory.CreateRule(neighbourrule);
            return evolutionrule;
        }

        public void Evolve()
        {
            IRule rule = GetRule();
            Cell evolvedCell = null;

            generationNumber++;
            
            foreach (Cell cell in this.grid)
            {
                evolvedCell = rule.CellToEvolve(cell);
                cell.SetNewState(evolvedCell.IsAlive);
            }
            foreach (Cell cell in grid)
            {
                cell.ApplyNewState();
            }
        }

    }
}
