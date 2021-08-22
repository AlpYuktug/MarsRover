using MarsRover.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Concrete
{
    public class Plateau : IPlateau
    {
        public int PlateauLongitude { get; set; }
        public int PlateauLatitude { get; set; }
        public bool PlateauLonLatValid { get; set; }
        public bool CheckPlateauLonLat(string plateauLonLat)
        {
            bool valid = false;
            this.PlateauLonLatValid = true;

            if (!String.IsNullOrEmpty(plateauLonLat.Trim()))
            {
                var plateauSize = plateauLonLat.Trim().Split(' ');
                if (plateauSize.Length == 2)
                {
                    //Check Longitude and Latitude
                    if (int.TryParse(plateauSize[0], out int longitude))
                    {
                        if (int.TryParse(plateauSize[1], out int latitude))
                        {
                            valid = true;
                            this.PlateauLonLatValid = false;
                        }
                    }
                }
            }
            return valid;
        }
        public IList<IRoverInstruction> RoverInstructionList { get; set; }

        public Plateau()
        {
            this.RoverInstructionList = new List<IRoverInstruction>();
        }

        public Plateau(int plateauLongitude, int plateauLatitude)
        {
            PlateauLongitude = plateauLongitude;
            PlateauLatitude = plateauLatitude;
        }

    }
}