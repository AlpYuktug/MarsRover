using MarsRover.Business.AppHelper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Abstract
{
    public interface IRoverInstruction
    {
        IPlateau plateau { get; set; }
        IRoverPosition roverPosition { get; set; }
        IList<IRoverInstructionBase> roverInstructionList { get; set; }
        bool SetRoverPosition(string roverPosition);
        bool RoverInstructionParse(string getRoverInstruction);
        void RoverBackForward();
        void RoverTurnTheRight();
        void RoverTurnTheLeft();


    }
}