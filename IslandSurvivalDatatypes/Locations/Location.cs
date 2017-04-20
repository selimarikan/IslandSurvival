using System;
using System.Collections.Generic;
using System.Linq;
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

        public void UpdateLocationValues()
        {
            // Update population capacity
            var residentalBuildings = Construction.Buildings.FindAll(building => building is ResidentialBuilding);
            uint newPopCapacity = (uint)residentalBuildings.Sum(building => ((ResidentialBuilding)building).Capacity);
            if (newPopCapacity > Population.Capacity)
            {
                Population.Capacity = newPopCapacity;
            }

            // Update inventory capacity
            var warehouseBuildings = Construction.Buildings.FindAll(building => building is WarehouseBuilding);
            uint newItemCapacity = (uint)warehouseBuildings.Sum(building => ((WarehouseBuilding)building).Capacity);
            if (newItemCapacity > Inventory.Capacity)
            {
                Inventory.Capacity = newItemCapacity;
            }

        }
    }
}
