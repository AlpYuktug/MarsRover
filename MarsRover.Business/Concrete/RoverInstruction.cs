using MarsRover.Business.Abstract;
using MarsRover.Business.AppHelper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Concrete

{
    public class RoverInstruction : IRoverInstruction
    {
        public IPlateau plateau { get; set; }
        public IRoverPosition roverPosition { get; set; }
        public IList<IRoverInstructionBase> roverInstructionList { get; set; }

        public RoverInstruction(IPlateau platea, IRoverPosition roverPosition)
        {
            this.plateau = plateau;
            this.roverPosition = roverPosition;
            this.roverInstructionList = new List<IRoverInstructionBase>();
        }

        public RoverInstruction()
        {
            this.roverInstructionList = new List<IRoverInstructionBase>();
        }

        public void SetRoverPosition(string roverPosition)
        {
            var roverPositionClean = roverPosition.Trim().Split(' ');

            //Check Rover Position
            if (int.TryParse(roverPositionClean[0], out int longitude))
            {
                if (int.TryParse(roverPositionClean[1], out int latitude))
                {
                    var position = roverPositionClean[2].ToString().ToUpper();

                    if (position == "N" || position == "S" || position == "E" || position == "W")
                    {
                        this.roverPosition.RoverDirection = (RoverDirectionEnum)Enum.Parse(typeof(RoverDirectionEnum), position);
                        this.roverPosition.RoverLatitude = latitude;
                        this.roverPosition.RoverLongitude = longitude;
                    }
                }
            }
        }

        public void RoverInstructionParse(string getRoverInstruction)
        {
            foreach (var itemInstruction in getRoverInstruction.ToCharArray())
            {
                if (char.ToUpper(itemInstruction) == 'M')
                    this.roverInstructionList.Add(new RoverInstructionBackForward(this));

                else if (char.ToUpper(itemInstruction) == 'L')
                    this.roverInstructionList.Add(new RoverInstructionLeft(this));

                else if (char.ToUpper(itemInstruction) == 'R')
                    this.roverInstructionList.Add(new RoverInstructionRight(this));
                else
                    this.roverInstructionList.Add(new RoverInstructionBackForward(this));
            }
        }

        public void RoverBackForward()
        {
            this.roverPosition = RoverAction.Move(this.roverPosition);
        }

        public void RoverTurnTheRight()
        {
            this.roverPosition.RoverDirection = RoverAction.TurnRight(this.roverPosition.RoverDirection);
        }

        public void RoverTurnTheLeft()
        {
            this.roverPosition.RoverDirection = RoverAction.TurnLeft(this.roverPosition.RoverDirection);
        }
    }
}