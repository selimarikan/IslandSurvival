using IslandSurvivalDatatypes.Items;

namespace IslandSurvivalDatatypes.Locations
{
    public class Shore : Location
    {
        public Shore()
        {
            Inventory.Capacity = 30;
            Population.Capacity = 5;
            Name = "Shore";
        }
    }
}
