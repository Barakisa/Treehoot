using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices;

public interface IStageService
{
    event EventHandler<int> StageReturned;
    Task<Stage?> GetSingle(int stageId);
    Task<List<Stage>?> GetQuizStages(int quizId);
    Task<Stage?> GetSingleFull(int stageId);
}
