using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.AppHelper.Enums
{
    public enum ElucidatingEnum
    {
        [Display(Name = "Please determine the latitude and longitude values for the plateau (e.g.:5 5).")]
        FirstElucidating,
        [Display(Name = "Invalid data (e.g.:5 5).")]
        WrongPlateauLonLat,
        [Display(Name = "Rover Position")]
        RoverPosition,
        [Display(Name = "Rover Instruction")]
        RoverInstruction,
        [Display(Name = "Invalid data (e.g.:1 2 N).")]
        WrongRoverPosition,
        [Display(Name = "Invalid data (e.g.:LMLMLMLMM).")]
        WrongRoverInstruction
    }

}