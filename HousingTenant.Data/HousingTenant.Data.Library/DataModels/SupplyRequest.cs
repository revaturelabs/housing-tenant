using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Data.Library.DataModels
{
    // numSupplies is the "size of" the enum, and therefore the size needed by the List
    // This allows the enumeration to be expanded without breaking existing code

    public enum Supplies {Soap = 0, PaperTowels, TrashBags, Sponges, numSupplies}


    public class SupplyRequest
    {
        public string content { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTime timeOfRequest { get; set; }
        
        public List<bool> supplies = new List<bool>((int)Supplies.numSupplies);
    }
}
