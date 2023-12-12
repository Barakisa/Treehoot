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
    [HttpGet]
    public async Task<ActionResult<GetPlaygroundQuizesResponse>> GetAll()
    {
        //service
        var quizes = await _playgroundService.GetAllHostedQuizes();

        //validation
        if (quizes == null)
        {
            return NotFound();
        }

        //maping
        var response = quizes.ToResponse();

        return Ok(response);


    }

    [HttpPut]
    public async Task<ActionResult<PutPlaygroundQuizResponse>> UpdateHostedQuiz([FromBody] PutPlaygroundQuizRequest request)
    {
        //validation
        if (request == null)
        {
            return BadRequest("Invalid request body.");
        }

        var response = new PutPlaygroundQuizResponse();
        
        //validation
        if (request.Action == "Remove")
        {
            //service
            response.Success = _playgroundService.RemoveHostedQuiz(request.Id);
            //maping
            response.Action = "Remove";
            response.Code = request.Code;
            response.Id = request.Id;
        }
        else if (request.Action == "Add")
        {
            //service
            response.Code = _playgroundService.AddHostedQuiz(request.Id);
            //maping
            response.Action = "Add";
            response.Success = response.Code > 0;
            response.Id = request.Id;
        }
        else
        {
            return BadRequest("Invalid action. Should be either \"Add\" or \"Remove\"");
        }

        return Ok(response);

    }



}