using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;
using Treehoot.Application.Services;

namespace Treehoot_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizController : ControllerBase
{
    private QuizService quizService = new QuizService();

    [HttpGet]//to be continued...
    public ActionResult<Quiz> Get()
    {
        return Ok(quizService.GetQuizes());
    }

    [HttpGet("{quizId}/full")]
    public ActionResult<QuizFull> GetFull(int quizId)
    {
        return Ok(quizService.GetQuizFull(quizId));
    }
}