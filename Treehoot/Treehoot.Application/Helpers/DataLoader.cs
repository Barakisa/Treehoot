using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

public class DataLoader
{
    //if no id is passed - return the first (0-th) entity
    public static T GetEntity<T>(string fakeDbPath, int entityId) where T : IEntity
    {
        try
        {
            var jsonText = File.ReadAllText(fakeDbPath);
            var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);

            var entities = data.GetEntities<T>();

            var entity = entities.SingleOrDefault(e => e.Id == entityId);
            return entity;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
            throw;
        }
        catch (Exception e)
        {
            throw new Exception($"Error: {e.Message}");
        }
    }
}
