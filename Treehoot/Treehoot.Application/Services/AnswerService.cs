using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class AnswerService
{
    private string fakeDbPath = "FakeDb/AnswersTable.json";

    // can handle single / multiple answer requests
    public List<Answer> GetAnswers(string answerIdsString)
    {
        try
        {
            var answerIds = answerIdsString.Split(',').Select(int.Parse).ToList();
            var answers = new List<Answer>();
            foreach(var answerId in answerIds)
            {
                // can i call the other method, or should this be self contained?
                var jsonText = File.ReadAllText(fakeDbPath);

                var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
                var allAnswers = data.Answers.ToList();

                var answer = allAnswers.SingleOrDefault(a => a.Id == answerId);

                if (answer != null)
                { 
                    answers.Add(answer);
                }
            }

            return answers;
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
