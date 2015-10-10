using System;

namespace CleanicalRobot.Robots
{
    public sealed class RobotEngine : IRobotEngine
    {
        private Position currentAbsolutePosition;

        public RobotEngine(Position startingPosition)
        {
            if (startingPosition == null)
            {
                startingPosition = Position.AtX(0).AtY(0);
            }

            currentAbsolutePosition = startingPosition;
        }

        public Position CurrentAbsolutePosition
        {
            get
            {
                return currentAbsolutePosition;
            }
        }

        /// <summary>
        /// Dummy robot that always cleans
        /// </summary>
        /// <returns>true</returns>
        public bool CleanAtCurrentPosition()
        {
            return true;
        }

        public bool MoveDelta(int x, int y)
        {
            currentAbsolutePosition = CurrentAbsolutePosition.MoveDelta(x, y);
            return true;
        }

        public override string ToString()
        {
            return string.Format("robot @{0}", CurrentAbsolutePosition);
        }
    }
}
