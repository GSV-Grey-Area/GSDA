using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
	[Serializable]
	public class Treasure : Item
	{
		public Treasure(string n_name, int nPrice) : base(n_name)
		{
			this.name = n_name;
			this.type = 4;
			this.price = nPrice;
			return;
		}

		new public int GetPrice()
		{
			return price;
		}
	}
}
