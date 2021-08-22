using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Abstract
{
    public interface IRoverCommand
    {
        IRoverInstruction roverInstruction { get; set; }
        void AddInstruction(IRoverInstructionBase roverInstructionBase);
        void AllInstruction();
    }
}
