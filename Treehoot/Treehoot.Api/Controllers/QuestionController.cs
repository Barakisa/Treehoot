using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;
using Treehoot.Application.Services;
using Treehoot.Application.IServices;

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
    public ActionResult<Question> Get(int questionId)
    {
        return Ok(_questionService.GetQuestion(questionId));
    }

    [HttpGet("stageId/{stageId}")]
    public ActionResult<Question> GetByStageId(int stageId)
    {
        return Ok(_questionService.GetStageQuestions(stageId));
    }

    [HttpGet("{questionId}/full")]
    public ActionResult<Question> GetFull(int questionId)
    {
        return Ok(_questionService.GetQuestionFull(questionId));
    }

}