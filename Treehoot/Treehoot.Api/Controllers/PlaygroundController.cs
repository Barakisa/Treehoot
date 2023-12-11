using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;
using Treehoot.Api.Dtos;
using Treehoot.Application.Services;
using Treehoot.Application.IServices;
using Treehoot.Application.Exceptions;
using Treehoot.Api.Mapping;


namespace Treehoot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlaygroundController : ControllerBase
{
    private readonly IPlaygroundService _playgroundService;

    public PlaygroundController(IPlaygroundService playgroundService)
    {
        _playgroundService = playgroundService;
    }

    //get all currently hosted quizes
    [HttpGet("{answerId}")]
    public async Task<ActionResult<GetAnswerResponse>> Get(Guid answerId)
    {
        //service
        var answer = await _answerService.GetSingle(answerId);

        //validation
        if (answer == null)
        {
            return NotFound();
        }

        //maping
        var response = answer.ToResponse();

        return Ok(response);


    }

    [HttpGet("questionId/{questionId}")]
    public async Task<ActionResult<List<GetAnswerResponse>>> GetByQuestionId(Guid questionId)
    {
        try
        {
            //service
            var answers = await _answerService.GetQuestionAnswers(questionId);

            //validation
            if (!answers.Any())
            {
                throw new NotFoundException("answer", "question", questionId);
            }

            //maping
            var response = answers.ToResponse();

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
    }
}