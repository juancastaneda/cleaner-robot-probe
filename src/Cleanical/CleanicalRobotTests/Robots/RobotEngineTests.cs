namespace CleanicalRobot.Robots
{
    using NUnit.Framework;

    [TestFixture]
    public class RobotEngineTests
    {
        [Test]
        public void Can_create_engine_without_start_position()
        {
            var fixture = new Fixture();
            fixture.startingPostion = null;

            var sut = fixture.CreateSUT();

            Assert.IsNotNull(sut.CurrentAbsolutePosition);
        }

        [TestCase(10, 20)]
        [TestCase(30, 40)]
        [TestCase(40, 50)]
        public void Can_create_engine_with_start_position_as_current_position(int x, int y)
        {
            var fixture = new Fixture();
            fixture.startingPostion = Position.AtX(x).AtY(y);

            var sut = fixture.CreateSUT();

            Assert.AreEqual(x, sut.CurrentAbsolutePosition.X, "Inspecting X");
            Assert.AreEqual(y, sut.CurrentAbsolutePosition.Y, "Inspecting Y");
        }

        [TestCase(10, 20, 40, 10, 50, 30)]
        [TestCase(30, 40, 10, 20, 40, 60)]
        [TestCase(40, 50, -40, -10, 0, 40)]
        public void Can_move_robot(int startX, int startY, int deltaX, int deltaY, int expectedX, int expectedY)
        {
            var fixture = new Fixture();
            fixture.startingPostion = Position.AtX(startX).AtY(startY);
            var sut = fixture.CreateSUT();

            sut.MoveDelta(deltaX, deltaY);

            Assert.AreEqual(expectedX, sut.CurrentAbsolutePosition.X, "Inspecting X");
            Assert.AreEqual(expectedY, sut.CurrentAbsolutePosition.Y, "Inspecting Y");
        }

        private sealed class Fixture
        {
            public Position startingPostion;

            public RobotEngine CreateSUT()
            {
                return new RobotEngine(startingPostion);
            }
        }
    }
}