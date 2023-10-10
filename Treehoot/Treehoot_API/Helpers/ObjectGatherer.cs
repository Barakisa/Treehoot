using Treehoot_API.Models;
using Treehoot_API.Services;

namespace Treehoot_API.Helpers
{
    public class ObjectGatherer
    {
        // gathers a quiz with all child elements
        public QuizFull GatherQuiz(int quizId)
        {
            // gatherable quiz
            var gQuiz = new QuizFull();
            var baseQuiz = new QuizService().GetQuiz(quizId);

            gQuiz.Id = baseQuiz.Id;
            gQuiz.Timer = baseQuiz.Timer;
            gQuiz.Description = baseQuiz.Description;
            gQuiz.Name = baseQuiz.Name;
            gQuiz.Stages = new List<StageFull>();

            foreach (int stageId in baseQuiz.Stages)
            {
                var stage = GatherStage(stageId);
                gQuiz.Stages.Add(stage);
            }

            return gQuiz;
        }

        // gathers a stage with all child elements
        public StageFull GatherStage(int stageId)
        {
            // gatherable stage
            var gStage = new StageFull();
            var baseStage = new StageService().GetStages(stageId.ToString())[0];

            gStage.Id = baseStage.Id;
            gStage.Name = baseStage.Name;
            gStage.Questions = new List<QuestionFull>();

            foreach (int questionId in baseStage.Questions)
            {
                var question = GatherQuestion(questionId);
                gStage.Questions.Add(question);
            }

            return gStage;
        }

        // gathers a question with all child elements
        public QuestionFull GatherQuestion(int questionId)
        {
            // gatherable stage
            var gQuestion = new QuestionFull();
            var baseQuestion = new QuestionService().GetQuestions(questionId.ToString())[0];

            gQuestion.Id = baseQuestion.Id;
            gQuestion.QuestionText = baseQuestion.QuestionText;
            gQuestion.Answers = new List<Answer>();

            var answerService = new AnswerService();
            foreach (int answerId in baseQuestion.Answers)
            {
                var answer = answerService.GetAnswers(answerId.ToString())[0];
                gQuestion.Answers.Add(answer);
            }

            return gQuestion;
        }
    }
}
