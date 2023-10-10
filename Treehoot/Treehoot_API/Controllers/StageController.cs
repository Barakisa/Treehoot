using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Treehoot_API.Helpers;
using Treehoot_API.Models;
using Treehoot_API.Services;

namespace Treehoot_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StageController : ControllerBase
    {
        private StageService stageService = new StageService();

        [HttpGet("{stageIdsString}")]
        public ActionResult<Stage> Get(string stageIdsString)
        {
            return Ok(stageService.GetStages(stageIdsString));
        }

        [HttpGet("{stageIdsString}/full")]
        public ActionResult<StageFull> GetFull(string stageIdsString)
        {
                return Ok(stageService.GetStagesFull(stageIdsString));           
        }
    }
}