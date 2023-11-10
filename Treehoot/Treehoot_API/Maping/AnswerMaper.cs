using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Treehoot.Api.Data;
using Treehoot.Domain.Models;

namespace Treehoot.Api.Maping
{
    public class Maper
    {
        public async Task<ActionResult<IEnumerable<Answer>>> AnswerMaper(TreehootApiContext _context)
        {
            if (_context.Answer == null)
            {
                return NotFound();
            }
            return await _context.Answer.ToListAsync();
        }
    }
}
