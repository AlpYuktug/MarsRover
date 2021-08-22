using MarsRover.Business.AppHelper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Abstract
{
    public class RoverPosition : IRoverPosition
    {
        public int RoverLongitude { get; set; }
        public int RoverLatitude { get; set; }
        public RoverDirectionEnum RoverDirection { get; set; }
        public bool RoverPositionValid { get; set; }

        public RoverPosition(RoverDirectionEnum roverDirection = RoverDirectionEnum.N, int roverLongitude = 0, int roverLatitude = 0)
        {
            this.RoverLongitude = roverLongitude;
            this.RoverLatitude = roverLatitude;
            this.RoverDirection = roverDirection;
        }

        public bool CheckRoverPosition(string roverPosition)
        {
            bool valid = false;
            this.RoverPositionValid = true;

            if (!String.IsNullOrEmpty(roverPosition.Trim()))
            {
                var roverPositionClean = roverPosition.Trim().Split(' ');
                if (roverPositionClean.Length == 3)
                {
                    //Check Rover Position
                    if (int.TryParse(roverPositionClean[0], out int latitude))
                    {
                        this.RoverLongitude = latitude;
                        if (int.TryParse(roverPositionClean[1], out int longitude))
                        {                         
                            var position = roverPositionClean[2].ToString().ToUpper();

                            if (position == "N" || position == "S" || position == "E" || position == "W")
                            {
                                this.RoverDirection = (RoverDirectionEnum)Enum.Parse(typeof(RoverDirectionEnum), position);
                                this.RoverLongitude = latitude;
                                this.RoverLatitude = longitude;
                                valid = true;
                                this.RoverPositionValid = false;
                            }
                        }
                    }
                }
            }
            return valid;
        }

    }
}