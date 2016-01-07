using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_RSA
{
    public static class MillerRabin
    {
        // private fields
        public static List<int> Primes { get; set; } = new List<int>()
        {
             2,      3,      5,      7,     11,     13,     17,     19,     23,     29,
            31,     37,     41,     43,     47,     53,     59,     61,     67,     71,
            73,     79,     83,     89,     97,    101,    103,    107,    109,    113,
           127,    131,    137,    139,    149,    151,    157,    163,    167,    173,
           179,    181,    191,    193,    197,    199,    211,    223,    227,    229,
           233,    239,    241,    251,    257,    263,    269,    271,    277,    281,
           283,    293,    307,    311,    313,    317,    331,    337,    347,    349,
           353,    359,    367,    373,    379,    383,    389,    397,    401,    409,
           419,    421,    431,    433,    439,    443,    449,    457,    461,    463,
           467,    479,    487,    491,    499,    503,    509,    521,    523,    541,
           547,    557,    563,    569,    571,    577,    587,    593,    599,    601,
           607,    613,    617,    619,    631,    641,    643,    647,    653,    659,
           661,    673,    677,    683,    691,    701,    709,    719,    727,    733,
           739,    743,    751,    757,    761,    769,    773,    787,    797,    809,
           811,    821,    823,    827,    829,    839,    853,    857,    859,    863,
           877,    881,    883,    887,    907,    911,    919,    929,    937,    941,
           947,    953,    967,    971,    977,    983,    991,    997,
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static bool IsPrime(BigInteger Number)
        {
            if(Number == 2)
            {
                return true;
            }

            // we are gonna write Number = 2^s * t + 1
            BigInteger T = Number - 1;
            int S = 0;
            while(T % 2 == 0)
            {
                T /= 2;
                S++;
            }

            // we are going to check b^t = 1 (mod n) or exists 0 <= j < s : b^(2^j*t) = -1 (mod n) for some bases (b E Z) iwht (b, n) = 1
            BigInteger biFirstCheck = BigInteger.ModPow(2, T, Number);
            if(biFirstCheck == 1)
            {
                return true;
            }

            bool bMatched = false;
            foreach (int prime in Primes.Where(x => x < Number))
            {
                for (int j = 0; j < S; j++)
                {
                    if (BigInteger.ModPow(prime, (int)(Math.Pow(2, j)) * T, Number) == Number - 1)
                    {
                        bMatched = true;
                        break;
                    }
                }

                if(!bMatched)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
