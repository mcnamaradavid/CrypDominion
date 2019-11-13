using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;

namespace CrypDominion
{
    internal class CryRanDominion
    {
        private readonly StringCollection _weightedExpansions;
        private readonly short _games;
        private readonly short _expansionsCount;

        public CryRanDominion(short games, short expansionsPerGame)
        {
            _games = games;
            _expansionsCount = expansionsPerGame;
            _weightedExpansions = CreateWeightedExpansionList();
        }

        private static readonly RNGCryptoServiceProvider Rng = RandomFactory.GetRngCryptoServiceProvider;

        private readonly Dictionary<string, int> _expansionKeyWeightVal = new Dictionary<string, int>
        {
            //{"Base", 3},
            {"Intrigue", 3},
            {"SeaSide", 3},
            {"Alchemy", 3},
            {"Prosperity", 3},
            {"Cornucopia", 3},
            {"Hinterlands", 3},
            {"New Base Cards", 3},
            {"Dark Ages", 3},
            {"Guilds", 3},
            {"Adventures", 3},
            {"Empires", 3},
            {"Nocturne", 3},
            {"Renaissance", 3}
        };

        private StringCollection CreateWeightedExpansionList()
        {
            var weightedExpansionList = new StringCollection();
            foreach (var keyVal in _expansionKeyWeightVal)
            { // Add each key to the list the number of times equal to its weight
                for (var i = 1; i <= keyVal.Value; i++)
                {
                    weightedExpansionList.Add(keyVal.Key);
                }
            }
            return weightedExpansionList;
        }

        public void Start()
        {
            WriteGames();

            Console.WriteLine("\n Done. Press enter to exit.");
            Console.Read();
        }

        private void WriteGames()
        {
            for (var i = 0; i < _games; i++)
            {
                var expansions = GetRandomDomionExpansions(_expansionsCount);
                DisplaySelection(expansions, i+1);
            }
        }

        private IEnumerable<string> GetRandomDomionExpansions(int desiredExpansionsCount)
        {
            var chosenExpansions = new List<string>();

            while (chosenExpansions.Count < desiredExpansionsCount)
            {
                var expansion = GetRandomItem(_weightedExpansions);
                if (!chosenExpansions.Contains(expansion))
                {
                    chosenExpansions.Add(expansion);
                }
            }

            return chosenExpansions;

            string GetRandomItem(StringCollection weightedList)
            {
                var num = Rng.GetRandomInRange(weightedList.Count);
                return weightedList[num];
            }
        }
        
        private static void DisplaySelection(IEnumerable<string> expansions, int optionNumber)
        {
            var defaultConsoleForeground = Console.ForegroundColor;
            Console.WriteLine($"Option {optionNumber}:");
            foreach (var expansion in expansions)
            {
                Thread.Sleep(33);
                Console.ForegroundColor = _colorLookup[expansion];
                Console.WriteLine($"\t {expansion}");
            }
            Thread.Sleep(111);
            Console.ForegroundColor = defaultConsoleForeground;
        }

        private static readonly Dictionary<string, ConsoleColor> _colorLookup = new Dictionary<string, ConsoleColor>
        {
            //{"Base", ConsoleColor.White},
            {"Intrigue", ConsoleColor.Gray},
            {"SeaSide", ConsoleColor.Blue},
            {"Alchemy", ConsoleColor.DarkMagenta},
            {"Prosperity", ConsoleColor.Green},
            {"Cornucopia", ConsoleColor.Yellow},
            {"Hinterlands", ConsoleColor.DarkGreen},
            {"New Base Cards", ConsoleColor.White},
            {"Dark Ages", ConsoleColor.DarkRed},
            {"Guilds", ConsoleColor.Yellow},
            {"Adventures", ConsoleColor.DarkGray},
            {"Empires", ConsoleColor.DarkYellow},
            {"Nocturne", ConsoleColor.DarkBlue},
            {"Renaissance", ConsoleColor.Cyan}
        };
    }
}
