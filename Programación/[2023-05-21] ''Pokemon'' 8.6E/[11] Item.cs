using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
	[Serializable]
	public abstract class Item
	{
		protected string name;
		protected int price;
		protected int amount;
		protected int type;
		protected bool sellable;
		// Amount in store, amount in player's inventory?

		public string GetName()
		{
			return name;
		}

		public int GetAmount()
		{
			return amount;
		}

		public int Type()
		{
			return type;
		}

		public void SetAmount(int n_amount)
		{
			this.amount = n_amount;
		}

		public void Add(int n_amount, Inventory xx, int origAmount)
		{
			Console.WriteLine("Item add item: " + amount + "(" + origAmount + ")");

			//this.amount += n_amount;
			this.amount = origAmount + n_amount;
		}

		public void Remove(int n_amount, Inventory xx, int origAmount)
		{
			Console.WriteLine("item remove items " + amount  + ", " + n_amount + "(" + origAmount + ")");
			//this.amount -= n_amount;
			this.amount = origAmount - n_amount;
		}

		public int GetPrice()
		{
			return price;
		}

		public Item(string n_name)
		{
			this.name = n_name;
			return;
		}

		public virtual void UseItem()
		{
			return;
		}

		public void ThrowItem()
		{
			return;
		}
	}
}
