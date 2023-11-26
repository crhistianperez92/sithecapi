using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using sithecapi.schema;

namespace sithecapi.Controllers;

[ApiController]
[Route("[controller]")]
public class HumanoController : ControllerBase
{
    private static readonly string[] Nombres = new[]
    {
        "Juan", "Maria", "Rosa", "Manuel", "Luis Manuel", "Kilian", "Marcos", "Dorian", "Julian", "Carlos"
    };
    
    private static readonly string[] Genero = new[]
    {
        "Hombre", "Mujer"
    };
    
    [HttpGet(Name = "GetHumanos")]
    public IEnumerable<HumanoSchema> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new HumanoSchema
        {
            Id=Random.Shared.Next(Nombres.Length),
            Nombre = Nombres[Random.Shared.Next(Nombres.Length)],
            Edad = Random.Shared.Next(20, 55),
            Sexo = Genero[Random.Shared.Next(Genero.Length)],
            Altura = Random.Shared.Next(140, 200),
            Peso = Random.Shared.Next(60, 100),
        })
        .ToArray();
    }
}