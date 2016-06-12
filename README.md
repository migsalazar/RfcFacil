
# RfcFacil .NET

![](https://raw.githubusercontent.com/migsalazar/RfcFacil/master/logo.png)

Librería para el cálculo del RFC (Registro Federal de Contribuyentes) del SAT (Servicio de Administración Tributaria) en México - C# .NET

# Uso

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

# En otros lenguajes

# Licencia