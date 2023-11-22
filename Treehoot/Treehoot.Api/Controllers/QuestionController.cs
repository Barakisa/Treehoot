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
    public async Task<ActionResult<GetQuestionResponse>> Get(int questionId)
    {
        //service
        var question = await _questionService.GetQuestion(questionId);

        //validation
        if (question == null)
        {
            return NotFound();
        }
        
        //maping
        var response = question.ToResponse();
        
        return Ok(response);
    }

    [HttpGet("stageId/{stageId}")]
    public async Task<ActionResult<List<GetQuestionResponse>>> GetByStageId(int stageId)
    {
        //service
        var questions = await _questionService.GetStageQuestions(stageId);

        //validation
        if (questions == null)
        {
            return NotFound();
        }

        //maping
        var response = questions.ToResponse();
        
        return Ok(response);
    }

    [HttpGet("{questionId}/full")]
    public async Task<ActionResult<GetQuestionFullResponse>> GetFull(int questionId)
    {
        //service
        var question = await _questionService.GetQuestionFull(questionId);

        //validation
        if (question == null)
        {
            return NotFound();
        }

        //maping
        var fullResponse = question.ToFullResponse();
        
        return Ok(fullResponse);
    }

}