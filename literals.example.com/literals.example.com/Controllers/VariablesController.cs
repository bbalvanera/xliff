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
    public class VariablesController : ControllerBase
    {
        private readonly LiteralsContext _context;

        public VariablesController(LiteralsContext context)
        {
            _context = context;
        }

        // GET: api/Variables
        [HttpGet]
        public IEnumerable<Variables> Getvariables()
        {
            return _context.variables;
        }

        // GET: api/Variables/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVariables([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var variables = await _context.variables.FindAsync(id);

            if (variables == null)
            {
                return NotFound();
            }

            return Ok(variables);
        }

        // PUT: api/Variables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVariables([FromRoute] Guid id, [FromBody] Variables variables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != variables.VariableID)
            {
                return BadRequest();
            }

            _context.Entry(variables).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VariablesExists(id))
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

        // POST: api/Variables
        [HttpPost]
        public async Task<IActionResult> PostVariables([FromBody] Variables variables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.variables.Add(variables);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVariables", new { id = variables.VariableID }, variables);
        }

        // DELETE: api/Variables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVariables([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var variables = await _context.variables.FindAsync(id);
            if (variables == null)
            {
                return NotFound();
            }

            _context.variables.Remove(variables);
            await _context.SaveChangesAsync();

            return Ok(variables);
        }

        private bool VariablesExists(Guid id)
        {
            return _context.variables.Any(e => e.VariableID == id);
        }
    }
}