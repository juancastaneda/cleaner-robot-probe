namespace CleanicalRobot.Given.Square_grid.Spanning_100000_positive_and_negavite
{
    using Robots;
    using NUnit.Framework;

    [TestFixture]
    public class When_robot_goes_2E_1N_from_x10_and_y20
    {
        [Test]
        public void Then_reports_4_cleaned()
        {
            var fixture = new CleaningRobotFixture();
            fixture.StartPosition = Position.AtX(10).AtY(20);
            var sut = fixture.CreateSUT();

            sut.CleanEast(2);
            sut.CleanNorth(1);

            Assert.AreEqual(4, sut.GetLog().CleanedStations);
        }
    }
}
