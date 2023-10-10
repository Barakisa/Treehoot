using System.Text.Json;
using Treehoot_API.Helpers;
using Treehoot_API.Models;

namespace Treehoot_API.Services
{
    public class QuizService
    {
        private string fakeDbPath = "FakeDb/QuizesTable.json";

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
}
