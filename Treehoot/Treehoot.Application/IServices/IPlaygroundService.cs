using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices;

public interface IPlaygroundService
{
    Task<Answer?> GetSingle(Guid answerId);
    Task<List<Answer>?> GetQuestionAnswers(Guid questionId);
}
