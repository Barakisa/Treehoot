using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;
using Treehoot.Application.Services;
using Treehoot.Application.IServices;
using Treehoot.Domain.DTOs;
using Treehoot.Application.Data;

namespace Treehoot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService)
    {
        _quizService = quizService;
    }


    [HttpGet]//to be continued...
    public ActionResult<Quiz> Get()
    {
        return Ok(_quizService.GetQuizes());
    }

    [HttpGet("{quizId}")]
    public ActionResult<Quiz> Get(int quizId)
    {
        return Ok(_quizService.GetQuiz(quizId));
    }

    //broken
    [HttpGet("{quizId}/full")]
    public ActionResult<QuizFull> GetFull(int quizId)
    {
        return Ok(_quizService.GetQuizFull(quizId));
    }

    [HttpPost]
    public Task<HttpResponseMessage> QuizPost(QuizPostRequest quiz)
    {
        return _quizService.QuizPost(quiz);
    }
}