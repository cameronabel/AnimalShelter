using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterApi.Models;

namespace ShelterApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
  private readonly ShelterApiContext _context;

  public AnimalsController(ShelterApiContext context)
  {
    _context = context;
  }

  // GET: api/Reviews
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Animal>>> GetReviews([FromQuery] PaginationFilter filter)
  {
    PaginationFilter validFilter = new PaginationFilter();
    if (filter != null)
    {
      validFilter.PageNumber = filter.PageNumber;
      validFilter.PageSize = filter.PageSize;
    }
    List<Animal> PagedResponse = await _context.Animals
      .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
      .Take(validFilter.PageSize)
      .ToListAsync();
    int totalRecords = await _context.Animals.CountAsync();
    return Ok(new PagedResponse<List<Animal>>(PagedResponse, validFilter.PageNumber, validFilter.PageSize, totalRecords));
  }

  // GET: api/Animals/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Animal>> GetAnimal(int id)
  {
    var animal = await _context.Animals.FindAsync(id);

    if (animal == null)
    {
      return NotFound(new Response<Animal>() { Succeeded = false, Message = "Animal not found" });
    }

    return Ok(new Response<Animal>(animal));
  }

  // PUT: api/Animals/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutAnimal(int id, Animal animal)
  {
    if (id != animal.AnimalId)
    {
      return BadRequest();
    }

    _context.Entry(animal).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!AnimalExists(id))
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

  // POST: api/Animals
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
  {
    _context.Animals.Add(animal);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetAnimal", new { id = animal.AnimalId }, animal);
  }

  // DELETE: api/Animals/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteAnimal(int id)
  {
    var animal = await _context.Animals.FindAsync(id);
    if (animal == null)
    {
      return NotFound();
    }

    _context.Animals.Remove(animal);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool AnimalExists(int id)
  {
    return _context.Animals.Any(e => e.AnimalId == id);
  }
}
