using System.Text.Json;
using Treehoot_API.Helpers;
using Treehoot_API.Models;

namespace Treehoot_API.Services
{
    public class StageService
    {
        private string fakeDbPath = "FakeDb/StagesTable.json";

        // can handle single / multiple stage requests
        // quizes have stageIds, not full stages
        public List<Stage> GetStages(string stageIdsString)
        {
            try
            {
                var stageIds = stageIdsString.Split(',').Select(int.Parse).ToList();
                var stages = new List<Stage>();
                foreach(var stageId in stageIds)
                {
                    // can i call the other method, or should this be self contained?
                    var jsonText = File.ReadAllText(fakeDbPath);

                    var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
                    var allStages = data.Stages.ToList();

                    var stage = allStages.SingleOrDefault(q => q.Id == stageId);

                    if (stage != null)
                    {
                        stages.Add(stage);
                    }
                }

                return stages;
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
