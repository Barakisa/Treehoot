using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Treehoot.Application.Data;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services
{
    public class ApiCallResultService : IApiCallResultService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ApiCallResultService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async void OnEntityReturned<T>(object source, List<T> entity) where T : IEntity, IGetable
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<TreehootApiContext>();

                await dbContext.ApiCallResult
                    .AddAsync(new ApiCallResult() { 
                        Id = Guid.NewGuid(),
                        DateTime = DateTime.Now.ToString(),
                        ItemCount = entity.Where(a => a != null).ToList().Count, 
                        IsSuccessful = entity.Where(a => a != null).ToList().Count > 0
                    });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
