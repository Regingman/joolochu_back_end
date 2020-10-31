using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using joolochu.Model;

namespace joolochu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeCarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TypeCarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TypeCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeCar>>> GetTypeCars()
        {
            return await _context.TypeCars.ToListAsync();
        }

        // GET: api/TypeCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeCar>> GetTypeCar(int id)
        {
            var typeCar = await _context.TypeCars.FindAsync(id);

            if (typeCar == null)
            {
                return NotFound();
            }

            return typeCar;
        }

        // PUT: api/TypeCars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeCar(int id, TypeCar typeCar)
        {
            if (id != typeCar.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeCarExists(id))
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

        // POST: api/TypeCars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TypeCar>> PostTypeCar(TypeCar typeCar)
        {
            _context.TypeCars.Add(typeCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeCar", new { id = typeCar.Id }, typeCar);
        }

        // DELETE: api/TypeCars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeCar>> DeleteTypeCar(int id)
        {
            var typeCar = await _context.TypeCars.FindAsync(id);
            if (typeCar == null)
            {
                return NotFound();
            }

            _context.TypeCars.Remove(typeCar);
            await _context.SaveChangesAsync();

            return typeCar;
        }

        private bool TypeCarExists(int id)
        {
            return _context.TypeCars.Any(e => e.Id == id);
        }
    }
}
