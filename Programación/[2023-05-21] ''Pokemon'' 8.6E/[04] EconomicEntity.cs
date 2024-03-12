using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
	[Serializable]
	public class EconomicEntity
	{
		protected int money;

		public void TransferMoney(int amount)
		{
			this.money += amount;
		}
	}
}
