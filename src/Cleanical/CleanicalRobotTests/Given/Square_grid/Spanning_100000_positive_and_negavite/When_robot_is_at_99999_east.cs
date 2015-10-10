namespace CleanicalRobot.Given.Square_grid.Spanning_100000_positive_and_negavite
{
    using Robots;
    using NUnit.Framework;

    [TestFixture]
    public class When_robot_is_at_99999_east
    {
        [Test]
        public void Then_cannot_continue_cleaning_outside_the_grid()
        {
            var fixture = new CleaningRobotFixture();
            fixture.StartPosition = Position.AtX(99999).AtY(30);
            var sut = fixture.CreateSUT();

            sut.CleanEast(10);

            Assert.AreEqual(2, sut.GetLog().CleanedStations);
        }
    }
}
