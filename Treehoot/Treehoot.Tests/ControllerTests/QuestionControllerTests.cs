using Microsoft.AspNetCore.Mvc;
using Moq;
using Treehoot.Api.Controllers;
using Treehoot.Application.Exceptions;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;
using Xunit;

namespace Treehoot.Api.Controller.Tests
{
    public class QuestionControllerTests
    {
        [Fact]
        public async Task GetSingle_WhenQuestionExists_ReturnsOk()
        {
            // Arrange
            var expectedQuestion = new Question(new Guid(), "Topic", "QuestionText");
            expectedQuestion.Stage = new Stage(new Guid(), "Name");

            var questionServiceMock = new Mock<IQuestionService>();
            questionServiceMock.Setup(service => service.GetSingle(It.IsAny<Guid>()))
                .ReturnsAsync(expectedQuestion);
            var controller = new QuestionController(questionServiceMock.Object);

            // Act
            var result = await controller.GetSingle(new Guid());

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetSingle_WhenQuestionDoesntExist_ReturnsNotFound()
        {
            // Arrange
            var nonExistentQuestionId = new Guid();

            var questionServiceMock = new Mock<IQuestionService>();
            questionServiceMock.Setup(service => service.GetSingle(nonExistentQuestionId))
                .ReturnsAsync((Question)null);
            var controller = new QuestionController(questionServiceMock.Object);

            // Act
            var result = await controller.GetSingle(nonExistentQuestionId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetByStageId_WhenQuestionsExist_ReturnsOk()
        {
            // Arrange
            var expectedQuestions = new List<Question>
        {
            new Question(new Guid(), "Topic1", "QuestionText1"),
            new Question(new Guid(), "Topic2", "QuestionText2")
        };
            expectedQuestions.ForEach(question => question.Stage = new Stage(new Guid(), "Name"));

            var questionServiceMock = new Mock<IQuestionService>();
            questionServiceMock.Setup(service => service.GetStageQuestions(It.IsAny<Guid>()))
                .ReturnsAsync(expectedQuestions);
            var controller = new QuestionController(questionServiceMock.Object);

            // Act
            var result = await controller.GetByStageId(new Guid());

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetByStageId_WhenNoQuestionsExist_ReturnsNotFound()
        {
            // Arrange
            var nonExistentStageId = new Guid();

            var questionServiceMock = new Mock<IQuestionService>();
            questionServiceMock.Setup(service => service.GetStageQuestions(nonExistentStageId))
                .ReturnsAsync(new List<Question>());
            var controller = new QuestionController(questionServiceMock.Object);

            // Act
            var result = await controller.GetByStageId(nonExistentStageId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}