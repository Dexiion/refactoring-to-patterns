﻿using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public class ProceedNorthCommand
    {
        private MarsRover _marsRover;

        public ProceedNorthCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void ProceedNorth()
        {
            _marsRover._obstacleFound = _marsRover._obstacles.Contains($"{_marsRover._x}:{_marsRover._y - 1}");
            // check if rover reached plateau limit or found an obstacle
            _marsRover._y = _marsRover._y > 0 && !_marsRover._obstacleFound ? _marsRover._y -= 1 : _marsRover._y;
        }
    }
}