using System;

namespace assignment2
{
    class Program
    {
        static void Main()
        {
            /*
            Purpose:        Generate a program that will take dimensions of a playground,
                            gate, distance between posts, type of fence and tyoe of paint.
                            Then it will calculate and print a costed Packing Slip reflecting
                            the materials needed to build a playground fence as shown below.

                Inputs:     playgroundLength
                            playgroundWidth
                            fenceHeight
                            gateWidth 
                            gateHeight
                            distanceInPost
                            fenceSelected
                            paintSelected

            Outputs:    	gateArea
                            gateCost
                            numberOfQuarters
                            paintCost
                            fenceCost
                            fenceArea
                            railingCost
                            postCost
                            numberOfPosts
                            netPrice
                            TOTAL_GST
                            totalPrice
                            

            Algorithm:   	Declare necessary variables
                            do
                                Display complete information options  
                                Prompt the user and read users choice
                                    (1) Error for invalid input and ask to try again
                                        Update playground dimensions and calculate area of fence   
                                    (2) Error for invalid input and ask to try again
                                        Update gate dimensions and calculate artea of gate
                                    (3) Error for invalid input and ask to try again
                                        Update distance between two posts and calculate:
                                            (a) total fence length
                                            (b) number of posts needed
                                    (4) Error for invalid input and ask to try again
                                        Update the type of fence user wants and calculate:
                                            (a) railing cost
                                            (b) fence cost
                                            (c) posts cost
                                    (5) Error for invalid input and ask to try again
                                        Update the type of paint user wants and calculate: 
                                            (a) number of quarts required of paint
                                            (b) paint cost
                                    (6) Display the packing slip containg:
                                            (a) Fence area, fence selected, fence cost per foot and total fence cost
                                            (b) Gate area, total gate cost
                                            (c) Number of quarts of paint, selected paint,paint cost per foot and total paint cost
                                            (d) Railing length, railing cost per foot and total railing cost
                                            (e) Number of posts needed, cost per post and total posts cost
                                            (f) Sub total
                                            (g) Total GST
                                            (h) Total cost
                                    (0) Quit program
                                        Error for invalid input
                                        while option selected is not 0
                                        Exit message

            Test Plan:
                            Test Case	  Test Data	                    Expected Results

                              1.          Length of Playground = 20 ft   Paint area   = 432
                                          Width of Playground  = 10 ft   Gate area    = 24 ^ft
                                          Height of playground = 8 ft    Posts needed = 10
                                          Distance in posts    = 7 ft    Paint qts.   = 9
                                          Width of Gate        = 6 ft    Paint cost   = 143.91
                                          Height of Gate       = 4 ft    Fence cost   = 6415.20
                                          Type of fence        = chain   Gate cost    = 498
                                          Type of paint        = premium Railing cost = 295.81
                                                                         Sub total    = 7860.82
                                                                         Total gst    = 393.04
                                                                         Total price  = 8253.56
                                          

            Written by:     Gurkomal Singh

            Written for:	Cody Schellenberger

            Section No:		OA03

            Last modified:  2021.11.07
            */

            // Declare all necessary varibles
            int userInput;
            double playgroundLength = 0;
            double playgroundWidth = 0;
            double fenceHeight = 0;
            double gateWidth = 0;
            double gateHeight = 0;
            double gateArea = 0;
            double gateCost = 0;
            double distanceInPost = 0;
            string fenceSelected = "######";
            string paintSelected = "###### ";
            double paintCost = 0;
            double paintPerFoot = 0;
            double fenceCost = 0;
            double fencePerFoot = 0;
            double fenceArea = 0;
            double railingCost = 0;
            double railingPerFoot = 0;
            double postCost = 0;
            double costPerPost = 0;
            double totalFenceLength = 0;
            double numberOfPosts = 0;
            double netPrice = 0;
            const double TOTAL_GST = 5.0 / 100;
            double totalPrice = 0;
            double numberOfQuarters = 0;
            // given waste factor 
            double WASTE_FACTOR = 1.1;

            // Display welcome message
            Console.WriteLine($"Welcome to the Platground Calculator.");

            // Do the following
            do
            { // Display options to the user
                Console.WriteLine($"\nPlease complete the following information.");
                Console.WriteLine($"1. Playground Dimensions");
                Console.WriteLine($"2. Gate Dimensions");
                Console.WriteLine($"3. Distance Between Posts");
                Console.WriteLine($"4. Fence Type");
                Console.WriteLine($"5. Paint Type");
                Console.WriteLine($"6. Create Packing Slip.");
                Console.WriteLine($"0. Exit\n");

                Console.Write($"Make a selection >>> ");

                // Read the option selected
                bool success = int.TryParse(Console.ReadLine(), out userInput);
                // while loop for getting positive valid input
                while (!success)
                {
                    Console.WriteLine($"Sorry, it is invalid input\n" +
                        $"Please enter again an integer from above list\n");

                    Console.Write($"Make a selection >>> ");
                    success = int.TryParse(Console.ReadLine(), out userInput);
                } // end of while
                // process the selected choice
                switch (userInput)
                {
                    case 1: // Playground Dimensions
                        {
                            // Display heading 
                            Console.Write($"\n*** Dimensions of the playground(in feet) ***");
                            Console.WriteLine();

                                Console.Write("Length: ");
                                // Prompting user for  using while loop for positive and valid length
                                while (!double.TryParse(Console.ReadLine(), out playgroundLength) || (playgroundLength! < 0))
                                {
                                    Console.WriteLine($"\nSorry, it is invalid input\n" +
                                        $"Enter a positive number\n");
                                    Console.Write("Length: ");
                                } // end of while

                                Console.Write($"Width: ");
                                // Prompting user for  using while loop for positive and valid width
                                while (!double.TryParse(Console.ReadLine(), out playgroundWidth) || (playgroundWidth! < 0))
                                {
                                    Console.WriteLine($"\nSorry, it is invalid input\n" +
                                        $"Enter a positive number\n");
                                    Console.Write("Width: ");
                                } // end of while

                                Console.Write($"Height(Fence): ");
                                // Prompting user for  using while loop for positive and valid height
                                while (!double.TryParse(Console.ReadLine(), out fenceHeight) || (fenceHeight! < 0))
                                {
                                    Console.WriteLine($"\nSorry, it is invalid input\n" +
                                        $"Enter a positive number\n");
                                    Console.Write("Height(Fence): ");
                                } // end of while

                                // calculating total fence length and area
                                totalFenceLength = ((2 * playgroundLength) + (2 * playgroundWidth) - gateWidth);
                                fenceArea = totalFenceLength * fenceHeight;
                                break;
                            
                        } // end of case 1
                    case 2: // Gate dimensions
                        {
                            // Display welcome message 
                            Console.Write($"*** Dimensions of the gate(in feet) ***\n");
                            Console.WriteLine();

                                // Prompting user for  using while loop for positive and valid width
                                Console.Write($"Width: ");
                                while (!double.TryParse(Console.ReadLine(), out gateWidth) || (gateWidth! < 0))
                                {
                                    Console.WriteLine($"\nSorry, it is invalid input\n" +
                                        $"Enter a positive number\n");
                                    Console.Write("Width: ");
                                } // end of while

                                Console.Write($"Height: ");
                                // Prompting user for  using while loop for positive and valid height
                                while (!double.TryParse(Console.ReadLine(), out gateHeight) || (gateHeight! < 0))
                                {
                                    Console.WriteLine($"\nSorry, it is invalid input\n" +
                                        $"Enter a positive number\n");
                                    Console.Write("Height: ");
                                } // end of while

                                // calculate gate area and cost
                                gateArea = gateHeight * gateWidth;
                                gateCost = 120.00 + (15.75 * gateArea);
                                break;

                            
                        } // end of case 2
                    case 3: // Distance between posts
                        {
                            Console.Write($"\nDistance between two adjacent posts(6-8 feet): ");
                            // Prompting user for  using while loop for positive and valid distace between posts
                            while (!double.TryParse(Console.ReadLine(), out distanceInPost) || (distanceInPost! < 0))
                            {
                                Console.WriteLine($"\nSorry, it is invalid input\n" +
                                    $"Enter a positive number\n");
                                Console.Write($"Distance between two adjacent posts(6-8 feet): ");
                            } // end of while

                            // calculating fence length and number of posts needed
                            totalFenceLength = ((2 * playgroundLength) + (2 * playgroundWidth) - gateWidth);
                            numberOfPosts = Math.Ceiling(((totalFenceLength + gateWidth) / distanceInPost) + 1);
                            break;

                        } // end of case 3
                    case 4: // Fence Type
                        { // Displaying options for fence
                            Console.WriteLine($"Enter a, b or c according to the fence you want around playground:\n" +
                                $"a - Pressure treated spruce ($4.50 / sq. foot + $17.20 per post + $0.49 / linear foot of railing)\n" +
                                $"b - Cedar ($7.25 / sq. foot + $23.99 per post + $0.69 / linear foot of railing)\n" +
                                $"c - Chain link ($13.50 / sq. foot + $50.79 per post + $2.49 / linear foot of railing)");
                            // prompting user for selecting fence 
                            fenceSelected = Console.ReadLine();
                            // converting input character to lower case
                            fenceSelected.ToLower();

                            // calculating fence length, number of posts needed and fence area
                            totalFenceLength = ((2 * playgroundLength) + (2 * playgroundWidth) - gateWidth);
                            numberOfPosts = Math.Ceiling(((totalFenceLength + gateWidth) / distanceInPost) + 1);
                            fenceArea = totalFenceLength * fenceHeight;

                            {
                                // if user selects a
                                if (fenceSelected == "a")
                                {
                                    fencePerFoot = 04.50;
                                    fenceCost = fenceArea * fencePerFoot * WASTE_FACTOR;
                                    railingPerFoot = 00.49;
                                    railingCost = 2 * railingPerFoot * totalFenceLength * WASTE_FACTOR;
                                    costPerPost = 17.20;
                                    postCost = costPerPost * numberOfPosts;
                                    fenceSelected = "Spruce";
                                } // end of if
                                  // if user selects b
                                else if (fenceSelected == "b")
                                {
                                    fencePerFoot = 07.25;
                                    fenceCost = fenceArea * fencePerFoot * WASTE_FACTOR;
                                    railingPerFoot = 00.69;
                                    railingCost = 2 * railingPerFoot * totalFenceLength * WASTE_FACTOR;
                                    costPerPost = 23.99;
                                    postCost = costPerPost * numberOfPosts;
                                    fenceSelected = "Cedar.";
                                } // end of else if
                                  // if user selects a
                                else if (fenceSelected == "c")
                                {
                                    fencePerFoot = 13.50;
                                    fenceCost = fenceArea * fencePerFoot * WASTE_FACTOR;
                                    railingPerFoot = 02.49;
                                    railingCost = 2 * railingPerFoot * totalFenceLength * WASTE_FACTOR;
                                    costPerPost = 50.79;
                                    postCost = costPerPost * numberOfPosts;
                                    fenceSelected = "Chain ";
                                } // end of else if
                                  // if user selects any other character other than a,b or c
                                else
                                {
                                    Console.WriteLine("Invalid character typed.\n" +
                                        "Please go through this section again.\n");
                                } // end of else
                            } // end of if-else
                            break;

                        } // end of case 4
                    case 5: // Paint type
                        {
                            // Displaying options for fence
                            Console.WriteLine($"Enter A, B, or C accrding to the paint you want on fence:\n" +
                                $"A - Basic ($11.99 / quart)\n" +
                                $"B - Premium ($15.99 / quart)\n" +
                                $"C - Deluxe ($19.99 / quart)");
                            // Prompting user to select type of paint
                            paintSelected = Console.ReadLine();
                            {
                                // if user selects A
                                if (paintSelected == "A" || paintSelected == "a")
                                {
                                    numberOfQuarters = Math.Ceiling((fenceArea * 2 / 300) * 4);
                                    paintPerFoot = 11.99;
                                    paintCost = numberOfQuarters * paintPerFoot;
                                    paintSelected = "Basic  ";
                                } // end of if
                                // if user selects B
                                else if (paintSelected == "B" || paintSelected == "b")
                                {
                                    numberOfQuarters = Math.Ceiling((fenceArea * 2 / 400) * 4);
                                    paintPerFoot = 15.99;
                                    paintCost = numberOfQuarters * paintPerFoot;
                                    paintSelected = "Premium";
                                } // end of else if
                                // if user selects C
                                else if (paintSelected == "C" || paintSelected == "c")
                                {
                                    numberOfQuarters = Math.Ceiling((fenceArea * 2 / 500) * 4);
                                    paintPerFoot = 19.99;
                                    paintCost = numberOfQuarters * paintPerFoot;
                                    paintSelected = "Deluxe ";
                                } // end of else if
                                // if user selects character other than A, B or C
                                else
                                {
                                    Console.WriteLine("Invalid character typed.\n" +
                                       "Please go through this section again.\n");
                                } // end of else
                            } // end of if-else
                            break;

                        } // end of case 5
                    case 6: // Packing slip
                        { 
                            // calculating net price, gst and total cost
                            netPrice = fenceCost + gateCost + paintCost + postCost + railingCost;
                            totalPrice = (netPrice * 105) / 100;
                            // Display heading for slip
                            Console.WriteLine($"\n        Invoice and Packing Slip\n" +
                                $"*******************************************\n");
                            // Display cost of each area including waste factor
                            Console.WriteLine($"{fenceArea,5:0.0}^ft.  {fenceSelected}   @   {fencePerFoot,6:0.00}  ={fenceCost,13:C2}");
                            Console.WriteLine($"{numberOfPosts,5:0.0}      Posts    @   {costPerPost,6:0.00}  ={postCost,13:C2}");
                            Console.WriteLine($"{2 * totalFenceLength,5:0.0} ft.  Railing  @   {railingPerFoot,6:0.00}  ={railingCost,13:C2}");
                            Console.WriteLine($"{gateArea,5:0.0}^ft.  Gate                 ={gateCost,13:C2}");
                            Console.WriteLine($"{numberOfQuarters,5:0.0} qts. {paintSelected}  @   {paintPerFoot,6:0.00}  ={paintCost,13:C2}\n");
                            Console.WriteLine($"                      Net Price =  {netPrice,11:C2}");
                            Console.WriteLine($"                      GST       =  {TOTAL_GST * netPrice,11:C2}");
                            Console.WriteLine($"                      Total     =  {totalPrice,11:C2}");
                            break;
                        } // end of case 6
                     default: // if user inputs any ungiven option
                        {
                            Console.WriteLine($"It is not an option\n" +
                                $"Try selecting again please\n");
                            break;
                        } // end of default case
                } // end of switch
            }while (userInput != 0);
            Console.WriteLine($"\nPlease visit again.\n" +
                $"Thank you for your valuable time.");
        } // end of method
    } // end of class
} // end of namespace
