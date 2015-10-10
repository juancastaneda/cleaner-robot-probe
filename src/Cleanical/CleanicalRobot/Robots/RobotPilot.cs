using System;

namespace CleanicalRobot.Robots
{
    /// <summary>
    /// A robot that cleans at each position where it is position and moved
    /// </summary>
    public sealed class RobotPilot : ICleanerPilot, ICleanerLog
    {
        private readonly IRobotEngine robot;
        private int timesRobotHasCleaned;

        public RobotPilot(IRobotEngine robot)
        {
            this.robot = robot;
            CleanAtPosition();
        }

        public int CleanedStations
        {
            get
            {
                return timesRobotHasCleaned;
            }
        }

        public void CleanEast(int steps)
        {
            NumberOfValidStepsOnDirection(steps, Direction.East);
        }

        public void CleanNorth(int steps)
        {
            NumberOfValidStepsOnDirection(steps, Direction.North);
        }

        public ICleanerLog GetLog()
        {
            return this;
        }

        public void CleanWest(int steps)
        {
            NumberOfValidStepsOnDirection(steps, Direction.West);
        }

        public void CleanSouth(int steps)
        {
            NumberOfValidStepsOnDirection(steps, Direction.South);
        }

        private void NumberOfValidStepsOnDirection(int steps, Direction direction)
        {
            for (int i = 0; i < steps; i++)
            {
                MoveRobotOneStepOn(direction);
            }
        }

        private void MoveRobotOneStepOn(Direction direction)
        {
            var x = 0;
            var y = 0;
            switch (direction)
            {
                case Direction.South:
                    y = -1;
                    break;
                case Direction.North:
                    y = 1;
                    break;
                case Direction.East:
                    x = 1;
                    break;
                case Direction.West:
                    x = -1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }

            if( robot.MoveDelta(x, y))
            {
                CleanAtPosition();
            }
        }

        private void CleanAtPosition()
        {
            if (robot.CleanAtCurrentPosition())
            {
                timesRobotHasCleaned++;
            }
        }

        private enum Direction { South, North, East, West }
    }
}
