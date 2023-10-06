using System.Text.Json;
using Treehoot_API.Models;

namespace Treehoot_API.Services
{
    public class QuestionService
    {
        private string fakeDbPath = "FakeDb/QuestionsTable.json";

        // single question
        public Question GetQuestion(int questionId)
        {
            try
            {
                var jsonText = File.ReadAllText(fakeDbPath);

                var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
                var allQuestions = data.Questions.ToList();

                var question = allQuestions.SingleOrDefault(q => q.Id == questionId);
                
                return question;
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

        // muiltiple questions
        public List<Question> GetQuestions(string questionIdsString)
        {
            try
            {
                var questionIds = questionIdsString.Split(',').Select(int.Parse).ToList();
                var questions = new List<Question>();
                foreach(var id in questionIds)
                {
                    // can i call the other method, or should this be self contained?
                    var question = GetQuestion(id);
                    if(question != null)
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
}
