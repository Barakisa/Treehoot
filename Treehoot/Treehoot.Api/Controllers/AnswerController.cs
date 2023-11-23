using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;
using Treehoot.Application.Services;
using Treehoot.Application.IServices;

namespace Treehoot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnswerController : ControllerBase
{
    private readonly IAnswerService _answerService;

    public AnswerController(IAnswerService answerService)
    {
        _answerService = answerService;
    }

    [HttpGet("{answerId}")]
    public ActionResult<Answer> Get(int answerId)
    {
        return Ok(_answerService.GetAnswer(answerId));
    }

    [HttpGet("questionId/{questionId}")]
    public ActionResult<Answer> GetByQuestionId(int questionId)
    {
        return Ok(_answerService.GetQuestionAnswers(questionId));
    }
}