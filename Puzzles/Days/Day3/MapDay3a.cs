using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Day3
{
    public class MapDay3a
    {
        public MapDay3a(List<string> inputMap, int moveBottom, int moveRight)
        {
            Map = inputMap;
            Height = inputMap.Count;
            Width = inputMap[0].Length;
            CurrentPositionX = 0;
            CurrentPositionY = 0;
            MoveBottom = moveBottom;
            MoveRight = moveRight;
        }

        public void Move()
        {
            CurrentPositionX = (CurrentPositionX + MoveRight) % Width;
            CurrentPositionY = CurrentPositionY + MoveBottom;
        }
        public bool IsAtTree()
        {
            return Map[CurrentPositionY][CurrentPositionX] == '#';
        }
        public bool DidLeftMap()
        {
            return CurrentPositionY >= Height;
        }

        public List<string> Map { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int MoveRight { get; private set; }
        public int MoveBottom { get; private set; }
        public int CurrentPositionX { get; private set; }
        public int CurrentPositionY { get; private set; }
    }
}