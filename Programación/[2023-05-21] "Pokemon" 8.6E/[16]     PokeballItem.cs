using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
	[Serializable]
	public class PokeballItem : Item
	{
		float captureRatio;

		public PokeballItem(string n_name, float n_captureRatio, int n_price) : base(n_name)
		{
			this.name = n_name;
			this.captureRatio = n_captureRatio;
			this.price = n_price;
			this.type = 1;
			return;
		}
	}
}
