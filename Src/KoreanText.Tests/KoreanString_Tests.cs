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
                new KoreanChar('��'),
                new KoreanChar('��')
            };
            var str = new KoreanString(chars);
            Console.WriteLine(str);

            Assert.AreEqual(str.ToString(), "����");
        }

        [TestMethod]
        public void KoreanString_Implicit_Test()
        {
            KoreanString str = "������";
            Console.Write(str);

            Assert.AreEqual(str.ToString(), "������");
        }
    }
}