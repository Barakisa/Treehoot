using Microsoft.AspNetCore.Mvc;
using Moq;
using Treehoot.Api.Controllers;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;
using Xunit;

namespace Treehoot.Api.Controller.Tests
{

    public class QuizControllerTests
    {
        [Fact]
        public async Task GetAll_WhenQuizzesExist_ReturnsOk()
        {
            // Arrange
            var expectedQuizzes = new List<Quiz>
        {
            new Quiz(1, "Quiz 1", "Description 1"),
            new Quiz(2, "Quiz 2", "Description 2"),
        };

            var quizServiceMock = new Mock<IQuizService>();
            quizServiceMock.Setup(service => service.GetAll())
                .ReturnsAsync(expectedQuizzes);
            var controller = new QuizController(quizServiceMock.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAll_WhenQuizzesDontExist_ReturnsNotFound()
        {
            // Arrange
            var expectedQuizzes = new List<Quiz>();

            var quizServiceMock = new Mock<IQuizService>();
            quizServiceMock.Setup(service => service.GetAll())
                .ReturnsAsync(expectedQuizzes);
            var controller = new QuizController(quizServiceMock.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetSingle_WhenQuizExists_ReturnsOk()
        {
            // Arrange
            var expectedQuiz = new Quiz(1, "Name", "Description");

            var quizServiceMock = new Mock<IQuizService>();
            quizServiceMock.Setup(service => service.GetSingle(It.IsAny<int>()))
                .ReturnsAsync(expectedQuiz);
            var controller = new QuizController(quizServiceMock.Object);

            // Act
            var result = await controller.GetSingle(1);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetSingle_WhenQuizDoesntExist_ReturnsNotFound()
        {
            // Arrange
            var nonExistentQuizId = 999;

            var quizServiceMock = new Mock<IQuizService>();
            quizServiceMock.Setup(service => service.GetSingle(nonExistentQuizId))
                .ReturnsAsync((Quiz)null);
            var controller = new QuizController(quizServiceMock.Object);

            // Act
            var result = await controller.GetSingle(nonExistentQuizId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}