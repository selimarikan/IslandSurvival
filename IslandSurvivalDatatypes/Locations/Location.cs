using System.Collections.Generic;
using IslandSurvivalDatatypes.Buildings;
using IslandSurvivalDatatypes.Characters;
using IslandSurvivalDatatypes.Items;

namespace IslandSurvivalDatatypes.Locations
{
    public class Location : Entity
    {
        public Inventory Inventory { get; set; }
        public Population Population { get; set; }
        public Construction Construction { get; set; }

        public Location()
        {
            Population = new Population();
            Inventory = new Inventory();
            Construction = new Construction();
        }
    }
}
