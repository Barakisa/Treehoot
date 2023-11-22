using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Treehoot.Application.Data;
using Treehoot.Application.Helpers;
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

    public Stage GetStage(int stageId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return context.Stage.Single(a => a.Id == stageId);
        }
    }

    public List<Stage> GetQuizStages(int quizId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return context.Stage.Where(a => a.Quiz.Id == quizId).ToList();
        }
    }

    //broken
    public StageFull GetStageFull(int stageId)
    {
        return new StageFull();
    }
    
}
