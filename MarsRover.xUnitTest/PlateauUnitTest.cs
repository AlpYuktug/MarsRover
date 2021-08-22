using MarsRover.Business.Abstract;
using MarsRover.Business.Concrete;
using System;
using Xunit;

namespace MarsRover.xUnitTest
{
    public class PlateauUnitTest
    {
        [Fact]
        public void Test_CheckPlateauLonLat()
        {
            bool expected = true;
            bool result = false;

            try
            {
                #region Arrange
                int longitude = 10;
                int latitude = 20;
                Plateau plateau = new();
                #endregion
                #region Act
                result = plateau.CheckPlateauLonLat(longitude.ToString() + " " + latitude.ToString());
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
