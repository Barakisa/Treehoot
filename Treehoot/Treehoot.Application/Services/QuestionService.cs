using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Treehoot.Application.Data;
using Treehoot.Application.Exceptions;
using Treehoot.Application.Helpers;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

#nullable enable

public class QuestionService : IQuestionService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public QuestionService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<Question?> GetSingle(int questionId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var dbcontext = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return await dbcontext.Question
                            .Include(q => q.Stage)
                            .SingleOrDefaultAsync(q => q.Id == questionId);
        }
    }

    public async Task<List<Question>?> GetStageQuestions(int stageId) 
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var dbcontext = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            var stage = await dbcontext.Stage.FindAsync(stageId);
            if (stage == null) 
            {
                throw new NotFoundException("Stage", stageId);
            }
            return await dbcontext.Question
                            .Include(q => q.Stage)
                            .Where(q => q.Stage.Id == stageId)
                            .ToListAsync();
        }
    }

    public async Task<Question?> GetSingleFull(int questionId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var dbcontext = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return await dbcontext.Question
                            .Include(q => q.Answers)
                            .Include(q => q.Stage)
                            .SingleOrDefaultAsync(q => q.Id == questionId) ;
        }
    }

}
