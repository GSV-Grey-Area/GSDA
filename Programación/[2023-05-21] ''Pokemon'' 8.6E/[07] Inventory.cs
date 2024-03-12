using System;
using System.Collections.Generic;
using System.Text;
using Pokemon;

namespace Pokemon
{
	[Serializable]
	public class Inventory
	{
		protected Item[] items;
		protected Game g;
		protected IO io;
		protected string name;

		public Item[] GetInventory()
		{
			return items;
		}

		public Inventory(Game n_g, IO n_io, string n_name)
		{
			this.items = new Item[50];
			this.g = n_g;
			this.io = n_io;
			this.name = n_name;
			return;
		}

		public string GetName()
		{
			return name;
		}

		public void List()
		{
			bool inventoryEmpty = true;
			for (int i = 0; i < items.Length; i++)
			{
				if (items[i] != null)
				{
					inventoryEmpty = false;
				}
			}

			if (inventoryEmpty == false)
			{
				io.WriteLine(this.name);
				io.WriteLine
				(
					io.Padder("Nº", 5) +
					io.Padder("Objeto", 20) +
					io.Padder("Cantidad", 10) +
					io.Padder("Precio", 10)
				);
				io.WriteLine(io.Liner(45));
			}
			else
			{
				io.WriteLine("Inventorio vacío");
			}

			for (int i = 0; i < items.Length; i++)
			{
				if (items[i] != null)
				{
					io.WriteLine
					(
						io.Padder(i + "", 5) +
						io.Padder(items[i].GetName(), 20) +
						io.Padder(items[i].GetAmount() + "", 10) +
						io.Padder(items[i].GetPrice() + "", 10)
					);
				}
			}

			io.WriteLine("");
		}

		/*public void TransferItem(Inventory seller, Inventory buyer, Item item)
		{
			AddItem(buyer, item);
			RemoveItem(seller, item);
			return;
		}*/

		/*public void AddItem(Item item)
		{
			inventory[0] = item;
			return;
		}*/

		public int GetAmount(Item item)
		{
			for (int i = 0; i < items.GetLength(0); i++)
			{
				if (items[i] != null)
				{
					if (items[i].GetName() == item.GetName())
					{
						return items[i].GetAmount();
					}
				}
			}

			return 0;
		}

		public void AddItem(Item item, int amount, int origAmount)
		{
			bool found = false;
			int nOrigAmount = origAmount;

			for (int i = 0; i < items.GetLength(0); i++)
			{
				if (items[i] != null)
				{
					if (items[i].GetName() == item.GetName())
					{
						io.WriteLine("Inventory add item: " + amount + "(" + nOrigAmount + ")");
						items[i].Add(amount, this, nOrigAmount);
						found = true;
						break;
					}
				}
			}

			if (found == false)
			{
				if (RoomFind() != -1)
				{
					io.WriteLine("Inventory add item: " + amount + "(" + origAmount + ")");
					//items[i].Add(amount, this, origAmount);
					int room = RoomFind();
					items[room] = item;
					items[room].Add(amount, this, origAmount);
				}
				else
				{
					ReplaceItem(item);
				}
			}

			return;
		}

		public bool RoomCheck()
		{
			for (int i = 0; i < items.GetLength(0); i++)
			{
				if (items[i] == null)
				{
					return true;
				}
			}
			return false;
		}

		public int RoomFind()
		{
			for (int i = 0; i < items.GetLength(0); i++)
			{
				if (items[i] == null)
				{
					return i;
				}
			}
			return -1;
		}

		public void ReplaceItem(Item item)
		{
			io.WriteLine("Equipo lleno.");
			io.WriteLine("¿Quieres quedarte con este Pokémon? S/N");
			char answer = io.ReadLine()[0];
			if (Char.ToLower(answer) == 'n')
			{
				return;
			}
			io.WriteLine("¿Por qué pokémon quieres cambiar el que acabas de capturar?");
			answer = io.ReadLine()[0];
			items[(int)answer - 48] = item;
		}

		public void RemoveItem(Item item, int amount, int origAmount)
		{
			int nOrigAmount = origAmount;
			for (int i = 0; i < items.GetLength(0); i++)
			{
				if (items[i].GetName() == item.GetName())
				{
					items[i].Remove(amount, this, nOrigAmount);
					io.WriteLine("inventory remove item " + amount + "(" + nOrigAmount + ")");
					break;
				}
			}
		}
	}
}
