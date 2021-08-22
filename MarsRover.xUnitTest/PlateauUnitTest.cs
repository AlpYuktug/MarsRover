using MarsRover.Business.Abstract;
using System;
using Xunit;

namespace MarsRover.xUnitTest
{
    public class PlateauUnitTest
    {
        [Fact]
        public void Test_CheckPlateauLonLat()
        {
            #region Arrange
            int longitude = 10;
            int latitude = 20;
            bool expected = true;
            Plateau plateau = new();
            #endregion
            #region Act
            bool result = plateau.CheckPlateauLonLat(longitude.ToString() + " " + latitude.ToString());
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }
    }
}
