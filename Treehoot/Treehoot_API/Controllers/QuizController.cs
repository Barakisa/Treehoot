using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Treehoot_API.Models;

namespace Treehoot_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {

        [HttpGet(Name = "GetSpecificQuiz")]
        public ActionResult<Quiz> Get(int quizId)
        {
            try
            {

                var jsonText = System.IO.File.ReadAllText("FakeDb/FakeDb1.json");

                var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
                var allQuizes = data.Quizes.ToList();

                var quiz = allQuizes.FirstOrDefault(q => q.Id == quizId);

                return Ok(quiz);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
                return BadRequest("File not found");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}