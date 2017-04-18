using System.Collections.Generic;
using IslandSurvivalDatatypes.Characters;
using IslandSurvivalDatatypes.Items;

namespace IslandSurvivalDatatypes.Locations
{
    public class Location : Entity
    {
        public Inventory Inventory { get; set; }

        public uint CharacterCapacity { get; set; }
        public List<Character> Characters { get; set; }

        public Location()
        {
            Characters = new List<Character>();
            Inventory = new Inventory();
        }
    }
}
