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
                return Ok(quizService.GetQuizes(quizIdsString));
        }

        // handles single / multiple quiz requests
        // quizes have full stages, not stageIds
        [HttpGet("{quizIdsString}/full")]
        public ActionResult<QuizFull> GetFull(string quizIdsString)
        {
                return Ok(quizService.GetQuizesFull(quizIdsString));
        }
    }
}