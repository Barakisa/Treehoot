using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices;

public interface IQuestionService
{
    Task<Question?> GetSingle(Guid questionId);
    Task<List<Question>?> GetStageQuestions(Guid stageId);
    Task<Question?> GetSingleFull(Guid questionId);
}
