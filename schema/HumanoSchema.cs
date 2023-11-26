using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace sithecapi.schema;

public class HumanoSchema
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public string Sexo { get; set; }

    public int Edad { get; set; }

    public float Altura {get; set;}

    public float Peso {get; set;}
}


public class HumanoInsertSchema
{
    public string Nombre { get; set; }

    public string Sexo { get; set; }

    public int Edad { get; set; }

    public float Altura {get; set;}

    public float Peso {get; set;}
}