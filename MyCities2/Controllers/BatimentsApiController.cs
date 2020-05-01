using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCities2.Models;

namespace MyCities2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatimentsApiController : ControllerBase
    {
        private readonly MyCitiesDBContext _context;

        public BatimentsApiController(MyCitiesDBContext context)
        {
            _context = context;
        }

        // GET: api/BatimentsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batiment>>> GetBatiments()
        {
            return await _context.Batiments.ToListAsync();
        }

        // GET: api/BatimentsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Batiment>> GetBatiment(int id)
        {
            var batiment = await _context.Batiments.FindAsync(id);

            if (batiment == null)
            {
                return NotFound();
            }

            return batiment;
        }

        // PUT: api/BatimentsApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatiment(int id, Batiment batiment)
        {
            if (id != batiment.Id)
            {
                return BadRequest();
            }

            _context.Entry(batiment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatimentExists(id))
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

        // POST: api/BatimentsApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Batiment>> PostBatiment(Batiment batiment)
        {
            _context.Batiments.Add(batiment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatiment", new { id = batiment.Id }, batiment);
        }

        // DELETE: api/BatimentsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Batiment>> DeleteBatiment(int id)
        {
            var batiment = await _context.Batiments.FindAsync(id);
            if (batiment == null)
            {
                return NotFound();
            }

            _context.Batiments.Remove(batiment);
            await _context.SaveChangesAsync();

            return batiment;
        }

        private bool BatimentExists(int id)
        {
            return _context.Batiments.Any(e => e.Id == id);
        }
    }
}
