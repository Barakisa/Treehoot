using Microsoft.AspNetCore.Mvc;
using Treehoot_API.Models;
using Treehoot_API.Services;

namespace Treehoot_API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private AnswerService answerService = new AnswerService();

        // handles single / multiple answer requests
        [HttpGet("{answerIdsString}")]
        public ActionResult<Answer> Get(string answerIdsString)
        {
            var answers = answerService.GetAnswers(answerIdsString);
            return Ok(answers);
        }
    }
}