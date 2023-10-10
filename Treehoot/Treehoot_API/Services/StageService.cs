using System.Text.Json;
using Treehoot_API.Helpers;
using Treehoot_API.Models;

namespace Treehoot_API.Services
{
    public class StageService
    {
        private string fakeDbPath = "FakeDb/StagesTable.json";

        public Stage GetStage(int stageId)
        {
            try
            {
                var jsonText = File.ReadAllText(fakeDbPath);

                var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
                var allStages = data.Stages.ToList();

                var stage = allStages.SingleOrDefault(q => q.Id == stageId);

                return stage;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
                throw; // rethrow the exception so it can be handled in the controller
            }
            catch (Exception e)
            {
                throw new Exception($"Error: {e.Message}");
            }
        }

        public StageFull GetStageFull(int stageId)
        {
            try
            {
                var gatherer = new ObjectGatherer();

                var jsonText = File.ReadAllText(fakeDbPath);

                var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
                var allStages = data.Stages.ToList();

                var stage = allStages.SingleOrDefault(q => q.Id == stageId);

                return gatherer.GatherStage(stageId);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
                throw; // rethrow the exception so it can be handled in the controller
            }
            catch (Exception e)
            {
                throw new Exception($"Error: {e.Message}");
            }
        }
    }
}
