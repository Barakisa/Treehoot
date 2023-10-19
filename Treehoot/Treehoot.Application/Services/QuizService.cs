using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class QuizService
{
    private string fakeDbPath = "FakeDb/QuizesTable.json";

    public Quiz GetQuiz(int quizId)
    {
        return DataLoader.GetEntity<Quiz>("FakeDb/QuizesTable.json", quizId);
    }
    public List<Quiz> GetQuizes() {
        try
        {
            var jsonText = File.ReadAllText(fakeDbPath);
            var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
            var allQuizes = data.Quizes.ToList();
            return allQuizes;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
            throw; 
        }
        catch (Exception e)
        {
            throw new Exception($"Error: {e.Message}");
        }
        
    }

    public QuizFull GetQuizFull(int quizId)
    {
        try
        {
            var gatherer = new ObjectGatherer();

            var jsonText = File.ReadAllText(fakeDbPath);

            var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
            var allQuizes = data.Quizes.ToList();

            var quiz = allQuizes.SingleOrDefault(q => q.Id == quizId);

            return gatherer.GatherQuiz(quizId);
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
