using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Treehoot.Application.Data;
using Treehoot.Application.Helpers;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class AnswerService : IAnswerService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public AnswerService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<Answer?> GetSingle(int answerId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var dbcontext = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return await dbcontext.Answer
                            .SingleOrDefaultAsync(a => a.Id == answerId);
        }
    }

    public async Task<List<Answer>?> GetQuestionAnswers(int questionId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var dbcontext = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return await dbcontext.Answer
                            .Where(a => a.Question.Id == questionId)
                            .ToListAsync();
        }
    }
}
