using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class QuestionService
{
    private string fakeDbPath = "FakeDb/QuestionsTable.json";


    // can handle single / multiple questions
    public List<Question> GetQuestions(string questionIdsString)
    {
        try
        {
            var questionIds = questionIdsString.Split(',').Select(int.Parse).ToList();
            var questions = new List<Question>();

            foreach(var questionId in questionIds)
            {
                // can i call the other method, or should this be self contained?
                var jsonText = File.ReadAllText(fakeDbPath);

                var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
                var allQuestions = data.Questions.ToList();

                var question = allQuestions.SingleOrDefault(q => q.Id == questionId);
                
                if (question != null)
                { 
                    questions.Add(question);
                }
            }

            return questions;
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
