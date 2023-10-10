using Microsoft.AspNetCore.Mvc;
using Treehoot_API.Models;
using Treehoot_API.Services;


namespace Treehoot_API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private QuestionService questionService = new QuestionService();

        // handles single / multiple question requests
        [HttpGet("{questionIdsString}")]
        public ActionResult<Question> Get(string questionIdsString)
        {
            try
            {
                var questions = questionService.GetQuestions(questionIdsString);
                return Ok(questions);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"Question is null - question wasn't found");
                return BadRequest($"Question is null - question wasn't found");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}

