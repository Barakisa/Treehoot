using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;
using Treehoot.Api.Dtos;
using Treehoot.Application.Services;
using Treehoot.Application.IServices;
using Treehoot.Api.Mapping;

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
    public async Task<ActionResult<GetAnswerResponse>> Get(int answerId)
    {
        //service
        var answer = await _answerService.GetSingle(answerId);

        //validation
        if (answer == null)
        {
            return NotFound();
        }

        //maping
        var response = answer.ToResponse();

        return Ok(response);
    }

    [HttpGet("questionId/{questionId}")]
    public async Task<ActionResult<List<GetAnswerResponse>>> GetByQuestionId(int questionId)
    {
        //service
        var answers = await _answerService.GetQuestionAnswers(questionId);

        //validation
        if (answers == null || answers.Count == 0)
        {
            return NotFound();
        }

        //maping
        var response = answers.ToResponse();

        return Ok(response);
    }
}