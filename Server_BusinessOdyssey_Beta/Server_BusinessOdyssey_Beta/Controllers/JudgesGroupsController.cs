using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server_BusinessOdyssey_Beta.Models;

namespace Server_BusinessOdyssey_Beta.Controllers
{
    [Produces("application/json")]
    [Route("api/JudgesGroups")]
    public class JudgesGroupsController : Controller
    {
        private readonly DB_BusinessOdyssey_BetaContext _context;

        public JudgesGroupsController(DB_BusinessOdyssey_BetaContext context)
        {
            _context = context;
        }

        // GET: api/JudgesGroups
        [HttpGet]
        public IEnumerable<JudgesGroup> GetJudgesGroup()
        {
            return _context.JudgesGroup;
        }

        // GET: api/JudgesGroups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJudgesGroup([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var judgesGroup = await _context.JudgesGroup.SingleOrDefaultAsync(m => m.JGroupName == id);

            if (judgesGroup == null)
            {
                return NotFound();
            }

            return Ok(judgesGroup);
        }

        // PUT: api/JudgesGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJudgesGroup([FromRoute] string id, [FromBody] JudgesGroup judgesGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != judgesGroup.JGroupName)
            {
                return BadRequest();
            }

            _context.Entry(judgesGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JudgesGroupExists(id))
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

        // POST: api/JudgesGroups
        [HttpPost]
        public async Task<IActionResult> PostJudgesGroup([FromBody] JudgesGroup judgesGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.JudgesGroup.Add(judgesGroup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JudgesGroupExists(judgesGroup.JGroupName))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJudgesGroup", new { id = judgesGroup.JGroupName }, judgesGroup);
        }

        // DELETE: api/JudgesGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJudgesGroup([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var judgesGroup = await _context.JudgesGroup.SingleOrDefaultAsync(m => m.JGroupName == id);
            if (judgesGroup == null)
            {
                return NotFound();
            }

            _context.JudgesGroup.Remove(judgesGroup);
            await _context.SaveChangesAsync();

            return Ok(judgesGroup);
        }

        private bool JudgesGroupExists(string id)
        {
            return _context.JudgesGroup.Any(e => e.JGroupName == id);
        }
    }
}