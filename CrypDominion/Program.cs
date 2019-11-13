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
