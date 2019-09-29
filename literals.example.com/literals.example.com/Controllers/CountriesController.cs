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
    public class CountriesController : ControllerBase
    {
        private readonly LiteralsContext _context;

        public CountriesController(LiteralsContext context)
        {
            _context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public IEnumerable<Countries> Getcountries()
        {
            return _context.countries;
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountries([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var countries = await _context.countries.FindAsync(id);

            if (countries == null)
            {
                return NotFound();
            }

            return Ok(countries);
        }

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountries([FromRoute] Guid id, [FromBody] Countries countries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != countries.CountryID)
            {
                return BadRequest();
            }

            _context.Entry(countries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountriesExists(id))
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

        // POST: api/Countries
        [HttpPost]
        public async Task<IActionResult> PostCountries([FromBody] Countries countries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.countries.Add(countries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountries", new { id = countries.CountryID }, countries);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountries([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var countries = await _context.countries.FindAsync(id);
            if (countries == null)
            {
                return NotFound();
            }

            _context.countries.Remove(countries);
            await _context.SaveChangesAsync();

            return Ok(countries);
        }

        private bool CountriesExists(Guid id)
        {
            return _context.countries.Any(e => e.CountryID == id);
        }
    }
}