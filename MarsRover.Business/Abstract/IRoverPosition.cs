using MarsRover.Business.AppHelper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Abstract
{
    public interface IRoverPosition
    {
        int RoverLongitude { get; set; }
        int RoverLatitude { get; set; }
        RoverDirectionEnum RoverDirection { get; set; }
        bool RoverPositionValid { get; set; }
        bool CheckRoverPosition(string roverPosition);
    }
}