using Treehoot.Domain.Models;
using Xunit;

namespace Treehoot.Domain.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void CompareTo_WhenScoresAreGreaterThanOther_Returns1()
        {
            // Arrange
            var player1 = new Player { Scores = new List<int> { 5, 10, 15 } };
            var player2 = new Player { Scores = new List<int> { 3, 8, 12 } };

            // Act
            var result = player1.CompareTo(player2);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void CompareTo_WhenScoresAreLessThanOther_ReturnsMinus1()
        {
            // Arrange
            var player1 = new Player { Scores = new List<int> { 3, 8, 12 } };
            var player2 = new Player { Scores = new List<int> { 5, 10, 15 } };

            // Act
            var result = player1.CompareTo(player2);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void CompareTo_WhenScoresAreEqual_Returns0()
        {
            // Arrange
            var player1 = new Player { Scores = new List<int> { 5, 10, 15 } };
            var player2 = new Player { Scores = new List<int> { 5, 10, 15 } };

            // Act
            var result = player1.CompareTo(player2);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CompareTo_WhenOtherIsNull_Return0()
        {
            // Arrange
            var player1 = new Player { Scores = new List<int> { 5, 10, 15 } };

            // Act
            var result = player1.CompareTo(null);

            // Assert
            Assert.Equal(1, result);
        }
    }
}