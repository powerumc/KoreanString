using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoreanText
{
    public class KoreanStringMatch : IEqualityComparer<KoreanChar>, IEqualityComparer<KoreanString>
    {
        private readonly KoreanStringMatchCompareOption option;

        public KoreanStringMatch(KoreanStringMatchCompareOption option)
        {
            this.option = option;
        }

        public bool Equals(KoreanChar x, KoreanChar y)
        {
            var result = false;

            var option1 = (this.option & KoreanStringMatchCompareOption.Depth1) == KoreanStringMatchCompareOption.Depth1;
            var option2 = (this.option & KoreanStringMatchCompareOption.Depth2) == KoreanStringMatchCompareOption.Depth2;
            var optionAnd = (this.option & KoreanStringMatchCompareOption.Depth1And2) == KoreanStringMatchCompareOption.Depth1And2;


            if (option1) result |= x.CharDepth1 == y.CharDepth1;
            if (option2) result |= x.CharDepth2 == y.CharDepth2;
            if (optionAnd) result &= x.CharDepth2 == y.CharDepth2;


            return result;
        }

        public bool StartWiths(KoreanString x, KoreanString y)
        {
            throw new NotImplementedException();
        }

        public bool Contains(KoreanString x, KoreanString y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(KoreanChar obj)
        {
            return obj.GetHashCode();
        }

        public bool Equals(KoreanString x, KoreanString y)
        {
            var result = false;

            for (int i = 0; i < x.Strings.Length; i++)
            {
                result = this.Equals(x.Strings[i], y.Strings[i]);
                if (result == false) return false;
            }

            return true;
        }

        public int GetHashCode(KoreanString obj)
        {
            return obj.GetHashCode();
        }
    }

    [Flags]
    public enum KoreanStringMatchCompareOption
    {
        [Description]
        Depth1 = 0x01,
        [Description]
        Depth2 = Depth1 << 1,
        [Description]
        Depth1And2 = (Depth1 << 2) + 1
    }
}
