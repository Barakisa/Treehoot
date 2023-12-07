using Treehoot.Application.IServices;
using Treehoot.Domain.Models;
using Treehoot.Application.Data;
using Microsoft.EntityFrameworkCore;
using Treehoot.Application.Exceptions;

namespace Treehoot.Application.Services;

public class QuizService : IQuizService
{
    private readonly TreehootApiContext _treehootApiContext;

    public QuizService(TreehootApiContext treehootApiContext)
    {
        _treehootApiContext = treehootApiContext;
    }

    public async Task<List<Quiz>?> GetAll()
    {
        try
        {
            return await _treehootApiContext.Quiz
                                .ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error: {e.Message}");
        }

    }

    public async Task<Quiz?> GetSingle(Guid quizId)
    {
        var quiz = await _treehootApiContext.Quiz.FindAsync(quizId);
        if (quiz == null)
        {
            throw new NotFoundException("Quiz", quizId);
        }
        return await _treehootApiContext.Quiz
                        .SingleOrDefaultAsync(a => a.Id == quizId);



    }

    public async Task<Quiz?> GetSingleFull(Guid quizId)
    {
        return await _treehootApiContext.Quiz
                        .Include(s => s.Stages)
                            .ThenInclude(s => s.Questions)
                                .ThenInclude(q => q.Answers)
                        .SingleOrDefaultAsync(a => a.Id == quizId);

    }
    public async Task<PostResult> ValidatePost(Quiz quiz)
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

            foreach (var stage in quiz.Stages)
            {
                int stageId = 12;
                //stages.Add(new Stage(stage.Name ,stageId, newQuiz.Id));

                if(stage.Questions == null || !stage.Questions.Any())
                {
                    return new PostResult(false, "At least one topic is required!");
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

            return new PostResult(true, "Quiz is valid!"); 
        }

        catch
        {
            return new PostResult(false, "Something went wrong, try again...");
        }
    }

    public async Task<PostResult> Create(Quiz quiz)
    {
        var res = await _treehootApiContext.Quiz.AddAsync(quiz);
        await _treehootApiContext.SaveChangesAsync();
        return new PostResult(true, "Quiz added");
    }
}
