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
    public class LiteralTranslationsController : ControllerBase
    {
        private readonly LiteralsContext _context;

        public LiteralTranslationsController(LiteralsContext context)
        {
            _context = context;
        }

        // GET: api/LiteralTranslations
        [HttpGet]
        public IEnumerable<LiteralTranslations> GetliteralTranslations()
        {
            return _context.literalTranslations;
        }

        // GET: api/LiteralTranslations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLiteralTranslations([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var literalTranslations = await _context.literalTranslations.FindAsync(id);

            if (literalTranslations == null)
            {
                return NotFound();
            }

            return Ok(literalTranslations);
        }

        // PUT: api/LiteralTranslations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLiteralTranslations([FromRoute] Guid id, [FromBody] LiteralTranslations literalTranslations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != literalTranslations.LiteralTranslationID)
            {
                return BadRequest();
            }

            _context.Entry(literalTranslations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiteralTranslationsExists(id))
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

        // POST: api/LiteralTranslations
        [HttpPost]
        public async Task<IActionResult> PostLiteralTranslations([FromBody] LiteralTranslations literalTranslations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.literalTranslations.Add(literalTranslations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLiteralTranslations", new { id = literalTranslations.LiteralTranslationID }, literalTranslations);
        }

        // DELETE: api/LiteralTranslations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLiteralTranslations([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var literalTranslations = await _context.literalTranslations.FindAsync(id);
            if (literalTranslations == null)
            {
                return NotFound();
            }

            _context.literalTranslations.Remove(literalTranslations);
            await _context.SaveChangesAsync();

            return Ok(literalTranslations);
        }

        private bool LiteralTranslationsExists(Guid id)
        {
            return _context.literalTranslations.Any(e => e.LiteralTranslationID == id);
        }
    }
}