using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public interface ProceedCommand
    {
        void Execute();
    }

    public class ProceedEastCommand : ProceedCommand
    {
        private MarsRover _marsRover;

        public ProceedEastCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            _marsRover.ObstacleFound = _marsRover.Obstacles.Contains($"{_marsRover.X + 1}:{_marsRover.Y}");
            _marsRover.X = _marsRover.X < 9 && !_marsRover.ObstacleFound ? _marsRover.X += 1 : _marsRover.X;
        }
    }
}