using System;
using System.Security.Cryptography;

namespace CrypDominion
{
    internal static class RandomFactory
    {
        public static RNGCryptoServiceProvider GetRngCryptoServiceProvider => new RNGCryptoServiceProvider();

        public static Random GetNewRandom()
        {
            return new Random(GetEncryptedSeed());
        }

        public static int GetEncryptedSeed()
        {
            var rng = GetRngCryptoServiceProvider;
            var randomBytes = new byte[4]; //I think 4 is arbitrary; found online.
            rng.GetBytes(randomBytes);
            return BitConverter.ToInt32(randomBytes, startIndex: 0);
        }
    }
}
