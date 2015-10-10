namespace CleanicalRobot.Robots
{
    public sealed class RectangularGrid : ICleaningGrid
    {
        private readonly int xMin;
        private readonly int xMax;
        private readonly int yMin;

        private readonly int yMax;

        private RectangularGrid(int xMin, int xMax, int yMin, int yMax)
        {
            this.xMin = xMin;
            this.yMin = yMin;
            this.xMax = xMax;
            this.yMax = yMax;
        }

        internal static Builder MinX(int value)
        {
            return new Builder(value);
        }
        public bool isPostionOnGrid(Position position)
        {
            var isNotInXInterval = position.X < xMin || position.X > xMax;
            var isNotInYInterval = position.Y < yMin || position.Y > yMax;
            if (isNotInXInterval || isNotInYInterval)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return string.Format("[MinX:{0}] [MaxX:{1}] [MinY:{2}] [MaxY:{3}]",xMin,xMax,yMin,yMax);
        }

        public class Builder
        {
            private readonly int xMin;
            private int xMax;
            private int yMin;

            public Builder(int xMin)
            {
                this.xMin = xMin;
            }

            public Builder MaxX(int value)
            {
                xMax = value;
                return this;
            }

            public Builder MinY(int value)
            {
                yMin = value;
                return this;
            }

            public RectangularGrid MaxY(int value)
            {
                return new RectangularGrid(xMin, xMax, yMin, value);
            }
        }
    }
}
