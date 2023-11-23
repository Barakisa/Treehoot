using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices;

public interface IAnswerService
{
    Answer GetAnswer(int answerId);
    List<Answer> GetQuestionAnswers(int questionId);
}
