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
        private static Random random;

        /// <summary>
        /// Generates a large prime number
        /// </summary>
        /// <param name="Length"> Number of digits of number to generate </param>
        /// <returns> A BigInteger value with Length number of digits </returns>
        public static BigInteger GetPrimeNumber(int Length)
        {
            random = new Random();
            byte[] data = new byte[Length];
            random.NextBytes(data);

            return new BigInteger(data);
        }
    }
}
