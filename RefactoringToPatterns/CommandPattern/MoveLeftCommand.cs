namespace RefactoringToPatterns.CommandPattern
{
    public class MoveLeftCommand : MoveCommand
    {
        private MarsRover _marsRover;

        public MoveLeftCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            var currentDirectionPosition = _marsRover._availableDirections.IndexOf(_marsRover.Direction);
            _marsRover.Direction = currentDirectionPosition != 0
                ? _marsRover._availableDirections[currentDirectionPosition - 1]
                : _marsRover._availableDirections[3];
        }
    }
}