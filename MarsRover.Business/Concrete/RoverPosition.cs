using MarsRover.Business.Abstract;
using MarsRover.Business.AppHelper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Concrete
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
            try
            {
                if (!String.IsNullOrEmpty(roverPosition.Trim()))
                {
                    var roverPositionClean = roverPosition.Trim().Split(' ');
                    if (roverPositionClean.Length == 3)
                    {
                        //Check Rover Position
                        if (int.TryParse(roverPositionClean[0], out int longitude))
                        {
                            this.RoverLongitude = longitude;
                            if (int.TryParse(roverPositionClean[1], out int latitude))
                            {
                                this.RoverLatitude = latitude;

                                var position = roverPositionClean[2].ToString().ToUpper();

                                if (position == "N" || position == "S" || position == "E" || position == "W")
                                {
                                    valid = true;
                                    this.RoverPositionValid = false;
                                }
                            }
                        }
                    }
                }

                return valid;

            }
            catch (Exception)
            {
                return valid;
            }
        }

    }
}