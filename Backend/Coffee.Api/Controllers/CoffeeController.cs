
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coffee.Api.Models;

[ApiController]
[Route("api/coffees")]
public class CoffeeController : ControllerBase
{
    private readonly CoffeeContext _context;

    public CoffeeController(CoffeeContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CoffeeModel>>> GetCoffees()
    {
        return await _context.Coffees.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<CoffeeModel>>> AddCoffee(CoffeeModel coffee)
    {
        _context.Coffees.Add(coffee);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<IEnumerable<CoffeeModel>>> UpdateCoffee(int id, CoffeeModel coffee)
    {
        try
        {
            await _context.Coffees.Where(c => c.Id == id).ExecuteUpdateAsync(c => c
                .SetProperty(c => c.Name, coffee.Name)
                .SetProperty(c => c.Texture, coffee.Texture)
                .SetProperty(c => c.Description, coffee.Description)
                .SetProperty(c => c.Roast, coffee.Roast)
                .SetProperty(c => c.Origin, coffee.Origin)
                .SetProperty(c => c.Process, coffee.Process)
                .SetProperty(c => c.Brand, coffee.Brand)
                .SetProperty(c => c.Price, coffee.Price));
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Coffees.Any(c => c.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        await _context.SaveChangesAsync();
        return Ok();
    }

/*    [HttpGet("{id}")]
    public async Task<ActionResult<CoffeeModel>> GetCoffees(int id)
    {
        return await _context.Coffees.FindAsync(id);
    }*/

}
