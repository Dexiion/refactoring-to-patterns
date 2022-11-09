using System.Collections.Generic;

namespace RefactoringToPatterns.CommandPattern
{
    public class MoveRightCommand
    {
        private MarsRover _marsRover;

        public MoveRightCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void MoveRight()
        {
            var currentDirectionPosition = _marsRover._availableDirections.IndexOf(_marsRover._direction);
            _marsRover._direction = currentDirectionPosition != 3
                ? _marsRover._availableDirections[currentDirectionPosition + 1]
                : _marsRover._availableDirections[0];
        }
    }

    public class MoveLeftCommand
    {
        private MarsRover _marsRover;

        public MoveLeftCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void MoveLeft()
        {
            var currentDirectionPosition = _marsRover._availableDirections.IndexOf(_marsRover._direction);
            _marsRover._direction = currentDirectionPosition != 0
                ? _marsRover._availableDirections[currentDirectionPosition - 1]
                : _marsRover._availableDirections[3];
        }
    }

    public class MoveForwardCommand
    {
        private MarsRover _marsRover;
        private readonly Dictionary<char, ProceedCommand> ProceedCommands;

        public MoveForwardCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
            ProceedCommands = new Dictionary<char, ProceedCommand>
            {
                { 'N', new ProceedNorthCommand(marsRover) }, { 'W', new ProceedWestCommand(marsRover) },
                { 'S', new ProceedSouthCommand(marsRover) }, { 'E', new ProceedEastCommand(marsRover) }
            };
        }

        public void MoveForward()
        {
            ProceedCommands[_marsRover._direction].Execute();
        }
    }

    public class MarsRover
    {
        internal int X;
        internal int Y;
        internal char _direction;
        internal readonly string _availableDirections = "NESW";
        internal readonly string[] Obstacles;
        internal bool ObstacleFound;
        private readonly MoveRightCommand moveRightCommand;
        private readonly MoveLeftCommand moveLeftCommand;
        private readonly MoveForwardCommand moveForwardCommand;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            X = x;
            Y = y;
            _direction = direction;
            Obstacles = obstacles;
            moveRightCommand = new MoveRightCommand(this);
            moveLeftCommand = new MoveLeftCommand(this);
            moveForwardCommand = new MoveForwardCommand(this);
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
                moveForwardCommand.MoveForward();
            }
            else if (command == 'L')
            {
                moveLeftCommand.MoveLeft();
            }
            else if (command == 'R')
            {
                moveRightCommand.MoveRight();
            }
        }
    }
}