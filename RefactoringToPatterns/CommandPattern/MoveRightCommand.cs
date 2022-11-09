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
}