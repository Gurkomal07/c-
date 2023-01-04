using System;
using System.Collections.Generic;

namespace Assignment_4
{
    class Program
    {
        static void Main(string[] args)
        {
            char userChoice = 'y';
            char rightInformation = 'y';
            int index = 0;

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
                string type = Console.ReadLine();
                pet.Type = type;

                petList.Add(new Pet(name, age, weight, type));


                Console.WriteLine();



                DisplayPet(petList);
                Console.WriteLine();
                string message = "Is the information above your pet, correct? Enter y or n: ";
                rightInformation = PromptForCharNotEmpty(message);


                Console.WriteLine();


                if (rightInformation == 'y')
                {
                    index++;
                    Console.Write($"Service Options:\n" +
                        $"1.Pain Killer\n" +
                        $"2.Sedative\n" +
                        $"3.Both Pain Killer and Sedative\n" +
                        $"Enter the service(1 - 3) required for your pet: ");

                    int service = GetSafeInteger();

                    double dosageCarprofen = 0;
                    double dosageAcepromazine = 0;
                    if (service == 1)
                    {
                        dosageCarprofen = pet.Carprofen(weight, type);
                        Console.WriteLine($"\nYour pet requires {dosageCarprofen}mL of carprofen.");
                    }
                    else if (service == 2)
                    {
                        dosageAcepromazine = pet.Acepromazine(weight, type);
                        Console.WriteLine($"\nYour pet requires {dosageAcepromazine}mL of carprofen.");
                    }
                    else if (service == 3)
                    {
                        dosageCarprofen = pet.Carprofen(weight, type);
                        dosageAcepromazine = pet.Acepromazine(weight, type);

                        Console.WriteLine($"\nYour pet requires {dosageCarprofen}mL of carprofen.");
                        Console.WriteLine($"Your pet requires {dosageAcepromazine}mL of carprofen.\n");

                    }
                   

                    Console.WriteLine();
                    message = "Do you have another pet that requires service? Enter y or n: ";
                    userChoice = PromptForCharNotEmpty(message);
                    Console.WriteLine();

                }
                else if (rightInformation == 'n')
                {
                    petList.RemoveAt(index);
                    Console.WriteLine($"Please enter the correct details again");
                }

            } while (userChoice != 'n');

            Console.WriteLine();
            Console.WriteLine($"Good-bye and thanks for coming to the Pet Clinic.");
        }

        static void DisplayPet(List<Pet> pets)
        {
            foreach (Pet pet in pets)
            {
                Console.WriteLine($"Name: {pet.Name}, Age: {pet.Age} years, Weight: {pet.Weight} lb, Type: {pet.Type}");
            }

        }



        static double GetSafeWeight()
        {
            bool validInput = double.TryParse(Console.ReadLine(), out double userInput);
            while (!validInput || userInput < 5)
            {
                if (userInput < 0)
                {
                    Console.Write("Invalid input value. Weight must be a positive value: ");
                    Console.Write($"Enter the weight in pounds of your pet: ");
                    validInput = double.TryParse(Console.ReadLine(), out userInput);
                }
                else if (userInput < 5)
                {
                    Console.Write("Invalid input value. Weight must be at least 5 pounds: ");
                    Console.Write($"Enter the weight in pounds of your pet: ");
                    validInput = double.TryParse(Console.ReadLine(), out userInput);
                }
                else
                    Console.Write("Invalid input value. Weight must be a postive double: ");
                Console.Write($"Enter the weight in pounds of your pet: ");
                validInput = double.TryParse(Console.ReadLine(), out userInput);

            } // end of while

            return userInput;
        }


        static int GetSafeAge()
        {
            bool validInput = int.TryParse(Console.ReadLine(), out int userInput);
            while (!validInput || userInput < 1)
            {
                if (userInput < 0)
                {
                    Console.Write("Invalid input value. Age must be a positive value: ");
                    Console.Write($"Enter the age in years of your pet: ");
                    validInput = int.TryParse(Console.ReadLine(), out userInput);
                }
                else if (userInput < 5)
                {
                    Console.Write("Invalid input value. Age must be at least 1 year: ");
                    Console.Write($"Enter the age in years of your pet: ");
                    validInput = int.TryParse(Console.ReadLine(), out userInput);
                }
                else
                    Console.Write("Invalid input value. Age must be a postive double: ");
                Console.Write($"Enter the age in years of your pet: ");
                validInput = int.TryParse(Console.ReadLine(), out userInput);

            } // end of while

            Console.WriteLine();

            return userInput;
        }




        static string PromptForNameNotEmpty()
        {
            string stringValue;
            bool validInput = false;

            do
            {
                stringValue = Console.ReadLine();
                if (!string.IsNullOrEmpty(stringValue))
                {
                    validInput = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. A pet name is required and must contain at least one character.");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write($"Enter the name of your pet: ");
                }
            } while (!validInput);

            return stringValue;
        }






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
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Pet type must be D or C.");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write($"Enter D for Dog, C for Cat: ");
                }
            } while (!validInput);

            return stringValue;
        }


        static int GetSafeInteger()
        {
            bool validInput = int.TryParse(Console.ReadLine(), out int userInput);
            while (!validInput || userInput < 1)
            {
                if (userInput < 0)
                {
                    Console.Write("Invalid input value. Option selected must be a postive integer(1, 2 or 3).");
                    Console.Write($"Enter the service(1 - 3) required for your pet: ");
                    validInput = int.TryParse(Console.ReadLine(), out userInput);
                }
                else if (userInput > 3)
                {
                    Console.Write("Invalid input value. Select among 1, 2 and 3.");
                    Console.Write($"Enter the service(1 - 3) required for your pet: ");
                    validInput = int.TryParse(Console.ReadLine(), out userInput);
                }
                else
                    Console.Write("Invalid input value. Option selected must be a postive integer(1, 2 or 3).");
                Console.Write($"Enter the service(1 - 3) required for your pet: ");
                validInput = int.TryParse(Console.ReadLine(), out userInput);

            } // end of while

            Console.WriteLine();

            return userInput;
        }

        static char PromptForCharNotEmpty(string message)
        {
            char charValue;
            bool validInput = false;

            do
            {
                charValue = char.ToLower(Console.ReadKey().KeyChar);
                if (charValue.ToString().Trim().Length == 0 && (charValue == 'y' || charValue == 'n'))
                {
                    validInput = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input value. Input must be y or n.");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write(message);
                }
            } while (!validInput);

            return charValue;
        }
    }
}
