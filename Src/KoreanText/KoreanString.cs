using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KoreanText
{
    public class KoreanString
    {
        public KoreanChar[] Strings { get; private set; }

        public KoreanString(params KoreanChar[] chars)
        {
            this.Strings = chars;
        }


        public static implicit operator KoreanString(string str)
        {
            var chars = str.Select(o => new KoreanChar(o));

            return new KoreanString(chars.ToArray());
        }

        public override string ToString()
        {
            var ptr = Marshal.AllocHGlobal(this.Strings.Length);
            var bdata = this.Strings.SelectMany(o => o.ToByteForMemCopy());

            Marshal.Copy(bdata.ToArray(), 0, ptr, this.Strings.Length * 2);
            var str = Marshal.PtrToStringUni(ptr, this.Strings.Length);

            Marshal.FreeHGlobal(ptr);

            return str;
        }
    }
}
