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
            string method = "zero emmision";
            int expectedPoints = 210;

            // Act
            int actualPoints = Score.CalculateScore(distance, method);

            // Assert
            Assert.Equal(expectedPoints, actualPoints);
        }
        [Fact]
        public void randomtest1()
        {
            // Arrange
            int distance = 19;
            string method = "public transit";
            int expectedPoints = 150;

            // Act
            int actualPoints = Score.CalculateScore(distance, method);

            // Assert
            Assert.Equal(expectedPoints, actualPoints);
        }

        [Fact]
        public void CalculateScore_airplane()
        {
            // Arrange
            int distance = 40;
            string method = "airplane";
            int expectedPoints = 150;

            // Act
            int actualPoints = Score.CalculateScore(distance,  method);

            // Assert
            Assert.Equal(expectedPoints, actualPoints);
        }

        [Fact]
        public void CalculateScore_Returns_Correct_Points_For_Long_Distance_Public_Transit_Method()
        {
            // Arrange
            int distance = 100;
            string method = "public transit";
            int expectedPoints = 200;

            // Act
            int actualPoints = Score.CalculateScore(distance,  method);

            // Assert
            Assert.Equal(expectedPoints, actualPoints);
        }

        [Fact]
        public void CalculateScore_Throws_Exception_For_Invalid_Group()
        {
            // Arrange
            int distance = 10;
            string method = "zero emmision";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Score.CalculateScore(distance, method));
        }

        [Fact]
        public void CalculateScore_Throws_Exception_For_Invalid_Method()
        {
            // Arrange
            int distance = 10;
            string method = "invalid method";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Score.CalculateScore(distance, method));
        }
    }
}
