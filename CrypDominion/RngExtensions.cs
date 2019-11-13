using System;
using System.Linq;
using System.Security.Cryptography;

namespace CrypDominion
{
    internal static class RngExtensions
    {
        public static int GetRandomInRange(this RNGCryptoServiceProvider rng, int range)
        {
            var groupsPerByte = (decimal)256/range;
            while (true)
            {
                var randomByte = rng.GetRandomByte();
                var toScale = randomByte / groupsPerByte;
                var toDiscrete = Math.Floor(toScale);
                if (toDiscrete == range) continue;
                return Convert.ToByte(toDiscrete);
            }
        }

        private static byte GetRandomByte(this RNGCryptoServiceProvider rng)
        {
            var randomByte = new byte[1];
            rng.GetBytes(randomByte);
            return randomByte.First();
        }
    }
}
