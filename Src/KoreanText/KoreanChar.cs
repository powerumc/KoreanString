using System;
using System.Collections.Generic;
using System.Text;

namespace KoreanText
{
    public class KoreanChar
    {

        private char mChar;
        private byte[] mCharData;

        public KoreanChar(char c)
        {
            this.mChar = c;
            this.init();
        }

        public KoreanChar(int i)
        {
            this.mChar = (char)i;
            this.init();
        }

        /**
         * 바이트로 분할하여 메모리에 push된 값을 swap하여 보관한다. 
         */
        private void init()
        {
            this.mCharData = toBinaryNumber(this.mChar);
            this.mCharData = swapBytes(this.mCharData);
        }


        public static implicit operator KoreanChar(char c)
        {
            return new KoreanChar(c);
        }

        public char GetChar()
        {
            return this.mChar;
        }

        public byte[] GetBytes()
        {
            return this.mCharData;
        }

        /**
         * 한글 문자의 초성 반환합니다.
         */
        public KoreanChar GetChoSung()
        {
            var unicode = this.ToInt();
            if (unicode >= KoreanStringTable.G.ToInt() && unicode <= KoreanStringTable.H.ToInt())
            {
                return this;
            }

            var index = this.ToKoreanUniqueCode();

            return KoreanStringTable.GetIndex1(KoreanStringTable.GetIndexOnChoSung(index));
        }

        /**
         * 한글 문자의 중성을 반환합니다.
         */
        public KoreanChar GetJoongSung()
        {
            var index = this.ToKoreanUniqueCode();

            return KoreanStringTable.GetIndex2(KoreanStringTable.GetIndexOnJoongSung(index));
        }

        /**
         * 한글 문자의 종성을 반환합니다.
         */
        public KoreanChar GetJongSung()
        {
            var index = this.ToKoreanUniqueCode();

            return KoreanStringTable.GetIndex3(KoreanStringTable.GetIndexOnJongSung(index));
        }

        private static byte[] toBinaryNumber(char c)
        {
            var data = Encoding.Unicode.GetBytes(c.ToString());

            return data;
        }

        private static byte[] swapBytes(byte[] data)
        {
            var temp = new byte[data.Length];

            for (var i = 0; i < data.Length; i++)
            {
                temp[i] = data[data.Length - i - 1];
            }

            return temp;
        }

        public long ToLong()
        {
            return (long)this.mChar;
        }

        public int ToInt()
        {
            return (int)this.mChar;
        }

        public byte[] ToBytes()
        {
            return this.mCharData;
        }

        public int ToKoreanUniqueCode()
        {
            var unicode = this.ToInt();

            return unicode - KoreanStringTable.Ga.ToInt();
        }

        public override string ToString()
        {
            return Encoding.Unicode.GetString(swapBytes(this.mCharData));
        }

        public override int GetHashCode()
        {
            if (this.mCharData.Length >= 2)
                return this.mCharData[0] ^ this.mCharData[1];

            return 1;
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public bool Contains(char c)
        {
            var kc = new KoreanChar(c);
            var has = KoreanStringTable.GetIndexOnChoSung(this.GetChoSung().ToKoreanUniqueCode()) > 0 &&
                      KoreanStringTable.GetIndexOnChoSung(kc.GetChoSung().ToKoreanUniqueCode()) > 0;
            if (has && this.GetChoSung() != kc.GetChoSung()) return false;

            has = KoreanStringTable.GetIndexOnJoongSung(this.GetJoongSung().ToInt()) > 0 &&
                  KoreanStringTable.GetIndexOnJoongSung(kc.GetJoongSung().ToInt()) > 0;
            if (has && this.GetJoongSung() != kc.GetJoongSung()) return false;

            has = KoreanStringTable.GetIndexOnJongSung(this.GetJongSung().ToInt()) > 0 &&
                  KoreanStringTable.GetIndexOnJongSung(kc.GetJongSung().ToInt()) > 0;
            if (has && this.GetJongSung() != kc.GetJongSung()) return false;


            return true;
        }

        public static bool operator ==(KoreanChar a, KoreanChar b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(KoreanChar a, KoreanChar b)
        {
            return !a.Equals(b);
        }

        public static bool operator ==(char a, KoreanChar b)
        {
            return new KoreanChar(a).Equals(b);
        }

        public static bool operator !=(char a, KoreanChar b)
        {
            return !(new KoreanChar(a).Equals(b));
        }
    }
}
