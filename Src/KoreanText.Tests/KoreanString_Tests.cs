using System;
using KoreanText;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KoreanTest.Tests
{
    [TestClass]
    public class KoreanString_Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var chars = new KoreanChar[]
            {
                new KoreanChar('决'),
                new KoreanChar('霖')
            };
            var str = new KoreanString(chars);
            Console.WriteLine(str);

            Assert.AreEqual(str.ToString(), "决霖");
        }

        [TestMethod]
        public void KoreanString_Implicit_Test()
        {
            KoreanString str = "决霖老";
            Console.Write(str);

            Assert.AreEqual(str.ToString(), "决霖老");
        }
    }
}