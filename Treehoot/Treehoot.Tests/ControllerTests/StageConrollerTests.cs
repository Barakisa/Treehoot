using Microsoft.AspNetCore.Mvc;
using Moq;
using Treehoot.Api.Controllers;
using Treehoot.Application.Exceptions;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;
using Xunit;

public class StageControllerTests
{
    [Fact]
    public async Task GetByQuizId_WhenStagesExist_ReturnsOk()
    {
        // Arrange
        var quizId = 1;
        var stages = new List<Stage>
            {
                new Stage(11,"stage 1"),
                new Stage(12,"stage 2"),
            };

        var stageServiceMock = new Mock<IStageService>();
        stageServiceMock.Setup(service => service.GetQuizStages(quizId))
            .ReturnsAsync(stages);

        var apiCallResultServiceMock = new Mock<IApiCallResultService>();

        var controller = new StageController(stageServiceMock.Object, apiCallResultServiceMock.Object);

        // Act
        var result = await controller.GetByQuizId(quizId);

        Assert.IsType<OkObjectResult>(result.Result);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);

        var response = Assert.IsType<List<Stage>>(okResult.Value);

        Assert.NotNull(response);
        Assert.Equal(stages.Count, response.Count);

        Assert.Equal("stage 1", response[0].Name);
        Assert.Equal("stage 2", response[1].Name);
    }

    [Fact]
        public async Task GetByQuizId_WhenStagesDoNotExist_ReturnsNotFound()
        {
            // Arrange
            var quizId = 1;

            var stageServiceMock = new Mock<IStageService>();
            stageServiceMock.Setup(service => service.GetQuizStages(quizId))
                .ReturnsAsync(new List<Stage>());

            var apiCallResultServiceMock = new Mock<IApiCallResultService>();

            var controller = new StageController(stageServiceMock.Object, apiCallResultServiceMock.Object);

            // Act
            var result = await controller.GetByQuizId(quizId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);

        }

        [Fact]
        public async Task GetByQuizId_WhenNotFoundExceptionThrown_ReturnsNotFound()
        {
            // Arrange
            var quizId = 1;

            var stageServiceMock = new Mock<IStageService>();
            stageServiceMock.Setup(service => service.GetQuizStages(quizId))
                .ThrowsAsync(new NotFoundException("stage", "quiz", quizId));

            var apiCallResultServiceMock = new Mock<IApiCallResultService>();

            var controller = new StageController(stageServiceMock.Object, apiCallResultServiceMock.Object);

            // Act
            var result = await controller.GetByQuizId(quizId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
 
        }
    }




