namespace CleanicalRobot.Robots
{
    public static class RobotFactory
    {
        public static ICleanerPilot CreateCleaningRobotAt(Position startingPosition)
        {
            var grid = RectangularGrid.MinX(-100000).MaxX(100000).MinY(-100000).MaxY(100000);
            var robot = new RobotEngine(startingPosition);
            var restrictedRobot = new GridRestrictedRobotEngine(robot, grid);
            return new RobotPilot(restrictedRobot);
        }
    }
}
