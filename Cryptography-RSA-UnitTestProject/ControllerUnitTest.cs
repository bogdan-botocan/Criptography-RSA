﻿using Cryptography_RSA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_RSA_UnitTestProject
{
    [TestClass]
    public class ControllerUnitTest
    {
        [TestMethod]
        public void EncryptTestMethod()
        {
            ///Controller.GenerateKeyPair(5, 8);
            Controller.SetPublicKey(new PublicKey(new System.Numerics.BigInteger(1643),
                new System.Numerics.BigInteger(67)), 2, 3);
            Assert.AreEqual("ayx rlagabar", Controller.Encrypt("algebra"));
        }
    }
}
