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

            Assert.IsTrue(match.Equals('决', 'し'));
            Assert.IsTrue(match.Equals('霖', 'じ'));
            Assert.IsTrue(match.Equals('老', 'し'));


            Assert.IsFalse(match.Equals('决', 'げ'));
            Assert.IsFalse(match.Equals('霖', 'げ'));
            Assert.IsFalse(match.Equals('老', 'げ'));
        }

        [TestMethod]
        public void KoreanChar_MatchCompareOption_Depth1_and_2_Tests()
        {
            var match = new KoreanStringMatch(KoreanStringMatchCompareOption.Depth1And2);

            Assert.IsTrue(match.Equals('决', '绢'));
            Assert.IsTrue(match.Equals('霖', '林'));
            Assert.IsTrue(match.Equals('老', '捞'));

            Assert.IsFalse(match.Equals('决', '捞'));
            Assert.IsFalse(match.Equals('霖', '瘤'));
            Assert.IsFalse(match.Equals('老', '快'));
        }


        [TestMethod]
        public void KoreanString_MatchCompareOption_Depth1_Test()
        {
            var match = new KoreanStringMatch(KoreanStringMatchCompareOption.Depth1);

            Assert.IsTrue(match.Equals("决霖老", "しじし"));
            Assert.IsFalse(match.Equals("决霖老", "しじげ"));
        }


        [TestMethod]
        public void KoreanString_MatchCompareOption_Depth2_Test()
        {
            var match = new KoreanStringMatch(KoreanStringMatchCompareOption.Depth1 | KoreanStringMatchCompareOption.Depth2);

            Assert.IsTrue(match.Equals("决霖老", "绢林捞"));
            Assert.IsTrue(match.Equals("决霖老", "しじし"));
        }
    }
}