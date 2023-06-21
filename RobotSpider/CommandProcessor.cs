using RobotSpider.robot_spider;

namespace RobotSpider;

public class CommandProcessor : ICommandProcessor
{
    private const char Separator = ' ';

    public Wall GetWallSize()
    {
        int width = 0, height = 0;
        do
        {
            Console.WriteLine("Enter width and height of the wall - e.g. 7 15");
            var inputText = Console.ReadLine();

            if (inputText != null)
            {
                var values = inputText.Split(Separator);
                if (values.Length == 2)
                {
                    var result1 = int.TryParse(values[0], out width);
                    var result2 = int.TryParse(values[1], out height);
                }
            }
        } while (width == 0 || height == 0);

        return new Wall(width, height);
    }

    public Coordinate GetInitialCoordinate(Wall wall)
    {
        int x = 0, y = 0;
        Orientation orientation = Orientation.NotSet;

        do
        {
            Console.WriteLine("Enter spider's initial location and orientation - e.g. 4 10 Left");
            var inputText = Console.ReadLine();

            if (inputText != null)
            {
                var values = inputText.Split(Separator);
                if (values.Length == 3)
                {
                    var result1 = int.TryParse(values[0], out x);
                    var result2 = int.TryParse(values[1], out y);
                    if (!wall.IsLocationWithinBoundary(x, y))
                    {
                        Console.WriteLine("Error: Initial coordinate not within wall boundary {0}x{1}", wall.Width, wall.Height);
                        continue;
                    }
                    orientation = ConvertToOrientation(values[2]);
                }
            }
        } while (orientation == Orientation.NotSet);

        return new Coordinate(x, y, orientation);
    }

    public List<char> GetCommandSequence()
    {
        List<char> commands = new List<char>();

        do
        {
            Console.WriteLine("Enter sequence of commands to move the spider - e.g. FLFLFRFFLF");
            var inputText = Console.ReadLine();

            if (inputText != null)
            {
                var list = new List<char>(inputText.ToCharArray());
                if (!list.TrueForAll(c => c is Navigator.Left or Navigator.Right or Navigator.Forward))
                {
                    Console.WriteLine("Error: command sequence must comprise L, R, F");
                    continue;
                }
                commands = list;
            }
        } while (commands.Count == 0);

        return commands;
    }

    private Orientation ConvertToOrientation(string value)
    {
        return value.ToLower() switch
        {
            "left" => Orientation.Left,
            "right" => Orientation.Right,
            "up" => Orientation.Up,
            "down" => Orientation.Down,
            _ => Orientation.NotSet
        };
    }
}
