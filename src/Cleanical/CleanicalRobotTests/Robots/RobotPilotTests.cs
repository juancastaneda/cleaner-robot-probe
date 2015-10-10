namespace CleanicalRobot.Robots
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotPilotTests
    {
        [Test]
        public void Can_report_cleaned_west()
        {
            var sut = new Fixture().CreateSUT();

            sut.CleanWest(10);

            Assert.AreEqual(11, sut.CleanedStations);
        }

        [Test]
        public void Can_report_cleaned_east()
        {
            var sut = new Fixture().CreateSUT();

            sut.CleanEast(10);

            Assert.AreEqual(11, sut.CleanedStations);
        }

        [Test]
        public void Can_report_cleaned_north()
        {
            var sut = new Fixture().CreateSUT();

            sut.CleanNorth(10);

            Assert.AreEqual(11, sut.CleanedStations);
        }

        [Test]
        public void Can_report_cleaned_south()
        {
            var sut = new Fixture().CreateSUT();

            sut.CleanSouth(10);

            Assert.AreEqual(11, sut.CleanedStations);
        }

        [Test]
        public void Cannot_conitnue_clean_more_than_grid_limit_south()
        {
            var fixture = new Fixture();
            fixture.Engine = new EngineDouble(
                startPosition: Position.AtX(0).AtY(0),
                validPositionEvaluator: p => p.Y > -5);
            var sut = fixture.CreateSUT();

            sut.CleanSouth(10);

            Assert.AreEqual(5, sut.CleanedStations);
        }

        [Test]
        public void Cannot_conitnue_clean_more_than_grid_limit_north()
        {
            var fixture = new Fixture();
            fixture.Engine = new EngineDouble(
                startPosition: Position.AtX(0).AtY(0),
                validPositionEvaluator: p => p.Y < 5);
            var sut = fixture.CreateSUT();

            sut.CleanNorth(10);

            Assert.AreEqual(5, sut.CleanedStations);
        }

        [Test]
        public void Cannot_conitnue_clean_more_than_grid_limit_west()
        {
            var fixture = new Fixture();
            fixture.Engine = new EngineDouble(
                startPosition: Position.AtX(0).AtY(0),
                validPositionEvaluator: p => p.X > -5);
            var sut = fixture.CreateSUT();

            sut.CleanWest(10);

            Assert.AreEqual(5, sut.CleanedStations);
        }

        [Test]
        public void Cannot_conitnue_clean_more_than_grid_limit_east()
        {
            var fixture = new Fixture();
            fixture.Engine = new EngineDouble(
                startPosition: Position.AtX(0).AtY(0),
                validPositionEvaluator: p => p.X < 5);
            var sut = fixture.CreateSUT();

            sut.CleanEast(10);

            Assert.AreEqual(5, sut.CleanedStations);
        }

        [Test]
        public void Can_report_clean_if_robot_could_clean_east()
        {
            var fixture = new Fixture();
            fixture.Engine = new EngineDouble(
                startPosition: Position.AtX(0).AtY(0),
                validPositionEvaluator: p => true,
                cleaningAtPositionEvaluator: p => p.X < 5);
            var sut = fixture.CreateSUT();

            sut.CleanEast(10);

            Assert.AreEqual(5, sut.CleanedStations);
        }

        [Test]
        public void Can_report_clean_if_robot_could_clean_west()
        {
            var fixture = new Fixture();
            fixture.Engine = new EngineDouble(
                startPosition: Position.AtX(0).AtY(0),
                validPositionEvaluator: p => true,
                cleaningAtPositionEvaluator: p => p.X > -5);
            var sut = fixture.CreateSUT();

            sut.CleanWest(10);

            Assert.AreEqual(5, sut.CleanedStations);
        }

        [Test]
        public void Can_report_clean_if_robot_could_clean_north()
        {
            var fixture = new Fixture();
            fixture.Engine = new EngineDouble(
                startPosition: Position.AtX(0).AtY(0),
                validPositionEvaluator: p => true,
                cleaningAtPositionEvaluator: p => p.Y<5);
            var sut = fixture.CreateSUT();

            sut.CleanNorth(10);

            Assert.AreEqual(5, sut.CleanedStations);
        }

        [Test]
        public void Can_report_clean_if_robot_could_clean_south()
        {
            var fixture = new Fixture();
            fixture.Engine = new EngineDouble(
                startPosition: Position.AtX(0).AtY(0),
                validPositionEvaluator: p => true,
                cleaningAtPositionEvaluator: p => p.Y > -5);
            var sut = fixture.CreateSUT();

            sut.CleanSouth(10);

            Assert.AreEqual(5, sut.CleanedStations);
        }

        private sealed class Fixture
        {
            public EngineDouble Engine = new EngineDouble();

            public RobotPilot CreateSUT()
            {
                return new RobotPilot(Engine);
            }
        }

        private sealed class EngineDouble : IRobotEngine
        {
            private Position currentPosition;
            private readonly Func<Position, bool> validPositionEvaluator;
            private readonly Func<Position, bool> cleaningAtPositionEvaluator;

            public EngineDouble(
                Position startPosition,
                Func<Position, bool> validPositionEvaluator,
                Func<Position, bool> cleaningAtPositionEvaluator)
            {
                currentPosition = startPosition;
                this.validPositionEvaluator = validPositionEvaluator;
                this.cleaningAtPositionEvaluator = cleaningAtPositionEvaluator;
            }

            public EngineDouble(
                Position startPosition,
                Func<Position, bool> validPositionEvaluator)
                : this(startPosition, validPositionEvaluator, p => true)
            {
            }

            public EngineDouble() : this(Position.AtX(0).AtY(0), p => true, p => true)
            {
            }

            public Position CurrentAbsolutePosition
            {
                get
                {
                    return currentPosition;
                }
            }

            public bool MoveDelta(int x, int y)
            {
                var newPosition = currentPosition.MoveDelta(x, y);
                if (validPositionEvaluator(newPosition))
                {
                    currentPosition = newPosition;
                    return true;
                }

                return false;
            }

            public bool CleanAtCurrentPosition()
            {
                return cleaningAtPositionEvaluator(currentPosition);
            }
        }
    }
}