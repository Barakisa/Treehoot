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

        public async void OnStageReturned(object source, int a)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<TreehootApiContext>();

                await dbContext.ApiCallResult
                    .AddAsync(new ApiCallResult() { 
                        Id = Guid.NewGuid(),
                        DateTime = DateTime.Now.ToString(), 
                        IsSuccessful = a > 0,
                        ItemCount = a
                    });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
