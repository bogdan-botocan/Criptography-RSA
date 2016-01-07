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
        public PublicKey Public { get; set; }
        public PrivateKey Private { get; set; }

        public RsaKey(PublicKey Public, PrivateKey Private)
        {
            this.Private = Private;
            this.Public = Public;
        }
    }
}
