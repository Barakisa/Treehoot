using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Treehoot_API.Helpers;
using Treehoot_API.Models;
using Treehoot_API.Services;

namespace Treehoot_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageController : ControllerBase
    {
        private StageService stageService = new StageService();

        [HttpGet("{stageId}")]
        public ActionResult<Stage> Get(int stageId)
        {
            return Ok(stageService.GetStage(stageId));
        }

        [HttpGet("{stageId}/full")]
        public ActionResult<StageFull> GetFull(int stageId)
        {
                return Ok(stageService.GetStageFull(stageId));
        }
    }
}