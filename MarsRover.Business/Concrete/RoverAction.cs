using MarsRover.Business.Abstract;
using MarsRover.Business.AppHelper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Concrete
{
    public class RoverAction
    {
        public static IRoverPosition Move(IRoverPosition roverPosition)
        {
            IRoverPosition currentRoverPosition = roverPosition;

            if (roverPosition.RoverDirection == RoverDirectionEnum.N)
                currentRoverPosition = new RoverPosition(roverPosition.RoverDirection, roverPosition.RoverLongitude, roverPosition.RoverLatitude + 1);
            else if (roverPosition.RoverDirection == RoverDirectionEnum.S)
                currentRoverPosition = new RoverPosition(roverPosition.RoverDirection, roverPosition.RoverLongitude, roverPosition.RoverLatitude - 1);
            else if (roverPosition.RoverDirection == RoverDirectionEnum.W)
                currentRoverPosition = new RoverPosition(roverPosition.RoverDirection, roverPosition.RoverLongitude - 1, roverPosition.RoverLatitude);
            else if (roverPosition.RoverDirection == RoverDirectionEnum.E)
                currentRoverPosition = new RoverPosition(roverPosition.RoverDirection, roverPosition.RoverLongitude + 1, roverPosition.RoverLatitude);
            else
                currentRoverPosition = new RoverPosition(roverPosition.RoverDirection, roverPosition.RoverLongitude, roverPosition.RoverLatitude + 1);

            return currentRoverPosition;
        }

        public static RoverDirectionEnum TurnRight(RoverDirectionEnum roverDirection)
        {
            RoverDirectionEnum currentRoverDirection = roverDirection;

            if (currentRoverDirection == RoverDirectionEnum.N)
                currentRoverDirection = RoverDirectionEnum.E;
            else if (currentRoverDirection == RoverDirectionEnum.S)
                currentRoverDirection = RoverDirectionEnum.W;
            else if (currentRoverDirection == RoverDirectionEnum.W)
                currentRoverDirection = RoverDirectionEnum.N;
            else if (currentRoverDirection == RoverDirectionEnum.E)
                currentRoverDirection = RoverDirectionEnum.S;
            else
                currentRoverDirection = RoverDirectionEnum.E;

            return currentRoverDirection;
        }

        public static RoverDirectionEnum TurnLeft(RoverDirectionEnum roverDirection)
        {
            RoverDirectionEnum currentRoverDirection = roverDirection;

            if (currentRoverDirection == RoverDirectionEnum.N)
                currentRoverDirection = RoverDirectionEnum.W;
            else if (currentRoverDirection == RoverDirectionEnum.S)
                currentRoverDirection = RoverDirectionEnum.E;
            else if (currentRoverDirection == RoverDirectionEnum.W)
                currentRoverDirection = RoverDirectionEnum.S;
            else if (currentRoverDirection == RoverDirectionEnum.E)
                currentRoverDirection = RoverDirectionEnum.N;
            else
                currentRoverDirection = RoverDirectionEnum.E;

            return currentRoverDirection;
        }
    }
}