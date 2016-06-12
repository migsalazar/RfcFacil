using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RfcFacil
{
    public class RfcBuilder
    {
        private string Name;
        private string FirstLastName;
        private string SecondLastName;
        private int Year;
        private int Month;
        private int Day;

        private bool IsNaturalPerson;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isNaturalPerson">Set if person is Natural or Juristic</param>
        private RfcBuilder(bool isNaturalPerson) 
        {
            this.IsNaturalPerson = isNaturalPerson;
        }

        /// <summary>
        /// Init path 
        /// </summary>
        /// <returns>Instance of Rfc</returns>
        public Rfc Build()
        {
            return this.IsNaturalPerson ? BuildForNaturalPerson() : BuildForJuristicPerson();
        }

        /// <summary>
        /// Build Natural Person - Main logic
        /// </summary>
        /// <returns>instance of RFC (wrapped by static method Rfc.Build)</returns>
        private Rfc BuildForNaturalPerson()
        {
            NaturalPerson person = new NaturalPerson(this.Name, this.FirstLastName, this.SecondLastName, this.Day, this.Month, this.Year);

            string tenDigitsCode = new NaturalPersonTenDigitsCodeCalculator(person).Calculate();
            string homoclave = new HomoclaveCalculator(person).Calculate();
            string verificationDigit = new VerificationDigitCalculator(tenDigitsCode + homoclave).Calculate();

            return Rfc.Build(tenDigitsCode, homoclave, verificationDigit);
        }

        /// <summary>
        /// Build Juristic Person - Main logic
        /// </summary>
        /// <returns>instance of RFC (wrapped by static method Rfc.Build)</returns>
        private Rfc BuildForJuristicPerson()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set person type
        /// </summary>
        /// <returns></returns>
        public static RfcBuilder ForNaturalPerson()
        {
            return new RfcBuilder(true);
        }

        /// <summary>
        /// Set person type
        /// </summary>
        /// <returns></returns>
        public static RfcBuilder ForJuristicPerson()
        {
            return new RfcBuilder(false);
        }

        /// <summary>
        /// Set Name (Legal Name or Person Name)
        /// </summary>
        /// <returns>Instance of RfcBuilder to be fluent</returns>
        public RfcBuilder WithName(string name) 
        {
            this.Name = name;
            return this;
        }

        /// <summary>
        /// Set FirsLastName
        /// </summary>
        /// <param name="firstLastName"></param>
        /// <returns></returns>
        public RfcBuilder WithFirstLastName(string firstLastName)
        {
            if (!this.IsNaturalPerson)
            {
                throw new MethodAccessException("WithFirstLastName method can't be used with ForJuristicPerson method");
            }

            this.FirstLastName = firstLastName;
            return this;
        }

        /// <summary>
        /// Set SecondLastName
        /// </summary>
        /// <param name="secondLastName"></param>
        /// <returns></returns>
        public RfcBuilder WithSecondLastName(string secondLastName)
        {
            if (!this.IsNaturalPerson)
            {
                throw new MethodAccessException("WithSecondLastName method can't be used with ForJuristicPerson method");
            }

            this.SecondLastName = secondLastName;
            return this;
        }

        /// <summary>
        /// Set birthdate/creation date
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public RfcBuilder WithDate(int year, int month, int day)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;

            return this;
        }
    }
}
