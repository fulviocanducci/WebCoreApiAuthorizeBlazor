using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ReferencesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ReferencesController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<References> GetReferences() => _context.References;

        // GET: api/References/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReferences([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var references = await _context.References.FindAsync(id);

            if (references == null)
            {
                return NotFound();
            }

            return Ok(references);
        }

        // PUT: api/References/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReferences([FromRoute] int id, [FromBody] References references)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != references.Id)
            {
                return BadRequest();
            }

            _context.Entry(references).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferencesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(references);
        }

        // POST: api/References
        [HttpPost]
        public async Task<IActionResult> PostReferences([FromBody] References references)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.References.Add(references);
            await _context.SaveChangesAsync();

            return Ok(references);
        }

        // DELETE: api/References/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReferences([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var references = await _context.References.FindAsync(id);
            if (references == null)
            {
                return NotFound();
            }

            _context.References.Remove(references);
            await _context.SaveChangesAsync();

            return Ok(references);
        }

        private bool ReferencesExists(int id)
        {
            return _context.References.Any(e => e.Id == id);
        }
    }
}