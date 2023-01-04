/*
Purpose: The program is designed for preparing a bill of a Cafe. The user
                should have the ability to perform various actions on the
                collection. Namely, add item, remove item, add tip, display
                bill, clear everything in bill. There is also the ability
                to save and read the data to or from a file respectively.

    Inputs:     Up to 5 items and their respective prices.
                Tip method and amount or percentage.
                File path
                

    Outputs:    Net amount
                Tip amount(if percentage method)
                Total GST
                Total amount
                
    Algorithm:  Prompt the user for item description and price
                Prompt the user for removing item
                Prompt the user for tip
                do
                    Collect and validate the user selection
                        Calculate net amount, tip amount, gst and total amount
                        Display bill
                        Save to file
                        Read from file
                        Quit program
                while the user selection is not 0

    Test Plan:
        Test Case       Test Data                Expected Results
        ---------       ------------------       ----------------
           1.           Description 1: Coke      Net Total = 70.09
                        Price: 12.89             Total GST = 3.95
                                                 Total Amount = 86.04
                        Description 2: Pop-Corn
                        Price: 7.18

                        Description 3: Pizza
                        Price: 34.12

                        Description 4: Coke
                        Price : 15.00

                        Description 5: Ice-Cream
                        Price: 9.90

                        Tip Amount = 3
                        

    Written By:     Gurkomal Singh

    Written For:    Cody Schellenberger

    Section Number: OA03

    Last Modified:  27 / 11 / 2021
*/
using System;
using System.Linq;
using System.IO;
namespace CPSC1012Assignment3GurkomalSingh 
{
    class Program
{
    static void Main()
    {
        // Declare necessary variables
        int actualSizeArray = 0;
        double tipAmount = 0;
        double netAmount = 0;
        double totalGst = 0;
        double totalAmount = 0;
        const double TOTAL_GST = 5.0;
        int userChoice;
        char exit;

        // set the physical array size and declare the parallel arrays
        const int ARRAY_SIZE = 5;
        string[] descriptionArray = new string[ARRAY_SIZE];
        double[] priceArray = new double[ARRAY_SIZE];


        // Getting actual size of array populated by user
        int count = 0;
        int logicalSize = count;

        do
        {
            Console.Clear();
            // Calling Display method
            Display();
            Console.Write("\nEnter your choice: ");
            // Calling method GetSafeInteger
            userChoice = GetSafeInteger();
            // Processing the options of user
            Console.Clear();
            switch (userChoice)
            {
                case 1: // Populating both arrays
                    {
                        try
                        {
                            Console.WriteLine($"New Item\n" +
                                $"--------------------------------------");
                            Console.Write("\nEnter description: ");

                            // Calling method GetSafeNonEmptystring for a valid non empty string
                            string description = GetSafeNonEmptystring();
                            descriptionArray[count] = description;

                            Console.Write("      Enter price: ");
                            // Calling method GetSafeDouble for a valid input
                            double price = GetSafeDouble();
                            priceArray[count] = price;
                            Console.WriteLine("Add item was successful.");
                            count++;
                        } // end of try
                        catch (Exception)
                        {
                            Console.WriteLine("Sorry! Only 5 items are allowed.");
                        } // end of catch
                        actualSizeArray = count;
                        Console.WriteLine("Press any key to continue...");
                        exit = Console.ReadKey().KeyChar;
                        break;
                    } // end of case 1
                case 2: // Removing an item
                    {
                        if (descriptionArray[0] == null && descriptionArray[1] == null && descriptionArray[2] == null && descriptionArray[3] == null && descriptionArray[4] == null)
                        {
                            Console.WriteLine("There are no items in the list to remove.");
                        } // end of if
                        else
                        {
                            // Calling method RemoveItem
                            RemoveItem(priceArray, descriptionArray, ref actualSizeArray);
                            // Calling method AddTip
                            tipAmount = AddTip(netAmount);
                        } // end of else
                        Console.WriteLine("Press any key to continue...");
                        exit = Console.ReadKey().KeyChar;
                        break;
                    } // end of case 2
                case 3: // Adding tip for the selected items total
                    {
                        if (descriptionArray[0] == null && descriptionArray[1] == null && descriptionArray[2] == null && descriptionArray[3] == null && descriptionArray[4] == null)
                        {
                            Console.WriteLine("There are no items in the bill to add tip for.");
                        } // end of if
                        else
                        {
                            // Calling method
                            netAmount = CalculateNetAmount(priceArray, actualSizeArray);
                            // Calling method
                            tipAmount = AddTip(netAmount);
                        } // end of else
                        Console.WriteLine("Press any key to continue...");
                        exit = Console.ReadKey().KeyChar;
                        break;
                    } // end of case 3
                case 4: // Displaying bill for selected items
                    {
                        if (descriptionArray[0] == null && descriptionArray[1] == null && descriptionArray[2] == null && descriptionArray[3] == null && descriptionArray[4] == null)
                        {

                            Console.WriteLine("There are no items in the bill to display.");
                        } // end of if 
                        else
                        {
                            // Calling method CalculateNetAmount
                            netAmount = CalculateNetAmount(priceArray, actualSizeArray);
                            // Calling method CalculateGST
                            totalGst = CalculateGST(netAmount, TOTAL_GST);
                            // Calling method CalculateTotalAmount
                            totalAmount = CalculateTotalAmount(netAmount, tipAmount, totalGst);
                            // Calling method DisplayBill
                            DisplayBill(priceArray, descriptionArray, netAmount, tipAmount, totalGst, totalAmount, actualSizeArray);
                        } // end of else
                        Console.WriteLine("Press any key to continue...");
                        exit = Console.ReadKey().KeyChar;
                        break;
                    } // end of case 4
                case 5: // Clearing everything in bill and array
                    {
                        descriptionArray = new string[ARRAY_SIZE];
                        priceArray = new double[ARRAY_SIZE];
                        tipAmount = 0;
                        totalGst = 0;
                        totalAmount = 0;
                        Console.Clear();
                        Console.WriteLine("All items have been cleared.");
                        Console.WriteLine("Press any key to continue...");
                        exit = Console.ReadKey().KeyChar;
                        break;
                    } // end of case 5
                case 6: // Saving data to files
                    {
                        // Calling method SaveToFiles
                        SaveToFiles(descriptionArray, priceArray, actualSizeArray);
                        Console.WriteLine("Press any key to continue...");
                        exit = Console.ReadKey().KeyChar;
                        break;
                    } // end of case 6
                case 7: // Loading data from files
                    {
                        // Calling method LoadFromFiles
                        LoadFromFiles(descriptionArray, priceArray, actualSizeArray);
                        Console.WriteLine("Press any key to continue...");
                        exit = Console.ReadKey().KeyChar;
                        break;
                    } // end of case 7
                default: // Ensuring the user input is in given options or not
                    {
                        if (userChoice != 0)
                        {
                            Console.WriteLine($"\nInvalid menu choice. Please try again.");
                            Console.WriteLine("Press any key to continue...");
                            exit = Console.ReadKey().KeyChar;
                        } // end of if
                        break;
                    } // end of default case
            } // end of switch
        } while (userChoice != 0);
        Console.WriteLine("Good-bye and thanks for using this program.");
    } // end of method

