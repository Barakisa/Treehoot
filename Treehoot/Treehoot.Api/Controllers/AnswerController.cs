using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;
using Treehoot.Application.Services;

namespace Treehoot_API.Controllers;

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

    [HttpGet("questionId/{questionId}")]
    public ActionResult<Answer> GetByQuestionId(int questionId)
    {
        return Ok(answerService.GetQuestionAnswers(questionId));
    }
}