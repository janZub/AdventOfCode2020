﻿using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Puzzles.Day6
{
    public class PuzzleDay6a : PuzzleDay6
    {
        public override void ReadInput()
        {
            var path = PuzzleUtils.PuzzleInputsPath;
            var input = FileReader.ReadFile(path, inputFileileName, fileExt);

            var groupsData = inputHandler.ConvertListToGroupDataList(input);
            var onlyStringInput = groupsData.Select(g => g.Item1).ToList();
            inputData = inputHandler.CreateGroup6aFromInput(onlyStringInput);
        }
    }
}