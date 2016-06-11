using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfcFacil
{
    public class StringUtils
    {
        public static string StripAccents(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s.Normalize(NormalizationForm.FormKD))
                switch (CharUnicodeInfo.GetUnicodeCategory(c))
                {
                    case UnicodeCategory.NonSpacingMark:
                    case UnicodeCategory.SpacingCombiningMark:
                    case UnicodeCategory.EnclosingMark:
                        break;

                    default:
                        sb.Append(c);
                        break;
                }
            return sb.ToString();
        }

    }
}
