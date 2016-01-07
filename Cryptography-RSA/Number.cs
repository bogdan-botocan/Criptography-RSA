using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_RSA
{
    public static class Number
    {
        // private fields
        private static Random _Random;

        /// <summary>
        /// Generates a large prime number
        /// </summary>
        /// <param name="Length"> Number of digits of number to generate </param>
        /// <returns> A BigInteger value with Length number of digits </returns>
        public static BigInteger GetPrimeNumber(int Length)
        {
            _Random = new Random();
            byte[] data = new byte[Length];
            _Random.NextBytes(data);

            return new BigInteger(data);
        }
    }
}
