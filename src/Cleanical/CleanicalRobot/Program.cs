namespace CleanicalRobot
{
    using System;
    using RobotCommander;
    using Robots;

    class Program
    {
        static void Main(string[] args)
        {
            var consoleReader = new ConsoleInputReader()
                .ReadNumberOfCommands()
                .ReadStartPosition()
                .ReadCommands();
            var robot = RobotFactory.CreateCleaningRobotAt(consoleReader.StartPosition);
            var textCommander = new TextCommander(robot);
            foreach (var command in consoleReader.Commands)
            {
                textCommander.Execute(command);
            }

            Console.WriteLine("=> Cleaned: " + robot.GetLog().CleanedStations);
        }
    }
}
