using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sithecapi;
using sithecapi.models;
using sithecapi.schema;

[Route("[controller]")]
[ApiController]
public class HumanosController : ControllerBase
{
    private readonly AppDbContext dbconn;

    public HumanosController(AppDbContext db)
    {
        dbconn = db;
    }

    private bool ExisteHumano(int id)
    {
        return dbconn.Humanos.Any(e => e.Id == id);
    }

    // GET: Humanos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HumanoModel>>> GetHumanos()
    {
        return await dbconn.Humanos.ToListAsync();
    }

    // GET: Humanos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<HumanoModel>> GetPersona(int id)
    {
        var persona = await dbconn.Humanos.FindAsync(id);

        if (persona == null)
        {
            return NotFound();
        }

        return persona;
    }
    [HttpPost]
    [ProducesResponseType(typeof(HumanoInsertSchema), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HumanoModel>> CrearPersona([FromBody] HumanoModel nuevoHumano)
    {
        if (ModelState.IsValid)
        {
            dbconn.Humanos.Add(nuevoHumano);
            await dbconn.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = nuevoHumano.Id }, nuevoHumano);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(HumanoInsertSchema), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ActualizarPersona(int id, [FromBody] HumanoModel actualizarHumano)
    {
        if (id != actualizarHumano.Id)
        {
            return BadRequest();
        }

        dbconn.Entry(actualizarHumano).State = EntityState.Modified;

        try
        {
            await dbconn.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ExisteHumano(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

}
