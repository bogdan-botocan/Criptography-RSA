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
        private static Random _Random = new Random();

        /// <summary>
        /// Generates a large prime number
        /// </summary>
        /// <param name="Length"> Number of digits of number to generate </param>
        /// <returns> A BigInteger value with Length number of digits </returns>
        public static BigInteger GetPrimeNumber(int Length)
        {
            byte[] data;
            do
            {
                data = new byte[Length];
                data[0] = 0;
                _Random.NextBytes(data);
            } while (MillerRabin.IsPrime(new BigInteger(data)));

            return new BigInteger(data);
        }

        public static BigInteger
            GetRandomNumberInIntervalGcdedWithNumberIsOne(
            BigInteger MinValue,
            BigInteger MaxValue,
            BigInteger GcdToBeOne)
        {
            for (BigInteger wildNumber = MinValue; wildNumber < MaxValue; wildNumber++)
            {
                if(BigInteger.GreatestCommonDivisor(wildNumber, GcdToBeOne) == 1)
                {
                    return wildNumber;
                }
            }

            throw new Exception("Esti retardat!");
        }
    }
}
