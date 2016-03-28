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
			KoreanStringTable.檬己.ForEach(o => Console.WriteLine("{0} - {1}", o, KoreanStringTable.GetIndexDepth1(o)));

			Assert.AreEqual(0, KoreanStringTable.GetIndexDepth1('ぁ'));
			Assert.AreEqual(18, KoreanStringTable.GetIndexDepth1('ぞ'));
		}

		[TestMethod]
		public void Korean_Depth1_Index_Excloude_Test()
		{
			KoreanStringTable.檬己.ForEach(o => Console.WriteLine("{0} - {1}", o, KoreanStringTable.GetIndexDepth1(o)));

			Assert.AreEqual(-1, KoreanStringTable.GetIndexDepth1('ぃ'));
		}



		[TestMethod]
		public void Korean_Depth2_Index_Test()
		{
			KoreanChar c = 'た';

			for (int i = KoreanStringTable.た.ToLong(); i <= KoreanStringTable.び.ToLong(); i++)
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
			KoreanChar c = 'ぁ';

			for (int i = KoreanStringTable.ぁ.ToLong(); i <= KoreanStringTable.ぞ.ToLong(); i++)
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
			KoreanStringTable.辆己.ForEach(o => Console.WriteLine("{0} - {1}", o, KoreanStringTable.GetIndexDepth3(o)));


			KoreanChar c = '决';
			Console.WriteLine(c.CharDepth1);
			Console.WriteLine(c.CharDepth2);
			Console.WriteLine(c.CharDepth3);

			Assert.IsTrue('し' == c.CharDepth1);
			Assert.IsTrue('っ' == c.CharDepth2);
			Assert.IsTrue('け' == c.CharDepth3);
		}
	}
}
