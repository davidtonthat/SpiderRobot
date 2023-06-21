namespace RobotSpider.robot_spider;

public class Navigator
{
    public const char Left  = 'L';
    public const char Right = 'R';
    public const char Forward = 'F';
    private readonly Coordinate _coordinate;

    public Navigator(Coordinate coordinate)
    {
        _coordinate = coordinate;
    }

    public Coordinate Move(char command)
    {
        switch (command)
        {
            case Left:
                _coordinate.Orientation = RotateToLeft(_coordinate.Orientation);
                break;
            case Right:
                _coordinate.Orientation = RotateToRight(_coordinate.Orientation);
                break;
            case Forward:
                (_coordinate.X, _coordinate.Y) = MoveForward(_coordinate.X, _coordinate.Y, _coordinate.Orientation);
                break;
        }

        return _coordinate;
    }

    private Orientation RotateToLeft(Orientation currentOrientation)
    {
        return currentOrientation switch
        {
            Orientation.Left => Orientation.Down,
            Orientation.Right => Orientation.Up,
            Orientation.Up => Orientation.Left,
            Orientation.Down => Orientation.Right,
            _ => currentOrientation
        };
    }

    private Orientation RotateToRight(Orientation currentOrientation)
    {
        return currentOrientation switch
        {
            Orientation.Left => Orientation.Up,
            Orientation.Right => Orientation.Down,
            Orientation.Up => Orientation.Right,
            Orientation.Down => Orientation.Left,
            _ => currentOrientation
        };
    }

    private (int x, int y) MoveForward(int currentX, int currentY, Orientation currentOrientation)
    {
        switch (currentOrientation)
        {
            case Orientation.Left:
                return (currentX - 1, currentY);
            case Orientation.Right:
                return (currentX + 1, currentY);
            case Orientation.Up:
                return (currentX, currentY + 1);
            case Orientation.Down:
                return (currentX, currentY - 1);
            default:
                return (currentX, currentY);
        }
    }
}
