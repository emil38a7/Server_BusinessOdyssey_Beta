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
    [Route("api/StudentGroups")]
    public class StudentGroupsController : Controller
    {
        private readonly DB_BusinessOdyssey_BetaContext _context;

        public StudentGroupsController(DB_BusinessOdyssey_BetaContext context)
        {
            _context = context;
        }

        // GET: api/StudentGroups
        [HttpGet]
        public IEnumerable<StudentGroup> GetStudentGroup()
        {
            return _context.StudentGroup;
        }

        // GET: api/StudentGroups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentGroup([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentGroup = await _context.StudentGroup.SingleOrDefaultAsync(m => m.SGroupName == id);

            if (studentGroup == null)
            {
                return NotFound();
            }

            return Ok(studentGroup);
        }

        // PUT: api/StudentGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentGroup([FromRoute] string id, [FromBody] StudentGroup studentGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentGroup.SGroupName)
            {
                return BadRequest();
            }

            _context.Entry(studentGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentGroupExists(id))
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

        // POST: api/StudentGroups
        [HttpPost]
        public async Task<IActionResult> PostStudentGroup([FromBody] StudentGroup studentGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StudentGroup.Add(studentGroup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentGroupExists(studentGroup.SGroupName))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentGroup", new { id = studentGroup.SGroupName }, studentGroup);
        }

        // DELETE: api/StudentGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentGroup([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentGroup = await _context.StudentGroup.SingleOrDefaultAsync(m => m.SGroupName == id);
            if (studentGroup == null)
            {
                return NotFound();
            }

            _context.StudentGroup.Remove(studentGroup);
            await _context.SaveChangesAsync();

            return Ok(studentGroup);
        }

        private bool StudentGroupExists(string id)
        {
            return _context.StudentGroup.Any(e => e.SGroupName == id);
        }
    }
}