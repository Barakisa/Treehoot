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

        // single question
        [HttpGet("single/{questionId}")]
        public ActionResult<Question> GetSingle(int questionId)
        {
            try
            {
                var question = questionService.GetQuestion(questionId);
                return Ok(question);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"Question is null - question by this id ({questionId}) wasn't found");
                return BadRequest($"Question is null - question by this id ({questionId}) wasn't found");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        // multiple questions
        [HttpGet("multiple/{questionIds}")]
        public ActionResult<Question> GetMultiple(string questionIds)
        {
            try
            {
                var question = questionService.GetQuestions(questionIds);
                return Ok(question);
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

