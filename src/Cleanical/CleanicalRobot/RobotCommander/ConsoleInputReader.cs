namespace CleanicalRobot.RobotCommander
{
    using Robots;
    using System;
    using System.Collections.Generic;

    public class ConsoleInputReader
    {
        private int numberOfCommands;
        private Position startPosition;
        private string[] commands;

        public string[] Commands
        {
            get
            {
                return commands;
            }
        }

        public Position StartPosition
        {
            get
            {
                return startPosition;
            }
        }

        public ConsoleInputReader ReadNumberOfCommands()
        {
			Console.Write("Number of commands your are going to provide: ");
            var value = Console.ReadLine();
            if (!int.TryParse(value, out numberOfCommands))
            {
                throw new InvalidOperationException("number of commands should be value");
            }

            if (numberOfCommands < 0)
            {
                throw new InvalidOperationException("requires at least 0 commands");
            }

            return this;
        }

        public ConsoleInputReader ReadStartPosition()
        {
			Console.Write("Start position (X Y)");
            var value = Console.ReadLine();
            var xy = value.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (xy.Length < 2)
            {
                throw new InvalidOperationException("requires 2 values");
            }

            int x;
            int y;
            if (!int.TryParse(xy[0], out x))
            {
                throw new InvalidOperationException("first number x needs to be int");
            }

            if (!int.TryParse(xy[1], out y))
            {
                throw new InvalidOperationException("second number y needs to be int");
            }

            startPosition = Position.AtX(x).AtY(y);
            return this;
        }

        public ConsoleInputReader ReadCommands()
        {
			Console.WriteLine("Provide the commands one per line format: bearing steps. E.g. N 10. Bearings: N/S/W/E");
            var inputCommands = new List<string>();
            for (int i = 0; i < numberOfCommands; i++)
            {
                inputCommands.Add(Console.ReadLine());
            }

            commands = inputCommands.ToArray();
            return this;
        }
    }
}
