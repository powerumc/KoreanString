using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoreanText
{
    public class KoreanChar : IEqualityComparer<KoreanChar>
    {

        public override int GetHashCode()
        {
            return CharK.GetHashCode();
        }

        public char CharK { get; private set; }
        public Encoding CurrentEncoding { get; set; }

        private readonly byte[] chardata = new byte[2];

        public KoreanChar CharDepth1
        {
            get
            {
                if (this.chardata[0] == 49) return this.CharK; // 초성만 있음

                var cindex = this.ToKoreanUniqueCode() - KoreanStringTable.GetIndexDepth3(this.CharDepth3);
                cindex = (cindex / 28) - KoreanStringTable.GetIndexDepth2(this.CharDepth2);
                cindex = cindex / 21;

                return KoreanStringTable.GetIndex1(cindex);
            }
        }

        public KoreanChar CharDepth2
        {
            get
            {
                var cindex = this.ToKoreanUniqueCode() - KoreanStringTable.GetIndexDepth3(this.CharDepth3);
                cindex = (cindex / 28) % 21;

                return KoreanStringTable.GetIndex2(cindex);
            }
        }
        public KoreanChar CharDepth3
        {
            get
            {
                var cindex = this.ToKoreanUniqueCode() % 20;
                return KoreanStringTable.GetIndex3(cindex);
            }
        }

        public KoreanChar(char c)
        {
            this.CharK = c;
            this.CurrentEncoding = Encoding.Default;

            this.Init();
        }

        public KoreanChar(int i)
        {
            this.CharK = Convert.ToChar(i);
            this.Init();
        }

        public KoreanChar(params byte[] bdata)
        {
            this.chardata = bdata.Reverse().ToArray();
            this.CharK = Encoding.Unicode.GetString(this.chardata).First();
        }

        public KoreanChar(string hex)
        {
            this.chardata[1] = (byte)((Convert.ToInt32(new string(hex[0], 1), 16) << 4
                                          | Convert.ToInt32(new string(hex[1], 1), 16)));


            this.chardata[0] = (byte)((Convert.ToInt32(new string(hex[2], 1), 16) << 4
                                          | Convert.ToInt32(new string(hex[3], 1), 16)));

            this.CharK = Encoding.Unicode.GetString(this.chardata).First();
        }

        public static implicit operator KoreanChar(char c)
        {
            return new KoreanChar(c);
        }

        public static implicit operator KoreanChar(int i)
        {
            return new KoreanChar(i);
        }


        public void Init()
        {
            var bdata = Encoding.Unicode.GetBytes(new char[] { this.CharK }).Reverse().ToArray();
            var bdataIndexCount = bdata.Length - 1;

            for (int i = 0; i < bdata.Length; i++)
            {
                this.chardata[i] = bdata[i];
            }
        }

        public string ToUnicodeString()
        {
            return BitConverter.ToString(this.chardata).Replace("-", "");
        }

        public string ToBitsString()
        {
            return Convert.ToString(this.CharK, 2);
        }

        public byte[] ToBytes()
        {
            return this.chardata;
        }

        public byte[] ToByteForMemCopy()
        {
            return this.chardata.Reverse().ToArray();
        }

        public int ToLong()
        {
            return Convert.ToInt32(this.CharK);
        }

        public int ToKoreanUniqueCode()
        {
            return this.ToLong() - KoreanStringTable.가.ToLong();
        }

        public override string ToString()
        {
            return new string(new char[] { this.CharK });
        }


        protected bool Equals(KoreanChar other)
        {
            return this.CharK == other.CharK;
        }

        public bool Equals(KoreanChar x, KoreanChar y)
        {
            return x.CharK == y.CharK;
        }

        public int GetHashCode(KoreanChar obj)
        {
            return this.chardata[0] ^ this.chardata[1];
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
