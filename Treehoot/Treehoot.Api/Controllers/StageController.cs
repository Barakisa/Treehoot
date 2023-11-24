using Microsoft.AspNetCore.Mvc;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;
using Treehoot.Api.Mapping;
using Treehoot.Api.Dtos;
using Treehoot.Application.Exceptions;
using Treehoot.Application.Services;

namespace Treehoot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StageController : ControllerBase
{
    private readonly IStageService _stageService;
    private readonly IApiCallResultService _apiCallResultService;

    public StageController(IStageService stageService, IApiCallResultService apiCallResultService)
    {
        _stageService = stageService;
        _apiCallResultService = apiCallResultService;
    }

    [HttpGet("{stageId}")]
    public async Task<ActionResult<Stage>> GetSingle(int stageId)
    {
        _stageService.StageReturned +=  _apiCallResultService.OnEntityReturned;

        //service
        var stage = await _stageService.GetSingle(stageId);

        _stageService.StageReturned -= _apiCallResultService.OnEntityReturned;

        //validation
        if (stage == null)
        {
            return NotFound();
        }

        //maping
        var response = stage.ToResponse();

        return Ok(response);
    }

    [HttpGet("quizId/{quizId}")]
    public async Task<ActionResult<Stage>> GetByQuizId(int quizId)
    {
        try
        {
            _stageService.StageReturned += _apiCallResultService.OnEntityReturned;

            //service
            var stages = await _stageService.GetQuizStages(quizId);

            _stageService.StageReturned -= _apiCallResultService.OnEntityReturned;

            //validation
            if (!stages.Any())
            {
                throw new NotFoundException("stage", "quiz", quizId);
            }
            //maping
            var response = stages.ToResponse();

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
    }

    //broken
    [HttpGet("{stageId}/full")]
    public async Task<ActionResult<GetStageFullResponse>> GetSingleFull(int stageId)
    {
        _stageService.StageReturned += _apiCallResultService.OnEntityReturned;

        //service
        var stage = await _stageService.GetSingleFull(stageId);

        _stageService.StageReturned -= _apiCallResultService.OnEntityReturned;

        //validation
        if (stage == null)
        {
            return NotFound();
        }

        //maping
        var response = stage.ToFullResponse();

        return Ok(response);
    }
}