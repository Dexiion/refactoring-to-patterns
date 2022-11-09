using System.Linq;

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

    public class ProceedWestCommand
    {
        private MarsRover _marsRover;

        public ProceedWestCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void ProceedWest()
        {
            _marsRover._obstacleFound = _marsRover._obstacles.Contains($"{_marsRover._x - 1}:{_marsRover._y}");
            // check if rover reached plateau limit or found an obstacle
            _marsRover._x = _marsRover._x > 0 && !_marsRover._obstacleFound ? _marsRover._x -= 1 : _marsRover._x;
        }
    }

    public class ProceedSouthCommand
    {
        private MarsRover _marsRover;

        public ProceedSouthCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void ProceedSouth()
        {
            _marsRover._obstacleFound = _marsRover._obstacles.Contains($"{_marsRover._x}:{_marsRover._y + 1}");
            // check if rover reached plateau limit or found an obstacle
            _marsRover._y = _marsRover._y < 9 && !_marsRover._obstacleFound ? _marsRover._y += 1 : _marsRover._y;
        }
    }

    public class ProceedEastCommand
    {
        private MarsRover _marsRover;

        public ProceedEastCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void ProceedEast()
        {
            _marsRover._obstacleFound = _marsRover._obstacles.Contains($"{_marsRover._x + 1}:{_marsRover._y}");
            // check if rover reached plateau limit or found an obstacle
            _marsRover._x = _marsRover._x < 9 && !_marsRover._obstacleFound ? _marsRover._x += 1 : _marsRover._x;
        }
    }

    public class MarsRover
    {
        internal int _x;
        internal int _y;
        private char _direction;
        private readonly string _availableDirections = "NESW";
        internal readonly string[] _obstacles;
        internal bool _obstacleFound;
        private readonly ProceedNorthCommand proceedNorthCommand;
        private readonly ProceedWestCommand proceedWestCommand;
        private readonly ProceedSouthCommand proceedSouthCommand;
        private readonly ProceedEastCommand proceedEastCommand;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            _x = x;
            _y = y;
            _direction = direction;
            _obstacles = obstacles;
            proceedNorthCommand = new ProceedNorthCommand(this);
            proceedWestCommand = new ProceedWestCommand(this);
            proceedSouthCommand = new ProceedSouthCommand(this);
            proceedEastCommand = new ProceedEastCommand(this);
        }
        
        public string GetState()
        {
            return !_obstacleFound ? $"{_x}:{_y}:{_direction}" : $"O:{_x}:{_y}:{_direction}";
        }

        public void Execute(string commands)
        {
            foreach(char command in commands)
            {
                if (command == 'M')
                {
                    Proceed();
                }
                else if(command == 'L')
                {
                    // get new direction
                    var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                    if (currentDirectionPosition != 0)
                    {
                        _direction = _availableDirections[currentDirectionPosition-1];
                    }
                    else
                    {
                        _direction = _availableDirections[3];
                    }
                } else if (command == 'R')
                {
                    // get new direction
                    var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                    if (currentDirectionPosition != 3)
                    {
                        _direction = _availableDirections[currentDirectionPosition+1];
                    }
                    else
                    {
                        _direction = _availableDirections[0];
                    }
                }
            }
        }

        private void Proceed()
        {
            switch (_direction)
            {
                case 'E':
                    proceedEastCommand.ProceedEast();
                    break;
                case 'S':
                    proceedSouthCommand.ProceedSouth();
                    break;
                case 'W':
                    proceedWestCommand.ProceedWest();
                    break;
                case 'N':
                    proceedNorthCommand.ProceedNorth();
                    break;
            }
        }
    }
}