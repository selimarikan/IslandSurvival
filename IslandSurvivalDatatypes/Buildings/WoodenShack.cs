using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandSurvivalDatatypes.Buildings
{
    public class WoodenShack : ResidentialBuilding
    {
        public WoodenShack()
        {
            Capacity = 4;
            WoodCost = 50;
        }
    }
}
