using Microsoft.AspNetCore.Mvc;
using Treehoot.Application.IServices;
using Treehoot.Application.Services;
using Treehoot.Domain.Models;

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
    public ActionResult<Stage> Get(int stageId)
    {
        return Ok(_stageService.GetStage(stageId));
    }
    [HttpGet("quizId/{quizId}")]
    public ActionResult<Stage> GetByQuizId(int quizId)
    {
        return Ok(_stageService.GetQuizStages(quizId));
    }

    //broken
    [HttpGet("{stageId}/full")]
    public ActionResult<StageFull> GetFull(int stageId)
    {
        return Ok(_stageService.GetStageFull(stageId:stageId));
    }
}