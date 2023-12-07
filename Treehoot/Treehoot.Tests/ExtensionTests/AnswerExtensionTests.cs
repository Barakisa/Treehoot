using Xunit;
using Treehoot.Domain.Models;
using Treehoot.Api.Mapping;

namespace Treehoot.Api.Mapping.Tests
{
    public class AnswerExtensionsTests
    {
        [Fact]
        public void ToResponse_SingleAnswer_ShouldMapCorrectly()
        {
            // Arrange
            var question = new Question(new Guid(), "Topic 1", "Question 1");
            var answer = new Answer(new Guid(), true, "Answer") { Question = question };

            // Act
            var result = answer.ToResponse();

            // Assert
            Assert.Equal(answer.Id, result.Id);
            Assert.Equal(answer.Question.Id, result.QuestionId);
            Assert.Equal(answer.IsCorrect, result.IsCorrect);
            Assert.Equal(answer.Text, result.Text);
        }

        [Fact]
        public void ToResponse_ListOfAnswers_ShouldMapCorrectly()
        {
            // Arrange
            var question = new Question(new Guid(), "Topic1", "QuestionText1");
            var answers = new List<Answer>
            {
                new Answer(new Guid(), true, "Answer") { Question = question },
                new Answer(new Guid(), true, "Answer") { Question = question }
            };

            // Act
            var result = answers.ToResponse();

            // Assert
            Assert.Equal(answers.Count, result.Count);

            for (int i = 0; i < answers.Count; i++)
            {
                Assert.Equal(answers[i].Id, result[i].Id);
                Assert.Equal(answers[i].Question.Id, result[i].QuestionId);
                Assert.Equal(answers[i].IsCorrect, result[i].IsCorrect);
                Assert.Equal(answers[i].Text, result[i].Text);
            }
        }
    }
}
