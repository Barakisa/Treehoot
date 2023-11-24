using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices;

public interface IApiCallResultService
{
    public void OnEntityReturned<T>(object source, List<T> entity) where T : IEntity, IGetable;
}
