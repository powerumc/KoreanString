using KoreanText;

namespace KoreanTest.Tests
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class KoreanStringTable_Tests
    {
		[TestMethod]
		public void Korean_Depth1_Index_Test()
		{
			KoreanStringTable.초성.ForEach(o => Console.WriteLine("{0} - {1}", o, KoreanStringTable.GetIndexDepth1(o)));

			Assert.AreEqual(0, KoreanStringTable.GetIndexDepth1('ㄱ'));
			Assert.AreEqual(18, KoreanStringTable.GetIndexDepth1('ㅎ'));
		}

		[TestMethod]
		public void Korean_Depth1_Index_Excloude_Test()
		{
			KoreanStringTable.초성.ForEach(o => Console.WriteLine("{0} - {1}", o, KoreanStringTable.GetIndexDepth1(o)));

			Assert.AreEqual(-1, KoreanStringTable.GetIndexDepth1('ㄳ'));
		}



		[TestMethod]
		public void Korean_Depth2_Index_Test()
		{
			KoreanChar c = 'ㅏ';

			for (int i = KoreanStringTable.ㅏ.ToLong(); i <= KoreanStringTable.ㅣ.ToLong(); i++)
			{
				KoreanChar chartest = i;
				Console.WriteLine("{0} - {1}", chartest.CharK, KoreanStringTable.GetIndexDepth2(i));
			}

			var index = KoreanStringTable.GetIndexDepth2(c);
			Assert.AreEqual(0, index);
		}

		[TestMethod]
		public void Korean_Depth3_Index_Test()
		{
			KoreanChar c = 'ㄱ';

			for (int i = KoreanStringTable.ㄱ.ToLong(); i <= KoreanStringTable.ㅎ.ToLong(); i++)
			{
				KoreanChar chartest = i;
				Console.WriteLine("{0} - {1}", chartest.CharK, KoreanStringTable.GetIndexDepth3(i));
			}

			var index = KoreanStringTable.GetIndexDepth3(c);
			Assert.AreEqual(0, index);
		}



		[TestMethod]
		public void Korean_Depth2_and_3_Analysis_Test()
		{
			KoreanStringTable.종성.ForEach(o => Console.WriteLine("{0} - {1}", o, KoreanStringTable.GetIndexDepth3(o)));


			KoreanChar c = '엄';
			Console.WriteLine(c.CharDepth1);
			Console.WriteLine(c.CharDepth2);
			Console.WriteLine(c.CharDepth3);

			Assert.IsTrue('ㅇ' == c.CharDepth1);
			Assert.IsTrue('ㅓ' == c.CharDepth2);
			Assert.IsTrue('ㅁ' == c.CharDepth3);
		}
	}
}
