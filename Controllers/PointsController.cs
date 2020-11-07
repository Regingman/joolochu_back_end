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
    public class PointsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PointsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Points
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Point>>> GetPoints()
        {
            return await _context.Points
                .ToListAsync();
        }

        // GET: api/Points/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Point>> GetPoint(int id)
        {
            var point =  await _context.Points
                .Where(p => p.Id == id)
                .Include(p => p.District)
                .Include(p => p.Village)
                .FirstOrDefaultAsync();


            if (point == null)
            {
                return NotFound();
            }

            return point;
        }

        // PUT: api/Points/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoint(int id, Point point)
        {
            if (id != point.Id)
            {
                return BadRequest();
            }

            _context.Entry(point).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointExists(id))
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

        // POST: api/Points
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Point>> PostPoint(Point point)
        {
            _context.Points.Add(point);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoint", new { id = point.Id }, point);
        }

        // DELETE: api/Points/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Point>> DeletePoint(int id)
        {
            var point = await _context.Points.FindAsync(id);
            if (point == null)
            {
                return NotFound();
            }

            _context.Points.Remove(point);
            await _context.SaveChangesAsync();

            return point;
        }

        private bool PointExists(int id)
        {
            return _context.Points.Any(e => e.Id == id);
        }
    }
}
