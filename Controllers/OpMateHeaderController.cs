using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace sithecapi.Controllers;

[ApiController]
[Route("[controller]")]
public class OpMateHeaderController : ControllerBase
{
    [HttpGet(Name = "OpMateHeader")]
    public ActionResult<object> OperacionMatematicaHeader([FromHeader] int tipo, [FromHeader] float valor1, [FromHeader] float valor2)
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
