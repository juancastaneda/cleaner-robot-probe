﻿namespace CleanicalRobot.Given.Square_grid.Spanning_100000_positive_and_negavite
{
    using Robots;
    using NUnit.Framework;

    [TestFixture]
    public class When_robot_is_at_99999_north
    {
        [Test]
        public void Then_cannot_continue_cleaning_outside_the_grid()
        {
            var fixture = new CleaningRobotFixture();
            fixture.StartPosition = Position.AtX(20).AtY(99999);
            var sut = fixture.CreateSUT();

            sut.CleanNorth(10);

            Assert.AreEqual(2, sut.GetLog().CleanedStations);
        }
    }
}
