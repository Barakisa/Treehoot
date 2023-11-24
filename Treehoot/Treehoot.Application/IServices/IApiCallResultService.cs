using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices;

public interface IApiCallResultService
{
    public void OnStageReturned(object source, int a);
}
