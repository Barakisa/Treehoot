﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Treehoot.Api.Controllers;
using Treehoot.Application.Data;
using Treehoot.Application.Services;
using Treehoot.Application.IServices;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TreehootApiContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TreehootApiContext") ?? throw new InvalidOperationException("Connection string 'TreehootApiContext' not found."), b => b.MigrationsAssembly("Treehoot.Infrastructure")));
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

//dependency injection registration
builder.Services.AddSingleton<IAnswerService, AnswerService>();
builder.Services.AddSingleton<IQuestionService, QuestionService>();
builder.Services.AddSingleton<IStageService, StageService>();
builder.Services.AddSingleton<IQuizService, QuizService>();
builder.Services.AddSingleton<IApiCallResultService, ApiCallResultService>();

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
