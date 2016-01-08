using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_RSA
{
    public class PrivateKey
    {
        public BigInteger D { get; set; }

        public PrivateKey(BigInteger D)
        {
            this.D = D;
        }
    }
}
