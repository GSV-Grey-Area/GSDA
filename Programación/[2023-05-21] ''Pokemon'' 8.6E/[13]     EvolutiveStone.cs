using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
	[Serializable]
	public class EvolutiveStone : Item
	{
		Species[] compatibleSpecies;
		public EvolutiveStone(string n_name, Species[] n_compatibleSpecies) : base(n_name)
		{
			this.compatibleSpecies = n_compatibleSpecies;
			this.name = n_name;
			this.type = 5;
			return;
		}
	}
}
