using Treehoot.Domain.Models;

namespace Treehoot.Application.Services.IServices;

public interface IAnswerService
{
    Answer GetAnswer(int answerId);
    List<Answer> GetQuestionAnswers(int questionId);
}
