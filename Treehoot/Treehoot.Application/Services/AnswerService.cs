using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class AnswerService
{
    private string fakeDbPath = "FakeDb/AnswersTable.json";

    public Answer GetAnswer(int answerId)
    {
        return DataLoader.GetEntity<Answer>(fakeDbPath, answerId);
    }

    public List<Answer> GetQuestionAnswers(int questionId)
    {

        var jsonText = File.ReadAllText(fakeDbPath);
        var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);

        var answers = data.Answers.Where(a => a.QuestionId == questionId).ToList();
        return answers;
    }
}
