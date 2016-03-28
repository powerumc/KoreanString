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
    public class KoreanChar_Tests
    {
        [TestMethod]
        public void KoreanChar_Print()
        {
            KoreanChar char1 = '엄';

            Console.WriteLine(char1.GetChoSung());
            Console.WriteLine(char1.GetJoongSung());
            Console.WriteLine(char1.GetJongSung());
        }

        [TestMethod()]
        public void KoreanChar_Test()
        {
            var char1 = new KoreanChar('엄');
            var char2 = new KoreanChar('엄');

            Assert.AreEqual(char1, char2);
        }
        [TestMethod()]
        public void getChar_Test()
        {
            KoreanChar char1 = '엄';
            
            Assert.AreEqual(char1.GetChar(), '엄');
        }

        [TestMethod()]
        public void getBytes_Test()
        {
            KoreanChar char1 = '엄';

            Console.WriteLine(char1.GetBytes()[0]);
        }

        [TestMethod()]
        public void getChoSung_Test()
        {
            KoreanChar char1 = '엄';

            Assert.AreEqual(char1.GetChoSung(), 'ㅇ');
        }

        [TestMethod()]
        public void getJoongSung_Test()
        {
            KoreanChar char1 = '엄';

            Assert.AreEqual(char1.GetJoongSung(), 'ㅓ');
        }

        [TestMethod()]
        public void getJongSung_Test()
        {
            KoreanChar char1 = '엄';

            Assert.AreEqual(char1.GetJongSung(), 'ㅁ');
        }
        
        [TestMethod()]
        public void ToKoreanUniqueCode_Test()
        {
            KoreanChar char1 = '엄';

            Console.WriteLine(char1.ToKoreanUniqueCode());
        }
        
        [TestMethod()]
        public void equals_Test()
        {
            KoreanChar char1 = '엄';
            KoreanChar char2 = '엄';

            Assert.IsTrue(char1.Equals(char2));
        }

        [TestMethod]
        public void Contains_Tests()
        {
            KoreanChar char1 = '엄';

            Console.WriteLine(char1.Contains('ㅁ'));
        }
    }
}