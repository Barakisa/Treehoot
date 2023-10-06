using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Treehoot_API.Models;
using Treehoot_API.Services;

namespace Treehoot_API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private QuestionService questionService = new QuestionService();

        [HttpGet("{questionId}/answer")]
        public ActionResult<Question> Get(int questionId)
        {
            try
            {
                var question = questionService.GetQuestion(questionId);
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

