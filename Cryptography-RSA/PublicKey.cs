using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Cryptography_RSA
{
    public class PublicKey
    {
        public BigInteger N { get; set; }
        public BigInteger E { get; set; }

        public PublicKey(BigInteger N, BigInteger E)
        {
            this.N = N;
            this.E = E;
        }
    }
}
