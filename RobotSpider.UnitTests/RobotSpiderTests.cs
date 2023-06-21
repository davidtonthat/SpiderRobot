using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotSpider.robot_spider;

namespace RobotSpider.UnitTests;

[TestClass]
public class RobotSpiderTests
{
    private SpiderOnWall? _systemUnderTest;

    [TestInitialize]
    public void Setup()
    {
        Wall wall = new Wall(7, 15);
        Coordinate coordinate = new Coordinate(4, 10, Orientation.Left);
        _systemUnderTest = new SpiderOnWall(coordinate, wall);
    }

    [TestMethod]
    public void GivenValidParameters_WhenReceivingCommand_FinalCoordinateAsExpected()
    {
        // Arrange
        Coordinate expected = new Coordinate(3, 10, Orientation.Left);

        // Act
        var actual = _systemUnderTest?.MoveOnCommand('F');

        // Assert
        Assert.AreEqual(expected.X, actual!.X);
        Assert.AreEqual(expected.Y, actual!.Y);
        Assert.AreEqual(expected.Orientation, actual!.Orientation);
    }

    [TestMethod]
    public void GivenValidParameters_WhenReceivingSequenceOfCommands_FinalCoordinateAsExpected()
    {
        // Arrange
        Coordinate expected = new Coordinate(5, 7, Orientation.Right);

        // Act
        var final = _systemUnderTest?.MoveOnCommandSequence(new List<char>("FLFLFRFFLF"));

        // Assert
        Assert.AreEqual(expected.X, final!.X);
        Assert.AreEqual(expected.Y, final!.Y);
        Assert.AreEqual(expected.Orientation, final!.Orientation);
    }
}
