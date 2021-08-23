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

            plateauService.PlateauLonLatValid = true;
            while (plateauService.PlateauLonLatValid)
            {
                var roverPositionService = serviceProvider.GetService<IRoverPosition>();

                Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.FirstElucidating));

                //First, get pleteau values. If PlateauLon and PlateauLat are true the process continues.
                if (plateauService.CheckPlateauLonLat(Console.ReadLine()))
                {
                    //If pleteau values are valid, get rover position
                    roverPositionService.RoverPositionValid = true;

                    while (roverPositionService.RoverPositionValid)
                    {
                        var roverInstructionService = serviceProvider.GetService<IRoverInstruction>();

                        Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.RoverPosition));
                        var roverPosition = Console.ReadLine();

                        //If rover position values are valid, get rover instruction
                        if (roverPositionService.CheckRoverPosition(roverPosition))
                        {
                            Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.RoverInstruction));
                            var roverInstruction = Console.ReadLine();
                            //Return for rover instruction. Check for rover position
                            if (roverInstructionService.SetRoverPosition(roverPosition))
                            {
                                //Return for rover instruction. Check for rover instruction
                                if (roverInstructionService.RoverInstructionParse(roverInstruction))
                                {
                                    roverInstructionService.plateau = plateauService;
                                    plateauService.RoverInstructionList.Add(roverInstructionService);
                                }
                                else
                                    Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.WrongRoverInstruction));
                            }
                            else
                                Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.WrongRoverPosition));


                            //Add more rover
                            Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.AddDiffrentRover));
                            var addDiffrentRover = Console.ReadLine();
                            if (addDiffrentRover.ToUpper() == "Y")
                                roverPositionService.RoverPositionValid = true;
                        }
                        else
                            Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.WrongRoverPosition));
                    }
                }
                else
                    Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.WrongPlateauLonLat));
                
            }

            //Display all rover
            int countRover = 1;
            Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.RoverResult));
            foreach (var roverInstruction in plateauService.RoverInstructionList)
            {
                var roverCommandService = serviceProvider.GetService<IRoverCommand>();
                roverCommandService.roverInstruction = roverInstruction;

                foreach (var roverCommand in roverInstruction.roverInstructionList)
                {
                    roverCommandService.AddInstruction(roverCommand);
                }

                roverCommandService.AllInstruction();

                Console.WriteLine(
                  $"{countRover}. Rover: " +
                  $"{roverCommandService.roverInstruction.roverPosition.RoverLongitude} " +
                  $"{roverCommandService.roverInstruction.roverPosition.RoverLatitude} " +
                  $"{roverCommandService.roverInstruction.roverPosition.RoverDirection.ToString()}");

                countRover++;
            }

            Console.ReadKey();
        }
    }
}