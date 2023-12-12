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

    
}