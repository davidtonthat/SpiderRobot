namespace RobotSpider.robot_spider;

public class SpiderOnWall
{
    private readonly Coordinate _coordinate;
    private readonly Wall _wall;
    private readonly Navigator _navigator;

    public SpiderOnWall(Coordinate initCoordinate, Wall wall)
    {
        _coordinate = initCoordinate;
        _wall = wall;
        _navigator = new Navigator(initCoordinate);
    }

    public Coordinate MoveOnCommand(char command)
    {
        if (command == Navigator.Forward && IsAtBoundary(_coordinate))
        {
            Console.WriteLine("Error: Cannot move forward when spider coordinate is at wall boundary.");
            return _coordinate;
        }
        return _navigator.Move(command);
    }

    public Coordinate MoveOnCommandSequence(List<char> commands)
    {
        Coordinate coordinate = null!;

        foreach (var cmd in commands)
        {
            coordinate = MoveOnCommand(cmd);
        }

        return coordinate;
    }

    private bool IsAtBoundary(Coordinate currentCoordinate)
    {
        switch (currentCoordinate.Orientation)
        {
            case Orientation.Left:
                return currentCoordinate.X == 0;
            case Orientation.Right:
                return currentCoordinate.X == _wall.Width;
            case Orientation.Up:
                return currentCoordinate.Y == _wall.Height;
            case Orientation.Down:
                return currentCoordinate.Y == 0;
            default:
                return false;
        }
    }
}