using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class AnswerService
{
    private string fakeDbPath = "FakeDb/AnswersTable.json";

    public Answer GetAnswer(int answerId)
    {
        try
        {
            var jsonText = File.ReadAllText(fakeDbPath);

            var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
            var allAnswers = data.Answers.ToList();

            var answer = allAnswers.SingleOrDefault(a => a.Id == answerId);

            return answer;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
            throw; // rethrow the exception so it can be handled in the controller
        }
        catch (Exception e)
        {
            throw new Exception($"Error: {e.Message}");
        }
    }
}
