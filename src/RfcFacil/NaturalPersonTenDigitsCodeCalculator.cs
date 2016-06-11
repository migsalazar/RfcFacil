using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfcFacil
{
    internal class NaturalPersonTenDigitsCodeCalculator
    {
        private NaturalPerson person;
        
        private static const string VowelPattern = "[AEIOU]+";
        
        private static const string[] SpecialParticles = {
            "DE", "LA", "LAS", "MC", "VON", "DEL", "LOS", "Y", "MAC", "VAN", "MI"};

        private static const string[] ForbiddenWords = {
            "BUEI", "BUEY", "CACA", "CACO", "CAGA", "KOGE", "KAKA", "MAME", "KOJO", "KULO",
            "CAGO", "COGE", "COJE", "COJO", "FETO", "JOTO", "KACO", "KAGO", "MAMO", "MEAR", "MEON",
            "MION", "MOCO", "MULA", "PEDA", "PEDO", "PENE", "PUTA", "PUTO", "QULO", "RATA", "RUIN"
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        public NaturalPersonTenDigitsCodeCalculator(NaturalPerson person)
        {
            this.person = person;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Calculate()
        {
            return ObfuscateForbiddenWords(NameCode()) + BirthdayCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameCode"></param>
        /// <returns></returns>
        private string ObfuscateForbiddenWords(string nameCode) 
        {
            foreach(var forbidden in ForbiddenWords)
            {
                if (forbidden.Equals(nameCode))
                {
                    return string.Format("{0}{1}", nameCode.Substring(0, 3), "X");
                }
            }

            return nameCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string NameCode()
        {
            if (IsFirstLastNameEmpty())
            {
                return FirstLastNameEmptyForm();
            }
            else 
            {
                if (IsSecondLastNameEmpty())
                {
                    return SecondLastNameEmptyForm();
                }
                else
                {
                    if (IsFirstLastNameIsTooShort())
                    {
                        return FirstLastNameTooShortForm();
                    }
                    else
                    {
                        return NormalForm();
                    }
                }
            }
        }

        private string BirthdayCode()
        {

            return LastTwoDigitsOf(person.Year)
                    + FormattedInTwoDigits(person.Month)
                    + FormattedInTwoDigits(person.Day);
        }

        private bool IsFirstLastNameEmpty()
        {
            return string.IsNullOrEmpty(Normalize(person.FirstLastName));
        }

        private bool IsSecondLastNameEmpty()
        {
            return string.IsNullOrEmpty(Normalize(person.SecondLastName));
        }

        private string FirstLastNameEmptyForm()
        {
            return 
                FirstTwoLettersOf(person.SecondLastName) + 
                FirstTwoLettersOf(FilterName(person.Name));
        }

        private string SecondLastNameEmptyForm()
        {
            return 
                FirstTwoLettersOf(person.FirstLastName) + 
                FirstTwoLettersOf(FilterName(person.Name));
        }

        private bool IsFirstLastNameIsTooShort()
        {
            return Normalize(person.FirstLastName).Length <= 2;
        }

        private string FirstLastNameTooShortForm()
        {
            return 
                FirstLetterOf(person.FirstLastName) + 
                FirstLetterOf(person.SecondLastName) + 
                FirstTwoLettersOf(FilterName(person.Name));
        }

        private string NormalForm()
        {
            throw new NotImplementedException();
        }

        private string FirstTwoLettersOf(string word)
        {
            string normalizedWord = Normalize(word);
            
            return normalizedWord.Substring(0, 2);
        }

        private string FilterName(string name)
        {
            bool isPopularGivenName = false;
            string rawName = name.Normalize().Trim();

            if (rawName.Contains(" "))
            {
                isPopularGivenName = rawName.StartsWith("MARIA") || rawName.StartsWith("JOSE");

                if (isPopularGivenName)
                {
                    return rawName.Split(' ')[1];
                }
            }
            return name;
        }

        private string FirstLetterOf(string word)
        {
            string normalizedWord = Normalize(word);
            
            return normalizedWord[0].ToString();
        }

        private string Normalize(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return word;
            }
            else
            {
                string normalizedWord = StringUtils.stripAccents(word).toUpperCase();
                return removeSpecialParticles(normalizedWord, SPECIAL_PARTICLES);
            }
        }
    }
}
