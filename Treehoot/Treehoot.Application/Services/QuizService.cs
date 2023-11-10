using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;
using Treehoot.Domain.DTOs;
using System.Net;

namespace Treehoot.Application.Services;

public class QuizService
{
    private string fakeDbPath = "FakeDb/QuizesTable.json";

    public Quiz GetQuiz(int quizId)
    {
        return DataLoader.GetEntity<Quiz>(fakeDbPath, quizId);
    }
    public List<Quiz> GetQuizes() {
        try
        {
            var jsonText = File.ReadAllText(fakeDbPath);
            var data = JsonSerializer.Deserialize<JsonConversion>(jsonText);
            var allQuizes = data.Quizes.ToList();
            return allQuizes;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
            throw; 
        }
        catch (Exception e)
        {
            throw new Exception($"Error: {e.Message}");
        }
        
    }

    public QuizFull GetQuizFull(int quizId)
    {
        try
        {
            var gatherer = new ObjectGatherer();
            return gatherer.GatherQuiz(quizId);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
            throw; // rethrow the exception so it can be handled in the controller
        }
        catch (Exception e)
        {
            throw new Exception($"Error: {e.Message}");
        }
    }

    public async Task <HttpResponseMessage> QuizPost (QuizPostRequest quiz)
    {
        try
        {
            var newQuiz = new Quiz(147, quiz.Name, quiz.Description);
            var stages = new List<Stage>();
            var questions = new List<Question>();
            var answers = new List<Answer>();

            foreach (var stage in quiz.Stages)
            {
                int stageId = 12;
                stages.Add(new Stage(stage.Name ,stageId, newQuiz.Id));

                foreach (var question in stage.Topics)
                {
                    int questionId = 13;
                    questions.Add(new Question(questionId, stageId, question.TopicName, question.Question));

                    foreach (var answer in question.Answers)
                    {
                        int answerId = 14;
                        answers.Add(new Answer(answerId, questionId, answer.IsCorrect, answer.Answer));
                    }
                }

            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        catch
        {
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }

}
