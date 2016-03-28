using System;
using KoreanText;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KoreanTest.Tests
{
    [TestClass]
    public class KoreanChar_Tests
    {
        private const char testchar1 = '��';

        [TestMethod]
        public void KoreanChar_Test1()
        {
            var c = new KoreanChar(testchar1);
            Console.WriteLine(c.CharK);
            
            
            Assert.AreEqual(c.CharK, testchar1);
        }

        [TestMethod]
        public void KoreanChar_Test2()
        {
            var c = new KoreanChar("AC00");
            Console.WriteLine(c);

            Assert.AreEqual(c.CharK, '��');
        }

        [TestMethod]
        public void KoreanChar_Implicit_Test3()
        {
            KoreanChar c = '��';
            Assert.AreEqual(c.CharK, testchar1);
        }

        [TestMethod]
        public void KoreanChar_Implict_By_Hex()
        {
            KoreanChar c = 0xAC00;
            Console.WriteLine(c);

            Assert.AreEqual(c.CharK, '��');
        }


        [TestMethod]
        public void KoreanChar_KChar_Equals_Test()
        {
            Console.WriteLine(new KoreanChar('��').ToBytes()[0]);
            Console.WriteLine(new KoreanChar('��').ToBytes()[0]);

            Assert.AreEqual(new KoreanChar('��').ToBytes()[0], (byte)49);
        }
    }
}