using System.Collections.Generic;

namespace RefactoringToPatterns.CommandPattern
{
    public class MoveForwardCommand : MoveCommand
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

        public void Execute()
        {
            ProceedCommands[_marsRover.Direction].Execute();
        }
    }
}