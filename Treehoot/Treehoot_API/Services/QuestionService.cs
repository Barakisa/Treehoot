using System.Text.Json;
using Treehoot_API.Models;

namespace Treehoot_API.Services
{
    public class QuestionService
    {
        private string fakeDbPath = "FakeDb/StagesTable.json";

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
                throw; // Rethrow the exception so it can be handled in the controller.
            }
            catch (Exception e)
            {
                throw new Exception($"Error: {e.Message}");
            }
        }
    }
}
