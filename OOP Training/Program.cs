using System;
using System.Collections.Generic;
using System.Linq;
using TrainSystem;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


Engine engine = new Engine(3600, "SERIAL_NUMBER", "MODEL_NUMBER", 200);

Console.WriteLine(engine.ToString());

RailCar railCar = new RailCar("3", 100, 1000, 1000, RailCarType.COAL_CAR, true);

Console.WriteLine(railCar.ToString());

Train train = new Train(engine);





string pathname = FormCSVFile();




List<RailCar> Cars = new List<RailCar>();
List<Train> trains = new List<Train>();


List<RailCar> Carsrail = ReadCSVFile(pathname);





string FormCSVFile()
{
    string path = "../../../RailCar";

    List<RailCar> Cars = new List<RailCar>();

    Cars.Add(new RailCar("GYR55", 3000, 4500, 5000, RailCarType.BOX_CAR, true));
    Cars.Add(new RailCar("HYR55", 4000, 5500, 6000, RailCarType.COAL_CAR, true));
    Cars.Add(new RailCar("GYR45", 5000, 6500, 7000, RailCarType.BOX_CAR, false));
    Cars.Add(new RailCar("GKR55", 6000, 7500, 8000, RailCarType.COVERED_HOPPER, true));
    Cars.Add(new RailCar("GYS55", 7000, 8500, 9000, RailCarType.COAL_CAR, false));

    List<string> csvLines = new List<string>();

    foreach (var item in Cars)
    {
        csvLines.Add(item.ToString());
    }


    // Testing for bad data inputs

    csvLines.Add($"GYR55, 30, bad, 50, {RailCarType.BOX_CAR}, true");
    csvLines.Add($"GYR55, 30, 45, 60, {RailCarType.BOX_CAR}, false");
    csvLines.Add($"GYR55, 32, 55, 70, , true");
     
    File.WriteAllLines(path, csvLines);
    

    return Path.GetFullPath(path);

}





List<RailCar> ReadCSVFile(string path)
{
    List<RailCar> inputList = new List<RailCar>();
  
   
        string[] csvFileInput = File.ReadAllLines(path);

        RailCar Car = null;

        foreach (var text in csvFileInput)
        {            
                    inputList.Add(Car);   
        }
    
    return inputList;
}







RailCar Cara = Car();

RailCar Car()
{
    List<RailCar> Cars = new List<RailCar>();
    RailCar Car = null;

    Car = new RailCar("GYR55", 3000, 4500, 5000, RailCarType.BOX_CAR, true);

    return Car;
}

string pathName = "../../../RailCar.json";

SaveAsJson(Cara, pathName);
ReadAsJson(pathName);


void SaveAsJson(RailCar railcars, string pathName)
{
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true
    };
        string jsontext = JsonSerializer.Serialize<RailCar>(railcars, options);
  
        File.WriteAllText(pathName, jsontext);
  
}

RailCar ReadAsJson(string pathName)
{
    RailCar railcars = null;

        string jsontext = File.ReadAllText(pathName);

        railcars = JsonSerializer.Deserialize<RailCar>(jsontext);

    Console.WriteLine($"You can find your file saved at location: {Path.GetFullPath(pathName)}");

    return railcars;
}

