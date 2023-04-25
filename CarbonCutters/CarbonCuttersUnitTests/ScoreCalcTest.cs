using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarbonCuttersCore;
using Xunit;
using Xunit.Abstractions;

namespace CarbonCuttersUnitTests
{
    public class ScoreCalculatorTests
    {
        [Fact]
        public void CalculateScore_Returns_Correct_Points_For_Close_Distance_Zero_Emmision_Method()
        {
            // Arrange
            int distance = 20;
            string group = "close distance";
            string method = "zeroEmmision";
            int expectedPoints = 210;

            // Act
            int actualPoints = Score.CalculateScore(distance, group, method);

            // Assert
            Assert.Equal(expectedPoints, actualPoints);
        }

        [Fact]
        public void CalculateScore_Returns_Correct_Points_For_Medium_Distance_Car_Method()
        {
            // Arrange
            int distance = 40;
            string group = "medium distance";
            string method = "car";
            int expectedPoints = 140;

            // Act
            int actualPoints = Score.CalculateScore(distance, group, method);

            // Assert
            Assert.Equal(expectedPoints, actualPoints);
        }

        [Fact]
        public void CalculateScore_Returns_Correct_Points_For_Long_Distance_Public_Transit_Method()
        {
            // Arrange
            int distance = 100;
            string group = "long distance";
            string method = "publicTransit";
            int expectedPoints = 200;

            // Act
            int actualPoints = Score.CalculateScore(distance, group, method);

            // Assert
            Assert.Equal(expectedPoints, actualPoints);
        }

        [Fact]
        public void CalculateScore_Throws_Exception_For_Invalid_Group()
        {
            // Arrange
            int distance = 10;
            string group = "invalid group";
            string method = "zeroEmmision";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Score.CalculateScore(distance, group, method));
        }

        [Fact]
        public void CalculateScore_Throws_Exception_For_Invalid_Method()
        {
            // Arrange
            int distance = 10;
            string group = "close distance";
            string method = "invalid method";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Score.CalculateScore(distance, group, method));
        }
    }
}
