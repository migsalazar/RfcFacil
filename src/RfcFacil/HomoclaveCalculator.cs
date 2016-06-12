using System;
using System.Collections.Generic;
using System.Linq;
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
        private static readonly Dictionary<string, string> fullNameMapping = new Dictionary<string, string>()
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

        public String calculate() {

            normalizeFullName();
            mapFullNameToDigitsCode();
            sumPairsOfDigits();
            buildHomoclave();

            return Homoclave;
        }

        private void buildHomoclave() {

            int lastThreeDigits = PairsOfDigitsSum % 1000;
            int quo = lastThreeDigits / 34;
            int reminder = lastThreeDigits % 34;
            Homoclave = String.valueOf(HOMOCLAVE_DIGITS.charAt(quo))
                    + String.valueOf(HOMOCLAVE_DIGITS.charAt(reminder));
        }

        private void sumPairsOfDigits() {

            PairsOfDigitsSum = 0;
            for (int i = 0; i < MappedFullName.length() - 1; i++) {
                int intNum1 = Integer.parseInt(MappedFullName.substring(i, i + 2));
                int intNum2 = Integer.parseInt(MappedFullName.substring(i + 1, i + 2));
                PairsOfDigitsSum += intNum1 * intNum2;
            }
        }

        private void mapFullNameToDigitsCode() {

            MappedFullName = "0";
            for (int i = 0; i < FullName.length(); i++) {
                MappedFullName += mapCharacterToTwoDigitCode(String.valueOf(FullName.charAt(i)));
            }
        }

        private String mapCharacterToTwoDigitCode(String c) {

            if (!FullNameMapping.containsKey(c)) {
                throw new IllegalArgumentException("No two-digit-code mapping for char: " + c);
            } else {
                return FullNameMapping.get(c);
            }
        }

        private void normalizeFullName() {

            String rawFullName = IHomoclavePerson.getFullNameForHomoclave().toUpperCase();

            FullName = StringUtils.stripAccents(rawFullName);
            FullName = FullName.replaceAll("[\\-\\.',]", ""); // remove .'-,
            FullName = addMissingCharToFullName(rawFullName, 'Ñ');

        }

        private String addMissingCharToFullName(String rawFullName, char missingChar) {

            int index = rawFullName.indexOf(missingChar);
            if (index == -1) {
                return FullName;
            }

            StringBuilder newFullName = new StringBuilder(FullName);
            while (index >= 0) {
                newFullName.setCharAt(index, missingChar);
                index = rawFullName.indexOf(missingChar, index + 1);
            }
            return newFullName.toString();
        }
    }
}
