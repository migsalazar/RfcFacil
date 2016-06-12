using System;
using System.Collections.Generic;

namespace RfcFacil
{
    public class VerificationDigitCalculator
    {

        private string p;

        private static readonly Dictionary<string, int> Mapping = new Dictionary<string, int>()
        {
            {"0", 0},
            {"1", 1},
            {"2", 2},
            {"3", 3},
            {"4", 4},
            {"5", 5},
            {"6", 6},
            {"7", 7},
            {"8", 8},
            {"9", 9},
            {"A", 10},
            {"B", 11},
            {"C", 12},
            {"D", 13},
            {"E", 14},
            {"F", 15},
            {"G", 16},
            {"H", 17},
            {"I", 18},
            {"J", 19},
            {"K", 20},
            {"L", 21},
            {"M", 22},
            {"N", 23},
            {"&", 24},
            {"O", 25},
            {"P", 26},
            {"Q", 27},
            {"R", 28},
            {"S", 29},
            {"T", 30},
            {"U", 31},
            {"V", 32},
            {"W", 33},
            {"X", 34},
            {"Y", 35},
            {"Z", 36},
            {" ", 37},
            {"Ñ", 38}
        };

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="p"></param>
        public VerificationDigitCalculator(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        internal string Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
