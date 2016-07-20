using System;
using System.Collections.Generic;

namespace RfcFacil
{
    internal class VerificationDigitCalculator
    {
        private readonly string Rfc12Digits;
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
        /// 
        /// </summary>
        /// <param name="p"></param>
        public VerificationDigitCalculator(string rfc12Digits)
        {
            this.Rfc12Digits = rfc12Digits.PadLeft(12);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Calculate()
        {
            int sum = 0;
            int reminder;

            for (int i = 0; i < 12; i++)
            {
                sum += MapDigit(this.Rfc12Digits[i]) * (13 - i);
            }

            reminder = sum % 11;

            if (reminder == 0)
            {
                return "0";
            }
            if (reminder > 0)
            {
                return MapValue(11 - reminder);
            }
            return null;
        }

        private int MapDigit(char c)
        {
            int outValue = 0; //redundance

            bool hasOutput = Mapping.TryGetValue(c.ToString(), out outValue);
            
            return hasOutput ? outValue : 0;
        }
        
        private string MapValue(int i)
        {
            var key = Mapping.FirstOrDefault(x => x.Value == i).Key;
            return key;
        }
    }
}
