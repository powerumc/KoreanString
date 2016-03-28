using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace KoreanText
{
    public class KoreanString
    {
        public readonly KoreanChar[] Strings;

        public KoreanString(string s)
        {
            var arrChar = s.ToCharArray();
            this.Strings = new KoreanChar[arrChar.Length];
            for (var i = 0; i < arrChar.Length; i++)
            {
                this.Strings[i] = new KoreanChar(arrChar[i]);
            }
        }

        public KoreanString(params KoreanChar[] chars)
        {
            this.Strings = chars;
        }

        public int Length
        {
            get { return this.Strings.Length; }
        }

        public override int GetHashCode()
        {
            var hashcode = 1;

            foreach (var c in this.Strings)
            {
                hashcode ^= c.GetHashCode();
            }

            return hashcode;
        }

        /**
	    * 한글 문자열의 초/중/종성 모두 같으면 true를 반환합니다.
	    */
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override string ToString()
        {
            var sb = new StringBuilder(this.Strings.Length);
            foreach (var s in this.Strings)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }

        /**
	 * 한글 문자열이 초/중/종성의 규칙을 matcher로 지정하여 한글 문자열을 비교합니다.
	 * 
	 * @param obj		비교할 대상의 한글 문자열 입니다.
	 * @param matcher	비교할 규칙 인터페이스 입니다.
	 * @return			비교할 규칙에 의해 같은 경우 (초/중/종성일 수 있음) true를 반환합니다.
	 */
        //public boolean equals(Object obj, Equalable<KoreanChar> matcher)
        //{
        //    if (matcher == null)
        //        matcher = KoreanStringMatch.OnlyChosungKoreanStringMatcher;

        //    if (this.getLength() != ((KoreanString)obj).getLength()) return false;

        //    return this.startsWith((KoreanString)obj, matcher);
        //}

        /**
	 * 한글 문자열이 지정한 값으로 시작하면 true를 반환합니다.
	 * 
	 * @param s		비교할 대상의 한글 문자열 입니다.
	 * @return		비교할 규칙에 의해 같은 경우 (초/중/종성일 수 있음) true를 반환합니다.
	 */

        //public bool startsWith(KoreanString s)
        //{
        //    return this.startsWith(s, null);
        //}

        /**
	 * 한글 문자열이 지정한 값으로 시작하면 true를 반환합니다.
	 * 
	 * @param s			비교할 대상의 한글 문자열 입니다.
	 * @param matcher	기본 값은 초성만 비교하는 인터페이스의 KoreanStringMatch.OnlyChosungKoreanStringMatcher 구현입니다.
	 * @return			비교할 규칙에 의해 같은 경우 (초/중/종성일 수 있음) true를 반환합니다.
	 */
        //public bool startsWith(KoreanString s, Equalable<KoreanChar> matcher)
        //{

        //    if (matcher == null)
        //        matcher = KoreanStringMatch.OnlyChosungKoreanStringMatcher;

        //    boolean result = true;

        //    Iterator<KoreanChar> src = this.iterator();
        //    Iterator<KoreanChar> des = s.iterator();

        //    while (result && src.hasNext() && des.hasNext())
        //    {

        //        KoreanChar srcChar = src.next();
        //        KoreanChar desChar = des.next();

        //        result = matcher.equals(srcChar, desChar);
        //    }

        //    return result;
        //}

        //public boolean contains(KoreanString s, Equalable<KoreanChar> matcher)
        //{
        //    if (matcher == null)
        //        matcher = KoreanStringMatch.OnlyChosungKoreanStringMatcher;

        //    boolean result = true;

        //    Iterator<KoreanChar> src = this.iterator();
        //    Iterator<KoreanChar> des = s.iterator();



        //    return result;
        //}
    }
}
