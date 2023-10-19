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
}
