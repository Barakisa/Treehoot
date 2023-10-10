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
        [HttpGet("{questionId}")]
        public ActionResult<Question> Get(int questionId)
        {
                return Ok(questionService.GetQuestion(questionId));           
        }
        
        [HttpGet("{questionId}/full")]
        public ActionResult<QuestionFull> GetFull(int questionId)
        {
            return Ok(questionService.GetQuestionFull(questionId));
        }
        
    }
}