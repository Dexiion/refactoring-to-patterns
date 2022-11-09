using System.Collections.Generic;

namespace RefactoringToPatterns.CommandPattern
{
    public class MarsRover
    {
        internal int X;
        internal int Y;
        internal char Direction;
        internal readonly string _availableDirections = "NESW";
        internal readonly string[] Obstacles;
        internal bool ObstacleFound;
        private Dictionary<char, MoveCommand> MoveCommands;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            X = x;
            Y = y;
            Direction = direction;
            Obstacles = obstacles;
            MoveCommands = new Dictionary<char, MoveCommand>
            {
                { 'M', new MoveForwardCommand(this) }, { 'R', new MoveRightCommand(this) },
                { 'L', new MoveLeftCommand(this) }
            };
        }

        public string GetState()
        {
            return !ObstacleFound ? $"{X}:{Y}:{Direction}" : $"O:{X}:{Y}:{Direction}";
        }

        public void Execute(string commands)
        {
            foreach (char command in commands)
            {
                MoveCommands[command].Execute();
            }
        }
    }
}