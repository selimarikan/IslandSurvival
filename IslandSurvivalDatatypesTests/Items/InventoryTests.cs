using Microsoft.VisualStudio.TestTools.UnitTesting;
using IslandSurvivalDatatypes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandSurvivalDatatypes.Items.Tests
{
    [TestClass()]
    public class InventoryTests
    {
        [TestMethod()]
        public void RemoveItemTest()
        {
            var inventory = new Inventory();
            int itemCount = 100;

            // Add items
            for (int iItem = 0; iItem < itemCount; iItem++)
            {
                if (iItem % 3 == 0)
                {
                    inventory.Items.Add(new Wood());
                }
                else if (iItem % 3 == 1)
                {
                    inventory.Items.Add(new Stone());
                }
                else
                {
                    inventory.Items.Add(new Leather());
                }
            }

            // Remove items
            var rng = new Random();
            while (inventory.Items.Count > 0)
            {
                int number = rng.Next(3);

                if (number == 0)
                {
                    inventory.RemoveItem<Wood>();
                }
                else if (number == 1)
                {
                    inventory.RemoveItem<Stone>();
                }
                else
                {
                    inventory.RemoveItem<Leather>();
                }
            }

        }

        [TestMethod()]
        public void AddItemTest()
        {
            var inventory = new Inventory();
            int itemCount = 100;

            // Add items
            for (int iItem = 0; iItem < itemCount; iItem++)
            {
                int previousItemCount = inventory.Items.Count;

                if (iItem % 3 == 0)
                {
                    inventory.AddItem<Wood>();
                }
                else if (iItem % 3 == 1)
                {
                    inventory.Items.Add(new Stone());
                }
                else
                {
                    inventory.Items.Add(new Leather());
                }

                if (inventory.Items.Count != previousItemCount + 1)
                {
                    Assert.Fail();
                }
            }
        }
    }
}