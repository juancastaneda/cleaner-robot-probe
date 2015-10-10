namespace CleanicalRobot.Given.Square_grid.Spanning_100000_positive_and_negavite
{
    using CleanicalRobot.Robots;

    public class CleaningRobotFixture
    {
        public Position StartPosition=Position.AtX(0).AtY(0);

        public ICleanerPilot CreateSUT()
        {
            return RobotFactory.CreateCleaningRobotAt(StartPosition);
        }
    }
}
