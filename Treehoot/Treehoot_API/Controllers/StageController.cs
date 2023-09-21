using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Treehoot_API.Models;

namespace Treehoot_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StageController : ControllerBase
    {

        private Stage GetSpecificStage(int stageId)
        {
            try
            {
                string jsonText = System.IO.File.ReadAllText("FakeDb/FakeDb1.json");

                var jsonDb = JsonSerializer.Deserialize<JsonConversion>(jsonText);

                Stage specificStage = new Stage();
                foreach (Quiz quiz in jsonDb.Quizes)
                {
                    foreach (Stage stage in quiz.Stages)
                    {
                        if (stage.Id == stageId)
                        {
                            specificStage = stage;
                            break;
                        }
                    }
                }

                return specificStage;
            }
            catch (FileNotFoundException) 
            { 
                Console.WriteLine("File not found"); 
                return null; 
            }
            catch (Exception ex) 
            { 
                Console.WriteLine($"An error occurred: {ex.Message}"); 
                return null; 
            }
        }

        private readonly ILogger<StageController> _logger;

        public StageController(ILogger<StageController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStage")]
        public Stage Get()
        {
            return GetSpecificStage(13);
        }
    }
}