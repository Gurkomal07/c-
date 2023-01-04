
using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main()
        {
            /* Purpose:to create a costed Packing Slip reflecting the materials needed to renovate a bedroom.
               Input: User need to input the dimensions of the room, door, window and closet door. Along with
                      it user must select the type of paint he wanted and type of flooring.Finally user needs 
                      to enter cost of baseboarding and casing.
               Output: Program will tell the total cost of painting, flooring, baseboarding, casing and total cost.
               Written by: Gurkomal Singh
               Written to: Cody Schellenberger(CPSC 1012)
               Section: OA03
               Test Plan:
                  Test Case |	Test Data                   |  Expected Results
                      01    	Room Length            10     	 Nettotal               470.59
                                Room Breadth           8         Total                  494.12
                                
                                Window Length          2
                                Window Breadth         2
                                Door length            3
                                Door breadth           3
                                closet length          4
                                closet breadth         3
                                paint type             basic
                                flooring type          tiles
                                price of casing        2
                                price of baseboarding  3

                      02    	Room Length            15     	 Nettotal               974.99
                                Room Breadth           12        Total                  1,023.74
                                
                                Window Length          2
                                Window Breadth         4
                                Door length            6
                                Door breadth           5
                                closet length          3
                                closet breadth         3
                                paint type             premium
                                flooring type          carpet
                                price of casing        2.9
                                price of baseboarding  6.3       
            
                      03    	Room Length            25     	 Nettotal               3,405.68
                                Room Breadth           20        Total                  3.575.97
                                
                                Window Length          5
                                Window Breadth         4
                                Door length            6
                                Door breadth           4
                                closet length          4
                                closet breadth         3
                                paint type             delux
                                flooring type          hardwood
                                price of casing        9.99
                                price of baseboarding  4.23     
            
               Last modified:  2021.10.17
               Algorithm: The program will calculate the area of the room(roof, walls and floor separately),
                        window, entry gate and closet door. Then it will follow the users command to calculate the total 
                       cost for painting, flooring, baseboarding and casing.
                 */
            double roomLength, roomWidth;
            double entryDoorLength, entryDoorWidth;
            double windowLength, windowWidth;
            double closetDoorLength, closetDoorWidth;
            double areaWalls, areaCeiling, areaFloor, areaEntryDoor, areaClosetDoor;
            double casingLength, baseboardingLength, areaPaintWalls;
            double priceBaseboard, priceCasing;
            double paintCost, flooringCost, netPrice, totalPrice;
            const int TOTAL_GST = 5;
            int numberGallonWalls, numberGallonCeiling;

            Console.WriteLine($" Renovation Calculator\n" +
                $"***********************\n");

            Console.WriteLine($"Enter dimensions of the room(of height 8 feet) in feet.\n" +
                              $"What is length of the room?");
            roomLength = double.Parse(Console.ReadLine());

            Console.WriteLine($"What is width of the room?");
            roomWidth = double.Parse(Console.ReadLine());

            Console.WriteLine($"\nEnter dimensions of the entry door in feet.\n" +
                             $"What is length of the entry door?");
            entryDoorLength = double.Parse(Console.ReadLine());

            Console.WriteLine($"What is width of the entry door?");
            entryDoorWidth = double.Parse(Console.ReadLine());

            Console.WriteLine($"\nEnter dimensions of the window in feet.\n" +
                             $"What is length of the window?");
            windowLength = double.Parse(Console.ReadLine());

            Console.WriteLine($"What is width of the window?");
            windowWidth = double.Parse(Console.ReadLine());

            Console.WriteLine($"\nEnter dimensions of the closet door in feet.\n" +
                             $"What is length of the closet door?");
            closetDoorLength = double.Parse(Console.ReadLine());

            Console.WriteLine($"What is width of the closet door?");
            closetDoorWidth = double.Parse(Console.ReadLine());


            areaClosetDoor = closetDoorLength * closetDoorWidth;
            areaEntryDoor = entryDoorLength * entryDoorWidth;
            areaFloor = areaCeiling = roomLength * roomWidth;
            areaWalls = 2 * (roomLength + roomWidth) * 8;
            casingLength = (((2 * entryDoorLength) + entryDoorWidth) + ((2 * closetDoorLength) + closetDoorWidth) + (2 * (windowLength + windowWidth)));
            baseboardingLength = 2 * (roomLength + roomWidth) - (closetDoorWidth + entryDoorWidth);
            areaPaintWalls = areaWalls - (areaEntryDoor + areaClosetDoor + areaEntryDoor);

            double costGallonBasic = 29.99;
            double costGallonPremium = 39.99;
            double costGallonDelux = 49.99;

            Console.WriteLine($"\nSelect the type of paint you want on your room's walls and ceilings" +
                $"Enter number 1 or 2 or 3, according to your preference:\n" +
                $"1. Basic ($29.99 / gallon )\n" +
                $"2. Premium ($39.99  / gallon )\n" +
                $"3. Delux ($49.99 / gallon )\n");
            int paintType = int.Parse(Console.ReadLine());
            
            double selectedPaintCost = 0;

            {
                numberGallonWalls = 0;
                numberGallonCeiling = 0;

                if (paintType == 1)
                {
                    numberGallonWalls = (int)Math.Ceiling(areaPaintWalls / 300);
                    numberGallonCeiling = (int)Math.Ceiling(areaCeiling / 200);
                    selectedPaintCost = costGallonBasic;
                }
                else if (paintType == 2)
                {
                    numberGallonWalls = (int)Math.Ceiling(areaPaintWalls / 400);
                    numberGallonCeiling = (int)Math.Ceiling(areaCeiling / 250);
                    selectedPaintCost = costGallonPremium;
                }
                else
                {
                    numberGallonWalls = (int)Math.Ceiling(areaPaintWalls / 500);
                    numberGallonCeiling = (int)Math.Ceiling(areaCeiling / 300);
                    selectedPaintCost = costGallonDelux;
                }

                if (numberGallonWalls >= numberGallonCeiling)
                    paintCost = selectedPaintCost * numberGallonWalls;
                else
                    paintCost = selectedPaintCost * numberGallonCeiling;

                Console.WriteLine($"Total cost of painting walls and ceiling is {paintCost:C2}");
            }

            Console.WriteLine($"\nSelect the type of flooring you want in your room" +
               $"Enter alphabet A or B or C, according to your preference:\n" +
               $"A. Carpet ($2.75 / square foot)\n" +
               $"B. Tile ($3.50 / square foot)\n" +
               $"C. Hardwood ($4.85 / square foot) \n");
            char floorType = Console.ReadKey().KeyChar;

            flooringCost = 0;
            switch (floorType)
            {
                case 'A':
                case 'a':

                    Console.WriteLine($"\nCost of flooring is {flooringCost = 2.75 * areaFloor:C2}");
                    break;

                case 'B':
                case 'b':

                    Console.WriteLine($"\nCost of flooring is {flooringCost = 3.50 * areaFloor:C2}");
                    break;

                case 'C':
                case 'c':

                    Console.WriteLine($"\nCost of flooring is {flooringCost = 4.85 * areaFloor:C2}");
                    break;
            }

            Console.WriteLine($"\nWhat is price of Baseboarding per linaer foot?");
            priceBaseboard = double.Parse(Console.ReadLine());
            Console.WriteLine($"Waste factor for baseboarding is {priceBaseboard * (baseboardingLength/10):C2}");

            Console.WriteLine($"Cost for baseboarding in the room is {(priceBaseboard * baseboardingLength) + (priceBaseboard * (baseboardingLength / 10)):C2} ");

            Console.WriteLine($"\nWhat is price of casing per linaer foot?");
            priceCasing = double.Parse(Console.ReadLine());
            Console.WriteLine($"Waste factor for casing is {priceCasing * (casingLength / 10):C2}");

            Console.WriteLine($"Cost for baseboarding in the room is {(priceCasing * casingLength) + (priceCasing * (casingLength / 10)):C2} ");

            netPrice = (priceBaseboard * baseboardingLength) + (priceCasing * casingLength) + paintCost + flooringCost + (priceCasing * (casingLength / 10)) + (priceBaseboard * (baseboardingLength / 10));
            totalPrice = (netPrice * 105) / 100;

            Console.WriteLine($"        Packing Slip\n" +
                $"*******************************************");
            
            Console.WriteLine($"\n{areaPaintWalls}^ft Wall Area\n" +
                $"{areaCeiling}^ft Ceiling Area\n\n" +
                $"{numberGallonWalls} gallons paint      @ {selectedPaintCost}= {paintCost,5:C2}\n" +
                $"{areaFloor}^ft    floorarea          = {flooringCost,5:C2}\n" +
                $"{casingLength}ft      casing     @ {priceCasing}    = {(priceCasing * casingLength) + (priceCasing * (casingLength / 10)),5:C2}\n" +
                $"{baseboardingLength}ft      baseboard  @ {priceBaseboard}    = {(priceBaseboard * baseboardingLength) + (priceBaseboard * (baseboardingLength / 10)),5:C2}\n" +
                $"                 =======================\n" +
                $"                  Net Total = {netPrice:C2}\n" +
                $"                  GST       = {TOTAL_GST:N}\n" +
                $"                  Total     = {totalPrice:C2}");
            

        }
    }
}
