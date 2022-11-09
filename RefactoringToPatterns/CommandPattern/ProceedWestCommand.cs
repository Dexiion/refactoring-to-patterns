using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public class ProceedWestCommand : ProceedCommand
    {
        private MarsRover _marsRover;

        public ProceedWestCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            _marsRover.ObstacleFound = _marsRover.Obstacles.Contains($"{_marsRover.X - 1}:{_marsRover.Y}");
            _marsRover.X = _marsRover.X > 0 && !_marsRover.ObstacleFound ? _marsRover.X -= 1 : _marsRover.X;
        }
    }
}