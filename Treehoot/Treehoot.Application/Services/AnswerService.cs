using Microsoft.EntityFrameworkCore;
using Treehoot.Application.Data;
using Treehoot.Application.Exceptions;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class AnswerService : IAnswerService
{
    private readonly TreehootApiContext _treehootApiContext;

    public AnswerService(TreehootApiContext treehootApiContext)
    {
        _treehootApiContext = treehootApiContext;
    }

    public async Task<Answer?> GetSingle(Guid answerId)
    {
        return await _treehootApiContext.Answer
                        .SingleOrDefaultAsync(a => a.Id == answerId);
    }

    public async Task<List<Answer>?> GetQuestionAnswers(Guid questionId)
    {
        var question = await _treehootApiContext.Question.FindAsync(questionId);
        if (question == null)
        {
            throw new NotFoundException("Question", questionId);
        }
        return await _treehootApiContext.Answer
                        .Where(a => a.Question.Id == questionId)
                        .ToListAsync();
    }
}
