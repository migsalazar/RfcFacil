using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfcFacil
{
    internal class NaturalPerson : Person, IHomoclavePerson
    {
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="firstLastName"></param>
        /// <param name="secondLastName"></param>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        public NaturalPerson(string name, string firstLastName, string secondLastName, int day, int month, int year)
        {
            this.Name = name;
            this.FirstLastName = firstLastName;
            this.SecondLastName = secondLastName;
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetFullNameForHomoclave()
        {
            return string.Format("{0} {1} {2}", this.FirstLastName, this.SecondLastName, this.Name);
        }
    }
}
