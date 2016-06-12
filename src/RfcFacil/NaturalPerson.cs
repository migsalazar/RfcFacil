
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
        public NaturalPerson(string name, string firstLastName, string secondLastName, int year, int month, int day)
        {
            this.Name = name;
            this.FirstLastName = firstLastName;
            this.SecondLastName = secondLastName;
            this.Year = year;
            this.Month = month;
            this.Day = day;    
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
