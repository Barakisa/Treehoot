using Microsoft.AspNetCore.Mvc;
using Moq;
using Treehoot.Api.Controllers;
using Treehoot.Application.Exceptions;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;
using Xunit;

namespace Treehoot.Api.Controller.Tests
{
    public class StageControllerTests
    {
        [Fact]
        public async Task GetSingle_WhenStageExists_ReturnsOk()
        {
            // Arrange
            var expectedStage = new Stage(new Guid(), "Name");
            expectedStage.Quiz = new Quiz(new Guid(), "Name", "Description");

            var stageServiceMock = new Mock<IStageService>();
            stageServiceMock.Setup(service => service.GetSingle(It.IsAny<Guid>()))
                .ReturnsAsync(expectedStage);
            var controller = new StageController(stageServiceMock.Object);

            // Act
            var result = await controller.GetSingle(new Guid());

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetSingle_WhenStageDoesntExist_ReturnsNotFound()
        {
            // Arrange
            var nonExistentStageId = new Guid();

            var stageServiceMock = new Mock<IStageService>();
            stageServiceMock.Setup(service => service.GetSingle(nonExistentStageId))
                .ReturnsAsync((Stage)null);
            var controller = new StageController(stageServiceMock.Object);

            // Act
            var result = await controller.GetSingle(nonExistentStageId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetByQuizId_WhenStagesExist_ReturnsOk()
        {
            // Arrange
            var expectedStages = new List<Stage>
        {
            new Stage(new Guid(), "Name1"),
            new Stage(new Guid(), "Name2")
        };
            expectedStages.ForEach(stage => stage.Quiz = new Quiz(new Guid(), "QuizName", "QuizDescription"));

            var stageServiceMock = new Mock<IStageService>();
            stageServiceMock.Setup(service => service.GetQuizStages(It.IsAny<Guid>()))
                .ReturnsAsync(expectedStages);
            var controller = new StageController(stageServiceMock.Object);

            // Act
            var result = await controller.GetByQuizId(new Guid());

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetByQuizId_WhenNoStagesExist_ReturnsNotFound()
        {
            // Arrange
            var nonExistentQuizId = new Guid();

            var stageServiceMock = new Mock<IStageService>();
            stageServiceMock.Setup(service => service.GetQuizStages(nonExistentQuizId))
                .ReturnsAsync(new List<Stage>());
            var controller = new StageController(stageServiceMock.Object);

            // Act
            var result = await controller.GetByQuizId(nonExistentQuizId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}