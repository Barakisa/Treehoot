using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Treehoot.Api.Data;
using Treehoot.Domain.Models;
using Treehoot.Api.Maping;

namespace Treehoot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EFAnswersController : ControllerBase
    {
        private readonly TreehootApiContext _context;
        private Maper _maps;

        public EFAnswersController(TreehootApiContext context, Maper maps)
        {
            _context = context;
            _maps = maps;
        }

        // GET: api/EFAnswers
        [HttpGet]
        public ActionResult<IEnumerable<Answer>> GetAnswer()
        {
            return _maps(_context);
        }

        // GET: api/EFAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetAnswer(int id)
        {
            if (_context.Answer == null)
            {
                return NotFound();
            }
            var answer = await _context.Answer.FindAsync(id);

            if (answer == null)
            {
                return NotFound();
            }

            return answer;
        }

        // PUT: api/EFAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswer(int id, Answer answer)
        {
            if (id != answer.Id)
            {
                return BadRequest();
            }

            _context.Entry(answer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerExists(id))
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

        // POST: api/EFAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Answer>> PostAnswer(Answer answer)
        {
            if (_context.Answer == null)
            {
                return Problem("Entity set 'TreehootApiContext.Answer'  is null.");
            }
            _context.Answer.Add(answer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnswer", new { id = answer.Id }, answer);
        }

        // DELETE: api/EFAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            if (_context.Answer == null)
            {
                return NotFound();
            }
            var answer = await _context.Answer.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            _context.Answer.Remove(answer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnswerExists(int id)
        {
            return (_context.Answer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
