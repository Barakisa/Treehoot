using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Treehoot.Application.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TreehootApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TreehootApiContext") ?? throw new InvalidOperationException("Connection string 'TreehootApiContext' not found."), b => b.MigrationsAssembly("Treehoot.Infrastructure")));
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
