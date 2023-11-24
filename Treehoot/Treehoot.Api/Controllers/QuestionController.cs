using Microsoft.AspNetCore.Mvc;
using Treehoot.Application.IServices;
using Treehoot.Api.Dtos;
using Treehoot.Api.Mapping;

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
    public async Task<ActionResult<GetQuestionResponse>> GetSingle(int questionId)
    {
        //service
        var question = await _questionService.GetSingle(questionId);

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
        if (questions == null || questions.Count == 0)
        {
            return NotFound();
        }

        //maping
        var response = questions.ToResponse();
        
        return Ok(response);
    }

    [HttpGet("{questionId}/full")]
    public async Task<ActionResult<GetQuestionFullResponse>> GetSingleFull(int questionId)
    {
        //service
        var question = await _questionService.GetSingleFull(questionId);

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