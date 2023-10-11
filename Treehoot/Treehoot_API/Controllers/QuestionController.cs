using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;
using Treehoot.Application.Services;

namespace Treehoot_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private QuestionService questionService = new QuestionService();

    [HttpGet("{questionId}")]
    public ActionResult<Question> Get(int questionId)
    {
        return Ok(questionService.GetQuestion(questionId));
    }

    [HttpGet("{questionId}/full")]
    public ActionResult<QuestionFull> GetFull(int questionId)
    {
        return Ok(questionService.GetQuestionFull(questionId));
    }

}