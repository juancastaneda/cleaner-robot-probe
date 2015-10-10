namespace CleanicalRobot.RobotCommander
{
    using Robots;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Adapter from text commands to the robot
    /// </summary>
    public sealed class TextCommander
    {
        private readonly ICleanerPilot cleaner;
        private Dictionary<string, Action<int>> commandsByLetter;

        public TextCommander(ICleanerPilot cleaner)
        {
            this.cleaner = cleaner;
            commandsByLetter=new Dictionary<string, Action<int>>
            {
                { "S", steps=>cleaner.CleanSouth(steps) },
                { "N", steps=>cleaner.CleanNorth(steps) },
                { "E", steps=>cleaner.CleanEast(steps) },
                { "W", steps=>cleaner.CleanWest(steps) }
            };
        }

        public void Execute(string command)
        {
            var stepData = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (stepData.Length < 2)
            {
                throw new ArgumentException("Command requires 2 parts separated by space");
            }

            var direction = stepData[0];
            var parsedSteps = stepData[1];
            int steps;
            if (!int.TryParse(parsedSteps, out steps))
            {
                throw new ArgumentException("Cannot parse steps");
            }

            if (!commandsByLetter.ContainsKey(direction))
            {
                throw new ArgumentException("Unknown direction");
            }

            commandsByLetter[direction](steps);
        }
    }
}
