using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;
using Treehoot.Application.Services;
using Treehoot.Application.IServices;
using Treehoot.Api.Dtos;
using Treehoot.Api.Maping;

namespace Treehoot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet("{questionId}")]
    public ActionResult<GetQuestionResponse> Get(int questionId)
    {
        return Ok(_questionService.GetQuestion(questionId).ToResponse());
    }

    [HttpGet("stageId/{stageId}")]
    public ActionResult<List<GetQuestionResponse>> GetByStageId(int stageId)
    {
        return Ok(_questionService.GetStageQuestions(stageId).ToResponse());
    }

    //broken
    [HttpGet("{questionId}/full")]
    public async Task<ActionResult<GetQuestionFullResponse>> GetFull(int questionId)
    {
        var question = await _questionService.GetQuestionFull(questionId);

        if (question == null)
        {
            return NotFound();
        }

        var fullResponse = question.ToFullResponse();
        return Ok(fullResponse);
    }

}