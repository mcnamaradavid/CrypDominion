using System;
using System.Linq;

namespace CrypDominion
{
    internal class Program
    {
        private static short _expansionsPerGame;
        private static short _games;

        public static void Main(string[] args)
        {
            //
            // This program demonstrates all colors and backgrounds.
            //
            //Type type = typeof(ConsoleColor);
            //Console.ForegroundColor = ConsoleColor.Black;
            //foreach (var name in Enum.GetNames(type))
            //{
            //    Console.BackgroundColor = (ConsoleColor)Enum.Parse(type, name);
            //    Console.WriteLine(name);
            //}
            //Console.BackgroundColor = ConsoleColor.Black;
            //foreach (var name in Enum.GetNames(type))
            //{
            //    Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, name);
            //    Console.WriteLine(name);
            //}

            //Use cryptographically secure random number generator (CNG) to select multiple expansions for a games. Do this for as many games as desired.
            ParseParametersForAutoRun(args);
            var autoRun = new CryRanDominion(_games, _expansionsPerGame);
            autoRun.Start();
        }

        private static void ParseParametersForAutoRun(string[] args)
        {
            var parameter = args.FirstOrDefault(w => w.Contains("/expansions="));
            _expansionsPerGame = parameter != null
                ? Convert.ToInt16(parameter.Substring("/expansions=".Length))
                : Convert.ToInt16(3);

            parameter = args.FirstOrDefault(w => w.Contains("/games="));
            _games = parameter != null
                ? Convert.ToInt16(parameter.Substring("/games=".Length))
                : Convert.ToInt16(10);
        }
    }
}
