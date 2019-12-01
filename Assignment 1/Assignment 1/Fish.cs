using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Fish
    {
        ///Initialises Class Variables
        private static readonly string[] speciesName = { "Angler", "Cod", "Haddock", "Hake", "Horse Mackerel", "Witches", "Plaice", "Skates and Rays", "Whiting" };
        private static readonly decimal[] speciesFactor = { 1.22m, 1.17m, 1.17m, 1.11m, 1.08m, 1.06m, 1.05m, 1.13m, 1.18m };
        private static readonly decimal[] maxQuota = { 5000m, 3000m, 4000m, 1000m, 500m, 3000m, 8000m, 1800m, 7000m };

        public Fish(string fishName, decimal fishFactor, decimal maximumQuota)
        {
            fishName = "N/A";
            fishFactor = 0m;
            maximumQuota = 0m;
        }

        /// Returns speciesName
        public static string[] GetName
        {
            get
            {
                return speciesName;
            }
        }

        /// Returns speciesFactor
        public static decimal[] GetFactor
        {
            get
            {
                return speciesFactor;
            }
        }

        /// Returns maxQuota
        public static decimal[] GetQuota
        {
            get
            {
                return maxQuota;
            }
        }
    }
}