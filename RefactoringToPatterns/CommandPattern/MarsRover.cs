namespace RefactoringToPatterns.CommandPattern
{
    public class MarsRover
    {
        internal int _x;
        internal int _y;
        private char _direction;
        private readonly string _availableDirections = "NESW";
        internal readonly string[] _obstacles;
        internal bool _obstacleFound;
        private readonly ProceedCommand proceedNorthCommand;
        private readonly ProceedCommand proceedWestCommand;
        private readonly ProceedCommand proceedSouthCommand;
        private readonly ProceedCommand proceedEastCommand;

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
                    proceedEastCommand.Execute();
                    break;
                case 'S':
                    proceedSouthCommand.Execute();
                    break;
                case 'W':
                    proceedWestCommand.Execute();
                    break;
                case 'N':
                    proceedNorthCommand.Execute();
                    break;
            }
        }
    }
}