
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

/*    [HttpGet("{id}")]
    public async Task<ActionResult<CoffeeModel>> GetCoffees(int id)
    {
        return await _context.Coffees.FindAsync(id);
    }*/

}
