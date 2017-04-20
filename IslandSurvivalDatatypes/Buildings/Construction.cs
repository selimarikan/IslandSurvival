using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IslandSurvivalDatatypes.Characters;

namespace IslandSurvivalDatatypes.Buildings
{
    public class Construction : Entity
    {
        public uint Capacity { get; set; }
        public List<Building> Buildings { get; set; }

        public Construction()
        {
            Buildings = new List<Building>((int)Capacity);
        }

        public uint GetBuildingCount<T>()
        {
            return (uint)Buildings.Count(item => item is T);
        }

        public void RemoveBuilding<T>(int removeCount = 1)
        {
            var tBuildings = Buildings.OfType<T>().ToList();
            if (tBuildings.Count() < removeCount)
            {
                return;
            }

            while (removeCount > 0)
            {
                Buildings.Remove(tBuildings.ElementAt(0) as Building);
                removeCount--;
            }
        }

        public void AddBuilding<T>(int addCount = 1) where T : new()
        {
            if (!typeof(T).IsSubclassOf(typeof(Building)))
            {
                return;
            }

            for (var iBuilding = 0; iBuilding < addCount; iBuilding++)
            {
                Buildings.Add((new T()) as Building);
            }
        }
    }
}
