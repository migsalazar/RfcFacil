
# RfcFacil .NET

![](https://raw.githubusercontent.com/migsalazar/RfcFacil/master/logo.png)

Librería para el cálculo del RFC (Registro Federal de Contribuyentes) del SAT (Servicio de Administración Tributaria) en México - en C# .NET 

[![Build status](https://ci.appveyor.com/api/projects/status/jnui923swgs8e7xt/branch/master?svg=true)](https://ci.appveyor.com/project/migsalazar/rfcfacil/branch/master)

# Uso

Vía NuGet:

			PM> Install-Package RfcFacil

```csharp
var rfc = RfcBuilder.ForNaturalPerson()
					.WithName("Miguel Angel")
					.WithFirstLastName("Salazar")
					.WithSecondLastName("Santillán")
					.WithDate(1987, 4, 15)
					.Build();

Console.WriteLine(rfc);
```

# Fuente
Esta librería se basa en documentación oficial obtenida por medio del IFAI (Instituto Federal de Acceso a la Información). El documento puede ser consultado en el sitio de [INFOMEX](https://www.infomex.org.mx/gobiernofederal/moduloPublico/moduloPublico.action) con el folio `0610100135506`.

Cabe advertir que sólo la Secretaría de Hacienda y Crédito Público, a través del Servicio de Administración Tributaria, es la única instancia que oficialmente asigna las claves de RFC a los contribuyentes que así lo soliciten, a partir de la aplicación de este procedimiento a la base de datos del Padrón de Contribuyentes, con la finalidad de identificar homonimias y evitar la duplicidad de registros.

# En otros lenguajes
- JAVA [josketres/rfc-facil](https://github.com/josketres/rfc-facil)
- Ruby [acrogenesis/rfc_facil](https://github.com/acrogenesis/rfc_facil)