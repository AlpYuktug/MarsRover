using MarsRover.Business.Abstract;
using MarsRover.Business.Concrete;
using System;
using Xunit;

namespace MarsRover.xUnitTest
{
    public class RoverInstructionUnitTest
    {
        [Fact]
        public void Test_SetRoverPosition()
        {
            bool expected = true;
            bool result = false;

            try
            {
                #region Arrange
                int longitude = 1;
                int latitude = 2;
                string direction = "N";
                RoverInstruction roverInstruction = new();
                #endregion
                #region Act
                result = roverInstruction.SetRoverPosition(longitude.ToString() + " " + latitude.ToString() + " " + direction);
                #endregion
                #region Assert
                Assert.Equal(expected, result);
                #endregion
            }
            catch (Exception)
            {
                Assert.Equal(expected, result);
            }

        } 
        
        [Fact]
        public void Test_RoverInstructionParse()
        {
            bool expected = true;
            bool result = false;

            try
            {
                #region Arrange
                string roverInstructionList = "LMLMLMLMM";
                RoverInstruction roverInstruction = new();
                #endregion
                #region Act
                result = roverInstruction.RoverInstructionParse(roverInstructionList);
                #endregion
                #region Assert
                Assert.Equal(expected, result);
                #endregion
            }
            catch (Exception)
            {
                Assert.Equal(expected, result);
            }

        }
    }
}
