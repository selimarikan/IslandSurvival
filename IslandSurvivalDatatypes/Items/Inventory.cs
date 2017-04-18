using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandSurvivalDatatypes.Items
{
    public class Inventory : Entity
    {
        public uint Capacity { get; set; }
        public List<Item> Items { get; set; }

        public Inventory()
        {
            Items = new List<Item>((int)Capacity);
        }

        public uint GetItemCount<T>()
        {
            return (uint)Items.Count(item => item is T);
        }

        public void RemoveItem<T>(int removeCount = 1)
        {
            var tItems = Items.OfType<T>().ToList();
            if (tItems.Count() >= removeCount)
            {
                while (removeCount > 0)
                {
                    Items.Remove(tItems.ElementAt(0) as Item);
                    removeCount--;
                }
            }
        }

    }
}
