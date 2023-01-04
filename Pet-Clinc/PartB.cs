/*
Purpose:    Track the administration of these two drugs - Acepromazine and Carprofen. 
  
Inputs:     Name, age, weight and type of pet. 
  
Outputs:    Amount of drugs needed for pet.

Algorithm:  1)  prompt for name, age, weight and type of pet
            2)  Calculate amount of drug
            3)  Ask to add, remove, read and write to file.
           
        5)  Do the following:
Do the following:
                a.Prompt and read name, age, weight and type of pet
                b.While not validInput do the following:
                        a.Display an error message
                             End While
                c.Increment attempts
                d.If userAnswer = correctAnswer do the following:
                e. Ask user for adding, removing pet.
                f. Ask user for reading and writing into file.
            6) Good bye message
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment_4
{
    class Program
    {
        static void Main(string[] args)
        {
            char userChoice = 'y';
            char rightInformation;
            int index = 0;
            int FurtherChoice;

            List<Pet> petList = new();
            Pet pet = new();

            do
            {

                Console.WriteLine($"\n|---------------------|");
                Console.WriteLine($"| CPSC1012 Pet Clinic |");
                Console.WriteLine($"|---------------------|");

                Console.Write($"Enter the name of your pet: ");
                string name = PromptForNameNotEmpty();
                pet.Name = name;

                Console.Write($"Enter the age in years of your pet: ");
                int age = GetSafeAge();
                pet.Age = age;

                Console.Write($"Enter the weight in pounds of your pet: ");
                double weight = GetSafeWeight();
                pet.Weight = weight;

                Console.Write($"Enter D for Dog, C for Cat: ");
                string type = PromptForTypeNotEmpty();
                pet.Type = type;

                petList.Add(new Pet(name, age, weight, type));
                Console.WriteLine();

                DisplayPet(petList, index);
                Console.WriteLine();
                string message = "Is the information above your pet, correct? Enter y or n: ";
                rightInformation = PromptForCharNotEmpty(message);

                Console.WriteLine();
                Console.WriteLine();

                if (rightInformation == 'y')
                {
                    index++;
                    Console.Write($"Service Options:\n" +
                        $"1. Pain Killer\n" +
                        $"2. Sedative\n" +
                        $"3. Both Pain Killer and Sedative\n" +
                        $"Enter the service(1 - 3) required for your pet: ");

                    int service = GetSafeInteger();

                    double dosageCarprofen = 0;
                    double dosageAcepromazine = 0;
                    if (service == 1)
                    {
                        dosageCarprofen = pet.Carprofen(weight, type);
                        Console.WriteLine($"\nYour pet requires {dosageCarprofen:0.000}mL of carprofen.");
                    } // end of if
                    else if (service == 2)
                    {
                        dosageAcepromazine = pet.Acepromazine(weight, type);
                        Console.WriteLine($"\nYour pet requires {dosageAcepromazine:0.000}mL of carprofen.");
                    } // end of else if
                    else if (service == 3)
                    {
                        dosageCarprofen = pet.Carprofen(weight, type);
                        dosageAcepromazine = pet.Acepromazine(weight, type);

                        Console.WriteLine($"\nYour pet requires {dosageCarprofen:0.000}mL of carprofen.");
                        Console.WriteLine($"Your pet requires {dosageAcepromazine:0.000}mL of Acepromazine.\n");
                    } // end of else if

                    Console.WriteLine();
                    //message = "Do you have another pet that requires service? Enter y or n: ";
                    //userChoice = PromptForCharNotEmpty(message);

                    do
                    {
                        Console.WriteLine($"\n|---------------------|");
                        Console.WriteLine($"|  1. Add pet         |");
                        Console.WriteLine($"|  2. Remove pet      |");
                        Console.WriteLine($"|  3. Write to files  |");
                        Console.WriteLine($"|  4. Load from files |");
                        Console.WriteLine($"|  5. Exit            |");
                        Console.WriteLine($"|---------------------|");

                        Console.Write($"Enter the option from above list: ");
                        FurtherChoice = GetSafeIntegerChoice();
                        Console.WriteLine();
                        switch (FurtherChoice)
                        {
                            case 1:
                                {
                                    FurtherChoice = 5;
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine();
                                    DisplayPetList(petList);
                                    message = $"Enter the pet number that you want to remove: ";
                                    Console.WriteLine();
                                    RemovePetAt(petList, message, petList.Count);
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine();
                                    WriteToFile(petList);
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine();
                                    ReadFromFile(petList);
                                    break;
                                }
                            case 5:
                                {
                                    userChoice = 'n';
                                    break;
                                }

                        }
                    } while (FurtherChoice != 5);
                    Console.WriteLine();

                } // end of if
                else if (rightInformation == 'n')
                {
                    petList.RemoveAt(index);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Please enter the correct details again");
                    Console.ForegroundColor = ConsoleColor.Black;
                } // end of else if

            } while (userChoice != 'n');  // end of do-while
            Console.WriteLine();
            Console.WriteLine($"Good-bye and thanks for coming to the Pet Clinic.");
        } // end of method

        static void DisplayPet(List<Pet> pets, int index)
        {
            Console.WriteLine($"Name: {pets[index].Name}, Age: {pets[index].Age} years, Weight: {pets[index].Weight} lb, Type: {pets[index].Type}");
        } // end of method

        static double GetSafeWeight()
        {
            bool validInput = double.TryParse(Console.ReadLine(), out double userInput);
            while (!validInput || userInput < 5)
            {
                if (userInput < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Weight must be a positive value: ");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"Enter the weight in pounds of your pet: ");
                    validInput = double.TryParse(Console.ReadLine(), out userInput);
                } // end of if
                else if (userInput < 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Weight must be at least 5 pounds: ");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"Enter the weight in pounds of your pet: ");
                    validInput = double.TryParse(Console.ReadLine(), out userInput);
                } // end of else if
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Weight must be a positive double greater than or equal to 5: ");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"Enter the weight in pounds of your pet: ");
                    validInput = double.TryParse(Console.ReadLine(), out userInput);
                } // end of else
            } // end of while

            return userInput;
        } // end of method

        static int GetSafeAge()
        {
            bool validInput = int.TryParse(Console.ReadLine(), out int userInput);
            while (!validInput || userInput < 1)
            {
                if (userInput < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Age must be a positive value: ");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"Enter the age in years of your pet: ");
                    validInput = int.TryParse(Console.ReadLine(), out userInput);
                } // end of if
                else if (userInput < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Age must be at least 1 year: ");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"Enter the age in years of your pet: ");
                    validInput = int.TryParse(Console.ReadLine(), out userInput);
                } // end of else if
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Age must be a positive integer greater than or equal to 1: ");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"Enter the age in years of your pet: ");
                    validInput = int.TryParse(Console.ReadLine(), out userInput);
                } // end of else
            } // end of while

            return userInput;
        } // end of method

        static string PromptForNameNotEmpty()
        {
            string stringValue;
            bool validInput = false;

            do
            {
                stringValue = Console.ReadLine();
                if (!string.IsNullOrEmpty(stringValue.Trim()))
                {
                    validInput = true;
                } // end of if
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. A pet name is required and must contain at least one character.");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"Enter the name of your pet: ");
                } // end of else
            } while (!validInput);

            return stringValue;
        } // end of method

        static string PromptForTypeNotEmpty()
        {
            string stringValue;
            bool validInput = false;

            do
            {
                stringValue = Console.ReadLine().ToUpper();
                if (!string.IsNullOrEmpty(stringValue) && (stringValue == "D" || stringValue == "C"))
                {
                    validInput = true;
                } // end of if
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Pet type must be D or C.");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"Enter D for Dog, C for Cat: ");
                } // end of else
            } while (!validInput);  // end of do-while

            return stringValue;
        } // end of method

        static int GetSafeInteger()
        {
            bool validInput = int.TryParse(Console.ReadLine(), out int userInput);
            while (!validInput || userInput < 1 || userInput > 3)
            {
                if (userInput < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Option selected must be a postive integer(1, 2 or 3).");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"Enter the service(1 - 3) required for your pet: ");
                    validInput = int.TryParse(Console.ReadLine(), out userInput);
                } // end of if
                else if (userInput > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Select among 1, 2 and 3.");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"Enter the service(1 - 3) required for your pet: ");
                    validInput = int.TryParse(Console.ReadLine(), out userInput);
                } // end of else if
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Option selected must be a postive integer(1, 2 or 3).");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"Enter the service(1 - 3) required for your pet: ");
                    validInput = int.TryParse(Console.ReadLine(), out userInput);
                } // end of else
            } // end of while
            Console.WriteLine();

            return userInput;
        } // end of method

        static char PromptForCharNotEmpty(string message)
        {
            char charValue;
            bool validInput = false;

            do
            {
                Console.Write(message);
                charValue = char.ToLower(Console.ReadKey().KeyChar);
                if (charValue.ToString().Trim().Length != 0 && (charValue == 'y' || charValue == 'n'))
                {
                    validInput = true;
                } // end of if
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input value. Input must be y or n.");
                    Console.ForegroundColor = ConsoleColor.Black;
                } // end of else
            } while (!validInput); // end of do-while loop

            return charValue;
        } // end of method

        static void DisplayPetList(List<Pet> pets)
        {
            Console.WriteLine();
            int count = 1;
            Console.WriteLine($"{"Serial No.",10}{"Name",10}   {"Age(years)",5}{"Weight(lb)",15}{"Type",10}");
            Console.WriteLine($"{"----------",10}{"----",10}   {"----------",5}{"----------",15}{"----",10}");
            foreach (Pet pet in pets)
            {
                Console.WriteLine($"{count,4}{pet.Name,16} {pet.Age,4} years {pet.Weight,8} lb {pet.Type,13}");
                count++;
            }
        } // end of method

        static bool RemovePetAt(List<Pet> pet, string message, int length)
        {
            Console.Write(message);
            int index = int.Parse(Console.ReadLine());
            if (index <= length && index > 0)
            {
                try
                {
                    pet.RemoveAt(index - 1);
                    Console.WriteLine("Pet removed successfully");
                    return true;
                } // end of try
                catch (Exception)
                {
                    return false;
                } // end of catch   
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You want to delete {index} number pet. There are only {length} pets.");
                Console.WriteLine("Unsuccessful to remove pet");
                Console.ForegroundColor = ConsoleColor.Black;
                return false;
            }
        } // end of method

        static void WriteToFile(List<Pet> pets)
        {
            string message = "Please provide a file path: ";
            string path = PromptForStringNotEmpty(message);
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(path);

                foreach (Pet pet1 in pets)
                {
                    writer.WriteLine($"{pet1.Name},{pet1.Age},{pet1.Weight},{pet1.Type}");
                }
                Console.WriteLine("The file was saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("The file was not successfully saved.");
            }
            finally
            {
                writer.Close();
            }
        }


        static void ReadFromFile(List<Pet> pets)
        {
            pets.Clear();
            string message = "Please provide a file path: ";
            string path = PromptForStringNotEmpty(message);
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(path);
                while (!reader.EndOfStream)
                {
                    try
                    {
                        Pet pet = new();
                        string line = reader.ReadLine();
                        string[] lines = line.Split(',');
                        pet.Name = lines[0];
                        pet.Age = int.Parse(lines[1]);
                        pet.Weight = double.Parse(lines[2]);
                        pet.Type = (lines[3]);
                        pets.Add(pet);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.WriteLine("The file was loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("The file was not successfully loaded.");
            }
            finally
            {
                reader.Close();
            }
        }

        static string PromptForStringNotEmpty(string message)
        {
            string stringValue;
            bool validInput = false;

            do
            {
                Console.Write(message);
                stringValue = Console.ReadLine();
                if (!string.IsNullOrEmpty(stringValue))
                {
                    validInput = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Please enter a non-empty string.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (!validInput);

            return stringValue;
        } // end of method

        static int GetSafeIntegerChoice()
        {
            bool validInput = int.TryParse(Console.ReadLine(), out int userInput);
            while (!validInput || userInput < 1 || userInput > 5)
            {
                if (userInput < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Option selected must be a postive integer(1 to 5).");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"Enter the option from above list: ");
                    validInput = int.TryParse(Console.ReadLine(), out userInput);
                } // end of if
                else if (userInput > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Select 1 to 5.");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"Enter the option from above list: ");
                    validInput = int.TryParse(Console.ReadLine(), out userInput);
                } // end of else if
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Option selected must be a postive integer(1 to 5).");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"Enter the option from above list: ");
                    validInput = int.TryParse(Console.ReadLine(), out userInput);
                } // end of else
            } // end of while
            Console.WriteLine();

            return userInput;
        } // end of method

    } // end of class
} // end of namespace
