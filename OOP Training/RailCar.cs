using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrainSystem
{
	public class RailCar
	{
		private int _Capacity;
		private int _LightWeight;
		private int _LoadLimit;
		private string _SerialNumber;


		public int LightWeight
		{
			get { return _LightWeight; }
			private set
			{
				if (!Utilities.IsPositive(value))
				{
					throw new ArgumentNullException("Light Weight should not be a negative value.");
				}
				if (!Utilities.IsHundredMultiple(value))
				{
					throw new ArgumentNullException("Light Weight must be multiple of 100.");
				}
				_LightWeight = value;
			}
		}



		public int LoadLimit
		{
			get { return _LoadLimit; }
			private set
			{
				if (!Utilities.IsPositive(value))
				{
					throw new ArgumentNullException("Load Limit should not be a negative value.");
				}
                if (!Utilities.IsHundredMultiple(value))
                {
					throw new ArgumentNullException("Load Limit must be a multiple of 100");
                }
				_LoadLimit = value;
			}
		}


		public int Capacity
		{
			get { return _Capacity; }
			private set
			{
				if (!Utilities.IsPositive(value))
				{
					throw new ArgumentNullException("Capacity should not be a negative value.");
				}
				if (!Utilities.IsHundredMultiple(value))
				{
					throw new ArgumentNullException("Capacity should be multiple of 100.");
				}
               /* if (value >= LoadLimit)
                {
                    throw new ArgumentNullException("Capacity of the rail car must be less than or equal to Load Limit.");
                }*/
                _Capacity = value;
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

		public RailCarType Type { get; private set; }

		public bool IsFull
		{
			get
			{
				return (Capacity * 0.9 < (double)NetWeight);
			}
		}

		public int GrossWeight { get; private set; }
		

		public bool InService { get; set; }

		public int NetWeight
		{ 
			get
			{
				return GrossWeight - LightWeight;
			}
		}

		
		public RailCar(string serialnumber, int lightweight, int capacity, int loadlimit, RailCarType type, bool inservice)
		{
			SerialNumber = serialnumber;
			LightWeight = lightweight;
			Capacity = capacity;
			LoadLimit = loadlimit;
			InService = inservice;
			Type = type;
			GrossWeight = lightweight;
		}


		public void RecordScaleWeight(int grossweight)
		{
			if (!Utilities.IsPositive(grossweight))
			{
				throw new Exception("Gross weight must be a positive value.");
			}
			if (grossweight < LightWeight)
			{
				throw new Exception("Scale Error-Gross weight should be greater than Light Weight.");
			}
			if (grossweight < (LightWeight + LoadLimit))
			{
				throw new Exception("Unsafe Load-Gross weight should be less than sum of Light Weight and Load Limit.");
			}
		}

		public override string ToString()
		{
			return $"{SerialNumber}, {LightWeight}, {Capacity}, {LoadLimit}, {Type}, {InService}";
		}

		// newly added
		public static RailCar Parse(string text)
		{ 
			string[] subParts = text.Split(',');

			if (subParts.Length != 3)
			{
				throw new FormatException("The string provided is not in the proper format");
			}

			return new RailCar(subParts[0], int.Parse(subParts[1]), int.Parse(subParts[2]),
							   int.Parse(subParts[3]), (RailCarType)Enum.Parse(typeof(RailCarType),
							   subParts[4]), bool.Parse(subParts[5]));
		}

		// newly added
		public static bool TryParse(string text, out RailCar outputTryParse)
		{ 
			outputTryParse = null;
			bool isValid = false;
		
			try
			{
				outputTryParse = Parse(text);
				isValid = true;
				
			}
			catch (Exception ex)
			{ 
				throw new Exception(ex.Message);
			}

			return isValid;
		}
	}

}