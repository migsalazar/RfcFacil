using System;
using System.Collections.Generic;
using System.Text;

namespace RfcFacil
{
    class HomoclaveCalculator
    {
        private static IHomoclavePerson IHomoclavePerson;
        private string FullName;
        private string MappedFullName;
        private int PairsOfDigitsSum;
        private string Homoclave;
        private static readonly string HomoclaveDigits = "123456789ABCDEFGHIJKLMNPQRSTUVWXYZ";
        private static readonly Dictionary<string, string> FullNameMapping = new Dictionary<string, string>()
        {
            {" ", "00"},
            {"0", "00"},
            {"1", "01"},
            {"2", "02"},
            {"3", "03"},
            {"4", "04"},
            {"5", "05"},
            {"6", "06"},
            {"7", "07"},
            {"8", "08"},
            {"9", "09"},
            {"&", "10"},
            {"A", "11"},
            {"B", "12"},
            {"C", "13"},
            {"D", "14"},
            {"E", "15"},
            {"F", "16"},
            {"G", "17"},
            {"H", "18"},
            {"I", "19"},
            {"J", "21"},
            {"K", "22"},
            {"L", "23"},
            {"M", "24"},
            {"N", "25"},
            {"O", "26"},
            {"P", "27"},
            {"Q", "28"},
            {"R", "29"},
            {"S", "32"},
            {"T", "33"},
            {"U", "34"},
            {"V", "35"},
            {"W", "36"},
            {"X", "37"},
            {"Y", "38"},
            {"Z", "39"},
            {"Ñ", "40"}
        };

        public HomoclaveCalculator(IHomoclavePerson person) {

            IHomoclavePerson = person;
        }

        public string Calculate() {

            NormalizeFullName();
            MapFullNameToDigitsCode();
            SumPairsOfDigits();
            BuildHomoclave();

            return Homoclave;
        }

        private void BuildHomoclave() {

            int lastThreeDigits = PairsOfDigitsSum % 1000;
            int quo = lastThreeDigits / 34;
            int reminder = lastThreeDigits % 34;

            Homoclave = HomoclaveDigits[quo].ToString() + HomoclaveDigits[reminder].ToString();
        }

        private void SumPairsOfDigits() {

            PairsOfDigitsSum = 0;

            for (int i = 0; i < MappedFullName.Length - 1; i++) {
                int intNum1 = int.Parse(MappedFullName.Substring(i, i + 2));

                int intNum2 = int.Parse(MappedFullName.Substring(i + 1, i + 2));

                PairsOfDigitsSum += intNum1 * intNum2;
            }
        }

        private void MapFullNameToDigitsCode() {

            MappedFullName = "0";

            for (int i = 0; i < FullName.Length; i++) {
                MappedFullName += MapCharacterToTwoDigitCode( FullName[i].ToString());
            }
        }

        private string MapCharacterToTwoDigitCode(string c) {
            
            string outValue = "";

            if (!FullNameMapping.TryGetValue(c, out outValue)) {
                throw new ArgumentException("No two-digit-code mapping for char: " + c);
            } 

            return outValue;
        }

        private void NormalizeFullName() {

            string rawFullName = IHomoclavePerson.GetFullNameForHomoclave().ToUpper();

            FullName = RfcUtils.StripAccents(rawFullName);
            FullName = FullName.Replace("[\\-\\.',]", "");
            FullName = AddMissingCharToFullName(rawFullName, 'Ñ');

        }

        private string AddMissingCharToFullName(string rawFullName, char missingChar) {

            StringBuilder newFullName;
            int index = rawFullName.IndexOf(missingChar);

            if (index == -1) {
                return FullName;
            }

            newFullName = new StringBuilder(FullName);

            while (index >= 0) {
                newFullName[index] =  missingChar;
                index = rawFullName.IndexOf(missingChar, index + 1);
            }

            return newFullName.ToString();
        }
    }
}
