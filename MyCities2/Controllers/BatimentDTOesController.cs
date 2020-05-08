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
    public class BatimentDTOesController : ControllerBase
    {
        private readonly MyCitiesDBContext _context;

        public BatimentDTOesController(MyCitiesDBContext context)
        {
            _context = context;
        }

        // GET: api/BatimentDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatimentDTO>>> GetBatimentDTO()
        {
            return await _context.BatimentDTO.ToListAsync();
        }

        // GET: api/BatimentDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BatimentDTO>> GetBatimentDTO(int id)
        {
            var batimentDTO = await _context.BatimentDTO.FindAsync(id);

            if (batimentDTO == null)
            {
                return NotFound();
            }

            return batimentDTO;
        }

        // PUT: api/BatimentDTOes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatimentDTO(int id, BatimentDTO batimentDTO)
        {
            if (id != batimentDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(batimentDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatimentDTOExists(id))
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

        // POST: api/BatimentDTOes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BatimentDTO>> PostBatimentDTO(BatimentDTO batimentDTO)
        {
            _context.BatimentDTO.Add(batimentDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatimentDTO", new { id = batimentDTO.Id }, batimentDTO);
        }

        // DELETE: api/BatimentDTOes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BatimentDTO>> DeleteBatimentDTO(int id)
        {
            var batimentDTO = await _context.BatimentDTO.FindAsync(id);
            if (batimentDTO == null)
            {
                return NotFound();
            }

            _context.BatimentDTO.Remove(batimentDTO);
            await _context.SaveChangesAsync();

            return batimentDTO;
        }

        private bool BatimentDTOExists(int id)
        {
            return _context.BatimentDTO.Any(e => e.Id == id);
        }
    }
}
