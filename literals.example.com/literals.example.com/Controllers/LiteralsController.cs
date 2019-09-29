using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using literals.example.com.Models;

namespace literals.example.com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiteralsController : ControllerBase
    {
        private readonly LiteralsContext _context;

        public LiteralsController(LiteralsContext context)
        {
            _context = context;
        }

        // GET: api/Literals
        [HttpGet]
        public IEnumerable<Literals> Getliterals()
        {
            return _context.literals;
        }

        // GET: api/Literals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLiterals([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var literals = await _context.literals.FindAsync(id);

            if (literals == null)
            {
                return NotFound();
            }

            return Ok(literals);
        }

        // PUT: api/Literals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLiterals([FromRoute] Guid id, [FromBody] Literals literals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != literals.LiteralID)
            {
                return BadRequest();
            }

            _context.Entry(literals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiteralsExists(id))
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

        // POST: api/Literals
        [HttpPost]
        public async Task<IActionResult> PostLiterals([FromBody] Literals literals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.literals.Add(literals);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLiterals", new { id = literals.LiteralID }, literals);
        }

        // DELETE: api/Literals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLiterals([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var literals = await _context.literals.FindAsync(id);
            if (literals == null)
            {
                return NotFound();
            }

            _context.literals.Remove(literals);
            await _context.SaveChangesAsync();

            return Ok(literals);
        }

        private bool LiteralsExists(Guid id)
        {
            return _context.literals.Any(e => e.LiteralID == id);
        }
    }
}