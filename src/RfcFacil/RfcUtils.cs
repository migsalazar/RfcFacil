using System.Globalization;
using System.Linq;
using System.Text;

namespace RfcFacil
{ 
    public static class RfcUtils
    {
        /// <summary>
        /// Remove diacritics, ex:
        // "ÁÂÃÄÅÇÈÉàáâãäåèéêëìíîïòóôõ" ====>> "AAAAACEEaaaaaaeeeeiiiioooo"
        /// </summary>
        /// <param name="word">target word</param>
        /// <returns>result word</returns>
        public static string StripAccents(string word)
        {
            string normal = word.Normalize(NormalizationForm.FormD);

            var converted = normal.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);

            return new string(converted.ToArray());
        }
    }
}
