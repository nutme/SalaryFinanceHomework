using System;
using System.Security.Cryptography;

namespace SalaryFinanceHomework.StarSystemGenerator.Worker
{
    public class CryptoRandomnessProvider : RandomNumberGenerator, IRandomnessProvider
    {
        // Crypto RNG generator is significantly more better for randomness compared to standard .NET one
        // For true randomness however external source is needed. Like noise from Hubble Space Telescope
        // https://msdn.microsoft.com/en-us/library/system.security.cryptography.rngcryptoserviceprovider.aspx
        // https://stackoverflow.com/questions/1234094/how-can-i-generate-truly-not-pseudo-random-numbers-with-c

        private readonly RandomNumberGenerator rng = new RNGCryptoServiceProvider();

        public bool GetRandomBool()
        {
            var random = GetRandomInt(int.MinValue, int.MaxValue);
            return random < 0;
        }

        public int GetRandomInt(int upperLimmit)
        {
            return GetRandomInt(0, upperLimmit);
        }

        public int GetRandomInt(int lowerLimit, int upperLimmit)
        {
            if (lowerLimit > upperLimmit)
            {
                throw new ArgumentOutOfRangeException();
            }

            var data = new byte[sizeof(uint)];
            rng.GetBytes(data);
            var randUint = BitConverter.ToUInt32(data, 0);
            var random = randUint / (uint.MaxValue + 1.0);

            return (int)Math.Floor((lowerLimit + ((double)upperLimmit - lowerLimit) * random));
        }

        public override void GetBytes(byte[] data)
        {
            rng.GetBytes(data);
        }

        public override void GetNonZeroBytes(byte[] data)
        {
            rng.GetNonZeroBytes(data);
        }
    }
}
