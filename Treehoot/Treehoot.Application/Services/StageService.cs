using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Treehoot.Application.Data;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class StageService : IStageService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public StageService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<Stage?> GetStage(int stageId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var dbcontext = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return await dbcontext.Stage
                            .Include(s => s.Quiz)
                            .SingleOrDefaultAsync(a => a.Id == stageId);
        }
    }

    public async Task<List<Stage>?> GetQuizStages(int quizId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var dbcontext = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return await dbcontext.Stage
                            .Include(s => s.Quiz)
                            .Where(a => a.Quiz.Id == quizId).ToListAsync();
        }
    }

    public async Task<Stage?> GetStageFull(int stageId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var dbcontext = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return await dbcontext.Stage
                            .Include(s => s.Questions)
                            .Include(s => s.Quiz)
                            .SingleOrDefaultAsync(s => s.Id == stageId);
        }
    }
    
}
