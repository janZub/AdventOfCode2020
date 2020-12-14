using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day6
{
    public class PuzzleDay6b : PuzzleDay6
    {
        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            var groupsData = inputHandler.ConvertListToGroupDataList(input);
            inputData = inputHandler.CreateGroup6bFromInput(groupsData);
        }
    }
}