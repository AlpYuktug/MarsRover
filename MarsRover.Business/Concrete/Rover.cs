using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Abstract
{
    public class Rover : IRover
    {
        public IRoverPosition roverPosition { get; set; }
        public IPlateau plateau { get; set; }

        public Rover(IRoverPosition roverPosition, IPlateau plateau)
        {
            this.roverPosition = roverPosition;
            this.plateau = plateau;
        }
    }
}