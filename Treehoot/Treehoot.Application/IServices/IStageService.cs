using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices;

public interface IStageService
{
    Task<Stage?> GetSingle(Guid stageId);
    Task<List<Stage>?> GetQuizStages(Guid quizId);
    Task<Stage?> GetSingleFull(Guid stageId);
}
