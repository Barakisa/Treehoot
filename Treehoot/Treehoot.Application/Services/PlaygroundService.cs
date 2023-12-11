using Microsoft.EntityFrameworkCore;
using Treehoot.Application.Data;
using Treehoot.Application.Exceptions;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class PlaygroundService : IPlaygroundService
{
    private readonly TreehootApiContext _treehootApiContext;

    public PlaygroundService(TreehootApiContext treehootApiContext)
    {
        _treehootApiContext = treehootApiContext;
    }

    public async Task<Playground?> GetSingle(Guid answerId)
    {
        return await _treehootApiContext.Playground
                        .SingleOrDefaultAsync(a => a.Id == answerId);
    }

    public async Task<List<Playground>?> GetQuestionPlaygrounds(Guid questionId)
    {
        var question = await _treehootApiContext.Question.FindAsync(questionId);
        if (question == null)
        {
            throw new NotFoundException("Question", questionId);
        }
        return await _treehootApiContext.Playground
                        .Where(a => a.Question.Id == questionId)
                        .ToListAsync();
    }
}
