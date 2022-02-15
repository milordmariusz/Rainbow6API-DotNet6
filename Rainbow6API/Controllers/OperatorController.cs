using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Rainbow6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        private readonly DataContext _context;

        public OperatorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Operator>>> Get()
        {
            return Ok(await _context.Operators.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Operator>> Get(int id)
        {
            var op = await _context.Operators.FindAsync(id);
            if (op == null)
            {
                return BadRequest("Operator not found.");
            }
            return Ok(op);
        }

        [HttpPost]
        public async Task<ActionResult<List<Operator>>> AddOperator(Operator op)
        {
           _context.Operators.Add(op);
           await _context.SaveChangesAsync();

           return Ok(await _context.Operators.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Operator>>> UpdateOperator(Operator request)
        {
            var dbop = await _context.Operators.FindAsync(request.Id);
            if (dbop == null)
            {
                return BadRequest("Operator not found.");
            }

            dbop.Name = request.Name;
            dbop.FirstName = request.FirstName;
            dbop.LastName = request.LastName;
            dbop.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.Operators.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Operator>>> Delete(int id)
        {
            var dbop = await _context.Operators.FindAsync(id);
            if (dbop == null)
            {
                return BadRequest("Operator not found.");
            }

            _context.Operators.Remove(dbop);
            await _context.SaveChangesAsync();

            return Ok(await _context.Operators.ToListAsync());
        }

    }
}
