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
    [Route("api/Judges")]
    public class JudgesController : Controller
    {
        private readonly DB_BusinessOdyssey_BetaContext _context;

        public JudgesController(DB_BusinessOdyssey_BetaContext context)
        {
            _context = context;
        }

        // GET: api/Judges
        [HttpGet]
        public IEnumerable<Judge> GetJudge()
        {
            return _context.Judge;
        }

        // GET: api/Judges/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJudge([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var judge = await _context.Judge.SingleOrDefaultAsync(m => m.JudgeId == id);

            if (judge == null)
            {
                return NotFound();
            }

            return Ok(judge);
        }

        // PUT: api/Judges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJudge([FromRoute] int id, [FromBody] Judge judge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != judge.JudgeId)
            {
                return BadRequest();
            }

            _context.Entry(judge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JudgeExists(id))
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

        // POST: api/Judges
        [HttpPost]
        public async Task<IActionResult> PostJudge([FromBody] Judge judge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Judge.Add(judge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJudge", new { id = judge.JudgeId }, judge);
        }

        // DELETE: api/Judges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJudge([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var judge = await _context.Judge.SingleOrDefaultAsync(m => m.JudgeId == id);
            if (judge == null)
            {
                return NotFound();
            }

            _context.Judge.Remove(judge);
            await _context.SaveChangesAsync();

            return Ok(judge);
        }

        private bool JudgeExists(int id)
        {
            return _context.Judge.Any(e => e.JudgeId == id);
        }
    }
}