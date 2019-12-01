using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Boat
    {
        ///Initialises Class Variables
        private string Name;
        private string LicenceNumber;
        private decimal MaximumLoad;
        private decimal ShipHaul;
        private decimal[] LiveWeight;
        private string[] fishSpecies;
        private decimal[] QuotaFilled;

        public Boat()
        {
            Name = "N/A";
            LicenceNumber = "N/A";
            MaximumLoad = 0m;
            ShipHaul = 0m;
            fishSpecies = new string[] { "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
            QuotaFilled = new decimal[] { 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m };
            LiveWeight = new decimal[] { 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m};
        }

        public Boat(string ShipName, string ShipLicence, decimal MaximumCapacity, decimal SelectedShipHaul, string[] caughtSpecies, decimal[] QuotaCaught, decimal[] SelectedShipLiveWeight)
        {
            Name = ShipName;
            LicenceNumber = ShipLicence;
            MaximumLoad = MaximumCapacity;
            ShipHaul = SelectedShipHaul;
            fishSpecies = caughtSpecies;
            QuotaFilled = QuotaCaught;
            LiveWeight = SelectedShipLiveWeight;
        }

        /// Verifies and then returns Name
        public string GetName
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        /// Verifies and then returns LicenseNumber
        public string GetLicence
        {
            get
            {
                return LicenceNumber;
            }
            set
            {
                LicenceNumber = value;
            }
        }

        /// Verifies and then returns MaximumLoad
        public decimal GetMaximumLoad
        {
            get
            {
                return MaximumLoad;
            }
            set
            {
                MaximumLoad = value;
            }
        }

        /// Verifies and then returns ShipHaul
        public decimal GetShipHaul
        {
            get
            {
                return ShipHaul;
            }
            set
            {
                ShipHaul = value;
            }
        }

        /// Verifies and then returns LiveWeight
        public decimal[] GetLiveWeight
        {
            get
            {
                return LiveWeight;
            }
            set
            {
                LiveWeight = value;
            }
        }

        /// Verifies and then returns fishSpecies
        public string[] GetFishSpecies
        {
            get
            {
                return fishSpecies;
            }
            set
            {
                fishSpecies = value;
            }
        }

        /// Verifies and then returns QuotaFilled
        public decimal[] GetFilledQuota
        {
            get
            {
                return QuotaFilled;
            }
            set
            {
                QuotaFilled = value;
            }
        }
    }
}