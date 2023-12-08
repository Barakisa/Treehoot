using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices;

public interface IAnswerService
{
    Task<Answer?> GetSingle(Guid answerId);
    Task<List<Answer>?> GetQuestionAnswers(Guid questionId);
}
