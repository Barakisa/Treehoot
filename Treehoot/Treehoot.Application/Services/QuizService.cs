﻿using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;
using System.Net;
using Treehoot.Application.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Treehoot.Application.Services;

public class QuizService : IQuizService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public QuizService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public Quiz GetQuiz(int quizId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return context.Quiz.Single(a => a.Id == quizId);
        }
    }

    public List<Quiz> GetQuizes() {
        try
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
                return context.Quiz.ToList();
            }
        }
        catch (Exception e)
        {
            throw new Exception($"Error: {e.Message}");
        }
        
    }
    
    //broken
    public QuizFull GetQuizFull(int quizId)
    {
        return new QuizFull();
    }


    public PostResult CreateAndValidateQuiz(Quiz quiz)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(quiz.Name) || string.IsNullOrWhiteSpace(quiz.Description))
            {
                return new PostResult(false, "Quiz name and description fields must not be empty!");
            }

            if (quiz.Stages == null || !quiz.Stages.Any())
            {
                return new PostResult(false, "At least one stage is required!");
            }

            var newQuiz = new Quiz(147, quiz.Name, quiz.Description);
            var stages = new List<Stage>();
            var questions = new List<Question>();
            var answers = new List<Answer>();

            foreach (var stage in quiz.Stages)
            {
                int stageId = 12;
                //stages.Add(new Stage(stage.Name ,stageId, newQuiz.Id));

                if(stage.Questions == null || !stage.Questions.Any())
                {
                    return new PostResult(false, "Atleast one topic is required!");
                }

                foreach (var question in stage.Questions)
                {
                    if (string.IsNullOrWhiteSpace(question.Topic) || string.IsNullOrWhiteSpace(question.QuestionText))
                    {
                        return new PostResult(false, "Topic name and question fields must not be empty!");
                    }

                    int questionId = 13;
                    //questions.Add(new Question(questionId, stageId, question.TopicName, question.Question));

                    if(question.Answers == null || !question.Answers.Any())
                    {
                        return new PostResult(false, "Atleast one answer is required");
                    }

                    foreach (var answer in question.Answers)
                    {
                        if (string.IsNullOrWhiteSpace(answer.Text))
                        {
                            return new PostResult(false, "Answer field must not be empty!");
                        }

                        int answerId = 14;
                        //answers.Add(new Answer(answerId, questionId, answer.IsCorrect, answer.Answer));
                    }
                }

            }

            return new PostResult(true, "Quiz has been created!"); 
        }

        catch
        {
            return new PostResult(false, "Something went wrong, try again...");
        }
    }

}
