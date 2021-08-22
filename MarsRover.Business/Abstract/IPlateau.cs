using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Abstract
{
    public interface IPlateau
    {
        int PlateauLongitude { get; set; }
        int PlateauLatitude { get; set; }
        bool PlateauLonLatValid { get; set; }
        bool CheckPlateauLonLat(string plateauLonLat);
    }
}
