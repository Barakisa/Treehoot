using Microsoft.AspNetCore.Mvc;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;
using Treehoot.Api.Maping;
using Treehoot.Api.Dtos;
using Treehoot.Application.Exceptions;

namespace Treehoot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StageController : ControllerBase
{
    private readonly IStageService _stageService;

    public StageController(IStageService stageService)
    {
        _stageService = stageService;
    }

    [HttpGet("{stageId}")]
    public async Task<ActionResult<Stage>> GetSingle(int stageId)
    {
        //service
        var stage = await _stageService.GetSingle(stageId);

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
            //service
            var stages = await _stageService.GetQuizStages(quizId);

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
        //service
        var stage = await _stageService.GetSingleFull(stageId);

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