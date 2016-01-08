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

    public class KeyNotSetException: ApplicationException
    { 
        public KeyNotSetException() : base()
        {

        }

        public KeyNotSetException(string Message) : base()
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

        private static PublicKey _PublicKey;
        private static PrivateKey _PrivateKey;
        private static Boolean _PublicKeySet = false;
        private static Boolean _PrivateKeySet = false;

        private static string _Alphabet = " abcdefghijklmnopqrstuvwxyz";

        private static int _PlainTextCharsPerBlock;
        private static int _CipherCharactersPerBlock;

        public static void SetPublicKey(PublicKey Key, int CharsPerBlockInput, int CharsPerBlockOutput)
        {
            _PublicKey = Key;
            _PlainTextCharsPerBlock = CharsPerBlockInput;
            _CipherCharactersPerBlock = CharsPerBlockOutput;
            _PublicKeySet = true;
        }

        public static void SetPrivateKey(PrivateKey Key)
        {
            _PrivateKey = Key;
            _PrivateKeySet = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
            Text = Text.ToLower().Trim();

            if (!_PublicKeySet)
            {
                throw new KeyNotSetException("Please set public key before encrypting!");
            }

            _ValidateInputText(Text);

            List<string> blocks = _SplitTextInBlocks(Text, _PlainTextCharsPerBlock);
            List<BigInteger> bigIntBlocks = new List<BigInteger>();
            List<BigInteger> encryptedBlocks = new List<BigInteger>();

            /// TODO: merge the foreaches
            foreach (var item in blocks)
            {
                bigIntBlocks.Add(_PreprocessString(item));
            }

            foreach (var item in bigIntBlocks)
            {
                encryptedBlocks.Add(BigInteger.ModPow(item, _PublicKey.E, _PublicKey.N));
            }

            return _PostprocessEncryptedBlocks(encryptedBlocks);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            Text = Text.ToLower().Trim();

            if (!_PublicKeySet)
            {
                throw new KeyNotSetException("Please set private key before decrypting!");
            }

            _ValidateInputText(Text);

            List<string> blocks = _SplitTextInBlocks(Text, _CipherCharactersPerBlock);
            List<BigInteger> bigIntBlocks = new List<BigInteger>();
            List<BigInteger> decryptedBlocks = new List<BigInteger>();

            /// TODO: merge the foreaches
            foreach (var item in blocks)
            {
                bigIntBlocks.Add(_PreprocessString(item));
            }

            foreach (var item in bigIntBlocks)
            {
                decryptedBlocks.Add(BigInteger.ModPow(item, _PrivateKey.D, _PublicKey.N));
            }

            return _PostprocessDecryptedBlocks(decryptedBlocks);
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

        private static List<string> _SplitTextInBlocks(string Text, int CharsPerBlock)
        {
            List<string> blocks = new List<string>();

            // pad the text
            if (Text.Length % CharsPerBlock != 0)
            {
                int charsToAdd = CharsPerBlock - Text.Length % CharsPerBlock;

                for (int i = 0; i < charsToAdd; i++)
                {
                    Text += _Alphabet[0];
                }
            }

            for (int i = 0; i < Text.Length; i += CharsPerBlock)
            {
                blocks.Add(Text.Substring(i, CharsPerBlock));
            }

            return blocks;
        }

        private static BigInteger _PreprocessString(string Text)
        {
            Dictionary<char, BigInteger> textToBigInteger = new Dictionary<char, BigInteger>();

            for (int i = 0; i < _Alphabet.Length; i++)
            {
                textToBigInteger.Add(_Alphabet.ElementAt(i), i);
            }

            BigInteger nr = new BigInteger();

            /// TODO: check this
            for (int i = 0; i < Text.Length; i++)
            {
                nr += textToBigInteger[Text.ElementAt(i)] * BigInteger.Pow(_Alphabet.Length, Text.Length - i - 1);
            }

            Console.WriteLine(nr.ToString());

            return nr;
        }

        private static string _PostprocessEncryptedBlocks(List<BigInteger> Blocks)
        {
            Dictionary<int, char> bigIntegerToChar = new Dictionary<int, char>();
            
            for (int i = 0; i < _Alphabet.Length; i++)
            {
                bigIntegerToChar.Add(i, _Alphabet.ElementAt(i));
            }

            string text = string.Empty;
            foreach (BigInteger block in Blocks)
            {
                BigInteger tempBlock = block;
                for (int i = _CipherCharactersPerBlock - 1; i >= 0; i--)
                {
                    BigInteger pow = BigInteger.Pow(_Alphabet.Length, i);
                    int element = (int)(tempBlock / pow);
                    text += bigIntegerToChar[element];
                    tempBlock -= pow * element;
                }
            }

            return text;
        }

        private static string _PostprocessDecryptedBlocks(List<BigInteger> Blocks)
        {
            Dictionary<int, char> bigIntegerToChar = new Dictionary<int, char>();

            for (int i = 0; i < _Alphabet.Length; i++)
            {
                bigIntegerToChar.Add(i, _Alphabet.ElementAt(i));
            }

            string text = string.Empty;
            foreach (BigInteger block in Blocks)
            {
                BigInteger tempBlock = block;
                for (int i = _PlainTextCharsPerBlock - 1; i >= 0; i--)
                {
                    BigInteger pow = BigInteger.Pow(_Alphabet.Length, i);
                    int element = (int)(tempBlock / pow);
                    text += bigIntegerToChar[element];
                    tempBlock -= pow * element;
                }
            }

            return text;
        }

        /// <summary>
        /// This should not return void
        /// </summary>
        public static RsaKey GenerateKeyPair(int K, int L)
        {
            // generate 2 random prime numbers
            P = Number.GetPrimeNumberInInterval(K, L, _Alphabet.Length);
            Q = Number.GetPrimeNumberInInterval(K, L, _Alphabet.Length);

            // compute n = pq
            N = BigInteger.Multiply(P, Q);
            int ck = K;
            int cl = L;
            while (N <= BigInteger.Pow(_Alphabet.Length, K) ||
                N >= BigInteger.Pow(_Alphabet.Length, L))
            {
                // generate 2 random prime numbers
                if (N <= BigInteger.Pow(_Alphabet.Length, K))
                {
                    cl++;
                    ck++;
                }
                else
                {
                    ck--;
                    cl--;
                }
                P = Number.GetPrimeNumberInInterval(ck, cl, _Alphabet.Length);
                Q = Number.GetPrimeNumberInInterval(ck, cl, _Alphabet.Length);

                // compute n = pq
                N = BigInteger.Multiply(P, Q);
            }
                //{
                //    throw new ApplicationException("N nu e in interval ");
                //}

                // compute Phi(n) = (p - 1)(q - 1)
                Phi = BigInteger.Multiply(BigInteger.Subtract(P, BigInteger.One), 
                BigInteger.Subtract(Q, BigInteger.One));

            // randomly select 1 < e < Phi(n)
            E = Number.GetRandomNumberInIntervalGcdedWithNumberIsOne(BigInteger.One, Phi, N);

            // compute d = e ^ -1 mod phi
            //D = BigInteger.ModPow(E, Phi - 1, Phi);
            D = Number.ModInverse(E, Phi);

            // public key = (n, e)
            PublicKey publicKey = new PublicKey(N, E);

            // private key = d
            PrivateKey privateKey = new PrivateKey(D);

            RsaKey key = new RsaKey(publicKey, privateKey);

            _PrivateKeySet = _PublicKeySet = true;
            _PublicKey = publicKey;
            _PrivateKey = privateKey;
            _PlainTextCharsPerBlock = K;
            _CipherCharactersPerBlock = L;

            return key;
        }
    }
}
