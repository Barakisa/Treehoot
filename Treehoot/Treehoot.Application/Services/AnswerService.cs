using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Application.Services.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class AnswerService : IAnswerService
{
    private string fakeDbPath = "FakeDb/AnswersTable.json";

    public Answer GetAnswer(int answerId)
    {
        return DataLoader.GetEntity<Answer>(fakeDbPath, answerId);
    }

    public List<Answer> GetQuestionAnswers(int questionId)
    {

        return new List<Answer>();
    }
}
