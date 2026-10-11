
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
                .SetProperty(c => c.Name, c => string.IsNullOrWhiteSpace(coffee.Name) ? c.Name : coffee.Name)
                .SetProperty(c => c.Texture, c => string.IsNullOrWhiteSpace(coffee.Texture) ? c.Texture : coffee.Texture)
                .SetProperty(c => c.Description, c => string.IsNullOrWhiteSpace(coffee.Description) ? c.Description : coffee.Description)
                .SetProperty(c => c.Roast, c => string.IsNullOrWhiteSpace(coffee.Roast) ? c.Roast : coffee.Roast)
                .SetProperty(c => c.Origin, c => string.IsNullOrWhiteSpace(coffee.Origin) ? c.Origin : coffee.Origin)
                .SetProperty(c => c.Process, c => string.IsNullOrWhiteSpace(coffee.Process) ? c.Process : coffee.Process)
                .SetProperty(c => c.Brand, c => string.IsNullOrWhiteSpace(coffee.Brand) ? c.Brand : coffee.Brand)
                .SetProperty(c => c.Price, c => string.IsNullOrWhiteSpace(coffee.Price.ToString()) ? c.Price : coffee.Price));
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

    [HttpDelete("{id}")]
    public async Task<ActionResult<IEnumerable<CoffeeModel>>> DeleteCoffee(int id)
    {
        try
        {
            if (!_context.Coffees.Any(c => c.Id == id))
            {
                return NotFound();
            }
            await _context.Coffees.Where(c => c.Id == id).ExecuteDeleteAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
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
