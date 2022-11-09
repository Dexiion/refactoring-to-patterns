using System.Collections.Generic;

namespace RefactoringToPatterns.CommandPattern
{
    public class MarsRover
    {
        internal int X;
        internal int Y;
        private char _direction;
        private readonly string _availableDirections = "NESW";
        internal readonly string[] Obstacles;
        internal bool ObstacleFound;
        private readonly Dictionary<char, ProceedCommand> ProceedCommands;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            X = x;
            Y = y;
            _direction = direction;
            Obstacles = obstacles;
            ProceedCommands = new Dictionary<char, ProceedCommand>
            {
                { 'N', new ProceedNorthCommand(this) }, { 'W', new ProceedWestCommand(this) },
                { 'S', new ProceedSouthCommand(this) }, { 'E', new ProceedEastCommand(this) }
            };
        }

        public string GetState()
        {
            return !ObstacleFound ? $"{X}:{Y}:{_direction}" : $"O:{X}:{Y}:{_direction}";
        }

        public void Execute(string commands)
        {
            foreach (char command in commands)
            {
                Move(command);
            }
        }

        private void Move(char command)
        {
            if (command == 'M')
            {
                Proceed();
            }
            else if (command == 'L')
            {
                var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                _direction = currentDirectionPosition != 0 ? _availableDirections[currentDirectionPosition - 1] : _availableDirections[3];
            }
            else if (command == 'R')
            {
                var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                _direction = currentDirectionPosition != 3 ? _availableDirections[currentDirectionPosition + 1] : _availableDirections[0];
            }
        }

        private void Proceed()
        {
            ProceedCommands[_direction].Execute();
        }
    }
}