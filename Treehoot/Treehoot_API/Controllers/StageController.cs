using Microsoft.AspNetCore.Mvc;
using Treehoot.Application.Services;
using Treehoot.Domain.Models;

namespace Treehoot_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StageController : ControllerBase
{
    private StageService stageService = new StageService();

    [HttpGet("{stageId}")]
    public ActionResult<Stage> Get(int stageId)
    {
        return Ok(stageService.GetStage(stageId:stageId));
    }
    [HttpGet("quizId/{quizId}")]
    public ActionResult<Stage> GetByQuizId(int quizId)
    {
        return Ok(stageService.GetQuizStages(quizId));
    }

    [HttpGet("{stageId}/full")]
    public ActionResult<StageFull> GetFull(int stageId)
    {
        return Ok(stageService.GetStageFull(stageId:stageId));
    }
}