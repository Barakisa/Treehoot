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

        [HttpGet("{quizId}")]
        public ActionResult<Quiz> Get(int quizId)
        {
                return Ok(quizService.GetQuiz(quizId));
        }

        [HttpGet("{quizId}/full")]
        public ActionResult<QuizFull> GetFull(int quizId)
        {
                return Ok(quizService.GetQuizFull(quizId));
        }
    }
}