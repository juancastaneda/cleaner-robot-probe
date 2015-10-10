using System;

namespace CleanicalRobot.Robots
{
    public class GridRestrictedRobotEngine : IRobotEngine
    {
        private readonly IRobotEngine engine;
        private readonly ICleaningGrid grid;

        public GridRestrictedRobotEngine(IRobotEngine engine, ICleaningGrid grid)
        {
            this.engine = engine;
            this.grid = grid;
        }
        public Position CurrentAbsolutePosition
        {
            get
            {
                return engine.CurrentAbsolutePosition;
            }
        }

        public bool CleanAtCurrentPosition()
        {
            return engine.CleanAtCurrentPosition();
        }

        public bool MoveDelta(int x, int y)
        {
            var currentPosition = engine.CurrentAbsolutePosition;
            var newPosition = currentPosition.MoveDelta(x, y);
            if (!grid.isPostionOnGrid(newPosition))
            {
                return false;
            }

            return engine.MoveDelta(x, y);
        }
    }
}
