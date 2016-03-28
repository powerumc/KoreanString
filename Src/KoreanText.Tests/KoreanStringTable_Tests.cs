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
			KoreanStringTable.�ʼ�.ForEach(o => Console.WriteLine("{0} - {1}", o, KoreanStringTable.GetIndexDepth1(o)));

			Assert.AreEqual(0, KoreanStringTable.GetIndexDepth1('��'));
			Assert.AreEqual(18, KoreanStringTable.GetIndexDepth1('��'));
		}

		[TestMethod]
		public void Korean_Depth1_Index_Excloude_Test()
		{
			KoreanStringTable.�ʼ�.ForEach(o => Console.WriteLine("{0} - {1}", o, KoreanStringTable.GetIndexDepth1(o)));

			Assert.AreEqual(-1, KoreanStringTable.GetIndexDepth1('��'));
		}



		[TestMethod]
		public void Korean_Depth2_Index_Test()
		{
			KoreanChar c = '��';

			for (int i = KoreanStringTable.��.ToLong(); i <= KoreanStringTable.��.ToLong(); i++)
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
			KoreanChar c = '��';

			for (int i = KoreanStringTable.��.ToLong(); i <= KoreanStringTable.��.ToLong(); i++)
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
			KoreanStringTable.����.ForEach(o => Console.WriteLine("{0} - {1}", o, KoreanStringTable.GetIndexDepth3(o)));


			KoreanChar c = '��';
			Console.WriteLine(c.CharDepth1);
			Console.WriteLine(c.CharDepth2);
			Console.WriteLine(c.CharDepth3);

			Assert.IsTrue('��' == c.CharDepth1);
			Assert.IsTrue('��' == c.CharDepth2);
			Assert.IsTrue('��' == c.CharDepth3);
		}
	}
}
