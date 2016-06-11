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

            return lastTwoDigitsOf(person.year)
                    + formattedInTwoDigits(person.month)
                    + formattedInTwoDigits(person.day);
        }

        private bool IsFirstLastNameEmpty()
        {
            throw new NotImplementedException();
        }

        private string FirstLastNameEmptyForm()
        {
            throw new NotImplementedException();
        }

        private bool IsSecondLastNameEmpty()
        {
            throw new NotImplementedException();
        }

        private string SecondLastNameEmptyForm()
        {
            throw new NotImplementedException();
        }

        private bool IsFirstLastNameIsTooShort()
        {
            throw new NotImplementedException();
        }

        private string FirstLastNameTooShortForm()
        {
            throw new NotImplementedException();
        }

        private string NormalForm()
        {
            throw new NotImplementedException();
        }  
    }
}
