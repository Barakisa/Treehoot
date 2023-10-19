using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class StageService
{
    private string fakeDbPath = "FakeDb/StagesTable.json";

    public Stage GetStage(int stageId)
    {
        return DataLoader.GetEntity<Stage>("FakeDb/StagesTable.json", stageId);
    }

    public StageFull GetStageFull(int stageId)
    {
        try
        {
            var gatherer = new ObjectGatherer();
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
