using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
	public class Shop : EconomicEntity
	{
		Game g;
		IO io;
		Inventory inventory;

		public Item[] GetInventory()
		{
			return inventory.GetInventory();
		}

		public Shop(Game n_g, IO n_io, Inventory n_inventory)
		{
			this.g = n_g;
			this.io = n_io;
			this.inventory = n_inventory;
		}

		public int GetAmount(Item n_item)
		{
			int amount = inventory.GetAmount(n_item);
			return amount;
		}

		public void AddItem(Item n_item, int amount, int origAmount)
		{
			inventory.AddItem(n_item, amount, origAmount);
		}

		public void RemoveItem(Item n_item, int n_amount, int origAmount)
		{
			io.WriteLine("shop remove item: " + this.GetAmount(n_item) + "(" + origAmount + ")");
			inventory.RemoveItem(n_item, n_amount, origAmount);
		}

		public void List()
		{
			inventory.List();
		}
	}
}
