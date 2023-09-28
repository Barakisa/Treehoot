using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Treehoot_API.Models;

namespace Treehoot_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        [HttpGet(Name  = "GetSpecificQuestion")]
        public ActionResult<Question> Get(int questionId)
        {
            try
            {

                var jsonText = System.IO.File.ReadAllText("FakeDb/QuestionsTable.json");

                var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
                var allQuestions = data.Questions.ToList();

                var question = allQuestions.FirstOrDefault(q => q.Id == questionId);

                return Ok(question);
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

