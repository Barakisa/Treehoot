using System.Security.Principal;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Helpers;

public class JsonConversion
{
    public List<Quiz> Quizes { get; set; }
    public List<Stage> Stages { get; set; }
    public List<Question> Questions { get; set; }
    public List<Answer> Answers { get; set; }

    public List<QuizFull> QuizesFull { get; set; }
    public List<StageFull> StagesFull { get; set; }
    public List<QuestionFull> QuestionsFull { get; set; }

    public List<T> GetEntities<T>() where T : IEntity
    {
        // Implement logic to extract and return entities of type T
        if (typeof(T) == typeof(Quiz))
        {
            return Quizes.Cast<T>().ToList();
        }
        else if (typeof(T) == typeof(Stage))
        {
            return Stages.Cast<T>().ToList();
        }
        else if (typeof(T) == typeof(Question))
        {
            return Questions.Cast<T>().ToList();
        }
        else if (typeof(T) == typeof(Answer))
        {
            return Answers.Cast<T>().ToList();
        }

        // Add similar logic for other entity types

        // Return an empty list if the entity type is not supported
        return new List<T>();
    }
}

