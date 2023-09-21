using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using Treehoot_API.Models;

namespace Treehoot_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        [HttpGet]
        public ActionResult<Question> Get(int questionId)
        {
            try
            {
                string jsonText = System.IO.File.ReadAllText("FakeDb/FakeDb1.json");
         
                var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
                var allQuestions = data.quizes
                .SelectMany(quiz => quiz.Stages)
                .SelectMany(stage => stage.Questions)
                .ToList();

                var question = allQuestions.FirstOrDefault(q => q.Id == questionId);

                return Ok(question);
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
 
    }
}
