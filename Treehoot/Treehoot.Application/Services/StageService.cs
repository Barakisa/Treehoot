using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Treehoot.Application.Data;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class StageService : IStageService
{
    public event EventHandler<List<Stage>> StageReturned;

    protected virtual void OnStageReturned(List<Stage> stages)
    {
        if(StageReturned != null) 
            StageReturned(this, stages);
    }

    private readonly IServiceScopeFactory _scopeFactory;

    public StageService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<Stage?> GetSingle(int stageId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var dbcontext = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            var stage = await dbcontext.Stage
                            .Include(s => s.Quiz)
                            .SingleOrDefaultAsync(a => a.Id == stageId);
            
            OnStageReturned(new List<Stage> { stage });

            return stage;
        }
    }

    public async Task<List<Stage>?> GetQuizStages(int quizId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var dbcontext = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            var stages =  await dbcontext.Stage
                            .Include(s => s.Quiz)
                            .Where(a => a.Quiz.Id == quizId).ToListAsync();

            OnStageReturned(stages);

            return stages;
        }
    }

    public async Task<Stage?> GetSingleFull(int stageId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var dbcontext = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            var stage = await dbcontext.Stage
                            .Include(s => s.Questions)
                                .ThenInclude(q => q.Answers)
                            .Include(s => s.Quiz)
                            .SingleOrDefaultAsync(s => s.Id == stageId);

            OnStageReturned(new List<Stage> { stage });

            return stage;
        }
    }
    
}
