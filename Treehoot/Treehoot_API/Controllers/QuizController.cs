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

        // handles single / multiple quiz requests
        // quizes have stageIds, not full stages
        [HttpGet("{quizIdsString}")]
        public ActionResult<Quiz> Get(string quizIdsString)
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

        // handles single / multiple quiz requests
        // quizes have full stages, not stageIds
        [HttpGet("{quizIdsString}/full")]
        public ActionResult<QuizFull> GetFull(string quizIdsString)
        {
            try
            {
                var quizes = quizService.GetQuizesFull(quizIdsString);
                return Ok(quizes);
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