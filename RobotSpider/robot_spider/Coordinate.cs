namespace RobotSpider.robot_spider;

public class Coordinate
{
    public int X { get; set; }
    public int Y { get; set; }
    public Orientation Orientation { get; set; }

    public Coordinate(int x, int y, Orientation orientation)
    {
        X = x;
        Y = y;
        Orientation = orientation;
    }

    public Coordinate(Coordinate other)
    {
        X = other.X;
        Y = other.Y;
        Orientation = other.Orientation;
    }
}
