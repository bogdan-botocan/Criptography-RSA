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
        public static BigInteger GetPrimeNumberInInterval(int K, int L, int AlphabetSize)
        {
            int twentySevenToK = BigInteger.Pow(AlphabetSize, K).ToByteArray().Length;
            int twentySevenToL = BigInteger.Pow(AlphabetSize, L).ToByteArray().Length;

            byte[] data;
            do
            {
                data = new byte[_Random.Next(L - K) + L];
                _Random.NextBytes(data);
            } while (!MillerRabin.IsPrime(new BigInteger(data)));
            
            return new BigInteger(data);
        }

        public static BigInteger
            GetRandomNumberInIntervalGcdedWithNumberIsOne(
            BigInteger MinValue,
            BigInteger MaxValue,
            BigInteger GcdToBeOne)
        {
            for (BigInteger wildNumber = MinValue + 1; wildNumber < MaxValue; wildNumber++)
            {
                if(BigInteger.GreatestCommonDivisor(wildNumber, GcdToBeOne) == 1)
                {
                    return wildNumber;
                }
            }

            throw new Exception("Esti retardat!");
        }

        public static BigInteger ModInverse(BigInteger a, BigInteger n)
        {
            BigInteger i = n, v = 0, d = 1;
            while (a > 0)
            {
                BigInteger t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }
    }
}
