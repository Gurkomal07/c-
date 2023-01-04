# OOP Training

> This is the second of a set of exercises that follow the evolution of a program to manage trains. This set is cumulative and will build upon previous exercises.

## Overview

Your task is to add functionality to the set of classes from the previous exercise for managing trains. You are expected to have completed and made corrections to your submission for the previous exercise.

### General Validation Rules

All validation is to be performed by throwing exceptions. Continue to use these general requirements where/when applicable.

- Exceptions must have meaningful error messages.
- Error messages must include details about the limits for acceptable values.
- Weights must always be positive and non-zero whole numbers. Weights are to be in 100 pound increments (all weights are in pounds *unless otherwise noted*).
- All string information must contain text. Null, empty, and plain white-space text is not allowed. Sanitize your strings by trimming the leading and trailing whitespace.

### The `RailCar`

Extend the `RailCar` class by adding the following methods.

- Add **`Parse`** and **`TryParse`** methods to instantiate a RailCar from a string. The string's format is expected to match the formatting of the `ToString()` method.
  - In the `Parse` method, throw a [`FormatException`](https://docs.microsoft.com/dotnet/api/system.formatexception?view=net-5.0) if the supplied string does not match the expected format.
  - In the `TryParse` method, explicitly return a `bool` indicating if the parsing was successful. The parameters for this method are to be a `string` and an `out` parameter for the `RailCar` type.

In addition, you need to modify the `RailCar` constructor to ensure that the supplied serial number does not contain any of the following characters: `,:;\/!?@#$%^&*~` and the backtick (`) character.

### The `Train`

Modify the `Add(RailCar car)` method to ensure the following:

- Ensure the supplied object is not `null`. If it is, throw an `ArgumentNullException` with proper values for the parameter name and the error message.
- Ensure there are no duplicate serial numbers in the train. If the supplied car's serial number already exists, throw an `ArgumentException` with a message of `"The railcar {car.SerialNumber} is already attached to the train"`.

  
### `Detaching` cars from the `Train`

Not only are trains created by adding railcars to the train, they are split apart by detaching cars. These routines are to add the detach capability to our train.

#### Deatch by `SerialNumber`

Add another method to the `Train` class to detach a series of cars from the train. The method signature to use is `List<RailCar> Detach(string atSerialNumber)`. The method must generate and return a new list of rail cars beginning with the one that matches the supplied serial number through to the end of the remaining cars in the train. Those rail cars must be removed from the list of rail cars in the train.

For example, assume the train's rail car serial numbers follow this order:

> "GATX 220455", "GATX 259314", "GATX 150687", "GATX 220587", "GATX 225963", "TILX 261848", "TILX 286721"

If the train is asked to detach at serial number "GATX 225963", then the returned list of cars would be the following, and they would be removed from the train:

> "GATX 225963", "TILX 261848", "TILX 286721"


#### Detach by car `postion`
Add an overloaded version of the previous `Detach()` method that removes based on numeric position for the train: `List<RailCar> Detach(int fromPosition)`.

For example, let's use the same set of rail cars from our initial train:

> "GATX 220455", "GATX 259314", "GATX 150687", "GATX 220587", "GATX 225963", "TILX 261848", "TILX 286721"

If the train is asked to detach from position 3 (includes the car in that postion), then the returned list of cars would be the following, and they would be removed from the train:

> "GATX 150687", "GATX 220587", "GATX 225963", "TILX 261848", "TILX 286721"

### A Console I/O Driver

### Const FileNames

Create 3 const strings at the being of your program. These strings will be assigned the filename for your good csv file, good json file and your bad csv file.
### Reading a csv routine

Create a text file holding the comma-separated values for five good rail cars, one rail car per line. 

Create a method which will receive a string represnting a filename and return an instance of `Train`. Read all the lines using the [`System.File`](https://docs.microsoft.com/dotnet/api/system.io.file?view=net-5.0) class. Parse the read lines into individual railcars using the `RailCar.TryParse` method. Process all read lines and output any/all parsed exceptions. Add the valid cars to a new train.

#### Exception testing

Once you have the good 5 record CSV working, copy the file and intermix 3 bad records. One record will have a missing value (only 5 values on record). One record will have a bad value for the csv value (example a string instead of a number). One record will have a duplicate serial number (to test AddRailCar duplicate serial number logic). Rerun your program.

### Writing a JSON file
Create a method which receives an instance of `Train` and a string representing the JSON filename.

 Save the train information [formatted as JSON](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializer?view=net-5.0) to a separate file. Display the full file path of the JSON file on the screen using the [`Path.GetFullPath(String)` method](https://docs.microsoft.com/dotnet/api/system.io.path.getfullpath?view=net-5.0#System_IO_Path_GetFullPath_System_String_).


### Reading a JSON file
Create a method which receives an instance of `Train` and a string representing the JSON filename.

 Read the train information [formatted as JSON](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializer?view=net-5.0) from the `JSON` file you wrote. Return the Train data from the method. Display the Train data after returning from the read method.
### Display Current Train

Create a routine to display the contents of a Train. Display the Engine data. Display all railcars' data or a "No cars on train" message.

----

## Evaluation

> ***NOTE:** Your code **must** compile. Solutions that do not compile will receive an automatic mark of zero (0).*
>
> If you are unable to get a portion of the assignment to compile, you should:
>
> - Comment out the non-compiling portion of code
> - Identify the non-compiling portion in the **Incomplete Requirements** heading, noting the item's
>   - File name (e.g.: "Account.cs")
>   - Line number(s)
>   - Compiler error number and general message

Your assignment will be marked based upon the following weights. See the [general rubric](../../ReadMe.md#generalized-marking-rubric) for details.

| Weight | Deliverable/Requirement |
| ---- | --------- |
| 3 | RailCar Modifications |
| 3 | Train Modifications |
| 3 | Driver and File I/O |
| 1 | CSV File of RailCars |
| ---- | --------- |
| **10** | **Total Weight** |
| ---- | --------- |


----

## Credits

- [AAR Car Type Codes Explained & Resources](https://www.railcartracking.com/aar-car-type-codes-explained-resources-2/)
