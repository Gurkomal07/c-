using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
    public class Train
    {
        public Engine Engine
        { get; private set; }

        public int GrossWeight
        {
            get
            { return Engine.Weight + CalculateGrossWeightCar(); }
        }

        public int MaxGrossWeight   
        { 
            get 
            {
                return Engine.HP * 2000;
            } 
        }

        public List<RailCar> RailCars { get; set; } = new();
        

        public int TotalCars
        {
            get
            {
               return RailCars.Count;
            }
        }

        private int CalculateGrossWeightCar()
        { 
            int totalCarsWeight = 0;
            foreach (RailCar car in RailCars)
            { 
                totalCarsWeight += car.GrossWeight;
            }
            return totalCarsWeight;
        }


        public void AddRailCar(RailCar car)
        {
            if (GrossWeight + car.GrossWeight > MaxGrossWeight)
            {
                throw new Exception("Gross Weight exceeded Maximum allowed weight, cannot add more rail cars");
            }

            // newly added
            if (car == null)
            {
                throw new ArgumentNullException($"Car object cannot be a null field.");
            }

            // newly added
            if (car.SerialNumber == Engine.SerialNumber)
            {
                throw new ArgumentException($"The railcar {car.SerialNumber} is already attached to the train.");
            }
            
            RailCars.Add(car);
        }

        public Train(Engine givenEngine)
        {
            Engine = givenEngine;
        }

        private Engine GetEngine()
        {
            return Engine;
        }

        // newly added
        List<RailCar> Detach(string atSerialNumber, RailCar RailCara) 
        {

            List<RailCar> Detach = new List<RailCar>();
            if (RailCara.SerialNumber == atSerialNumber)
            {
                int indexValue = RailCars.IndexOf(RailCara);
                while (indexValue < RailCars.Count)
                {
                    RailCars.RemoveAt(indexValue);
                    Detach.Add(RailCara);
                    indexValue++;
                }
            }
            return Detach;
        }

        // newly added
        private List<RailCar>Detach(int fromPosition, RailCar RailCara)
        {
            List<RailCar> Detach = new List<RailCar>();
            
            {
                int indexValue = fromPosition - 1;
                while (indexValue < RailCars.Count)
                {
                    RailCars.RemoveAt(indexValue);
                    Detach.Add(RailCara);
                    indexValue++;
                }
            }
            return Detach;
        }
    }
}