    static void Display()
    {
        Console.WriteLine(@"
     ____________________________
    |  ________________________  |
    | |                        | |
    | |      Monk's Cafe       | |
    | | ---------------------- | |
    | | 1. Add Item            | |
    | | 2. Remove Item         | |
    | | 3. Add Tip             | |
    | | 4. Display Bill        | |
    | | 5. Clear All           | |
    | | 6. Save to file        | |
    | | 7. Load from file      | |
    | | 0. Exit                | |
    | |________________________| |
    |____________________________|");
    } // end of method

    static bool RemoveItem(double[] priceArray, string[] descriptionArray, ref int arrayLength)
    {
        int count = 0;
        bool remove = false;
        Console.WriteLine("{0}    {1}                   {2}", "ItemNo", "Description", "Price");
        Console.WriteLine($"------    -----------                   -----");

        while (count < arrayLength)
        {
            Console.WriteLine("{0,6}    {1,-16} {2,18:C}", count + 1, descriptionArray[count], priceArray[count]);
            count++;
        } // end of while

        Console.Write("Enter item number which you want to remove or 0 to cancel: ");
        int removeMarkIndex = PromptForDoublePositiveOrZero(0, arrayLength, "items");
        if (removeMarkIndex == 0)
        {
            Console.WriteLine("No mark has been removed.\n");
        } // end of if
        else
        {
            removeMarkIndex -= 1;
            for (int index = removeMarkIndex; index < arrayLength - 1; index++)
            {
                descriptionArray[index] = descriptionArray[index + 1];
                priceArray[index] = priceArray[index + 1];
            } // end of for
            priceArray[arrayLength - 1] = 0;
            descriptionArray[arrayLength - 1] = null;
            remove = true;
            arrayLength -= 1;
            Console.WriteLine("Remove item was successful.\n");
        } // end of else
        return remove;
    } // end of method

    static double CalculateNetAmount(double[] sumOfPrice, int length)
    {
        int count = 0;
        double sumOfPrices = 0;

        while (count < length)
        {
            sumOfPrices += sumOfPrice[count];
            count++;
        } // end of while
        return sumOfPrices;
    } // end of method

    static double AddTip(double netAmount)
    {
        double tipAmount = 0;
        Console.WriteLine($"Net Total = {netAmount}");
        Console.Write($"Please select from 1, 2 or 3 regarding tip:\n" +
            $"1 - Tip Percentage\n" +
            $"2 - Tip Amount\n" +
            $"3 - No Tip     : ");
        int userSelection = PromptForDoublePositiveOrZero(1, 3, "options");

        if (userSelection == 1)
        {
            Console.Write("Enter tip percentage: ");
            double tipPercentage = double.Parse(Console.ReadLine());

            tipAmount = (tipPercentage / 100) * netAmount;
        } // end of if
        else if (userSelection == 2)
        {
            Console.Write("Enter tip amount: ");
            tipAmount = double.Parse(Console.ReadLine());
        } // end of else if
        else if (userSelection == 3)
        {
            tipAmount = 0;
            Console.WriteLine("It is totally fine if you don't want to add tip.");
        } // end of else if
        else
        {
            Console.WriteLine("This is an invalid choice.");
        } // end of else
        return tipAmount;
    } // end of method

    static double CalculateGST(double netAmount, double gstTotal)
    {
        double totalGst;
        return totalGst = (gstTotal / 100) * netAmount;
    } // end of method

    static double CalculateTotalAmount(double netAmount, double tipAmount, double totalGst)
    {
        double totalAmount;
        return totalAmount = netAmount + tipAmount + totalGst;
    } // end of method

    static void SaveToFiles(string[] descriptionArray, double[] priceArray, int length)
    {
        int count;
        const char delimiter = ':';
        Console.Write("Enter the file path to save items to: ");
        // Calling method GetSafeNonEmptystring
        string path = GetSafeNonEmptystring();

        try
        {
            using (StreamWriter writer = new(path))
            {
                for (count = 0; count < length; count++)
                {
                    writer.WriteLine($"{descriptionArray[count]}{delimiter}{priceArray[count]}");
                } // end of for
                Console.WriteLine($"Write to file {path} was successful.");
            }
        } // end of try
        catch (Exception ex)
        {
            Console.WriteLine($"Error: message = {ex.Message}");
        } // end of catch
    } // end of method

    static void LoadFromFiles(string[] descriptionArray, double[] priceArray, int length)
    {
        int count;
        string line;
        const char delimiter = ':';
        Console.Write("Enter the file path to load items from: ");
        // Calling method GetSafeNonEmptystring
        string path = GetSafeNonEmptystring();
        StreamReader reader = null;

        try
        {
            using (reader = new(path))
            {
                for (count = 0; !reader.EndOfStream && count < length; count++)
                {

                    line = reader.ReadLine();
                    string[] lineArray = line.Split(delimiter);
                    descriptionArray[count] = lineArray[0];
                    priceArray[count] = int.Parse(lineArray[1]);
                } // end of for
                Console.WriteLine($"Read from file {path} was successful.");
            }
        } // end of try
        catch (Exception ex)
        {
            Console.WriteLine($"Error: message = {ex.Message}");
        } // end of catch
    } // end of method

    static void DisplayBill(double[] priceArray, string[] descriptionArray, double netAmount, double tipAmount, double totalGst, double totalAmount, int length)
    {
        int count = 0;
        Console.WriteLine("\n{0}           {1}", "Description", "Price");
        Console.WriteLine($"----------------    -------");

        while (count < length)
        {
            Console.WriteLine("{0,-20} {1,6:C}", descriptionArray[count], priceArray[count]);
            count++;
        } // end of while

        Console.WriteLine($"----------------    -------");
        Console.WriteLine("{0,16}{1,11:C}", "Net Total", netAmount);
        Console.WriteLine("{0,16}{1,11:C}", "Tip Amount", tipAmount);
        Console.WriteLine("{0,16}{1,11:C}", "GST Amount", totalGst);
        Console.WriteLine("{0,16}{1,11:C}", "Total Amount", totalAmount);
    } // end of method

    static int GetSafeInteger()
    {
        int userInput;
        while (!int.TryParse(Console.ReadLine(), out userInput))
        {
            Console.Write($"\nInvalid input value. Please enter an integer value: ");
        } // end of while
        return userInput;
    } // end of method

    static string GetSafeNonEmptystring()
    {
        string userString;
        userString = Console.ReadLine();

        while (userString == null)
        {
            Console.Write("Invalid input value. Please enter a non-empty string: ");
            userString = Console.ReadLine();
        } // end of while
        return userString;
    } // end of method

    static double GetSafeDouble()
    {
        double userInput;
        while (!double.TryParse(Console.ReadLine(), out userInput) || userInput < 0)
        {
            Console.Write($"\nInvalid input value. Please enter a positive value: ");
        } // end of while
        return userInput;
    } // end of method

    static int PromptForDoublePositiveOrZero(int lowestNumber, int highestNumber, string prompt)
    {
        int userInput;
        while (!int.TryParse(Console.ReadLine(), out userInput) || lowestNumber > userInput || userInput > highestNumber)
        {
            if (userInput > highestNumber || lowestNumber > userInput)
            {
                Console.Write($"Invalid input value. Please enter an integer value between 1 and {highestNumber}: ");

            } // end of if
            else
            {
                Console.Write($"\nInvalid input value. Please enter a numeric value: ");
            } // end of else
        }// end of while
        return userInput;
    } // end of method
} // end of class
} // end of namespace
