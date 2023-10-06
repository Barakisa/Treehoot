using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Treehoot_API.Helpers;
using Treehoot_API.Models;

namespace Treehoot_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StageController : ControllerBase
    {

        private readonly ILogger<StageController> _logger;

        public StageController(ILogger<StageController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSpecificStage")]
        public ActionResult<StageFull> Get(int stageId)

        {
                string jsonText = System.IO.File.ReadAllText("FakeDb/StagesTable.json");

                var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
                var specificStage = data.Stages.FirstOrDefault(s => s.Id == stageId);

                return Ok(specificStage);           
        }
    }
}