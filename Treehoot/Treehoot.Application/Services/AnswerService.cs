using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Treehoot.Application.Data;
using Treehoot.Application.Exceptions;
using Treehoot.Application.Helpers;
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

    public async Task<Answer?> GetSingle(int answerId)
    {
        return await _treehootApiContext.Answer
                        .SingleOrDefaultAsync(a => a.Id == answerId);
    }

    public async Task<List<Answer>?> GetQuestionAnswers(int questionId)
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
