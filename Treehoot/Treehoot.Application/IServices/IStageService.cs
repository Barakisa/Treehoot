using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices;

public interface IStageService
{
    Task<Stage?> GetStage(int stageId);
    Task<List<Stage>?> GetQuizStages(int quizId);
    Task<Stage?> GetStageFull(int stageId);
}
