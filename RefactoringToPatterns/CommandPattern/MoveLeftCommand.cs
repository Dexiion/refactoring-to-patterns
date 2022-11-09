namespace RefactoringToPatterns.CommandPattern
{
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
}