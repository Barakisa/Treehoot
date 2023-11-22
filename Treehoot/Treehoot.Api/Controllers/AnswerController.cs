using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;
using Treehoot.Api.Dtos;
using Treehoot.Application.Services;
using Treehoot.Application.IServices;
using Treehoot.Api.Maping;

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
    public ActionResult<GetAnswerResponse> Get(int answerId)
    {
        return Ok(_answerService.GetAnswer(answerId).ToResponse());
    }

    [HttpGet("questionId/{questionId}")]
    public ActionResult<List<GetAnswerResponse>> GetByQuestionId(int questionId)
    {
        return Ok(_answerService.GetQuestionAnswers(questionId).ToResponse());
    }
}