using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_RSA
{
    public class RsaKey
    {
        public BigInteger Value { get; set; }
        public RsaKey(BigInteger Value)
        {
            this.Value = Value;
        }
    }
}
