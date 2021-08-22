﻿using MarsRover.Business;
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
            var roverPositionService = serviceProvider.GetService<IRoverPosition>();
            var roverInstructionService = serviceProvider.GetService<IRoverInstruction>();

            //First, get pleteau values
            plateauService.PlateauLonLatValid = true;
            while (plateauService.PlateauLonLatValid)
            {
                Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.FirstElucidating));
                if (plateauService.CheckPlateauLonLat(Console.ReadLine()))
                {
                    //If pleteau values are valid, get rover position
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

                            roverInstructionService.SetRoverPosition(roverPosition);
                            roverInstructionService.RoverInstructionParse(roverInstruction);
                            roverInstructionService.plateau = plateauService;

                            plateauService.RoverInstructionList.Add(roverInstructionService);
                        }
                        else
                            Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.WrongRoverPosition));
                    }
                }
                else
                    Console.WriteLine(EnumExtensions.GetDisplayName(ElucidatingEnum.WrongPlateauLonLat));
                
            }

            foreach (var roverInstruction in plateauService.RoverInstructionList)
            {
                var roverCommandService = serviceProvider.GetService<IRoverCommand>();
                roverCommandService.roverInstruction = roverInstruction;

                foreach (var roverCommand in roverInstruction.roverInstructionList)
                {
                    roverCommandService.AddInstruction(roverCommand);
                }

                roverCommandService.AllInstruction();

                Console.WriteLine($"{roverCommandService.roverInstruction.roverPosition.RoverLongitude} " +
                  $"{roverCommandService.roverInstruction.roverPosition.RoverLatitude} " +
                  $"{roverCommandService.roverInstruction.roverPosition.RoverDirection.ToString()}");
            }

            Console.ReadKey();
        }
    }
}