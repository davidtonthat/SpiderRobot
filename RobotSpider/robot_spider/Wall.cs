namespace RobotSpider.robot_spider;

public class Wall
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    public Wall(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public bool IsLocationWithinBoundary(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }
}
