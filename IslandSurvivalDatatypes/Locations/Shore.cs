using IslandSurvivalDatatypes.Items;

namespace IslandSurvivalDatatypes.Locations
{
    public class Shore : Location
    {
        public Shore()
        {
            Inventory.Capacity = 30;
            CharacterCapacity = 5;
            Name = "Shore";
        }
    }
}
