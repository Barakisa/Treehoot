using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;
using Treehoot.Application.Services;
using Treehoot.Domain.DTOs;
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

    [HttpGet("{quizId}")]
    public ActionResult<Quiz> Get(int quizId)
    {
        return Ok(quizService.GetQuiz(quizId));
    }

    [HttpGet("{quizId}/full")]
    public ActionResult<QuizFull> GetFull(int quizId)
    {
        return Ok(quizService.GetQuizFull(quizId));
    }

    [HttpPost]
    public IActionResult CreateQuiz (QuizPostRequest quiz)
    {
        var validationResult = quizService.CreateAndValidateQuiz(quiz);

        if (validationResult.Success)
        {
            return Ok(validationResult.Message);
        }

        return BadRequest(validationResult.Message);
    }
}