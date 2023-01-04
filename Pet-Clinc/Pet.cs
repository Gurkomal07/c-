using System;
namespace Assignment_4
{
    public class Pet
    {
        // Fields
        private string _name = "Spot";
        private int _age = 1;
        private double _weight = 5;
        private string _type = "D";

        // Accessors through properties
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new Exception("Can't left the name field empty.");
                } // end of if
                else
                {
                    _name = value;
                } // end of else
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Sorry! Minimum age of the pet must be 1 year.");
                } // end of if
                else
                {
                    _age = value;
                } // end of else
            }
        }

        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value < 5)
                {
                    throw new Exception("Sorry! Minimum weight of the pet must be 5 pounds.");
                } // end of if
                else
                {
                    _weight = value;
                } // end of else
            }
        }

        public string Type
        {
            get
            {
                if (_type == "C")
                {
                    return "Cat";
                } // end of if
                else if (_type == "D")
                {
                    return "Dog";
                } // end of else if
                else
                {
                    return _type;
                } // end of else
            }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new Exception("Can't left the type field empty.");
                } // end of if
                else if(_type == "Cat")
                {
                    _type =  "Cat";
                } // end of else if
                else if (_type == "Dog")
                {
                    _type = "Dog";
                } // end of else if
                else
                {
                    _type = value;
                } // end of else       
            }
        }

        // Constructors
        // Empty constructor
        public Pet()
        {
        }

        // Greedy construtor
        public Pet(string name, int age, double weight, string type)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Type = type;
        }

        // Methods
        public double Acepromazine(double weight, string type)
        {
            double dosage = 0;

            if (type == "D")
            {
                dosage = weight * (0.03 / 10);
            } // end of if
            else if (type == "C")
            {
                dosage = weight * (0.002 / 10);
            } // end of else if

            return dosage;
        } // end of method

        public double Carprofen(double weight, string type)
        {
            double dosage = 0;

            if (type == "D")
            {
                dosage = weight * (0.5 / 12);
            }  // end of if
            else if (type == "C")
            {
                dosage = weight * (0.25 / 12);
            } // end of else if

            return dosage;
        } // end of method
    } // end of class
} // end of namespace
