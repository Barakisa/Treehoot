using Microsoft.CodeAnalysis.CSharp;
using Treehoot.Api.Dtos;
using Treehoot.Application.Services;
using Treehoot.Domain.Models;


namespace Treehoot.Api.Mapping
{
    public static class PostQuizBodyExtention
    {
        public static Quiz ToModel(this PostQuizBody postQuiz)
        {
            var modelQuiz = new Quiz(id: 1, 
                                     name: postQuiz.Name, 
                                     description: postQuiz.Description);
            modelQuiz.Stages = postStagesToModel(postQuiz.Stages);
            return modelQuiz;
        }

        private static List<Stage> postStagesToModel(List<PostStageBody> postStages)
        {
            var modelStages = new List<Stage>();

            foreach (var postStage in postStages)
            {
                var modelStage = new Stage(id: 1, 
                                           name: postStage.Name);
                modelStage.Questions = postQuestionsToModel(postStage.Topics);

                modelStages.Add(modelStage);
            }

            return modelStages;
        }

        private static List<Question> postQuestionsToModel(List<PostQuestionBody>  postQuestions) 
        {
            var modelQuestions = new List<Question>();

            foreach (var postQuestion in postQuestions)
            {
                var modelQuestion = new Question(id: 1, 
                                                 topic: postQuestion.TopicName, 
                                                 questionText: postQuestion.Question);
                modelQuestion.Answers = postAnswersToModel(postQuestion.Answers);

                modelQuestions.Add(modelQuestion);
            }

            return modelQuestions;
        }

        private static List<Answer> postAnswersToModel(List<PostAnswerBody> postAnswers)
        {
            var modelAnswers = new List<Answer>();

            foreach (var postAnswer in postAnswers)
            {
                var modelAnswer = new Answer(id: 1, isCorrect: postAnswer.IsCorrect, text: postAnswer.Answer);
                modelAnswers.Add(modelAnswer);
            }
            return modelAnswers;
        }   
    }
}
