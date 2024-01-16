using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
	[Serializable]
	public class Bag
	{
		int capacity;
		Game g;
		IO io;
		Inventory[] bag;

		// Max 999 per object.

		public Bag(Game n_g, IO n_io, Inventory[] n_bag)
		{
			this.g = n_g;
			this.io = n_io;
			this.bag = n_bag;
			return;
		}

		public void DeleteItem()
		{
			return;
		}

		public void CheckItemAmount()
		{
			return;
		}

		public void CheckForItem()
		{
			return;
		}

		public void ObjectInfo()
		{
			return;
		}

		public int GetAmount(Item n_item)
		{
			int amount = bag[n_item.Type()].GetAmount(n_item);
			return amount;
		}

		public void AddItem(Item n_item, int amount, int origAmount)
		{
			io.WriteLine("Bag add item amount: " + amount + "(" + origAmount + ")");
			bag[n_item.Type()].AddItem(n_item, amount, origAmount);
		}

		public void RemoveItem(Item n_item, int amount)
		{
			bag[1].RemoveItem(n_item, amount, bag[1].GetAmount(n_item));
		}

		public void ExperimentalList()
		{
			for (int i = 0; i < bag.Length; i++)
			{
				bag[i].List();
			}
		}
	}
}
