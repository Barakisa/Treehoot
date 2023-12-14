using Microsoft.EntityFrameworkCore;
using Treehoot.Application.Data;
using Treehoot.Application.IServices;
using Treehoot.Application.Services;
using Treehoot.Domain.Models;
using Xunit;

namespace Treehoot.Tests.ServiceTests
{
    public class QuizServiceTests
    {
        [Fact]
        public async Task GetAll_ReturnsAllQuizzes()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TreehootApiContext>()
                .UseInMemoryDatabase(databaseName: "GetAll_ReturnsAllQuizzes")
                .Options;

            var context = new TreehootApiContext(options);

            SeedTestData(context,
                new List<Quiz>
                {
                    new Quiz(new Guid(), "Quiz 1", "Description 1"),
                    new Quiz(new Guid(), "Quiz 2", "Description 2"),
                });

            IQuizService quizService = new QuizService(context);

            // Act
            var result = await quizService.GetAll();

            // Assert
            Assert.Equal(2, result.Count);
        }
        
        [Fact]
        public async Task GetSingle_ReturnsSpecificQuiz()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TreehootApiContext>()
                .UseInMemoryDatabase(databaseName: "GetSingle_ReturnsSpecificQuiz")
                .Options;

            var context = new TreehootApiContext(options);
            var quizId = Guid.NewGuid();
            var expectedQuiz = new Quiz(quizId, "Quiz 1", "Description 1");
            SeedTestData(context,
                new List<Quiz>
                {
                    new Quiz(Guid.NewGuid(), "Quiz 2", "Description 2"),
                    expectedQuiz
                }) ;

            IQuizService quizService = new QuizService(context);

            // Act
            var result = await quizService.GetSingle(quizId);

            // Assert
            Assert.Equal(result, expectedQuiz);
        }

        [Fact]
        public async Task GetSingle_ReturnsSpecificQuizWithRelations()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<TreehootApiContext>()
                .UseInMemoryDatabase(databaseName: "GetSingle_ReturnsSpecificQuizWithRelations")
                .Options;

            var context = new TreehootApiContext(options);
            var quizId = Guid.NewGuid();
            var expectedQuiz = new Quiz(quizId, "Quiz 1", "Description 1");

            expectedQuiz.Stages = new List<Stage>
            {
                new Stage(Guid.NewGuid(), "Stage 1")
                {
                    Questions = new List<Question>
                    {
                        new Question(Guid.NewGuid(), "Topic 1", "Text")
                        {
                            Answers = new List<Answer>
                            {
                            new Answer(Guid.NewGuid(), true, "Answer Text 1"),
                            new Answer(Guid.NewGuid(), false, "Answer Text 2")
                            }
                        }
                    }
                },
                new Stage(Guid.NewGuid(), "Stage 2")
                {
                    Questions = new List<Question>
                    {
                        new Question(Guid.NewGuid(), "Topic 2", "Text")
                        {
                            Answers = new List<Answer>
                            {
                                new Answer(Guid.NewGuid(), false, "Answer Text 1"),
                                new Answer(Guid.NewGuid(), true, "Answer Text 2")
                            }
                        }
                    }
                }
            };

            SeedTestData(context, new List<Quiz> { expectedQuiz });

            IQuizService quizService = new QuizService(context);

            // Act
            var result = await quizService.GetSingleFull(quizId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedQuiz.Id, result.Id);
            Assert.Equal(expectedQuiz.Name, result.Name);
            Assert.Equal(expectedQuiz.Description, result.Description);

            Assert.NotNull(result.Stages);
            Assert.Equal(expectedQuiz.Stages.Count, result.Stages.Count);

            for (int i = 0; i < expectedQuiz.Stages.Count; i++)
            {
                Assert.Equal(expectedQuiz.Stages[i].Name, result.Stages[i].Name);
                Assert.Equal(expectedQuiz.Stages[i].Questions.Count, result.Stages[i].Questions.Count);

                for (int j = 0; j < expectedQuiz.Stages[i].Questions.Count; j++)
                {
                    Assert.Equal(expectedQuiz.Stages[i].Questions[j].Topic, result.Stages[i].Questions[j].Topic);
                    Assert.Equal(expectedQuiz.Stages[i].Questions[j].Answers.Count, result.Stages[i].Questions[j].Answers.Count);

                    for (int k = 0; k < expectedQuiz.Stages[i].Questions[j].Answers.Count; k++)
                    {
                        Assert.Equal(expectedQuiz.Stages[i].Questions[j].Answers[k].Text, result.Stages[i].Questions[j].Answers[k].Text);
                        Assert.Equal(expectedQuiz.Stages[i].Questions[j].Answers[k].IsCorrect, result.Stages[i].Questions[j].Answers[k].IsCorrect);
                    }
                }
            }
        }


        static void SeedTestData(TreehootApiContext context, List<Quiz> quizzes)
        {
            context.Quiz.AddRange(quizzes);
            context.SaveChanges();
        }
    }
}

