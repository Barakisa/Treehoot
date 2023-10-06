using System.Text.Json;
using Treehoot_API.Helpers;
using Treehoot_API.Models;

namespace Treehoot_API.Services
{
    public class QuizService
    {
        private string fakeDbPath = "FakeDb/QuizesTable.json";

        // single question
        public Quiz GetQuiz(int quizId)
        {
            try
            {
                var jsonText = File.ReadAllText(fakeDbPath);

                var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
                var allQuizes = data.Quizes.ToList();

                var quiz = allQuizes.SingleOrDefault(q => q.Id == quizId);
                
                return quiz;
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
        public List<Quiz> GetQuizes(string quizIdsString)
        {
            try
            {
                var quizIds = quizIdsString.Split(',').Select(int.Parse).ToList();
                var quizes = new List<Quiz>();
                foreach(var id in quizIds)
                {
                    // can i call the other method, or should this be self contained?
                    var quiz = GetQuiz(id);
                    if(quiz != null)
                    { 
                        quizes.Add(quiz);
                    }
                }

                return quizes;
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
