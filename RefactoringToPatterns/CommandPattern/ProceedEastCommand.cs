using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public class ProceedEastCommand
    {
        private MarsRover _marsRover;

        public ProceedEastCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            _marsRover._obstacleFound = _marsRover._obstacles.Contains($"{_marsRover._x + 1}:{_marsRover._y}");
            _marsRover._x = _marsRover._x < 9 && !_marsRover._obstacleFound ? _marsRover._x += 1 : _marsRover._x;
        }
    }
}