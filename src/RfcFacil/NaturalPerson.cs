using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfcFacil
{
    internal class NaturalPerson : Person
    {
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }

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
        /// String representation of NaturalPerson object
        /// </summary>
        /// <returns>string FullName</returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.FirstLastName, this.SecondLastName, this.Name);            
        }
    }
}
