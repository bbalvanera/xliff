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
    public class LanguagesController : ControllerBase
    {
        private readonly LiteralsContext _context;

        public LanguagesController(LiteralsContext context)
        {
            _context = context;
        }

        // GET: api/Languages
        [HttpGet]
        public IEnumerable<Languages> Getlanguages()
        {
            return _context.languages;
        }

        // GET: api/Languages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguages([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var languages = await _context.languages.FindAsync(id);

            if (languages == null)
            {
                return NotFound();
            }

            return Ok(languages);
        }

        // PUT: api/Languages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguages([FromRoute] Guid id, [FromBody] Languages languages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != languages.LanguageID)
            {
                return BadRequest();
            }

            _context.Entry(languages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguagesExists(id))
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

        // POST: api/Languages
        [HttpPost]
        public async Task<IActionResult> PostLanguages([FromBody] Languages languages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.languages.Add(languages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanguages", new { id = languages.LanguageID }, languages);
        }

        // DELETE: api/Languages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguages([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var languages = await _context.languages.FindAsync(id);
            if (languages == null)
            {
                return NotFound();
            }

            _context.languages.Remove(languages);
            await _context.SaveChangesAsync();

            return Ok(languages);
        }

        private bool LanguagesExists(Guid id)
        {
            return _context.languages.Any(e => e.LanguageID == id);
        }
    }
}