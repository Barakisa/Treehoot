using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class QuestionService
{
    private string fakeDbPath = "FakeDb/QuestionsTable.json";

    public Question GetQuestion(int questionId)
    {
        return DataLoader.GetEntity<Question>("FakeDb/QuestionsTable.json", questionId);
    }
    public QuestionFull GetQuestionFull(int questionId)
    {
        try
        {
            var gatherer = new ObjectGatherer();

            var jsonText = File.ReadAllText(fakeDbPath);

            var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
            var allQuestiones = data.Questions.ToList();

            var question = allQuestiones.SingleOrDefault(q => q.Id == questionId);

            return gatherer.GatherQuestion(questionId);
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
