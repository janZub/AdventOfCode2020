using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzles.Day24
{
    public class HexFloorTileDay24
    {
        private TileDay24[,] _tiles;
        private IInstructionService _instructionService;
        private INeighboourStrategy _strategy;
        private int _heightCenter;
        private int _widthCenter;

        public HexFloorTileDay24(int size, IInstructionService instructionService, INeighboourStrategy strategy)
        {
            _tiles = new TileDay24[size * 2 + 1, (size * 2 + 1) * 2];

            for (int i = 0; i < _tiles.GetLength(0); i++)
                for (int j = 0; j < _tiles.GetLength(1); j++)
                    _tiles[i, j] = new TileDay24();

            _instructionService = instructionService;
            _strategy = strategy;

            _heightCenter = size + 1;
            _widthCenter = size * 2 + 1;
        }

        public ulong BlackTilesCount()
        {
            ulong nr = 0;
            for (int i = 0; i < _tiles.GetLength(0); i++)
                for (int j = 0; j < _tiles.GetLength(1); j++)
                    if (_tiles[i, j].State)
                        nr++;

            return nr;
        }
        public void PerformInstruction(string instruction)
        {
            var instructions = _instructionService.ExtractInstructions(instruction);
            var shift = _instructionService.ComputeShift(instructions);

            _tiles[_heightCenter + shift.Item1, _widthCenter + shift.Item2].ChangeState();
        }
        public void ChangeState()
        {
            UpdateNeighboursCount();
            UpdateTilesStates();
        }

        private void UpdateNeighboursCount()
        {
            for (int hi = 1; hi < _tiles.GetLength(0); hi++)
            {
                int hj = 2 + (hi % 2);
                for (; hj < _tiles.GetLength(1); hj += 2)
                    _tiles[hi, hj].Neighbours = _strategy.CountOccupiedNeighbours(_tiles, hi, hj);
            }
        }
        private void UpdateTilesStates()
        {
            for (int hi = 1; hi < _tiles.GetLength(0); hi++)
            {
                int hj = 2 + (hi % 2);
                for (; hj < _tiles.GetLength(1); hj += 2)
                    if (_strategy.ShouldChangeState(_tiles[hi, hj]))
                        _tiles[hi, hj].ChangeState();
            }
        }
    }
}