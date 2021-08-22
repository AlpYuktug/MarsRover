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
            try
            {
                #region Arrange
                int longitude = 1;
                int latitude = 2;
                string direction = "N";
                RoverInstruction roverInstruction = new();
                #endregion
                #region Act
                roverInstruction.SetRoverPosition(longitude.ToString() + " " + latitude.ToString() + " " + direction);
                #endregion
                #region Assert
                Assert.True(true);
                #endregion
            }
            catch (Exception)
            {
                Assert.True(false);
            }

        } 
        
        [Fact]
        public void Test_RoverInstructionParse()
        {
            try
            {
                #region Arrange
                string roverInstructionList = "LMLMLMLMM";
                RoverInstruction roverInstruction = new();
                #endregion
                #region Act
                roverInstruction.RoverInstructionParse(roverInstructionList);
                #endregion
                #region Assert
                Assert.True(true);
                #endregion
            }
            catch (Exception)
            {
                Assert.True(false);
            }

        }
    }
}
