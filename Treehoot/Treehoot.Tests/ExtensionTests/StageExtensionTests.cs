using Xunit;
using Treehoot.Domain.Models;
using Treehoot.Api.Maping;

namespace Treehoot.Api.Mapping.Tests
{
    public class StageExtensionsTests
    {
        [Fact]
        public void ToResponse_SingleStage_ShouldMapCorrectly()
        {
            // Arrange
            var quiz = new Quiz(1, "Quiz 1", "Description 1");
            var stage = new Stage(1, "Stage 1") { Quiz = quiz };

            // Act
            var result = stage.ToResponse();

            // Assert
            Assert.Equal(stage.Id, result.Id);
            Assert.Equal(stage.Name, result.Name);
            Assert.Equal(stage.Quiz.Id, result.QuizId);
        }

        [Fact]
        public void ToResponse_ListOfStages_ShouldMapCorrectly()
        {
            // Arrange
            var quiz = new Quiz(1, "Quiz 1", "Description 1");
            var stages = new List<Stage>
            {
                new Stage(1, "Stage 1") { Quiz = quiz },
                new Stage(2, "Stage 2") { Quiz = quiz }
            };

            // Act
            var result = stages.ToResponse();

            // Assert
            Assert.Equal(stages.Count, result.Count);

            for (int i = 0; i < stages.Count; i++)
            {
                Assert.Equal(stages[i].Id, result[i].Id);
                Assert.Equal(stages[i].Name, result[i].Name);
                Assert.Equal(stages[i].Quiz.Id, result[i].QuizId);
            }
        }
    }
}
