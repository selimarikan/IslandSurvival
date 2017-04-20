using System.Collections.Generic;
using System.Linq;

namespace IslandSurvivalDatatypes.Items
{
    public class Inventory : Entity
    {
        public uint Capacity { get; set; }
        public List<Item> Items { get; }

        public Inventory()
        {
            Items = new List<Item>((int)Capacity);
        }

        public uint GetItemCount<T>()
        {
            return (uint)Items.Count(item => item is T);
        }

        public void RemoveItem<T>(uint removeCount = 1)
        {
            var tItems = Items.OfType<T>().ToList();
            if (tItems.Count() < removeCount)
            {
                return;
            }

            while (removeCount > 0)
            {
                Items.Remove(Items.FirstOrDefault(item => item is T));
                removeCount--;
            }
        }

        public void AddItem<T>(uint addCount = 1) where T : new()
        {
            if (!typeof(T).IsSubclassOf(typeof(Item)))
            {
                return;
            }

            for (var iItem = 0; iItem < addCount; iItem++)
            {
                Items.Add((new T()) as Item);
            }
        }
    }
}
