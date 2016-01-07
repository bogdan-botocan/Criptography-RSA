using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_RSA
{
    public class InvalidTextException: ApplicationException
    {
        public InvalidTextException() : base()
        {

        }

        public InvalidTextException(string Message): base()
        {

        }
    }

    public static class Controller
    {
        public static BigInteger P { get; private set; }
        public static BigInteger Q { get; private set; }
        public static BigInteger N { get; private set; }
        public static BigInteger Phi { get; private set; }

        private static BigInteger E;// { private get; private set; }
        private static BigInteger D;

        private const int _Base = 27;

        private static RsaKey _KeyPair;

        private static string _Alphabet = " abcdefghijklmnopqrstuvwxyz";

        private static int _PlainTextBlocks;
        private static int _CypherTextBlocks;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
            _ValidateInputText(Text);
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            throw new NotImplementedException();
        }

        private static void _ValidateInputText(string Text)
        {
            foreach (var item in Text.ToLower())
            {
                if (!_Alphabet.Contains(item))
                {
                    throw new InvalidTextException("Unsupported character: " + item.ToString());
                }
            }
        }

        /// <summary>
        /// This should not return void
        /// </summary>
        public static RsaKey GenerateKeyPair(int K, int L)
        {
            // generate 2 random prime numbers
            P = Number.GetPrimeNumber((K + L) / 2);
            Q = Number.GetPrimeNumber((K + L) / 2);
            
            // compute n = pq
            N = BigInteger.Multiply(P, Q);

            // compute Phi(n) = (p - 1)(q - 1)
            Phi = BigInteger.Multiply(BigInteger.Subtract(P, BigInteger.One), 
                BigInteger.Subtract(Q, BigInteger.One));

            // randomly select 1 < e < Phi(n)
            //E = Number.GetPrimeNumber(1, Phi)

            // compute d = e ^ -1 mod phi
            D = BigInteger.ModPow(E, BigInteger.MinusOne, Phi);

            // public key = (n, e)
            PublicKey publicKey = new PublicKey(N, E);

            // private key = d
            PrivateKey privateKey = new PrivateKey(D);

            RsaKey key = new RsaKey(publicKey, privateKey);

            _KeyPair = key;

            return key;
        }
    }
}
