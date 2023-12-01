﻿using Microsoft.AspNetCore.Mvc;
using Treehoot.Domain.Models;
using Treehoot.Application.Services;
using Treehoot.Application.IServices;
using Treehoot.Api.Dtos;
using Treehoot.Api.Mapping;
using Treehoot.Application.Data;
using Treehoot.Application.Exceptions;

namespace Treehoot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService)
    {
        _quizService = quizService;
    }


    [HttpGet]//to be continued...
    public async Task<ActionResult<List<GetQuizResponse>>> GetAll()
    {
        //service
        var quizzes = await _quizService.GetAll();

        //validation
        if (quizzes == null || quizzes.Count == 0)
        {
            return NotFound();
        }

        //maping
        var response = quizzes.ToResponse();

        return Ok(response);
    }

    [HttpGet("{quizId}")]
    public async Task<ActionResult<GetQuizResponse>> GetSingle(int quizId)
    {
        //service
        try
        {
            var quiz = await _quizService.GetSingle(quizId);
            //validation

            if (quiz == null)
            {
                return NotFound();
            }

            //maping
            var response = quiz.ToResponse();

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new {Message = ex.Message});
        }

    }

    [HttpGet("{quizId}/full")]
    public async Task<ActionResult<GetQuizFullResponse>> GetSingleFull(int quizId)
    {
        //service
        var quiz = await _quizService.GetSingleFull(quizId);

        //validation
        if (quiz == null)
        {
            return NotFound();
        }

        //maping
        var response = quiz.ToFullResponse();

        return Ok(response);
    }
    /*
    [HttpPost]
    public ActionResult<PostResult> QuizPost(PostQuizBody quiz)
    {
        var quizModel = new Quiz(new Guid(), quiz.Name, quiz.Description);
        return Ok(_quizService.CreateAndValidateQuiz(quizModel));
    }*/
}