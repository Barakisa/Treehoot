using System.Text.Json;
using Treehoot_API.Helpers;
using Treehoot_API.Models;

namespace Treehoot_API.Services
{
    public class AnswerService
    {
        private string fakeDbPath = "FakeDb/AnswersTable.json";

        // can handle single / multiple answer requests
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
}
