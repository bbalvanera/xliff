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
    public class ModulesController : ControllerBase
    {
        private readonly LiteralsContext _context;

        public ModulesController(LiteralsContext context)
        {
            _context = context;
        }

        // GET: api/Modules
        [HttpGet]
        public IEnumerable<Modules> Getmodules()
        {
            return _context.modules;
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModules([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modules = await _context.modules.FindAsync(id);

            if (modules == null)
            {
                return NotFound();
            }

            return Ok(modules);
        }

        // PUT: api/Modules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModules([FromRoute] Guid id, [FromBody] Modules modules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modules.ModuleID)
            {
                return BadRequest();
            }

            _context.Entry(modules).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModulesExists(id))
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

        // POST: api/Modules
        [HttpPost]
        public async Task<IActionResult> PostModules([FromBody] Modules modules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.modules.Add(modules);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModules", new { id = modules.ModuleID }, modules);
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModules([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modules = await _context.modules.FindAsync(id);
            if (modules == null)
            {
                return NotFound();
            }

            _context.modules.Remove(modules);
            await _context.SaveChangesAsync();

            return Ok(modules);
        }

        private bool ModulesExists(Guid id)
        {
            return _context.modules.Any(e => e.ModuleID == id);
        }
    }
}