using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Treehoot_API.Data;
using Treehoot.Api.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TreehootApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TreehootApiContext") ?? throw new InvalidOperationException("Connection string 'TreehootApiContext' not found.")));
builder.Services.AddDbContext<Treehoot_APIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Treehoot_APIContext") ?? throw new InvalidOperationException("Connection string 'Treehoot_APIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .WithOrigins("http://localhost:3000")  
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
