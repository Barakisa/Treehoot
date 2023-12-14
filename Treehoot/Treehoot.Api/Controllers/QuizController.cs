using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;
using Treehoot.Application.IServices;
using Treehoot.Api.Dtos;
using Treehoot.Api.Mapping;
using Treehoot.Application.Exceptions;

namespace Treehoot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;
    private readonly IPlaygroundService _playgroundService;

    public QuizController(IQuizService quizService, IPlaygroundService playgroundService)
    {
        _quizService = quizService;
        _playgroundService = playgroundService;
    }


    [HttpGet]
    public async Task<ActionResult<List<GetQuizResponse>>> GetAll()
    {
        //service
        var quizzes = await _quizService.GetAll();

        //validation
        if (quizzes == null || quizzes.Count == 0)
        {
            return NotFound();
        }

        //maping
        var response = quizzes.ToResponse();

        return Ok(response);
    }

    [HttpGet("{quizId}")]
    public async Task<ActionResult<GetQuizResponse>> GetSingle(Guid quizId)
    {
        //service
        try
        {
            var quiz = await _quizService.GetSingle(quizId);
            //validation

            if (quiz == null)
            {
                return NotFound();
            }

            //maping
            var response = quiz.ToResponse();

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new {Message = ex.Message});
        }

    }

    [HttpGet("code/{quizCode}")]
    public async Task<ActionResult<GetQuizResponse>> GetSingleByCode(int quizCode)
    {
        //service
        try
        {
            var quiz = (await _playgroundService.GetSingleHostedQuiz(quizCode)).Value;
            
            if (quiz == null)
            {
                return NotFound();
            }

            //maping
            var response = quiz.ToResponse();

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }

    }

    [HttpGet("{quizId}/full")]
    public async Task<ActionResult<GetQuizFullResponse>> GetSingleFull(Guid quizId)
    {
        //service
        var quiz = await _quizService.GetSingleFull(quizId);

        //validation
        if (quiz == null)
        {
            return NotFound();
        }

        //maping
        var response = quiz.ToFullResponse();

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<PostResult>> CreateQuiz([FromBody] PostQuizRequest postQuiz)
    {
        if (postQuiz == null)
        {
            return BadRequest(new PostResult (success: false, message: "Could not map request body to the expected new quiz body"));
        }

        var quiz = postQuiz.ToModel();
        
        var valid = await _quizService.ValidatePost(quiz);
        
        if(!valid.Success){
            return BadRequest(valid);
        }

        var created = await _quizService.Create(quiz);
        
        return Ok(created);
    }
}