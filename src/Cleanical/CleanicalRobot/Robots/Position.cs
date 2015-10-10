namespace CleanicalRobot.Robots
{
    public class Position
    {
        private readonly int x;
        private readonly int y;

        private Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
        }

        public static Builder AtX(int value)
        {
            return new Builder(value);
        }

        public Position MoveDelta(int x, int y)
        {
            return Position.AtX(this.x + x).AtY(this.y + y);
        }

        public override string ToString()
        {
            return string.Format("[X: {0}], [Y: {1}]", X, Y);
        }

        public class Builder
        {
            private int x;

            public Builder(int x)
            {
                this.x = x;
            }

            public Position AtY(int y)
            {
                return new Position(x, y);
            }
        }
    }
}
