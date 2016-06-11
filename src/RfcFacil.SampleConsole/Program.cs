using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfcFacil.SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var rfc = RfcBuilder.ForJuristicPerson()
                                .WithName("Miguel")
                                .WithFirstLastName("Salazar")
                                .WithSecondLastName("Santillán")
                                .WithDate(1987, 04, 15)
                                .Build();

            Console.WriteLine(rfc);

            Console.ReadKey();
        }
    }
}
