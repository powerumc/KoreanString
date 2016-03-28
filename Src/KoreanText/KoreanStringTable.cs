using System;
using System.Collections.Generic;
using System.Text;

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

        private static readonly List<KoreanChar> Chosung = new List<KoreanChar>()
        {
            new KoreanChar('ㄱ'),
            new KoreanChar('ㄲ'),
            new KoreanChar('ㄴ'),
            new KoreanChar('ㄷ'),
            new KoreanChar('ㄸ'),
            new KoreanChar('ㄹ'),
            new KoreanChar('ㅁ'),
            new KoreanChar('ㅂ'),
            new KoreanChar('ㅃ'),
            new KoreanChar('ㅅ'),
            new KoreanChar('ㅆ'),
            new KoreanChar('ㅇ'),
            new KoreanChar('ㅈ'),
            new KoreanChar('ㅉ'),
            new KoreanChar('ㅊ'),
            new KoreanChar('ㅋ'),
            new KoreanChar('ㅌ'),
            new KoreanChar('ㅍ'),
            new KoreanChar('ㅎ'),
        };
        private static readonly List<KoreanChar> JoongSung = new List<KoreanChar>();
        private static readonly List<KoreanChar> JongSung = new List<KoreanChar>()
        {
            new KoreanChar('\0'),
            new KoreanChar('ㄱ'),
            new KoreanChar('ㄲ'),
            new KoreanChar('ㄳ'),
            new KoreanChar('ㄴ'),
            new KoreanChar('ㄵ'),
            new KoreanChar('ㄶ'),
            new KoreanChar('ㄷ'),
            new KoreanChar('ㄹ'),
            new KoreanChar('ㄺ'),
            new KoreanChar('ㄻ'),
            new KoreanChar('ㄼ'),
            new KoreanChar('ㄽ'),
            new KoreanChar('ㄾ'),
            new KoreanChar('ㄿ'),
            new KoreanChar('ㅀ'),
            new KoreanChar('ㅁ'),
            new KoreanChar('ㅂ'),
            new KoreanChar('ㅄ'),
            new KoreanChar('ㅅ'),
            new KoreanChar('ㅆ'),
            new KoreanChar('ㅇ'),
            new KoreanChar('ㅈ'),
            new KoreanChar('ㅊ'),
            new KoreanChar('ㅋ'),
            new KoreanChar('ㅌ'),
            new KoreanChar('ㅍ'),
            new KoreanChar('ㅎ'),
        };
 
        internal static KoreanChar Ga = new KoreanChar('가');
        internal static KoreanChar A = new KoreanChar('ㅏ');
        internal static KoreanChar I = new KoreanChar('ㅣ');
        internal static KoreanChar G = new KoreanChar('ㄱ');
        internal static KoreanChar H = new KoreanChar('ㅎ');
 
 
        private static readonly int DepthIndex2;
        private static readonly int DepthIndex3;
 
        static KoreanStringTable()
        {
            DepthIndex2 = A.ToInt();
            DepthIndex3 = G.ToInt();
            
            /* 중성 값은 일정한 순서로 들어가므로... */
            for (int i = KoreanStringTable.A.ToInt(); i <= KoreanStringTable.I.ToInt(); i++) 
            	JoongSung.Add(new KoreanChar(i));
        }


        internal static int GetIndexDepth1(KoreanChar c)
        {
        	for(int i=0; i<Chosung.Count; i++) {
        		if( Chosung[i].Equals(c)) {
        			return i;
        		}
        	}
        	
        	throw new IndexOutOfRangeException("GetIndexDepth1");
        }

        internal static int GetIndexDepth2(KoreanChar c)
        {
            return c.ToInt() - DepthIndex2;
        }

        internal static int GetIndexDepth3(KoreanChar c)
        {
            return c.ToInt() - DepthIndex3;
        }
 
        internal static KoreanChar GetIndex1(int index)
        {
            if (index < 0) return new KoreanChar(0);
            return Chosung[index];
        }

        internal static KoreanChar GetIndex2(int index)
        {
            if (index < 0) return new KoreanChar(0);
            return JoongSung[index];
        }

        internal static KoreanChar GetIndex3(int index)
        {
            if (index < 0) return new KoreanChar(0);
            return JongSung[index];
        }
        
        /**
         * Chosung 배열의 한글 초성을 가져옵니다.
         * 
         * @param unicodeIndex	한글 문자의 유니코드 인덱스 값입니다.
         * @return				Chosung 배열의 한글 초성을 가져옵니다.
         */
        internal static int GetIndexOnChoSung(int unicodeIndex) {
        	return (unicodeIndex - Ga.ToKoreanUniqueCode()) / 21 / 28;
        }
        
        /**
         * JoongSung 배열의 한글 중성 값을 가져옵니다.
         * 
         * @param unicodeIndex	한글 문자의 유니코드 인덱스 값입니다.
         * @return				JoongSung 배열의 한글 중성 값을 가져옵니다.
         */
        internal static int GetIndexOnJoongSung(int unicodeIndex) {
        	return (unicodeIndex - Ga.ToKoreanUniqueCode()) % (21 * 28) / 28;
        }
        
        /**
         * JongSung 배열의 한글 종성 값을 가져옵니다.
         * 
         * @param unicodeIndex	한글 문자의 유니코드 인덱스 값입니다.
         * @return				JoongSung 배열의 한글 중성 값을 가져옵니다.
         */
        internal static int GetIndexOnJongSung(int unicodeIndex) {
        	return (unicodeIndex - Ga.ToKoreanUniqueCode()) % 28;
        }
    }
}
