﻿using Treehoot.Application.IServices;
using Treehoot.Domain.Interfaces;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class PlaygroundService : IPlaygroundService
{
    private readonly IPlayground _playground;
    private readonly IQuizService _quizService;

    public PlaygroundService(IPlayground playground, IQuizService quizService)
    {
        _playground = playground;
        _quizService = quizService;
    }

    public async Task<KeyValuePair<int, Quiz>> GetSingleHostedQuiz(int code)
    {
        var quiz = new Quiz();
        if (_playground.IsHosted(code))
        {
            var quizId = _playground.GetHostedQuizGuidByCode(code);
            quiz = await _quizService.GetSingle(quizId);
        }
        return new KeyValuePair<int, Quiz>(-1, quiz);
    }

    public async Task<Dictionary<int, Quiz>> GetAllHostedQuizes()
    {
        var quizList = new Dictionary<int, Quiz>();
        foreach (var hosted in _playground.GetAllHostedQuizes())
        {
            quizList.Add(hosted.Key, await _quizService.GetSingle(hosted.Value));
        }
        return quizList;
    }

    public int AddHostedQuiz(Guid id)
    {
        return _playground.AddHostedQuiz(id);
    }

    public bool RemoveHostedQuiz(int code)
    {
        return _playground.RemoveHostedQuiz(code);
    }

    public bool RemoveHostedQuiz(Guid id)
    {
        return _playground.RemoveHostedQuiz(id);
    }
}
