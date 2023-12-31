﻿using Microsoft.CodeAnalysis.CSharp;
using Treehoot.Api.Dtos;
using Treehoot.Application.Services;
using Treehoot.Domain.Models;


namespace Treehoot.Api.Mapping
{
    public static class PostQuizRequestExtention
    {
        public static Quiz ToModel(this PostQuizRequest postQuiz)
        {
            var modelQuiz = new Quiz(id: new Guid(), 
                                     name: postQuiz.Name, 
                                     description: postQuiz.Description)
                                    {Stages = PostStagesToModel(postQuiz.Stages)};
            return modelQuiz;
        }

        private static List<Stage> PostStagesToModel(List<PostStageRequest> postStages)
        {
            var modelStages = new List<Stage>();

            foreach (var postStage in postStages)
            {
                var modelStage = new Stage(id: new Guid(), 
                                           name: postStage.Name)
                                          {Questions = PostQuestionsToModel(postStage.Topics)};

                modelStages.Add(modelStage);
            }

            return modelStages;
        }

        private static List<Question> PostQuestionsToModel(List<PostQuestionRequest>  postQuestions) 
        {
            var modelQuestions = new List<Question>();

            foreach (var postQuestion in postQuestions)
            {
                var modelQuestion = new Question(id: new Guid(), 
                                                 topic: postQuestion.TopicName, 
                                                 questionText: postQuestion.Question)
                                                {Answers = PostAnswersToModel(postQuestion.Answers)};

                modelQuestions.Add(modelQuestion);
            }

            return modelQuestions;
        }

        private static List<Answer> PostAnswersToModel(List<PostAnswerRequest> postAnswers)
        {
            var modelAnswers = new List<Answer>();

            foreach (var postAnswer in postAnswers)
            {
                var modelAnswer = new Answer(id: new Guid(), isCorrect: postAnswer.IsCorrect, text: postAnswer.Answer);
                modelAnswers.Add(modelAnswer);
            }
            return modelAnswers;
        }   
    }
}
