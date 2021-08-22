using MarsRover.Business.Abstract;
using MarsRover.Business.AppHelper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarsRover.Business.Concrete
{
    public class RoverAction
    {
        public static IRoverPosition Move(IRoverPosition roverPosition)
        {
            IRoverPosition moveRoverPosition = roverPosition;
            try
            {
                if (roverPosition.RoverDirection == RoverDirectionEnum.N)
                    moveRoverPosition = new RoverPosition(roverPosition.RoverDirection, roverPosition.RoverLongitude, roverPosition.RoverLatitude + 1);
                else if (roverPosition.RoverDirection == RoverDirectionEnum.S)
                    moveRoverPosition = new RoverPosition(roverPosition.RoverDirection, roverPosition.RoverLongitude, roverPosition.RoverLatitude - 1);
                else if (roverPosition.RoverDirection == RoverDirectionEnum.W)
                    moveRoverPosition = new RoverPosition(roverPosition.RoverDirection, roverPosition.RoverLongitude - 1, roverPosition.RoverLatitude);
                else if (roverPosition.RoverDirection == RoverDirectionEnum.E)
                    moveRoverPosition = new RoverPosition(roverPosition.RoverDirection, roverPosition.RoverLongitude + 1, roverPosition.RoverLatitude);
                else
                    throw new Exception();

            }
            catch (Exception)
            {
                Assert.True(false);
                throw;
            }
        
            return moveRoverPosition;
        }

        public static RoverDirectionEnum TurnRight(RoverDirectionEnum roverDirection)
        {
            RoverDirectionEnum moveRoverDirection = roverDirection;
            try
            {
                if (moveRoverDirection == RoverDirectionEnum.N)
                    moveRoverDirection = RoverDirectionEnum.E;
                else if (moveRoverDirection == RoverDirectionEnum.S)
                    moveRoverDirection = RoverDirectionEnum.W;
                else if (moveRoverDirection == RoverDirectionEnum.W)
                    moveRoverDirection = RoverDirectionEnum.N;
                else if (moveRoverDirection == RoverDirectionEnum.E)
                    moveRoverDirection = RoverDirectionEnum.S;
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                Assert.True(false);
                throw;
            }
     

            return moveRoverDirection;
        }

        public static RoverDirectionEnum TurnLeft(RoverDirectionEnum roverDirection)
        {
            RoverDirectionEnum moveRoverDirection = roverDirection;
            try
            {
                if (moveRoverDirection == RoverDirectionEnum.N)
                    moveRoverDirection = RoverDirectionEnum.W;
                else if (moveRoverDirection == RoverDirectionEnum.S)
                    moveRoverDirection = RoverDirectionEnum.E;
                else if (moveRoverDirection == RoverDirectionEnum.W)
                    moveRoverDirection = RoverDirectionEnum.S;
                else if (moveRoverDirection == RoverDirectionEnum.E)
                    moveRoverDirection = RoverDirectionEnum.N;
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                Assert.True(false);
                throw;
            }
   

            return moveRoverDirection;
        }
    }
}