using KoreanText;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KoreanTest.Tests
{
    [TestClass]
    public class KoreanStringMatch_Tests
    {
        [TestMethod]
        public void KoreanChar_MatchCompareOption_Depth1_Tests()
        {
            var match = new KoreanStringMatch(KoreanStringMatchCompareOption.Depth1);

            Assert.IsTrue(match.Equals('��', '��'));
            Assert.IsTrue(match.Equals('��', '��'));
            Assert.IsTrue(match.Equals('��', '��'));


            Assert.IsFalse(match.Equals('��', '��'));
            Assert.IsFalse(match.Equals('��', '��'));
            Assert.IsFalse(match.Equals('��', '��'));
        }

        [TestMethod]
        public void KoreanChar_MatchCompareOption_Depth1_and_2_Tests()
        {
            var match = new KoreanStringMatch(KoreanStringMatchCompareOption.Depth1And2);

            Assert.IsTrue(match.Equals('��', '��'));
            Assert.IsTrue(match.Equals('��', '��'));
            Assert.IsTrue(match.Equals('��', '��'));

            Assert.IsFalse(match.Equals('��', '��'));
            Assert.IsFalse(match.Equals('��', '��'));
            Assert.IsFalse(match.Equals('��', '��'));
        }


        [TestMethod]
        public void KoreanString_MatchCompareOption_Depth1_Test()
        {
            var match = new KoreanStringMatch(KoreanStringMatchCompareOption.Depth1);

            Assert.IsTrue(match.Equals("������", "������"));
            Assert.IsFalse(match.Equals("������", "������"));
        }


        [TestMethod]
        public void KoreanString_MatchCompareOption_Depth2_Test()
        {
            var match = new KoreanStringMatch(KoreanStringMatchCompareOption.Depth1 | KoreanStringMatchCompareOption.Depth2);

            Assert.IsTrue(match.Equals("������", "������"));
            Assert.IsTrue(match.Equals("������", "������"));
        }
    }
}