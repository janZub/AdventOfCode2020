using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day11
{
    public abstract class PuzzleDay11 : Puzzle
    {
        protected AirportSeatsDay11 inputData;
        protected int solution;

        protected string inputFileileName = "Day11Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;

        public override void DeliverResults()
        {
            Console.WriteLine(string.Format("There are {0} seats occupied.", solution));

            inputData.PrintSeats();

        }
        public override void Solve()
        {
            while (inputData.ChangeState()) ;
                
            solution = inputData.GetNumberOfOccupiedSeats();
        }
        protected SeatDay11[,] ProcessInputToArray()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);
            var width = input[0].Trim().Length;
            var height = input.Count;

            var seats = new SeatDay11[height, width];

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    seats[i, j] = new SeatDay11(input[i].Trim()[j]);

            return seats;
        }
    }
}