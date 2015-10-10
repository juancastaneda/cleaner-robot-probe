namespace CleanicalRobot.RobotCommander
{
    using System;
    using Robots;
    using NUnit.Framework;

    [TestFixture]
    public class TextCommanderTests
    {
        [Test]
        public void Can_move_cleaner_south_with_command()
        {
            var fixture = new Fixture();
            var sut = fixture.CreateSUT();

            sut.Execute("S 10");

            Assert.AreEqual(10, fixture.cleaner.SouthSteps);
        }

        [Test]
        public void Can_move_cleaner_north_with_command()
        {
            var fixture = new Fixture();
            var sut = fixture.CreateSUT();

            sut.Execute("N 10");

            Assert.AreEqual(10, fixture.cleaner.NorthSteps);
        }

        [Test]
        public void Can_move_cleaner_West_with_command()
        {
            var fixture = new Fixture();
            var sut = fixture.CreateSUT();

            sut.Execute("W 10");

            Assert.AreEqual(10, fixture.cleaner.WestSteps);
        }

        [Test]
        public void Can_move_cleaner_east_with_command()
        {
            var fixture = new Fixture();
            var sut = fixture.CreateSUT();

            sut.Execute("E 10");

            Assert.AreEqual(10, fixture.cleaner.EastSteps);
        }

        private class Fixture
        {
            public CleanerSpy cleaner = new CleanerSpy();

            public TextCommander CreateSUT()
            {
                return new TextCommander(cleaner);
            }
        }

        private class CleanerSpy : ICleanerPilot
        {
            public int EastSteps;
            public int WestSteps;
            public int NorthSteps;
            public int SouthSteps;

            public void CleanEast(int steps)
            {
                EastSteps = steps;
            }

            public void CleanNorth(int steps)
            {
                NorthSteps = steps;
            }

            public void CleanSouth(int steps)
            {
                SouthSteps = steps;
            }

            public void CleanWest(int steps)
            {
                WestSteps = steps;
            }

            public ICleanerLog GetLog()
            {
                throw new NotImplementedException();
            }
        }
    }
}