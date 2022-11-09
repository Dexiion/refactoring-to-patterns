namespace RefactoringToPatterns.CommandPattern
{
    public interface MoveCommand
    {
        void Execute();
    }

    public class MoveRightCommand : MoveCommand
    {
        private MarsRover _marsRover;

        public MoveRightCommand(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Execute()
        {
            var currentDirectionPosition = _marsRover._availableDirections.IndexOf(_marsRover.Direction);
            _marsRover.Direction = currentDirectionPosition != 3
                ? _marsRover._availableDirections[currentDirectionPosition + 1]
                : _marsRover._availableDirections[0];
        }
    }
}