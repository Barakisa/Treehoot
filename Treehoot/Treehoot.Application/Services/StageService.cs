using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class StageService : IStageService
{
    private string fakeDbPath = "FakeDb/StagesTable.json";

    public Stage GetStage(int stageId)
    {
        return DataLoader.GetEntity<Stage>(fakeDbPath, stageId);
    }

    public List<Stage> GetQuizStages(int quizId) {

        var jsonText = File.ReadAllText(fakeDbPath);
        var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);

        var stages = data.Stages.Where(s=>s.QuizId == quizId).ToList();

        return stages;
    }
    
    public StageFull GetStageFull(int stageId)
    {
        return new StageFull();
    }
    
}
