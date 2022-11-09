using System.Collections.Generic;

namespace RefactoringToPatterns.CommandPattern
{
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
}