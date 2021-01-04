using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace Puzzles.Day24
{
    public abstract class PuzzleDay24 : Puzzle
    {
        protected ulong solution;
        protected string inputFileileName = "Day24Input";
        protected FileExtensionEnum fileExt = FileExtensionEnum.TXT;
        protected HexFloorTileDay24 tiles;


        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);
            tiles = new HexFloorTileDay24(150, new InstructionService(), new NeighboursStrategy());

            foreach (var instruction in input)
                tiles.PerformInstruction(instruction);
        }
    }
}