namespace CleanicalRobot.Robots
{
    /// <summary>
    /// Represents some one driving the robot
    /// </summary>
    public interface ICleanerPilot
    {
        void CleanEast(int steps);
        void CleanNorth(int steps);
        void CleanWest(int steps);
        void CleanSouth(int steps);
        ICleanerLog GetLog();
    }
}
