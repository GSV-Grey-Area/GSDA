using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
	[Serializable]
	public class Medicine : Item
	{
		int minLife;
		int maxLife;
		int healingPower;
		int energizingPower;

		public Medicine(string n_name, int n_minLife, int n_maxLife, int n_healingPower, int n_energizingPower, int n_price) : base(n_name)
		{
			this.name = n_name;
			this.minLife = n_minLife;
			this.maxLife = n_maxLife;
			this.healingPower = n_healingPower;
			this.energizingPower = n_energizingPower;
			this.price = n_price;
			this.type = 0;
			return;
		}
	}
}
