using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services.IServices;

public interface IStageService
{
    Stage GetStage(int stageId);
    List<Stage> GetQuizStages(int quizId);
    StageFull GetStageFull(int stageId);
}
