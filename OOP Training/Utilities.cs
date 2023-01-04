using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
    public static class Utilities
    {
        public static bool IsPositive(int numberValue)
        {
            return numberValue >= 0;
        }

        public static bool IsHundredMultiple(int numberValue)
        { 
            return numberValue % 100 == 0;
        }
    }
}
