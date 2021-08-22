using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Abstract
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
                    if (int.TryParse(plateauSize[0], out int latitude))
                    {
                        this.PlateauLatitude = latitude;
                        if (int.TryParse(plateauSize[1], out int longitude))
                        {
                            this.PlateauLongitude = longitude;
                            valid = true;
                            this.PlateauLonLatValid = false;
                        }
                    }
                }
            }
            return valid;
        }
    }
}