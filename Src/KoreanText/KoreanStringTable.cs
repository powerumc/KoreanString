using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoreanText
{
    internal class KoreanStringTable
    {
        /*
		 * 참고 http://kakidot.tistory.com/63
		 * http://www.w3c.or.kr/i18n/hangul-i18n/ko-code.html
		 * 
		 *  ㄱ 0
			ㄲ 1
			ㄴ 2
			ㄷ 3
			ㄸ 4
			ㄹ 5
			ㅁ 6
			ㅂ 7
			ㅃ 8
			ㅅ 9
			ㅆ 10
			ㅇ 11
			ㅈ 12
			ㅉ 13
			ㅊ 14
			ㅋ 15
			ㅌ 16
			ㅍ 17
		    ㅎ 18

		 * 
		 * */

        internal static List<KoreanChar> 초성 = new List<KoreanChar>()
                                                  {
                                                      'ㄱ',
                                                      'ㄲ',
                                                      'ㄴ',
                                                      'ㄷ',
                                                      'ㄸ',
                                                      'ㄹ',
                                                      'ㅁ',
                                                      'ㅂ',
                                                      'ㅃ',
                                                      'ㅅ',
                                                      'ㅆ',
                                                      'ㅇ',
                                                      'ㅈ',
                                                      'ㅉ',
                                                      'ㅊ',
                                                      'ㅋ',
                                                      'ㅌ',
                                                      'ㅍ',
                                                      'ㅎ'
                                                  };

        internal static List<KoreanChar> 중성 = new List<KoreanChar>();
        internal static List<KoreanChar> 종성 = new List<KoreanChar>();

        internal static KoreanChar 가 = '가';

        internal static KoreanChar ㅏ = 'ㅏ';
        internal static KoreanChar ㅣ = 'ㅣ';

        internal static KoreanChar ㄱ = 'ㄱ';
        internal static KoreanChar ㅎ = 'ㅎ';


        internal static int DepthIndex2;
        internal static int DepthIndex3;

        static KoreanStringTable()
        {
            DepthIndex2 = ㅏ.ToLong();
            DepthIndex3 = ㄱ.ToLong();


            for (int i = KoreanStringTable.ㅏ.ToLong(); i <= KoreanStringTable.ㅣ.ToLong(); i++) { 중성.Add(i); }
            for (int i = KoreanStringTable.ㄱ.ToLong(); i <= KoreanStringTable.ㅎ.ToLong(); i++) { 종성.Add(i); }
        }


        internal static int GetIndexDepth1(KoreanChar c)
        {
            return 초성.FindIndex(o => o == c);
        }

        internal static int GetIndexDepth2(KoreanChar c)
        {
            return c.ToLong() - DepthIndex2;
        }

        internal static int GetIndexDepth3(KoreanChar c)
        {
            return c.ToLong() - DepthIndex3;
        }

        internal static KoreanChar GetIndex1(int index)
        {
            if (index < 0) return '\0';
            return 초성[index];
        }

        internal static KoreanChar GetIndex2(int index)
        {
            if (index < 0) return '\0';
            return 중성[index];
        }

        internal static KoreanChar GetIndex3(int index)
        {
            if (index < 0) return '\0';
            return 종성[index];
        }
    }
}
