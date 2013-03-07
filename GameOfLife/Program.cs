using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLifeCore;
using GameOfLifeCore.Interfaces;

namespace GameOfLifePresenter
{
    class Program
    {
        static void Main(string[] args)
        {
            Cell[] cells = null;
            PrintInstructions();
            if (!string.IsNullOrWhiteSpace(GetUserInput(ref cells)))
            {

                Game grid = new Game(4, 4);
                SetAliveValue(cells,grid);

                IGameOfLife gameOfLife = GetGameOfLifeController(grid);

                PrintCellCurrentState(grid);

                for (int hitCount = 0; hitCount < 10; hitCount++)
                {
                    Console.WriteLine("Press to enter to next generation");
                    Console.ReadLine();
                    gameOfLife.Evolve();
                    PrintCellCurrentState(grid);
                }

                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }

        }

        private static void SetAliveValue(Cell[] cells, Game grid)
        {
            // Initialize with values got as user input.
            foreach (Cell cell in cells)
            {
                grid[cell.RowNumber, cell.ColNumber].IsAlive = true;
            }
        }

        private static IGameOfLife GetGameOfLifeController(Game grid)
        {
            // Create the neighbourhood rule
            INeighbourRuleFactory neighbourRuleFactory = new NeighbourRuleFactory();
            
            // Create the rule
            IRuleFactory ruleFactory = new RuleFactory();

            IGameOfLife gameofLifeobject = new GameOfLife(grid, ruleFactory, neighbourRuleFactory);
            return gameofLifeobject;
        }

        private static void PrintCellCurrentState(Game grid)
        {
            int rownumber = 0;
            for (int count = 0; count < grid.RowCount; count++ )
            {
                for(int colCount = 0; colCount < grid.ColumnCount ; colCount++)
                {
                    if (rownumber != grid[count,colCount].RowNumber)
                    {
                        rownumber++;
                        Console.WriteLine();
                    }

                    Console.Write("{0}\t", grid[count, colCount].IsAlive ? "Live" : "Dead");
                }
            }
            Console.WriteLine();
        }
       
        private static Cell[] ValidateUserInput(string userInput)
        {
            List<Cell> cells = new List<Cell>();
            string[] cellsEnterByUser = userInput.Split('|');
            int rownum;
            int colnum;
           
            if (cellsEnterByUser.Length == 0)
                  throw new Exception("Invalid user input.");


            for (int count = 0; count < cellsEnterByUser.Length; count++)
            {
                rownum = 0;
                colnum = 0;
                string[] coordinstring = cellsEnterByUser[count].Split(',');
                if (coordinstring.Length != 2)
                {
                    throw new Exception("Invalid user input.");
                }
                if (!Int32.TryParse(coordinstring[0], out rownum))
                {
                    throw new Exception("Invalid user input.");
                }
                if (!Int32.TryParse(coordinstring[1], out colnum))
                {
                    throw new Exception("Invalid user input.");
                }
                cells.Add(new Cell(rownum, colnum, true));
            }
            return cells.ToArray();
        }

        private static string GetUserInput(ref Cell[] cells)
        {
            string userinput = Console.ReadLine();
            while (true)
            {
                try
                {
                    cells = ValidateUserInput(userinput);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("\n\n\n\n\nInvalid input! Read the instructions below and try again.\n\n");
                    PrintInstructions();
                    userinput = Console.ReadLine();
                }
            }
            return userinput;
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Welcome to Game of Life. \n");
            Console.WriteLine("Please specify the cells that are originally alive. \n");
            Console.WriteLine("<rownum>,<colnum> | <rownum>,<columnnum>\n");
            Console.WriteLine("Example - 1,1| 2,2 - Means that the cells in the specific location(rownumber, columnnumber) are alive.\n");
            Console.WriteLine("This example modify with purposed value of cells 10 times.");
            Console.WriteLine("Press ENTER after entering the values. Waiting...");
          
        }
    }
}
