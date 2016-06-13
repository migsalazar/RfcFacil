![](https://raw.githubusercontent.com/migsalazar/RfcFacil/master/logo.png)

Librería para el cálculo del RFC (Registro Federal de Contribuyentes) del SAT (Servicio de Administración Tributaria) en .NET 

[![Build status](https://ci.appveyor.com/api/projects/status/jnui923swgs8e7xt/branch/master?svg=true)](https://ci.appveyor.com/project/migsalazar/rfcfacil/branch/master)

## Uso

La documentación completa se encuentra en [migsalazar.com/RfcFacil](http://migsalazar.com/RfcFacil)

1.- Instala RfcFacil en tu proyecto [vía NuGet](https://www.nuget.org/packages/RfcFacil/):

```
PM> Install-Package RfcFacil
```

2.- Calcular el RFC es muy sencillo:

- Personas físicas

C#
```csharp
using RfcFacil;
namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {
            var rfc = RfcBuilder.ForNaturalPerson()
                                .WithName("Miguel Angel")
                                .WithFirstLastName("Salazar")
                                .WithSecondLastName("Santillan")
                                .WithDate(1987, 04, 15)
                                .Build();

            Console.WriteLine(rfc.ToString());
        }
    }
}
```
VB
```vb
Imports RfcFacil
Module Module1
    Sub Main()
        Dim rfc = RfcBuilder.ForNaturalPerson() _
                            .WithName("Miguel Angel") _
                            .WithFirstLastName("Salazar") _
                            .WithSecondLastName("Santillan") _
                            .WithDate(1987, 4, 15)

        Console.Write(rfc)
    End Sub
End Module
```

- Personas morales

```csharp
//coming soon :B
```

## Fuente
Esta librería se basa en documentación oficial obtenida por medio del IFAI (Instituto Federal de Acceso a la Información). El documento puede ser consultado en el sitio de [INFOMEX](https://www.infomex.org.mx/gobiernofederal/moduloPublico/moduloPublico.action) con el folio `0610100135506`.

Cabe advertir que sólo la Secretaría de Hacienda y Crédito Público, a través del Servicio de Administración Tributaria, es la única instancia que oficialmente asigna las claves de RFC a los contribuyentes que así lo soliciten, a partir de la aplicación de este procedimiento a la base de datos del Padrón de Contribuyentes, con la finalidad de identificar homonimias y evitar la duplicidad de registros.

## En otros lenguajes
- JAVA [josketres/rfc-facil](https://github.com/josketres/rfc-facil)
- Ruby [acrogenesis/rfc_facil](https://github.com/acrogenesis/rfc_facil)

## Contribuciones
- Reporta errores o sugerencias en: [https://github.com/migsalazar/RfcFacil/issues](https://github.com/migsalazar/RfcFacil/issues)

## Agradecimientos
RfcFacil .NET es una versión para .NET de la librería [rfc-facil](http://josketres.github.io/rfc-facil/) escrita por [josketres](https://github.com/josketres). Gracias!

## Licencia
The MIT License (MIT)
