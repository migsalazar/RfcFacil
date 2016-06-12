using System;

namespace RfcFacil.SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var rfc = RfcBuilder.ForNaturalPerson()
                                .WithName("Miguel Angel")
                                .WithFirstLastName("Salazar")
                                .WithSecondLastName("Santillán")
                                .WithDate(1987, 4, 15)
                                .Build();

            Console.WriteLine(rfc);

            Console.ReadKey();
        }
    }
}
