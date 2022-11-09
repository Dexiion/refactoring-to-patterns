namespace RefactoringToPatterns.CommandPattern
{
    public class MarsRover
    {
        internal int X;
        internal int Y;
        internal char _direction;
        internal readonly string _availableDirections = "NESW";
        internal readonly string[] Obstacles;
        internal bool ObstacleFound;
        private readonly MoveCommand moveRightCommand;
        private readonly MoveCommand moveLeftCommand;
        private readonly MoveCommand moveForwardCommand;

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
                moveForwardCommand.Execute();
            }
            else if (command == 'L')
            {
                moveLeftCommand.Execute();
            }
            else if (command == 'R')
            {
                moveRightCommand.Execute();
            }
        }
    }
}