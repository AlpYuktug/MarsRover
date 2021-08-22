using MarsRover.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Concrete
{
    public class RoverInstructionRight : IRoverInstructionBase
    {
        IRoverInstruction roverInstruction;

        public RoverInstructionRight(IRoverInstruction roverInstruction)
        {
            this.roverInstruction = roverInstruction;
        }

        public void RoverInstruction()
        {
            this.roverInstruction.RoverTurnTheRight();
        }
    }
}
