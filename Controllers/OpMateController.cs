using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace sithecapi.Controllers;

[ApiController]
[Route("[controller]")]
public class OpMateController : ControllerBase
{
    [HttpPost(Name = "OpMate")]
    public ActionResult<object> OperacionMatematica([FromQuery] int tipo, [FromQuery] float valor1, [FromQuery] float valor2)
    {
        float result = 0;
        if(tipo == 1) // Suma
        {
            result = valor1 + valor2;
        }
        if(tipo == 2) // Resta
        {
            result = valor1 - valor2;
        }
        if(tipo == 3) // Multiplicacion
        {
            result = valor1 * valor2;
        }
        if(tipo == 4) // Division
        {
            result = valor1 / valor2;
        }
        var jsonResponse = new {
            resultado=result
        };
        return Ok(jsonResponse);
    }
}
