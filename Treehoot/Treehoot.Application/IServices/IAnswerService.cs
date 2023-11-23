using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices;

public interface IAnswerService
{
    Task<Answer?> GetSingle(int answerId);
    Task<List<Answer>?> GetQuestionAnswers(int questionId);
}
