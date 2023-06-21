using RobotSpider.robot_spider;

namespace RobotSpider;

public interface ICommandProcessor
{
    public Wall GetWallSize();
    public Coordinate GetInitialCoordinate(Wall wall);
    public List<char> GetCommandSequence();
}
