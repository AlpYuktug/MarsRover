using MarsRover.Business.Abstract;
using System;
using Xunit;

namespace MarsRover.xUnitTest
{
    public class RoverPositionUnitTest
    {
        [Fact]
        public void CheckRoverPosition()
        {
            #region Arrange
            int longitude = 1;
            int latitude = 2;
            string direction = "N";
            bool expected = true;
            RoverPosition rover = new();
            #endregion
            #region Act
            bool result = rover.CheckRoverPosition(longitude.ToString() + " " + latitude.ToString()+ " " + direction);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }
    }
}
