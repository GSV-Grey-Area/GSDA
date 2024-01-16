using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
	[Serializable]
	public class MT : Item
	{
		Move movement;

		public MT(string n_name, Move movement) : base(n_name)
		{
			this.name = n_name;
			this.type = 3;
			this.movement = movement;
			return;
		}

		public void UseItem(Pokemon pokemon)
		{
			pokemon.AddMove(movement);
		}
	}
}
