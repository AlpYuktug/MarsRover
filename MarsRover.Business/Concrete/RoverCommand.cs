using MarsRover.Business.Abstract;
using MarsRover.Business.AppHelper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Concrete
{
    public class RoverCommand : IRoverCommand
    {
        public IRoverInstruction roverInstruction { get; set; }
        private Queue<IRoverInstructionBase> roverInstructionBaseList = new Queue<IRoverInstructionBase>();

        public RoverCommand(IRoverInstruction roverInstruction)
        {
            this.roverInstruction = roverInstruction;
        }

        public void AddInstruction(IRoverInstructionBase roverInstructionBase)
        {
            roverInstructionBaseList.Enqueue(roverInstructionBase);
        }

        public void AllInstruction()
        {
            while (roverInstructionBaseList.Count > 0)
            {
                IRoverInstructionBase roverInstructionBase = roverInstructionBaseList.Dequeue();
                roverInstructionBase.RoverInstruction();
            }
        }
    }
}