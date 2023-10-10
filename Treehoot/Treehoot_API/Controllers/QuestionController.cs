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
                return Ok(questionService.GetQuestions(questionIdsString));           
        }
    }
}