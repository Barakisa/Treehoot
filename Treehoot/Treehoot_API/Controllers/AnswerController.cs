using Microsoft.AspNetCore.Mvc;
using Treehoot_API.Models;
using Treehoot_API.Services;

namespace Treehoot_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private AnswerService answerService = new AnswerService();

        [HttpGet("{answerId}")]
        public ActionResult<Answer> Get(int answerId)
        {
            return Ok(answerService.GetAnswer(answerId));
        }
    }
}