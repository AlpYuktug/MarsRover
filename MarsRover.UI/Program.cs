using MarsRover.Business;
using MarsRover.Business.Abstract;
using MarsRover.Business.AppHelper.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add all service class
            var serviceProvider = BusinessInjections.Initialize();

            var plateauService = serviceProvider.GetService<IPlateau>();

            //First, get pleteau values
            plateauService.PlateauLonLatValid = true;
            while (plateauService.PlateauLonLatValid)
            {
                Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.FirstElucidating));
                if (plateauService.CheckPlateauLonLat(Console.ReadLine()))
                {
                    //If pleteau values are valid, get rover position
                    var roverPositionService = serviceProvider.GetService<IRoverPosition>();
                    roverPositionService.RoverPositionValid = true;

                    while (roverPositionService.RoverPositionValid)
                    {
                        Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.RoverPosition));
                        var roverPosition = Console.ReadLine();

                        //If rover position values are valid, get rover instruction
                        if (roverPositionService.CheckRoverPosition(roverPosition))
                        {
                            Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.RoverInstruction));
                            var roverInstruction = Console.ReadLine();
                            //Return for rover instruction
                        }
                        else
                            Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.WrongRoverPosition));
                    }
                }
                else
                    Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.WrongPlateauLonLat));
                
            }
        }
    }
}
