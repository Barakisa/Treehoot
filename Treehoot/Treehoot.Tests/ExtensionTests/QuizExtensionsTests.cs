using Xunit;
using Treehoot.Domain.Models;

namespace Treehoot.Api.Mapping.Tests
{
    public class QuizExtensionsTests
    {
        [Fact]
        public void ToResponse_SingleQuiz_ShouldMapCorrectly()
        {
            // Arrange
            var quiz = new Quiz(1, "Quiz 1", "Description 1");

            // Act
            var result = quiz.ToResponse();

            // Assert
            Assert.Equal(quiz.Id, result.Id);
            Assert.Equal(quiz.Name, result.Name);
            Assert.Equal(quiz.Description, result.Description);
        }

        [Fact]
        public void ToResponse_ListOfQuizzes_ShouldMapCorrectly()
        {
            // Arrange
            var quizzes = new List<Quiz>
            {
                new Quiz(1, "Quiz1", "Description1"),
                new Quiz(2, "Quiz2", "Description2")
            };

            // Act
            var result = quizzes.ToResponse();

            // Assert
            Assert.Equal(quizzes.Count, result.Count);

            for (int i = 0; i < quizzes.Count; i++)
            {
                Assert.Equal(quizzes[i].Id, result[i].Id);
                Assert.Equal(quizzes[i].Name, result[i].Name);
                Assert.Equal(quizzes[i].Description, result[i].Description);
            }
        }
    }
}
