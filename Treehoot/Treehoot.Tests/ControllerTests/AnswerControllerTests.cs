using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treehoot.Api.Controllers;
using Treehoot.Application.Exceptions;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;
using Xunit;

namespace Treehoot.Api.Controller.Tests
{
    public class AnswerControllerTests
    {
        [Fact]
        public async Task GetByQuestionId_WhenAnswersExist_ReturnsOk()
        {
            // Arrange
            var expectedAnswers = new List<Answer>
        {
            new Answer(1, true , "Text"),
            new Answer(2, false, "Text")
        };
            expectedAnswers.ForEach(answer => answer.Question = new Question(1, "Topic", "QuestionText"));

            var answerServiceMock = new Mock<IAnswerService>();
            answerServiceMock.Setup(service => service.GetQuestionAnswers(It.IsAny<int>()))
                .ReturnsAsync(expectedAnswers);
            var controller = new AnswerController(answerServiceMock.Object);

            // Act
            var result = await controller.GetByQuestionId(1);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetByQuestionId_WhenNoAnswersExist_ReturnsNotFound()
        {
            // Arrange
            var nonExistentQuestionId = -1;

            var answerServiceMock = new Mock<IAnswerService>();
            answerServiceMock.Setup(service => service.GetQuestionAnswers(nonExistentQuestionId))
                .ReturnsAsync(new List<Answer>());
            var controller = new AnswerController(answerServiceMock.Object);

            // Act
            var result = await controller.GetByQuestionId(nonExistentQuestionId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}
