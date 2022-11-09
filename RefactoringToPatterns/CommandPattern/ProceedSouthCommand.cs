using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public class ProceedSouthCommand : ProceedCommand
    {
        private MarsRover _marsRover;

        public ProceedSouthCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            _marsRover.ObstacleFound = _marsRover.Obstacles.Contains($"{_marsRover.X}:{_marsRover.Y + 1}");
            _marsRover.Y = _marsRover.Y < 9 && !_marsRover.ObstacleFound ? _marsRover.Y += 1 : _marsRover.Y;
        }
    }
}