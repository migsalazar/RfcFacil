using System;

namespace RfcFacil.SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var rfc = RfcBuilder.ForNaturalPerson()
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
