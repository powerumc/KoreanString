using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoreanText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoreanText.Tests
{
    [TestClass()]
    public class KoreanString_Tests
    {
        [TestMethod()]
        public void KoreanString_Test()
        {
            var ks = new KoreanString("엄준일");

            Console.WriteLine(ks.ToString());
        }

        [TestMethod()]
        public void KoreanString_Test1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetHashCode_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Equals_Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToString_Test()
        {
            Assert.Fail();
        }
    }
}