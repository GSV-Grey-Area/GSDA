using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
	[Serializable]
	public class BattleItem : Item
	{
		public BattleItem(string n_name) : base(n_name)
		{
			this.name = n_name;
			this.type = 2;
			return;
		}
	}
}
