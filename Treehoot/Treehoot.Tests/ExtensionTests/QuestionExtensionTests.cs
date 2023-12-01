using Xunit;
using Treehoot.Domain.Models;

namespace Treehoot.Api.Mapping.Tests
{
    public class QuestionExtensionsTests
    {
        [Fact]
        public void ToResponse_SingleQuestion_ShouldMapCorrectly()
        {
            // Arrange
            var stage = new Stage(1, "Stage 1");
            var question = new Question(1, "Topic 1", "QuestionText 1") { Stage = stage };

            // Act
            var result = question.ToResponse();

            // Assert
            Assert.Equal(question.Id, result.Id);
            Assert.Equal(question.Topic, result.Topic);
            Assert.Equal(question.QuestionText, result.QuestionText);
            Assert.Equal(question.Stage.Id, result.StageId);
        }

        [Fact]
        public void ToResponse_ListOfQuestions_ShouldMapCorrectly()
        {
            // Arrange
            var stage = new Stage(1, "Stage 1");
            var questions = new List<Question>
            {
                new Question(1, "Topic 1", "QuestionText 1") { Stage = stage },
                new Question(2, "Topic 2", "QuestionText 2") { Stage = stage }
            };

            // Act
            var result = questions.ToResponse();

            // Assert
            Assert.Equal(questions.Count, result.Count);

            for (int i = 0; i < questions.Count; i++)
            {
                Assert.Equal(questions[i].Id, result[i].Id);
                Assert.Equal(questions[i].Topic, result[i].Topic);
                Assert.Equal(questions[i].QuestionText, result[i].QuestionText);
                Assert.Equal(questions[i].Stage.Id, result[i].StageId);
            }
        }
    }
}