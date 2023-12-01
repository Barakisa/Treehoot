﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Treehoot.Application.Data;
using Treehoot.Application.Exceptions;
using Treehoot.Application.Helpers;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

#nullable enable

public class QuestionService : IQuestionService
{
    private readonly TreehootApiContext _treehootApiContext;

    public QuestionService(TreehootApiContext treehootApiContext)
    {
        _treehootApiContext = treehootApiContext;
    }

    public async Task<Question?> GetSingle(int questionId)
    {
        return await _treehootApiContext.Question
                        .Include(q => q.Stage)
                        .SingleOrDefaultAsync(q => q.Id == questionId);
    }

    public async Task<List<Question>?> GetStageQuestions(int stageId)
    {
        var stage = await _treehootApiContext.Stage.FindAsync(stageId);
        if (stage == null)
        {
            throw new NotFoundException("Stage", stageId);
        }
        return await _treehootApiContext.Question
                        .Include(q => q.Stage)
                        .Where(q => q.Stage.Id == stageId)
                        .ToListAsync();
    }

    public async Task<Question?> GetSingleFull(int questionId)
    {
        return await _treehootApiContext.Question
                        .Include(q => q.Answers)
                        .Include(q => q.Stage)
                        .SingleOrDefaultAsync(q => q.Id == questionId);
    }

}
