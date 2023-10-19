using System;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using System.Security.Principal;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

public class DataLoader
{
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
