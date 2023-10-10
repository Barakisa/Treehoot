using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;
using Treehoot.Application.Services;

namespace Treehoot_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizController : ControllerBase
{
    private QuizService quizService = new QuizService();

    // handles single / multiple quiz requests
    // quizes have stageIds, not full stages
    [HttpGet("{quizId}")]
    public ActionResult<Quiz> Get(int quizId)
    {
        return Ok(quizService.GetQuiz(quizId));
    }

    // handles single / multiple quiz requests
    // quizes have full stages, not stageIds
    [HttpGet("{quizId}/full")]
    public ActionResult<QuizFull> GetFull(int quizId)
    {
        return Ok(quizService.GetQuizFull(quizId));
    }
}