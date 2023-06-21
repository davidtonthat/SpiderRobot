using RobotSpider;
using RobotSpider.robot_spider;

ICommandProcessor commandProcessor = new CommandProcessor();

Wall wall = commandProcessor.GetWallSize();

Coordinate coordinate = commandProcessor.GetInitialCoordinate(wall);

SpiderOnWall spider = new SpiderOnWall(coordinate, wall);

var commands = commandProcessor.GetCommandSequence();

Coordinate finalCoordinate = spider.MoveOnCommandSequence(commands);

Console.WriteLine();
Console.WriteLine("Final coordinate: {0} {1} {2}", finalCoordinate.X, finalCoordinate.Y, finalCoordinate.Orientation.ToString());
