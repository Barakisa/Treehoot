using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;
using Treehoot.Application.Data;

namespace Treehoot.Application.Services;

public class EfAnswerService
{
    private readonly TreehootApiContext _context;

    public EfAnswerService(TreehootApiContext context)
    {
        _context = context;
    }

    public Answer GetAnswer(int answerId)
    {
        return _context.Answer.First(a => a.Id == answerId);
    }

    public List<Answer> GetQuestionAnswers(int questionId)
    {

        return _context.Answer.Where(a => a.Question.Id == questionId).ToList();
    }
    /*
    public async Task<ActionResult<Answer>> AddAnswer(Answer answer)
    {
        _context.Answer.Add(answer);
        await _context.SaveChangesAsync();
        return CreatedAtAction("PostAnswer", new { id = answer.Id }, answer);
    }
    */
}
