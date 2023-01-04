using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrainSystem
{
	public class Engine
	{
		private int _HP;
		private string _SerialNumber;
		private string _Model;
		private int _Weight;



		public int HP
		{
			get { return _HP; }
			private set
			{
				if (value < 3500 || value >= 5500)
				{
					throw new ArgumentOutOfRangeException("Horse Power should be a positive value between 3500 and 5500.");
				}
                if (!Utilities.IsPositive(value))	
                {
					throw new ArgumentNullException("Value of HP can't be negative.");
                }
                if (!Utilities.IsHundredMultiple(value))
                {
					throw new ArgumentNullException("HP of an engine must be multiple of 100");
                }
				_HP = value;
			}
		}


		public string SerialNumber
		{
			get { return _SerialNumber; }
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("You cannot leave Serial number empty.");
				}
				_SerialNumber = value.Trim();
			}
		}


		public string Model
		{
			get { return _Model; }
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("You cannot leave Model field empty.");
				}
				_Model = value.Trim();
			}
		}


		public int Weight
		{
			get { return _Weight; }
			private set
			{
				if (!Utilities.IsPositive(value))
				{
					throw new ArgumentNullException("Weight should not be a negative value.");
				}
				if (!Utilities.IsHundredMultiple(value))
				{
					throw new ArgumentNullException("Weight of an engine must be multiple of 100");
				}
				_Weight = value;
			}
		}

		public Engine(int hp, string serialnumber, string model, int weight)
		{
			HP = hp;
			SerialNumber = serialnumber;
			Model = model;
			Weight = weight;
		}

		public override string ToString()
		{
			return $"{_HP}, {_SerialNumber}, {_Model}, {_Weight}";
		}
	}
}