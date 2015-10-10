namespace CleanicalRobot.Robots
{
    public interface IRobotEngine
    {
        /// <summary>
        /// Moves the robot on X and Y if possible.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Whether the move can be executed or not</returns>
        bool MoveDelta(int x, int y);
        Position CurrentAbsolutePosition { get; }
        /// <summary>
        /// Executes the cleaning position where the robot is
        /// </summary>
        /// <returns>true if the cleaning was doned</returns>
        bool CleanAtCurrentPosition();
    }
}