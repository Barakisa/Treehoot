using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Treehoot_API.Models;
using Treehoot_API.Services;

namespace Treehoot_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private QuizService quizService = new QuizService();

        // single quiz
        [HttpGet("single/{quizId}")]
        public ActionResult<Quiz> GetSingle(int quizId)
        {
            try
            {
                var quiz = quizService.GetQuiz(quizId);
                return Ok(quiz);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"Quiz is null - quiz by this id ({quizId}) wasn't found");
                return BadRequest($"Quiz is null - quiz by this id ({quizId}) wasn't found");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        // multiple quizes
        [HttpGet("multiple/{quizIdsString}")]
        public ActionResult<Quiz> GetMultiple(string quizIdsString)
        {
            try
            {
                var quiz = quizService.GetQuizes(quizIdsString);
                return Ok(quiz);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"Quiz is null - quiz wasn't found");
                return BadRequest($"Quiz is null - quiz wasn't found");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}