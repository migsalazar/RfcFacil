using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RfcFacil
{
    class HomoclaveCalculator
    {
        private JuristicPerson person;
        private NaturalPerson person1;

        public HomoclaveCalculator(JuristicPerson person)
        {
            // TODO: Complete member initialization
            this.person = person;
        }

        public HomoclaveCalculator(NaturalPerson person)
        {
            // TODO: Complete member initialization
            this.person1 = person;
        }
     
        internal string Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
