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
            var expectedQuestion = new Question(1, "Topic", "QuestionText");
            expectedQuestion.Stage = new Stage(1, "Name");

            var questionServiceMock = new Mock<IQuestionService>();
            questionServiceMock.Setup(service => service.GetSingle(It.IsAny<int>()))
                .ReturnsAsync(expectedQuestion);
            var controller = new QuestionController(questionServiceMock.Object);

            // Act
            var result = await controller.GetSingle(1);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetSingle_WhenQuestionDoesntExist_ReturnsNotFound()
        {
            // Arrange
            var nonExistentQuestionId = -1;

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
            new Question(1, "Topic1", "QuestionText1"),
            new Question(2, "Topic2", "QuestionText2")
        };
            expectedQuestions.ForEach(question => question.Stage = new Stage(1, "Name"));

            var questionServiceMock = new Mock<IQuestionService>();
            questionServiceMock.Setup(service => service.GetStageQuestions(It.IsAny<int>()))
                .ReturnsAsync(expectedQuestions);
            var controller = new QuestionController(questionServiceMock.Object);

            // Act
            var result = await controller.GetByStageId(1);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetByStageId_WhenNoQuestionsExist_ReturnsNotFound()
        {
            // Arrange
            var nonExistentStageId = -1;

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