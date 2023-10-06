using Treehoot_API.Models;

namespace Treehoot_API.Helpers
{
    public class JsonConversion
    {
        public List<Quiz> Quizes { get; set; }
        public List<Stage> Stages { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }

        public List<QuizFull> QuizesFull { get; set; }
        public List<StageFull> StagesFull { get; set; }
        public List<QuestionFull> QuestionsFull { get; set; }
    }
}

