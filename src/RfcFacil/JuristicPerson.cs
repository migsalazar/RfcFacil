using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfcFacil
{
    class JuristicPerson
    {
        private string Name;
        private int Day;
        private int Month;
        private int Year;

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Day"></param>
        /// <param name="Month"></param>
        /// <param name="Year"></param>
        public JuristicPerson(string Name, int Day, int Month, int Year)
        {
            // TODO: Complete member initialization
            this.Name = Name;
            this.Day = Day;
            this.Month = Month;
            this.Year = Year;
        }
    }
}
